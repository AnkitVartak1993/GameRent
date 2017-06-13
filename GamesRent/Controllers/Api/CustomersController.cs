using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamesRent.Models;
using GamesRent.Dtos;
using AutoMapper;
using System.Data.Entity;
namespace GamesRent.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;


        public CustomersController(){
            _context = new ApplicationDbContext();
            }
        // GET api/<controller>
       public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MemberShipType);
            // to check if query matches any records
            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            
            return Ok(customerDtos);    
        }


        //Getting Customer Info
        // GET api/<controller>/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }


        //Creating Customer
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult  CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created( new Uri(Request.RequestUri + "/" +customer.Id),customerDto);

        }

        //Updating Customer Information
        [HttpPut]
        // PUT api/<controller>/5
        public void Put(int id, CustomerDto customer)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //customerInDb.Name = customer.Name;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribedtoNews = customer.IsSubscribedtoNews;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            Mapper.Map(customer, customerInDb);



            _context.SaveChanges();
        }

        //Deleting Customer From the List 
        [HttpDelete]
        // DELETE api/<controller>/5
        public void Delete(int id)
        {


            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();







        }
    }
}