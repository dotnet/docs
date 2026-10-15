using System.Diagnostics;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace SimdSnippets;

public static class AdvancedVectorization
{
    // <CodeStructure>
    // Sums a buffer, choosing the widest vector the hardware and element type support.
    public static T Sum<T>(ReadOnlySpan<T> buffer)
        where T : unmanaged, INumberBase<T>
    {
        // The widest-first order continues with the Vector512 and Vector256 paths, which belong
        // here ahead of the Vector128 block below. They're identical to it aside from the wider
        // type (for example, Vector512<T> with Vector512.Create and Vector512.Sum), so they're
        // omitted for brevity:
        //
        // if (Vector512.IsHardwareAccelerated && Vector512<T>.IsSupported)
        // {
        //     if (buffer.Length >= Vector512<T>.Count)
        //     {
        //         return SumVector512(buffer);
        //     }
        //     return SumVectorSmall(buffer);
        // }
        //
        // if (Vector256.IsHardwareAccelerated && Vector256<T>.IsSupported)
        // {
        //     if (buffer.Length >= Vector256<T>.Count)
        //     {
        //         return SumVector256(buffer);
        //     }
        //     return SumVectorSmall(buffer);
        // }

        if (Vector128.IsHardwareAccelerated && Vector128<T>.IsSupported)
        {
            if (buffer.Length >= Vector128<T>.Count)
            {
                return SumVector128(buffer);
            }
            return SumVectorSmall(buffer);
        }

        return SumScalar(buffer);
    }
    // </CodeStructure>

    private static T SumScalar<T>(ReadOnlySpan<T> buffer)
        where T : unmanaged, INumberBase<T>
    {
        T result = T.Zero;
        foreach (T value in buffer)
        {
            result += value;
        }
        return result;
    }

    // <VectorSmall>
    // Sums a buffer smaller than the widest vector. The complete "optimal" shape dispatches on the
    // element width so each width uses a switch jump table sized to the number of elements that fit
    // in the widest vector (63 for byte, 31 for short, 15 for int/float, 7 for long/double).
    private static T SumVectorSmall<T>(ReadOnlySpan<T> buffer)
        where T : unmanaged, INumberBase<T>
    {
        // sizeof(T) is a JIT constant, so only the matching branch survives for a given T.
        if (sizeof(T) == 4)
        {
            return SumVectorSmall4(buffer);
        }

        // The 1-, 2-, and 8-byte tables share the shape below, sized for their element width.
        // They're omitted for brevity, so those widths fall back to a scalar loop here:
        //
        // if (sizeof(T) == 1) return SumVectorSmall1(buffer); // switch over lengths 0..63
        // if (sizeof(T) == 2) return SumVectorSmall2(buffer); // switch over lengths 0..31
        // if (sizeof(T) == 8) return SumVectorSmall8(buffer); // switch over lengths 0..7
        return SumScalar(buffer);
    }

    private static T SumVectorSmall4<T>(ReadOnlySpan<T> buffer)
        where T : unmanaged, INumberBase<T>
    {
        Debug.Assert(sizeof(T) == 4);
        Debug.Assert(buffer.Length < Vector512<T>.Count);

        T result = T.Zero;

        // A 4-byte element gives Count == 4/8/16 for Vector128/256/512, so a remainder can be up to
        // 15 elements. The larger cases fold the leftover with the widest vector that fits, using two
        // overlapping loads (one from the start, one from the end) rather than recursing—the shape
        // TensorPrimitives uses. The loads overlap for lengths that aren't an exact multiple of the
        // width, so the tail is masked down to the additive identity before it's summed. That mask is
        // only needed because addition is non-idempotent; an idempotent operation such as a search
        // could fold the overlapping tail in directly.
        switch (buffer.Length)
        {
            // One or two Vector256's worth of data.
            case 15:
            case 14:
            case 13:
            case 12:
            case 11:
            case 10:
            case 9:
            case 8:
            {
                Vector256<T> beg = Vector256.Create(buffer);
                Vector256<T> end = Vector256.Create(buffer.Slice(buffer.Length - Vector256<T>.Count));

                Vector256<T> msk = CreateRemainderMask256<T>(buffer.Length - Vector256<T>.Count);
                end = Vector256.ConditionalSelect(msk, end, Vector256<T>.Zero);

                result = Vector256.Sum(beg + end);
                break;
            }

            // One or two Vector128's worth of data.
            case 7:
            case 6:
            case 5:
            case 4:
            {
                Vector128<T> beg = Vector128.Create(buffer);
                Vector128<T> end = Vector128.Create(buffer.Slice(buffer.Length - Vector128<T>.Count));

                Vector128<T> msk = CreateRemainderMask128<T>(buffer.Length - Vector128<T>.Count);
                end = Vector128.ConditionalSelect(msk, end, Vector128<T>.Zero);

                result = Vector128.Sum(beg + end);
                break;
            }

            // Smaller than a single vector: each case falls through to the next, accumulating one
            // element per label.
            case 3:
            {
                result += buffer[2];
                goto case 2;
            }

            case 2:
            {
                result += buffer[1];
                goto case 1;
            }

            case 1:
            {
                result += buffer[0];
                goto case 0;
            }

            case 0:
            {
                break;
            }
        }

        return result;
    }

