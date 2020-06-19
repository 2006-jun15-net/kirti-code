using System.Collections.Generic;

namespace ProductCatalog.Library
{
    // the point of creating an interface like this is....
        /*
            lets say I have some need in my project to sort data, 
            but I have several ways to do it, might need to switch between them. 
        */
        /*
            Interfaces let us decouple code that needs functionality
            fromtcode that provides functionality.
        */
        /*
            eg. methods in the program class might accept a ISortingAlgorithm parameter.
            I could pass into those methods an instance of any class that implements that interface.
        */
        public interface ISortingAlgorithm<TCollection>
        {
            void Sort(TCollection collection);
        }

}