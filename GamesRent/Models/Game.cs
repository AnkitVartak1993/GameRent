using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesRent.Models
{
    public class Game
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public String Genre { get; set; }

        public DateTime GameAdded { get; set; }

        public int InStock { get; set; }



    }


}