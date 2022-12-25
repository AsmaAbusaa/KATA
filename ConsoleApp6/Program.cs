using System;

namespace KATA
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Products book = new Products("The little Prince","1234",20.25);
            Products.Tax = 20;
            Products.Discount = 15; 
            PaymentServices bookPay = new PaymentServices(book);
            

            bookPay.addTax();
            bookPay.createDiscount();
            bookPay.Report();
            Console.WriteLine();

        }
    }
}
