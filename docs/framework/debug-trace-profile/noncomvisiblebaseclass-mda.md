---
title: "nonComVisibleBaseClass MDA"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "visible classes"
  - "managed debugging assistants (MDAs), COM visible classes"
  - "nonComVisibleBaseClass MDA"
  - "COM visible classes"
  - "QueryInterface call failures"
  - "MDAs (managed debugging assistants), COM visible classes"
ms.assetid: 9ec1af27-604b-477e-9ee2-e833eb10d3ce
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# nonComVisibleBaseClass MDA
The `nonComVisibleBaseClass` managed debugging assistant (MDA) is activated when a `QueryInterface` call is made by native or unmanaged code on the COM callable wrapper (CCW) of a COM-visible managed class that derives from a base class that is not COM visible.  The `QueryInterface` call causes the MDA to activate only in cases where call requests the class interface or default `IDispatch` of the COM-visible managed class.  The MDA is not activated when the `QueryInterface` is for an explicit interface that has the <xref:System.Runtime.InteropServices.ClassInterfaceAttribute> attribute applied and is explicitly implemented by the COM-visible class.  
  
## Symptoms  
 A `QueryInterface` call made from native code that is failing with a COR_E_INVALIDOPERATION HRESULT.  The HRESULT might be due to the runtime disallowing `QueryInterface` calls that would cause the activation of this MDA.  
  
## Cause  
 The runtime cannot allow `QueryInterface` calls for the class interface or default `IDispatch` interface of a COM-visible class that derives from a class that is not COM-visible because of potential versioning problems.  For example, if any public members were added to the base class that is not COM-visible, existing COM clients using the derived class could potentially break because the vtable of the derived class, which contains the base class members, would be altered by such a change.  Explicit interfaces exposed to COM do not have this problem because they do not include the base members of interfaces in the vtable.  
  
## Resolution  
 Do not expose the class interface. Define an explicit interface and apply the <xref:System.Runtime.InteropServices.ClassInterfaceAttribute> attribute to it.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 The following is an example message for a `QueryInterface` call on a COM-visible class `Derived` that derives from a non-COM-visible class `Base`.  
  
```  
A QueryInterface call was made requesting the class interface of COM   
visible managed class 'Derived'. However since this class derives from   
non COM visible class 'Base', the QueryInterface call will fail. This   
is done to prevent the non COM visible base class from being   
constrained by the COM versioning rules.   
```  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <nonComVisibleBaseClass />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
