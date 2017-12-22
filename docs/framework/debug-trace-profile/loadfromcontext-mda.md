---
title: "loadFromContext MDA"
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
  - "MDAs (managed debugging assistants), LoadFrom context"
  - "managed debugging assistants (MDAs), LoadFrom context"
  - "LoadFrom context"
  - "LoadFromContext MDA"
ms.assetid: a9b14db1-d3a9-4150-a767-dcf3aea0071a
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# loadFromContext MDA
The `loadFromContext` managed debugging assistant (MDA) is activated if an assembly is loaded into the `LoadFrom` context. This situation can occur as a result of calling <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> or other similar methods.  
  
## Symptoms  
 The use of some loader methods can result in assemblies being loaded in the `LoadFrom` context. The use of this context can result in unexpected behavior for serialization, casting, and dependency resolution. In general, it is recommended that assemblies be loaded into the `Load` context to avoid these problems. It is difficult to determine which context an assembly has been loaded into without this MDA.  
  
## Cause  
 Generally, an assembly was loaded into the `LoadFrom` context if it was loaded from a path outside the `Load` context, such as the global assembly cache or the <xref:System.AppDomainSetup.ApplicationBase%2A?displayProperty=nameWithType> property.  
  
## Resolution  
 Configure applications such that <xref:System.Reflection.Assembly.LoadFrom%2A> calls are no longer needed. You can use the following techniques for doing so:  
  
-   Install assemblies in the global assembly cache.  
  
-   Place assemblies in the <xref:System.AppDomainSetup.ApplicationBase%2A> directory for the <xref:System.AppDomain>. In the case of the default domain, the <xref:System.AppDomainSetup.ApplicationBase%2A> directory is the one that contains the executable file that started the process. This might also require creating a new <xref:System.AppDomain> if it is not convenient to move the assembly.  
  
-   Add a probing path to your application configuration (.config) file or to secondary  application domains if dependent assemblies are in child directories relative to the executable.  
  
 In each case, the code can be changed to use the <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> method.  
  
## Effect on the Runtime  
 The MDA does not have any effect on the CLR. It reports the context that was used as a result of a load request.  
  
## Output  
 The MDA reports that the assembly was loaded into the `LoadFrom` context. It specifies the simple name of the assembly and the path. It also suggests mitigations to avoid using the `LoadFrom` context.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <loadFromContext />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following code example demonstrates a situation that can activate this MDA:  
  
```  
using System.Reflection;  
namespace ConsoleApplication1  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            // The following call caused the LoadFrom context to be used  
            // because the assembly is loaded using LoadFrom and the path is   
            // located outside of the Load context probing path.   
            Assembly.LoadFrom(@"C:\Text\Test.dll");  
        }  
    }  
}  
```  
  
## See Also  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
