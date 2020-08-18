using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flex00
{
    public class SoldSub
    {
        public int SubscriptionNumber { get; set; }
        public string SubscriptionType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Visit { get; set; } = "";
        public string PaymentDate { get; set; }
        public bool WithTrainer { get; set; } = false;
        public string Discount { get; set; }
        public bool TypePayment { get; set; } = true;
        public string Amount { get; set; }
        public string Additional { get; set; }
    }
}
