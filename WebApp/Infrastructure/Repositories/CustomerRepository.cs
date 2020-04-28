using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Aplication.Interfaces;
using WebApp.Core.Domain.Entities;
using WebApp.Core.Domain.Enums;

namespace WebApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IEnumerable<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>() {
            new Customer
            {
                CustomerId=1,
                FirstName="lucas",
                LastName ="bolivar",
                Address = "jujuy",
                Status = CustomerStatus.Active
            },
            new Customer
              {
                CustomerId=2,
                FirstName="julieta",
                LastName ="yamin",
                Address = "tucuman",
                Status = CustomerStatus.Paused
            }
            };

        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers;
        }
        public Customer GetCustomerByID(int customerId)
        {
            return _customers.FirstOrDefault(x => x.CustomerId == customerId);
        }


        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}