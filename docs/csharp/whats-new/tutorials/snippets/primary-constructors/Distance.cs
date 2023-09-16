namespace StructOne
{
    // <ReadonlyStruct>
    public readonly struct Distance(double dx, double dy)
    {
        public readonly double Magnitude { get; } = Math.Sqrt(dx * dx + dy * dy);
        public readonly double Direction { get; } = Math.Atan2(dy, dx);
    }
    // </ReadonlyStruct>
}

namespace Lowered
{
    // <StructOneLowered>
    public readonly struct Distance
    {
        public readonly double Magnitude { get; }

        public readonly double Direction { get; }

        public Distance(double dx, double dy)
        {
            Magnitude = Math.Sqrt(dx * dx + dy * dy);
            Direction = Math.Atan2(dy, dx);
        }
    }
    // </StructOneLowered>
}

namespace StructTwo
{
    // <MutableStruct>
    public struct Distance(double dx, double dy)
    {
        public readonly double Magnitude => Math.Sqrt(dx * dx + dy * dy);
        public readonly double Direction => Math.Atan2(dy, dx);

        public void Translate(double deltaX, double deltaY)
        {
            dx += deltaX;
            dy += deltaY;
        }

        public Distance() : this(0,0) { }
    }
    // </MutableStruct>
}

namespace LoweredMutable
{
    // <StructTwoLowered>
    public struct Distance
    {
        private double __unspeakable_dx;
        private double __unspeakable_dy;

        public readonly double Magnitude => Math.Sqrt(__unspeakable_dx * __unspeakable_dx + __unspeakable_dy * __unspeakable_dy);
        public readonly double Direction => Math.Atan2(__unspeakable_dy, __unspeakable_dx);

        public void Translate(double deltaX, double deltaY)
        {
            __unspeakable_dx += deltaX;
            __unspeakable_dy += deltaY;
        }

        public Distance(double dx, double dy)
        {
            __unspeakable_dx = dx;
            __unspeakable_dy = dy;
        }
        public Distance() : this(0, 0) { }
    }
    // </StructTwoLowered>

}
