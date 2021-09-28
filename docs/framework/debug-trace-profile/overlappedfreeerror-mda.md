---
title: "overlappedFreeError MDA"
description: Review the overlappedFreeError managed debugging assistant (MDA) in .NET, which may activate on access violations or corruption of the garbage-collected heap.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "OverlappedFreeError MDA"
  - "overlapped free method call error"
  - "managed debugging assistants (MDAs), overlapped structures"
  - "overlapped structures"
  - "MDAs (managed debugging assistants), overlapped structures"
  - "freeing overlapped structures"
ms.assetid: b6ab2d48-6eee-4bab-97a3-046b3b0a5470
---
# overlappedFreeError MDA

The `overlappedFreeError` managed debugging assistant (MDA) is activated when the <xref:System.Threading.Overlapped.Free%28System.Threading.NativeOverlapped%2A%29?displayProperty=nameWithType> method is called before the overlapped operation has completed.  
  
## Symptoms  

 Access violations or corruption of the garbage-collected heap.  
  
## Cause  

 An overlapped structure was freed before the operation completed. The function that is using the overlapped pointer might write to the structure later, after it has been freed. That can cause heap corruption because another object might now occupy that region.  
  
 This MDA might not represent an error if the overlapped operation did not start successfully.  
  
## Resolution  

 Ensure that the I/O operation using the overlapped structure has completed before calling the <xref:System.Threading.Overlapped.Free%28System.Threading.NativeOverlapped%2A%29> method.  
  
## Effect on the Runtime  

 This MDA has no effect on the CLR.  
  
## Output  

 The following is sample output for this MDA.  
  
 `An overlapped pointer (0x00ea3430) that was not allocated on the GC heap was passed via Pinvoke to the win32 function 'WriteFile' in module 'KERNEL32.DLL'. If the AppDomain is shut down, this can cause heap corruption when the async I/O completes. The best solution is to pass a NativeOverlappedStructure retrieved from a call to System.Threading.Overlapped.Pack(). If the AppDomain exits, the CLR will keep this structure alive and pinned until the I/O completes.`  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <overlappedFreeError/>  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshaling.md)
