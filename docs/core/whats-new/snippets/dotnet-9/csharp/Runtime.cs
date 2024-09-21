using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics;

class Runtime
{
    // <SnippetForLoop>
    static int Sum(int[] nums)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
        }

        return sum;
    }
    // </SnippetForLoop>

    // <SnippetWhileLoop>
    static int Sum2(Span<int> nums)
    {
        int sum = 0;
        ref int p = ref MemoryMarshal.GetReference(nums);
        ref int end = ref Unsafe.Add(ref p, nums.Length);
        while (Unsafe.IsAddressLessThan(ref p, ref end))
        {
            sum += p;
            p = ref Unsafe.Add(ref p, 1);
        }

        return sum;
    }
    // </SnippetWhileLoop>

    // <SnippetAdvance>
    class Body { public double x, y, z, vx, vy, vz, mass; }

    static void Advance(double dt, Body[] bodies)
    {
        foreach (Body b in bodies)
        {
            b.x += dt * b.vx;
            b.y += dt * b.vy;
            b.z += dt * b.vz;
        }
    }
    // </SnippetAdvance>

    // <SnippetTest1>
    static byte Test1()
    {
        Vector128<byte> v = Vector128<byte>.Zero;
        const byte size = 1;
        v = Sse2.ShiftRightLogical128BitLane(v, size);
        return Sse41.Extract(v, 0);
    }
    // </SnippetTest1>

    // <SnippetCompare>
    static bool Compare(object? x, object? y)
    {
        if ((x == null) || (y == null))
        {
            return x == y;
        }

        return x.Equals(y);
    }

    public static int RunIt()
    {
        bool result = Compare(3, 4);
        return result ? 0 : 100;
    }
    // </SnippetCompare>
}
