using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.ComponentModel.DataAnnotations;
namespace GamesRent.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Required]
        public String Genre { get; set; }

        [Required]
        public DateTime GameAdded { get; set; }

        [Required]
        public int InStock { get; set; }
        [Required]
        public DateTime ReleaseDate { get;  set;}

        public int NumbersInStock { get; set; }

    }


}