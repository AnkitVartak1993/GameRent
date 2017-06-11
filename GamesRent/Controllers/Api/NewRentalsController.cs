using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamesRent.Models;
using GamesRent.Dtos;
using AutoMapper;

namespace GamesRent.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals (NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(
        c => c.Id == newRental.CustomerId);

            var games = _context.Games.Where(
                m => newRental.GameIds.Contains(m.Id)).ToList();

            foreach (var game in games)
            {
                if (game.NumbersInStock <= 0)
                    return BadRequest("Game is not available");

                game.NumbersInStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();


        }
    }
}
