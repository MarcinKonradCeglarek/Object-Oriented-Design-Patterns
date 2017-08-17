namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; }

        public double Width { get; }

        public override double Area => this.Height * this.Width;

        public override double Perimeter => (this.Height * 2) + (this.Width * 2);
    }
}