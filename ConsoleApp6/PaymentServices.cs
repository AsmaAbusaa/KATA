using System;
namespace KATA
{
    public class PaymentServices
    {
        double Price;
        int Tax, Discount;
        string Name,UPC;

        
        public PaymentServices(Products p)
        { 
            this.Price = p.Price;
            this.Name = p.Name;
            this.UPC = p.UPC;
            this.Tax = Products.Tax;
            this.Discount = Products.Discount;
         
        }
        public double addTax()
        {

            double priceWithTax = Price + (Price * Tax / 100);
            return Math.Round(priceWithTax, 2);
        }

        public double createDiscount()
        {
            double pricewithDiscount = addTax() - (Price * Discount / 100);
            return Math.Round(pricewithDiscount, 2);
        }

        public void Report()
        {
            if (Discount != 0)
            {
                Console.Write($"Tax Amount= ${Price * Tax / 100}, Discount Amount = ${Price * Discount / 100}" +
                            $"\nTittle = {Name}, UPC = {UPC}, Price = ${createDiscount()}");

            }
            else
            {
                Console.Write($"Tax Amount = ${Price * Tax / 100}, no Discount\nTittle = {Name}, UPC = {UPC}, Price = ${addTax()}");
            }
        }


    }
}
