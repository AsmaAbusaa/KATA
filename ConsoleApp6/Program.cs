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
            Products.isAddetiveDiscount =false;
            
            Products case1 = new Products("The little Prince","1234",20.25,"GBJ");
            IPaymentsServices case1Pay = new PaymentServices(case1);

            
            
            case1Pay = new Discount((PaymentServices)case1Pay);
            //case1Pay = new Packaging(case1Pay,1,false);
            case1Pay = new Transport(case1Pay,3,false);
          
            Console.WriteLine(case1Pay.getDescription());
           // Console.WriteLine(case1Pay.Cost());
           
            //case1Pay.Precedence(true,false);

            Console.WriteLine();

        }
    }
}
