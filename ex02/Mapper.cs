﻿using AutoMapper;
using DTO;
using Entities;

namespace ex02
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>().ReverseMap();         
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();


        }

      
    }
}
