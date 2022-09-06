---
title: Use custom marshallers in source-generated P/Invokes
description: Learn how to use the CustomMarshallerAttribute and implement a custom marshaller for use with source generation.
author: AaronRobinsonMSFT
ms.date: 08/22/2022
helpviewer_keywords:
  - "Interop"
  - "Marshalling"
  - "NativeAOT"
---

# Tutorial: Use custom marshallers in source-generated P/Invokes

In this tutorial, you'll learn how to implement a marshaller and use it for [custom marshalling](custom-marshalling-source-generation.md) in [source-generated P/Invokes](pinvoke-source-generation.md).

We will implement marshallers for a built-in type, customize marshalling for a specific parameter, and a user-defined type, specify default marshalling for a user-defined type.

All source code used in this tutorial is available in the [dotnet/samples repository](https://github.com/dotnet/samples/tree/main/core/interop/source-generation/custom-marshalling).

## Overview of the `LibraryImportAttribute` source generator

The `LibraryImportAttribute` is the user entry point for a source generator introduced in .NET 7. This new source generator is designed to generate all marshalling code at compile-time instead of at run-time. This has historically been done using `DllImport`, but that approach comes with costs that may not always be acceptable. The most important cost is generation of marshalling code at run-time. This cost can be measured in terms of application performance but also in terms of potential target platforms that may not support dynamic code generation. The NativeAOT application model addresses issues with dynamic code generation by precompiling all code ahead of time directly into native code. Using `DllImport` is therefore not an option because of its run-time generation semantics. The `LibraryImportAttribute` source generator can generate all marshalling code and remove the run-time generation requirement intrinsic to `DllImport`.

In order to express the details needed to generated marshalling code both for the runtime and for users to customize for their own types, several types are needed. The following types will be used throughout this tutorial.

* [`MarshalUsingAttribute`][api_marshalusingattribute] &ndash; Looked for by the source generator at use sites and used to determine the marshaller type used for marshalling the attributed variable.

* [`CustomMarshallerAttribute`][api_custommarshallerattribute] &ndash; Attribute used to indicate a marshaller for a type, along with the mode in which the marshalling operations is to be performed (for example, by-ref from managed to unmanaged).

* [`NativeMarshallingAttribute`][api_nativemarshallingattribute] &ndash; Used to indicate what marshaller to use for the attributed type. This is useful for the library authors that provide types and accompanying marshallers for those types.

These attributes, however are not the only mechanisms available to the custom marshaller author, the source generator insepct the marshaller itself for various other indications that inform how marshalling should occur.

Complete details on the design can be found in the [dotnet/runtime](https://github.com/dotnet/runtime/tree/main/docs/design/libraries/LibraryImportGenerator) repository.

## Introducing the native library

Using the `LibraryImportAttribute` source generator would mean consuming a native, or unmanaged, library. A native library might be a shared library (that is, `.dll`, `.so`, or `dylib`) that directly calls an operating system API, not exposed through .NET, or one that is heavily optimized in an unmanaged language that a .NET developer wants to consume. For this tutorial we are going to build our own shared library that exposes a C style API surface. The below represents a user defined type and two APIs that we would like to consume from C#. These two APIs represent the "in" scenario, but there are additional scenarios to explore in the sample.

```cpp
struct error_data
{
    int code;
    bool is_fatal_error;
    char32_t* message;    /* UTF-32 encoded string */
};

extern "C" DLL_EXPORT void STDMETHODCALLTYPE PrintString(char32_t* chars);

extern "C" DLL_EXPORT void STDMETHODCALLTYPE PrintErrorData(error_data data);
```

The above contains the two types of interest, `char32_t*` and `error_data`. The latter represents a string that is encoded in UTF-32, not an string encoding .NET historically marshals, and a user defined type containing a 32-bit integer field, a C++ boolean field, and a UTF-32 encoded string field. Both of these types will require us to provide a way for the source generator to generate marshalling code.

## Customize marshalling for a built-in type

Let's look at the `char32_t*` type first, since marshalling this is required by the user-defined type. We should note that `char32_t*` represents the native side, but we also need representation in managed code. In .NET, there is only one "string" type, `string`. Therefore we will be marshalling a native UTF-32 encoded string to and from the `string` type in managed code. There are already several built-in marshallers for the `string` type that will marshal as UTF-8, UTF-16, ANSI, and even as the Windows `BSTR` type. However, there isn't one for marshalling as UTF-32. That is what we need to define.

The `Utf32StringMarshaller` type has an instance of the `CustomMarshaller`, which helps to described what it does to for the source generator. Note the first type argument to the attribute is the `string` type, the managed type to marshal, the mode is next, which indicates when to use the marshaller, third type, `Utf32StringMarshaller`. Multiple instances of `CustomMarshaller` can be provided and further specify the mode and what marshaller type to use. The current example showcases a "stateless" marshaller that will take some input and return a data in the marshalled form. The `Free` method exists for symmetry with the unmanaged marshalling, the garbage collector is the "free" operation for the managed marshaller. The implementer is free to perform what operations are desired to marshal the input to the output, but remember no state will be explicitly preserved by the source generator.

The specifics of how this particular marshaller performs the conversion from `string` to `char32_t*` can be found in the sample, note though that any .NET APIs could be used (for example, [`Encoding.UTF32`](https://docs.microsoft.com/dotnet/api/system.text.encoding.utf32)).


```csharp
namespace CustomMarshalling
{
    [CustomMarshaller(typeof(string), MarshalMode.Default, typeof(Utf32StringMarshaller))]
    internal static unsafe class Utf32StringMarshaller
    {
        public static uint* ConvertToUnmanaged(string? managed)
            => throw new NotImplementedException();

        public static string? ConvertToManaged(uint* unmanaged)
            => throw new NotImplementedException();

        public static void Free(uint* unmanaged)
            => throw new NotImplementedException();
    }
}
```

Let's consider a case where state is desirable. Observe the additional `CustomMarshaller` and note the more specific mode, `MarshalMode.ManagedToUnmanagedIn`. This specialized marshaller is implemented as "stateful" and can store state across the interop call. More specialization and state permit optimizations and tailored marshalling for a mode. For example, the source generator can be instructed to provide a reasonable sized stack allocation that could avoid an explicit allocation during marshalling. The allocated buffer is requested by the marshaller when the source generator discovers a `BufferSize` property. This property indicates the amount of stack space the marshaller would like to get during the marshal call.

```csharp
namespace CustomMarshalling
{
    [CustomMarshaller(typeof(string), MarshalMode.Default, typeof(Utf32StringMarshaller))]
    [CustomMarshaller(typeof(string), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToUnmanagedIn))]
    internal static unsafe class Utf32StringMarshaller
    {
        //
        // Stateless functions removed
        //

        public ref struct ManagedToUnmanagedIn
        {
            public static int BufferSize => 0x100;

            private uint* _unmanagedValue;
            private bool _allocated; // Used stack alloc or allocated other memory

            public void FromManaged(string? managed, Span<byte> buffer)
                => throw new NotImplementedException();

            public uint* ToUnmanaged()
                => throw new NotImplementedException();

            public void Free()
                => throw new NotImplementedException();
        }
    }
}
```

The first of our two native functions can now be called using our UTF-32 string marshallers. The below declaration uses the `LibraryImport` attribute, just like `DllImport`, but relies upon the `MarshalUsing` to instruct the source generator what marshaller to use when calling the native function. There is no need to clarify if the stateless or stateful marshaller should be used. This is handled by the implementer defining the "mode" on the marshaller. The source generator will select the most appropriate marshaller based on the context in which the `MarshalUsing` is applied, `MarshalMode.Default` being the fallback.

```csharp
// extern "C" DLL_EXPORT void STDMETHODCALLTYPE PrintString(char32_t* chars);
[LibraryImport(LibName)]
internal static partial void PrintString([MarshalUsing(typeof(Utf32StringMarshaller))] string s);
```

## Customize marshalling for a user-defined type

Marshalling a user-defined type requires defining not only the marshalling logic, but also the type in C# to marshal to/from. Let's recall the native type we are trying to marshal and define what it would ideally look like in C#.

```cpp
struct error_data
{
    int code;
    bool is_fatal_error;
    char32_t* message;    /* UTF-32 encoded string */
};
```

An `int` is the same size in both modern C++ and in .NET. A `bool` is the canonical example for a boolean value in .NET. Building on top of `Utf32StringMarshaller`, we can marshal `char32_t*` as a .NET `string`. Accounting for .NET style the result is the following definition in C#.

```csharp
struct ErrorData
{
    public int Code;
    public bool IsFatalError;
    public string? Message;
}
```

Following the naming pattern, we will name the marshaller `ErrorDataMarshaller`. Instead of creating a default marshaller, we will instead define only an "in", "out", and collection based marshaller for this type. This will demonstrate the case where if a scenario isn't provided, the source generator will fail. Let's start with the "in" direction.

```csharp
namespace CustomMarshalling
{
    [CustomMarshaller(typeof(ErrorData), MarshalMode.ManagedToUnmanagedIn, typeof(ErrorDataMarshaller))]
    internal static unsafe class ErrorDataMarshaller
    {
        // Unmanaged representation of ErrorData.
        // Should mimic the unmanaged error_data type at a binary level.
        internal struct ErrorDataUnmanaged
        {
            public int Code;        // .NET doesn't support less than 32-bit, so int is 32-bit.
            public byte IsFatal;    // The C++ bool is defined as a single byte.
            public uint* Message;   // This could be as simple as a void*, but uint* is closer.
        }

        public static ErrorDataUnmanaged ConvertToUnmanaged(ErrorData managed)
            => throw new NotImplementedException();

        public static void Free(ErrorDataUnmanaged unmanaged)
            => throw new NotImplementedException();
    }
}
```

The conversion from an `ErrorData` to a `ErrorDataUnmanaged`, that will mimic the shape of the unmanaged type is trivial with `Utf32StringMarshaller`.

```csharp
public static ErrorDataUnmanaged ConvertToUnmanaged(ErrorData managed)
{
    return new ErrorDataUnmanaged
    {
        Code = managed.Code,
        IsFatal = (byte)(managed.IsFatalError ? 1 : 0),
        Message = Utf32StringMarshaller.ConvertToUnmanaged(managed.Message),
    };
}
```

[CustomMarshaller(typeof(ErrorData), MarshalMode.ManagedToUnmanagedOut, typeof(ThrowOnFatalErrorOut))]
[CustomMarshaller(typeof(ErrorData), MarshalMode.ElementOut, typeof(Out))]

    public static class Out
    {
        public static ErrorData ConvertToManaged(ErrorDataUnmanaged unmanaged)
            => throw new NotImplementedException();

        public static void Free(ErrorDataUnmanaged unmanaged)
            => throw new NotImplementedException();
    }

    public static class ThrowOnFatalErrorOut
    {
        public static ErrorData ConvertToManaged(ErrorDataUnmanaged unmanaged)
            => throw new NotImplementedException();

        public static void Free(ErrorDataUnmanaged unmanaged)
            => throw new NotImplementedException();
    }


Let us assume we are not only going to consume the native library, but we are also going to share our work with the community and provide an interop library. This means we could provide `ErrorData` an implied marshaller whenever it is used in a P/Invoke by adding `[NativeMarshalling(typeof(ErrorDataMarshaller))]` to the `ErrorData` definition.

```csharp
[NativeMarshalling(typeof(ErrorDataMarshaller))]
struct ErrorData { ... }
```

## `LibraryImportAttribute` source generator Analyzer and Fixer

  <!-- links -->

[api_custommarshallerattribute]:https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.marshalling.custommarshallerattribute
[api_marshalusingattribute]:https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.marshalling.marshalusingattribute
[api_nativemarshallingattribute]:https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.marshalling.nativemarshallingattribute