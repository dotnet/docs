---
title: "bindingFailure MDA"
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
  - "binding failure"
  - "binding, failures"
  - "MDAs (managed debugging assistants), binding failures"
  - "assemblies [.NET Framework], binding failures"
  - "managed debugging assistants (MDAs), binding failures"
  - "BindingFailure MDA"
ms.assetid: 26ada5af-175c-4576-931a-9f07fa1723e9
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# bindingFailure MDA
The `bindingFailure` managed debugging assistant (MDA) is activated when an assembly fails to load.  
  
## Symptoms  
 Code has attempted to load an assembly using a static reference or one of the loader methods, such as <xref:System.Reflection.Assembly.Load%2A?displayProperty=nameWithType> or <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType>. The assembly is not loaded and a <xref:System.IO.FileNotFoundException> or <xref:System.IO.FileLoadException> exception is thrown.  
  
## Cause  
 A binding failure occurs when the runtime is unable to load an assembly. A binding failure might be the result of one of the following situations:  
  
-   The common language runtime (CLR) cannot find the requested assembly. There are many reasons this can occur, such as the assembly not being installed or the application not being correctly configured to find the assembly.  
  
-   A common problem scenario is passing a type to another application domain, which requires the CLR to load the assembly containing that type in the other application domain. It may not be possible for the runtime to load the assembly if the other application domain is configured differently from the original application domain. For example, the two application domains might have different <xref:System.AppDomain.BaseDirectory%2A> property values.  
  
-   The requested assembly is corrupted or is not an assembly.  
  
-   The code attempting to load the assembly does not have the correct code access security permissions to load assemblies.  
  
-   The user credentials do not provide the required permissions to read the file.  
  
## Resolution  
 The first step is to determine why the CLR could not bind to the requested assembly. There are many reasons why the runtime might not have found or been able load the requested assembly, such as the scenarios listed in the Cause section. The following actions are recommended to eliminate the cause of the binding failure:  
  
-   Determine the cause by using the data provided by the `bindingFailure` MDA:  
  
    -   Run the [Fuslogvw.exe (Assembly Binding Log Viewer)](../../../docs/framework/tools/fuslogvw-exe-assembly-binding-log-viewer.md) to read the error logs produced by the assembly binder.  
  
    -   Determine if the assembly is at the location requested. In the case of the <xref:System.Reflection.Assembly.LoadFrom%2A> and <xref:System.Reflection.Assembly.LoadFile%2A> methods, the requested location can be easily determined. In the case of the <xref:System.Reflection.Assembly.Load%2A> method, which binds using the assembly identity, you must look for assemblies that match that identity in the application domain's <xref:System.AppDomain.BaseDirectory%2A> property probe path and the global assembly cache.  
  
-   Resolve the cause based on the preceding determination. Possible resolution options are the following:  
  
    -   Install the requested assembly in the global assembly cache and call the. <xref:System.Reflection.Assembly.Load%2A> method to load the assembly by identity.  
  
    -   Copy the requested assembly into the application directory and call the <xref:System.Reflection.Assembly.Load%2A> method to load the assembly by identity.  
  
    -   Reconfigure the application domain in which the binding failure occurred to include the assembly path by either changing the <xref:System.AppDomain.BaseDirectory%2A> property or adding private probing paths.  
  
    -   Change the access control list for the file to allow the logged-on user to read the file.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR. It only reports data about binding failures.  
  
## Output  
 The MDA reports the assembly that failed to load, including the requested path and/or display name, the binding context, the application domain in which the load was requested, and the reason for the failure.  
  
 The display name or requested path may be blank if that data was not available to the CLR. If the call that failed was to the <xref:System.Reflection.Assembly.Load%2A> method, it is likely the runtime could not determine the display name for the assembly.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <bindingFailure />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following code example demonstrates a situation that can activate this MDA:  
  
```  
using System;  
using System.Collections.Generic;  
using System.Text;  
using System.Reflection;  
namespace ConsoleApplication1  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            // This call attempts to load a nonexistent assembly.  
            // The call will throw a System.IO.FileNotFound exception  
            // and cause the activation of the bindingFailure MDA   
            // if it is registered.  
            Assembly.Load("NonExistentAssembly");  
        }  
    }  
}  
```  
  
## See Also  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
