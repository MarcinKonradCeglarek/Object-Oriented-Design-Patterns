namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    using ObjectOrientedDesignPatterns.Builder;

    using Xunit;

    public class CircleTests
    {
        [Fact]
        public void Circle_5Radius_ProperlyCalculatesAreaAndPerimeter()
        {
            var sut = new Circle(5);

            // Assert
            Assert.Equal(78.539816339744830961566084581988, sut.Area);
            Assert.Equal(31.415926535897932384626433832795, sut.Perimeter);
        }

        [Fact]
        public void Circle_0Radius_ProperlyCalculatesAreaAndPerimeter()
        {
            var sut = new Circle(0);

            // Assert
            Assert.Equal(0, sut.Area);
            Assert.Equal(0, sut.Perimeter);
        }
    }
}