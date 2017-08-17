namespace ObjectOrientedDesignPatterns.Builder
{
    using ObjectOrientedDesignPatterns.Shared.Shapes;

    using Ploeh.AutoFixture;

    using Xunit;

    public class RectangleBuilderTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void RectangleBuilder_NoParameters_BuildsRectangle()
        {
            // Arrange
            var sut = new RectangleBuilder();

            // Act
            var result = sut.Build();

            // Assert
            Assert.IsType<Rectangle>(result);
        }

        [Fact]
        public void RectangleBuilder_WidthAndHeight_BuildsRectangle()
        {
            // Arrange
            var width = this.fixture.Create<double>();
            var height = this.fixture.Create<double>();
                
            var expected = new Rectangle(width, height);

            // Act
            var actual = new RectangleBuilder().Width(width).Height(height).Build();

            // Assert
            Assert.Equal(expected.Area, actual.Area);
            Assert.Equal(expected.Perimeter, actual.Perimeter);

            Assert.Equal(width, actual.Width);
            Assert.Equal(height, actual.Height);
        }
    }
}