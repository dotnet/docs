---
title: Native interoperability best practices
description: Learn the best practices for interfacing with native components in .NET.
author: jkoritzinsky
ms.author: jekoritz
ms.date: 1/4/2019
---

# Native interoperability best practices

## General guidance

The guidance in this section applies to all interop scenarios.

- **✔️ DO** use the same naming and capitalization for your methods and parameters as the native method you want to call.
- **✔️ CONSIDER** using the same naming and capitalization for constant values.
- **✔️ DO** use .NET types that map closest to the native type. For example, in C#, use `uint` when the native type is `unsigned int`.
- **✔️ DO** only use `[In]` and `[Out]` attributes when the behavior you want differs from the default behavior.
- **✔️ CONSIDER** using <xref:System.Buffers.ArrayPool%601?displayProperty=nameWithType> to pool your native array buffers.
- **✔️ CONSIDER** wrapping your P/Invoke declarations in a class with the same name and capitalization as your native library.
  - This allows your `[DllImport]` attributes to use the C# `nameof` language feature to pass in the name of the native library and ensure that you did not misspell the name of the native library.

## [DllImport](xref:System.Runtime.InteropServices.DllImportAttribute) attribute settings

| Setting | Default | Recommendation | Details |
|---------|---------|----------------|---------|
| [`PreserveSig`](xref:System.Runtime.InteropServices.DllImportAttribute.PreserveSig)   | `true` |  keep default  | When this is explicitly set to false, failed HRESULT return values will be turned into Exceptions (and the return value in the definition becomes null as a result).|
| [`SetLastError`](xref:System.Runtime.InteropServices.DllImportAttribute.SetLastError) | `false`  | depends on the API  | Set this to true if the API uses GetLastError and use Marshal.GetLastWin32Error to get the value. If the API sets a condition that says it has an error, get the error before making other calls to avoid inadvertently having it overwritten.|
| [`CharSet`](xref:System.Runtime.InteropServices.DllImportAttribute.CharSet) | `CharSet.None`, which falls back to `CharSet.Ansi` behavior  | Explicitly  use `CharSet.Unicode` or `CharSet.Ansi` when strings or characters are present in the definition | This specifies marshalling behavior of strings and what `ExactSpelling` does when `false`. Note that `CharSet.Ansi` is actually UTF8 on Unix. _Most_ of the time Windows uses Unicode while Unix uses UTF8. See more information on the [documentation on charsets](./charset.md). |
| [`ExactSpelling`](xref:System.Runtime.InteropServices.DllImportAttribute.ExactSpelling) | `false` | `true`             | Set this to true and gain a slight perf benefit as the runtime will not look for alternate function names with either an "A" or "W" suffix depending on the value of the `CharSet` setting ("A" for `CharSet.Ansi` and "W" for `CharSet.Unicode`). |

## String parameters

When the CharSet is Unicode or the argument is explicitly marked as `[MarshalAs(UnmanagedType.LPWSTR)]` _and_ the string is passed by value (not `ref` or `out`) the string will be be pinned and used directly by native code (rather than copied).

Remember to mark the `[DllImport]` as `Charset.Unicode` unless you explicitly want ANSI treatment of your strings.

**❌ DO NOT** use `[Out] string` parameters. String parameters passed by value with the `[Out]` attribute can destabilize the runtime if the string is an interned string. See more information about string interning in the documentation for [String.Intern](xref:System.String.Intern).

**❌ AVOID** `StringBuilder` parameters. `StringBuilder` marshalling *always* creates a native buffer copy. As such it can be extremely inefficient. Take the typical
scenario of calling a Windows API that takes a string:

1. Create a SB of the desired capacity (allocates managed capacity) **{1}**
2. Invoke
   1. Allocates a native buffer **{2}**  
   2. Copies the contents if `[In]` _(the default for a `StringBuilder` parameter)_  
   3. Copies the native buffer into a newly allocated managed array if `[Out]` **{3}** _(also the default for `StringBuilder`)_  
3. `ToString()` allocates yet another managed array **{4}**

That is *{4}* allocations to get a string out of native code. The best you can do to limit this is to reuse the `StringBuilder`
in another call but this still only saves *1* allocation. It is much better to use and cache a character buffer from `ArrayPool`- you can then get down to just the allocation for the `ToString()` on subsequent calls.

The other issue with `StringBuilder` is that it always copies the return buffer back up to the first null. If the passed back string isn't terminated or is a double-null-terminated string your P/Invoke is incorrect at best.

