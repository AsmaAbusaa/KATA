using System;

namespace KATA
{
    class Program
    {
        static void Main(string[] args)
        {

            Products.Tax = 20;
            Products.Discount = 15;
            Products.UPC_Discount = 7;

            Products case1 = new Products("The little Prince","1234",20.25);
            
            PaymentServices case1Pay = new PaymentServices(case1);

            case1Pay.Precedence(true,false);
            Console.Write(case1.Price);

            Console.WriteLine();
            Console.WriteLine();

            Products case2 = new Products("The little Prince", "789", 20.25);
            Products.Tax = 21;
       
            PaymentServices case2Pay = new PaymentServices(case2);

           // case2Pay.Precedence(true, true);
            Console.WriteLine();

        }
    }
}
