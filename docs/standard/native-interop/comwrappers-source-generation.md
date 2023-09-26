---
title: ComWrappers source generation
description: Learn about compile-time source generation for ComWrappers in .NET.
ms.date: 08/25/2023
---

# Source Generation for ComWrappers

.NET 8 introduces a source generator that creates an implementation of the [ComWrappers](./com-wrappers.md) API for you. The generator recognizes the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute>.

The .NET runtime's built-in (not source-generated), Windows-only, COM interop system generates an IL stub&mdash;a stream of IL instructions that is JIT-ed&mdash;at run-time to facilitate the transition from managed code to COM, and vice-versa. Since this IL stub is generated at run-time, it isn't compatible with [NativeAOT](../../core/deploying/native-aot/index.md), or [IL trimming](../../core/deploying/trimming/trim-self-contained.md). Stub generation at run-time can also make diagnosing marshalling issues difficult.

Built-in interop uses attributes such as `ComImport` or `DllImport`, which rely on code generation at run-time. The following code shows an example of this:

```csharp
[ComImport]
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
IFoo foo = (IFoo)Marshal.GetObjectForIUnknown(ptr);
foo.Method(0);
...
// Use the system to create a COM Callable Wrapper to pass to unmanaged code
IFoo foo = GetManagedIFoo();
nint ptr = Marshal.GetIUnknownForObject(foo);
GivePointerToComInterface(ptr);
```

The `ComWrappers` API enables interacting with COM in C# without using the built-in COM system, but [requires substantial boilerplate and hand-written unsafe code](./tutorial-comwrappers.md). The COM interface generator automates this process and makes `ComWrappers` as easy as built-in COM, but delivers it in a trimmable and AOT-friendly manner.

## Basic usage

To use the COM interface generator, add the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> and <xref:System.Runtime.InteropServices.GuidAttribute> attributes on the interface definition that you want to import from or expose to COM. The type must be marked `partial` and have `internal` or `public` visibility for the generated code to be able to access it.

```csharp
[GeneratedComInterface]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
internal partial IFoo
{
    void Method(int i);
}
```

Then, to expose a class that implements an interface to COM, add the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> to the implementing class. This class will also need to be `partial` and either `internal` or `public`.

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

At compile time, the generator will create an implementation of the ComWrappers API, and you can use the <xref:System.Runtime.InteropServices.Marshalling.StrategyBasedComWrappers> type or a custom derived type to consume or expose the COM interface.

```csharp
[LibraryImport("MyComObjectProvider.dll")]
static nint GetPointerToComInterface();

[LibraryImport("MyComObjectProvider.dll")]
static void GivePointerToComInterface(nint comObject);

// Use the ComWrappers API to create a Runtime Callable Wrapper to use in managed code
ComWrappers cw = new StrategyBasedComWrappers();
nint ptr = GetPointerToComInterface();
IFoo foo = (IFoo)cw.GetOrCreateObjectForComInterface(ptr);
foo.Method(0);
...
// Use the system to create a COM Callable Wrapper to pass to unmanaged code
ComWrappers cw = new StrategyBasedComWrappers();
Foo foo = new();
nint ptr = cw.GetOrCreateComInterfaceForObject(foo);
GivePointerToComInterface(ptr);
```

## Customizing marshalling

The COM interface generator respects the <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> and some usages of <xref:System.Runtime.InteropServices.MarshalAsAttribute> attributes to customize marshalling of parameters. For more information, see how to [customize source-generated marshalling with the `MarshalUsing` attribute](./custom-marshalling-source-generation.md) and [customize parameter marshalling with the `MarshalAs` attribute](./customize-parameter-marshalling.md). If an interface has `string` parameters or return types, the <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute.StringMarshalling?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute.StringMarshallingCustomType?displayProperty=nameWithType> properties will apply to all parameters and return types of `string` in the interface if they don't have other marshalling attributes.

