---
title: "COM Callable Wrapper"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "CCW"
  - "COM interop, COM wrappers"
  - "COM wrappers"
  - "callable wrappers"
  - "interoperation with unmanaged code, COM wrappers"
  - "COM callable wrappers"
ms.assetid: d04be3b5-27b9-4f5b-8469-a44149fabf78
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COM Callable Wrapper
When a COM client calls a .NET object, the common language runtime creates the managed object and a COM callable wrapper (CCW) for the object. Unable to reference a .NET object directly, COM clients use the CCW as a proxy for the managed object.  
  
 The runtime creates exactly one CCW for a managed object, regardless of the number of COM clients requesting its services. As the following illustration shows, multiple COM clients can hold a reference to the CCW that exposes the INew interface. The CCW, in turn, holds a single reference to the managed object that implements the interface and is garbage collected. Both COM and .NET clients can make requests on the same managed object simultaneously.  
  
 ![COM callable wrapper](./media/ccw.gif "ccw")  
Accessing .NET objects through COM callable wrapper  
  
 COM callable wrappers are invisible to other classes running within the .NET Framework. Their primary purpose is to marshal calls between managed and unmanaged code; however, CCWs also manage the object identity and object lifetime of the managed objects they wrap.  
  
## Object Identity  
 The runtime allocates memory for the .NET object from its garbage-collected heap, which enables the runtime to move the object around in memory as necessary. In contrast, the runtime allocates memory for the CCW from a noncollected heap, making it possible for COM clients to reference the wrapper directly.  
  
## Object Lifetime  
 Unlike the .NET client it wraps, the CCW is reference-counted in traditional COM fashion. When the reference count on the CCW reaches zero, the wrapper releases its reference on the managed object. A managed object with no remaining references is collected during the next garbage-collection cycle.  
  
## Simulating COM interfaces

CCW exposes all public, COM-visible interfaces, data types, and return values to COM clients in a manner that is consistent with COM's enforcement of interface-based interaction. For a COM client, invoking methods on a .NET Framework object is identical to invoking methods on a COM object.  
  
 To create this seamless approach, the CCW manufactures traditional COM interfaces, such as **IUnknown** and **IDispatch**. As the following illustration shows, the CCW maintains a single reference on the .NET object that it wraps. Both the COM client and .NET object interact with each other through the proxy and stub construction of the CCW.  
  
 ![COM interfaces](./media/ccwwithinterfaces.gif "ccwwithinterfaces")  
COM interfaces and the COM callable wrapper  
  
 In addition to exposing the interfaces that are explicitly implemented by a class in the managed environment, the .NET Framework supplies implementations of the COM interfaces listed in the following table on behalf of the object. A .NET class can override the default behavior by providing its own implementation of these interfaces. However, the runtime always provides the implementation for the **IUnknown** and **IDispatch** interfaces.  
  
|Interface|Description|  
|---------------|-----------------|  
|**Idispatch**|Provides a mechanism for late binding to type.|  
|**IerrorInfo**|Provides a textual description of the error, its source, a Help file, Help context, and the GUID of the interface that defined the error (always **GUID_NULL** for .NET classes).|  
|**IprovideClassInfo**|Enables COM clients to gain access to the **ITypeInfo** interface implemented by a managed class.|  
|**IsupportErrorInfo**|Enables a COM client to determine whether the managed object supports the **IErrorInfo** interface. If so, enables the client to obtain a pointer to the latest exception object. All managed types support the **IErrorInfo** interface.|  
|**ItypeInfo**|Provides type information for a class that is exactly the same as the type information produced by Tlbexp.exe.|  
|**Iunknown**|Provides the standard implementation of the **IUnknown** interface with which the COM client manages the lifetime of the CCW and provides type coercion.|  
  
 A managed class can also provide the COM interfaces described in the following table.  
  
|Interface|Description|  
|---------------|-----------------|  
|The (\_*classname*) class interface|Interface, exposed by the runtime and not explicitly defined, that exposes all public interfaces, methods, properties, and fields that are explicitly exposed on a managed object.|  
|**IConnectionPoint** and **IconnectionPointContainer**|Interface for objects that source delegate-based events (an interface for registering event subscribers).|  
|**IdispatchEx**|Interface supplied by the runtime if the class implements **IExpando**. The **IDispatchEx** interface is an extension of the **IDispatch** interface that, unlike **IDispatch**, enables enumeration, addition, deletion, and case-sensitive calling of members.|  
|**IEnumVARIANT**|Interface for collection-type classes, which enumerates the objects in the collection if the class implements **IEnumerable**.|  
  
## Introducing the class interface  
 The class interface, which is not explicitly defined in managed code, is an interface that exposes all public methods, properties, fields, and events that are explicitly exposed on the .NET object. This interface can be a dual or dispatch-only interface. The class interface receives the name of the .NET class itself, preceded by an underscore. For example, for class Mammal, the class interface is \_Mammal.  
  
 For derived classes, the class interface also exposes all public methods, properties, and fields of the base class. The derived class also exposes a class interface for each base class. For example, if class Mammal extends class MammalSuperclass, which itself extends System.Object, the .NET object exposes to COM clients three class interfaces named \_Mammal, \_MammalSuperclass, and \_Object.  
  
 For example, consider the following .NET class:  
  
```vb  
' Applies the ClassInterfaceAttribute to set the interface to dual.  
<ClassInterface(ClassInterfaceType.AutoDual)> _  
' Implicitly extends System.Object.  
Public Class Mammal  
    Sub Eat()  
    Sub Breathe()  
    Sub Sleep()  
End Class  
```  
  
