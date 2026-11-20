using System.Numerics.Tensors;

namespace SimdSnippets;

public static class TensorPrimitivesExample
{
    // <TensorPrimitives>
    // Computes result = (left * right) + addend over the whole span, vectorized internally.
    public static float[] MultiplyAdd(float[] left, float[] right, float[] addend)
    {
        float[] result = new float[left.Length];

        TensorPrimitives.Multiply(left, right, result);
        TensorPrimitives.Add(result, addend, result);

        return result;
    }

    // Higher-level reductions are available too.
    public static float CosineSimilarity(float[] left, float[] right) =>
        TensorPrimitives.CosineSimilarity(left, right);
    // </TensorPrimitives>
}
