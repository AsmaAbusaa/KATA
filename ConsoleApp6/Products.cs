﻿using System;
using System.Collections.Generic;

namespace KATA
{
    public class Products
    {
        public string Name { get; set; }
        public string UPC { get; set; }
        public double Price { get; set; }

        public static int Tax { get; set; }
        public static int Discount { get; set; }
        public static int UPC_Discount { get; set; }
        public static List<string> specialUPC = new List<string>() { "1234", "4321" };

        public Products(string name,string upc,double price)
        {
            this.Name = name;
            this.UPC = upc;
            this.Price = Math.Round(price,2);

        }

        public void AddSpecialUPC(string sUPC)
        {
            specialUPC.Add(sUPC);

        }
       
    }
}