using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace SimdSnippets;

public static class SimpleVectorization
{
    // <VectorizedRemainder>
    // Idempotent search that re-processes the final vector instead of a scalar loop.
    public static bool Contains(ReadOnlySpan<int> buffer, int searched)
    {
        Debug.Assert(Vector128.IsHardwareAccelerated);

        Vector128<int> values = Vector128.Create(searched);
        ReadOnlySpan<int> remaining = buffer;

        while (remaining.Length >= Vector128<int>.Count)
        {
            if (Vector128.EqualsAny(Vector128.Create(remaining), values))
            {
                return true;
            }
            remaining = remaining.Slice(Vector128<int>.Count);
        }

        if (remaining.IsEmpty)
        {
            return false;
        }

        // A partial vector remains. When the buffer holds at least one full vector,
        // re-check the last one (overlapping the tail); otherwise scan the few elements directly.
        if (buffer.Length >= Vector128<int>.Count)
        {
            Vector128<int> tail = Vector128.Create(buffer.Slice(buffer.Length - Vector128<int>.Count));
            return Vector128.EqualsAny(tail, values);
        }

        foreach (int value in remaining)
        {
            if (value == searched)
            {
                return true;
            }
        }

        return false;
    }
    // </VectorizedRemainder>

    public static bool IsValidAscii(byte value) => (value & 0b1000_0000) == 0;

    // Returns true when every byte in the vector is a valid ASCII value (0-127).
    // Anding with the high bit and comparing to zero avoids a movemask extraction.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsValidAscii(Vector128<byte> vector) =>
        (vector & Vector128.Create<byte>(0b1000_0000)) == Vector128<byte>.Zero;

    public static bool IsAscii(ReadOnlySpan<byte> buffer)
    {
        ReadOnlySpan<byte> remaining = buffer;

        if (Vector128.IsHardwareAccelerated)
        {
            while (remaining.Length >= Vector128<byte>.Count)
            {
                if (!IsValidAscii(Vector128.Create(remaining)))
                {
                    return false;
                }
                remaining = remaining.Slice(Vector128<byte>.Count);
            }
        }

        // Scalar path handles the remainder and short or non-accelerated inputs.
        foreach (byte value in remaining)
        {
            if (!IsValidAscii(value))
            {
                return false;
            }
        }

        return true;
    }
}
