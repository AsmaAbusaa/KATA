using System;

namespace KATA
{
    class Transport : IPaymentsServices
    {
        IPaymentsServices payments;
        public double TransportAmount;

        public Transport(IPaymentsServices payments,double transportAmount,bool isAbsolute)
        {
            this.payments = payments;
            if (isAbsolute)
                this.TransportAmount = transportAmount;
            else this.TransportAmount = transportAmount*getCurrency().Item1 / 100;
        }
        public double Cost()
        {
            double transport =Math.Round(TransportAmount + payments.Cost(),4);
            return transport;
        }
        public string getDescription()
        {
            return payments.getDescription() + "\nTransport: "+Math.Round(TransportAmount,2) +" "+getCurrency().Item2
                +"\nTotal cost: "+ Math.Round(Cost(),2)+" "+getCurrency().Item2;
        }
        public (double,string) getCurrency()
        {
            return payments.getCurrency();
        }
    }
}
