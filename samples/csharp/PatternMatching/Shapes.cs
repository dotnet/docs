using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    #region 01_ShapeDefinitions
    /// <summary>
    /// Represents a square.
    /// </summary>
    public class Square
    {
        /// <summary>
        /// Gets the side length of the square.
        /// </summary>
        public double Side { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="side">The side length of the square.</param>
        public Square(double side)
        {
            Side = side;
        }
    }
    /// <summary>
    /// Represents a circle.
    /// </summary>
    public class Circle
    {
        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    /// <summary>
    /// Represents a rectangle.
    /// </summary>
    public struct Rectangle
    {
        /// <summary>
        /// Gets the length of the rectangle.
        /// </summary>
        public double Length { get; }
        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="length">The length of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
    }

    /// <summary>
    /// Represents a triangle.
    /// </summary>
    public struct Triangle
    {
        /// <summary>
        /// Gets the base of the triangle.
        /// </summary>
        public double Base { get; }
        /// <summary>
        /// Gets the height of the triangle.
        /// </summary>
        public double Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> struct.
        /// </summary>
        /// <param name="base">The base of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
    #endregion

}