    // Builds a mask whose last `keepLast` lanes are all-bits-set and the rest zero, so an overlapping
    // tail load can be folded in without double-counting the lanes the head already covered.
    // TensorPrimitives uses an internal table-based helper. The mask is only a bit pattern keyed on
    // lane width, so it's built with the same-width integer Indices ([0, 1, 2, ...]) and reinterpreted
    // to T: integer comparisons are cheaper than floating-point ones, so a float/double table would
    // still compare as int/long rather than in its own element type.
    private static Vector256<T> CreateRemainderMask256<T>(int keepLast)
        where T : unmanaged, INumberBase<T>
    {
        Debug.Assert(sizeof(T) == 4);

        Vector256<int> firstKept = Vector256.Create(Vector256<int>.Count - keepLast);
        return Vector256.GreaterThanOrEqual(Vector256<int>.Indices, firstKept).As<int, T>();
    }

    private static Vector128<T> CreateRemainderMask128<T>(int keepLast)
        where T : unmanaged, INumberBase<T>
    {
        Debug.Assert(sizeof(T) == 4);

        Vector128<int> firstKept = Vector128.Create(Vector128<int>.Count - keepLast);
        return Vector128.GreaterThanOrEqual(Vector128<int>.Indices, firstKept).As<int, T>();
    }
    // </VectorSmall>

    // <MaskedRemainder>
    // Sums a buffer with an unrolled vector loop plus a masked, jump-table remainder.
    private static T SumVector128<T>(ReadOnlySpan<T> buffer)
        where T : unmanaged, INumberBase<T>
    {
        Debug.Assert(Vector128.IsHardwareAccelerated && Vector128<T>.IsSupported);
        Debug.Assert(buffer.Length >= Vector128<T>.Count);

        // Preload the last full vector, overlapping the tail. Any sub-vector remainder is folded in
        // from here (masked) by case 0 of the switch below, so the loop never falls out to a separate
        // scalar tail—the same shape TensorPrimitives uses.
        Vector128<T> end = Vector128.Create(buffer.Slice(buffer.Length - Vector128<T>.Count));

        // A production implementation would also align the buffer to a vector boundary and, for
        // very large inputs, use non-temporal loads/stores so the data doesn't evict useful
        // cache lines. Both are omitted here; see TensorPrimitives for a complete treatment.

        Vector128<T> sum = Vector128<T>.Zero;

        // Only pay for the four independent accumulators when there's enough data to unroll;
        // smaller payloads skip straight to the remainder below. Four vectors per iteration lets
        // the accumulators pipeline; Vector128.Create reads the first Vector128<T>.Count elements.
        if (buffer.Length >= Vector128<T>.Count * 4)
        {
            Vector128<T> sum0 = Vector128<T>.Zero;
            Vector128<T> sum1 = Vector128<T>.Zero;
            Vector128<T> sum2 = Vector128<T>.Zero;
            Vector128<T> sum3 = Vector128<T>.Zero;

            do
            {
                sum0 += Vector128.Create(buffer);
                sum1 += Vector128.Create(buffer.Slice(Vector128<T>.Count));
                sum2 += Vector128.Create(buffer.Slice(Vector128<T>.Count * 2));
                sum3 += Vector128.Create(buffer.Slice(Vector128<T>.Count * 3));

                buffer = buffer.Slice(Vector128<T>.Count * 4);
            }
            while (buffer.Length >= Vector128<T>.Count * 4);

            // Combine pairwise so the two independent adds can pipeline.
            sum = (sum0 + sum1) + (sum2 + sum3);
        }

        // Split the remainder into its full vectors and a sub-vector tail. The full vectors fall
        // through the jump table; the tail lands in case 0, where the preloaded end is masked so only
        // the trailing elements the full vectors didn't already cover are added.
        (int blocks, int trailing) = Math.DivRem(buffer.Length, Vector128<T>.Count);

        switch (blocks)
        {
            case 3:
            {
                sum += Vector128.Create(buffer.Slice(Vector128<T>.Count * 2));
                goto case 2;
            }

            case 2:
            {
                sum += Vector128.Create(buffer.Slice(Vector128<T>.Count));
                goto case 1;
            }

            case 1:
            {
                sum += Vector128.Create(buffer);
                goto case 0;
            }

            case 0:
            {
                Vector128<T> msk = CreateRemainderMask128<T>(trailing);
                sum += Vector128.ConditionalSelect(msk, end, Vector128<T>.Zero);
                break;
            }
        }

        // Horizontally add the lanes into a single scalar.
        return Vector128.Sum(sum);
    }
    // </MaskedRemainder>
}
