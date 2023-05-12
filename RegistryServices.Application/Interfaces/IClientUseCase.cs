using RegistryServices.Application.Dto;
using RegistryServices.Domain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryServices.Application.Interfaces
{
    public interface IClientUseCase
    {
        Task<List<ClientDto>> GetClients();
    }
}
