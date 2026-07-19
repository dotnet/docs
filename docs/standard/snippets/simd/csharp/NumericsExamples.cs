using System.Numerics;

namespace SimdSnippets;

public static class NumericsExamples
{
    public static void SimpleVectors()
    {
        // <SimpleVectorAdd>
        Vector2 v1 = Vector2.Create(0.1f, 0.2f);
        Vector2 v2 = Vector2.Create(1.1f, 2.2f);
        Vector2 sum = v1 + v2;
        // </SimpleVectorAdd>

        // <SimpleVectorOps>
        float dot = Vector2.Dot(v1, v2);
        float distance = Vector2.Distance(v1, v2);
        Vector2 clamped = Vector2.Clamp(v1, Vector2.Zero, Vector2.One);
        // </SimpleVectorOps>

        Console.WriteLine($"sum={sum}, dot={dot}, distance={distance}, clamped={clamped}");
    }

    public static void Matrices()
    {
        // <MatrixMultiply>
        Matrix4x4 m1 = Matrix4x4.Create(
            1.1f, 1.2f, 1.3f, 1.4f,
            2.1f, 2.2f, 3.3f, 4.4f,
            3.1f, 3.2f, 3.3f, 3.4f,
            4.1f, 4.2f, 4.3f, 4.4f);

        Matrix4x4 m2 = Matrix4x4.Transpose(m1);
        Matrix4x4 product = Matrix4x4.Multiply(m1, m2);
        // </MatrixMultiply>

        Console.WriteLine($"product.M11={product.M11}");
    }

    // <VectorTAdd>
    // Illustrative: element-wise add with Vector<T>. In practice, prefer the already-accelerated
    // TensorPrimitives.Add, which is optimized for every Vector<T>.IsSupported element type.
    public static double[] Add(double[] left, double[] right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);
        ArgumentOutOfRangeException.ThrowIfNotEqual(right.Length, left.Length);

        double[] result = new double[left.Length];

        int i = 0;

        // Vector<T>.Count is a JIT-time constant, so the compiler optimizes the loop bound.
        int lastVectorStart = left.Length - Vector<double>.Count;

        for (; i <= lastVectorStart; i += Vector<double>.Count)
        {
            Vector<double> v1 = Vector.Create(left.AsSpan(i));
            Vector<double> v2 = Vector.Create(right.AsSpan(i));
            (v1 + v2).CopyTo(result, i);
        }

        // Process any remaining elements that don't fill a full vector.
        // Simplified for illustration: a scalar tail isn't optimal. A vectorized
        // remainder that reprocesses the last full vector avoids the per-element loop.
        for (; i < left.Length; i++)
        {
            result[i] = left[i] + right[i];
        }

        return result;
    }
    // </VectorTAdd>
}
