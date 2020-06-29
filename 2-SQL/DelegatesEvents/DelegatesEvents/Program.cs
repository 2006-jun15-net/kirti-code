using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesEvents
{

    // declration of delegate
    // this declares anew type (just like the class Program { } bit does)
    // which can be a type of a veriable
    public delegate void StringAction(string text);

    class Program
    {

        // events are another kind of "member" like properties, fields, and members.
        // an event supports three operations:
        // sunscribe +=
        // unsubscribe -=
        // call/publish ()

        // implement Logging like an event:
        public static event Action<string> Log;
        //public static List<Action<string>> Log;
        // it looks like a field basically, but every event needs a void-return delegate type to define what
            // parameters can and will be sent along witht he event

        // in this example, it lets us have some seperation of concerns so that
            //the main method can decide how ot log (by subscribing)
            // and other code can decide WHAT to log and WHEN (by calling)


        static void Main(string[] args)
        {
            // C# is object oriented langauge

            // one thing it takes from fuctional programming
            // is an ability to treat function/methods as
            // just another piece of data line int, Product, etc.

            // in C# when we're treating method as data, we call them "delegates"
            // and we have "delegate types" that represent groups of thode delegate values.
            // any delegate can fit in a delegate type based on having the same return type and method parameter types.

            //since i subscribed twice, bot the event handlers will run
            Log += s => Console.WriteLine();
            Log += Console.WriteLine;

            Console.WriteLine("Hello World!");

            //Action<string> theMethodItself = Console.WriteLine;
            StringAction theMethodItself = Console.WriteLine; //same as the above line except now it uses delegate

            theMethodItself("text to print");

            theMethodItself = PrintInUppercase;

            theMethodItself("text to print");

            PrintAllStrings(false, "adsf", "asdf", "");

            var strings = new List<string> { "abc", "b", "c3" };

            // C# provides a way to write a quick disposable methods called lambda expression
            //ProcessStrings(strings, Console.WriteLine);
            ProcessStrings(strings, x => x.ToLower(), Console.WriteLine);

            // the most useful builtin delegate types are Func and Action

            // Func<int, int, sting>    : method that takes two ints and returns a string
            // Action<int, int, sting>  : method that takes two ints and a string and returns nothing (void)

            // to overload the Sort method take a Comparison<string>
            // which is a delegate type meaning, takes 2 strings, return an int to indicate the sort order you want.
            strings.Sort((s1, s2) => s2.Length - s1.Length);

            // C# lets you write "extension methods"
            // these are just static methods, but they appear to be added on to an existing type.
            // the following is how you call extension methods
            // "sdf".PrintInLowercase();
            // that methods will only be visible in file that has the right namespace.
            // extention methods are just "syntact sugar" for static methods
            100.ToString();
            //Multiply(2, 3) == 8; // regular static methods
            //4.Multiply(2) == 8; //extension methods

            //C# has a great collection of sequence-processing methods called LINQ
            // "langauge-integrated query"
            // it is just a full of extension methods for the IEnumerable called LINQ
            // (the one that all collection implements)
            LinqDemo();
        }

        static void PrintInUppercase(string text)
        {
            Console.WriteLine(text.ToUpper());
        }

        //need to be in static class
        //static void PrintInLowercase(this string text)
        //{
        //    Console.WriteLine(text.ToLower());
        //}

        static void PrintAllStrings(bool uppercase, params string[] strings)
        {
            foreach (var item in strings)
            {
                if (uppercase)
                    PrintInUppercase(item);
                else
                    Console.WriteLine(item);
            }
        }

        static void ProcessStrings(IEnumerable<string> collection, Func<string, string> modify, Action<string> action)
        {
            foreach (string str in collection)
            {
                string newString = modify(str);

                //bit unsafe way to call an event..
                // if there are no subscribers, then you get a null reference exception from firing
                Log("modified string is: " + newString);

                // ?. and ?? are two useful operators in C#

                action(newString);
            }
        }

        static void LinqDemo()
        {
            var strings = new List<string> { "abs", "b", "c3" };

            // get the first element matching some condition
            strings.First(x => x.Length < 2); // first element shorter that 2 characters - returns "b"

            // LINQ methods fit into one of a few categories
            // 1. the once that return some concrete value - eg. First,Average,Min,Max,Count,Sum
                // these once run "right away"
            // 2. the once that return a sequence (IEnumerable) - eg. Select,Where,OrderBy,Distinct
            // these once dont run right "yet" = the collection will only really be processed if you loop over it later.
                // this is called "deferred execution"
            // 3. stuff that returns a concrete collection - eg. ToList()
                // these ones run "right away" as well -- by calling ToList at the right times,
                // you can take control over that "deferred execution" behavior.

            // none of them ever modify the original list.


            IEnumerable<string> results = strings.Where(x => x[0] == 'a'); // all elements having first charactera

            IEnumerable<char> results2 = strings
                .Where(s => s.Length > 0)
                .Select(s => s[0]) //Select converts each element into something new
                .OrderByDescending(c => c); // use the default sorting of chars, but in reverse
                // the first characters of the strings, in reverse alphabetical order: c, b, a

            foreach (var item in results2)
            {
                Console.WriteLine(item);
            }

            // LINQ has two syntaxes - all that is the "method syntax"

            // there's also the "query syntax"
            var results3 = from s in strings
                           where s.Length > 0
                           select s[0]; // some methods dont have an equivalent in query syntax

            // in different contexts, sometimes the sequence processing stuff is converted into something besides
            // regular C#. for example there is "LINQ to SQL". (there's two copies of each LINQ method, one for
            // IEnumerable, one for IQueryable. the weird stuff like that is on IQueryable.)
        }
    }
}
