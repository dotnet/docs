﻿using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    /// <summary>
    /// Provides utilities for geometric calculations.
    /// </summary>
    public static class GeometricUtilities
    {
        #region 04_ClassicSwitch
        /// <summary>
        /// Generates a message based on the number of parts provided.
        /// </summary>
        /// <param name="parts">The parts to include in the message.</param>
        /// <returns>A message based on the number of parts.</returns>
        public static string GenerateMessage(params string[] parts)
        {
            switch (parts.Length)
            {
                case 0:
                    return "No elements to the input";
                case 1:
                    return $"One element: {parts[0]}";
                case 2:
                    return $"Two elements: {parts[0]}, {parts[1]}";
                default:
                    return $"Many elements. Too many to write";
            }
        }
        #endregion

        #region 02_ClassicIsExpression
        /// <summary>
        /// Computes the area of a shape.
        /// </summary>
        /// <param name="shape">The shape to compute the area of.</param>
        /// <returns>The area of the shape.</returns>
        public static double ComputeArea(object shape)
        {
            if (shape is Square)
            {
                var s = shape as Square;
                return s.Side * s.Side;
            } else if (shape is Circle)
            {
                var c = shape as Circle;
                return c.Radius * c.Radius * Math.PI;
            }
            // elided
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }
        #endregion

        #region 03_IsPatternExpression
        /// <summary>
        /// Computes the area of a shape using modern C# `is` pattern matching.
        /// </summary>
        /// <param name="shape">The shape to compute the area of.</param>
        /// <returns>The area of the shape.</returns>
        public static double ComputeAreaModernIs(object shape)
        {
            if (shape is Square s)
                return s.Side * s.Side;
            else if (shape is Circle c)
                return c.Radius * c.Radius * Math.PI;
            else if (shape is Rectangle r)
                return r.Height * r.Length;
            // elided
            throw new ArgumentException(
                message: "shape is not a recognized shape",
                paramName: nameof(shape));
        }
        #endregion

        #region 05_SwitchTypePattern
        /// <summary>
        /// Computes the area of a shape using modern C# `switch` pattern matching.
        /// </summary>
        /// <param name="shape">The shape to compute the area of.</param>
        /// <returns>The area of the shape.</returns>
        public static double ComputeAreaModernSwitch(object shape)
        {
            switch (shape)
            {
                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Rectangle r:
                    return r.Height * r.Length;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
        #endregion


        #region 07_ComputeDegenerateShapes
        /// <summary>
        /// Computes the area of a shape, handling degenerate shapes.
        /// </summary>
        /// <param name="shape">The shape to compute the area of.</param>
        /// <returns>The area of the shape.</returns>
        public static double ComputeArea_Version3(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
        #endregion

        #region 09_AddRectangleAndTriangle
        /// <summary>
        /// Computes the area of a shape, including rectangles and triangles.
        /// </summary>
        /// <param name="shape">The shape to compute the area of.</param>
        /// <returns>The area of the shape.</returns>
        public static double ComputeArea_Version4(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height * 2;
                case Rectangle r:
                    return r.Length * r.Height;
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
        #endregion

        #region 10_NullCase
        /// <summary>
        /// Computes the area of a shape, handling null input.
        /// </summary>
        /// <param name="shape">The shape to compute the area of.</param>
        /// <returns>The area of the shape.</returns>
        public static double ComputeArea_Version5(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s:
                    return s.Side * s.Side;
                case Circle c:
                    return c.Radius * c.Radius * Math.PI;
                case Triangle t:
                    return t.Base * t.Height * 2;
                case Rectangle r:
                    return r.Length * r.Height;
                case null:
                    throw new ArgumentNullException(paramName: nameof(shape), message: "Shape must not be null");
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
        #endregion

    }
}
