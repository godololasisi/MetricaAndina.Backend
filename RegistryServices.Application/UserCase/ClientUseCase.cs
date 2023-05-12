using AutoMapper;
using RegistryServices.Application.Dto;
using RegistryServices.Application.Interfaces;
using RegistryServices.Domain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryServices.Application.UserCase
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientUseCase(
            IClientRepository clientRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> GetClients()
        {
            var client =  await _clientRepository.GetClientRepository();

            return _mapper.Map<List<Client>, List<ClientDto>>(client);
        }
    }
}
