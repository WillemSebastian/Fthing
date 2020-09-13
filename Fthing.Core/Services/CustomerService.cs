using Fthing.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fthing.Core.Services
{
    public class CustomerService : ICustomerService
    {
        protected ApplicationDbContext _centralEntities;

        public CustomerService(ApplicationDbContext centralEntities)
        {
            _centralEntities = centralEntities;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = _centralEntities.Customers.ToList();
            return customers;
        }

        public Customer GetCustomer()
        {
            var customer = _centralEntities.Customers.FirstOrDefault();
            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            _centralEntities.Customers.Add(customer);
            _centralEntities.SaveChanges();
            return null;
        }

        public Customer EditCustomer(Customer customer, long customerId)
        {
            Customer _customer = _centralEntities.Customers.Where(_ => _.Id == customerId).FirstOrDefault();
            _customer.Name = customer.Name;
            _customer.Email = customer.Email;
            _customer.Gender = customer.Gender;
            _customer.Is_married = customer.Is_married;
            _customer.Address = customer.Address;

            _centralEntities.SaveChanges();
            return null;
        }

        public Customer DeleteCustomer(long customerId)
        {
            Customer customer = _centralEntities.Customers.Where(_ => _.Id == customerId).FirstOrDefault(); 
            _centralEntities.Customers.Remove(customer);
            _centralEntities.SaveChanges();
            return null;
        }
    }
}
