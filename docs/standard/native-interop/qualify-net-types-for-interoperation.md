---
title: "Qualifying .NET Types for COM Interoperation"
description: This article provides guidelines to help you expose types in a .NET assembly to COM applications for COM interop.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "exposing .NET components to COM"
  - "COM interop, qualifying .NET types"
  - "qualifying .NET types for interoperation"
  - "interoperation with unmanaged code, qualifying .NET types"
  - "interoperation with unmanaged code, exposing .NET components"
  - "COM interop, exposing COM components"
ms.assetid: 4b8afb52-fb8d-4e65-b47c-fd82956a3cdd
---
# Qualifying .NET Types for COM Interoperation

## Exposing .NET Types to COM

If you intend to expose types in an assembly to COM applications, consider the requirements of COM interop at design time. Managed types (class, interface, structure, and enumeration) seamlessly integrate with COM types when you adhere to the following guidelines:  
  
- Classes should implement interfaces explicitly.  
  
     Although COM interop provides a mechanism to automatically generate an interface containing all members of the class and the members of its base class, it is far better to provide explicit interfaces. The automatically generated interface is called the class interface. For guidelines, see [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface).  
  
     You can use Visual Basic, C#, and C++ to incorporate interface definitions in your code, instead of having to use Interface Definition Language (IDL) or its equivalent. For syntax details, see your language documentation.  
  
- Managed types must be public.  
  
     Only public types in an assembly are registered and exported to the type library. As a result, only public types are visible to COM.  
  
     Managed types expose features to other managed code that might not be exposed to COM. For instance, parameterized constructors, static methods, and constant fields are not exposed to COM clients. Further, as the runtime marshals data in and out of a type, the data might be copied or transformed.  
  
- Methods, properties, fields, and events must be public.  
  
     Members of public types must also be public if they are to be visible to COM. You can restrict the visibility of an assembly, a public type, or public members of a public type by applying the <xref:System.Runtime.InteropServices.ComVisibleAttribute>. By default, all public types and members are visible.  
  
- Types must have a public parameterless constructor to be activated from COM.  
  
     Managed, public types are visible to COM. However, without a public parameterless constructor (a constructor with no arguments), COM clients cannot create the type. COM clients can still use the type if it is activated by some other means.  
  
- Types cannot be abstract.  
  
     Neither COM clients nor .NET clients can create abstract types.  
  
 When exported to COM, the inheritance hierarchy of a managed type is flattened. Versioning also differs between managed and unmanaged environments. Types exposed to COM do not have the same versioning characteristics as other managed types.  

## Consuming COM types from .NET

If you intend to consume COM types from .NET and you do not want to use tools like [Tlbimp.exe (Type Library Importer)](../../../framework/tools/tlbimp-exe-type-library-importer.md), you must follow these guidelines:

- Interfaces must have the <xref:System.Runtime.InteropServices.ComImportAttribute> applied.
- Interfaces must have the <xref:System.Runtime.InteropServices.GuidAttribute> applied with the Interface ID for the COM interface.
- Interfaces should have the <xref:System.Runtime.InteropServices.InterfaceTypeAttribute> applied to specify the base interface type of this interface (IUnknown, IDispatch, or IInspectable).
  - The default option is to have the base type of IDispatch and append the declared methods to the expected virtual function table for the interface.
  - Only .NET Framework supports specifying a base type of IInspectable.

Many more customization options exist and they are mentioned in the [Applying Interop Attributes](apply-interop-attributes.md) documentation, but these guidelines provide the minimum requirements for common scenarios.

### Defining COM interfaces in .NET

When .NET code tries to call a method on a COM object through an interface with the <xref:System.Runtime.InteropServices.ComImportAttribute>, it needs to build up a virtual function table (also known as vtable or vftable) to from the .NET definition of the interface to determine the native code to call. This process is very complex, but we can look at some simple cases to see how it works.

We will start with a COM interface with a few methods:

```c++
struct IComInterface : public IUnknown
{
    STDMETHOD(Method)() = 0;
    STDMETHOD(Method2)() = 0;
};
```

For this interface, the following table describes its virtual function table layout:

| `IComInterface` Virtual Function Table slot | Method name |
|-----------------------------|-------------|
| 0 | `IUnknown::QueryInterface` |
| 1 | `IUnknown::AddRef` |
| 2 | `IUnknown::Release` |
| 3 | `IComInterface::Method` |
| 4 | `IComInterface::Method2` |

As we see, each method is added to the virtual function table in the order it was declared. The particular order is defined by the C++ compiler, but for simple cases without overloads, declaration order defines the order in the table.

To declare a .NET interface that corresponds to this interface, we would declare it as follows:

```csharp
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid(/* The IID for IComInterface */)]
interface IComInterface
{
    void Method();
    void Method2();
}
```

The <xref:System.Runtime.InteropServices.InterfaceTypeAttribute> specifies the base interface. It provides a few options:

