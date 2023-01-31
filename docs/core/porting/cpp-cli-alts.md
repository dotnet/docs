---
title: Migrating C++/CLI projects to ISO C++ and/or .NET
description: Learn about alternatives to C++/CLI
author: AaronRobinsonMSFT
ms.date: 01/30/2023
---

# Migration from C++/CLI to ISO C++ and/or C\#

The C++/CLI language has been around since 2005 and has enabled users to easily integrate C++ and a .NET language into a single binary. The utility of C++/CLI remains as an innovative way to integrate C++ with the .NET runtime on the Windows platform. There are however limitations to using C++/CLI and as ISO C++ and .NET platforms evolve these limitations are expected to grow.

**Current Limitations**

- Only operates on the Windows platform.

- Limited functional support for the latest ISO C++.

- Limited support for newer .NET types and patterns (for example, [`Span<T>`](/dotnet/api/system.span-1) and [default interface methods](/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods)).

If the above limitations are a concern then this document is intended to provide options on how to transtition from C++/CLI to ISO C++ and/or .NET. The approaches described represent a preference for cross-platform and access to the respective language's entire feature set.

## Expose C++ as C exports

.NET has supported directly calling C code since .NET Framework 1.0 through the [Platform Invoke](/dotnet/standard/native-interop/pinvoke) (P/Invokes) mechanism. All C++ APIs that are expected to be called from .NET could be wrapped in a C-style function. This approach has always worked with .NET but prior to .NET 7, the recommendation was to use [`DllImportAttribute`](/dotnet/api/system.runtime.interopservices.dllimportattribute). Since .NET 7, the [`LibraryImportAttribute`](/dotnet/standard/native-interop/pinvoke-source-generation?source=recommendations) should be prefered in all cases. As it relates to C++/CLI, the `LibraryImportAttribute` mechanism provides a higher performance solution to calling C exports than previously available. Furthermore, the extensibility provided by `LibraryImportAttribute` enables developers to create customized marshalling schemes where they are in full control of how and when data is marshalled across the interop boundary. This is in stark contrast to using `DllImportAttribute` that imposes significant performance penalties if custom marshalling is needed.

