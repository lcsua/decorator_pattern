using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Aplication.Interfaces;
using WebApp.Core.Domain.Entities;

namespace WebApp.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json",
              "application/xml")]
    [Route("api/v{version:apiVersion}/[controller]")]
    
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

       
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Customer>), 200)]
        public IActionResult Index()
        {
            return  Ok(_customerRepository.GetCustomers());
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(Customer), 200)]
        public IActionResult Index(int customerId)
        {
            return Ok(_customerRepository.GetCustomerByID(customerId));
        }
    }
}