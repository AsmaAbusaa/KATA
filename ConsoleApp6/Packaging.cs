using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATA
{
    class Packaging : IDecorater
    {
        IPaymentsServices payments;
        public Packaging(IPaymentsServices payments)
        {
            this.payments = payments;
        }
        public double Cost()
        {/* i can't access price from low level PaymentServices,
         * so when we decorate we have to packege firstly 
         * because cost of packaging is percentage 
         */
            double package = Math.Round(.01 * payments.Cost(), 2) + payments.Cost();
           return package ;
           
        }

        public string getDescription()
        {
            return payments.getDescription()+"\nTotal with Packaging: "+Cost();
        }
    }
}
