using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.Wasm;
using System.Runtime.Intrinsics.X86;

namespace SimdSnippets;

public static class HardwareIntrinsicsExample
{
    // <HardwareIntrinsics>
    // Illustrates per-platform lightup. The portable '(vector & mask) == Zero' below
    // already lowers optimally, so prefer it unless a specific instruction measurably wins.
    public static bool AllBitsClear(Vector128<byte> vector, Vector128<byte> mask)
    {
        if (Sse41.IsSupported)
        {
            // x86/x64: a single ptest instruction.
            return Sse41.TestZ(vector, mask);
        }
        else if (AdvSimd.Arm64.IsSupported)
        {
            // Arm64: AND, then reduce the maximum byte across every lane.
            Vector128<byte> anded = AdvSimd.And(vector, mask);
            return AdvSimd.Arm64.MaxAcross(anded).ToScalar() == 0;
        }
        else if (PackedSimd.IsSupported)
        {
            // WebAssembly: AND, then test whether any lane is non-zero.
            return !PackedSimd.AnyTrue(PackedSimd.And(vector, mask));
        }
        else
        {
            // Portable fallback for any other platform.
            return (vector & mask) == Vector128<byte>.Zero;
        }
    }
    // </HardwareIntrinsics>
}
