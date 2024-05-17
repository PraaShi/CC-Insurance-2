using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Model
{
    internal class Claim
    {
        public int claimId { get; set; }

        public long claimNumber { get; set; }

        public decimal claimAmount { get; set; }

        public DateTime dateFiled { get; set; }

        public string status { get; set; }

        public int  policyId { get; set; }

        public int clientId { get; set; }

    }
}
