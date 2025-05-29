using LibraryManagement.Models.Dtos;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<Client>>>> GetAllClients()
        {
            var responseObject = await _clientService.GetAllClientsAsync();

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }



        [HttpGet("id")]
        public async Task<ActionResult<ResponseObject<List<Client>>>> GetClientById(int id)
        {
            var responseObject = await _clientService.GetClientByIdAsync(id);

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ResponseObject<List<Client>>>> CreateClient(ClientDto clientDto)
        {
            var responseObject = await _clientService.CreateClientAsync(clientDto);

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult<ResponseObject<List<Client>>>> UpdateClient(int id, ClientDto clientDto)
        {
            var responseObject = await _clientService.UpdateClientAsync(id, clientDto);

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }
    }
}
