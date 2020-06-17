using System;
using System.Linq;

namespace Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            Console.WriteLine("Enter the size of staircase: ");
            string input = Console.ReadLine();
            n = int.Parse(input);
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine(string.Concat(Enumerable.Repeat(" ",n-i)) + string.Concat(Enumerable.Repeat("#",i)));
                string space = new string(' ', n-i);
                string step = new string('#', i+1);
                Console.WriteLine(space + step);
            }
        }
    }
}
