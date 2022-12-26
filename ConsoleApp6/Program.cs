using System;

namespace KATA
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Products case1 = new Products("The little Prince","1234",20.25);
            Products.Tax = 20;
            Products.Discount = 15;
            Products.UPC_Discount = 7;
            PaymentServices case1Pay = new PaymentServices(case1);

            case1Pay.DoServices();

            Console.WriteLine();
            Console.WriteLine();

            Products case2 = new Products("The little Prince", "789", 20.25);
            Products.Tax = 21;
       
            PaymentServices case2Pay = new PaymentServices(case2);

            case2Pay.DoServices();
            Console.WriteLine();

        }
    }
}
