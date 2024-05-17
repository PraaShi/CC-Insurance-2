using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Model
{
    internal class Payment
    {
        public int paymentId { get; set; }

        public DateTime paymentDate { get; set; }

        public int PaymentAmount { get; set; }

        public int MyProperty { get; set; }
    }
}