```csharp  
// Applies the ClassInterfaceAttribute to set the interface to dual.  
[ClassInterface(ClassInterfaceType.AutoDual)]  
// Implicitly extends System.Object.  
public class Mammal  
{  
    void  Eat();  
    void  Breathe():  
    void  Sleep();  
}  
```  
  
 The COM client can obtain a pointer to a class interface named `_Mammal`, which is described in the type library that the [Type Library Exporter (Tlbexp.exe)](../tools/tlbexp-exe-type-library-exporter.md) tool generates. If the `Mammal` class implemented one or more interfaces, the interfaces would appear under the coclass.  
  
```  
[odl, uuid(…), hidden, dual, nonextensible, oleautomation]  
interface _Mammal : IDispatch  
{  
    [id(0x00000000), propget] HRESULT ToString([out, retval] BSTR*  
        pRetVal);  
    [id(0x60020001)] HRESULT Equals([in] VARIANT obj, [out, retval]  
        VARIANT_BOOL* pRetVal);  
    [id(0x60020002)] HRESULT GetHashCode([out, retval] short* pRetVal);  
    [id(0x60020003)] HRESULT GetType([out, retval] _Type** pRetVal);  
    [id(0x6002000d)] HRESULT Eat();  
    [id(0x6002000e)] HRESULT Breathe();  
    [id(0x6002000f)] HRESULT Sleep();  
}  
[uuid(…)]  
coclass Mammal   
{  
    [default] interface _Mammal;  
}  
```  
  
 Generating the class interface is optional. By default, COM interop generates a dispatch-only interface for each class you export to a type library. You can prevent or modify the automatic creation of this interface by applying the <xref:System.Runtime.InteropServices.ClassInterfaceAttribute> to your class. Although the class interface can ease the task of exposing managed classes to COM, its uses are limited.  
  
> [!CAUTION]
>  Using the class interface, instead of explicitly defining your own, can complicate the future versioning of your managed class. Please read the following guidelines before using the class interface.  
  
### Define an explicit interface for COM clients to use rather than generating the class interface.  
 Because COM interop generates a class interface automatically, post-version changes to your class can alter the layout of the class interface exposed by the common language runtime. Since COM clients are typically unprepared to handle changes in the layout of an interface, they break if you change the member layout of the class.  
  
 This guideline reinforces the notion that interfaces exposed to COM clients must remain unchangeable. To reduce the risk of breaking COM clients by inadvertently reordering the interface layout, isolate all changes to the class from the interface layout by explicitly defining interfaces.  
  
 Use the **ClassInterfaceAttribute** to disengage the automatic generation of the class interface and implement an explicit interface for the class, as the following code fragment shows:  
  
```vb  
<ClassInterface(ClassInterfaceType.None)>Public Class LoanApp  
    Implements IExplicit  
    Sub M() Implements IExplicit.M  
…  
End Class  
```  
  
```csharp  
[ClassInterface(ClassInterfaceType.None)]  
public class LoanApp : IExplicit {  
    void M();  
}  
```  
  
 The **ClassInterfaceType.None** value prevents the class interface from being generated when the class metadata is exported to a type library. In the preceding example, COM clients can access the `LoanApp` class only through the `IExplicit` interface.  
  
### Avoid caching dispatch identifiers (DispIds)
 Using the class interface is an acceptable option for scripted clients, Microsoft Visual Basic 6.0 clients, or any late-bound client that does not cache the DispIds of interface members. DispIds identify interface members to enable late binding.  
  
 For the class interface, generation of DispIds is based on the position of the member in the interface. If you change the order of the member and export the class to a type library, you will alter the DispIds generated in the class interface.  
  
 To avoid breaking late-bound COM clients when using the class interface, apply the **ClassInterfaceAttribute** with the **ClassInterfaceType.AutoDispatch** value. This value implements a dispatch-only class interface, but omits the interface description from the type library. Without an interface description, clients are unable to cache DispIds at compile time. Although this is the default interface type for the class interface, you can apply the attribute value explicitly.  
  
```vb  
<ClassInterface(ClassInterfaceType.AutoDispatch)> Public Class LoanApp  
    Implements IAnother  
    Sub M() Implements IAnother.M  
…  
End Class  
```  
  
```csharp  
[ClassInterface(ClassInterfaceType.AutoDispatch]  
public class LoanApp : IAnother {  
    void M();  
}  
```  
  
 To get the DispId of an interface member at run time, COM clients can call **IDispatch.GetIdsOfNames**. To invoke a method on the interface, pass the returned DispId as an argument to **IDispatch.Invoke**.  
  
### Restrict using the dual interface option for the class interface.  
 Dual interfaces enable early and late binding to interface members by COM clients. At design time and during testing, you might find it useful to set the class interface to dual. For a managed class (and its base classes) that will never be modified, this option is also acceptable. In all other cases, avoid setting the class interface to dual.  
  
 An automatically generated dual interface might be appropriate in rare cases; however, more often it creates version-related complexity. For example, COM clients using the class interface of a derived class can easily break with changes to the base class. When a third party provides the base class, the layout of the class interface is out of your control. Further, unlike a dispatch-only interface, a dual interface (**ClassInterface.AutoDual**) provides a description of the class interface in the exported type library. Such a description encourages late-bound clients to cache DispIds at run time.  
  
## See Also  
 <xref:System.Runtime.InteropServices.ClassInterfaceAttribute>  
 [COM Wrappers](com-wrappers.md)  
 [Exposing .NET Framework Components to COM](exposing-dotnet-components-to-com.md)  
 [Qualifying .NET Types for Interoperation](qualifying-net-types-for-interoperation.md)  
 [Runtime Callable Wrapper](runtime-callable-wrapper.md)