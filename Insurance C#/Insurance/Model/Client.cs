using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Model
{
    internal class Client
    {
        public int clientId { get; set; }

        public string clientName { get; set; }

        public string contactInfo { get; set; }

        public int policyId { get; set; }
    }
}
