---
title: Unsafe code best practices - .NET
description: Learn the best practices for dealing with unsafe code in .NET, including common pitfalls and how to avoid them.
ms.date: 09/17/2025
---
# Unsafe code best practices

This article contains fine-grained recommendations for specific unsafe patterns, the risks
they entail, and how to mitigate those risks. These guidelines target all developers who are
writing or reviewing unsafe code in C#. Other
.NET languages such as F# and Visual Basic are outside of the scope of this article, although some recommendations
might be applicable to those languages as well.

## Glossary

* AVE - Access violation exception.
* Byref - A managed pointer (`ref T t`) that's similar to unmanaged pointer but tracked
by the GC. Typically points to arbitrary parts of objects or stack. Reference is effectively a managed pointer with +0 offset.
* CVE - [Publicly disclosed cybersecurity vulnerabilities](https://www.cve.org/).
* JIT - Just-in-time compiler (RyuJIT in CoreCLR and NativeAOT).
* PGO - Profile-guided optimization.
* Unmanaged pointer (or raw pointer) - A pointer (`T* p`) that points to arbitrary memory location and is not managed or tracked by the GC.

For other terms, see [.NET Runtime Glossary](https://github.com/dotnet/runtime/blob/main/docs/project/glossary.md).

## Common unreliable patterns

C# provides a safe environment where developers don't need to worry about the internal workings of the runtime and the GC. Unsafe code allows you to bypass these safety checks, potentially introducing unreliable patterns that can lead to memory corruption. While such patterns might be useful in certain scenarios, you should use them with caution and only when absolutely necessary. Not only do C# and .NET not provide tools to verify the soundness of unsafe code (as various C/C++ sanitizers might provide), GC-specific behaviors might introduce additional risks in unsafe C# beyond those that traditional C/C++ developers might be familiar with.

Unsafe code around managed references should be written with the following conservative assumptions in mind:

* The GC can interrupt the execution of any method at any point of time at any instruction.
* The GC can move objects in memory and update all *tracked* references.
* The GC knows precisely when references are no longer needed.

A classic example of heap corruption occurs when the GC loses track of an object reference or
treats invalid pointers as heap references. This often results in non-deterministic crashes
or memory corruption. Heap corruption bugs are particularly challenging to diagnose and reproduce because:

* These issues can remain hidden for a long time and only manifest after an unrelated code change or runtime update.
* They often require precise timing to reproduce, such as the GC interrupting execution at a specific location and starting heap compaction, which is a rare and nondeterministic event.

The next sections describe common unsafe patterns with ✔️ DO and ❌ DON'T recommendations.

## 1. Untracked managed pointers (`Unsafe.AsPointer` and friends)

It's not possible to convert a managed (tracked) pointer to an unmanaged (untracked)
pointer in safe C#. When such need arises, it might be tempting to use `Unsafe.AsPointer`
to avoid the overhead of a `fixed` statement. While there are valid
use cases for that, it introduces a risk of creating untracked pointers to moveable objects.
Example:

```csharp
unsafe void UnreliableCode(ref int x)
{
    int* nativePointer = (int*)Unsafe.AsPointer(ref x);
    nativePointer[0] = 42;
}
```

If the GC interrupts the execution of the `UnreliableCode` method right after the pointer has been read
(the address referenced by `x`) and relocates the referenced object, the GC will correctly update the
location stored in `x` but won't know anything about `nativePointer` and will not update the value
it contains. At that point, writing to `nativePointer` is writing to arbitrary memory.

```csharp
unsafe void UnreliableCode(ref int x)
{
    int* nativePointer = (int*)Unsafe.AsPointer(ref x);
    // <-- GC happens here between the two lines of code and updates `x` to point to a new location.
    // However, `nativePointer` still points to the old location as it's not reported to the GC
    
    nativePointer[0] = 42; // Potentially corrupting write, access violation, or other issue.
}
```

Once GC resumes the execution of the method, it will write 42 into the old location of `x`, which might lead
to an unexpected exception, general global state corruption, or process termination via an access violation.

The recommended solution is instead to use the `fixed` keyword and `&` address-of operator to ensure that the
GC cannot relocate the target reference for the duration of the operation.

```csharp
unsafe void ReliableCode(ref int x)
{
    fixed (int* nativePointer = &x) // `x` cannot be relocated for the duration of this block.
    {
        nativePointer[0] = 42;
    }
}
```

### Recommendations

1. ❌ DON'T use `ref X` arguments with an implicit contract that `X` is always stack-allocated, pinned, or otherwise not relocatable by the GC. Consider instead taking a [ref struct](../../csharp/language-reference/builtin-types/ref-struct.md) argument or changing the argument to be a raw pointer type (`X*`).
2. ❌ DON'T use a pointer from `Unsafe.AsPointer` if it can outlive the original object it is pointing to. [Per the API's documentation](xref:System.Runtime.CompilerServices.Unsafe.AsPointer``1(``0@)), it's up to the caller of `Unsafe.AsPointer` to guarantee that the GC cannot relocate the reference. Ensure it's clearly visible to code reviewers that the caller has fulfilled this prerequisite.
3. ✔️ DO use `GCHandle` or `fixed` scopes instead of `Unsafe.AsPointer` to define explicit scopes for unmanaged pointers and to ensure that the object is always pinned.
4. ✔️ DO use unmanaged pointers (with `fixed`) instead of byrefs when you need to align an array to a specific boundary. This ensures the GC won't relocate the object and invalidate any alignment assumptions your logic might rely upon.

## 2. Exposing pointers outside of the `fixed` scope

While the [fixed](../../csharp/language-reference/statements/fixed.md)
keyword defines a scope for the pointer obtained from the pinned object, it's still possible for that pointer
to escape the `fixed` scope and introduce bugs, as C# doesn't provide any ownership/lifecycle protections for it.
A typical example is the following snippet:

```csharp
unsafe int* GetPointerToArray(int[] array)
{
    fixed (int* pArray = array)
    {
        _ptrField = pArray; // Bug!

        Method(pArray);     // Bug if `Method` allows `pArray` to escape, perhaps by assigning it to a field.

        return pArray;      // Bug!

        // And other ways to escape the scope.
    }
}
```

In this example, the array is pinned properly using the `fixed` keyword (ensuring the GC can't relocate it within the `fixed` block),
but then the pointer is exposed outside of the `fixed` block. This creates a dangling pointer whose dereference will result in undefined behavior.

### Recommendations

1. ✔️ DO make sure that pointers in `fixed` blocks do not leave the defined scope.
2. ✔️ DO prefer safe low-level primitives with built-in escape analysis, such as C#'s [ref struct](../../csharp/language-reference/builtin-types/ref-struct.md). For more information, see [Low-level struct improvements](~/_csharplang/proposals/csharp-11.0/low-level-struct-improvements.md).

## 3. Internal implementation details of the runtime and libraries

While accessing or relying on internal implementation details is bad practice in general (and not supported by .NET), it's worth calling out specific commonly observed cases. This is not intended to be an exhaustive list of all possible things that could go wrong when code inappropriately relies on an internal implementation detail.

### Recommendations

1. ❌ DON'T alter or read any parts of an object's header.
   * Object headers might differ across runtimes.
   * In CoreCLR, the object header cannot be accessed safely without pinning the object first.
   * Never change object's type by modifying the MethodTable pointer.
2. ❌ DON'T store any data in an object's padding. Don't assume padding contents will be preserved or that padding is always zeroed by default.
3. ❌ DON'T make assumptions about the sizes and offsets of anything other than primitives and structs with sequential or explicit layout. Even then, exceptions exist, such as when GC handles are involved.
4. ❌ DON'T invoke nonpublic methods, access nonpublic fields, or mutate readonly fields in BCL types with reflection or unsafe code.
5. ❌ DON'T assume any given nonpublic member in the BCL will always be present or will have a specific shape. The .NET team does occasionally modify or remove nonpublic APIs in servicing releases.
6. ❌ DON'T change `static readonly` fields using reflection or unsafe code, as they're assumed to be constant. For example, RyuJIT usually inlines them as explicit constants.
7. ❌ DON'T simply assume that a reference is non-relocatable. This guidance applies to string and UTF-8 (`"..."u8`) literals, static fields, RVA fields, LOH objects, and so on.
   * These are runtime implementation details that might hold for some runtimes but not for others.
   * Unmanaged pointers to such objects might not stop assemblies from being unloaded, causing the pointers to become dangling. Use `fixed` scopes to ensure correctness.
8. ❌ DON'T write code that relies on the implementation details of a specific runtime.

## 4. Invalid managed pointers (even if they are never dereferenced)

Certain categories of code end up leaning on pointer manipulation and arithmetic, and such code
often has a choice between using unmanaged pointers (`T* p`) and managed pointers (`ref T p`).
These pointers can be manipulated arbitrarily, for instance, via operators on unmanaged pointers (`p++`) and
via `Unsafe` methods on managed pointers (`p = ref Unsafe.Add(ref p, 1)`). Both are considered "unsafe code"
and it's possible to create unreliable patterns with both. However, for certain algorithms, it can be easier to
accidentally create GC-unsafe patterns when manipulating managed pointers. Since unmanaged pointers aren't tracked
by the GC, the value they contain is only relevant when dereferenced by the developer's code. In contrast,
a managed pointer's value is relevant not only when it's dereferenced by the developer's code, but also
when it's examined by the GC. Thus, a developer can create invalid unmanaged pointers without consequence
as long as they're not dereferenced, but creating any invalid managed pointer is a bug. Example:

```csharp
unsafe void UnmanagedPointers(int[] array)
{
    fixed (int* p = array)
    {
        int* invalidPtr = p - 1000;
        // invalidPtr is pointing to an undefined location in memory
        // it's ok as long as it's not dereferenced.

        int* validPtr = invalidPtr + 1000; // Returning back to the original location
        *validPtr = 42; // OK
    }
}
```

However, similar code using byrefs (managed pointers) is invalid.

```csharp
void ManagedPointers_Incorrect(int[] array)
{
    ref int invalidPtr = ref Unsafe.Add(ref array[0], -1000); // Already a bug!
    ref int validPtr = ref Unsafe.Add(ref invalidPtr, 1000);
    validPtr = 42; // possibly corrupting write
}
```

While the managed implementation here avoids the minor pinning overhead, it is unsound because
`invalidPtr` *might* become an exterior pointer while the actual address of `array[0]` is being updated by GC.
Such bugs are subtle, and [even .NET has run afoul of them](https://github.com/dotnet/runtime/issues/75792#issuecomment-1251523057) during development.

### Recommendations

1. ❌ DON'T create invalid managed pointers, even if they are not dereferenced or they are located inside never-executed code paths.
   * For more information on what constitutes a valid managed pointer, see [ECMA-335](#references), Sec. II.14.4.2 Managed pointers; and [ECMA-335 CLI Specification Addendum](#references), Sec. II.14.4.2.
2. ✔️ DO use pinned unmanaged pointers if the algorithm requires such manipulations.

## 5. Reinterpret-like type casts

While all kinds of struct-to-class or class-to-struct casts are an undefined behavior by definition,
it's also possible to encounter unreliable patterns with struct-to-struct or class-to-class conversions.
A typical example of an unreliable pattern is the following code:

```csharp
struct S1
{
    string a;
    nint b;
}

struct S2
{
    string a;
    string b;
}

S1 s1 = ...
S2 s2 = Unsafe.As<S1, S2>(ref s1); // Bug! A random nint value becomes a reference reported to the GC.
```

And even if the layout is similar, you should still be careful when GC references (fields) are involved.

### Recommendations

1. ❌ DON'T cast structs to classes or vice versa.
2. ❌ DON'T use `Unsafe.As` for struct-to-struct or class-to-class conversions unless you're absolutely sure that the cast is legal.
   * For more information, see the _Remarks_ section of the [`Unsafe.As` API docs](xref:System.Runtime.CompilerServices.Unsafe.As``2(``0@)).
3. ✔️ DO prefer safer field-by-field copying, external libraries such as [AutoMapper](https://github.com/AutoMapper/AutoMapper), or Source Generators for such conversions.
4. ✔️ DO prefer `Unsafe.BitCast` over `Unsafe.As`, as `BitCast` provides some rudimentary usage checks. Note that these checks do not provide full correctness guarantees, meaning `BitCast` is still considered an unsafe API.

## 6. Bypassing the Write Barrier and non-atomic operations on GC references

Normally, all kind of writes or reads of GC references are always atomic. Also, all attempts
to assign a GC reference (or a byref to struct with GC fields) to a potential heap location
go through the Write Barrier that ensures that the GC is aware of new connections between objects.
However, unsafe code allows us to bypass these guarantees and introduce unreliable patterns. Example:

```csharp
unsafe void InvalidCode1(object[] arr1, object[] arr2)
{
    fixed (object* p1 = arr1)
    fixed (object* p2 = arr2)
    {
        nint* ptr1 = (nint*)p1;
        nint* ptr2 = (nint*)p2;

        // Bug! We're assigning a GC pointer to a heap location
        // without going through the Write Barrier.
        // Moreover, we also bypass array covariance checks.
        *ptr1 = *ptr2;
    }
}
```

Similarly, the following code with managed pointers is also unreliable:

```csharp
struct StructWithGcFields
{
    object a;
    int b;
}

void InvalidCode2(ref StructWithGcFields dst, ref StructWithGcFields src)
{
    // It's already a bad idea to cast a struct with GC fields to `ref byte`, etc.
    ref byte dstBytes = ref Unsafe.As<StructWithGcFields, byte>(ref dst);
    ref byte srcBytes = ref Unsafe.As<StructWithGcFields, byte>(ref src);

    // Bug! Bypasses the Write Barrier. Also, non-atomic writes/reads for GC references.
    Unsafe.CopyBlockUnaligned(
        ref dstBytes, ref srcBytes, (uint)Unsafe.SizeOf<StructWithGcFields>());

    // Bug! Same as above.
    Vector128.LoadUnsafe(ref srcBytes).StoreUnsafe(ref dstBytes);
}
```

### Recommendations

1. ❌ DON'T use non-atomic operations on GC references (for example, SIMD operations often don't provide them).
2. ❌ DON'T use unmanaged pointers to store GC references into heap locations (omitting the Write Barrier).

## 7. Assumptions about object lifetimes (finalizers, `GC.KeepAlive`)

Avoid making assumptions about the lifetime of objects from the GC's perspective.
Specifically, do not assume that an object is still alive when it might not be. Object lifetimes can vary
across different runtimes or even between different Tiers of the same method (Tier0 and Tier1 in RyuJIT).
Finalizers are a common scenario where such assumptions can be incorrect.

```csharp
public class MyClassWithBadCode
{
    public IntPtr _handle;

    public void DoWork() => DoSomeWork(_handle); // A use-after-free bug!

    ~MyClassWithBadCode() => DestroyHandle(_handle);
}

// Example usage:
var obj = new MyClassWithBadCode()
obj.DoWork();
```

In this example, `DestroyHandle` might be called before `DoWork` completes or even before it begins.
Therefore, it's crucial not to assume that objects, such as `this`, will remain alive until the end of the method.

```csharp
void DoWork()
{
    // A pseudo-code of what might happen under the hood:

    IntPtr reg = this._handle;
    // 'this' object is no longer alive at this point.

    // <-- GC interrupts here, collects the 'this' object, and triggers its finalizer.
    // DestroyHandle(_handle) is called.

    // Bug! 'reg' is now a dangling pointer.
    DoSomeWork(reg);

    // You can resolve the issue and force 'this' to be kept alive (thus ensuring the
    // finalizer will not run) by uncommenting the line below:
    // GC.KeepAlive(this);
}
```

Therefore, it is recommended to explicitly extend the lifetime of objects using <xref:System.GC.KeepAlive(System.Object)?displayProperty=nameWithType>
or <xref:System.Runtime.InteropServices.SafeHandle>.

### Recommendations

1. ❌ DON'T make assumptions about object lifetimes. For instance, never assume `this` is always alive through the end of the method.
2. ✔️ DO use <xref:System.Runtime.InteropServices.SafeHandle> for managing native resources.
3. ✔️ DO use <xref:System.GC.KeepAlive(System.Object)?displayProperty=nameWithType> to extend the lifetime of objects when necessary.

## 8. Cross-thread access to local variables

Accessing local variables from a different thread is generally considered bad practice. However, it becomes explicitly undefined behavior when managed references are involved, as outlined in the [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md#cross-thread-access-to-local-variables).

Example: A struct containing GC references might be zeroed or overwritten in a non-thread-safe manner within a no-GC region while another thread is reading it, leading to undefined behavior.

### Recommendations

1. ❌ DON'T access locals across threads (especially if they contain GC references).
2. ✔️ DO use heap or unmanaged memory (for example, `NativeMemory.Alloc`) instead.

## 9. Unsafe bounds check removal

In C#, all idiomatic memory accesses include bounds checks by default.
The JIT compiler can remove these checks if it can prove that they are unnecessary, as in the example below.

```csharp
int SumAllElements(int[] array)
{
    int sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        // The JIT knows that within this loop body, i >= 0 and i < array.Length.
        // The JIT can reason that its own bounds check would be duplicative and
        // unnecessary, so it opts not to emit the bounds check into the final
        // generated code.
        sum += array[i];
    }
}
```

While the JIT is continually improving at recognizing such patterns, there are still scenarios where it leaves the checks in place,
potentially impacting performance in hot code. In such cases, you might be tempted to
use unsafe code to manually remove these checks without fully understanding the risks or
accurately assessing the performance benefits.

Consider for example the following method.

```csharp
int FetchAnElement(int[] array, int index)
{
    return array[index];
}
```

If the JIT cannot prove that `index` is always legally within the bounds of `array`, it will rewrite the method to look something like the below.

```csharp
int FetchAnElement_AsJitted(int[] array, int index)
{
    if (index < 0 || index >= array.Length)
        throw new IndexOutOfBoundsException();
    return array.GetElementAt(index);
}
```

To reduce the overhead from that check in hot code, you might be tempted to use unsafe-equivalent APIs (`Unsafe` and `MemoryMarshal`):

```csharp
int FetchAnElement_Unsafe1(int[] array, int index)
{
    // DANGER: The access below is not bounds-checked and could cause an access violation.
    return Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), index);
}
```

Or use pinning and raw pointers:

```csharp
unsafe int FetchAnElement_Unsafe2(int[] array, int index)
{
    fixed (int* pArray = array)
    {
        // DANGER: The access below is not bounds-checked and could cause an access violation.
        return pArray[index];
    }
}
```

This can lead to random crashes or state corruption if `index` is outside the bounds of `array`.
Such unsafe transformations can have performance benefits on very hot paths, but these benefits are
often transient, as each .NET release improves the JIT's ability to eliminate unnecessary
bounds checks when it is safe to do so.

### Recommendations

1. ✔️ DO verify whether the latest version of .NET still can't eliminate the bounds check. If it can, rewrite using safe code. Otherwise, file an issue against the RyuJIT. Use [this tracking issue](https://github.com/dotnet/runtime/issues/109677) as a good starting point.
2. ✔️ DO measure the real-world performance impact. If the performance gain is negligible or the code isn't proven to be hot outside of a trivial microbenchmark, rewrite using safe code.
3. ✔️ DO provide additional hints to the JIT, such as manual bounds checks before loops and saving fields to locals, as [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md) might conservatively prevent the JIT from removing bounds checks in some scenarios.
4. ✔️ DO guard code with `Debug.Assert` bounds checks if unsafe code is still necessary. Consider the example below.

```csharp
Debug.Assert(array is not null);
Debug.Assert((index >= 0) && (index < array.Length));
// Unsafe code here
```

You might even refactor these checks into reusable helper methods.

```csharp
[MethodImpl(MethodImplOptions.AggressiveInlining)]
static T UnsafeGetElementAt<T>(this T[] array, int index)
{
    Debug.Assert(array is not null);
    Debug.Assert((index >= 0) && (index < array.Length));
    return Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(array), index);
}
```

Inclusion of `Debug.Assert` doesn't provide any soundness checks for Release builds, but it might help detect potential bugs in Debug builds.

## 10. Memory access coalescing

You might be tempted to use unsafe code to coalesce memory accesses to improve performance.
A classic example is the following code to write `"False"` into a char array:

```csharp
// Naive implementation
static void WriteToDestination_Safe(char[] dst)
{
    if (dst.Length < 5) { throw new ArgumentException(); }
    dst[0] = 'F';
    dst[1] = 'a';
    dst[2] = 'l';
    dst[3] = 's';
    dst[4] = 'e';
}

// Unsafe coalesced implementation
static void WriteToDestination_Unsafe(char[] destination)
{
    Span<char> dstSpan = destination;
    if (dstSpan.Length < 5) { throw new ArgumentException(); }
    ulong fals_val = BitConverter.IsLittleEndian ? 0x0073006C00610046ul : 0x00460061006C0073ul;
    MemoryMarshal.Write(MemoryMarshal.AsBytes(dstSpan.Slice(0, 4)), in fals_val); // Write "Fals" (4 chars)
    dstSpan[4] = 'e';                                                             // Write "e" (1 char)
}
```

In previous versions of .NET, the unsafe version using `MemoryMarshal` was measurably faster than
the straightforward safe version. However, modern versions of .NET contain a much improved JIT
that produces equivalent codegen for both cases. As of .NET 10, the x64 codegen is:

```asm
; WriteToDestination_Safe
cmp      eax, 5
jl       THROW_NEW_ARGUMENTEXCEPTION
mov      rax, 0x73006C00610046
mov      qword ptr [rdi+0x10], rax
mov      word  ptr [rdi+0x18], 101

; WriteToDestination_Unsafe
cmp      edi, 5
jl       THROW_NEW_ARGUMENTEXCEPTION
mov      rdi, 0x73006C00610046
mov      qword ptr [rax], rdi
mov      word  ptr [rax+0x08], 101
```

There is an even simpler and more readable version of the code:

```csharp
"False".CopyTo(dst);
```

As of .NET 10, this call produces identical codegen as above. It even has an additional benefit: it hints to the JIT that
strict per-element writes are not required to be atomic. The JIT might combine this hint with other contextual knowledge
to provide even more optimizations beyond what was discussed here.

### Recommendations

1. ✔️ DO prefer idiomatic safe code instead of unsafe for memory access coalescing:
    * Prefer `Span<T>.CopyTo` and `Span<T>.TryCopyTo` for copying data.
    * Prefer `String.Equals` and `Span<T>.SequenceEqual` for comparing data (even when using `StringComparer.OrdinalIgnoreCase`).
    * Prefer `Span<T>.Fill` for filling data and `Span<T>.Clear` for clearing data.
    * Be aware that per-element or per-fields writes/reads might be coalesced by JIT automatically.
2. ✔️ DO file an issue against [dotnet/runtime](https://github.com/dotnet/runtime) if you write idiomatic code and observe that it is not optimized as expected.
3. ❌ DON'T coalesce memory accesses manually if you're not sure about misaligned memory access risks, atomicity guarantees, or the associated performance benefits.

## 11. Unaligned memory access

The memory access coalescing described in [Memory access coalescing](#10-memory-access-coalescing) often results in explicit
or implicit misaligned reads/writes. While this usually doesn't cause serious issues (aside from
potential performance penalties due to crossing cache and page boundaries), it still poses some real risks.

For example, consider the scenario where you're clearing two elements of an array at once:

```csharp
uint[] arr = _arr;
arr[i + 0] = 0;
arr[i + 1] = 0;
```

Let's say the previous values at these locations were both `uint.MaxValue` (`0xFFFFFFFF`).
The [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md) guarantees that both writes are atomic, so all other threads in the process will only ever
observe the new value `0` or the old value `0xFFFFFFFF`, never "torn" values like `0xFFFF0000`.

However, assume the following unsafe code is used to bypass the bounds check and zero both elements with a single 64-bit store:

```csharp
ref uint p = ref Unsafe.Add(ref MemoryMarshal.GetArrayDataReference(arr), i);
Unsafe.WriteUnaligned<ulong>(ref Unsafe.As<uint, byte>(ref p), 0UL);
```

This code has the side effect of removing the
atomicity guarantee. Torn values might be observed by other threads, leading to undefined behavior.
For such a coalesced write to be atomic, the memory must be aligned to the size of the write (8 bytes in this case).
If you attempt to manually align the memory prior to the operation, you must consider that the GC can relocate
(and, effectively, change the alignment of) the array at any time if it's not pinned.
See the [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md) documentation for more details.

Another risk of unaligned memory access is the potential for an application crash in certain scenarios.
While some .NET runtimes rely on the OS to fixup misaligned accesses, there are still some scenarios on some
platforms where misaligned access can lead to an `DataMisalignedException` (or `SEHException`).
Some of the examples include:

* `Interlocked` operations on misaligned memory on some platforms ([example](https://github.com/dotnet/runtime/issues/91662)).
* Misaligned floating point operations on ARM.
* Accessing special device memory with certain alignment requirements (not really supported by .NET).

### Recommendations

1. ❌ DON'T use unaligned memory accesses in lock-free algorithms and other scenarios where atomicity is important.
2. ✔️ DO align data manually if necessary, but keep in mind that the GC can relocate objects
at any time, effectively changing the alignment dynamically. This is especially important for various
`StoreAligned`/`LoadAligned` APIs in SIMD.
3. ✔️ DO use explicit unaligned Read/Write APIs such as `Unsafe.ReadUnaligned`/`Unsafe.WriteUnaligned`
instead of aligned ones such as `Unsafe.Read`/`Unsafe.Write` or `Unsafe.As` if data might be misaligned.
4. ✔️ DO keep in mind that various memory manipulation APIs such as `Span<T>.CopyTo` also don't provide atomicity guarantees.
5. ✔️ DO consult with the [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md) documentation ([see references](#references)) for more details on atomicity guarantees.
6. ✔️ DO measure performance across all your target platforms, as some platforms impose a significant performance penalty for unaligned memory accesses. You may find that on these platforms, naive code performs better than clever code.
7. ✔️ DO keep in mind that there are scenarios and platforms where unaligned memory access might lead to an exception.

## 12. Binary (de)serialization of structs with paddings or non-blittable members

Be cautious when you use various serialization-like APIs to copy or read structs to or from byte arrays.
If a struct contains paddings or non-blittable members (for example, `bool` or GC fields), then classic unsafe memory operations such as `Fill`, `CopyTo`, and `SequenceEqual` might accidentally copy sensitive data from the stack to the paddings or treat garbage data as significant during comparisons creating rarely reproducible bugs. A common anti-pattern might look like this:

```csharp
T UnreliableDeserialization<TObject>(ReadOnlySpan<byte> data) where TObject : unmanaged
{
    return MemoryMarshal.Read<TObject>(data); // or Unsafe.ReadUnaligned
    // BUG! TObject : unmanaged doesn't guarantee that TObject is blittable and contains no paddings.
}
```

The only correct approach is to use field-by-field loads/store specialized for each `TObject` input (or generalized with Reflection, Source Generators, or (de)serialization libraries).

### Recommendations

1. ❌ DON'T use unsafe code to copy/load/compare structs with paddings or non-blittable members. Loads from untrusted inputs are problematic even for basic types like `bool` or `decimal`. At the same time, stores might accidentally serialize sensitive information from the stack in a struct's gaps/paddings.
2. ❌ DON'T rely on `T : unmanaged` constraint, `RuntimeHelpers.IsReferenceOrContainsReferences`, or similar APIs to guarantee that a generic type is safe to perform bitwise operations on. At the time of writing these guidelines, there is no reliable programmatic way to determine whether it is legal to perform arbitrary bitwise operations on a given type.
   * If you must perform such bitwise manipulation, only do it against this hardcoded list of types, and be aware of the current machine's endianness:
      * The primitive integral types `Byte`, `SByte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, and `UInt64`;
      * An `Enum` backed by one of the above primitive integral types;
      * `Char`, `Int128`, `UInt128`, `Half`, `Single`, `Double`, `IntPtr`, `UIntPtr`.
3. ✔️ DO use field-by-field loads/store (de)serialization instead. Consider using popular and safe libraries for (de)serialization.

## 13. Null managed pointers

Generally, byrefs (managed pointers) are rarely null and the only safe way to create a null byref as of today is
to initialize a `ref struct` with `default`. Then all its `ref` fields are null managed pointers:

```csharp
RefStructWithRefField s = default;
ref byte nullRef = ref s.refFld;
```

However, there are several unsafe ways to create null byrefs. Some examples include:

```csharp
// Null byref by calling Unsafe.NullRef directly:
ref object obj = ref Unsafe.NullRef<object>();

// Null byref by turning a null unmanaged pointer into a null managed pointer:
ref object obj = ref Unsafe.AsRef<object>((void*)0);
```

The risk of introducing memory safety issues is low, and any attempt to dereference
a null byref will lead to a well-defined `NullReferenceException`.
However, the C# compiler [assumes](https://github.com/dotnet/roslyn/issues/72165) that dereferencing a byref always succeeds
and produces no observable side effect. Therefore it is a legal optimization to elide any dereference whose resulting value is
immediately thrown away. See [dotnet/runtime#98681](https://github.com/dotnet/runtime/pull/98681) (and
[this related comment](https://github.com/dotnet/runtime/pull/98623#discussion_r1493490532)) for an example of a now-fixed bug within .NET
where library code improperly relied on the dereference triggering a side effect, unaware that the C# compiler effectively short-circuited
the intended logic.

### Recommendations

1. ❌ DON'T create null byrefs in C# if it's not necessary. Consider using normal managed references, the
[Null Object Pattern](https://en.wikipedia.org/wiki/Null_object_pattern), or empty spans instead.
2. ❌ DON'T discard the result of a byref dereference, as it might be optimized out and lead to potential bugs.

## 14. `stackalloc`

`stackalloc` has historically been used to create small, non-escaping arrays on the stack, reducing GC pressure. In the future, JIT's Escape Analysis might start optimizing non-escaping GC allocations of arrays to stack objects, potentially making `stackalloc` redundant. Until then, `stackalloc` remains useful for allocating small buffers on the stack. For larger or escaping buffers, it is often combined with `ArrayPool<T>`.

### Recommendations

1. ✔️ DO always consume `stackalloc` into `ReadOnlySpan<T>`/`Span<T>` on the left side of the expression to provide bounds checks:

    ```csharp
    // Good:
    Span<int> s = stackalloc int[10];
    s[2] = 0;  // Bounds check is eliminated by JIT for this write.
    s[42] = 0; // IndexOutOfRangeException is thrown

    // Bad:
    int* s = stackalloc int[10];
    s[2] = 0;
    s[42] = 0; // Out of bounds write, undefined behavior.
    ```

2. ❌ DON'T use `stackalloc` inside loops. The stack space isn't reclaimed until the method returns, so including a `stackalloc` inside a loop could result in process termination due to stack overflow.
3. ❌ DON'T use large lengths for `stackalloc`. For example, 1024 bytes could be considered a reasonable upper bound.
4. ✔️ DO check the range of variables used as `stackalloc` lengths.

    ```csharp
    void ProblematicCode(int length)
    {
        Span<int> s = stackalloc int[length]; // Bad practice: check the range of `length`!
        Consume(s);
    }
    ```

    Fixed version:

    ```csharp
    void BetterCode(int length)
    {
        // The "throw if length < 0" check below is important, as attempting to stackalloc a negative
        // length will result in process termination.
        ArgumentOutOfRangeException.ThrowIfLessThan(length, 0, nameof(length));
        Span<int> s = length <= 512 ? stackalloc int[length] : new int[length];
        // Or:
        // Span<int> s = length <= 512 ? stackalloc int[512] : new int[length];
        // Which performs a faster zeroing of the stackalloc, but potentially consumes more stack space.
        Consume(s);
    }
    ```

5. ✔️ DO use modern C# features such as collection literals (`Span<int> s = [1, 2, 3];`), `params Span<T>`, and inline arrays to avoid manual memory management when possible.

## 15. Fixed-size buffers

Fixed-size buffers were useful for interop scenarios with data sources from other languages or platforms. They then were replaced by safer and more convenient [inline arrays](~/_csharplang/proposals/csharp-12.0/inline-arrays.md).
An example of a fixed-size buffer (requires `unsafe` context) is the following snippet:

```csharp
public struct MyStruct
{
    public unsafe fixed byte data[8];
    // Some other fields
}

MyStruct m = new();
ms.data[10] = 0; // Out-of-bounds write, undefined behavior.
```

A modern and a safer alternative is [inline arrays](~/_csharplang/proposals/csharp-12.0/inline-arrays.md):

```csharp
[System.Runtime.CompilerServices.InlineArray(8)]
public struct Buffer
{
    private int _element0; // can be generic
}

public struct MyStruct
{
    public Buffer buffer;
    // Some other fields
}

MyStruct ms = new();
ms.buffer[i] = 0; // Runtime performs a bounds check on index 'i'; could throw IndexOutOfRangeException.
ms.buffer[7] = 0; // Bounds check elided; index is known to be in range.
ms.buffer[10] = 0; // Compiler knows this is out of range and produces compiler error CS9166.
```

### Recommendations

1. ✔️ DO prefer replacing fixed-size buffers with inline arrays or IL marshalling attributes where possible.

## 16. Passing contiguous data as pointers + lengths (or relying on zero-termination)

Avoid defining APIs that accept unmanaged or managed pointers to contiguous data. Instead, use `Span<T>` or `ReadOnlySpan<T>`:

```csharp
// Poor API designs:
void Consume(ref byte data, int length);
void Consume(byte* data, int length);
void Consume(byte* data); // zero-terminated
void Consume(ref byte data); // zero-terminated

// Better API designs:
void Consume(Span<byte> data);
void Consume(Memory<byte> data);
void Consume(byte[] data);
void Consume(byte[] data, int offset, int length);
```

Zero-termination is particularly risky because not all buffers are zero-terminated, and reading past any zero-terminator
can lead to information disclosure, data corruption, or process termination via an access violation.

### Recommendations

1. ❌ DON'T expose methods whose arguments are pointer types (unmanaged pointers `T*` or managed pointers `ref T`) when those arguments are intended to represent buffers. Use safe buffer types like `Span<T>` or `ReadOnlySpan<T>` instead.
2. ❌ DON'T use implicit contracts for byref arguments, such as requiring all callers to allocate the input on the stack. If such a contract is necessary, consider using [ref struct](../../csharp/language-reference/builtin-types/ref-struct.md) instead.
3. ❌ DON'T assume buffers are zero-terminated unless the scenario explicitly documents that this is a valid assumption. For example, even though .NET guarantees that `string` instances are null-terminated, the same does not hold of other buffer types like `ReadOnlySpan<char>` or `char[]`.

    ```csharp
    unsafe void NullTerminationExamples(string str, ReadOnlySpan<char> span, char[] array)
    {
        Debug.Assert(str is not null);
        Debug.Assert(array is not null);

        fixed (char* pStr = str)
        {
            // OK: Strings are always guaranteed to have a null terminator.
            // This will assign the value '\0' to the variable 'ch'.
            char ch = pStr[str.Length];
        }

        fixed (char* pSpan = span)
        {
            // INCORRECT: Spans aren't guaranteed to be null-terminated.
            // This could throw, assign garbage data to 'ch', or cause an AV and crash.
            char ch = pSpan[span.Length];
        }
        
        fixed (char* pArray = array)
        {
            // INCORRECT: Arrays aren't guaranteed to be null-terminated.
            // This could throw, assign garbage data to 'ch', or cause an AV and crash.
            char ch = pArray[array.Length];
        }
    }
    ```

4. ❌ DON'T pass a pinned `Span<char>` or `ReadOnlySpan<char>` across a p/invoke boundary unless you have also passed an explicit length argument. Otherwise, the code on the other side of the p/invoke boundary might improperly believe the buffer is null-terminated.

```csharp
unsafe static extern void SomePInvokeMethod(char* pwszData);

unsafe void IncorrectPInvokeExample(ReadOnlySpan<char> data)
{
    fixed (char* pData = data)
    {
        // INCORRECT: Since 'data' is a span and is not guaranteed to be null-terminated,
        // the receiver might attempt to keep reading beyond the end of the buffer,
        // resulting in undefined behavior.
        SomePInvokeMethod(pData);
    }
}
```

To resolve this, use an alternative p/invoke signature that accepts _both_ the data pointer _and_ the length if possible. Otherwise, if the receiver has no way of accepting a separate length argument, ensure the original data is converted to a `string` before pinning it and passing it across the p/invoke boundary.

```csharp
unsafe static extern void SomePInvokeMethod(char* pwszData);
unsafe static extern void SomePInvokeMethodWhichTakesLength(char* pwszData, uint cchData);

unsafe void CorrectPInvokeExample(ReadOnlySpan<char> data)
{
    fixed (char* pData = data)
    {
        // OK: Since the receiver accepts an explicit length argument, they're signaling
        // to us that they don't expect the pointer to point to a null-terminated buffer.
        SomePInvokeMethodWhichTakesLength(pData, (uint)data.Length);
    }
    
    // Alternatively, if the receiver doesn't accept an explicit length argument, use
    // ReadOnlySpan<T>.ToString to convert the data to a null-terminated string before
    // pinning it and sending it across the p/invoke boundary.
    
    fixed (char* pStr = data.ToString())
    {
        // OK: Strings are guaranteed to be null-terminated.
        SomePInvokeMethod(pStr);
    }
}
```

## 17. String mutations

Strings in C# are immutable by design, and any attempt to mutate them using unsafe code can lead to undefined behavior. Example:

```csharp
string s = "Hello";
fixed (char* p = s)
{
    p[0] = '_';
}
Console.WriteLine("Hello"); // prints "_ello" instead of "Hello"
```

Modifying an interned string (*most* string literals are) will change the value for all other uses. Even without string interning, writing into a newly created string should be replaced with the safer `String.Create` API:

```csharp
// Bad:
string s = new string('\n', 4); // non-interned string
fixed (char* p = s)
{
    // Copy data into the newly created string
}

// Good:
string s = string.Create(4, state, (chr, state) =>
{
    // Copy data into the newly created string
});
```

### Recommendations

1. ❌ DON'T mutate strings. Use the `String.Create` API to create a new string if complex copying logic is needed. Otherwise, use `.ToString()`, `StringBuilder`, `new string(...)`, or string interpolation syntax.

## 18. Raw IL code (for example, System.Reflection.Emit and Mono.Cecil)

Emitting raw IL (either via `System.Reflection.Emit`, third-party libraries such as `Mono.Cecil`,
or writing IL code directly) by definition bypasses all memory safety guarantees C# provides.
Avoid using such techniques unless absolutely necessary.

### Recommendations

1. ❌ DON'T emit raw IL code as it comes with no guiderails and it makes it easy to introduce type safety and other issues.
     * Like other dynamic code generation techniques, emitting raw IL is also not AOT-friendly if it's not done at the build time.
2. ✔️ DO use Source Generators instead, if possible.
3. ✔️ DO prefer [\[UnsafeAccessor\]](xref:System.Runtime.CompilerServices.UnsafeAccessorAttribute) instead of emitting raw IL for writing low overhead serialization code for private members if the need arises.
4. ✔️ DO file an API proposal against [dotnet/runtime](https://github.com/dotnet/runtime) if some API is missing and you're forced to use raw IL code instead.

## 19. Uninitialized locals `[SkipLocalsInit]` and `Unsafe.SkipInit`

`[SkipLocalsInit]` was introduced in .NET 5.0 to allow the JIT to skip zeroing local variables in methods, either on a per-method basis or module-wide. This feature was often used to help the JIT eliminate redundant zero initializations, such as those for `stackalloc`. However, it can lead to undefined behavior if locals are not explicitly initialized before use. With recent improvements in the JIT's ability to eliminate zero-initializations and perform vectorization, the need for `[SkipLocalsInit]` and `Unsafe.SkipInit` has significantly decreased.

### Recommendations

1. ❌ DON'T use `[SkipLocalsInit]` and `Unsafe.SkipInit` if no performance benefits in hot code are observed or you're not sure about the risks they introduce.
2. ✔️ DO code defensively when using APIs like `GC.AllocateUninitializedArray` and `ArrayPool<T>.Shared.Rent`, which can similarly return uninitialized buffers.

## 20. `ArrayPool<T>.Shared` and similar pooling APIs

`ArrayPool<T>.Shared` is a shared pool of arrays used to reduce GC pressure in hot code. It's often utilized for
allocating temporary buffers for I/O operations or other short-lived scenarios. While the API is straightforward
and doesn't inherently contain unsafe features, it can lead to use-after-free bugs in C#. Example:

```csharp
var buffer = ArrayPool<byte>.Shared.Rent(1024);
_buffer = buffer; // buffer object escapes the scope
Use(buffer);
ArrayPool<byte>.Shared.Return(buffer);
```

Any use of `_buffer` after the `Return` call is a use-after-free bug. This minimal example is easy to spot,
but the bug becomes harder to detect when `Rent` and `Return` are in different scopes or methods.

### Recommendations

1. ✔️ DO keep matched calls to `Rent` and `Return` within the same method if possible to narrow the scope of potential bugs.
2. ❌ DON'T use a `try-finally` pattern in order to call `Return` in the `finally` block unless you are confident the failed logic has finished using the buffer. It's better to abandon the buffer rather than risk a use-after-free bug due to an unexpected early `Return`.
3. ✔️ DO be aware that similar issues may arise with other pooling APIs or patterns, such as <xref:Microsoft.Extensions.ObjectPool.ObjectPool`1>.

## 21. `bool` <-> `int` conversions

While ECMA-335 standard defines a Boolean as 0-255 where `true` is any non-zero value, it's better to avoid any explicit conversions between integers and Booleans in order to avoid introducing "denormalized" values as anything other than 0 or 1 likely leads to unreliable behavior.

```csharp
// Bad:
bool b = Unsafe.As<int, bool>(ref someInteger);
int i = Unsafe.As<bool, int>(ref someBool);

// Good:
bool b = (byte)someInteger != 0;
int i = someBool ? 1 : 0;
```

The JIT present in earlier .NET runtimes did not fully optimize the safe version of this logic, resulting in developers using unsafe constructs to convert between `bool` and `int` in performance-sensitive code paths. This is no longer the case, and modern .NET JITs are able to optimize the safe version effectively.

### Recommendations

1. ❌ DON'T write "branchless" conversions between integers and Booleans using unsafe code.
2. ✔️ DO use ternary operators (or other branching logic) instead. Modern .NET JITs will optimize them effectively.
3. ❌ DON'T read `bool` using unsafe APIs such as `Unsafe.ReadUnaligned` or `MemoryMarshal.Cast` if you don't trust the input. Consider using ternary operators or equality comparisons instead:

```csharp
// Bad:
bool b = Unsafe.ReadUnaligned<bool>(ref byteData);

// Good:
bool b = byteData[0] != 0;

// Bad:
ReadOnlySpan<byte> byteSpan = ReadDataFromNetwork();
bool[] boolArray = MemoryMarshal.Cast<byte, bool>(byteSpan).ToArray();

// Good:
ReadOnlySpan<byte> byteSpan = ReadDataFromNetwork();
bool[] boolArray = new bool[byteSpan];
for (int i = 0; i < byteSpan.Length; i++) { boolArray[i] = byteSpan[i] != 0; }
```

For more information, see [Binary (de)serialization of structs with paddings or non-blittable members](#12-binary-deserialization-of-structs-with-paddings-or-non-blittable-members).

## 22. Interop

While most of the suggestions in this document apply to interop scenarios as well, it is recommended to follow the [Native interoperability best practices](../../standard/native-interop/best-practices.md) guide. Additionally, consider using auto-generated interop wrappers like [CsWin32](https://github.com/microsoft/CsWin32) and [CsWinRT](https://github.com/microsoft/CsWinRT/). This minimizes the need for you to write manual interop code and reduces the risk of introducing memory safety issues.

## 23. Thread safety

See [Managed threading best practices](../../standard/threading/managed-threading-best-practices.md) and [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md).

## 24. Unsafe code around SIMD/Vectorization

See [Vectorization guidelines](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/vectorization-guidelines.md) for more details.
In the context of the unsafe code it's important to keep in mind:

* SIMD operations have complex requirements to provide atomicity guarantees (sometimes, they don't provide them at all).
* Most SIMD Load/Store APIs don't provide bounds checks.

## 25. Fuzz testing

Fuzz testing (or "fuzzing") is an automated software testing technique that involves providing invalid, unexpected, or random data as inputs to a computer program. It provides a way to detect memory safety issues in code that may have gaps in test coverage. You can use tools like [SharpFuzz](https://github.com/Metalnem/sharpfuzz) to set up fuzz testing for .NET code.

## References

* [Unsafe code, pointer types, and function pointers](../../csharp/language-reference/unsafe-code.md).
* [Unsafe code, language specification](~/_csharpstandard/standard/unsafe-code.md).
* [What Every CLR Developer Must Know Before Writing Code](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/clr-code-guide.md) for advanced topics around the CoreCLR and the GC internals.
* [Native interoperability best practices](../../standard/native-interop/best-practices.md).
* [Managed threading best practices](../../standard/threading/managed-threading-best-practices.md).
* [Best practices for exceptions](../../standard/exceptions/best-practices-for-exceptions.md).
* [Vectorization guidelines](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/vectorization-guidelines.md)
* [.NET Memory Model](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Memory-model.md)
* [ECMA-335](https://ecma-international.org/publications-and-standards/standards/ecma-335/)
* [ECMA-335 augments](https://github.com/dotnet/runtime/blob/main/docs/design/specs/Ecma-335-Augments.md)
