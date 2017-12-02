﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using CustomerPortal.ViewModels;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CustomerPortal.Helpers;

namespace CustomerPortal.Controllers
{
    public class CustomerController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;


        public CustomerController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            

        }



        // GET: api/values
        [HttpGet]
        public IActionResult Get()

        {
            var allCustomers = _unitOfWork.Customers.GetAllCustomersData();
            return Ok(Mapper.Map<IEnumerable<CustomerViewModel>>(allCustomers));
        }



        [HttpGet("throw")]
        public IEnumerable<CustomerViewModel> Throw()
        {
            throw new InvalidOperationException("This is a test exception: " + DateTime.Now);
        }



        [HttpGet("email")]
        public async Task<string> Email()
        {
            string recepientName = "QickApp Tester"; //         <===== Put the recepient's name here
            string recepientEmail = "test@ebenmonney.com"; //   <===== Put the recepient's email here

            string message = EmailTemplates.GetTestEmail(recepientName, DateTime.UtcNow);

            (bool success, string errorMsg) response = await EmailSender.SendEmailAsync(recepientName, recepientEmail, "Test Email from RepairProject", message);

            if (response.success)
                return "Success";

            return "Error: " + response.errorMsg;
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value: " + id;
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }



        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
