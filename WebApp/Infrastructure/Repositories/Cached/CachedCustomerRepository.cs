using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Core.Aplication.Interfaces;
using WebApp.Core.Domain.Entities;

namespace WebApp.Infrastructure.Repositories.Cached
{
    public class CachedCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMemoryCache _cache;
      
        public CachedCustomerRepository(ICustomerRepository customerRepository, IMemoryCache memoryCache)
        {
            _customerRepository = customerRepository;
            _cache = memoryCache;
        }



        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }

        public Customer GetCustomerByID(int customerId)
        {
            Customer customer;
            var cacheId = $"customer_{customerId}";
            if (!_cache.TryGetValue(cacheId, out customer))
            {
                // customer not is in cache, so get data from reository.
                customer = _customerRepository.GetCustomerByID(customerId);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                // Save customer in cache.
                _cache.Set(cacheId, customer, cacheEntryOptions);
            }

            return  customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customers;
            var cacheId = $"Customers";
            if (!_cache.TryGetValue(cacheId, out customers))
            {
                // customer not is in cache, so get data from reository.
                customers = _customerRepository.GetCustomers();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                // Save customer in cache.
                _cache.Set(cacheId, customers, cacheEntryOptions);
            }

            return customers;
        }

        public void InsertCustomer(Customer customer)
        {
            _customerRepository.InsertCustomer(customer);
        }

        public void Save()
        {
            _customerRepository.Save();
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }
    }
}
