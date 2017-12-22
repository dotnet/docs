---
title: "Debugging, Tracing, and Profiling"
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
  - "debugging [.NET Framework]"
  - ".NET Framework application configuration, debugging"
  - "debugging [.NET Framework], .NET Framework application debugging"
  - "troubleshooting applications [.NET Framework], profiling"
  - "application development [.NET Framework], debugging"
  - ".NET Framework application configuration, profiling"
  - "profiling applications"
  - "troubleshooting applications [.NET Framework], debugging"
  - "troubleshooting applications [.NET Framework]"
  - "application development [.NET Framework], profiling"
ms.assetid: 4a04863e-2475-46f4-bc3f-3c11510c2a4b
caps.latest.revision: 28
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Debugging, Tracing, and Profiling
To debug a .NET Framework application, the compiler and runtime environment must be configured to enable a debugger to attach to the application and to produce both symbols and line maps, if possible, for the application and its corresponding Microsoft intermediate language (MSIL). After a managed application has been debugged, it can be profiled to boost performance. Profiling evaluates and describes the lines of source code that generate the most frequently executed code, and how much time it takes to execute them.  
  
 .NET Framework applications are easily debugged by using Visual Studio, which handles many of the configuration details. If Visual Studio is not installed, you can examine and improve the performance of .NET Framework applications by using the debugging classes in the .NET Framework <xref:System.Diagnostics> namespace. This namespace includes the <xref:System.Diagnostics.Trace>, <xref:System.Diagnostics.Debug>, and <xref:System.Diagnostics.TraceSource> classes for tracing execution flow, and the <xref:System.Diagnostics.Process>, <xref:System.Diagnostics.EventLog>, and <xref:System.Diagnostics.PerformanceCounter> classes for profiling code.  
  
## In This Section  
 [Enabling JIT-Attach Debugging](../../../docs/framework/debug-trace-profile/enabling-jit-attach-debugging.md)  
 Shows how to configure the registry to JIT-attach a debug engine to a .NET Framework application.  
  
 [Making an Image Easier to Debug](../../../docs/framework/debug-trace-profile/making-an-image-easier-to-debug.md)  
 Shows how to turn JIT tracking on and optimization off to make an assembly easier to debug.  
  
 [Tracing and Instrumenting Applications](../../../docs/framework/debug-trace-profile/tracing-and-instrumenting-applications.md)  
 Describes how to monitor the execution of your application while it is running, and how to instrument it to display how well it is performing or whether something has gone wrong.  
  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)  
 Describes managed debugging assistants (MDAs), which are debugging aids that work in conjunction with the common language runtime (CLR) to provide information on runtime state.  
  
 [Enhancing Debugging with the Debugger Display Attributes](../../../docs/framework/debug-trace-profile/enhancing-debugging-with-the-debugger-display-attributes.md)  
 Describes how the developer of a type can specify what that type will look like when it is displayed in a debugger.  
  
 [Performance Counters](../../../docs/framework/debug-trace-profile/performance-counters.md)  
 Describes the counters that you can use to track the performance of an application.  
  
## Related Sections  
 [Debugging ASP.NET and AJAX Applications](http://msdn.microsoft.com/library/9d531913-541b-47b8-864d-138021fca0c6)  
 Provides prerequisites and instructions for how to debug an ASP.NET application during development or after deployment.  
  
 [Development Guide](../../../docs/framework/development-guide.md)  
 Provides a guide to all key technology areas and tasks for application development, including creating, configuring, debugging, securing, and deploying your application, and information about dynamic programming, interoperability, extensibility, memory management, and threading.
