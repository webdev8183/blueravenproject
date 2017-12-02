// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomerPortal.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string BusinessName { get; set;}
        public string CustomerType { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int UsersCount { get; set; }
        public string Staff { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }
    }




    public class CustomerViewModelValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(register => register.Name).NotEmpty().WithMessage("Customer name cannot be empty");
            RuleFor(register => register.Gender).NotEmpty().WithMessage("Gender cannot be empty");
        }
    }
}
