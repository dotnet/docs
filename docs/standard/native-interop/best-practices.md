---
title: Native interoperability best practices - .NET
description: Learn the best practices for interfacing with native components in .NET.
ms.date: 01/18/2019
---
# Native interoperability best practices

.NET gives you various ways to customize your native interoperability code. This article includes the guidance that Microsoft's .NET teams follow for native interoperability.

## General guidance

The guidance in this section applies to all interop scenarios.

- ✔️ DO use the same naming and capitalization for your methods and parameters as the native method you want to call.
- ✔️ CONSIDER using the same naming and capitalization for constant values.
- ✔️ DO use .NET types that map closest to the native type. For example, in C#, use `uint` when the native type is `unsigned int`.
- ✔️ DO only use `[In]` and `[Out]` attributes when the behavior you want differs from the default behavior.
- ✔️ CONSIDER using <xref:System.Buffers.ArrayPool%601?displayProperty=nameWithType> to pool your native array buffers.
- ✔️ CONSIDER wrapping your P/Invoke declarations in a class with the same name and capitalization as your native library.
  - This allows your `[DllImport]` attributes to use the C# `nameof` language feature to pass in the name of the native library and ensure that you didn't misspell the name of the native library.

## DllImport attribute settings

| Setting | Default | Recommendation | Details |
|---------|---------|----------------|---------|
| <xref:System.Runtime.InteropServices.DllImportAttribute.PreserveSig>   | `true` |  keep default  | When this is explicitly set to false, failed HRESULT return values will be turned into exceptions (and the return value in the definition becomes null as a result).|
| <xref:System.Runtime.InteropServices.DllImportAttribute.SetLastError> | `false`  | depends on the API  | Set this to true if the API uses GetLastError and use Marshal.GetLastWin32Error to get the value. If the API sets a condition that says it has an error, get the error before making other calls to avoid inadvertently having it overwritten.|
| <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet> | Compiler-defined (specified in the [charset documentation](./charset.md))  | Explicitly  use `CharSet.Unicode` or `CharSet.Ansi` when strings or characters are present in the definition | This specifies marshaling behavior of strings and what `ExactSpelling` does when `false`. Note that `CharSet.Ansi` is actually UTF8 on Unix. _Most_ of the time Windows uses Unicode while Unix uses UTF8. See more information on the [documentation on charsets](./charset.md). |
| <xref:System.Runtime.InteropServices.DllImportAttribute.ExactSpelling> | `false` | `true`             | Set this to true and gain a slight perf benefit as the runtime will not look for alternate function names with either an "A" or "W" suffix depending on the value of the `CharSet` setting ("A" for `CharSet.Ansi` and "W" for `CharSet.Unicode`). |

## String parameters

When the CharSet is Unicode or the argument is explicitly marked as `[MarshalAs(UnmanagedType.LPWSTR)]` _and_ the string is passed by value (not `ref` or `out`), the string will be pinned and used directly by native code (rather than copied).

Remember to mark the `[DllImport]` as `Charset.Unicode` unless you explicitly want ANSI treatment of your strings.

❌ DO NOT use `[Out] string` parameters. String parameters passed by value with the `[Out]` attribute can destabilize the runtime if the string is an interned string. See more information about string interning in the documentation for <xref:System.String.Intern%2A?displayProperty=nameWithType>.

❌ AVOID `StringBuilder` parameters. `StringBuilder` marshaling *always* creates a native buffer copy. As such, it can be extremely inefficient. Take the typical scenario of calling a Windows API that takes a string:

1. Create a `StringBuilder` of the desired capacity (allocates managed capacity) **{1}**.
2. Invoke:
   1. Allocates a native buffer **{2}**.
   2. Copies the contents if `[In]` _(the default for a `StringBuilder` parameter)_.
   3. Copies the native buffer into a newly allocated managed array if `[Out]` **{3}** _(also the default for `StringBuilder`)_.
