using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GamesRent.Models
{
    public class Rental
    {
        public int Id { get; set; }

        
        public Customer Customer { get; set; }

        public Game Game { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

    }
}