Tooling, such as [ClangSharp](https://github.com/dotnet/ClangSharp), exists to help with generating callable native signatures and projecting data types into C#. The [Paint.NET](https://www.getpaint.net/) product successfully transitioned away from C++/CLI using ClangSharp.

### Example

Consider the following C++ class declaration and how to consume it via P/Invokes in C#.

```cpp
class myclass
{
public:
    myclass() = default;
    int get_value()
    {
        return -1;
    }
};

// New C exports
extern "C" __declspec(dllexport) myclass* new_myclass()
{
    return new myclass;
}

extern "C" __declspec(dllexport) void delete_myclass(myclass* mc)
{
    delete mc;
}

extern "C" __declspec(dllexport) int call_get_value(myclass* mc)
{
    return mc->get_value();
}
```

Consumption of the `myclass` type can then occur in C# using P/Invokes.

```csharp
void* mc = new_myclass();
Debug.Assert(mc != null);
Console.WriteLine(call_get_value(mc));
delete_myclass(mc);

[LibraryImport("...")]
static unsafe partial void* new_myclass();
[LibraryImport("...")]
static unsafe partial void delete_myclass(void* mc);
[LibraryImport("...")]
static unsafe partial int call_get_value(void* mc);
```

### Concerns

The wrapping of complex or large C++ APIs to C is tedious and error prone. Source generation techniques can be employed to help create wrapped C APIs, but even this may represent significant effort.

## Expose C++ as `IUnknown` based APIs

Instead of reducing object-oriented concepts down to what can be expressed in C, using [COM interop](/dotnet/standard/native-interop/cominterop) permits keeping some aspects of C++. The .NET platform has a long history of reducing friction when using COM style interfaces. There is existing tools that can help generate COM interface definitions and [cross-platform support](/dotnet/standard/native-interop/tutorial-comwrappers) through the [`ComWrappers`](/dotnet/api/system.runtime.interopservices.comwrappers) API for `IUnknown` interop was enabled in .NET 6.

### Example

```cpp
class myclass
{
public:
    myclass() = default;
    int get_value()
    {
        return -1;
    }
};

// COM interace defintion.
struct
__declspec(uuid("..."))
IMyClass : public IUnknown
{
    HRESULT STDMETHODCALLTYPE GetValue(int* val) = 0;
};

// Instead of a new class, the myclass type itself could
// implement IMyClass.
class MyClass : public IMyClass
{
    std::unique_ptr<myclass> _mc;
public:
    MyClass(std::unique_ptr<myclass> mc)
        : _mc{ std::move(mc) }
    { }
    virtual ~MyClass() = default;

    HRESULT STDMETHODCALLTYPE GetValue(int* val) override
    {
        *val = _mc->get_value();
        return S_OK;
    }

    // See /windows/win32/com/using-and-implementing-iunknown
    HRESULT QueryInterface() override;
    ULONG AddRef() override;
    ULONG Release() override;
};

extern "C" __declspec(dllexport) MyClass* get_myclass()
{
    auto mc = std::make_unique<myclass>();
    return new MyClass(std::move(mc));
}
```

Consumption of the `myclass` type can then occur in C# using COM interop.

```csharp
IMyClass mc = new_myclass();
Debug.Assert(mc != null);
Console.WriteLine(mc.GetValue());

[ComImport]
[Guid("...")]
interface IMyClass
{
    int GetValue();
}

[DllImport("...")]
static unsafe partial IMyClass get_myclass();
```

### Concerns

Defining COM interfaces for a C++ API can be daunting and expensive. There is a lot of boilerplate code for COM interop and does represent an older C++ style that would be pushed into codebases that are forward looking. COM and by extension, COM interop, carry opinionated design considerations and behavior which may make adoption difficult in some scenarios.

## Port C++/CLI to C\#

Converting a C++/CLI project into C# where possible and then calling system APIs via P/Invoke is a common option and the preferred mechanism for the .NET runtime team. This means converting as much C++/CLI as possible into C# and then calling C exports that group logical units of C++. This approach is similar to providing a C API for the entire C++ API previously mentioned.

Tools such as [ILSpy](https://github.com/icsharpcode/ILSpy) have features that can read in .NET metadata/IL and interpret the IL as another .NET language (for example, C#). Some C++/CLI concepts may not directly translate from C++/CLI to other .NET languages so these areas would need to be manually edited.

### Concerns

Porting code from one language to another is time consuming and error prone. It is particularly difficult if domain experts for the library are no longer available. Care must be taken to ensure semantics are properly ported from C++/CLI to C#. Using tooling, like ILSpy, can help tremedously but C++/CLI performs transforms that can make the process difficult. For example, the C++/CLI compiler minimally defines value types in metadata, specifying only size in most cases. Since size is all that is technically needed, field names are removed and computed offsets into fields are used throughout the generated IL instead of metadata tokens.

## Port C++/CLI to ISO C++

Converting a C++/CLI project into ISO C++ may be more appropriate if the majority of the code is using ISO C++ rather than managed code. Since C++/CLI is closer to ISO C++ than C# it is potentially an easier path and tools exist to help with creating the boilerplate needed to call .NET code from C++.

A [tutorial exists](/dotnet/core/tutorials/netcore-hosting) for using the .NET unmanaged hosting layer, which can be used to manually activate a .NET runtime instance. An example of tooling that uses this API to create exports callable by C or C++ is [DNNE](https://github.com/AaronRobinsonMSFT/DNNE). An alternative to using the unmanaged hosting API, is to use [NativeAOT](/dotnet/core/deploying/native-aot/) to create a library with unmanaged exports&mdash;see [sample](https://github.com/dotnet/samples/blob/main/core/nativeaot/NativeLibrary/README.md).

## Conclusion

 C++/CLI will continue to be supported and represents a novel solution for integrating .NET and ISO C++. There are limitations with the technology and that may necessitate considering the longer term costs of maintain deep dependencies on C++/CLI. None of the above options are cheap or come with zero risk and it is important for all owners of C++/CLI dependent applications to weight the costs and consider whether moving to a combination of ISO C++ and .NET is appropriate.
