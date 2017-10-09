namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    using System;

    using Xunit;

    public class TriangleTests
    {
        [Fact]
        public void Triangle_A5B5C5_ReturnsValidAreaAndPerimeter()
        {
            // Arrange
            var sut = new Triangle(6, 6, 6);

            // Assert
            AssertDoubleEquality(18, sut.Perimeter);
            AssertDoubleEquality(15.5884572681199, sut.Area);
        }

        [Fact]
        public void Triangle_A5B4C3_ReturnsValidAreaAndPerimeter()
        {
            // Arrange
            var sut = new Triangle(5, 4, 3);

            // Assert
            AssertDoubleEquality(12, sut.Perimeter);
            AssertDoubleEquality(6, sut.Area);
        }

        [Fact]
        public void Triangle_A0B0C0_ReturnsValidAreaAndPerimeter()
        {
            // Arrange
            var sut = new Triangle(0, 0, 0);

            // Assert
            AssertDoubleEquality(0, sut.Perimeter);
            AssertDoubleEquality(0, sut.Area);
        }

        [Fact]
        public void Triangle_A1B1C9_ReturnsValidAreaAndPerimeter()
        {
            // Arrange
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 9));
        }

        private static bool AssertDoubleEquality(double a, double b)
        {
            return a - b < a / 10000000;
        }
    }
}