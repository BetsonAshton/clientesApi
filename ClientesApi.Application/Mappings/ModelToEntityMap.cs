using AutoMapper;
using ClientesApi.Application.Models.Requests;
using ClientesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Application.Mappings
{
    public class ModelToEntityMap: Profile
    {
        public ModelToEntityMap() 
        {

            CreateMap<ClientesCreateRequest, Cliente>()
               .AfterMap((src, dest) =>
               {
                   dest.Id = Guid.NewGuid();
                   dest.DataHoraCriacao = DateTime.Now;
               });

            CreateMap<ClientesUpdateRequest, Cliente>();


        }   
    }
}
