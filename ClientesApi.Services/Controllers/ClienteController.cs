using ClientesApi.Application.Interfaces;
using ClientesApi.Application.Models.Requests;
using ClientesApi.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        public IActionResult Post(ClientesCreateRequest request)
        {
            return StatusCode(201, new
            {
                mensagem = "Cliente cadastrado com sucesso.",
                cliente = _clienteAppService.Create(request)
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClientesResponse), StatusCodes.Status200OK)]
        public IActionResult Put(ClientesUpdateRequest request)
        {
            return StatusCode(200, new
            {
                mensagem = "Cliente atualizado com sucesso.",
                cliente = _clienteAppService.Update(request)
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, new
            {
                mensagem = "O seguinte Cliente foi excluido com sucesso.",
                cliente = _clienteAppService.Delete(id)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClientesResponse>), 200)]
        public IActionResult GetAll()
        {
            return StatusCode(200, _clienteAppService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _clienteAppService.GetById(id));
        }
    }
}
