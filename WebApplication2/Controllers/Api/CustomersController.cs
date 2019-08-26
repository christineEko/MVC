using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET api/<controller>/5
        public Customer GetCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customerInDb;
        }

        // POST api/<controller>
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}