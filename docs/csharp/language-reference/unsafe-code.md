---
title: "Unsafe code, pointers to data, and function pointers"
description: Learn about unsafe code, pointers, and function pointers. C# uses an unsafe context for operations that access unmanaged memory or invoke function pointers (unmanaged delegates).
ms.date: 06/17/2026
ai-usage: ai-assisted
f1_keywords:
  - "functionPointer_CSharpKeyword"
helpviewer_keywords:
  - "security [C#], type safety"
  - "C# language, unsafe code"
  - "type safety [C#]"
  - "unsafe keyword [C#]"
  - "unsafe code [C#]"
  - "C# language, pointers"
  - "pointers [C#], about pointers"
---
# Unsafe code, pointer types, and function pointers

Most of the C# code you write is verifiably safe code. *Verifiably safe code* means that .NET tools can verify that the code is safe. In general, safe code doesn't directly access memory by using pointers. It also doesn't allocate raw memory. It creates managed objects instead.

[!INCLUDE[csharp-version-note](./includes/initial-version.md)]

C# also supports an [`unsafe`](keywords/unsafe.md) context, in which you can write *unverifiable* code. Unsafe code isn't necessarily dangerous; it's just code whose safety .NET tools can't verify. You use unsafe code to call native functions that require pointers, and in some cases to improve performance through direct memory access that avoids array bounds checks. Unsafe code also introduces security and stability risks. To compile code that contains an `unsafe` context, add the [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) compiler option.

C# defines two models for what counts as unsafe code: the original model and an updated memory safety model that's in preview in C# 15 and .NET 11. For how the two models differ, see [Two models for unsafe code](#two-models-for-unsafe-code).

For information about best practices for unsafe code in C#, see [Unsafe code best practices](../../standard/unsafe-code/best-practices.md).

## Two models for unsafe code

C# defines two models for unsafe code. The model in effect determines which operations require an `unsafe` context and how the `unsafe` modifier on a member affects callers.

- **Original unsafe model**: The `unsafe` context covers the existence of *pointer features*. You declare a pointer type, take the address of a variable, dereference a pointer, convert a `stackalloc` expression to a pointer, or apply `sizeof` to an arbitrary type only inside an `unsafe` context. (A `stackalloc` expression assigned to a `Span<T>` or `ReadOnlySpan<T>` is allowed in safe code.) The `unsafe` modifier on a type, a member, or a block establishes that context but places no obligation on callers. C# 1.0 introduced this model, and it remains the default.
- **Updated memory safety model**: The `unsafe` context covers the operations that *access memory the runtime doesn't manage*. The existence of a pointer isn't unsafe; the dereference of a pointer is. The `unsafe` modifier on a member becomes a contract that propagates the obligation to audit safety to the caller. This model is in preview in C# 15 and .NET 11.

The following table compares which operations require an `unsafe` context in each model.

| Operation                                                                      | Original model        | Updated model        |
|--------------------------------------------------------------------------------|-----------------------|----------------------|
| Declare a pointer type or take an address with `&`                             | Requires `unsafe`     | Allowed in safe code |
| The [`fixed`](statements/fixed.md) statement                                   | Requires `unsafe`     | Allowed in safe code |
| Convert a [`stackalloc`](operators/stackalloc.md) expression to a pointer      | Requires `unsafe`     | Allowed in safe code |
| The [`sizeof`](operators/sizeof.md) operator on any unmanaged type             | Requires `unsafe`     | Allowed in safe code |
| Pointer indirection (`*p`), member access (`p->m`), or element access (`p[i]`) | Requires `unsafe`     | Requires `unsafe`    |
| Function pointer invocation                                                    | Requires `unsafe`     | Requires `unsafe`    |
| Element access on a fixed-size buffer                                          | Requires `unsafe`     | Requires `unsafe`    |
| Call a member marked `unsafe`                                                  | No caller requirement | Requires `unsafe`    |

