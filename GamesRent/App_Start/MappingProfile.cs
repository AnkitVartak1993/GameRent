﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GamesRent.Models;
using GamesRent.Dtos;

namespace GamesRent.App_Start
{
    public class MappingProfile :Profile
    {


        public MappingProfile()
        {

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore()); ;
            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<GameDto, Game>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Rental, NewRentalDto>();
            // Mapper.CreateMap<MembershipTypeDto, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore());

        }
    }
}