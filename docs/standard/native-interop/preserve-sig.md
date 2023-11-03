---
title: Implicit native signature translations and PreserveSig in .NET native interop
description: Learn how managed signatures translate to native signatures for interop methods in .NET
ms.date: 9/21/2023
---

# Implicit method signature translations in .NET interop

To stay programming language agnostic, the Windows COM system and many Windows APIs return a 4 byte integer type called an `HRESULT` to indicate whether an API succeeded or failed, along with some information about the failure. Other values that need to be passed to the caller are "returned" via pointer parameters that act as "out" parameters, and are typically the last parameter in the signature. Languages like C# and Visual Basic traditionally translate a failure code to an exception to match how failures are usually propagated in the language, and expect interop method signatures to not include the `HRESULT`. To translate the method signature to a native signature, the runtime moves the return value of the method to an additional "out" parameter with one more level of indirection (in other words, makes it a pointer to the managed signature's return type), and assumes an `HRESULT` return value. If the managed method returns `void`, no additional parameter is added and the return value becomes an `HRESULT`. For example, see the following two C# COM methods that translate to the same native signature:

```csharp
int Add(int a, int b);

void Add(int a, int b, out int sum);
```

```c
HRESULT Add(int a, int b, /* out */ int* sum);
```

## PreserveSig in COM

All COM methods in C# are expected to use the translated signature by default. To use and export methods without the signature translation and handling of `HRESULT` values, add the <xref:System.Runtime.InteropServices.PreserveSigAttribute> to a COM interface method. When the attribute is applied to a method, no translation is done to the signature, and exceptions aren't thrown for failing `HRESULT` values. This applies to both built-in COM and source-generated COM. For example, see the following C# method signature with a `PreserveSig` attribute and its corresponding native signature.

```csharp
[PreserveSig]
int Add(int a, int b, out int sum);
```

```c
HRESULT Add(int a, int b, int* sum);
```

This can be useful if the method might return different `HRESULT` values that aren't failures, but must be handled differently. For example, some methods might return the value `S_FALSE` when a method doesn't fail but only returns partial results, and `S_OK` when it returns all results.

## `PreserveSig` with P/Invokes

The <xref:System.Runtime.InteropServices.DllImportAttribute> attribute also has the `bool PreserveSig` field that works similarly to the `PreserveSigAttribute`, but defaults to `true`. To indicate that the runtime should translate the managed signature and handle the `HRESULT` that is returned, set the `PreserveSig` field to `false` in the `DllImportAttribute`. For example, see the following signatures of two P/Invokes to the same native method, one with `PreserveSig` set to `false`, and one with it left to the default `true` value.

```csharp
[DllImport("shlwapi.dll", EntryPoint = "SHAutoComplete", ExactSpelling = true, PreserveSig = false)]
public static extern void SHAutoComplete(IntPtr hwndEdit, SHAutoCompleteFlags dwFlags);

[DllImport("shlwapi.dll", EntryPoint = "SHAutoComplete", ExactSpelling = true)]
public static extern int SHAutoCompleteHRESULT(IntPtr hwndEdit, SHAutoCompleteFlags dwFlags);
```

> [!NOTE]
> Source-generated P/Invokes, which use the <xref:System.Runtime.InteropServices.LibraryImportAttribute>, have no `PreserveSig` field. The generated code always assumes the native and managed signature are identical. For more information, see [Source-generated P/Invokes](./pinvoke-source-generation.md#differences-from-dllimport).

## Manually handle `HRESULT` values

When calling a `PreserveSig` method that returns an `HRESULT`, you can use the <xref:System.Runtime.InteropServices.Marshal.ThrowExceptionForHR%2A> method to throw the corresponding exception if the `HRESULT` indicates a failure. Similarly, when implementing a `PreserveSig` method, you can use the <xref:System.Runtime.InteropServices.Marshal.GetHRForException%2A> method to return the `HRESULT` that indicates a corresponding value for the exception.

## Marshal HRESULTs as structs

When using a `PreserveSig` method, `int` is expected to be the managed type for `HRESULT`. However, using a custom 4-byte struct as the return type allows you to define helper methods and properties that can simplify working with the `HRESULT`. In built-in marshalling, this works automatically. To use a struct in place of `int` as the managed representation of `HRESULT` in source-generated marshalling, add the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute with <xref:System.Runtime.InteropServices.UnmanagedType.Error> as the argument. The presence of this attribute reinterprets the bits of the `HRESULT` as the struct.

## See also

- [Handling COM Interop Exceptions](../../standard/exceptions/handling-com-interop-exceptions.md)
- [P/Invokes](./pinvoke.md)
- [Source generated P/Invoke marshalling](./pinvoke-source-generation.md)
- [COM Interop in .NET](./cominterop.md)
