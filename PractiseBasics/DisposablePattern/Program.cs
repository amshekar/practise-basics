using System;

namespace DisposablePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Calculate Price!");
            using (Calculator calObj=new Calculator())
            {
                Console.WriteLine("Please enter price for product");
                decimal price =Convert.ToDecimal(Console.ReadLine());
                int taxPercentage = 18;
                var bill=calObj.ToatalPrice(price,taxPercentage);
                Console.Write(bill);
                Console.ReadLine();

            }
        }
    }
}
