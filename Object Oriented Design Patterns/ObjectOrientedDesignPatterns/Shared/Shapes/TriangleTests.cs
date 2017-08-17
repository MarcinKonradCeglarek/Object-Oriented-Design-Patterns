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
            var sut = new Triangle(5, 5, 5);

            // Assert
            Assert.Equal(15, sut.Perimeter);
            Assert.Equal(13.97542485937368560255733542957, sut.Area);
        }

        [Fact]
        public void Triangle_A0B0C0_ReturnsValidAreaAndPerimeter()
        {
            // Arrange
            var sut = new Triangle(0, 0, 0);

            // Assert
            Assert.Equal(0, sut.Perimeter);
            Assert.Equal(0, sut.Area);
        }

        [Fact]
        public void Triangle_A1B1C9_ReturnsValidAreaAndPerimeter()
        {
            // Arrange
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 9));
        }
    }
}