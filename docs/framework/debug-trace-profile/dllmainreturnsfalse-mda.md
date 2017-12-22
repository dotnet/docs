---
title: "dllMainReturnsFalse MDA"
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
  - "managed debugging assistants (MDAs), DllMain returns false"
  - "DllMainReturnsFalse MDA"
  - "DllMain function"
  - "MDAs (managed debugging assistants), DllMain returns false"
ms.assetid: e2abdd04-f571-4b97-8c16-2221b8588429
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# dllMainReturnsFalse MDA
The `dllMainReturnsFalse` managed debugging assistant (MDA) is activated if the managed `DllMain` function of a user assembly, called with reason DLL_PROCESS_ATTACH, returns FALSE.  
  
## Symptoms  
 The `DllMain` function returned FALSE, indicating that it did not execute properly. This can cause undetermined issues because `DllMain` functions typically contain important initialization code.  
  
## Cause  
 The `DllMain` function is called with reason DLL_PROCESS_ATTACH for DLL initialization upon load. If it returns FALSE, it means that DLL initialization failed.  
  
## Resolution  
 Analyze the code of the `DllMain` function of the failed DLL and identify the cause of the initialization failure.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR. It only reports data about the return value for `DllMain`.  
  
## Output  
 A message indicating that a `DllMain` function, called for reason DLL_PROCESS_ATTACH, returned FALSE. Note that this MDA is activated only if `DllMain` is implemented in managed code.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <dllMainReturnsFalse />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
