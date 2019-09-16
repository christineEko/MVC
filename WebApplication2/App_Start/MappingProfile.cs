using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Dtos;

namespace WebApplication2
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();


            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }

        protected override void Configure()
        {
            return;
        }
    }
}