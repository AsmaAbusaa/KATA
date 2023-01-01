using System;

namespace KATA
{
    class Transport : IPaymentsServices
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
            return payments.getDescription() + "\nTransport: "+2.2+" "+getCurrency()
                +"\nTotal cost: "+ Cost()+" "+getCurrency();
        }
        public string getCurrency()
        {
            return payments.getCurrency();
        }
    }
}
