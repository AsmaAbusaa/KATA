using System;
using System.Collections.Generic;

namespace KATA
{
    public class PaymentServices
    {
        double Price;
        int Tax, Discount,upcDiscount;
        string Name,UPC;
        List<string> specialUPC;
       
        
        public PaymentServices(Products p)
        { 
            this.Price = p.Price;
            this.Name = p.Name;
            this.UPC = p.UPC;
            this.Tax = Products.Tax;
            this.Discount = Products.Discount;
            this.specialUPC = Products.specialUPC;
            this.upcDiscount = Products.UPC_Discount;
         
        }
        double addTax()
        {

            double priceWithTax = Price+(Price * Tax / 100);
            return Math.Round(priceWithTax, 2);
        }

        double createUniDiscount()
        {
            double amountofDiscount =Price * Discount / 100;
            //check if it is a speical upc
            if (specialUPC.Contains(UPC))
            {
                amountofDiscount = amountofDiscount +createUPCDiscount();
                return Math.Round(amountofDiscount, 2);
            }
            else return Math.Round(amountofDiscount, 2);
        }
        double createUPCDiscount()
        {
            double UPCDiscount =Price * upcDiscount / 100;
            return UPCDiscount;
        }

        void Report()
        {
            if (Discount != 0)
            {
                Console.Write($"Tax Amount= ${Math.Round(Price * Tax / 100, 2)}, Discount Amount = ${createUniDiscount()}" +
                            $"\nTittle = {Name}, UPC = {UPC}, Price = ${addTax()-createUniDiscount()}");

            }
            else
            {
                Console.Write($"Tax Amount = ${Math.Round(Price * Tax / 100,2)}, no Discount\nTittle = {Name}, UPC = {UPC}, Price = ${addTax()}");
            }
        }

        public void doServices() {
            addTax();
            createUniDiscount();
            Report();
        }


    }
}
