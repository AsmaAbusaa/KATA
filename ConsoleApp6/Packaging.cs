using System;

namespace KATA
{
    class Packaging : IPaymentsServices
    {
        IPaymentsServices payments;
        double price=0;
        public Packaging(IPaymentsServices payments,double price)
        {
            this.payments = payments;
            this.price = price;
        }

        public string getDescription()
        {
            return payments.getDescription() + "\nPackaging: " + Math.Round(.01 * payments.Cost(), 2)+" "+getCurrency();
        }

        public double Cost()
        {
            double costWithPackage = Math.Round(.01*price  , 2) + payments.Cost();
            return costWithPackage;
        }

        public string getCurrency()
        {
            return payments.getCurrency();
        }
    }
}
