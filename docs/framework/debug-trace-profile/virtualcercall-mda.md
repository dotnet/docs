---
title: "virtualCERCall MDA"
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
  - "MDAs (managed debugging assistants), CER calls"
  - "virtualCERCall MDA"
  - "virtual CER calls"
  - "constrained execution regions"
  - "CER calls"
  - "managed debugging assistants (MDAs), CER calls"
ms.assetid: 1eb18c7a-f5e0-443f-80fb-67bfbb047da2
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# virtualCERCall MDA
The `virtualCERCall` managed debugging assistant (MDA) is activated as a warning indicating that a call site within a constrained execution region (CER) call graph refers to a virtual target, that is, a virtual call to a non-final virtual method or a call using an interface. The common language runtime (CLR) cannot predict the destination method of these calls from the intermediate language and metadata analysis alone. As a result, the call tree cannot be prepared as part of the CER graph and thread aborts in that subtree cannot be automatically blocked. This MDA warns of cases where a CER might need to be extended by using explicit calls to the <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod%2A> method once the additional information required to compute the call target is known at run time.  
  
## Symptoms  
 CERs that do not run when a thread is aborted or an application domain is unloaded.  
  
## Cause  
 A CER contains a call to a virtual method that cannot be prepared automatically.  
  
## Resolution  
 Call <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod%2A> for the virtual method.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
  
```  
Method 'MethodWithCer', while executing within a constrained execution region, makes a call  
at IL offset 0x0024 to 'VirtualMethod', which is virtual and cannot be prepared automatically  
at compile time. The caller must ensure this method is prepared explicitly at  
runtime before entering the constrained execution region.  
method name="VirtualMethod"  
declaringType name="VirtualCERCall+MyClass"  
  declaringModule name="mda"  
    callsite name="MethodWithCer" offset="0x0024"  
```  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    < VirtualCERCall />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
  
```  
class MyClass  
{  
    [ReliabilityContract(Consistency.MayCorruptProcess, CER.None)]  
    virtual void VirtualMethod()  
    {  
        ...  
    }  
}  
  
class MyDerivedClass : MyClass  
{  
    [ReliabilityContract(Consistency.MayCorruptProcess, CER.None)]  
    override void VirtualMethod()  
    {  
        ...  
    }  
}  
  
void MethodWithCer(MyClass object)  
{  
    RuntimeHelpers.PrepareConstrainedRegions();  
    try  
    {  
        ...  
    }  
    finally  
    {  
        // Start of the CER.  
  
        // Cannot tell at analysis time whether object is a MyClass  
        // or a MyDerivedClass, so we do not know which version of   
        // VirtualMethod we are going to call.  
        object.VirtualMethod();  
    }  
}  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
