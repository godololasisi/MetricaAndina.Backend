using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RegistryServices.Application.Dto;
using RegistryServices.Application.Interfaces;
using RegistryServices.Domain;

namespace RegistryServices.Api.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class MaintainerController : Controller
    {
        private readonly IClientUseCase _clientUseCase;

        public MaintainerController(IClientUseCase clientUseCase)
        {
            _clientUseCase= clientUseCase;
        }

        [HttpGet]
        public async Task<List<ClientDto>> GetList()
        {
            return await _clientUseCase.GetClients();
        }

        [HttpPost]
        public async Task SaveList(ClientDto clientDto)
        {
            //await _clientUseCase.RegisterClient(clientDto);
        }
    }
}
