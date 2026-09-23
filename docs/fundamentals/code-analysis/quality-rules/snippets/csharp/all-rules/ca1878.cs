using System;

// <Violation>
class CA1878ViolationExample
{
    private static readonly byte[] Prefix = new byte[] { 0x50, 0x4B, 0x03, 0x04 };

    public static ReadOnlySpan<byte> GetPrefix() => Prefix;
}
// </Violation>

// <Fix>
class CA1878FixExample
{
    private static ReadOnlySpan<byte> Prefix => new byte[] { 0x50, 0x4B, 0x03, 0x04 };

    public static ReadOnlySpan<byte> GetPrefix() => Prefix;
}
// </Fix>
