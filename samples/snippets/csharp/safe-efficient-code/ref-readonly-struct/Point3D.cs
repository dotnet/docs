using System;

namespace SafeEfficientCode
{
    public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        #region OriginReference
        private static Point3D origin = new Point3D();
        public static ref readonly Point3D Origin => ref origin;
        #endregion
    }

    #region ReadonlyOnlyPoint3D
    readonly public struct ReadonlyPoint3D
    {
        public ReadonlyPoint3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        private static readonly ReadonlyPoint3D origin = new ReadonlyPoint3D();
        public static ref readonly ReadonlyPoint3D Origin => ref origin;
    }
    #endregion
}
