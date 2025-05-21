---
title: Use custom marshallers in source-generated P/Invokes
description: Learn how to use the CustomMarshallerAttribute and implement a custom marshaller for use with source generation.
author: AaronRobinsonMSFT
ms.date: 08/22/2022
helpviewer_keywords:
  - "Interop"
  - "Marshalling"
  - "NativeAOT"
ms.topic: tutorial
---

# Tutorial: Use custom marshallers in source-generated P/Invokes

In this tutorial, you'll learn how to implement a marshaller and use it for [custom marshalling](custom-marshalling-source-generation.md) in [source-generated P/Invokes](pinvoke-source-generation.md).

You'll implement marshallers for a built-in type, customize marshalling for a specific parameter and a user-defined type, and specify default marshalling for a user-defined type.

All source code used in this tutorial is available in the [dotnet/samples repository](https://github.com/dotnet/samples/tree/main/core/interop/source-generation/custom-marshalling).

## Overview of the `LibraryImport` source generator

The [`System.Runtime.InteropServices.LibraryImportAttribute`][api_libraryimportattribute] type is the user entry point for a source generator introduced in .NET 7. This source generator is designed to generate all marshalling code at compile time instead of at run time. Entry points have historically been specified using `DllImport`, but that approach comes with costs that may not always be acceptable&mdash;for more information, see [P/Invoke source generation][pinvoke_source_generation]. The `LibraryImport` source generator can generate all marshalling code and remove the run-time generation requirement intrinsic to `DllImport`.

To express the details needed to generated marshalling code both for the runtime and for users to customize for their own types, several types are needed. The following types are used throughout this tutorial:

- [`MarshalUsingAttribute`][api_marshalusingattribute] &ndash; Attribute that's sought by the source generator at use sites and used to determine the marshaller type for marshalling the attributed variable.

- [`CustomMarshallerAttribute`][api_custommarshallerattribute] &ndash; Attribute used to indicate a marshaller for a type and the mode in which the marshalling operations are to be performed (for example, by-ref from managed to unmanaged).

- [`NativeMarshallingAttribute`][api_nativemarshallingattribute] &ndash; Attribute used to indicate which marshaller to use for the attributed type. This is useful for library authors that provide types and accompanying marshallers for those types.

These attributes, however, aren't the only mechanisms available to a custom marshaller author. The source generator inspects the marshaller itself for various other indications that inform how marshalling should occur.

Complete details on the design can be found in the [dotnet/runtime][design_libraryimport] repository.

### Source generator analyzer and fixer

Along with the source generator itself, an analyzer and fixer are both provided. The analyzer and fixer are enabled and available by default since .NET 7 RC1. The analyzer is designed to help guide developers to use the source generator properly. The fixer provides automated conversions from many `DllImport` patterns into the appropriate `LibraryImport` signature.

## Introducing the native library

Using the `LibraryImport` source generator would mean consuming a native, or unmanaged, library. A native library might be a shared library (that is, `.dll`, `.so`, or `dylib`) that directly calls an operating system API that's not exposed through .NET. The library might also be one that is heavily optimized in an unmanaged language that a .NET developer wants to consume. For this tutorial, you'll build your own shared library that exposes a C-style API surface. The following code represents a user-defined type and two APIs that you'll consume from C#. These two APIs represent the "in" mode, but there are additional modes to explore in the sample.

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

The preceding code contains the two types of interest, `char32_t*` and `error_data`. `char32_t*` represents a string that's encoded in UTF-32, which isn't a string encoding that .NET historically marshals. `error_data` is a user-defined type that contains a 32-bit integer field, a C++ Boolean field, and a UTF-32 encoded string field. Both of these types require you to provide a way for the source generator to generate marshalling code.

## Customize marshalling for a built-in type

Consider the `char32_t*` type first, since marshalling this type is required by the user-defined type. `char32_t*` represents the native side, but you also need representation in managed code. In .NET, there's only one "string" type, `string`. Therefore, you'll be marshalling a native UTF-32 encoded string to and from the `string` type in managed code. There are already several built-in marshallers for the `string` type that marshal as UTF-8, UTF-16, ANSI, and even as the Windows `BSTR` type. However, there isn't one for marshalling as UTF-32. That's what you need to define.

The `Utf32StringMarshaller` type is marked with a `CustomMarshaller` attribute, which describes what it does to the source generator. The first type argument to the attribute is the `string` type, the managed type to marshal, the second is the mode, which indicates when to use the marshaller, and the third type is `Utf32StringMarshaller`, the type to use for marshalling. You can apply the `CustomMarshaller` multiple times to further specify the mode and which marshaller type to use for that mode.

The current example showcases a "stateless" marshaller that takes some input and returns data in the marshalled form. The `Free` method exists for symmetry with the unmanaged marshalling, and the garbage collector is the "free" operation for the managed marshaller. The implementer is free to perform whatever operations are desired to marshal the input to the output, but remember that no state will be explicitly preserved by the source generator.

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

The specifics of how this particular marshaller performs the conversion from `string` to `char32_t*` can be found in the sample. Note that any .NET APIs could be used (for example, <xref:System.Text.Encoding.UTF32?displayProperty=nameWithType>).

Consider a case where state is desirable. Observe the additional `CustomMarshaller` and note the more specific mode, `MarshalMode.ManagedToUnmanagedIn`. This specialized marshaller is implemented as "stateful" and can store state across the interop call. More specialization and state permit optimizations and tailored marshalling for a mode. For example, the source generator can be instructed to provide a stack-allocated buffer that could avoid an explicit allocation during marshalling. To indicate support for a stack-allocated buffer, the marshaller implements a `BufferSize` property and a `FromManaged` method that takes a `Span` of an `unmanaged` type. The `BufferSize` property indicates the amount of stack space&mdash;the length of the `Span` to be passed to `FromManaged`&mdash;the marshaller would like to get during the marshal call.

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

You can now call the first of the two native functions using your UTF-32 string marshallers. The following declaration uses the `LibraryImport` attribute, just like `DllImport`, but relies upon the `MarshalUsing` attribute to tell the source generator which marshaller to use when calling the native function. There's no need to clarify if the stateless or stateful marshaller should be used. This is handled by the implementer defining the `MarshalMode` on the marshaller's `CustomMarshaller` attribute(s). The source generator will select the most appropriate marshaller based on the context in which the `MarshalUsing` is applied, with `MarshalMode.Default` being the fallback.

```csharp
// extern "C" DLL_EXPORT void STDMETHODCALLTYPE PrintString(char32_t* chars);
[LibraryImport(LibName)]
internal static partial void PrintString([MarshalUsing(typeof(Utf32StringMarshaller))] string s);
```

## Customize marshalling for a user-defined type

Marshalling a user-defined type requires defining not only the marshalling logic, but also the type in C# to marshal to/from. Recall the native type we're trying to marshal.

```cpp
struct error_data
{
    int code;
    bool is_fatal_error;
    char32_t* message;    /* UTF-32 encoded string */
};
```

Now, define what it would ideally look like in C#. An `int` is the same size in both modern C++ and in .NET. A `bool` is the canonical example for a Boolean value in .NET. Building on top of `Utf32StringMarshaller`, you can marshal `char32_t*` as a .NET `string`. Accounting for .NET style, the result is the following definition in C#:

```csharp
struct ErrorData
{
    public int Code;
    public bool IsFatalError;
    public string? Message;
}
```

Following the naming pattern, name the marshaller `ErrorDataMarshaller`. Instead of specifying a marshaller for `MarshalMode.Default`, you'll only define marshallers for some modes. In this case, if the marshaller is used for a mode that isn't provided, the source generator will fail. Start with defining a marshaller for the "in" direction. This is a "stateless" marshaller because the marshaller itself only consists of `static` functions.

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

`ErrorDataUnmanaged` mimics the shape of the unmanaged type. The conversion from an `ErrorData` to an `ErrorDataUnmanaged` is now trivial with `Utf32StringMarshaller`.

Marshalling of an `int` is unnecessary since its representation is identical in unmanaged and managed code. A `bool` value's binary representation isn't defined in .NET, so use its current value to define a zero and non-zero value in the unmanaged type. Then, reuse your UTF-32 marshaller to convert the `string` field into a `uint*`.

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

Recall that you're defining this marshaller as an "in", so you must clean up any allocations performed during the marshalling. The `int` and `bool` fields didn't allocate any memory, but the `Message` field did. Reuse `Utf32StringMarshaller` again to clean up the marshalled string.

```csharp
public static void Free(ErrorDataUnmanaged unmanaged)
    => Utf32StringMarshaller.Free(unmanaged.Message);
```

Let's briefly consider the "out" scenario. Consider the case where one or multiple instances of `error_data` are returned.

```c++
extern "C" DLL_EXPORT error_data STDMETHODCALLTYPE GetFatalErrorIfNegative(int code)

extern "C" DLL_EXPORT error_data* STDMETHODCALLTYPE GetErrors(int* codes, int len)
```

```csharp
[LibraryImport(LibName)]
internal static partial ErrorData GetFatalErrorIfNegative(int code);

[LibraryImport(LibName)]
[return: MarshalUsing(CountElementName = "len")]
internal static partial ErrorData[] GetErrors(int[] codes, int len);
```

A P/Invoke that returns a single instance type, non-collection, is categorized as a `MarshalMode.ManagedToUnmanagedOut`. Typically, you use a collection to return multiple elements, and in this case, an `Array` is used. The marshaller for a collection scenario, corresponding to the `MarshalMode.ElementOut` mode, will return multiple elements and is described later.

```csharp
namespace CustomMarshalling
{
    [CustomMarshaller(typeof(ErrorData), MarshalMode.ManagedToUnmanagedIn, typeof(ErrorDataMarshaller))]
    [CustomMarshaller(typeof(ErrorData), MarshalMode.ElementOut, typeof(Out))]
    internal static unsafe class ErrorDataMarshaller
    {
        //
        // Other marshallers removed
        //

        public static class Out
        {
            public static ErrorData ConvertToManaged(ErrorDataUnmanaged unmanaged)
                => throw new NotImplementedException();

            public static ErrorDataUnmanaged ConvertToUnmanaged(ErrorData managed)
                => throw new NotImplementedException();

            public static void Free(ErrorDataUnmanaged unmanaged)
                => throw new NotImplementedException();
        }
    }
}
```

The conversion from `ErrorDataUnmanaged` to `ErrorData` is the inverse of what you did for the "in" mode. Remember that you also need to clean up any allocations that the unmanaged environment expected you to perform. It's also important to note the functions here are marked `static` and are therefore "stateless", being stateless is a requirement for all "Element" modes. You'll also notice that there is a `ConvertToUnmanaged` method like in the "in" mode. All "Element" modes require handling for both "in" and "out" modes.

For the managed to unmanaged "out" marshaller, you're going to do something special. The name of the data type you're marshalling is called `error_data` and .NET typically expresses errors as exceptions. Some errors are more impactful than others and errors identified as "fatal" usually indicate a catastrophic or unrecoverable error. Notice the `error_data` has a field to check if the error is fatal. You'll marshal an `error_data` into managed code, and if it's fatal, you'll throw an exception rather than just converting it into an `ErrorData` and returning it.

```csharp
namespace CustomMarshalling
{
    [CustomMarshaller(typeof(ErrorData), MarshalMode.ManagedToUnmanagedIn, typeof(ErrorDataMarshaller))]
    [CustomMarshaller(typeof(ErrorData), MarshalMode.ElementOut, typeof(Out))]
    [CustomMarshaller(typeof(ErrorData), MarshalMode.ManagedToUnmanagedOut, typeof(ThrowOnFatalErrorOut))]
    internal static unsafe class ErrorDataMarshaller
    {
        //
        // Other marshallers removed
        //

        public static class ThrowOnFatalErrorOut
        {
            public static ErrorData ConvertToManaged(ErrorDataUnmanaged unmanaged)
                => throw new NotImplementedException();

            public static void Free(ErrorDataUnmanaged unmanaged)
                => throw new NotImplementedException();
        }
    }
}
```

An "out" parameter converts from an unmanaged context into a managed context, so you implement the `ConvertToManaged` method. When the unmanaged callee returns and provides an `ErrorDataUnmanaged` object, you can inspect it using your `ElementOut` mode marshaller and check if it's marked as a fatal error. If so, that's your indication to throw instead of just returning the `ErrorData`.

```csharp
public static ErrorData ConvertToManaged(ErrorDataUnmanaged unmanaged)
{
    ErrorData data = Out.ConvertToManaged(unmanaged);
    if (data.IsFatalError)
        throw new ExternalException(data.Message, data.Code);

    return data;
}
```

Perhaps you're not only going to consume the native library, but you also want to share your work with the community and provide an interop library. You can provide `ErrorData` with an implied marshaller whenever it's used in a P/Invoke by adding `[NativeMarshalling(typeof(ErrorDataMarshaller))]` to the `ErrorData` definition. Now, anyone using your definition of this type in a `LibraryImport` call will get the benefit of your marshallers. They can always override your marshallers by using `MarshalUsing` at the use site.

```csharp
[NativeMarshalling(typeof(ErrorDataMarshaller))]
struct ErrorData { ... }
```

## See also

- [P/Invoke source generation](pinvoke-source-generation.md)
- [Custom marshalling source generation](custom-marshalling-source-generation.md)

<!-- links -->

[api_custommarshallerattribute]:/dotnet/api/system.runtime.interopservices.marshalling.custommarshallerattribute
[api_libraryimportattribute]:/dotnet/api/system.runtime.interopservices.libraryimportattribute
[api_marshalusingattribute]:/dotnet/api/system.runtime.interopservices.marshalling.marshalusingattribute
[api_nativemarshallingattribute]:/dotnet/api/system.runtime.interopservices.marshalling.nativemarshallingattribute
[design_libraryimport]:https://github.com/dotnet/runtime/tree/main/docs/design/libraries/LibraryImportGenerator
[pinvoke_source_generation]:pinvoke-source-generation.md
