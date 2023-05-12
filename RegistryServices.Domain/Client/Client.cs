using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryServices.Domain.Client
{
    public class Client
    {
        public string? ContactClient { get; set; }
        public string? Ruc { get; set; }
        public string? BusinessName { get; set; }
        public string? PhoneNumber { get; set; }
        public int CampusCode { get; set; }
    }
}
