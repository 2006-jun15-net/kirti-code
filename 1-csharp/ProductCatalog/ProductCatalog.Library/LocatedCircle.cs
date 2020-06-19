using System.Text;
using System.Collections.Generic;
using System;

//for example of inheritance
namespace ProductCatalog.Library
{
    // inheritance allows one class to automatically have all the methods, fields, properties, etc.
    // of another class. (code reuse)
    // It is also sometimes able to override the methods or properties of the parent class
        // static methods cannot be overriden
        // methods (or properties) have to be marked "virtual", otherwise it's not allowed to override them. 
    

    // base class = parent class
    // derived class = child class
    public class LocatedCircle : Circle
    {

        // get-only auto-properties can still be modified during the constructor but not afterwards
        public int X { get; }
        public int Y { get; }

        // every child class constructor need to call some parent class constructor first.
        // (the default is the zero parameter one. if there isn't a zero parameter constructor, that's an error, there's no default to rely on)
        public LocatedCircle(double diameter, int x, int y) : base(diameter)
        {
            X = x;
            Y = y;
        }

        public double DistanceToLocation(int otherX, int otherY)
        {
            // distance formula
            return Math.Sqrt((otherX) - X) * ((otherX) - X) + ((otherY) - Y) * ((otherY) - Y);
        }

        // C# allows "method hiding
        // in this case, the parent method is still there, and will be run if accessed by variable of the parent type.
        // you have got 2 methods with same name in the same object.
        // method hiding is done with the use of "new" keyword
        public new double GetArea()
        {
            return 0;
        }
    }
}
