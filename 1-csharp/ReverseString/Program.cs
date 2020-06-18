// in C#, a project is for "physical" organization of class/stuff
    // a project is compiled as one unit and deployed or run as one unit
    // one project is compiled into exactly one assembly
// in C#, a namespace is for "logical" organization of classes/stuff
    // a project could have many name spaces
    // but also, many projects could contribute to classes to one
// usually, folder structure in a project matches namespace structure

using System;

namespace ReverseString
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter a string that you would like to reverse: ");
            
            string input = Console.ReadLine();
            
            // put the string into a char array
            char[] arr = input.ToCharArray();
            
            // reverse char[]
            Array.Reverse(arr);
            
            // convert char[] to string
            string reversed = new string (arr);
            
            Console.WriteLine("Reversed string is: \n" + reversed);
        }
    }
}