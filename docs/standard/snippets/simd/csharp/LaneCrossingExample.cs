using System.Diagnostics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SimdSnippets;

public static class LaneCrossingExample
{
    // <SumVector128>
    // Sums all four elements with two rounds of pairwise horizontal adds.
    // HorizontalAdd(v, v) on [a, b, c, d] gives [a+b, c+d, a+b, c+d]; a second round
    // collapses that to the full sum in every element.
    public static float SumVector128(Vector128<float> v)
    {
        Debug.Assert(Sse3.IsSupported);

        Vector128<float> step1 = Sse3.HorizontalAdd(v, v);
        Vector128<float> step2 = Sse3.HorizontalAdd(step1, step1);

        return step2.ToScalar();
    }
    // </SumVector128>

    // <SumVector256Naive>
    // The same two-round pattern on Vector256<float> looks like it should sum all eight
    // elements, but Avx.HorizontalAdd repeats the pairwise pattern independently within
    // each 128-bit lane. The result holds the lower lane's sum (elements 0-3) broadcast
    // across the lower lane and the upper lane's sum (elements 4-7) broadcast across the
    // upper lane -- ToScalar only returns the lower lane's partial sum, not the total.
    public static float SumVector256Naive(Vector256<float> v)
    {
        Debug.Assert(Avx.IsSupported);

        Vector256<float> step1 = Avx.HorizontalAdd(v, v);
        Vector256<float> step2 = Avx.HorizontalAdd(step1, step1);

        return step2.ToScalar();
    }
    // </SumVector256Naive>

    // <SumVector256>
    // Getting the full sum needs an explicit step to cross the lane boundary: read each
    // lane's partial sum out with GetLower/GetUpper and add them together.
    public static float SumVector256(Vector256<float> v)
    {
        Debug.Assert(Avx.IsSupported);

        Vector256<float> step1 = Avx.HorizontalAdd(v, v);
        Vector256<float> step2 = Avx.HorizontalAdd(step1, step1);

        Vector128<float> lower = step2.GetLower();
        Vector128<float> upper = step2.GetUpper();

        return lower.ToScalar() + upper.ToScalar();
    }
    // </SumVector256>
}
