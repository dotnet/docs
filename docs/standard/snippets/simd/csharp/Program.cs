using System.Numerics;
using System.Linq;
using System.Runtime.Intrinsics;
using SimdSnippets;

// Verification runner. Not part of the published snippets.

Console.WriteLine($"Vector.IsHardwareAccelerated:    {Vector.IsHardwareAccelerated}");
Console.WriteLine($"Vector128.IsHardwareAccelerated: {Vector128.IsHardwareAccelerated}");
Console.WriteLine($"Vector256.IsHardwareAccelerated: {Vector256.IsHardwareAccelerated}");
Console.WriteLine($"Vector512.IsHardwareAccelerated: {Vector512.IsHardwareAccelerated}");
Console.WriteLine($"Vector<int>.Count:               {Vector<int>.Count}");
Console.WriteLine();

NumericsExamples.SimpleVectors();
NumericsExamples.Matrices();

double[] left = [1, 2, 3, 4, 5, 6, 7];
double[] right = [10, 20, 30, 40, 50, 60, 70];
Console.WriteLine($"Vector<T> Add: [{string.Join(", ", NumericsExamples.Add(left, right))}]");
Console.WriteLine();

int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
double[] reals = [1.5, 2.5, 3.0, 4.0, 5.0];
Console.WriteLine($"Sum<int>(1..10)    = {AdvancedVectorization.Sum<int>(numbers)}");
Console.WriteLine($"Sum<double>(reals) = {AdvancedVectorization.Sum<double>(reals)}");
Console.WriteLine($"Sum<int>(small)    = {AdvancedVectorization.Sum<int>(new int[] { 1, 2, 3 })}");
Console.WriteLine($"Sum<int>(1..37)    = {AdvancedVectorization.Sum<int>(Enumerable.Range(1, 37).ToArray())}");
Console.WriteLine($"Contains(7)        = {SimpleVectorization.Contains(numbers, 7)}");
Console.WriteLine($"Contains(42)       = {SimpleVectorization.Contains(numbers, 42)}");
Console.WriteLine($"Contains(small,2)  = {SimpleVectorization.Contains(new int[] { 1, 2, 3 }, 2)}");
Console.WriteLine($"Contains(small,9)  = {SimpleVectorization.Contains(new int[] { 1, 2, 3 }, 9)}");
Console.WriteLine($"Contains(empty)    = {SimpleVectorization.Contains(Array.Empty<int>(), 1)}");
Console.WriteLine();

byte[] ascii = "Hello, SIMD!"u8.ToArray();
byte[] notAscii = [0x48, 0x65, 0xFF, 0x6C];
Console.WriteLine($"IsAscii(ascii)    = {SimpleVectorization.IsAscii(ascii)}");
Console.WriteLine($"IsAscii(notAscii) = {SimpleVectorization.IsAscii(notAscii)}");
Console.WriteLine();

Vector128<byte> highBits = Vector128.Create<byte>(0b_1000_0000);
Console.WriteLine($"AllBitsClear(zero, highBits)     = {HardwareIntrinsicsExample.AllBitsClear(Vector128<byte>.Zero, highBits)}");
Console.WriteLine($"AllBitsClear(0xFF.., highBits)   = {HardwareIntrinsicsExample.AllBitsClear(Vector128<byte>.AllBitsSet, highBits)}");
Console.WriteLine();

float[] a = [1, 2, 3, 4];
float[] b = [5, 6, 7, 8];
float[] c = [1, 1, 1, 1];
Console.WriteLine($"MultiplyAdd = [{string.Join(", ", TensorPrimitivesExample.MultiplyAdd(a, b, c))}]");
Console.WriteLine($"CosineSimilarity(a, a) = {TensorPrimitivesExample.CosineSimilarity(a, a)}");
