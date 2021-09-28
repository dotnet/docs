---
title: "pInvokeLog MDA"
description: Understand the pInvokeLog managed debugging assistant (MDA), which is activated for each unique platform invoke signature used during execution in .NET.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "signatures, platform invoke"
  - "MDAs (managed debugging assistants), platform invoke"
  - "platform invoke, run-time errors"
  - "platform invoke log"
  - "PInvokeLog MDA"
  - "managed debugging assistants (MDAs), platform invoke"
ms.assetid: b830444a-5003-49fe-b89b-b8bee22f7b1a
---
# pInvokeLog MDA

The `pInvokeLog` managed debugging assistant (MDA) is activated for each unique platform invoke signature used during execution.  
  
## Effect on the Runtime  

 This MDA has no effect on the CLR.  
  
## Output  

 A message indicating the platform invoke signature used during execution.  
  
## Configuration  

 Each match element filters the .dll files to which platform invoke calls are made.  
  
```xml  
<mdaConfig>  
  <assistants>  
    <pInvokeLog>  
      <filter>  
        <match dllName="user32.dll"/>  
        <match dllName="kernel32.dll"/>  
      </filter>  
    </pInvokeLog>  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Consuming Unmanaged DLL Functions](../interop/consuming-unmanaged-dll-functions.md)
