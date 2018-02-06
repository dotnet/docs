---
title: "memberInfoCacheCreation MDA"
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
  - "member info cache creation"
  - "MemberInfoCacheCreation MDA"
  - "reflection, run-time errors"
  - "MDAs (managed debugging assistants), cache"
  - "cache [.NET Framework], reflection"
  - "managed debugging assistants (MDAs), cache"
  - "MemberInfo cache"
ms.assetid: 5abdad23-1335-4744-8acb-934002c0b6fe
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# memberInfoCacheCreation MDA
The `memberInfoCacheCreation` managed debugging assistant (MDA) is activated when a <xref:System.Reflection.MemberInfo> cache is created. This is a strong indication of a program that is making use of resource-expensive reflection features.  
  
## Symptoms  
 A program's working set increases because the program is using resource-expensive reflection.  
  
## Cause  
 Reflection operations that involve <xref:System.Reflection.MemberInfo> objects are considered resource expensive because they must read metadata that is stored in cold pages and in general they indicate the program is using some type of late-bound scenario.  
  
## Resolution  
 You can determine where reflection is being used in your program by enabling this MDA and then running your code in a debugger or attaching with a debugger when the MDA is activated. Under a debugger you will get a stack trace showing where the <xref:System.Reflection.MemberInfo> cache was created and from there you can determine where your program is using reflection.  
  
 The resolution is dependent on the objectives of the code. This MDA alerts you that your program has a late-bound scenario. You might want to determine if you can substitute an early-bound scenario or consider the performance of the late bound scenario.  
  
## Effect on the Runtime  
 This MDA is activated for every <xref:System.Reflection.MemberInfo> cache that is created. The performance impact is negligible.  
  
## Output  
 The MDA outputs a message indicating the <xref:System.Reflection.MemberInfo> cache was created. Use a debugger to get a stack trace showing where your program is using reflection.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <memberInfoCacheCreation/>  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 This sample code will activate the `memberInfoCacheCreation` MDA.  
  
```  
using System;  
  
public class Exe  
{  
    public static void Main()  
    {  
        typeof(object).GetMethods();  
    }  
}  
```  
  
## See Also  
 <xref:System.Reflection.MemberInfo>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
