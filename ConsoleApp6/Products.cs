using System;
using System.Collections.Generic;

namespace KATA
{
    public class Products
    {
        public string Name { get; set; } = " ";
        public string UPC { get; set; } = " ";
        public double Price { get; set; } = 0;
        public string Currency { get; set; } = "USD";
        public static int Tax { get; set; } = 0;
        public static int Discount { get; set; } = 0;
        public static int UPC_Discount { get; set; } = 0;
        public static List<string> specialUPC = new List<string>() { "1234", "4321" };
        public static bool FlagDiscount=true;// Addetive or Multiplication Discount, defualt is addetive discount
        public Products() { }
        public Products(string name,string upc,double price,string currency)
        {
            this.Name = name;
            this.UPC = upc;
            this.Price = Math.Round(price,2);
            this.Currency = currency;

        }

        public void AddSpecialUPC(string sUPC)
        {
            specialUPC.Add(sUPC);

        }

       
    }
}