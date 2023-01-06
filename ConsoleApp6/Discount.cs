using System;

namespace KATA
{
    class Discount : IPaymentsServices
    {
        PaymentServices payment;
        bool isAdditaveDiscount;
        static double AbsoluteCap { get; set; } = 0;
        static double ParcentCap { get; set; } = 0;
        public Discount(PaymentServices payment)
        {
            this.payment = payment;
            this.isAdditaveDiscount = payment.isAdditaveDiscount;
        }

        public double Cost()
        { 
            if(isAdditaveDiscount)
            return Math.Round(payment.Cost()- CheckCap(getAdditiveDiscounts()),2);
            return Math.Round(payment.Cost() - CheckCap(getMultiplicativeDiscount()),2);
        }
        public static void PutCap(double cap,bool isAbsoluteCap)
        {
            if (isAbsoluteCap)
                AbsoluteCap = cap;
            else ParcentCap = cap;

        }
        double CheckCap(double discount)
        {
            double parcentCap = payment.Price * ParcentCap / 100;

            if (AbsoluteCap != 0 && discount>=AbsoluteCap)
                return AbsoluteCap;
            else if (ParcentCap != 0 && discount >= parcentCap)
                return parcentCap ;
            return discount;
        }

        public string getDescription()
        {
            if(isAdditaveDiscount)
            return payment.getDescription() + "\nDiscount Amount: "+ CheckCap(getAdditiveDiscounts());
            return payment.getDescription() + "\nDiscount Amount: " + CheckCap(getMultiplicativeDiscount());
        }
        double getAdditiveDiscounts()
        {
            double addit = payment.CreateUniDiscount(payment.Price) + payment.CreateUPCDiscount(payment.Price);
            return Math.Round(addit,2);
        }
        double getMultiplicativeDiscount()
        {
            double tempPrice = payment.Price - payment.CreateUniDiscount(payment.Price);
            double multPrice = payment.CreateUPCDiscount(tempPrice) + payment.CreateUniDiscount(payment.Price);

            return Math.Round(multPrice,2);
        }
    }
}
