using AutoMapper;
using ClientesApi.Application.Interfaces;
using ClientesApi.Application.Models.Requests;
using ClientesApi.Application.Models.Responses;
using ClientesApi.Domain.Entities;
using ClientesApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Application.Services
{
    public class ClienteAppService: IClienteAppService
    {
        private readonly IClienteDomainService _clienteDomainService;
        private readonly IMapper _mapper;

        public ClienteAppService(IClienteDomainService clienteDomainService, IMapper mapper)
        {
            _clienteDomainService = clienteDomainService;
            _mapper = mapper;
        }

        public ClientesResponse Create(ClientesCreateRequest request)
        {
            var cliente = _mapper.Map<Cliente>(request);
            _clienteDomainService.Create(cliente);

           return _mapper.Map<ClientesResponse>(cliente);
        }

        public ClientesResponse Update(ClientesUpdateRequest request)
        {
            var cliente = _mapper.Map<Cliente>(request);
            _clienteDomainService.Update(cliente);

            return _mapper.Map<ClientesResponse>(cliente);

        }

        public ClientesResponse Delete(Guid id)
        {
            var cliente = _clienteDomainService.GetById(id);
            _clienteDomainService.Delete(cliente);

            return _mapper.Map<ClientesResponse>(cliente);

        }

        public List<ClientesResponse> GetAll()
        {
            var cliente = _clienteDomainService.GetAll();
            return _mapper.Map<List<ClientesResponse>>(cliente);
        }

        public ClientesResponse GetById(Guid id)
        {
            var cliente = _clienteDomainService.GetById(id);
            
            return _mapper.Map<ClientesResponse>(cliente);
        }
    }
}
