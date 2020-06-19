using System;

namespace ProductCatalog.Library
{
    // a class without an explicitly coded constructor
    //will have a hidden default constructor with following characteristics:
        // public
        // take zero parameters
        // does nothing
        // in other words, it is the same as: "public circle(){}"

    // every class (without an explicit base class) has "object" for its base class.
    public class Circle //: IShape
    {
        // field
        private double _radius = 0;

        // field
        private string _colour;

        // property
        public double Diameter
        {
            get { return _radius *2; }
            set { _radius = value / 2; }
        }

        // property
        public double Circumference
        {
            get { return 2 * Math.PI * this._radius; }
        }

        // method
        // "virtual" means = allowing derived classes to override.
        public virtual double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        // property
        // public bool IsSymmetric { get {return true; } }
        public bool IsSymmetric = true; // equielevent to above

        // as part of this constructor, call the other one with these two parameters.
        // effectively, you can either set the color yourself, or let it be default black.
        // constructor
        public Circle(double diameter) : this(diameter, "black")
        {
        }

        //public Circle() : this(1)
        //{ }

        // constructor
        public Circle(double diameter, string colour)
        {
            this.Diameter = diameter;
            this._colour = colour;
        }

        public override string ToString()
        {
            return $"{_colour} circle with diameter {Diameter}";
        }
    }
}