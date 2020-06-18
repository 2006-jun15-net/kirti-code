namespace ProductCatalog
{
    public class Circle
    {
        // field
        private double _radius;

        // field
        private string _colour;

        // property
        public double Diameter
        {
            get { return _radius *2; }
            set { _radius = value / 2; }
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

        // constructor
        public Circle(double diameter, string colour)
        {
            this.Diameter = diameter;
            this._colour = colour;
        }
    }
}