using System;

namespace CollatzSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            Console.WriteLine("Enter a number for collatz sequence: ");
            string input = Console.ReadLine();
            n = int.Parse(input);
                       
            while (true)
            {
                if (n == 1)
                    break;
                if (n%2 == 0)
                {
                    n = n/2;
                    Console.WriteLine(n);
                }
                else 
                {
                    n = (n*3)+1;
                    Console.WriteLine(n);
                }
                
            }
        }
    }
}
