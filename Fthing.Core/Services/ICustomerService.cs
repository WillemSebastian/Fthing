using Fthing.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fthing.Core.Services
{
    public interface ICustomerService
    {
        public List<Customer> GetCustomers();
        public Customer GetCustomer();
        public Customer AddCustomer(Customer customer);
        public Customer EditCustomer(Customer customer, long customerId);
        public Customer DeleteCustomer(long customerId);
    }
}