| <xref:System.Runtime.InteropServices.ComInterfaceType> Value | Base Interface Type | Behavior for members on attributed interface |
|------------|---------------|------------------|
| `InterfaceIsIUnknown` | `IUnknown` | Virtual function table first has the members of `IUnknown`, then the members of this interface in declaration order. |
| `InterfaceIsIDispatch` | `IDispatch` | Members are not added to the virtual function table. They are only accessible through `IDispatch` |
| `InterfaceIsDual` | `IDispatch` | Virtual function table first has the members of `IDispatch`, then the members of this interface in declaration order. |
| `InterfaceIsIInspectable` | `IInspectable` | Virtual function table first has the members of `IInspectable`, then the members of this interface in declaration order. Only supported on .NET Framework. |

#### COM Interface Inheritance and .NET

The COM interop system that uses the <xref:System.Runtime.InteropServices.ComImportAttribute> does not interact with interface inheritance, so it can cause unexpected behavior unless the some mitigating steps are taken.

##### COM Interface Inheritance in C++

In C++, developers can declare COM interfaces that derive from other COM interfaces as follows:

```cpp
struct IComInterface : public IUnknown
{
    STDMETHOD(Method)() = 0;
    STDMETHOD(Method2)() = 0;
};

struct IComInterface2 : public IComInterface
{
    STDMETHOD(Method3)() = 0;
};
```

This declaration style is regularly as a mechanism to add methods to COM objects without changing existing interfaces, which would be a breaking change. This inheritance mechanism results in the following virtual function table layouts:

| `IComInterface` Virtual Function Table slot | Method name |
|-----------------------------|-------------|
| 0 | `IUnknown::QueryInterface` |
| 1 | `IUnknown::AddRef` |
| 2 | `IUnknown::Release` |
| 3 | `IComInterface::Method` |
| 4 | `IComInterface::Method2` |

| `IComInterface2` Virtual Function Table slot | Method name |
|-----------------------------|-------------|
| 0 | `IUnknown::QueryInterface` |
| 1 | `IUnknown::AddRef` |
| 2 | `IUnknown::Release` |
| 3 | `IComInterface::Method` |
| 4 | `IComInterface::Method2` |
| 5 | `IComInterface2::Method3` |

As a result, it is very easy to call a method defined on `IComInterface` from an `IComInterface2*`. Specifically, calling a method on a base interface does not require a call to `QueryInterface` to get a pointer to the base interface. Additionally, C++ allows an implicit conversion from `IComInterface2*` to `IComInterface*`, which is well defined and allows avoiding a `QueryInterface` call again. As a result, in C or C++, you never need to call `QueryInterface` to get to the base type if you do not want to, which can allow some performance improvements.

> Note: WinRT interfaces do not follow this inheritance model. They are defined to follow the same model as the `[ComImport]`-based COM interop model in .NET.

###### COM Interface Inheritance in .NET with <xref:System.Runtime.InteropServices.ComImportAttribute>

In .NET, C# code that looks like interface inheritance isn't actually interface inheritance. Let's look at the following code:

```csharp
interface I
{
    void Method1();
}
interface J : I
{
    void Method2();
}
```

This code does not say, "`J` implements `I`." The code actually says, "any type that implements `J` must also implement `I`." This difference leads to the fundamental design decision that makes interface inheritance in <xref:System.Runtime.InteropServices.ComImportAttribute>-based interop unergonomic. Interfaces are always considered on their own; an interface's base interface list has no impact on any calculations to determing a virtual function table for a given .NET interface.

As a result, the natural equivalent of the above provided C++ COM interface example leads to a different virtual function table layout.

C# code:

```csharp
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
interface IComInterface
{
    void Method();
    void Method2();
}

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
interface IComInterface2 : IComInterface
{
    void Method3();
}
```

Virtual Function Table layouts:

| `IComInterface` Virtual Function Table slot | Method name |
|-----------------------------|-------------|
| 0 | `IUnknown::QueryInterface` |
| 1 | `IUnknown::AddRef` |
| 2 | `IUnknown::Release` |
| 3 | `IComInterface::Method` |
| 4 | `IComInterface::Method2` |

| `IComInterface2` Virtual Function Table slot | Method name |
|-----------------------------|-------------|
| 0 | `IUnknown::QueryInterface` |
| 1 | `IUnknown::AddRef` |
| 2 | `IUnknown::Release` |
| 3 | `IComInterface2::Method3` |

As these virtual function tables differ from the C++ example, this will lead to serious problems at runtime. The correct definition of these interfaces in .NET with <xref:System.Runtime.InteropServices.ComImportAttribute> is as follows:

```csharp
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
interface IComInterface
{
    void Method();
    void Method2();
}

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
interface IComInterface2 : IComInterface
{
    new void Method();
    new void Method2();
    void Method3();
}
```

Each method from the base interface types must be redeclared, as at the metadata level, `IComInterface2` does not implement `IComInterface`, but only specifies that implementors of `IComInterface2` must also implement `IComInterface`.

## See also

- <xref:System.Runtime.InteropServices.ComVisibleAttribute>
- <xref:System.Runtime.InteropServices.ComImportAttribute>
- [Exposing .NET Framework Components to COM](../../framework/interop/exposing-dotnet-components-to-com.md)
- [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface)
- [Applying Interop Attributes](apply-interop-attributes.md)
- [Packaging a .NET Framework Assembly for COM](../../framework/interop/packaging-an-assembly-for-com.md)
