---
title: "invalidOverlappedToPinvoke MDA"
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
  - "overlapped pointers"
  - "managed debugging assistants (MDAs), overlapped pointers"
  - "invalid overlapped pointer to platform invoke"
  - "InvalidOverlappedToPinvoke MDA"
  - "MDAs (managed debugging assistants), overlapped pointers"
  - "pointers, overlapped"
ms.assetid: 28876047-58bd-4fed-9452-c7da346d67c0
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# invalidOverlappedToPinvoke MDA
The `invalidOverlappedToPinvoke` managed debugging assistant (MDA) is activated when an overlapped pointer that was not created on the garbage collection heap is passed to specific Win32 functions.  
  
> [!NOTE]
>  By default, this MDA is activated only if the platform invoke call is defined in your code and the debugger reports the JustMyCode status of each method. A debugger that does not understand JustMyCode (such as MDbg.exe with no extensions) will not activate this MDA. This MDA can be enabled for those debuggers by using a configuration file and explicitly settting `justMyCode="false"` in the .mda.config file `(<invalidOverlappedToPinvoke enable="true" justMyCode="false"/>`).  
  
## Symptoms  
 Crashes or unexplainable heap corruptions.  
  
## Cause  
 An overlapped pointer that was not created on the garbage collection heap is passed to specific operating system functions.  
  
 The following table shows the functions that this MDA tracks.  
  
|Module|Function|  
|------------|--------------|  
|HttpApi.dll|`HttpReceiveHttpRequest`|  
|IpHlpApi.dll|`NotifyAddrChange`|  
|kernel32.dll|`ReadFile`|  
|kernel32.dll|`ReadFileEx`|  
|kernel32.dll|`WriteFile`|  
|kernel32.dll|`WriteFileEx`|  
|kernel32.dll|`ReadDirectoryChangesW`|  
|kernel32.dll|`PostQueuedCompletionStatus`|  
|MSWSock.dll|`ConnectEx`|  
|WS2_32.dll|`WSASend`|  
|WS2_32.dll|`WSASendTo`|  
|WS2_32.dll|`WSARecv`|  
|WS2_32.dll|`WSARecvFrom`|  
|MQRT.dll|`MQReceiveMessage`|  
  
 The potential for heap corruption is high for this condition because the <xref:System.AppDomain> making the call might unload. If the <xref:System.AppDomain> unloads, the application code will either free the memory for the overlapped pointer, causing corruption when the operation finishes, or the code will leak the memory, causing difficulties later.  
  
## Resolution  
 Use an <xref:System.Threading.Overlapped> object, calling the <xref:System.Threading.Overlapped.Pack%2A> method to get a <xref:System.Threading.NativeOverlapped> structure that can be passed to the function. If the <xref:System.AppDomain> unloads, the CLR waits until the asynchronous operation completes before freeing the pointer.  
  
## Effect on the Runtime  
 This MDA had no effect on the CLR.  
  
## Output  
 The following is an example of output from this MDA.  
  
 `An overlapped pointer (0x00ea3430) that was not allocated on the GC heap was passed via Pinvoke to the Win32 function 'WriteFile' in module 'KERNEL32.DLL'. If the AppDomain is shut down, this can cause heap corruption when the async I/O completes. The best solution is to pass a NativeOverlapped structure retrieved from a call to System.Threading.Overlapped.Pack(). If the AppDomain exits, the CLR will keep this structure alive and pinned until the I/O completes.`  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidOverlappedToPinvoke/>  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
