namespace ProductCatalog.Library
{
    // just as class specifies requirements for the objects that are instances of that class,
    // an interdace specifies requirements on class that mark themselves as implementation of that interface
    
    // interfaces let us decouple code that needs functionality fromt he code that provides functionality.

    // e.g. methods int he program class might accept a ISortingAlgorithm parameter. 
    // I could pass into those methods an instance of any class that implements that interface.
    public interface IShape
    {
        // there must be such a method that any class that claims to implement that IShape interface
        void Scale(double sizeMultiplier);
    }
}