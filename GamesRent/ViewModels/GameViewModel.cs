using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamesRent.Models;


namespace GamesRent.ViewModels
{
    public class GameViewModel
    {
        public Game Game { get; set; }
        public List<Customer> Customers { get; set; }
    }
}