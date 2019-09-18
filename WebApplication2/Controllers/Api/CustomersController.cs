using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;
using WebApplication2.Dtos;
using AutoMapper;

namespace WebApplication2.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        // GET api/<controller>
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var cust = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return cust;
        }

        // GET api/<controller>/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customerInDb));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}