To try the updated model, use the .NET 11 SDK (in preview) and set the [`LangVersion`](compiler-options/language.md#langversion) compiler option to `preview`. The pointer relaxations apply whenever you compile with the C# 15 compiler and the `preview` language version. The full enforcement, including caller obligations and the assembly opt-in, is still under development. For more information, see [The updated memory safety model (preview)](#the-updated-memory-safety-model-preview).

## The original unsafe model

In the original model, the `unsafe` keyword establishes an unsafe context on a type, a member, or a block, and that context unlocks the pointer features described in the following sections. The `unsafe` modifier changes only what the marked code can do; it places no requirement on callers. To compile any of these examples, set the [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) compiler option.

### Pointer types

In an unsafe context, a type can be a pointer type, in addition to a value type or a reference type. A pointer type declaration takes one of the following forms:

``` csharp
type* identifier;
void* identifier; //allowed but not recommended
```

The type you specify before the `*` in a pointer type is the **referent type**.

Pointer types don't inherit from [object](builtin-types/reference-types.md), and no conversions exist between pointer types and `object`. Also, boxing and unboxing don't support pointers. However, you can convert between different pointer types and between pointer types and integral types.

When you declare multiple pointers in the same declaration, write the asterisk (`*`) together with the underlying type only. It isn't used as a prefix to each pointer name. For example:

```csharp
int* p1, p2, p3;   // Ok
int *p1, *p2, *p3;   // Invalid in C#
```

The garbage collector doesn't keep track of whether an object is being pointed to by any pointer types. If the referent is an object in the managed heap (including local variables captured by lambda expressions or anonymous delegates), you must [pin](./statements/fixed.md) the object for as long as the pointer is used.

The value of the pointer variable of type `MyType*` is the address of a variable of type `MyType`. The following are examples of pointer type declarations:

- `int* p`: `p` is a pointer to an integer.
- `int** p`: `p` is a pointer to a pointer to an integer.
- `int*[] p`: `p` is a single-dimensional array of pointers to integers.
- `char* p`: `p` is a pointer to a char.
- `void* p`: `p` is a pointer to an unknown type.

You can use the pointer indirection operator `*` to access the contents at the location pointed to by the pointer variable. For example, consider the following declaration:

```csharp
int* myVariable;
```

The expression `*myVariable` denotes the `int` variable found at the address contained in `myVariable`.

There are several examples of pointers in the articles on the [`fixed` statement](statements/fixed.md). The following example uses the `unsafe` keyword and the `fixed` statement, and shows how to increment an interior pointer. You can paste this code into the Main function of a console application to run it. These examples must be compiled with the [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) compiler option set.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="5":::

You can't apply the indirection operator to a pointer of type `void*`. However, you can use a cast to convert a void pointer to any other pointer type, and vice versa.

A pointer can be `null`. Applying the indirection operator to a null pointer causes an implementation-defined behavior.

Passing pointers between methods can cause undefined behavior. Consider a method that returns a pointer to a local variable through an `in`, `out`, or `ref` parameter or as the function result. If the pointer was set in a fixed block, the variable to which it points might no longer be fixed.

The following table lists the operators and statements that can operate on pointers in an unsafe context:

| Operator/Statement                       | Use                                                            |
|------------------------------------------|----------------------------------------------------------------|
| `*`                                      | Performs pointer indirection.                                  |
| `->`                                     | Accesses a member of a struct through a pointer.               |
| `[]`                                     | Indexes a pointer.                                             |
| `&`                                      | Obtains the address of a variable.                             |
| `++` and `--`                            | Increments and decrements pointers.                            |
| `+` and `-`                              | Performs pointer arithmetic.                                   |
| `==`, `!=`, `<`, `>`, `<=`, and `>=`     | Compares pointers.                                             |
| [`stackalloc`](operators/stackalloc.md)  | Allocates memory on the stack.                                 |
| [`fixed` statement](statements/fixed.md) | Temporarily fixes a variable so that its address can be found. |

For more information about pointer-related operators, see [Pointer-related operators](operators/pointer-related-operators.md).

Any pointer type can be implicitly converted to a `void*` type. Any pointer type can be assigned the value `null`. You can explicitly convert any pointer type to any other pointer type using a cast expression. You can also convert any integral type to a pointer type, or any pointer type to an integral type. These conversions require an explicit cast.

The following example converts an `int*` to a `byte*`. Notice that the pointer points to the lowest addressed byte of the variable. When you successively increment the result, up to the size of `int` (4 bytes), you can display the remaining bytes of the variable.

:::code language="csharp" source="snippets/unsafe-code/Conversions.cs" ID="Conversion":::

### Fixed-size buffers

Arrays are reference types, so in safe code a struct field that's an array stores only a reference to the array's elements, not the elements themselves. The size of the following `struct` doesn't depend on the number of elements in the array, because `pathName` is a reference:

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="6":::

To store the array's contents inside the struct itself, use the `fixed` keyword to declare a *fixed-size buffer*. The `fixed` keyword requires an [`unsafe`](keywords/unsafe.md) context. Fixed-size buffers are useful when you write methods that interoperate with data sources from other languages or platforms. A fixed-size buffer can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`:

```csharp
private fixed char name[30];
```

In the following example, the `fixedBuffer` array has a fixed size. You use a [`fixed` statement](statements/fixed.md) to get a pointer to the first element, then access the elements of the array through that pointer. The `fixed` statement pins the `fixedBuffer` instance field to a specific location in memory:

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="7":::

The size of the 128 element `char` array is 256 bytes. Fixed-size [char](builtin-types/char.md) buffers always take 2 bytes per character, regardless of the encoding. This array size is the same even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.

The preceding example demonstrates accessing `fixed` fields without pinning. Another common fixed-size array is the [bool](builtin-types/bool.md) array. The elements in a `bool` array are always 1 byte in size. `bool` arrays aren't appropriate for creating bit arrays or buffers.

Fixed-size buffers are compiled with the <xref:System.Runtime.CompilerServices.UnsafeValueTypeAttribute?displayProperty=nameWithType>, which instructs the common language runtime (CLR) that a type contains an unmanaged array that can potentially overflow. Memory allocated by using [stackalloc](operators/stackalloc.md) also automatically enables buffer overrun detection features in the CLR. The preceding example shows how a fixed-size buffer could exist in an `unsafe struct`.

```csharp
internal unsafe struct Buffer
{
    public fixed char fixedBuffer[128];
}
```

The compiler-generated C# for `Buffer` is attributed as follows:

```csharp
internal struct Buffer
{
    [StructLayout(LayoutKind.Sequential, Size = 256)]
    [CompilerGenerated]
    [UnsafeValueType]
    public struct <fixedBuffer>e__FixedBuffer
    {
        public char FixedElementField;
    }

    [FixedBuffer(typeof(char), 128)]
    public <fixedBuffer>e__FixedBuffer fixedBuffer;
}
```

Fixed-size buffers differ from regular arrays in the following ways:

- You can only use them in an `unsafe` context.
- They can only be instance fields of structs.
- They're always vectors, or one-dimensional arrays.
- The declaration must include the length, such as `fixed char id[8]`. You can't use `fixed char id[]`.

### Function pointers

C# provides [`delegate`](builtin-types/reference-types.md#the-delegate-type) types to define safe function pointer objects. Invoking a delegate involves instantiating a type derived from <xref:System.Delegate?displayProperty=nameWithType> and making a virtual method call to its `Invoke` method. This virtual call uses the `callvirt` IL instruction. In performance critical code paths, using the `calli` IL instruction is more efficient.

You can define a function pointer by using the `delegate*` syntax. The compiler calls the function by using the `calli` instruction rather than instantiating a `delegate` object and calling `Invoke`. The following code declares two methods that use a `delegate` or a `delegate*` to combine two objects of the same type. The first method uses a <xref:System.Func`3?displayProperty=nameWithType> delegate type. The second method uses a `delegate*` declaration with the same parameters and return type:

:::code language="csharp" source="snippets/unsafe-code/FunctionPointers.cs" ID="UseDelegateOrPointer":::

The following code shows how you declare a static local function and invoke the `UnsafeCombine` method by using a pointer to that local function:

:::code language="csharp" source="snippets/unsafe-code/FunctionPointers.cs" ID="InvokeViaFunctionPointer":::

The preceding code illustrates several of the rules on the function accessed as a function pointer:

- You can only declare function pointers in an `unsafe` context.
- You can only call methods that take a `delegate*` (or return a `delegate*`) in an `unsafe` context.
- The `&` operator to obtain the address of a function is allowed only on `static` functions. This rule applies to both member functions and local functions.

The syntax has parallels with declaring `delegate` types and using pointers. The `*` suffix on `delegate` indicates the declaration is a *function pointer*. The `&` when assigning a method group to a function pointer indicates the operation takes the address of the method.

You can specify the calling convention for a `delegate*` by using the keywords `managed` and `unmanaged`. In addition, for `unmanaged` function pointers, you can specify the calling convention. The following declarations show examples of each. The first declaration uses the `managed` calling convention, which is the default. The next four use an `unmanaged` calling convention. Each specifies one of the ECMA 335 calling conventions: `Cdecl`, `Stdcall`, `Fastcall`, or `Thiscall`. The last declaration uses the `unmanaged` calling convention, instructing the CLR to pick the default calling convention for the platform. The CLR chooses the calling convention at run time.

:::code language="csharp" source="snippets/unsafe-code/FunctionPointers.cs" ID="UnmanagedFunctionPointers":::

You can learn more about function pointers in the [Function pointers](~/_csharpstandard/standard/unsafe-code.md#2433-function-pointers) section of the C# language specification.

### Example: Use pointers to copy an array of bytes

The following example uses pointers to copy bytes from one array to another.

This example uses the [unsafe](keywords/unsafe.md) keyword, which enables you to use pointers in the `Copy` method. The [fixed](statements/fixed.md) statement declares pointers to the source and destination arrays. The `fixed` statement *pins* the location of the source and destination arrays in memory so that garbage collection doesn't move the arrays. The `fixed` block pins the memory blocks for the arrays in the scope of the block. Because the `Copy` method in this example uses the `unsafe` keyword, you must compile it by using the [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) compiler option.

This example accesses the elements of both arrays by using indices rather than a second unmanaged pointer. The declaration of the `pSource` and `pTarget` pointers pins the arrays.

:::code language="csharp" source="snippets/unsafe-code/FixedKeywordExamples.cs" ID="8":::

## The updated memory safety model (preview)

> [!IMPORTANT]
> The updated memory safety model is a preview feature in C# 15 and .NET 11. It continues to evolve based on feedback during the preview releases. To try the model, use the .NET 11 (preview) SDK and set the [`LangVersion`](compiler-options/language.md#langversion) compiler option to `preview`. The compiler in .NET 11 Preview 5 implements the pointer relaxations but doesn't yet enforce the caller obligations, the assembly opt-in, or the `safe` keyword. For the full design, see the [memory safety feature specification](~/_csharplang/proposals/unsafe-evolution.md).

The updated model separates two things the original model treats as one: the *existence* of pointer code and the *propagation* of safety obligations to callers. Marking a member `unsafe` no longer just permits pointers in its body; it makes the member *caller-unsafe*, so every caller must either propagate that obligation or discharge it behind a validated, safe-callable boundary. To support that separation, the model also narrows the unsafe context: the existence of a pointer isn't unsafe, only the operations that access memory the runtime doesn't manage. The narrowing lets you hold, pass, and return pointers in safe code, while `unsafe` marks the operations and members that can actually violate memory safety.

### Caller-unsafe members

In the original model, the `unsafe` modifier on a member only allows pointers in the member's signature and body; it tells callers nothing. The updated model gives the modifier meaning for callers. When you mark a member `unsafe`, the compiler treats it as *caller-unsafe* (also called *requires-unsafe*): every caller must invoke it from an `unsafe` context, and the obligation to audit safety moves to that caller.

The `unsafe` modifier on a member signature no longer establishes an unsafe context for the body. The two roles split:

- The `unsafe` modifier on the signature propagates the obligation to callers.
- An inner `unsafe` block scopes the operations that access unmanaged memory.

In the following preview mockup, `ReadInt32` is caller-unsafe. The signature carries the `unsafe` modifier, and an inner `unsafe` block wraps the dereference:

```csharp
// Preview: illustrates the updated model, which the current compiler doesn't fully enforce yet.
public static unsafe int ReadInt32(byte* source)
{
    unsafe
    {
        return *(int*)source;
    }
}
```

A caller wraps the call in its own `unsafe` block:

```csharp
// Preview
unsafe
{
    int value = ReadInt32(buffer);
}
```

The updated model also tightens a few related rules:

- The `unsafe` modifier produces an error on a type declaration, a static constructor, and a finalizer, because the modifier has no caller to inform there.
- Delegates can't be `unsafe`, because a delegate is type-shaped.
- A type whose parameterless constructor is `unsafe` doesn't satisfy the `new()` constraint.

### Operations that require an unsafe context

The operations that access the pointed-to memory require an `unsafe` context:

- Pointer indirection (`*p`), pointer member access (`p->member`), and pointer element access (`p[i]`).
- Function pointer invocation.
- Element access on a fixed-size buffer.

The following example pins an array without an `unsafe` context but dereferences the pointer inside one:

:::code language="csharp" source="snippets/memory-safety/Relaxations.cs" id="Dereference":::

### Relaxed operations

Operation that don't access pointed-to memory no longer requires an `unsafe` context:

- Declaring a pointer type and taking the address of a variable with the `&` operator.
- The [`fixed`](statements/fixed.md) statement that pins a variable.
- Converting a [`stackalloc`](operators/stackalloc.md) expression to a pointer.
- The [`sizeof`](operators/sizeof.md) operator applied to any unmanaged type.

The following example creates and pins pointers without an `unsafe` context:

:::code language="csharp" source="snippets/memory-safety/Relaxations.cs" id="CreatePointer":::

:::code language="csharp" source="snippets/memory-safety/Relaxations.cs" id="FixedStatement":::

These relaxations apply whenever you compile with the `preview` language version, whether or not an assembly opts in to the updated memory safety rules.

### Discharge caller-unsafe obligations

A member that calls a caller-unsafe operation has two choices: propagate the obligation, or discharge it.

- **Propagate**: Mark your own member `unsafe`. The obligation passes to your callers. Use propagation when you can't fully validate the obligation yourself.
- **Discharge**: Leave your member's signature safe. Validate the obligation inside the member, usually with runtime guards, then perform the unsafe operation in an inner `unsafe` block. A member that contains an inner `unsafe` block but doesn't mark its own signature `unsafe` is an *unsafe boundary*: it turns unsafe code into a safe-callable surface.

The following preview mockup validates its input with a guard, pins a managed array, and reads through the pointer. Callers don't need an `unsafe` context, because the method discharges the obligation:

```csharp
// Preview
public static int SumBytes(byte[] source)
{
    ArgumentNullException.ThrowIfNull(source);

    fixed (byte* first = source)
    {
        unsafe
        {
            // SAFETY: the null check and source.Length bound every read to the pinned array.
            int total = 0;
            for (int i = 0; i < source.Length; i++)
            {
                total += first[i];
            }

            return total;
        }
    }
}
```

The null check and the array length rule out the inputs that would let a read run past the buffer, so the dereference inside the `unsafe` block is sound. The method leaves no residual obligation, so it exposes a safe-callable signature.

### Safety documentation

A caller-unsafe member should document what the caller must guarantee. The updated model encourages two complementary comment styles:

- A `/// <safety>` documentation block above the signature states the formal contract: the conditions a caller must satisfy. An analyzer can flag a caller-unsafe member that's missing one.
- A `// SAFETY:` comment inside an `unsafe` block records why the operation is sound at that spot, for the developers and auditors who read the body.

The following preview mockup shows both styles on a caller-unsafe `ReadByte` method:

```csharp
// Preview
/// <summary>Reads a single byte from unmanaged memory.</summary>
/// <safety>
/// The sum of <paramref name="ptr"/> and <paramref name="offset"/> must address a byte
/// the caller is permitted to read.
/// </safety>
public static unsafe byte ReadByte(IntPtr ptr, int offset)
{
    byte* address = (byte*)ptr;
    unsafe
    {
        // SAFETY: relies on the caller obligation stated in the <safety> block.
        return address[offset];
    }
}
```

The `/// <safety>` block tells you the contract.The contract belongs in the documentation where every caller and reviewer sees it.

### Unsafe fields

A field needs the `unsafe` modifier when its declared type doesn't express contracts that the enclosing type maintains and other code depends on. The unsafety lives in the gap between what the type system sees and what the type promises. The modifier forces every write to the field into an `unsafe` block, which keeps the writes reviewable in one place.

The clearest case is a field that holds a native pointer. The pointer doesn't declare how many bytes it addresses as a <xref:System.Span`1?displayProperty=nameWithType> does, so the containing type maintains that information itself:

```csharp
// Preview
public class NativeBuffer
{
    /// <safety>
    /// Null, or points to a buffer of Length bytes.
    /// </safety>
    private unsafe byte* _pointer;

    public int Length { get; }

    public byte ReadAt(int index)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Length);
        unsafe
        {
            // SAFETY: the bounds checks confine the read to the buffer that _pointer addresses.
            return _pointer[index];
        }
    }
}
```

A `readonly unsafe` field pairs the contract with a built-in guard: `unsafe` names the invariant, and `readonly` prevents a write that could break it after construction. Marking a property or an event `unsafe` doesn't make its backing field caller-unsafe. In a struct with `[StructLayout(LayoutKind.Explicit)]`, you mark every field either `safe` or `unsafe`.

### The safe keyword

The updated model adds a `safe` contextual keyword that attests a declaration is sound where the compiler requires you to make the choice explicit.

An `extern` member calls into native code, so the compiler can't classify its safety. Under the updated model, you mark every `extern` declaration, including a `LibraryImport` partial method, either `safe` or `unsafe`:

```csharp
// Preview
[LibraryImport("libc")]
internal static safe partial int getpid();

[LibraryImport("libc", StringMarshalling = StringMarshalling.Utf8)]
internal static unsafe partial nint strlen(byte* str);
```

`getpid` takes no parameters and returns a primitive, so the author attests that the call is safe and callers use it without ceremony. `strlen` takes a raw pointer that the native code dereferences, so the declaration is `unsafe` and propagates the obligation to callers. Omitting both modifiers is an error, which forces you to make the safety decision. A field in a struct with explicit layout uses the same rule.

### Opt in and cross-assembly behavior

The updated model has two independent project-level switches:

- A new opt-in property turns on the updated rules. With the property off, the original rules apply. With it on, `unsafe` on a member propagates to callers, and the compiler records the choice in the assembly with the <xref:System.Runtime.CompilerServices.MemorySafetyRulesAttribute> attribute.
- The existing [**AllowUnsafeBlocks**](compiler-options/language.md#allowunsafeblocks) property gates every appearance of the `unsafe` keyword, including the inner blocks at call sites. It defaults to `false`, so a project at the default can't call any unsafe API.

The two properties combine as follows:

| Opt-in property | `AllowUnsafeBlocks` | Result                                                                                  |
|-----------------|---------------------|-----------------------------------------------------------------------------------------|
| On              | Off (default)       | The safest configuration. The project uses the updated model and allows no unsafe code. |
| On              | On                  | The project uses the updated model and allows unsafe code.                              |
| Off             | Off                 | The original model applies, and the project can't use pointer types.                    |
| Off             | On                  | The original model applies, and the project can use pointer types.                      |

Whether one assembly enforces the updated rules against another depends on which side opts in:

- **Updated-model caller, updated-model callee**: The callee's `unsafe` markers travel through metadata. The caller wraps each call to a caller-unsafe member in an `unsafe` block.
- **Updated-model caller, original-model callee**: A compatibility mode treats any callee member with a pointer type in its signature as caller-unsafe, so the call site needs an enclosing `unsafe` block. This mode keeps a pointer-based API from silently losing its `unsafe` requirement.
- **Original-model caller, updated-model callee**: The original pointer rules still apply. A caller-unsafe member that has no pointer type in its signature becomes callable from safe code, because the original-model caller can't read the new markers.

## C# language specification

For more information, see the [Unsafe code](~/_csharpstandard/standard/unsafe-code.md) chapter of the [C# language specification](~/_csharpstandard/standard/README.md).

For the design of the updated memory safety model, see the [memory safety feature specification](~/_csharplang/proposals/unsafe-evolution.md).

## See also

- [Unsafe code best practices](../../standard/unsafe-code/best-practices.md)
