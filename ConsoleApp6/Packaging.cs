using System;

namespace KATA
{
    class Packaging : IPaymentsServices
    {
        IPaymentsServices payments;
        double PackagingAmount = 0;
        public Packaging(IPaymentsServices payments,double packaging,bool isAbsolute)
        {
            this.payments = payments;
            if (isAbsolute)
                this.PackagingAmount = packaging;
            else this.PackagingAmount = packaging*getCurrency().Item1 / 100;
           
        }
        public string getDescription()
        {
            return payments.getDescription() + "\nPackaging: " + Math.Round(PackagingAmount, 2)+" "+getCurrency().Item2;
        }
        public double Cost()
        {
            double costWithPackage = PackagingAmount + payments.Cost();
            return costWithPackage;
        }
        public (double,string) getCurrency()
        {
            return payments.getCurrency();
        }
    }
}
