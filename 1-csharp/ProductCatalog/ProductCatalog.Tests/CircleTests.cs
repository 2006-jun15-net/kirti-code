using System;
using Xunit;
using ProductCatalog.Library;

namespace ProductCatalog.Tests
{
    public class CircleTests
    {
        [Theory] // "Fact" means a zero-parameter test, "Theory" means a test with params that have several possible values
        // "Theory" - must have inline data
        [InlineData(3, 9.4248)]
        [InlineData(100, 314.15926535)]
        [InlineData(0, 0)]
        public void CircumferenceShouldBeDifferent(double diameter, double circumference)
        {
            //arrange
            var circle = new Circle(diameter);

            //act
            double actualCircimference = circle.Circumference;

            //assert
            Assert.Equal(circumference, actualCircimference, precision: 4); // within 4 decimal places
        }
    }
}
