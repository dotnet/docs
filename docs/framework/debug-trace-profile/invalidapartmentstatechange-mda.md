---
title: "invalidApartmentStateChange MDA"
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
  - "MDAs (managed debugging assistants), invalid apartment state"
  - "managed debugging assistants (MDAs), invalid apartment state"
  - "InvalidApartmentStateChange MDA"
  - "invalid apartment state changes"
  - "threading [.NET Framework], apartment states"
  - "apartment states"
  - "threading [.NET Framework], managed debugging assistants"
  - "COM apartment states"
ms.assetid: e56fb9df-5286-4be7-b313-540c4d876cd7
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# invalidApartmentStateChange MDA
The `invalidApartmentStateChange` managed debugging assistant (MDS) is activated by either of two problems:  
  
-   An attempt is made to change the COM apartment state of a thread that has already been initialized by COM to a different apartment state.  
  
-   The COM apartment state of a thread changes unexpectedly.  
  
## Symptoms  
  
-   A thread's COM apartment state is not what was requested. This may cause proxies to be used for COM components that have a threading model different from the current one. This in turn may cause an <xref:System.InvalidCastException> to be thrown when calling the COM object through interfaces that are not set up for cross-apartment marshaling.  
  
-   The COM apartment state of the thread is different than expected. This can cause a <xref:System.Runtime.InteropServices.COMException> with an HRESULT of RPC_E_WRONG_THREAD as well as a <xref:System.InvalidCastException> when making calls on a [Runtime Callable Wrapper](../../../docs/framework/interop/runtime-callable-wrapper.md) (RCW). This can also cause some single-threaded COM components to be accessed by multiple threads at the same time, which can lead to corruption or data loss.  
  
## Cause  
  
-   The thread was previously initialized to a different COM apartment state. Note that the apartment state of a thread can be set either explicitly or implicitly. The explicit operations include the <xref:System.Threading.Thread.ApartmentState%2A?displayProperty=nameWithType> property and the <xref:System.Threading.Thread.SetApartmentState%2A> and <xref:System.Threading.Thread.TrySetApartmentState%2A> methods. A thread created using the <xref:System.Threading.Thread.Start%2A> method is implicitly set to <xref:System.Threading.ApartmentState.MTA> unless <xref:System.Threading.Thread.SetApartmentState%2A> is called before the thread is started. The main thread of the application is also implicitly initialized to <xref:System.Threading.ApartmentState.MTA> unless the <xref:System.STAThreadAttribute> attribute is specified on the main method.  
  
-   The `CoUninitialize` method (or the `CoInitializeEx` method) with a different concurrency model is called on the thread.  
  
## Resolution  
 Set the apartment state of the thread before it begins executing, or apply either the <xref:System.STAThreadAttribute> attribute or the <xref:System.MTAThreadAttribute> attribute to the main method of the application.  
  
 For the second cause, ideally, the code that calls the `CoUninitialize` method should be modified to delay the call until the thread is about to terminate and there are no RCWs and their underlying COM components still in use by the thread. However, if it is not possible to modify the code that calls the `CoUninitialize` method, then no RCWs should be used from threads that are uninitialized in this way.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 The COM apartment state of the current thread, and the state that the code was attempting to apply.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidApartmentStateChange />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following code example demonstrates a situation that can activate this MDA.  
  
```  
using System.Threading;  
namespace ApartmentStateMDA  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);  
        }  
    }  
}  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
