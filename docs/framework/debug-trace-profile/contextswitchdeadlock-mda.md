---
title: "contextSwitchDeadlock MDA"
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
  - "deadlocks [.NET Framework]"
  - "pumping messages"
  - "STA message pumping"
  - "single-threaded COM components"
  - "MDAs (managed debugging assistants), context switching deadlocks"
  - "managed debugging assistants (MDAs), context switching deadlocks"
  - "ContextSwitchDeadlock MDA"
  - "message pumping"
  - "context switching deadlocks"
ms.assetid: 26dfaa15-9ddb-4b0a-b6da-999bba664fa6
caps.latest.revision: 22
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# contextSwitchDeadlock MDA
The `contextSwitchDeadlock` managed debugging assistant (MDA) is activated when a deadlock is detected during an attempted COM context transition.  
  
## Symptoms  
 The most common symptom is that a call on an unmanaged COM component from managed code does not return.  Another symptom is memory usage increasing over time.  
  
## Cause  
 The most probable cause is that a single-threaded apartment (STA) thread is not pumping messages. The STA thread is either waiting without pumping messages or is performing lengthy operations and is not allowing the message queue to pump.  
  
 Memory usage increasing over time is caused by the finalizer thread attempting to call `Release` on an unmanaged COM component and that component is not returning.  This prevents the finalizer from reclaiming other objects.  
  
 By default, the threading model for the main thread of Visual Basic console applications is STA. This MDA is activated if an STA thread uses COM interoperability either directly or indirectly through the common language runtime or a third-party control.  To avoid activating this MDA in a Visual Basic console application, apply the <xref:System.MTAThreadAttribute> attribute to the main method or modify the application to pump messages.  
  
 It is possible for this MDA to be falsely activated when all of the following conditions are met:  
  
-   An application creates COM components from STA threads either directly or indirectly through libraries.  
  
-   The application was stopped in the debugger and the user either continued the application or performed a step operation.  
  
-   Unmanaged debugging is not enabled.  
  
 To determine if the MDA is being falsely activated, disable all breakpoints, restart the application, and allow it to run without stopping. If the MDA is not activated, it is likely the initial activation was false. In this case, disable the MDA to avoid interference with the debugging session.  
  
> [!NOTE]
>  This MDA is in the default set for [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] and later versions. When the hosting process is enabled in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], you cannot disable MDAs that are in the default set. The hosting process is enabled by default, so it must be explicitly disabled. For information about how to disable MDAs, see "Enabling and Disabling MDAs" in [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md).  
  
## Resolution  
 Follow COM rules regarding STA message pumping.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR. It only reports data about COM contexts.  
  
## Output  
 A message describing the current context and the target context.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <contextSwitchDeadlock />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 [Interop Marshaling](../../../docs/framework/interop/interop-marshaling.md)
