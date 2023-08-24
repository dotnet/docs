---
title: COM wrappers source generation
description: Learn about compile-time source generation for COM wrappers in .NET.
ms.date: 08/25/2023
---

# Source Generation for COM Wrappers

.Net 8 introduces a source generator that creates an implementation of the [COM wrappers](./com-wrappers.md) API for you. The generator recognizes the <xref:System.Runtime.InteropServices.GeneratedComInterfaceAttribute>.

The .Net runtime's built-in (not source generated) COM interop system generates an IL stub&mdash;a stream of IL instructions that is JIT-ed&mdash;at run time to facilitate the transition from managed code to COM, and vice-versa, on Windows only. Since this IL stub is generated at run time, it isn't compatible with [NativeAOT](../../core/deploying/native-aot/index.md), or [IL trimming](../../core/deploying/trimming/trim-self-contained.md). Generating the IL stub also takes CPU time, and can be difficult to debug when issues arise.

Code using the built in system might look like the following:

```csharp
[ComImport]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
interface IFoo
{
    void Method(int i);
}

[DllImport("MyComObjectProvider.dll")]
static nint GetPointerToComInterface();

[DllImport("MyComObjectProvider.dll")]
static void GivePointerToComInterface(nint comObject);

// Use the system to create a Runtime Callable Wrapper to use in managed code
nint ptr = GetPointerToComInterface();
IFoo foo = Marshal.GetObjectForIUnknown(ptr);
foo.Method(0);
...
// Use the system to create a COM Callable Wrapper to pass to unmanaged code
IFoo foo = GetManagedIFoo();
nint ptr = Marshal.GetIUnknownForObject(foo);
GivePointerToComInterface(nint ptr);
```

The COM wrappers API enables interacting with COM in C# without using the the built-in COM system, but requires lots of boilerplate and hand written unsafe code. The COM interface generator automates that process and makes COM wrappers as easy as built-in COM.

## Basic Usage

To use the COM interface generator, add a <xref:System.Runtime.InteropServices.GeneratedComInterfaceAttribute> and <xref:System.Runtime.InteropServices.GuidAttribute> on the interface definition that you want to import from COM or expose to COM. The type will also need to be `partial` and have `internal` or `public` visibility for the generated code to be able to access it.

```csharp
[GeneratedComInterface]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
internal partial IFoo
{
    void Method(int i);
}
```
Then, if you want to expose a class that implements an interface to COM, add the <xref:System.Runtime.InteropServices.GeneratedComClassAttribute> to the implementing class. This class will also need to be `partial` and either `internal` or `public`.

```csharp
[GeneratedComClass]
internal partial class Foo : IFoo
{
    public void Method(int i)
    {
        // Do things
    }
}
```

At compile time, the generator will create an implementation of the COM wrappers API, and you can use the <xref:System.Runtime.InteropServices.StrategyBasedComWrappers> type or a custom derived type to consume or expose the COM interface.

```csharp
[LibraryImport("MyComObjectProvider.dll")]
static nint GetPointerToComInterface();

[LibraryImport("MyComObjectProvider.dll")]
static void GivePointerToComInterface(nint comObject);

// Use the system to create a Runtime Callable Wrapper to use in managed code
ComWrappers cw = new StrategyBasedComWrappers();
nint ptr = GetPointerToComInterface();
IFoo foo = cw.GetOrCreateObjectForComInterface(ptr);
foo.Method(0);
...
// Use the system to create a COM Callable Wrapper to pass to unmanaged code
ComWrappers cw = new StrategyBasedComWrappers();
Foo foo = new Foo();
nint ptr = cw.GetOrCreateComInterfaceForObject(foo);
GivePointerToComInterface(nint ptr);
```

## Customizing Marshalling

The COM interface generator respects the <xref:System.Runtime.InteropServices.Marshalling.MarshalAsAttribute> and <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> attributes to customize marshalling of parameters. For more information, see [Customize Parameter Marshalling](./customize-parameter-marshalling.md) If an interface uses `string`s, GeneratedComInterfaceAttribute has StringMarshalling and StringMarshallingCustomType properties that will apply to all parameters and return types of `string` in the interface if they don't have other marshalling attributes.

## Implicit HRESULTs and PreserveSig
COM methods in C# have a different signature than the native methods. Standard COM has a return type of HRESULT, a 4 byte code representing error and success states. This return value is hidden in the C# signature. The C# return value is converted into an additional parameter in the native signature, and the HRESULT is handled by the generated code, which will throw an exception if the HRESULT is an error value.

For example, the following snippets show C# method signatures and the corresponding native signature the generator infers.

```csharp
void Method1(int i);

int Method2(float i);
```

```c
HRESULT Method1(int i);

HRESULT Method2(float i, int* returnValue);
```

If you want to handle the HRESULT yourself, you can use the <xref:System.Runtime.InteropServices.PreserveSigAttribute> on the method to indicate the generator should not do this transformation. Below are snippets that demonstrate what native signature the generator expects when `[PreserveSig]` is applied.

```csharp
[PreserveSig]
void Method1(int i);

[PreserveSig]
int Method2(float i);
```

```c
int Method1(int i);

int Method2(float i);
```

## Incompatibilities and Differences to Built-In COM

### Derived Interfaces

In the built in COM system, if you had interfaces which derived from other COM interfaces, you would need to declare a shadowing method for each base method on the base interfaces with the `new` keyword.

```csharp
[ComImport]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
interface IBase
{
    void Method1(int i);
    void Method2(float i);
}

[ComImport]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
interface IDerived : IBase
{
    new void Method1(int i);
    new void Method2(float f);
    void Method3(long l);
    void Method4(double d);
}
```

The COM interface generator does not expect any shadowing of base methods.

### Marshal APIs

The APIs in <xref:System.Runtime.InteropServices.Marshal> are not compatible with source generated COM. These methods should be replaced with their corresponding methods on StrategyBasedComWrappers.

## See also

- [COM Wrappers](./com-wrappers.md)
- [Customizing Parameter Marshalling](./customize-parameter-marshalling.md)
- [Advanced COM Interoperability in .NET Framework](/previous-versions/dotnet/netframework-4.0/bd9cdfyx(v=vs.100))
- [Runtime Callable Wrapper](runtime-callable-wrapper.md)
- [COM Callable Wrapper](com-callable-wrapper.md)
- [Customizing Standard Wrappers in .NET Framework](/previous-versions/dotnet/netframework-4.0/h7hx9abd(v=vs.100))
- [How to: Customize Runtime Callable Wrappers in .NET Framework](/previous-versions/dotnet/netframework-4.0/56kh4hy7(v=vs.100))
