using System;
using System.Collections.Generic;

namespace KATA
{
    public class PaymentServices:IPaymentsServices
    {
        public string Currency;
        public double Price= 0;
        int Tax, Discount, upcDiscount;
        string Name, UPC;
        List<string> specialUPC;

        public bool isAdditaveDiscount; //when flag is true then --> Additavie Discount
        public PaymentServices(Products p)
        {
            this.Currency = p.Currency;
            this.Price = p.Price;
            this.Name = p.Name;
            this.UPC = p.UPC;
            this.Tax = Products.Tax;
            this.Discount = Products.Discount;
            this.specialUPC = Products.specialUPC;
            this.upcDiscount = Products.UPC_Discount;
            this.isAdditaveDiscount = Products.isAddetiveDiscount;

        }
                
        public double getTaxAmount()
        {
            double TaxPercentage =Price * Tax / 100;
            return Math.Round(TaxPercentage, 4);
        }

        public double CreateUniDiscount(double price)
        {
            double amountofDiscount =price * Discount / 100;
            return Math.Round(amountofDiscount, 4);
        }
        public double CreateUPCDiscount(double price)
        {
            double UPCDiscount=0;
            if (specialUPC.Contains(UPC))
                UPCDiscount = price * upcDiscount / 100;

            return Math.Round(UPCDiscount, 4);
        }

        public void Precedence(bool upcFlag,bool uniFlag)
        {
            if (upcFlag && uniFlag)//apply  2 type of discount before tax 
            {
                Price = Price - (CreateUniDiscount(Price) + CreateUPCDiscount(Price));

            }
            else if (upcFlag)//apply upc discount before tax
                Price = Price - CreateUPCDiscount(Price);

            else if (uniFlag)//apply uni discount before tax 
                Price = Price - CreateUniDiscount(Price);
        }

        public string getDescription()
        {
            var str=" ";
            if (Discount != 0)
            {
               str= ($"Tax Amount= ${Math.Round(getTaxAmount(),2)}\nTittle = {Name}, UPC = {UPC}");
            }
            else
            {
               str= ($"Tax Amount = ${Math.Round(getTaxAmount(), 2)}, no Discount\nTittle = {Name}, UPC = {UPC}, Price = ${Math.Round(Price,2)}+{Currency}");
            }
            return str;

        }
        public double Cost()
        {
            return Math.Round(Price+getTaxAmount(),4);
        }

        public (double,string) getCurrency()
        {
            return (Price,Currency);
        }
    }
}
