namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    using System;

    public class Circle : Shape
    {
        public Circle(double radious)
        {
            this.Radius = radious;
        }
        public double Radius { get; }

        public override double Area => Math.PI * this.Radius * this.Radius;

        public override double Perimeter => 2 * Math.PI * this.Radius;
    }
}