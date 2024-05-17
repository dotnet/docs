---
title: System.Runtime.InteropServices.ICustomMarshaler interface
description: Learn about the System.Runtime.InteropServices.ICustomMarshaler interface.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Runtime.InteropServices.ICustomMarshaler interface

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.InteropServices.ICustomMarshaler> interface provides custom wrappers for handling method calls.

A marshaller provides a bridge between the functionality of old and new interfaces. Custom marshaling provides the following benefits:

- It enables client applications that were designed to work with an old interface to also work with servers that implement a new interface.
- It enables client applications built to work with a new interface to work with servers that implement an old interface.

If you have an interface that introduces different marshaling behavior or that is exposed to the Component Object Model (COM) in a different way, you can design a custom marshaller instead of using the interop marshaller. By using a custom marshaller, you can minimize the distinction between new .NET Framework components and existing COM components.

For example, suppose that you are developing a managed interface called `INew`. When this interface is exposed to COM through a standard COM callable wrapper (CCW), it has the same methods as the managed interface and uses the marshaling rules built into the interop marshaller. Now suppose that a well-known COM interface called `IOld` already provides the same functionality as the `INew` interface. By designing a custom marshaller, you can provide an unmanaged implementation of `IOld` that simply delegates the calls to the managed implementation of the `INew` interface. Therefore, the custom marshaller acts as a bridge between the managed and unmanaged interfaces.

> [!NOTE]
> Custom marshallers are not invoked when calling from managed code to unmanaged code on a dispatch-only interface.

## Define the marshaling type

Before you can build a custom marshaller, you must define the managed and unmanaged interfaces that will be marshaled. These interfaces commonly perform the same function but are exposed differently to managed and unmanaged objects.

A managed compiler produces a managed interface from metadata, and the resulting interface looks like any other managed interface. The following example shows a typical interface.

:::code language="csharp" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/csharp/source.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/vb/source.vb" id="Snippet1":::

You define the unmanaged type in Interface Definition Language (IDL) and compile it with the Microsoft Interface Definition Language (MIDL) compiler. You define the interface within a library statement and assign it an interface ID with the universal unique identifier (UUID) attribute, as the following example demonstrates.

```
 [uuid(9B2BAADA-0705-11D3-A0CD-00C04FA35826)]
library OldLib {
     [uuid(9B2BAADD-0705-11D3-A0CD-00C04FA35826)]
     interface IOld : IUnknown
         HRESULT OldMethod();
}
```

The MIDL compiler produces several output files. If the interface is defined in Old.idl, the output file Old_i.c defines a `const` variable with the interface identifier (IID) of the interface, as the following example demonstrates.

```
const IID IID_IOld = {0x9B2BAADD,0x0705,0x11D3,{0xA0,0xCD,0x00,0xC0,0x4F,0xA3,0x58,0x26}};
```

The Old.h file is also produced by MIDL. It contains a C++ definition of the interface that can be included in your C++ source code.

## Implement the ICustomMarshaler interface

Your custom marshaller must implement the <xref:System.Runtime.InteropServices.ICustomMarshaler> interface to provide the appropriate wrappers to the runtime.

The following C# code displays the base interface that must be implemented by all custom marshallers.

:::code language="csharp" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/csharp/source.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/vb/source.vb" id="Snippet2":::

The <xref:System.Runtime.InteropServices.ICustomMarshaler> interface includes methods that provide conversion support, cleanup support, and information about the data to be marshaled.

|Type of operation|ICustomMarshaler method|Description|
|-----------------------|-----------------------------|-----------------|
|Conversion (from native to managed code)|<xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalNativeToManaged%2A>|Marshals a pointer to native data into a managed object. This method returns a custom runtime callable wrapper (RCW) that can marshal the unmanaged interface that is passed as an argument. The marshaller should return an instance of the custom RCW for that type.|
|Conversion (from managed to native code)|<xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalManagedToNative%2A>|Marshals a managed object into a pointer to native data. This method returns a custom COM callable wrapper (CCW) that can marshal the managed interface that is passed as an argument. The marshaller should return an instance of the custom CCW for that type.|
|Cleanup (of native code)|<xref:System.Runtime.InteropServices.ICustomMarshaler.CleanUpNativeData%2A>|Enables the marshaller to clean up the native data (the CCW) that is returned by the <xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalManagedToNative%2A> method.|
|Cleanup (of managed code)|<xref:System.Runtime.InteropServices.ICustomMarshaler.CleanUpManagedData%2A>|Enables the marshaller to clean up the managed data (the RCW) that is returned by the <xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalNativeToManaged%2A> method.|
|Information (about native code)|<xref:System.Runtime.InteropServices.ICustomMarshaler.GetNativeDataSize%2A>|Returns the size of the unmanaged data to be marshaled.|

### Conversion

<xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalNativeToManaged%2A?displayProperty=nameWithType>

Marshals a pointer to native data into a managed object. This method returns a custom runtime callable wrapper (RCW) that can marshal the unmanaged interface that is passed as an argument. The marshaller should return an instance of the custom RCW for that type.

<xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalManagedToNative%2A?displayProperty=nameWithType>

Marshals a managed object into a pointer to native data. This method returns a custom COM callable wrapper (CCW) that can marshal the managed interface that is passed as an argument. The marshaller should return an instance of the custom CCW for that type.

### Cleanup

<xref:System.Runtime.InteropServices.ICustomMarshaler.CleanUpNativeData%2A?displayProperty=nameWithType>

Enables the marshaller to clean up the native data (the CCW) that is returned by the <xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalManagedToNative%2A> method.

