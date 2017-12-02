// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using CustomerPortal.ViewModels;
using AutoMapper;
using DAL.Models;
using Microsoft.Extensions.Logging;
using CustomerPortal.Helpers;
using DAL.Core;
namespace backupCustomerPortal.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        private const string GetCustomerByIdActionName = "GetCustomerById";


        public CustomersController(IUnitOfWork unitOfWork, ILogger<CustomersController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        [HttpGet("{id}", Name = GetCustomerByIdActionName)]
        [Produces(typeof(CustomerViewModel))]
        public IActionResult GetCustomerById(int id)
        {
            var customerAndUsercount = _unitOfWork.Customers.GetCustomer(id);

            if (customerAndUsercount.customer != null)
                return Ok(ConvertToCustomerViewModel(customerAndUsercount));
            else
                return NotFound(id);
        }



        [HttpGet("{page:int?}/{pageSize:int?}")]
        [Produces(typeof(List<CustomerViewModel>))]
        public IActionResult GetAllCustomers(int? page, int? pageSize)
        {
            int? page_ = page < 0 ? (int?)null : page;
            int? pageSize_ = pageSize < 0 ? (int?)null : pageSize;

            var customers = _unitOfWork.Customers.GetCustomers(page_, pageSize_);

            List<CustomerViewModel> customerVMs = new List<CustomerViewModel>(customers.Count);
            customers.ForEach(r => customerVMs.Add(ConvertToCustomerViewModel(r)));

            return Ok(customerVMs);
        }



        [HttpPost]
        public IActionResult CreateCustomer([FromBody]CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                if (customerVM == null)
                    return BadRequest($"{nameof(customerVM)} cannot be null");


                Customer customer = Mapper.Map<Customer>(customerVM);
                customer.DateCreated = customer.DateModified = DateTime.UtcNow;

                _unitOfWork.Customers.Add(customer);
                _unitOfWork.SaveChanges();

                customerVM = Mapper.Map<CustomerViewModel>(customer);

                return CreatedAtAction(GetCustomerByIdActionName, new { id = customerVM.Id }, customerVM);
            }

            return BadRequest(ModelState);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody]CustomerViewModel customerVM)
        {
            if (ModelState.IsValid)
            {
                if (customerVM == null)
                    return BadRequest($"{nameof(customerVM)} cannot be null");

                if (customerVM.Id != 0 && id != customerVM.Id)
                    return BadRequest("Conflicting customer id in parameter and model data");


                Customer customer = _unitOfWork.Customers.Get(id);

                if (customer == null)
                    return NotFound(id);


                Mapper.Map<CustomerViewModel, Customer>(customerVM, customer);
                customer.DateModified = DateTime.UtcNow;

                _unitOfWork.SaveChanges();

                return NoContent();
            }

            return BadRequest(ModelState);
        }



        [HttpDelete("{id}")]
        [Produces(typeof(CustomerViewModel))]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_unitOfWork.Customers.TestCanDeleteCustomer(id))
                return BadRequest("Customer cannot be deleted. Remove all dependencies and try again");


            Customer customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return NotFound(id);

            CustomerViewModel customerVM = Mapper.Map<CustomerViewModel>(customer);

            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.SaveChanges();

            return Ok(customerVM);
        }




        private CustomerViewModel ConvertToCustomerViewModel((Customer customer, int userCount) customerAndUserCount)
        {
            CustomerViewModel customerVM = Mapper.Map<CustomerViewModel>(customerAndUserCount.customer);
            customerVM.UsersCount = customerAndUserCount.userCount;

            return customerVM;
        }



        private void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}
