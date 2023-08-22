using ClientesApi.Application.Models.Requests;
using ClientesApi.Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Application.Interfaces
{
    public interface IClienteAppService
    {
        ClientesResponse Create(ClientesCreateRequest request);

        ClientesResponse Update(ClientesUpdateRequest request);

        ClientesResponse Delete(Guid id);

        List<ClientesResponse> GetAll();

        ClientesResponse GetById(Guid id);
    }
}
