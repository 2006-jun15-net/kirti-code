using System;

namespace ProceduralBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            // the main method is ultimately run by the "dotnet run" command.

            // each line of code is a "statement" ending in semicolan.
            //int x = 5; // declares variable named "x" with type "int" (integer, whole number), and 
                       //gives it value 5.

            // Datatypes
            /* Whole numbers: 
                int (4bytes, between -2 billion to 2 billion)
                short (2 bytes), long (8 bytes), byte (1 byte)
            */
            /* Numbers with fractions (floating point numbers): 
                double (8 bytes, very wide in range)
                float (4 bytes, less precise)
            */
            /* True or false: 
                bool 
            */
            //bool mathWorks = (3+3 == 6); //true
            /* Text
                string (more than one character, use double quotes)
                char (just one character, use single quotes)
            */

            /* Collectoins
                arrays: int[], double[], string[], anything you want
            */
            int[] numbers = {4, 5, 6, 7};
            Console.WriteLine("Printing every item in the array");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            Console.WriteLine("Enter a number: ");
            string userInput = Console.ReadLine();
            //int.Parse can convert a string intot the int it represents
            int nmber = int.Parse(userInput);

            int number = int.Parse(userInput);
            number *= 2; // number = numner * 2

            // the valuse of the number will be converted back to string and combined witht he first string
            Console.WriteLine("Doubled: " + number);

            // control structures
            if (number < 0) 
            {
                Console.WriteLine("negative number");
            }
            else 
            {
                //repeatedly decrease the number until it's negative
                for ( ; number >= 0; number -=5)
                {
                    Console.WriteLine(number);
                }

            }

        }
    }
}
