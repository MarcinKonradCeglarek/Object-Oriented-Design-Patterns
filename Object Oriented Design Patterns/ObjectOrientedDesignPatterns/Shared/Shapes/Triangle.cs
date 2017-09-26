namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Triangle : Shape
    {
        public Triangle(double a, double b, double c)
        {
            var sides = new List<double>() { a, b, c };
            sides.Sort();

            if (sides[2] > sides[0] + sides[1])
            {
                throw new ArgumentException($"You can't construct a valid triangle with sides: {a}, {b} and {c}");
            }

            this.A = a;
            this.B = b;
            this.C = c;
        }

        public double A { get; }

        public double B { get; }

        public double C { get; }

        public override double Area => Math.Sqrt(this.Semiperimeter * (this.Semiperimeter - this.A) * (this.Semiperimeter - this.B) * (this.Semiperimeter - this.C));

        private double Semiperimeter => this.Perimeter / 2;

        public override double Perimeter => this.A + this.B + this.C;
    }
}