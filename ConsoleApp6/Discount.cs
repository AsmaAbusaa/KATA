using System;

namespace KATA
{
    class Discount : IPaymentsServices
    {
        PaymentServices payment;
        bool isAdditaveDiscount;
        double Cap = 0;

        public Discount(PaymentServices payment)
        {
            this.payment = payment;
            this.isAdditaveDiscount = payment.isAdditaveDiscount;
        }
        public Discount(PaymentServices payment,double Cap,bool isAbsolute)
        {
            this.payment = payment;
            this.isAdditaveDiscount = payment.isAdditaveDiscount;
            this.Cap = Cap;
            if (isAbsolute)
                this.Cap = Cap;
            else this.Cap = payment.Price * Cap / 100;

        }
        
        public double Cost()
        { 
            if(isAdditaveDiscount)
            return Math.Round(payment.Cost()- CheckCap(getAdditiveDiscounts()),4);
            return Math.Round(payment.Cost() - CheckCap(getMultiplicativeDiscount()),4);
        }
        public double CheckCap(double discount)
        {
              if (Cap!=0 && discount >= Cap)
                return Cap;
            
            return discount;
        }
        
        public string getDescription()
        {
            if(isAdditaveDiscount)
            return payment.getDescription() + "\nDiscount Amount: "+ Math.Round(CheckCap(getAdditiveDiscounts()),2) +" "+payment.Currency;
            return payment.getDescription() + "\nDiscount Amount: " + Math.Round(CheckCap(getMultiplicativeDiscount()),2) +" "+ payment.Currency;
        }
        double getAdditiveDiscounts()
        {
            double addit = payment.CreateUniDiscount(payment.Price) + payment.CreateUPCDiscount(payment.Price);
            return Math.Round(addit,4);
        }
        double getMultiplicativeDiscount()
        {
            double tempPrice = payment.Price - payment.CreateUniDiscount(payment.Price);
            double multPrice = payment.CreateUPCDiscount(tempPrice) + payment.CreateUniDiscount(payment.Price);

            return Math.Round(multPrice,4);
        }
    
        public (double,string) getCurrency()
        {
            return payment.getCurrency();
        }
    }
}
