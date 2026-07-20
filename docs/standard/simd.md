---
title: Use SIMD and hardware intrinsics in .NET
description: Learn about the layered SIMD support in .NET, from System.Numerics vector types to cross-platform Vector64/128/256/512 APIs, hardware intrinsics, and TensorPrimitives.
author: FIVIL
ms.author: tagoo
ms.date: 07/18/2026
ai-usage: ai-assisted
---

# Use SIMD and hardware intrinsics in .NET

SIMD (single instruction, multiple data) is hardware support for applying one operation to multiple pieces of data in parallel with a single instruction. Vectorized code processes several values per iteration instead of one, which can greatly increase throughput for the kind of numeric, scientific, graphics, text-processing, and data-parallel work where the same operation repeats over a buffer. The trade-off is added complexity, so it pays off most when the input is large enough and the win is confirmed with measurements.

.NET provides several kinds of SIMD support. Pick the one that matches how much control you need and how much complexity you're willing to take on.

## Types of SIMD support in .NET

| API | Namespace | When to use it |
| --- | --- | --- |
| Fixed-purpose vector and matrix types | <xref:System.Numerics> | Graphics and geometry math with 2-4 element vectors, matrices, quaternions, and planes. |
| `Vector<T>` | <xref:System.Numerics> | Portable, variable-width vectorization when you don't need per-platform control. |
| `Vector64<T>`, `Vector128<T>`, `Vector256<T>`, `Vector512<T>` | <xref:System.Runtime.Intrinsics> | Cross-platform, fixed-width vectorization with fine-grained control. This is the recommended starting point for new vectorized algorithms. |
| Hardware intrinsics | <xref:System.Runtime.Intrinsics.X86>, <xref:System.Runtime.Intrinsics.Arm>, <xref:System.Runtime.Intrinsics.Wasm> | Specific processor instructions that the higher-level APIs don't expose, for the last bit of performance on a hot path. |
| `TensorPrimitives` | <xref:System.Numerics.Tensors> | Ready-made, vectorized math over spans. It does the vectorization for you. |

Where these APIs overlap, they relate through layers of abstraction. The generic vector types are the foundational interchange types that the other layers pass around, so they're technically the lowest level: the variable-width `Vector<T>`, which grows to whatever width the running hardware supports, and the fixed-width `Vector64<T>` through `Vector512<T>`. The platform-specific hardware intrinsics in <xref:System.Runtime.Intrinsics.X86>, <xref:System.Runtime.Intrinsics.Arm>, and <xref:System.Runtime.Intrinsics.Wasm> operate on those types, each mapping directly to an individual processor instruction. The cross-platform operations exposed on the generic types sit a step above the platform-specific intrinsics, lowering to them for each target. Higher still are the managed APIs that operate over entire buffers—vectorized methods on `Span<T>` and `string`, and <xref:System.Numerics.Tensors.TensorPrimitives>—which build on the layers below, so you get SIMD acceleration without hand-writing any of it. The <xref:System.Numerics> fixed-shape types are domain-specific convenience types for graphics and geometry rather than part of this interchange stack.

The rest of this article works through these APIs from the highest level to the lowest, then covers testing, benchmarking, and best practices.

## System.Numerics vector and matrix types

The <xref:System.Numerics> namespace provides SIMD-accelerated types with a fixed shape:

- <xref:System.Numerics.Vector2>, <xref:System.Numerics.Vector3>, and <xref:System.Numerics.Vector4> represent vectors of 2, 3, and 4 <xref:System.Single> values.
- <xref:System.Numerics.Matrix3x2> and <xref:System.Numerics.Matrix4x4> represent 3x2 and 4x4 matrices of <xref:System.Single> values.
- <xref:System.Numerics.Plane> represents a plane in three-dimensional space.
- <xref:System.Numerics.Quaternion> represents a vector used to encode three-dimensional rotations.

These types map naturally to graphics and geometry, and the runtime accelerates their operations with SIMD instructions where the hardware supports them. The following example adds two vectors:

:::code language="csharp" source="./snippets/simd/csharp/NumericsExamples.cs" id="SimpleVectorAdd":::

