using System;

namespace KATA
{
    class Program
    {
        static void Main(string[] args)
        {

            Products.Tax = 21;
            Products.Discount = 15;
            Products.UPC_Discount = 7;

            Products case1 = new Products("The little Prince","1234",20.25);
            
            IPaymentsServices case1Pay = new PaymentServices(case1);
            
            case1Pay = new Packaging(case1Pay);
            case1Pay = new Transport(case1Pay);

          
            Console.WriteLine(case1Pay.getDescription());

            //case1Pay.Precedence(true,false);



            Console.WriteLine();
            Console.WriteLine();

            Products case2 = new Products("The little Prince", "789", 20.25);
            Products.Tax = 21;
       
            PaymentServices case2Pay = new PaymentServices(case2);

          
            Console.WriteLine();

        }
    }
}
