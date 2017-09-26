namespace ObjectOrientedDesignPatterns.Builder
{
    using System;

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
                
            var expected = new Rectangle(height, width);

            // Act
            var actual = new RectangleBuilder().Width(width).Height(height).Build();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RectangleBuilder_WithJustHeight_BuildsRectangle()
        {
            // Arrange
            var d = this.fixture.Create<double>();
            var expected = new Rectangle(d, RectangleBuilder.DefaultWidth);

            // Act & Assert
            var actual = new RectangleBuilder().Height(d).Build();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RectangleBuilder_WithJustWidth_BuildsRectangle()
        {
            // Arrange
            var d = this.fixture.Create<double>();
            var expected = new Rectangle(RectangleBuilder.DefaultHeight, d);

            // Act & Assert
            var actual = new RectangleBuilder().Width(d).Build();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}