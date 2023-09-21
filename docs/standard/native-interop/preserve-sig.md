---
title: Implicit native signature translations and PreserveSig in .NET
description: Learn how managed signatures translate to native signatures for interop methods in .NET
ms.date: 9/21/2023
---

# Implicit method signature translations in .NET

In order to stay programming language agnostic, the Windows COM system and many Windows APIs return a 4 byte error code called an HRESULT to indicate whether an API succeeded or failed, along with some information about the failure. Other values that need to be passed to the caller are "returned" via pointer parameters that act as `out` parameters, and are typically the last parameter in the signature. Languages like C#, Visual Basic, and Java traditionally translate a failure code to an exception to match how failures are usually propagated in the language, and the `out` parameter was treated as the return value in the signature of the managed langauge representation. For example, see below a native COM method signature and its corresponding C# signature.

```c
HRESULT Add(int a, int b, /* out */ int* sum);
```

```csharp
int Add(int a, int b);
```

## PreserveSig in COM

All COM methods in C# are expected to use the translated signature by default. In order to use and export methods without the translation, add the <xref:System.Runtime.InteropServices.PreserveSigAttribute> to a COM interface method. When the attribute is applied to a method, no translation is done to the signature. This applied to both built-in COM and source-generated COM. For example, see below the C# method signature with a `PreserveSig` attribute and its corresponding native signature.

```csharp
[PreserveSig]
int Add(int a, int b, out int sum);
```

```c
int Add(int a, int b, int* sum);
```

## PreserveSig with P/Invokes

The platform invoke attributes (<xref:System.Runtime.InteropServices.LibraryImportAttribute> and <xref:System.Runtime.InteropServices.DllImportAttribute>) both have a `bool` field named `PreserveSig` that works similarly to the `PreserveSigAttribute`, but defaults to `true`. If you want to use the translated signature with a P/Invoke that returns an HRESULT in the native signature, set the PreserveSig field to true in the `LibraryImportAttribute` or `DllImportAttribute`. For example, see below the signature of a P/Invoke to the same method with `PreserveSig` set to `false`, and with it left to the default `true` value.

```csharp
[LibraryImportAttribute("shlwapi.dll", EntryPoint = "SHAutoComplete", ExactSpelling = true, PreserveSig = false)]
public static extern void SHAutoComplete(IntPtr hwndEdit, SHAutoCompleteFlags dwFlags);

[DllImportAttribute("shlwapi.dll", EntryPoint = "SHAutoComplete", ExactSpelling = true)]
public static extern int SHAutoCompleteHRESULT(IntPtr hwndEdit, SHAutoCompleteFlags dwFlags);
```
