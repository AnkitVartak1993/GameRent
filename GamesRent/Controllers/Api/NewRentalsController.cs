using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GamesRent.Dtos;

namespace GamesRent.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        [HttpPost]
        public IHttpActionResult CreateNewRentals (NewRentalDto newRental)
        {
            throw new Exception();
        }
    }
}
