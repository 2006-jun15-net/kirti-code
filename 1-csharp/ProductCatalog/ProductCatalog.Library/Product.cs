using System;

// architectural principle
// seperation of concern
    // code reusability, flexibility, code reuse
    // maintainability, testability

// for projects, this kind of seperation is common:
    // application projecy just handles user input/output
    // various library projects handle the actual c# logic, seperated from user i/o

namespace ProductCatalog.Library
{
    // C# supports many paradigms of programing
    // above all, it's an object-oriented langauge.

    // package related data and behaviour together as one unit is called an object.
    // the object will have control over those things, the object can reference
    // any restrictions or rules about its own data are behaviours.
    // "encapsulation"

    //project is collection of classes that moves around as a whole block. 

    public class Product
    {
        // an "auto-implemented property" or just  "auto-property"
        // -it is based on a hidden backing field of the type double,
        // but i can modify its implementation later if my needs change.
        public double Price { get; set; } // if it dosent have a get/set after its a field
                                          // typically fields are private and properties are public

        public string Colur { get; set; }

        // backing field for Name property
        private string _name;

        // "full property" -no hidden field, full control validation, etc.
         public virtual string Name 
        {
            get { return _name; }
            set{ _name = value; }
        }

        public void Applydiscount(int percentage)
        {
            double multiplier = 1 - percentage / 100.0;
            Price *= multiplier;
        }
    }
}