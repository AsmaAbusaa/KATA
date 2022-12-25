using System;
namespace KATA
{
   public class Products 
    {
        public string Name { get; set; }
        public string UPC { get; set; }
        public double Price { get; set; }

        public static int Tax { get; set; }
        public static int Discount { get; set; }

        public Products(string name,string upc,double price)
        {
            this.Name = name;
            this.UPC = upc;
            this.Price = Math.Round(price,2);

        }

       
    }
}