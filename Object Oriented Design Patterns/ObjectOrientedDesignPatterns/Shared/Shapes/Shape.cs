namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    public abstract class Shape
    {
        public Point Position { get; set; }

        public string BorderColor { get; set; }

        public string BorderStyle { get; set; }

        public bool Filled { get; set; }

        public string FillColor { get; set; }

        public abstract double Area { get; }

        public abstract double Perimeter { get; }
    }
}