They also expose the common vector math you'd expect, such as dot product, distance, and clamping:

:::code language="csharp" source="./snippets/simd/csharp/NumericsExamples.cs" id="SimpleVectorOps":::

The matrix types support matrix math such as transpose and multiplication:

:::code language="csharp" source="./snippets/simd/csharp/NumericsExamples.cs" id="MatrixMultiply":::

## Vector\<T>

`Vector<T>` represents a variable-width vector of a primitive numeric type. Its length is fixed for the lifetime of the process, but the value of `Vector<T>.Count` depends on the CPU that runs the code. The Just-In-Time (JIT) compiler treats `Count` as a constant, so loops written against it optimize well.

`Vector<T>` gives you portable vectorization without per-platform code, at the cost of not knowing the vector width at compile time. The following example computes the element-wise add of two arrays:

:::code language="csharp" source="./snippets/simd/csharp/NumericsExamples.cs" id="VectorTAdd":::

> [!NOTE]
> This example is illustrative. You rarely need to write a loop like this by hand, because [`TensorPrimitives`](#higher-level-math-with-tensorprimitives) already provides accelerated span-based math. This element-wise add is <xref:System.Numerics.Tensors.TensorPrimitives.Add*>, and reductions such as <xref:System.Numerics.Tensors.TensorPrimitives.Sum*> are provided too. These operations are hardware-accelerated for the element types that `Vector<T>` supports (`Vector<T>.IsSupported`).

## Check for hardware acceleration

SIMD-accelerated types work even on hardware or JIT configurations that don't support SIMD, because they fall back to non-accelerated software implementations. To branch on whether acceleration is actually available, check the relevant `IsHardwareAccelerated` property:

- <xref:System.Numerics.Vector.IsHardwareAccelerated?displayProperty=nameWithType> reports whether `Vector<T>` operations are accelerated.
- <xref:System.Runtime.Intrinsics.Vector128.IsHardwareAccelerated?displayProperty=nameWithType>, and the `Vector64`/`Vector256`/`Vector512` equivalents, report acceleration for each fixed width.

These properties are turned into constants by the JIT, so the branches you don't take are eliminated and there's no runtime cost to checking them. Don't cache the values; read them directly where you need them. The same applies to the `Count` properties (for example, `Vector128<T>.Count`), which are also JIT-time constants.

Most operations on an accelerated width are themselves accelerated, but it isn't guaranteed for every operation. For example, floating-point division might be accelerated where integer division isn't. When `Vector256` is accelerated, `Vector128` usually is too, but there's no guarantee, so check each width you use.

> [!TIP]
> If an operation you need isn't accelerated on a platform you care about, or you'd like a new cross-platform API, file an issue on [dotnet/runtime](https://github.com/dotnet/runtime/issues). The same applies to codegen improvements.

Not every element type is valid for every vector. `Vector128<T>` and its siblings support the primitive numeric types (`byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `nint`, and `nuint`) today, and that set might grow to include other types in the future. Use `Vector128<T>.IsSupported` to determine whether a given `T` is valid, which is especially useful from generic code.

Types that aren't supported, such as `char` and `bool`, can still be vectorized by reinterpreting the buffer as a supported type of the same size. Use <xref:System.Runtime.InteropServices.MemoryMarshal.Cast*> to reinterpret a span—for example, `char` to `ushort`—or the vector's `As<TFrom, TTo>` method to reinterpret a vector you already hold. Reinterpretation only changes the type, not the underlying bits, so it's your responsibility to keep the data well-formed: a `bool` must stay `0` or `1`, and a `char` must remain a valid UTF-16 code unit. If a vectorized operation could produce an out-of-range value, take care to normalize the result before writing it back.

## Cross-platform vectorization with Vector128

`Vector128<T>` is the common denominator across every platform that supports vectorization, so it's the best place to start. It holds a 128-bit vector: 16 bytes, 8 shorts, 4 ints/floats, or 2 longs/doubles. `Vector256<T>` is twice as wide, and `Vector512<T>` twice again. Not all hardware supports the larger widths, so the examples that follow use `Vector128` for portability.

Each width has a generic type (`Vector128<T>`) for the data and a non-generic static class (<xref:System.Runtime.Intrinsics.Vector128>) that holds most of the operations, including static factory methods like `Create` and `Load`. Operators such as `+`, `&`, and `<<` are the idiomatic way to express arithmetic and bit operations; prefer them over the named method equivalents to avoid operator-precedence bugs and improve readability. For algorithms that depend on byte order, branch on <xref:System.BitConverter.IsLittleEndian>, which the JIT also folds to a constant.

> [!NOTE]
> On x86/x64, `Vector256<T>` operations are generally treated as two independent 128-bit "lanes". For most element-wise operations this is transparent, but operations that cross lanes (such as shuffles or pairwise/horizontal operations) might behave differently or cost more than the `Vector128` equivalent. Confirm with benchmarks before assuming a wider vector is faster.

### Common operations

`Vector128` and its wider siblings expose a large API surface. You don't need to memorize it—know the categories and look up the details when you need them. Every operation has a software fallback for platforms that can't accelerate it. The following table covers essentially the whole surface.

| Category | What it does | Representative APIs |
| --- | --- | --- |
| Constants | Predefined constant vectors | `Zero`, `One`, `NegativeOne`, `AllBitsSet`, `Indices`, `SignSequence`, `E`, `Pi`, `Tau`, `Epsilon`, `NaN`, `PositiveInfinity`, `NegativeInfinity`, `NegativeZero` |
| Creation | Broadcast a scalar, set elements, or generate a sequence | `Create`, `CreateScalar`, `CreateScalarUnsafe`, `Create(ReadOnlySpan<T>)`, `CreateSequence`, `CreateGeometricSequence`, `CreateHarmonicSequence`, `CreateAlternatingSequence` |
| Load and store | Move data between memory and a vector | `Load`, `LoadUnsafe`, `LoadAligned`, `LoadAlignedNonTemporal`, `Store`, `StoreUnsafe`, `StoreAligned`, `StoreAlignedNonTemporal`, `CopyTo`, `TryCopyTo` |
| Arithmetic | Element-wise math and reductions | `Add (x + y)`, `Subtract (x - y)`, `Multiply (x * y)`, `Divide (x / y)`, `Negate (-x)`, `AddSaturate`, `SubtractSaturate`, `Abs`, `Sqrt`, `FusedMultiplyAdd`, `Dot`, `Sum` |
| Bit operations | Bitwise logic and shifts | `BitwiseAnd (x & y)`, `BitwiseOr (x \| y)`, `Xor (x ^ y)`, `AndNot (x & ~y)`, `OnesComplement (~x)`, `ShiftLeft (x << n)`, `ShiftRightArithmetic (x >> n)`, `ShiftRightLogical (x >>> n)` |
| Min, max, and clamp | Element-wise minimum, maximum, and range clamping | `Min`, `Max`, `Clamp`, `MinMagnitude`, `MaxMagnitude`, `MinNumber`, `MaxNumber`, `MinMagnitudeNumber`, `MaxMagnitudeNumber` |
| Rounding | Round each element to an integral value | `Ceiling`, `Floor`, `Round`, `Truncate` |
| Math functions | Sign, interpolation, angle, and transcendental helpers | `CopySign`, `Lerp`, `DegreesToRadians`, `RadiansToDegrees`, `Hypot`, `Sin`, `Cos`, `SinCos`, `Asin`, `Exp`, `Log`, `Log2` |
| Comparison | Compare each element; the result is a vector mask, not the `bool` an operator gives | `Equals`, `GreaterThan`, `GreaterThanOrEqual`, `LessThan`, `LessThanOrEqual` |
| Classification | Per-element predicates over the number line, each returning a vector mask | `IsNaN`, `IsFinite`, `IsInfinity`, `IsPositiveInfinity`, `IsNegativeInfinity`, `IsInteger`, `IsEvenInteger`, `IsOddInteger`, `IsNegative`, `IsPositive`, `IsNormal`, `IsSubnormal`, `IsZero` |
| Comparison reductions | Collapse a per-element comparison to a single `bool` | `EqualsAll (x == y)`, `EqualsAny`, `GreaterThanAll`, `GreaterThanAny`, `GreaterThanOrEqualAll`, `GreaterThanOrEqualAny`, `LessThanAll`, `LessThanAny`, `LessThanOrEqualAll`, `LessThanOrEqualAny` |
| Whole-vector predicates | Reduce a vector to a `bool`: whether all, any, or no elements equal a value, or (the `WhereAllBitsSet` forms) have all bits set. Prefer these over converting a mask to an index | `All`, `Any`, `None`, `AllWhereAllBitsSet`, `AnyWhereAllBitsSet`, `NoneWhereAllBitsSet` |
| Search | Count or locate elements by value, or (the `WhereAllBitsSet` forms) set lanes in a mask | `Count`, `IndexOf`, `LastIndexOf`, `CountWhereAllBitsSet`, `IndexOfWhereAllBitsSet`, `LastIndexOfWhereAllBitsSet` |
| Mask to index | Turn a comparison mask into a scalar bitmask and scan it | `ExtractMostSignificantBits` with <xref:System.Numerics.BitOperations.TrailingZeroCount*> or <xref:System.Numerics.BitOperations.LeadingZeroCount*> |
| Selection | Blend two vectors according to a mask, bit by bit | `ConditionalSelect(x, y, z)`, equivalent to `(y & x) \| (z & ~x)` |
| Conversion | Change numeric type, computing new values (for example, `int` to `float`) | `ConvertToInt32`, `ConvertToInt64`, `ConvertToUInt32`, `ConvertToUInt64`, `ConvertToSingle`, `ConvertToDouble` |
| Widening and narrowing | Split elements into a wider type or pack them into a narrower one | `Widen`, `WidenLower`, `WidenUpper`, `Narrow`, `NarrowWithSaturation` |
| Reinterpretation | Reinterpret the bits as another element type without changing them | `As<TFrom, TTo>`, `AsByte`, `AsInt32`, `AsSingle`, and the other `As*` element forms |
| System.Numerics interop | Reinterpret between `Vector128<T>` and the fixed-shape numerics types | `AsVector`, `AsVector2`, `AsVector3`, `AsVector4`, `AsPlane`, `AsQuaternion`, `AsVector128`, `AsVector128Unsafe` |
| Reorder | Rearrange elements by index or interleave two vectors | `Shuffle`, `Reverse`, `Zip`, `ZipLower`, `ZipUpper`, `Unzip`, `UnzipEven`, `UnzipOdd`, `ConcatLowerLower`, `ConcatLowerUpper`, `ConcatUpperLower`, `ConcatUpperUpper` |
| Lane access | Read or replace individual elements and halves, or resize the vector | `GetElement`, `WithElement`, `ToScalar`, `GetLower`, `GetUpper`, `WithLower`, `WithUpper`, `ToVector256` |

> [!TIP]
> Several operations have `Estimate` and `Native` variants—for example, `MultiplyAddEstimate`, `ClampNative`, `MinNative`, `MaxNative`, `ShuffleNative`, and `ConvertToInt32Native`. They map to a faster hardware instruction that trades some precision or gives up an IEEE edge-case guarantee (such as NaN handling), so reach for them only when a benchmark shows the exact form is the bottleneck and the looser semantics are acceptable.

> [!NOTE]
> `Vector256.Shuffle` treats its input as a single 256-bit vector, where-as the platform-specific `Avx2.Shuffle` operates as two independent 128-bit lanes. The cross-platform API is the more portable choice, but confirm the behavior you need when porting hand-written intrinsics.

### Structure the code path

A vectorized method typically fans out into a path per vector width plus a scalar fallback for small inputs and non-accelerated hardware. To use the largest vector the hardware supports, check the widest vector first and work down:

:::code language="csharp" source="./snippets/simd/csharp/AdvancedVectorization.cs" id="CodeStructure":::

Each width's outer guard combines `Vector128.IsHardwareAccelerated` (a JIT-time constant for whether the platform accelerates that width) with `Vector128<T>.IsSupported` (whether the element type `T` is valid for that width). Inside a supported block, compare the input length against `Count` to choose between the vectorized path and a small-input fallback. The method is generic over `T`, and the `Vector256` and `Vector512` blocks—identical to the `Vector128` block but using the wider type—are shown commented out for brevity.

There are two distinct fallbacks. A buffer that's too small for even the narrowest vector, but on accelerated hardware, goes to `SumVectorSmall`—an explicit `switch` jump table that handles each possible sub-vector length without a loop:

:::code language="csharp" source="./snippets/simd/csharp/AdvancedVectorization.cs" id="VectorSmall":::

`sizeof(T)` is also a JIT-time constant, so `SumVectorSmall` dispatches on the element width to a table sized for the widest vector's worth of elements—the same approach <xref:System.Numerics.Tensors.TensorPrimitives> uses. (When the new memory safety model is enabled, `sizeof(T)` expressions on a type parameter with the `unmanaged` constraint is allowed in safe code.) Only the 4-byte table is shown; the 1-byte, 2-byte, and 8-byte tables share its shape. Its larger cases fold the leftover with a `Vector256` or `Vector128` using two overlapping loads—one from the start, one from the end—so the wider-remainder handling for the omitted `Vector512`/`Vector256` paths lives right in the jump table. The two loads overlap whenever the length isn't an exact multiple of the width, so the tail is masked to the additive identity with `ConditionalSelect` before it's summed. That mask is only needed because addition is non-idempotent; an idempotent operation such as a search could fold the overlapping tail in directly. A buffer on hardware with no vectorization at all falls through to `SumScalar`, an ordinary scalar loop.

### Loop over the input and handle the remainder

To process a buffer larger than a single vector, loop over it a vector at a time, then handle the leftover elements that don't fill a full vector. The robust way to handle that tail is to reprocess the last full vector's worth of elements, overlapping some the loop already handled—which avoids a separate scalar epilogue. Whether that overlap needs correcting depends on the operation.

A **non-idempotent** operation such as a sum would count the overlapping elements twice, so mask them down to the operation's identity before folding them in. Use this when each element must contribute exactly once:

:::code language="csharp" source="./snippets/simd/csharp/AdvancedVectorization.cs" id="MaskedRemainder":::

This version guards the unrolled loop with an `if`, so small payloads skip the four accumulators entirely and fall straight to the remainder. When there's enough data, a `do`/`while` accumulates four vectors per iteration into independent accumulators—which lets the processor pipeline the additions—and combines them pairwise. A `switch` jump table then folds in the remaining zero-to-three full vectors and, in `case 0`, the sub-vector tail: it reuses a full vector preloaded from the end of the buffer, overlapping the elements already processed, and masks that overlap down to the additive identity with `ConditionalSelect` so the tail stays vectorized instead of falling out to a scalar loop. As before, `Vector128.Create` reads `Vector128<T>.Count` elements from the span. The JIT elides the span's bounds check for typical access patterns, so `Create` is a fine default even in a hot loop; `LoadUnsafe` (covered next) is the lower-level alternative for when you walk the buffer by managed reference. For very large inputs, a complete implementation would also align the buffer and use non-temporal loads and stores to avoid evicting useful cache lines—both omitted here and covered fully by `TensorPrimitives`.

An **idempotent** operation such as searching for a value can reprocess the overlap harmlessly, so it folds the last vector in directly with no mask:

:::code language="csharp" source="./snippets/simd/csharp/SimpleVectorization.cs" id="VectorizedRemainder":::

> [!WARNING]
> Mishandling the remainder is a common source of bugs. A loop that reads past the end of the buffer produces non-deterministic results and can crash. The runtime's test suite uses a `BoundedMemory` helper that places a no-access page immediately after the buffer, so any out-of-bounds read throws an <xref:System.AccessViolationException> during testing. Always cover the remainder logic, including buffers whose length isn't a multiple of the vector width.

### Load and store vectors safely

For most code, `Vector128.Create(span)` and <xref:System.Runtime.Intrinsics.Vector128.CopyTo*> are the simplest way to move data between a span and a vector, and the JIT keeps them efficient. When you need the lower-level load and store—for example, to walk a buffer by managed reference—prefer the <xref:System.Runtime.Intrinsics.Vector128.LoadUnsafe*> and <xref:System.Runtime.Intrinsics.Vector128.StoreUnsafe*> overloads that take a managed reference and an `nuint` element offset. Unlike the pointer-based `Load`/`Store` overloads, they don't require pinning the buffer, and unlike raw reference arithmetic, they don't need you to manually advance a `ref`. Both alternatives are easy to get wrong in ways that introduce garbage-collector holes or access violations.

So that empty buffers don't throw, get the starting reference from <xref:System.Runtime.InteropServices.MemoryMarshal.GetReference*> (or <xref:System.Runtime.InteropServices.MemoryMarshal.GetArrayDataReference*> for arrays) rather than `ref span[0]`.

> [!IMPORTANT]
> Offset arithmetic uses unsigned `nuint`. Always check the buffer length before computing an offset such as `buffer.Length - Vector128<int>.Count`. If the buffer is smaller than one vector, that subtraction underflows to a huge value and the loop reads invalid memory.

## Platform-specific hardware intrinsics

When a specific processor instruction gives you an edge that the portable APIs don't expose, reach for the hardware intrinsics in <xref:System.Runtime.Intrinsics.X86>, <xref:System.Runtime.Intrinsics.Arm>, and <xref:System.Runtime.Intrinsics.Wasm>. Each intrinsic class has an `IsSupported` property (also a JIT constant) so you can guard the specialized path and fall back to portable code elsewhere:

:::code language="csharp" source="./snippets/simd/csharp/HardwareIntrinsicsExample.cs" id="HardwareIntrinsics":::

The preceding method shows how to light up per-architecture code paths when you want them, but it's deliberately a simple example: you don't actually need it here. The portable expression `(vector & mask) == Vector128<byte>.Zero` already lowers to the optimal instruction on each platform (for example, `ptest` on x86/x64), so it's doing the same work as the hand-written branches, just without the complexity. Reach for explicit intrinsics only when a specific instruction measurably beats what the portable APIs generate.

Hardware intrinsics require a separate implementation per instruction set, so treat them as an optimization for measured hot paths rather than a default. The `Vector128`/`Vector256` APIs already lower to efficient instructions on each platform, and in practice sophisticated per-instruction code doesn't always win. Confirm the difference with a benchmark before committing to the extra maintenance.

## Higher-level math with TensorPrimitives

If you need vectorized math over spans and don't want to write the loops yourself, <xref:System.Numerics.Tensors.TensorPrimitives> provides a large set of numeric operations—element-wise arithmetic, exponentials, and reductions such as dot product and cosine similarity—that are already vectorized internally. It's available in the [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors) NuGet package.

:::code language="csharp" source="./snippets/simd/csharp/TensorPrimitivesExample.cs" id="TensorPrimitives":::

For AI and numeric workloads, `TensorPrimitives` often delivers most of the benefit of hand-written SIMD with none of the complexity.

## Test all code paths

Because a vectorized method has several code paths, tests need to cover each one: the `Vector256` path, the `Vector128` path, and the scalar path, each with inputs both large enough and too small to benefit. You can vary the input size in tests, but you can't toggle hardware acceleration at the test level. Instead, control it with environment variables before the process starts:

- Set `DOTNET_EnableAVX2=0` to make <xref:System.Runtime.Intrinsics.Vector256.IsHardwareAccelerated?displayProperty=nameWithType> return `false`.
- Set `DOTNET_EnableHWIntrinsic=0` to disable intrinsics entirely, so `Vector128`, `Vector64`, and `Vector<T>` all report no acceleration.

To exercise every path on a single machine, run the test suite once with no overrides, once with `DOTNET_EnableAVX2=0`, and once with `DOTNET_EnableHWIntrinsic=0`. The alternative is running across enough varied hardware to cover them.

### Instruction-set configuration knobs

Beyond those two, the runtime recognizes a knob per logical grouping of instruction sets, each prefixed with `DOTNET_`. A single knob can cover several related instruction sets—`EnableAVX2`, for instance, gates AVX2 along with BMI1, BMI2, F16C, FMA, LZCNT, and MOVBE. Setting a knob to `0` disables its whole group and everything layered on top of it. Setting it to `1` (the default for most) allows the group, but the hardware must still actually support it—enabling a knob the current CPU lacks is ignored, so you can only ever narrow what's used, never force an unsupported instruction on and break yourself. `DOTNET_EnableHWIntrinsic=0` is the big hammer—it turns off everything down to the base, so `Vector128`, `Vector64`, and `Vector<T>` all report no acceleration and the code falls to its software path.

> [!IMPORTANT]
> These are diagnostic tools, meant primarily for testing and validation—exercising each code path, reproducing a hardware-specific issue, or confirming a fallback. They aren't designed for general or production use, and they aren't a stability contract. The following set is what .NET 11 recognizes; earlier releases exposed a different set—the baseline and AVX-512 knobs in particular were reconfigured—so confirm the names against the runtime version you target.
>
> These tools also have limits on what they reach. Because they gate JIT decisions, they don't affect code that was already compiled ahead of time through ReadyToRun or Native AOT, and they don't necessarily affect internal routines the runtime and core libraries use themselves. Treat them as a way to steer your own JIT-compiled code, not a global off switch for an instruction set.

The base switch and the width caps apply on every architecture:

| Knob (`DOTNET_` prefix) | Default | Effect |
| --- | --- | --- |
| `EnableHWIntrinsic` | `1` | Master switch for all hardware intrinsics; `0` forces the fully software path. |
| `MaxVectorTBitWidth` | system default | Caps `Vector<T>` to a maximum width in bits; a value below 128 means the system default. |
| `PreferredVectorBitWidth` | system default | Caps the maximum fixed-width vector that reports `IsHardwareAccelerated`, in bits; a value below 128 means the system default. |

The system default for `MaxVectorTBitWidth` can be narrower than the hardware fully supports, so `Vector<T>` doesn't automatically grow to the widest available vector. For example, `Vector512<T>.IsHardwareAccelerated` can be `true` while `Vector<T>` stays 256-bit; set `DOTNET_MaxVectorTBitWidth=512` to opt `Vector<T>` into the wider width.

`PreferredVectorBitWidth` caps the maximum vector width that reports `IsHardwareAccelerated`. Lowering it below what the hardware supports flips the wider widths off: on a machine that supports 512-bit vectors, `DOTNET_PreferredVectorBitWidth=256` makes `Vector512<T>.IsHardwareAccelerated` report `false`. It's a general knob, but only x86/x64 offers widths above 128 today, so that's the only place it has an observable effect.

Each logical grouping of x86/x64 instruction sets also has its own switch:

| Knob (`DOTNET_` prefix) | Default | Gates |
| --- | --- | --- |
| `EnableAVX` | `1` | AVX and dependents |
| `EnableAVX2` | `1` | AVX2, BMI1, BMI2, F16C, FMA, LZCNT, MOVBE, and dependents |
| `EnableAVX512` | `1` | AVX-512 F+BW+CD+DQ+VL and dependents |
| `EnableAVX512BMM` | `1` | AVX-512 BMM |
| `EnableAVX512v2` | `1` | AVX-512 IFMA+VBMI |
| `EnableAVX512v3` | `1` | AVX-512 BITALG+VBMI2+VPOPCNTDQ+VNNI |
| `EnableAVX10v1` | `1` | AVX10.1 |
| `EnableAVX10v2` | `0` | AVX10.2 |
| `EnableAPX` | `0` | APX (extended general-purpose registers) |
| `EnableAES` | `1` | AES, PCLMULQDQ |
| `EnableAVX512VP2INTERSECT` | `1` | AVX-512 VP2INTERSECT |
| `EnableAVXIFMA` | `1` | AVX-IFMA |
| `EnableAVXVNNI` | `1` | AVX-VNNI |
| `EnableAVXVNNIINT` | `1` | VEX AVX-VNNI-INT8 and AVX-VNNI-INT16 |
| `EnableGFNI` | `1` | GFNI |
| `EnableSHA` | `1` | SHA |
| `EnableVAES` | `1` | VAES, VPCLMULQDQ |
| `EnableWAITPKG` | `1` | WAITPKG |
| `EnableX86Serialize` | `1` | X86 SERIALIZE |

On Arm64, each logical grouping of instruction sets has its own switch:

| Knob (`DOTNET_` prefix) | Default | Gates |
| --- | --- | --- |
| `EnableArm64Aes` | `1` | AES |
| `EnableArm64Atomics` | `1` | Large System Extensions (LSE) atomics |
| `EnableArm64Crc32` | `1` | CRC32 |
| `EnableArm64Dczva` | `1` | `DC ZVA` cache-zeroing |
| `EnableArm64Dp` | `1` | Dot Product |
| `EnableArm64Rdm` | `1` | Rounding Doubling Multiply Accumulate (RDM) |
| `EnableArm64Sha1` | `1` | SHA1 |
| `EnableArm64Sha256` | `1` | SHA256 |
| `EnableArm64Rcpc` | `1` | Release-Consistent, processor-consistent ordering (RCpc) |
| `EnableArm64Rcpc2` | `1` | RCpc2 |
| `EnableArm64Cssc` | `0` | Common Short Sequence Compression (CSSC) |
| `EnableArm64Sve` | `1` | Scalable Vector Extension (SVE) |
| `EnableArm64Sve2` | `1` | SVE2 |
| `EnableArm64Sha3` | `1` | SHA3 |
| `EnableArm64Sm4` | `1` | SM4 |
| `EnableArm64SveAes` | `1` | SVE AES |
| `EnableArm64SveSha3` | `1` | SVE SHA3 |
| `EnableArm64SveSm4` | `1` | SVE SM4 |

A knob defaulting to `0` (for example, `EnableAVX10v2` or `EnableArm64Cssc`) gates an instruction set that's still coming online, so it stays off until you opt in.

## Benchmark to confirm the win

Vectorization adds complexity, so measure that it pays off before you keep it. Use [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet), and use the same environment variables shown previously to compare the scalar, `Vector128`, and `Vector256` implementations in one run. BenchmarkDotNet's disassembly diagnoser can also emit the generated assembly, which is invaluable when tuning high-performance code.

A few things to keep in mind:

- **Larger inputs benefit more.** For small buffers, vectorized code can be slower than scalar code because of setup overhead. Benchmark the input sizes your callers actually use.
- **Speedups are rarely perfect.** A 256-bit vector operating on 32-bit elements won't reliably be 8x faster; memory throughput, alignment, and instruction latency all factor in.
- **Memory alignment affects stability.** Randomized allocation alignment adds noise between runs. You can allocate aligned memory with <xref:System.Runtime.InteropServices.NativeMemory.AlignedAlloc*> for stable results, or enable BenchmarkDotNet's memory randomization to observe the full distribution.

## Best practices

- Reach for the existing higher-level APIs first. `Span<T>`, `string`, LINQ, `TensorPrimitives`, and the tensor types already accelerate many common operations for you—don't hand-roll what's already optimized and tested.
- Start with `Vector128<T>`; it's accelerated on the broadest set of hardware, and you don't need `Vector256<T>` to get a correct, portable implementation. Add wider widths and hardware intrinsics only for measured hot paths.
- Check `IsHardwareAccelerated` and `Count` directly instead of caching them; the JIT turns them into constants.
- Always handle the loop remainder, and account for overlapping source and destination buffers when storing.
- Write edge-case tests first, then a scalar solution, then express that scalar logic with the vector APIs.
- Test every code path (including access violations) and benchmark realistic input sizes before you commit to the added complexity.

## See also

- <xref:System.Runtime.Intrinsics>
- <xref:System.Numerics.Tensors.TensorPrimitives>
