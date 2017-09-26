namespace ObjectOrientedDesignPatterns.Shared.Shapes
{
    using System;

    public class Rectangle : Shape, IEquatable<Rectangle>
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double Area => this.Height * this.Width;

        public double Height { get; }

        public override double Perimeter => (this.Height * 2) + (this.Width * 2);

        public double Width { get; }

        public bool Equals(Rectangle other)
        {
            var heightTolerance = this.Height / 1000000;
            var widthTolerance = this.Width / 1000000;
            if (other == null)
            {
                return false;
            }

            return Math.Abs(this.Height - other.Height) < heightTolerance && Math.Abs(this.Width - other.Width) < widthTolerance;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Rectangle)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Height.GetHashCode() * 397) ^ this.Width.GetHashCode();
            }
        }
    }
}