<xref:System.Runtime.InteropServices.ICustomMarshaler.CleanUpManagedData%2A?displayProperty=nameWithType>

Enables the marshaller to clean up the managed data (the RCW) that is returned by the <xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalNativeToManaged%2A> method.

### Size information

<xref:System.Runtime.InteropServices.ICustomMarshaler.GetNativeDataSize%2A?displayProperty=nameWithType>

Returns the size of the unmanaged data to be marshaled.

> [!NOTE]
> If a custom marshaller calls any methods that set the last P/Invoke error when marshaling from native to managed or when cleaning up, the value returned by <xref:System.Runtime.InteropServices.Marshal.GetLastWin32Error?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.Marshal.GetLastPInvokeError?displayProperty=nameWithType> will represent the call in the marshaling or cleanup calls. This can cause errors to be missed when using custom marshallers with P/Invokes with <xref:System.Runtime.InteropServices.DllImportAttribute.SetLastError?displayProperty=nameWithType> set to `true`. To preserve the last P/Invoke error, use the <xref:System.Runtime.InteropServices.Marshal.GetLastPInvokeError?displayProperty=nameWithType> and <xref:System.Runtime.InteropServices.Marshal.SetLastPInvokeError(System.Int32)?displayProperty=nameWithType> methods in the <xref:System.Runtime.InteropServices.ICustomMarshaler> implementation.

## Implement the GetInstance method

In addition to implementing the <xref:System.Runtime.InteropServices.ICustomMarshaler> interface, custom marshallers must implement a `static` method called `GetInstance` that accepts a <xref:System.String> as a parameter and has a return type of <xref:System.Runtime.InteropServices.ICustomMarshaler>. This `static` method is called by the common language runtime's COM interop layer to instantiate an instance of the custom marshaller. The string that is passed to `GetInstance` is a cookie that the method can use to customize the returned custom marshaller. The following example shows a minimal, but complete, <xref:System.Runtime.InteropServices.ICustomMarshaler> implementation.

:::code language="csharp" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/csharp/source.cs" id="Snippet6":::

## Apply MarshalAsAttribute

To use a custom marshaller, you must apply the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to the parameter or field that is being marshaled.

You must also pass the <xref:System.Runtime.InteropServices.UnmanagedType.CustomMarshaler?displayProperty=nameWithType> enumeration value to the <xref:System.Runtime.InteropServices.MarshalAsAttribute> constructor. In addition, you must specify the <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalType> field with one of the following named parameters:

- <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalType> (required): The assembly-qualified name of the custom marshaller. The name should include the namespace and class of the custom marshaller. If the custom marshaller is not defined in the assembly it is used in, you must specify the name of the assembly in which it is defined.

    > [!NOTE]
    > You can use the <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalTypeRef> field instead of the <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalType> field. <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalTypeRef> takes a type that is easier to specify.

- <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalCookie> (optional): A cookie that is passed to the custom marshaller. You can use the cookie to provide additional information to the marshaller. For example, if the same marshaller is used to provide a number of wrappers, the cookie identifies a specific wrapper. The cookie is passed to the `GetInstance` method of the marshaller.

The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute identifies the custom marshaller so it can activate the appropriate wrapper. The common language runtime's interop service then examines the attribute and creates the custom marshaller the first time the argument (parameter or field) needs to be marshaled.

The runtime then calls the <xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalNativeToManaged%2A> and <xref:System.Runtime.InteropServices.ICustomMarshaler.MarshalManagedToNative%2A> methods on the custom marshaller to activate the correct wrapper to handle the call.

## Use a custom marshaller

When the custom marshaller is complete, you can use it as a custom wrapper for a particular type. The following example shows the definition of the `IUserData` managed interface:

:::code language="csharp" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/csharp/source.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/vb/source.vb" id="Snippet3":::

In the following example, the `IUserData` interface uses the `NewOldMarshaler` custom marshaller to enable unmanaged client applications to pass an `IOld` interface to the `DoSomeStuff` method. The managed description of the `DoSomeStuff` method takes an `INew` interface, as shown in the previous example, whereas the unmanaged version of `DoSomeStuff` takes an `IOld` interface pointer, as shown in the following example.

```
[uuid(9B2BAADA-0705-11D3-A0CD-00C04FA35826)]
library UserLib {
     [uuid(9B2BABCD-0705-11D3-A0CD-00C04FA35826)]
     interface IUserData : IUnknown
         HRESULT DoSomeStuff(IUnknown* pIOld);
}
```

The type library that is generated by exporting the managed definition of `IUserData` yields the unmanaged definition shown in this example instead of the standard definition. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute applied to the `INew` argument in the managed definition of the `DoSomeStuff` method indicates that the argument uses a custom marshaller, as the following example shows.

:::code language="csharp" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/csharp/source.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/vb/source.vb" id="Snippet4":::

:::code language="csharp" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/csharp/source.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Runtime.InteropServices/ICustomMarshaler/Overview/vb/source.vb" id="Snippet5":::

In the previous examples, the first parameter provided to the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute is the <xref:System.Runtime.InteropServices.UnmanagedType.CustomMarshaler?displayProperty=nameWithType> enumeration value `UnmanagedType.CustomMarshaler`.

The second parameter is the <xref:System.Runtime.InteropServices.MarshalAsAttribute.MarshalType> field, which provides the assembly-qualified name of the custom marshaller. This name consists of the namespace and class of the custom marshaller (`MarshalType="MyCompany.NewOldMarshaler"`).
