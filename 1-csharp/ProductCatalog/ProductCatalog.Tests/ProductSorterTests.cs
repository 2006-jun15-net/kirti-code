using System;
using System.Collections.Generic;
using ProductCatalog.Library;
using Xunit;

namespace ProductCatalog.Tests
{
    public class ProductSorterTests
    {
        // C# has syntax for "attributes"
        // any attributes are classes
        // any class derived from System.Attribute can be put in brackers
        // before classes, interfaces, properties, fields, methods, mthod parameters
        // by themselves they don't do anything - but some code looks for those attributes
            // using "reflection" and does something on the basis

        // testing that if we sort an empty list it should still be empty.
        [Fact]
        public void EmptyListShouldSortToEmpty()
        {
            // what this method is responsible for testing:

            // range: any necessary setup before the  "act". everything in this section is assumed to work correctly.
            // (if possible/relevant, it should itself get other unit test.)
            var sorter = new ProductSorter();
            var emptyList = new List<Product>();

            // act: the specific thing (usually 1 method call) that this method is responsible for testing
            sorter.Sort(emptyList);

            // assert: run checks as much as possible to verify the correct behaviour in xUnit, use Assert static class.
            Assert.Empty(emptyList);

            // if an unhandled exception, the test is considered failes.

        }

        [Fact] // mark it as a test (otherwise, it would be a helper method)
        public void SortListWithItemsShouldSortByName()
        {
            //arrange
            var sorter = new ProductSorter();
            var product1 = new Product { Name = "A" };
            var product2 = new Product { Name = "B" };
            var list = new List<Product> { product1, product2 };

            //act
            sorter.Sort(list);

            //assert
            Assert.Equal(2, list.Count); // unchanged length (expected first, actual second)
            Assert.Equal(list[0], product1); // in C#, the indexing operator[] isn't just for arrays
            Assert.Equal(list[1], product2);
        }
    }
}
