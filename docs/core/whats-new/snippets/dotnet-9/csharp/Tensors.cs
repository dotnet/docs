using System;
using System.Numerics.Tensors;

internal class Tensors
{
    public static void RunIt()
    {
        // <SnippetTensor>
        // Create a tensor (1 x 3).
        Tensor<int> t0 = Tensor.Create([1, 2, 3], [1, 3]); // [[1, 2, 3]]

        // Reshape tensor (3 x 1).
        Tensor<int> t1 = t0.Reshape(3, 1); // [[1], [2], [3]]

        // Slice tensor (2 x 1).
        Tensor<int> t2 = t1.Slice(1.., ..); // [[2], [3]]

        // Broadcast tensor (3 x 1) -> (3 x 3).
        // [
        //  [ 1, 1, 1],
        //  [ 2, 2, 2],
        //  [ 3, 3, 3]
        // ]
        var t3 = Tensor.Broadcast<int>(t1, [3, 3]);

        // Math operations.
        var t4 = Tensor.Add(t0, 1); // [[2, 3, 4]]
        var t5 = Tensor.Add(t0.AsReadOnlyTensorSpan(), t0); // [[2, 4, 6]]
        var t6 = Tensor.Subtract(t0, 1); // [[0, 1, 2]]
        var t7 = Tensor.Subtract(t0.AsReadOnlyTensorSpan(), t0); // [[0, 0, 0]]
        var t8 = Tensor.Multiply(t0, 2); // [[2, 4, 6]]
        var t9 = Tensor.Multiply(t0.AsReadOnlyTensorSpan(), t0); // [[1, 4, 9]]
        var t10 = Tensor.Divide(t0, 2); // [[0.5, 1, 1.5]]
        var t11 = Tensor.Divide(t0.AsReadOnlyTensorSpan(), t0); // [[1, 1, 1]]
        // </SnippetTensor>

        // <SnippetCosineSimilarity>
        ReadOnlySpan<float> vector1 = [1, 2, 3];
        ReadOnlySpan<float> vector2 = [4, 5, 6];
        Console.WriteLine(TensorPrimitives.CosineSimilarity(vector1, vector2));
        // Prints 0.9746318

        ReadOnlySpan<double> vector3 = [1, 2, 3];
        ReadOnlySpan<double> vector4 = [4, 5, 6];
        Console.WriteLine(TensorPrimitives.CosineSimilarity(vector3, vector4));
        // Prints 0.9746318461970762

        // </SnippetCosineSimilarity>
    }
}
