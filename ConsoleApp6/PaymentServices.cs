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
        
        double AddTax()
        {

            double priceWithTax = Price+(Price * Tax / 100);
            return Math.Round(priceWithTax, 2);
        }

        double CreateUniDiscount()
        {
            double amountofDiscount =Price * Discount / 100;
            return Math.Round(amountofDiscount, 2);
        }
        double CreateUPCDiscount()
        {
            double UPCDiscount=0;
            if (specialUPC.Contains(UPC))
                UPCDiscount = Price * upcDiscount / 100;

            return Math.Round(UPCDiscount, 2);
        }

        public void Report()
        {
            if (Discount != 0)
            {
                Console.WriteLine($"Tax Amount= ${Math.Round(Price * Tax / 100, 2)}, Discount Amount = ${CreateUniDiscount()}" +
                            $"\nTittle = {Name}, UPC = {UPC}, Price = ${AddTax()-CreateUniDiscount()}");

            }
            else
            {
                Console.WriteLine($"Tax Amount = ${Math.Round(Price * Tax / 100,2)}, no Discount\nTittle = {Name}, UPC = {UPC}, Price = ${AddTax()}");
            }
        }



        public void Precedence(bool upcFlag,bool uniFlag) {
            if (upcFlag && uniFlag)//apply  2 type of discount before tax 
            {
                Price = Price - (CreateUniDiscount() + CreateUPCDiscount());

            }
            else if (upcFlag)//apply upc discount before tax
                Price = Price - CreateUPCDiscount();

            else if (uniFlag)//apply uni discount before tax 
                Price = Price - CreateUniDiscount();
            Report();

        }

    }
}
