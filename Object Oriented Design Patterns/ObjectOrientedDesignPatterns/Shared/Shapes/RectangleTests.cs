namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    using ObjectOrientedDesignPatterns.Builder;

    using Xunit;

    public class RectangleTests
    {
        [Fact]
        public void Rectangle_Square_ProperlyCalculatesAreaAndPerimeter()
        {
            // Arrange
            var sut = new Rectangle(5, 5);

            // Assert
            Assert.Equal(20, sut.Perimeter);
            Assert.Equal(25, sut.Area);
        }

        [Fact]
        public void Rectangle_0Size_ProperlyCalculatesAreaAndPerimeter()
        {
            // Arrange
            var sut = new Rectangle(0, 0);

            // Assert
            Assert.Equal(0, sut.Perimeter);
            Assert.Equal(0, sut.Area);
        }
    }
}