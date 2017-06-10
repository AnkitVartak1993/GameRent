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

            Mapper.CreateMap<Customer, CustomerDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Game, GameDto>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<GameDto, Game>();


        }
    }
}