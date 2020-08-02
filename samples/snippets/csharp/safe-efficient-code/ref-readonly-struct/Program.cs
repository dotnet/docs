using System;

namespace SafeEfficientCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var pt1 = new Point3D { X = 3, Y = 4, Z = 5 };
            var pt2 = new Point3D { X = 10, Y = 8, Z = 5 };

            #region UseInArgument
            var distance = CalculateDistance(pt1, pt2);
            var fromOrigin = CalculateDistance(pt1, new Point3D());
            #endregion

            #region ExplicitInArgument
            distance = CalculateDistance(in pt1, in pt2);
            distance = CalculateDistance(in pt1, new Point3D());
            distance = CalculateDistance(pt1, in Point3D.Origin);
            #endregion

            fromOrigin = CalculateDistance2(pt1);

            #region AssignRefReadonly
            var originValue = Point3D.Origin;
            ref readonly var originReference = ref Point3D.Origin;
            #endregion
        }

        #region ByValue
        private static double CalculateDistance(Point3D point1, Point3D point2)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }
        #endregion

        #region InArgument
        private static double CalculateDistance(in Point3D point1, in Point3D point2)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }
        #endregion

        #region InArgumentDefault
        private static double CalculateDistance2(in Point3D point1, in Point3D point2 = default)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }
        #endregion

        #region ReadOnlyInArgument
        private static double CalculateDistance3(in ReadonlyPoint3D point1, in ReadonlyPoint3D point2 = default)
        {
            double xDifference = point1.X - point2.X;
            double yDifference = point1.Y - point2.Y;
            double zDifference = point1.Z - point2.Z;

            return Math.Sqrt(xDifference * xDifference + yDifference * yDifference + zDifference * zDifference);
        }
        #endregion
    }
}
