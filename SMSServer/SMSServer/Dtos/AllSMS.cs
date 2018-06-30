using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSServer.Dtos
{
    public class AllSMS
    {
        public string Message { get; set; }
        public string Sender { get; set; }
        public string SendTime { get; set; }
    }
}
