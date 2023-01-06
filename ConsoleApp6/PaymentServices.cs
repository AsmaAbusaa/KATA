using System;
using System.Collections.Generic;

namespace KATA
{
    public class PaymentServices:IPaymentsServices
    {
        public double Price { get; set; } = 0;
         int Tax, Discount,upcDiscount;
        string Name,UPC;
        List<string> specialUPC;

        public bool flagDiscount; //when flag is true then --> Additavie Discount
        public PaymentServices(Products p)
        { 
            this.Price = p.Price;
            this.Name = p.Name;
            this.UPC = p.UPC;
            this.Tax = Products.Tax;
            this.Discount = Products.Discount;
            this.specialUPC = Products.specialUPC;
            this.upcDiscount = Products.UPC_Discount;
            this.flagDiscount = Products.FlagDiscount;
         
        }
                
        public double AddTax()
        {

            double TaxPercentage =Price * Tax / 100;
            return Math.Round(TaxPercentage, 2);
        }

        public double CreateUniDiscount(double price)
        {
            double amountofDiscount =price * Discount / 100;
            return Math.Round(amountofDiscount, 2);
        }
        public double CreateUPCDiscount(double price)
        {
            double UPCDiscount=0;
            if (specialUPC.Contains(UPC))
                UPCDiscount = price * upcDiscount / 100;

            return Math.Round(UPCDiscount, 2);
        }

        void Report()
        {
            if (Discount != 0)
            {
                Console.WriteLine($"Tax Amount= ${AddTax()}, Discount Amount = ${CreateUniDiscount(Price)+CreateUPCDiscount(Price)}" +
                            $"\nTittle = {Name}, UPC = {UPC}, Price = ${Cost()}");

            }
            else
            {
                Console.WriteLine($"Tax Amount = ${AddTax()}, no Discount\nTittle = {Name}, UPC = {UPC}, Price = ${Cost()}");
            }
        }

        public void Precedence(bool upcFlag,bool uniFlag) {
            if (upcFlag && uniFlag)//apply  2 type of discount before tax 
            {
                Price = Price - (CreateUniDiscount(Price) + CreateUPCDiscount(Price));

            }
            else if (upcFlag)//apply upc discount before tax
                Price = Price - CreateUPCDiscount(Price);

            else if (uniFlag)//apply uni discount before tax 
                Price = Price - CreateUniDiscount(Price);
            Report();

        }

        public string getDescription()
        {
            var str=" ";
            if (Discount != 0)
            {
               str= ($"Tax Amount= ${AddTax()}\nTittle = {Name}, UPC = {UPC}");
            }
            else
            {
               str= ($"Tax Amount = ${AddTax()}, no Discount\nTittle = {Name}, UPC = {UPC}, Price = ${Price}");
            }
            return str;

        }
        public double Cost()
        {
            return Math.Round(Price+AddTax(),2);
        }

       
    }
}
