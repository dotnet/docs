---
title: "releaseHandleFailed MDA"
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
  - "managed debugging assistants (MDAs), handles"
  - "release handle failed"
  - "CriticalHandle class, run-time errors"
  - "releaseHandleFailed MDA"
  - "ReleaseHandle method"
  - "SafeHandle class, run-time errors"
  - "MDAs (managed debugging assistants), handles"
ms.assetid: 44cd98ba-95e5-40a1-874d-e8e163612c51
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# releaseHandleFailed MDA
The `releaseHandleFailed` managed debugging assistant (MDA) is activated is to notify developers when the <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> method of a class derived from <xref:System.Runtime.InteropServices.SafeHandle> or <xref:System.Runtime.InteropServices.CriticalHandle> returns `false`.  
  
## Symptoms  
 Resource or memory leaks.  If the <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> method of the class deriving from <xref:System.Runtime.InteropServices.SafeHandle> or <xref:System.Runtime.InteropServices.CriticalHandle> fails, then the resource encapsulated by the class might not have been released or cleaned up.  
  
## Cause  
 Users must provide the implementation of the <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> method if they create classes that derive from <xref:System.Runtime.InteropServices.SafeHandle> or <xref:System.Runtime.InteropServices.CriticalHandle>; thus, the circumstances are specific to the individual resource. However, the requirements are as follows:  
  
-   <xref:System.Runtime.InteropServices.SafeHandle> and <xref:System.Runtime.InteropServices.CriticalHandle> types represent wrappers around vital process resources. A memory leak would make the process unusable over time.  
  
-   The <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> method must not fail to perform its function. Once the process acquires such a resource, <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> is the only way to release it. Therefore, failure implies resource leaks.  
  
-   Any failure that does occur during the execution of <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A>, impeding the release of the resource, is a bug in the implementation of the <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> method itself. It is the responsibility of the programmer to ensure that the contract is fulfilled, even if that code calls code authored by someone else to perform its function.  
  
## Resolution  
 The code that uses the specific <xref:System.Runtime.InteropServices.SafeHandle> (or <xref:System.Runtime.InteropServices.CriticalHandle>) type that raised the MDA notification should be reviewed, looking for places where the raw handle value is extracted from the <xref:System.Runtime.InteropServices.SafeHandle> and copied elsewhere. This is the usual cause of failures within <xref:System.Runtime.InteropServices.SafeHandle> or <xref:System.Runtime.InteropServices.CriticalHandle> implementations, because the usage of the raw handle value is then no longer tracked by the runtime. If the raw handle copy is subsequently closed, it can cause a later <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> call to fail because the close is attempted on the same handle, which is now invalid.  
  
 There are a number of ways in which incorrect handle duplication can occur:  
  
-   Look for calls to the <xref:System.Runtime.InteropServices.SafeHandle.DangerousGetHandle%2A> method. Calls to this method should be exceedingly rare, and any that you find should be surrounded by calls to the <xref:System.Runtime.InteropServices.SafeHandle.DangerousAddRef%2A> and <xref:System.Runtime.InteropServices.SafeHandle.DangerousRelease%2A> methods. These latter methods specify the region of code in which the raw handle value may be safely used. Outside this region, or if the reference count is never incremented in the first place, the handle value can be invalidated at any time by a call to <xref:System.Runtime.InteropServices.SafeHandle.Dispose%2A> or <xref:System.Runtime.InteropServices.SafeHandle.Close%2A> on another thread. Once all uses of <xref:System.Runtime.InteropServices.SafeHandle.DangerousGetHandle%2A> have been tracked down, you should follow the path the raw handle takes to ensure it is not handed off to some component that will eventually call `CloseHandle` or another low-level native method that will release the handle.  
  
-   Ensure that the code that is used to initialize the <xref:System.Runtime.InteropServices.SafeHandle> with a valid raw handle value owns the handle. If you form a <xref:System.Runtime.InteropServices.SafeHandle> around a handle your code does not own without setting the `ownsHandle` parameter to `false` in the base constructor, then both the <xref:System.Runtime.InteropServices.SafeHandle> and the real handle owner can try to close the handle, leading to an error in <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> if the <xref:System.Runtime.InteropServices.SafeHandle> loses the race.  
  
-   When a <xref:System.Runtime.InteropServices.SafeHandle> is marshaled between application domains, confirm the <xref:System.Runtime.InteropServices.SafeHandle> derivation being used has been marked as serializable. In the rare cases where a class derived from <xref:System.Runtime.InteropServices.SafeHandle> has been made serializable, it should implement the <xref:System.Runtime.Serialization.ISerializable> interface or use one of the other techniques for controlling the serialization and deserialization process manually. This is required because the default serialization action is to create a bitwise clone of the enclosed raw handle value, resulting in two <xref:System.Runtime.InteropServices.SafeHandle> instances thinking they own the same handle. Both will try to call <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> on the same handle at some point. The second <xref:System.Runtime.InteropServices.SafeHandle> to do this will fail. The correct course of action when serializing a <xref:System.Runtime.InteropServices.SafeHandle> is to call the `DuplicateHandle` function or a similar function for your native handle type to make a distinct legal handle copy. If your handle type does not support this then the <xref:System.Runtime.InteropServices.SafeHandle> type wrapping it cannot be made serializable.  
  
-   It may be possible to track where a handle is being closed early, leading to a failure when the <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> method is finally called, by placing a debugger breakpoint on the native routine used to release the handle, for example the `CloseHandle` function. This may not be possible for stress scenarios or even medium-sized functional tests due to the heavy traffic such routines often deal with. It may help to instrument the code that calls the native release method, in order to capture the identity of the caller, or possibly a full stack trace, and the value of the handle being released.  The handle value can be compared with the value reported by this MDA.  
  
-   Note that some native handle types, such as all the Win32 handles that can be released via the `CloseHandle` function, share the same handle namespace. An erroneous release of one handle type can cause problems with another. For instance, accidentally closing a Win32 event handle twice might lead to an apparently unrelated file handle being closed prematurely. This happens when the handle is released and the handle value becomes available for use to track another resource, potentially of another type. If this happens and is followed by an erroneous second release, the handle of an unrelated thread might be invalidated.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 A message indicating that a <xref:System.Runtime.InteropServices.SafeHandle> or a <xref:System.Runtime.InteropServices.CriticalHandle> failed to properly release the handle. For example:  
  
```  
"A SafeHandle or CriticalHandle of type 'MyBrokenSafeHandle'   
failed to properly release the handle with value 0x0000BEEF. This   
usually indicates that the handle was released incorrectly via   
another means (such as extracting the handle using DangerousGetHandle   
and closing it directly or building another SafeHandle around it."  
```  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <releaseHandleFailed/>  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following is a code example that can activate the `releaseHandleFailed` MDA.  
  
```  
bool ReleaseHandle()  
{  
    // Calling the Win32 CloseHandle function to release the   
    // native handle wrapped by this SafeHandle. This method returns   
    // false on failure, but should only fail if the input is invalid   
    // (which should not happen here). The method specifically must not   
    // fail simply because of lack of resources or other transient   
    // failures beyond the user’s control. That would make it unacceptable   
    // to call CloseHandle as part of the implementation of this method.  
    return CloseHandle(handle);  
}  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
