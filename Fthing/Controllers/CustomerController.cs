using Fthing.Core;
using Fthing.Core.Models;
using Fthing.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fthing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected ApplicationDbContext _centralEntities;
        private readonly ICustomerService _customerService;
        protected IHttpContextAccessor _contextAccessor;

        public CustomerController(ApplicationDbContext centralEntities, IHttpContextAccessor contextAccessor, ICustomerService customerService)
        {
            _centralEntities = centralEntities;
            _contextAccessor = contextAccessor;
            _customerService = customerService;
        }

        [HttpGet()]
        [AllowAnonymous]
        public IActionResult GetCustomer()
        {
            try
            {
                List<Customer> customer = _customerService.GetCustomers();
                return Ok(customer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost()]
        [AllowAnonymous]
        public IActionResult AddCustomer([FromBody]Customer customer)
        {
            try
            {
                _customerService.AddCustomer(customer);
                return Ok("Success Add Customer");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut()]
        [AllowAnonymous]
        public IActionResult EditCustomer([FromBody] Customer customer, [FromQuery]long customerId)
        {
            try
            {
                _customerService.EditCustomer(customer, customerId);
                return Ok("Success Edit Customer");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete()]
        [AllowAnonymous]
        public IActionResult DeleteCustomer([FromQuery] long customerId)
        {
            try
            {
                _customerService.DeleteCustomer(customerId);
                return Ok("Success Delete Customer");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
