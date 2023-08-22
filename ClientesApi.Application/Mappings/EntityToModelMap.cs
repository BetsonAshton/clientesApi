using AutoMapper;
using ClientesApi.Application.Models.Responses;
using ClientesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Application.Mappings
{
    public class EntityToModelMap:Profile
    {
        public EntityToModelMap() 
        {

            CreateMap<Cliente, ClientesResponse>();
        
        }
    }
}