## Implicit HRESULTs and PreserveSig

COM methods in C# have a different signature than the native methods. Standard COM has a return type of `HRESULT`, a 4 byte integer type representing error and success states. This `HRESULT` return value is hidden by default in the C# signature and converted to an exception when an error value is returned. The last "out" parameter of the native COM signature may optionally be converted into the return in the C# signature.

For example, the following snippets show C# method signatures and the corresponding native signature the generator infers.

```csharp
void Method1(int i);

int Method2(float i);
```

```c
HRESULT Method1(int i);

HRESULT Method2(float i, _Out_ int* returnValue);
```

If you want to handle the `HRESULT` yourself, you can use the <xref:System.Runtime.InteropServices.PreserveSigAttribute> on the method to indicate the generator should not do this transformation. Below are snippets that demonstrate what native signature the generator expects when `[PreserveSig]` is applied. COM methods must return `HRESULT`, so the return value of any method with `PreserveSig` should be `int`.

```csharp
[PreserveSig]
int Method1(int i, out int j);

[PreserveSig]
int Method2(float i);
```

```c
HRESULT Method1(int i, int* j);

HRESULT Method2(float i);
```

For more information, see [Implicit method signature translations in .NET interop](./preserve-sig.md)

## Incompatibilities and differences to built-in COM

### IUnknown only

The only supported interface base is [IUnknown](/windows/win32/api/unknwn/nn-unknwn-iunknown). Interfaces with an <xref:System.Runtime.InteropServices.InterfaceTypeAttribute> with a value other values than <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIUnknown> are not supported in source-generated COM. Any interfaces without an `InterfaceTypeAttribute` are assumed to derive from `IUnknown`. This differs from built-in COM where the default is <xref:System.Runtime.InteropServices.ComInterfaceType.InterfaceIsDual>.

## Marshalling defaults and support

Source-generated COM has some different default marshalling behaviors from built in COM.

- In the built-in COM system, all types had an implicit `[In]` attribute except for arrays of blittable elements, which had implicit `[In, Out]` attributes. In source-generated COM, all types, including arrays of blittable elements, have `[In]` semantics.

- `[In]` and `[Out]` attributes are only allowed on arrays. If `[Out]` or `[In, Out]` behavior is required on other types, use the `in` and `out` parameter modifiers.

### Derived interfaces

In the built-in COM system, if you had interfaces which derived from other COM interfaces, you would need to declare a shadowing method for each base method on the base interfaces with the `new` keyword. See [COM interface inheritance and .NET](./qualify-net-types-for-interoperation.md#com-interface-inheritance-and-net) for more information.

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

The COM interface generator does not expect any shadowing of base methods. To create a method that inherits from another, simply indicate the base interface as a C# base interface and add the derived interface's methods. See [the design doc](https://github.com/dotnet/runtime/blob/main/docs/design/libraries/ComInterfaceGenerator/DerivedComInterfaces.md) for more information.

```csharp
[GeneratedComInterface]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
interface IBase
{
    void Method1(int i);
    void Method2(float i);
}

[GeneratedComInterface]
[Guid("3faca0d2-e7f1-4e9c-82a6-404fd6e0aab8")]
interface IDerived : IBase
{
    void Method3(long l);
    void Method4(double d);
}
```

Note that an interface with the `GeneratedComInterface` attribute can only inherit from one base interface that has the `GeneratedComInterface` attribute.

### Marshal APIs

Some APIs in <xref:System.Runtime.InteropServices.Marshal> are not compatible with source-generated COM. These methods should be replaced with their corresponding methods on a `ComWrappers` implementation.

## See also

- [ComWrappers](./com-wrappers.md)
- [Customizing Parameter Marshalling](./customize-parameter-marshalling.md)
- [Runtime Callable Wrapper](runtime-callable-wrapper.md)
- [COM Callable Wrapper](com-callable-wrapper.md)
