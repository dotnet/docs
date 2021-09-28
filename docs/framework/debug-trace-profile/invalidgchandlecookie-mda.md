---
title: "invalidGCHandleCookie MDA"
description: Review the invalidGCHandleCookie managed debugging assistant (MDA), which is activated when a conversion from an invalid IntPtr cookie to a GCHandle is tried.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "MDAs (managed debugging assistants), invalid cookies"
  - "cookies, invalid"
  - "managed debugging assistants (MDAs), invalid cookies"
  - "InvalidGCHandleCookie MDA"
  - "invalid cookies"
ms.assetid: 613ad742-3c11-401d-a6b3-893ceb8de4f8
---
# invalidGCHandleCookie MDA

The `invalidGCHandleCookie` managed debugging assistant (MDA) is activated when a conversion from an invalid <xref:System.IntPtr> cookie to a <xref:System.Runtime.InteropServices.GCHandle> is attempted.  
  
## Symptoms  

 Undefined behavior such as access violations and memory corruption while attempting to use or retrieve a <xref:System.Runtime.InteropServices.GCHandle> from an <xref:System.IntPtr>.  
  
## Cause  

 The cookie is probably invalid because it was not originally created from a <xref:System.Runtime.InteropServices.GCHandle>, represents a <xref:System.Runtime.InteropServices.GCHandle> that has already been freed, is a cookie to a <xref:System.Runtime.InteropServices.GCHandle> in a different application domain, or was marshaled to native code as a <xref:System.Runtime.InteropServices.GCHandle> but passed back into the CLR as an <xref:System.IntPtr>, where a cast was attempted.  
  
## Resolution  

 Specify a valid <xref:System.IntPtr> cookie for the <xref:System.Runtime.InteropServices.GCHandle>.  
  
## Effect on the Runtime  

 When this MDA is enabled, the debugger is no longer able to trace the roots back to their objects because the cookie values passed back are different from the ones returned when the MDA is not enabled.  
  
## Output  

 The invalid <xref:System.IntPtr> cookie value is reported.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidGCHandleCookie />  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.InteropServices.GCHandle.FromIntPtr%2A>
- <xref:System.Runtime.InteropServices.GCHandle>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