3. `ToString()` allocates yet another managed array **{4}**.

That is *{4}* allocations to get a string out of native code. The best you can do to limit this is to reuse the `StringBuilder`
in another call, but this still only saves *1* allocation. It's much better to use and cache a character buffer from `ArrayPool`. You can then get down to just the allocation for the `ToString()` on subsequent calls.

The other issue with `StringBuilder` is that it always copies the return buffer back up to the first null. If the passed back string isn't terminated or is a double-null-terminated string, your P/Invoke is incorrect at best.

If you *do* use `StringBuilder`, one last gotcha is that the capacity does **not** include a hidden null, which is always accounted for in interop. It's common for people to get this wrong as most APIs want the size of the buffer *including* the null. This can result in wasted/unnecessary allocations. Additionally, this gotcha prevents the runtime from optimizing `StringBuilder` marshaling to minimize copies.

✔️ CONSIDER using `char[]`s from an `ArrayPool`.

For more information on string marshaling, see [Default Marshaling for Strings](../../framework/interop/default-marshaling-for-strings.md) and [Customizing string marshaling](customize-parameter-marshaling.md#customizing-string-parameters).

> __Windows Specific__
> For `[Out]` strings the CLR will use `CoTaskMemFree` by default to free strings or `SysStringFree` for strings that are marked
as `UnmanagedType.BSTR`.
> **For most APIs with an output string buffer:**
> The passed in character count must include the null. If the returned value is less than the passed in character count the call has succeeded and the value is the number of characters *without* the trailing null. Otherwise the count is the required size of the buffer *including* the null character.
>
> - Pass in 5, get 4: The string is 4 characters long with a trailing null.
> - Pass in 5, get 6: The string is 5 characters long, need a 6 character buffer to hold the null.
> [Windows Data Types for Strings](/windows/desktop/Intl/windows-data-types-for-strings)

## Boolean parameters and fields

Booleans are easy to mess up. By default, a .NET `bool` is marshaled to a Windows `BOOL`, where it's a 4-byte value. However, the `_Bool`, and `bool` types in C and C++ are a *single* byte. This can lead to hard to track down bugs as half the return value will be discarded, which will only *potentially* change the result. For more for information on marshaling .NET `bool` values to C or C++ `bool` types, see the documentation on [customizing boolean field marshaling](customize-struct-marshaling.md#customizing-boolean-field-marshaling).

## GUIDs

GUIDs are usable directly in signatures. Many Windows APIs take `GUID&` type aliases like `REFIID`. When passed by ref, they can either be passed by `ref` or with the `[MarshalAs(UnmanagedType.LPStruct)]` attribute.

| GUID | By-ref GUID |
|------|-------------|
| `KNOWNFOLDERID` | `REFKNOWNFOLDERID` |

❌ DO NOT Use `[MarshalAs(UnmanagedType.LPStruct)]` for anything other than `ref` GUID parameters.

## Blittable types

Blittable types are types that have the same bit-level representation in managed and native code. As such they do not need to be converted to another format to be marshaled to and from native code, and as this improves performance they should be preferred. Some types are not blittable but are known to contain blittable contents. These types have similar optimizations as blittable types when they are not contained in another type, but are not considered blittable when in fields of structs or for the purposes of [`UnmanagedCallersOnlyAttribute`](xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute).

**Blittable types:**

- `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `single`, `double`
- structs with fixed layout that only have blittable value types for instance fields
  - fixed layout requires `[StructLayout(LayoutKind.Sequential)]` or `[StructLayout(LayoutKind.Explicit)]`
  - structs are `LayoutKind.Sequential` by default

**Types with blittable contents:**

- non-nested, one-dimensional arrays of blittable primitive types (for example, `int[]`)
- classes with fixed layout that only have blittable value types for instance fields
  - fixed layout requires `[StructLayout(LayoutKind.Sequential)]` or `[StructLayout(LayoutKind.Explicit)]`
  - classes are `LayoutKind.Auto` by default

**NOT blittable:**

- `bool`

**SOMETIMES blittable:**

- `char`

**Types with SOMETIMES blittable contents:**

- `string`

When blittable types are passed by reference with `in`, `ref`, or `out`, or when types with blittable contents are passed by value, they're simply pinned by the marshaller instead of being copied to an intermediate buffer.

`char` is blittable in a one-dimensional array **or** if it's part of a type that contains it's explicitly marked with `[StructLayout]` with `CharSet = CharSet.Unicode`.

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct UnicodeCharStruct
{
    public char c;
}
```

`string` contains blittable contents if it isn't contained in another type and it's being passed as an argument that is marked with `[MarshalAs(UnmanagedType.LPWStr)]` or the `[DllImport]` has `CharSet = CharSet.Unicode` set.

You can see if a type is blittable or contains blittable contents by attempting to create a pinned `GCHandle`. If the type isn't a string or considered blittable, `GCHandle.Alloc` will throw an `ArgumentException`.

✔️ DO make your structures blittable when possible.

For more information, see:

- [Blittable and Non-Blittable Types](../../framework/interop/blittable-and-non-blittable-types.md)
- [Type Marshaling](type-marshaling.md)

## Keeping managed objects alive

`GC.KeepAlive()` will ensure an object stays in scope until the KeepAlive method is hit.

[`HandleRef`](xref:System.Runtime.InteropServices.HandleRef) allows the marshaller to keep an object alive for the duration of a P/Invoke. It can be used instead of `IntPtr` in method signatures. `SafeHandle` effectively replaces this class and should be used instead.

[`GCHandle`](xref:System.Runtime.InteropServices.GCHandle) allows pinning a managed object and getting the native pointer to it. The basic pattern is:

```csharp
GCHandle handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
IntPtr ptr = handle.AddrOfPinnedObject();
handle.Free();
```

Pinning isn't the default for `GCHandle`. The other major pattern is for passing a reference to a managed object through native code and back to managed code, usually with a callback. Here is the pattern:

```csharp
GCHandle handle = GCHandle.Alloc(obj);
SomeNativeEnumerator(callbackDelegate, GCHandle.ToIntPtr(handle));

// In the callback
GCHandle handle = GCHandle.FromIntPtr(param);
object managedObject = handle.Target;

// After the last callback
handle.Free();
```

Don't forget that `GCHandle` needs to be explicitly freed to avoid memory leaks.

## Common Windows data types

Here is a list of data types commonly used in Windows APIs and which C# types to use when calling into the Windows code.

The following types are the same size on 32-bit and 64-bit Windows, despite their names.

| Width | Windows          | C#       | Alternative                          |
|:------|:-----------------|:---------|:-------------------------------------|
| 32    | `BOOL`           | `int`    | `bool`                               |
| 8     | `BOOLEAN`        | `byte`   | `[MarshalAs(UnmanagedType.U1)] bool` |
| 8     | `BYTE`           | `byte`   |                                      |
| 8     | `CHAR`           | `sbyte`  |                                      |
| 8     | `UCHAR`          | `byte`   |                                      |
| 16    | `SHORT`          | `short`  |                                      |
| 16    | `CSHORT`         | `short`  |                                      |
| 16    | `USHORT`         | `ushort` |                                      |
| 16    | `WORD`           | `ushort` |                                      |
| 16    | `ATOM`           | `ushort` |                                      |
| 32    | `INT`            | `int`    |                                      |
| 32    | `LONG`           | `int`    |  See [`CLong` and `CULong`](#cc-long). |
| 32    | `ULONG`          | `uint`   |  See [`CLong` and `CULong`](#cc-long). |
| 32    | `DWORD`          | `uint`   |                                      |
| 64    | `QWORD`          | `long`   |                                      |
| 64    | `LARGE_INTEGER`  | `long`   |                                      |
| 64    | `LONGLONG`       | `long`   |                                      |
| 64    | `ULONGLONG`      | `ulong`  |                                      |
| 64    | `ULARGE_INTEGER` | `ulong`  |                                      |
| 32    | `HRESULT`        | `int`    |                                      |
| 32    | `NTSTATUS`       | `int`    |                                      |

The following types, being pointers, do follow the width of the platform. Use `IntPtr`/`UIntPtr` for these.

| Signed Pointer Types (use `IntPtr`) | Unsigned Pointer Types (use `UIntPtr`) |
|:------------------------------------|:---------------------------------------|
| `HANDLE`                            | `WPARAM`                               |
| `HWND`                              | `UINT_PTR`                             |
| `HINSTANCE`                         | `ULONG_PTR`                            |
| `LPARAM`                            | `SIZE_T`                               |
| `LRESULT`                           |                                        |
| `LONG_PTR`                          |                                        |
| `INT_PTR`                           |                                        |

A Windows `PVOID`, which is a C `void*`, can be marshaled as either `IntPtr` or `UIntPtr`, but prefer `void*` when possible.

[Windows Data Types](/windows/desktop/WinProg/windows-data-types)

[Data Type Ranges](/cpp/cpp/data-type-ranges)

### Formerly built-in supported types

There are rare instances when built-in support for a type is removed.

The [`UnmanagedType.HString`](xref:System.Runtime.InteropServices.UnmanagedType) built-in marshal support was removed in the .NET 5 release. You must recompile binaries that use this marshaling type and that target a previous framework. It's still possible to marshal this type, but you must marshal it manually, as the following code example shows. This code will work moving forward and is also compatible with previous frameworks.

```csharp
static class HSTRING
{
    public static IntPtr FromString(string s)
    {
        Marshal.ThrowExceptionForHR(WindowsCreateString(s, s.Length, out IntPtr h));
        return h;
    }

    public static void Delete(IntPtr s)
    {
        Marshal.ThrowExceptionForHR(WindowsDeleteString(s));
    }

    [DllImport("api-ms-win-core-winrt-string-l1-1-0.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    private static extern int WindowsCreateString(
        [MarshalAs(UnmanagedType.LPWStr)] string sourceString, int length, out IntPtr hstring);

    [DllImport("api-ms-win-core-winrt-string-l1-1-0.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    private static extern int WindowsDeleteString(IntPtr hstring);
}

// Usage example
IntPtr hstring = HSTRING.FromString("HSTRING from .NET to WinRT API");
try
{
    // Pass hstring to WinRT or Win32 API.
}
finally
{
    HSTRING.Delete(hstring);
}
```

## Cross-platform data type considerations

There are types in the C/C++ language that have latitude in how they are defined. When writing cross-platform interop, cases can arise where platforms differ and can cause issues if not considered.

### C/C++ `long`

C/C++ `long` and C# `long` are not the same types. Using C# `long` to interop with C/C++ `long` is almost never correct.

The `long` type in C/C++ is defined to have ["at least 32"](https://en.cppreference.com/w/c/language/arithmetic_types) bits. This means there is a minimum number of required bits, but platforms can choose to use more bits if desired. The following table illustrates the differences in provided bits for the C/C++ `long` data type between platforms.

| Platform    | 32-bit | 64-bit |
|:------------|:-------|:-------|
| Windows     | 32     | 32     |
| macOS/\*nix | 32     | 64     |

These differences can make authoring cross-platform P/Invokes difficult when the native function is defined to use `long` on all platforms.

In .NET 6 and later versions, use the [`CLong`](xref:System.Runtime.InteropServices.CLong) and [`CULong`](xref:System.Runtime.InteropServices.CULong) types for interop with C/C++ `long` and `unsigned long` data types. The following example is for `CLong`, but you can use `CULong` to abstract `unsigned long` in a similar way.

```csharp
// Cross platform C function
// long Function(long a);
[DllImport("NativeLib")]
extern static CLong Function(CLong a);

// Usage
nint result = Function(new CLong(10)).Value;
```

When targeting .NET 5 and earlier versions, you should declare separate Windows and non-Windows signatures to handle the problem.

```csharp
static readonly bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

// Cross platform C function
// long Function(long a);

[DllImport("NativeLib", EntryPoint = "Function")]
extern static int FunctionWindows(int a);

[DllImport("NativeLib", EntryPoint = "Function")]
extern static nint FunctionUnix(nint a);

// Usage
nint result;
if (IsWindows)
{
    result = FunctionWindows(10);
}
else
{
    result = FunctionUnix(10);
}
```

## Structs

Managed structs are created on the stack and aren't removed until the method returns. By definition then, they are "pinned" (it won't get moved by the GC). You can also simply take the address in unsafe code blocks if native code won't use the pointer past the end of the current method.

Blittable structs are much more performant as they can simply be used directly by the marshaling layer. Try to make structs blittable (for example, avoid `bool`). For more information, see the [Blittable Types](#blittable-types) section.

*If* the struct is blittable, use `sizeof()` instead of `Marshal.SizeOf<MyStruct>()` for better performance. As mentioned above, you can validate that the type is blittable by attempting to create a pinned `GCHandle`. If the type is not a string or considered blittable, `GCHandle.Alloc` will throw an `ArgumentException`.

Pointers to structs in definitions must either be passed by `ref` or use `unsafe` and `*`.

✔️ DO match the managed struct as closely as possible to the shape and names that are used in the official platform documentation or header.

✔️ DO use the C# `sizeof()` instead of `Marshal.SizeOf<MyStruct>()` for blittable structures to improve performance.

❌ AVOID using `System.Delegate` or `System.MulticastDelegate` fields to represent function pointer fields in structures.

Since <xref:System.Delegate?displayProperty=fullName> and <xref:System.MulticastDelegate?displayProperty=fullName> don't have a required signature, they don't guarantee that the delegate passed in will match the signature the native code expects. Additionally, in .NET Framework and .NET Core, marshaling a struct containing a `System.Delegate` or `System.MulticastDelegate` from its native representation to a managed object can destabilize the runtime if the value of the field in the native representation isn't a function pointer that wraps a managed delegate. In .NET 5 and later versions, marshaling a `System.Delegate` or `System.MulticastDelegate` field from a native representation to a managed object is not supported. Use a specific delegate type instead of `System.Delegate` or `System.MulticastDelegate`.

### Fixed Buffers

An array like `INT_PTR Reserved1[2]` has to be marshaled to two `IntPtr` fields, `Reserved1a` and `Reserved1b`. When the native array is a primitive type, we can use the `fixed` keyword to write it a little more cleanly. For example, `SYSTEM_PROCESS_INFORMATION` looks like this in the native header:

```c
typedef struct _SYSTEM_PROCESS_INFORMATION {
    ULONG NextEntryOffset;
    ULONG NumberOfThreads;
    BYTE Reserved1[48];
    UNICODE_STRING ImageName;
...
} SYSTEM_PROCESS_INFORMATION
```

In C#, we can write it like this:

```csharp
internal unsafe struct SYSTEM_PROCESS_INFORMATION
{
    internal uint NextEntryOffset;
    internal uint NumberOfThreads;
    private fixed byte Reserved1[48];
    internal Interop.UNICODE_STRING ImageName;
    ...
}
```

However, there are some gotchas with fixed buffers. Fixed buffers of non-blittable types won't be correctly marshaled, so the in-place array needs to be expanded out to multiple individual fields. Additionally, in .NET Framework and .NET Core before 3.0, if a struct containing a fixed buffer field is nested within a non-blittable struct, the fixed buffer field won't be correctly marshaled to native code.