If you *do* use `StringBuilder` one last gotcha is that the capacity does **not** include a hidden null which is always accounted for in interop. It is pretty common for people to get this wrong as most APIs want the size of the buffer *including* the null. This can result in wasted/unnecessary allocations. Additionally, this gotcha prevents the runtime from optimizing `StringBuilder` marshalling to minimize copies.

**✔️ CONSIDER** using `char[]`s from an `ArrayPool`.

For more information on string marshalling, see the documentation on [Default Marshalling for Strings](../../framework/interop/default-marshaling-for-strings) and [customizing string marshalling](./customizing-parameter-marshalling#customizing-string-parameters).

> __Windows Specific__  
> For `[Out]` strings the CLR will use `CoTaskMemFree` by default to free strings or `SysStringFree` for strings that are marked
as `UnmanagedType.BSTR`.  
> **For most APIs with an output string buffer:**  
> The passed in character count must include the null. If the returned value is less than the passed in character count the call has succeeded and the value is the number of characters *without* the trailing null. Otherwise the count is the required size of the buffer *including* the null character.  
> - Pass in 5, get 4: The string is 4 characters long with a trailing null.
> - Pass in 5, get 6: The string is 5 characters long, need a 6 character buffer to hold the null.  
> [Windows Data Types for Strings](https://docs.microsoft.com/windows/desktop/Intl/windows-data-types-for-strings)

## Boolean parameters and fields

Booleans are easy to mess up. The default marshalling for .NET is as the Windows type `BOOL`, where it is a 4 byte value. However, the `_Bool`, and `bool` types in C and C++ are a *single* byte. This can lead to hard to track down bugs as half the return value will be discarded, which will only *potentially* change the result. See the documentation on [customizing boolean field marshalling](./customizing-struct-marshalling#customizing-boolean-field-marshalling) for information on marshalling .NET `bool` values to C or C++ `bool` types.

## Guids

Guids are usable directly in signatures. Many Windows APIs take `GUID&` type aliases like `REFIID`. When passed by ref they can either be passed by `ref` or with the `[MarshalAs(UnmanagedType.LPStruct)]` attribute.

| Guid | By-ref Guid |
|------|-------------|
| `KNOWNFOLDERID` | `REFKNOWNFOLDERID` |

**❌ DO NOT** Use `[MarshalAs(UnmanagedType.LPStruct)]` for anything other than `ref` Guid parameters.

## Blittable Types

Blittable types are types that have the same bit-level representation in managed and native code. As such they do not need to be converted to another format to be marshalled to and from native code, and as this improves performance they should be preferred.

**Blittable types:**

- `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `single`, `double`
- non-nested one dimensional arrays of blittable types (e.g. `int[]`)
- structs and classes with fixed layout that only have blittable value types for instance fields
  - fixed layout requires `[StructLayout(LayoutKind.Sequential)]` or `[StructLayout(LayoutKind.Explicit)]`
  - structs are `LayoutKind.Sequential` by default, classes are `LayoutKind.Auto`

**NOT blittable:**

- `bool`

**SOMETIMES blittable:**

- `char`, `string`

When blittable types are passed by reference they are simply pinned by the marshaller instead of being copied to an intermediate buffer. (Classes are inherently passed by reference, structs are passed by reference when used with `ref` or `out`.)

`char` is blittable in a one dimensional array **or** if it is part of a type that contains it is explicitly marked with `[StructLayout]` with `CharSet = CharSet.Unicode`.

```C#
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct UnicodeCharStruct
{
    public char c;
}
```

`string` is blittable if it isn't contained in another type and it's being passed as an argument that is marked with `[MarshalAs(UnmanagedType.LPWStr)]` or the `[DllImport]` has `CharSet = CharSet.Unicode` set.

You can see if a type is blittable by attempting to create a pinned `GCHandle`. If the type is not a string or considered blittable `GCHandle.Alloc` will throw an `ArgumentException`.

**✔️ DO** make your structures blittable when possible.

See more information at:

- [Blittable and Non-Blittable Types](../../framework/interop/blittable-and-non-blittable-types)  
- [Type Marshalling](./type-marshalling)

## Keeping Managed Objects Alive

`GC.KeepAlive()` will ensure an object stays in scope until the KeepAlive method is hit.

[`HandleRef`](xref:System.Runtime.InteropServices.HandleRef) allows the marshaller to keep an object alive for the duration of a P/Invoke. It can be used instead of `IntPtr` in method signatures. `SafeHandle` effectively replaces this class and should be used instead.

[`GCHandle`](xref:System.Runtime.InteropServices.GCHandle) allows pinning a managed object and getting the native pointer to it. The basic pattern is:  

```csharp
GCHandle handle = GCHandle.Alloc(obj, GCHandleType.Pinned);
IntPtr ptr = handle.AddrOfPinnedObject();
handle.Free();
```

Pinning is not the default for `GCHandle`. The other major pattern is for passing a reference to a managed object through native code and back to managed code, usually with a callback. Here is the pattern:

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

## Common Windows Data Types

Here is a list of data types commmonly used in Win32 APIs and which C# types to use when calling into the Win32 code.

The following types are the same size on 32-bit and 64-bit Windows, despite their names.

| Width | Windows          | C (Windows)          | C#       | Alternative                          |
|:------|:-----------------|:---------------------|:---------|:-------------------------------------|
| 32    | `BOOL`           | `int`                | `int`    | `bool`                               |
| 8     | `BOOLEAN`        | `unsigned char`      | `byte`   | `[MarshalAs(UnmanagedType.U1)] bool` |
| 8     | `BYTE`           | `unsigned char`      | `byte`   |                                      |
| 8     | `CHAR`           | `char`               | `sbyte`  |                                      |
| 8     | `UCHAR`          | `unsigned char`      | `byte`   |                                      |
| 16    | `SHORT`          | `short`              | `short`  |                                      |
| 16    | `CSHORT`         | `short`              | `short`  |                                      |
| 16    | `USHORT`         | `unsigned short`     | `ushort` |                                      |
| 16    | `WORD`           | `unsigned short`     | `ushort` |                                      |
| 16    | `ATOM`           | `unsigned short`     | `ushort` |                                      |
| 32    | `INT`            | `int`                | `int`    |                                      |
| 32    | `LONG`           | `long`               | `int`    |                                      |
| 32    | `ULONG`          | `unsigned long`      | `uint`   |                                      |
| 32    | `DWORD`          | `unsigned long`      | `uint`   |                                      |
| 64    | `QWORD`          | `long long`          | `long`   |                                      |
| 64    | `LARGE_INTEGER`  | `long long`          | `long`   |                                      |
| 64    | `LONGLONG`       | `long long`          | `long`   |                                      |
| 64    | `ULONGLONG`      | `unsigned long long` | `ulong`  |                                      |
| 64    | `ULARGE_INTEGER` | `unsigned long long` | `ulong`  |                                      |
| 32    | `HRESULT`        | `long`               | `int`    |                                      |
| 32    | `NTSTATUS`       | `long`               | `int`    |                                      |


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

A Windows `PVOID` which is a C `void*` can be marshaled as either `IntPtr` or `UIntPtr`, but prefer `void*` when possible.

[Windows Data Types](https://docs.microsoft.com/windows/desktop/WinProg/windows-data-types)

[Data Type Ranges](https://docs.microsoft.com/cpp/cpp/data-type-ranges)

## Structs

Managed structs are created on the stack and aren't removed until the method returns. By definition then, they are "pinned" (it won't get moved by the GC). You can also simply take the address in unsafe code blocks if native code won't use the pointer past the end of the current method.

Blittable structs are much more performant as they they can simply be used directly by the marshalling layer. Try to make structs blittable (for example, avoid `bool`). See the [Blittable Types section](#blittable-types) for more details.

*If* the struct is blittable, . As mentioned above, you can validate that the type is blittable by attempting to create a pinned `GCHandle`. If the type is not a string or considered blittable `GCHandle.Alloc` will throw an `ArgumentException`.

Pointers to structs in definitions must either be passed by `ref` or use `unsafe` and `*`.

**✔️ DO** match the managed struct as closely as possible to the shape and names that are used in the official platform documentation or header.

**✔️ DO** use the C# `sizeof()` instead of `Marshal.SizeOf<MyStruct>()` for blittable structures to improve performance.

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

However, there are some gotchas with fixed buffers. Fixed buffers of non-blittable types will not be correctly marshalled, so the in-place array needs to be expanded out to multiple individual fields. Additionally, in .NET Framework and .NET Core before 3.0, if a struct containing a fixed buffer field is nested within a non-blittable struct, the fixed buffer field will not be correctly marshalled to native code.