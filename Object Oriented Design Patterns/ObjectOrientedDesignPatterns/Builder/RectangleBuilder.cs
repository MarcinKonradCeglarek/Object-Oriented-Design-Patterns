namespace ObjectOrientedDesignPatterns.Builder
{
    using ObjectOrientedDesignPatterns.Shared.Shapes;

    public class RectangleBuilder
    {
        private double height = 5;

        private double width = 5;

        private string borderColor = "White";

        private string borderStyle = "Dashed";

        private bool fill = false;

        private string fillColor = null;

        public RectangleBuilder Height(double value)
        {
            this.height = value;
            return this;
        }

        public RectangleBuilder Width(double value)
        {
            this.width = value;
            return this;
        }

        public RectangleBuilder BorderColor(string color)
        {
            this.borderColor = color;
            return this;
        }

        public RectangleBuilder BorderStyle(string style)
        {
            this.borderStyle = style;
            return this;
        }

        public RectangleBuilder FillColor(string color)
        {
            this.fillColor = color;
            this.fill = true;
            return this;
        }

        public Rectangle Build()
        {
            var rectangle =
                new Rectangle(this.height, this.width)
                    {
                        BorderColor = this.borderColor,
                        FillColor = this.fillColor,
                        Filled = this.fill,
                        BorderStyle = this.borderStyle
                    };


            return rectangle;

        }
    }
}