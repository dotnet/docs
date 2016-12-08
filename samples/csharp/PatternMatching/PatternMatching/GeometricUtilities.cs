using System;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    public static class GeometricUtilities
    {
        #region 02_ComputeSquareArea
        private static double ComputeAreaOfSquare(Square sq) =>
            sq.Side * sq.Side;
        #endregion

        #region 04_ComputeCircleArea
        private static double ComputeAreaOfCircle(Circle c) =>
            c.Radius * c.Radius * PI;
        #endregion

        #region 05_ComputeWithAsExpression
        public static double ComputeArea(object shape)
        {
            if ((shape is Square s1) && (s1.Side == 0))
                return 0;
            if (shape is Square s)
                return ComputeAreaOfSquare(s);
            else if (shape is Circle c)
                return ComputeAreaOfCircle(c);
//            Console.WriteLine(c);
  //          Console.WriteLine(s);

            throw new ArgumentException(
                message: "shape is not a recognized shape", 
                paramName: nameof(shape));
        }
        #endregion

        #region 06_ComputeWithSwitchExpression
        public static double ComputeArea_Version2(object shape)
        {
            switch (shape)
            {
                case Square s:
                    return ComputeAreaOfSquare(s);
                case Circle c:
                    return ComputeAreaOfCircle(c);
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
        #endregion

        #region 07_ComputeDegenerateShapes
        public static double ComputeArea_Version3(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                    return 0;

                case Square s when s.Side < 5:
                    return ComputeAreaOfSquare(s);
                case Circle c:
                    return ComputeAreaOfCircle(c);
                default:
                    throw new ArgumentException(
                        message: "shape is not a recognized shape",
                        paramName: nameof(shape));
            }
        }
        #endregion

        #region 09_AddRectangleAndTriangle
        public static double ComputeArea_Version4(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s when s.Side < 5:
                    return ComputeAreaOfSquare(s);
                case Circle c:
                    return ComputeAreaOfCircle(c);
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
        public static double ComputeArea_Version5(object shape)
        {
            switch (shape)
            {
                case Square s when s.Side == 0:
                case Circle c when c.Radius == 0:
                case Triangle t when t.Base == 0 || t.Height == 0:
                case Rectangle r when r.Length == 0 || r.Height == 0:
                    return 0;

                case Square s when s.Side < 5:
                    return ComputeAreaOfSquare(s);
                case Circle c:
                    return ComputeAreaOfCircle(c);
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
