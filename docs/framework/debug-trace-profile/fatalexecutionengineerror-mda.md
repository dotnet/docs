---
title: "fatalExecutionEngineError MDA"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "corrupted CLR"
  - "fatal execution error"
  - "terminated processes"
  - "unexpected terminations"
  - "fatal errors"
  - "MDAs (managed debugging assistants), fatal errors"
  - "process termination"
  - "FatalExecutionEngineError MDA"
  - "managed debugging assistants (MDAs), fatal errors"
ms.assetid: 8b559e44-2393-4e4e-8160-7558d37a4a89
author: "mairaw"
ms.author: "mairaw"
---
# fatalExecutionEngineError MDA
The `fatalExecutionEngineError` managed debugging assistant (MDA) is activated when a fatal error in the common language runtime (CLR) has been detected. The process will be terminated.  
  
## Symptoms  
 Unexpected process termination. Other symptoms cannot be determined because a CLR failure can occur for a variety of reasons.  
  
## Cause  
 The CLR has been fatally corrupted. This is most often caused by data corruption, which can be caused by a number of problems, such as calls to malformed platform invoke functions and passing invalid data to the CLR.  
  
## Resolution  
 Enabling additional MDAs might help identify the problem. The following MDAs can be particularly helpful in diagnosing the issue:  
  
- [invalidOverlappedToPinvoke](invalidoverlappedtopinvoke-mda.md)  
  
- [overlappedFreeError](overlappedfreeerror-mda.md)  
  
- [pInvokeStackImbalance](pinvokestackimbalance-mda.md)  
  
- [gcUnmanagedToManaged](gcunmanagedtomanaged-mda.md)  
  
- [gcManagedToUnmanaged](gcmanagedtounmanaged-mda.md)  
  
- [callbackOnCollectedDelegate](callbackoncollecteddelegate-mda.md)  
  
- [reportAvOnComRelease](reportavoncomrelease-mda.md)  
  
- [invalidVariant](invalidvariant-mda.md)  
  
- [invalidIUnknown](invalidiunknown-mda.md)  
  
- [raceOnRCWCleanup](raceonrcwcleanup-mda.md)  
  
- [invalidFunctionPointerInDelegate](invalidfunctionpointerindelegate-mda.md)  
  
- [invalidGCHandleCookie](invalidgchandlecookie-mda.md)  
  
## Effect on the Runtime  
 This MDA has no effect on the runtime's behavior.  
  
## Output  
 The address of the CLR function that caused the fatal error, the ID of the thread where the error occurred, and the error code.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <fatalExecutionEngineError />  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod%2A>
- <xref:System.Runtime.ConstrainedExecution.Cer>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
