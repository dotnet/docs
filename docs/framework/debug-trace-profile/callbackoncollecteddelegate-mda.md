---
title: "callbackOnCollectedDelegate MDA"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "cpp"
helpviewer_keywords: 
  - "MDAs (managed debugging assistants), garbage collection"
  - "managed debugging assistants (MDAs), callback on collected delegates"
  - "MDAs (managed debugging assistants), callback on collected delegates"
  - "callback on delegate after garbage collection"
  - "callbackOnCollectedDelegate MDA"
  - "managed debugging assistants (MDAs), garbage collection"
  - "call back collected delegates"
  - "garbage collection, run-time errors"
  - "delegates [.NET Framework], garbage collection"
ms.assetid: 398b0ce0-5cc9-4518-978d-b8263aa21e5b
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# callbackOnCollectedDelegate MDA
The `callbackOnCollectedDelegate` managed debugging assistant (MDA) is activated if a delegate is marshaled from managed to unmanaged code as a function pointer and a callback is placed on that function pointer after the delegate has been garbage collected.  
  
## Symptoms  
 Access violations occur when attempting to call into managed code through function pointers that were obtained from managed delegates. These failures, while not common language runtime (CLR) bugs, may appear to be so because the access violation occurs in the CLR code.  
  
 The failure is not consistent; sometimes the call on the function pointer succeeds and sometimes it fails. The failure might occur only under heavy load or on a random number of attempts.  
  
## Cause  
 The delegate from which the function pointer was created and exposed to unmanaged code was garbage collected. When the unmanaged component tries to call on the function pointer, it generates an access violation.  
  
 The failure appears random because it depends on when garbage collection occurs. If a delegate is eligible for collection, the garbage collection can occur after the callback and the call succeeds. At other times, the garbage collection occurs before the callback, the callback generates an access violation, and the program stops.  
  
 The probability of the failure depends on the time between marshaling the delegate and the callback on the function pointer as well as the frequency of garbage collections. The failure is sporadic if the time between marshaling the delegate and the ensuing callback is short. This is usually the case if the unmanaged method receiving the function pointer does not save the function pointer for later use but instead calls back on the function pointer immediately to complete its operation before returning. Similarly, more garbage collections occur when a system is under heavy load, which makes it more likely that a garbage collection will occur before the callback.  
  
## Resolution  
 Once a delegate has been marshaled out as an unmanaged function pointer, the garbage collector cannot track its lifetime. Instead, your code must keep a reference to the delegate for the lifetime of the unmanaged function pointer. But before you can do that, you first must identify which delegate was collected. When the MDA is activated, it provides the type name of the delegate. Use this name to search your code for platform invoke or COM signatures that pass that delegate out to unmanaged code. The offending delegate is passed out through one of these call sites. You can also enable the `gcUnmanagedToManaged` MDA to force a garbage collection before every callback into the runtime. This will remove the uncertainty introduced by the garbage collection by ensuring that a garbage collection always occurs before the callback. Once you know what delegate was collected, change your code to keep a reference to that delegate on the managed side for the lifetime of the marshaled unmanaged function pointer.  
  
## Effect on the Runtime  
 When delegates are marshaled as function pointers, the runtime allocates a thunk that does the transition from unmanaged to managed. This thunk is what the unmanaged code actually calls before the managed delegate is finally invoked. Without the `callbackOnCollectedDelegate` MDA enabled, the unmanaged marshaling code is deleted when the delegate is collected. With the `callbackOnCollectedDelegate` MDA enabled, the unmanaged marshaling code is not immediately deleted when the delegate is collected. Instead, the last 1,000 instances are kept alive by default and changed to activate the MDA when called. The thunk is eventually deleted after 1,001 more marshaled delegates are collected.  
  
## Output  
 The MDA reports the type name of the delegate that was collected before a callback was attempted on its unmanaged function pointer.  
  
## Configuration  
 The following example shows the application configuration options. It sets the number of thunks the MDA keeps alive to 1,500. The default `listSize` value is 1,000, the minimum is 50, and the maximum is 2,000.  
  
```xml  
<mdaConfig>  
  <assistants>  
    <callbackOnCollectedDelegate listSize="1500" />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following example demonstrates a situation that can activate this MDA:  
  
```  
// Library.cpp : Defines the unmanaged entry point for the DLL application.  
#include "windows.h"  
#include "stdio.h"  
  
void (__stdcall *g_pfTarget)();  
  
void __stdcall Initialize(void __stdcall pfTarget())  
{  
    g_pfTarget = pfTarget;  
}  
  
void __stdcall Callback()  
{  
    g_pfTarget();  
}  
// ---------------------------------------------------  
// C# Client  
using System;  
using System.Runtime.InteropServices;  
  
public class Entry  
{  
    public delegate void DCallback();  
  
    public static void Main()  
    {  
        new Entry();  
        Initialize(Target);  
        GC.Collect();  
        GC.WaitForPendingFinalizers();  
        Callback();  
    }  
  
    public static void Target()  
    {          
    }  
  
    [DllImport("Library", CallingConvention = CallingConvention.StdCall)]  
    public static extern void Initialize(DCallback pfDelegate);  
  
    [DllImport ("Library", CallingConvention = CallingConvention.StdCall)]  
    public static extern void Callback();  
  
    ~Entry() { Console.Error.WriteLine("Entry Collected"); }  
}  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)  
 [gcUnmanagedToManaged](../../../docs/framework/debug-trace-profile/gcunmanagedtomanaged-mda.md)
