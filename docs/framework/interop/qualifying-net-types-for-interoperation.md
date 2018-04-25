---
title: "Qualifying .NET Types for Interoperation"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - "exposing .NET Framework components to COM"
  - "COM interop, qualifying .NET types"
  - "qualifying .NET types for interoperation"
  - "interoperation with unmanaged code, qualifying .NET types"
  - "interoperation with unmanaged code, exposing .NET Framework components"
  - "COM interop, exposing COM components"
ms.assetid: 4b8afb52-fb8d-4e65-b47c-fd82956a3cdd
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Qualifying .NET Types for Interoperation
If you intend to expose types in an assembly to COM applications, consider the requirements of COM interop at design time. Managed types (class, interface, structure, and enumeration) seamlessly integrate with COM types when you adhere to the following guidelines:  
  
-   Classes should implement interfaces explicitly.  
  
     Although COM interop provides a mechanism to automatically generate an interface containing all members of the class and the members of its base class, it is far better to provide explicit interfaces. The automatically generated interface is called the class interface. For guidelines, see [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface).  
  
     You can use Visual Basic, C#, and C++ to incorporate interface definitions in your code, instead of having to use Interface Definition Language (IDL) or its equivalent. For syntax details, see your language documentation.  
  
-   Managed types must be public.  
  
     Only public types in an assembly are registered and exported to the type library. As a result, only public types are visible to COM.  
  
     Managed types expose features to other managed code that might not be exposed to COM. For instance, parameterized constructors, static methods, and constant fields are not exposed to COM clients. Further, as the runtime marshals data in and out of a type, the data might be copied or transformed.  
  
-   Methods, properties, fields, and events must be public.  
  
     Members of public types must also be public if they are to be visible to COM. You can restrict the visibility of an assembly, a public type, or public members of a public type by applying the <xref:System.Runtime.InteropServices.ComVisibleAttribute>. By default, all public types and members are visible.  
  
-   Types must have a public default constructor to be activated from COM.  
  
     Managed, public types are visible to COM. However, without a public default constructor (a constructor with no arguments), COM clients cannot create the type. COM clients can still use the type if it is activated by some other means.  
  
-   Types cannot be abstract.  
  
     Neither COM clients nor .NET clients can create abstract types.  
  
 When exported to COM, the inheritance hierarchy of a managed type is flattened. Versioning also differs between managed and unmanaged environments. Types exposed to COM do not have the same versioning characteristics as other managed types.  
  
## See Also  
 <xref:System.Runtime.InteropServices.ComVisibleAttribute>  
 [Exposing .NET Framework Components to COM](../../../docs/framework/interop/exposing-dotnet-components-to-com.md)  
 [Introducing the class interface](com-callable-wrapper.md#introducing-the-class-interface)  
 [Applying Interop Attributes](../../../docs/framework/interop/applying-interop-attributes.md)  
 [Packaging an Assembly for COM](../../../docs/framework/interop/packaging-an-assembly-for-com.md)
