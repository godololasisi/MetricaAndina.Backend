using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using RegistryServices.Application.Interfaces;
using RegistryServices.Domain.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using RegistryServices.Application.Constants;

namespace RegistryServices.Infastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(IConfiguration _config)
        {
            _connectionString = _config.GetConnectionString("OracleDBConnection")!;
        }
        public async Task<List<Client>> GetClientRepository()
        {
            var clients = new List<Client>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                con.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = GetClientProcedure.GetClientList;

                    DbDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var client = new Client();
                        client.Ruc = await reader.IsDBNullAsync(0) ? null : Convert.ToString(reader.GetString(0));
                        client.BusinessName = await reader.IsDBNullAsync(0) ? null : Convert.ToString(reader.GetString(1));
                        client.CampusCode = await reader.IsDBNullAsync(0) ? 0 : Convert.ToInt32(reader.GetString(2));
                        clients.Add(client);
                    }

                }
            }
            return clients;
        }
    }
}
