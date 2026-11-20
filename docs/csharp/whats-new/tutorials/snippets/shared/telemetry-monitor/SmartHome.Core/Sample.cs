using System.Numerics;

namespace SmartHome.Core;

// <SampleUnion>
// A generic union, reusable across sensors of different numeric precision. A
// Sample<T> holds either an in-range reading of type T or a Saturated marker
// for a sensor that railed. The 'struct, INumber<T>' constraint keeps T a
// non-nullable numeric value type, so a switch over the cases needs no null arm.
public union Sample<T>(T, Saturated) where T : struct, INumber<T>
{
    // A union can declare members. This property patterns over 'this' to report
    // whether the sample carries a usable reading.
    public bool InRange => this is T;
}

// A marker for a railed sensor, carrying which rail it hit.
public readonly record struct Saturated(bool High);
// </SampleUnion>

public static class SampleReporter
{
    // <SampleConsume>
    // Scale any numeric width to a fraction of full scale. The INumber<T>
    // constraint makes the same arithmetic work for byte, short, int, and more.
    public static double Normalize<T>(Sample<T> sample, T fullScale)
        where T : struct, INumber<T> => sample switch
    {
        T value => double.CreateChecked(value) / double.CreateChecked(fullScale),
        Saturated { High: true } => 1.0,
        Saturated => 0.0,
    };
    // </SampleConsume>
}
