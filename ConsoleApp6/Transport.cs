using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA
{
    class Transport : IDecorater
    {
        IPaymentsServices payments;
        public Transport(IPaymentsServices payments)
        {
            this.payments = payments;
        }
        public double Cost()
        {
            double transport =Math.Round( 2.2 + payments.Cost(),2);
            return transport;
        }

        public string getDescription()
        {
            return payments.getDescription() + "\nTotal: " + Cost();
        }
    }
}
