using System.Collections.Generic;
using ProductCatalog.Library;

namespace ProductCatalog.App
{
    /* ACESSES MODIFIERS
    // no non-nested types (eg. a class out here like this) (eg. class, interface, structs, enums, etc.)
    // only 2 access levels are possible: public, internal (default).
    // public means unrestricted
    // internal means only accessible within the project (aka the assembly)

    // on member (eg. methods, properties, fields, nested classes, etc.) 6 access levels are possible
    // the most common 4 are: public, internal, protected, private
    // public
    // internal
    // protected: onlt accessible to the containing class or any of its child classes (even in a different project)
    // private: only accessible withint he containing type (for implementation details within a class)
    */

    public class BuiltinProductSorter : ISortingAlgorithm<List<Product>>
    {
        public void Sort(List<Product> collection)
        {
            collection.Sort();
        }
    }
}