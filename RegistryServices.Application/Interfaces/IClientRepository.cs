using RegistryServices.Domain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryServices.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientRepository();
    }
}
