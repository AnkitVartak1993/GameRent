using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GamesRent.Models;

namespace GamesRent.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedtoNews { get; set; }
        public MembershipTypeDto MemberShipType { get; set; }

        //[Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        //[Min18year]
        public DateTime? BirthDate { get; set; }


    }
}