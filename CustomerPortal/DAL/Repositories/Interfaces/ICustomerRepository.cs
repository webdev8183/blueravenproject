// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetTopActiveCustomers(int count);
        IEnumerable<Customer> GetAllCustomersData();
    }
}

/*  public interface ICustomerRepository : IRepository<Customer>
  {
      (Customer customer, int userCount) GetCustomer(int customerId);
      List<(Customer customer, int userCount)> GetCustomers(int? page, int? pageSize);
     // bool TestCanDeleteCustomer(int id);
      // bool TestCanDeleteCustomer(int id);

      //IEnumerable<Customer> GetTopActiveCustomers(int count);
      //IEnumerable<Customer> GetAllCustomersData();
  }
}
*/


