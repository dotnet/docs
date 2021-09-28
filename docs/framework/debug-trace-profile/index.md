---
title: "Debugging, Tracing, and Profiling"
description: Read about debugging, tracing, and profiling in .NET. See articles covering just-in-time (JIT) debugging, tracing and instrumenting applications, and more.
ms.date: "03/30/2017"
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
---
# Debugging, Tracing, and Profiling

To debug a .NET Framework application, the compiler and runtime environment must be configured to enable a debugger to attach to the application and to produce both symbols and line maps, if possible, for the application and its corresponding Microsoft intermediate language (MSIL). After a managed application has been debugged, it can be profiled to boost performance. Profiling evaluates and describes the lines of source code that generate the most frequently executed code, and how much time it takes to execute them.  
  
 .NET Framework applications are easily debugged by using Visual Studio, which handles many of the configuration details. If Visual Studio is not installed, you can examine and improve the performance of .NET Framework applications by using the debugging classes in the .NET Framework <xref:System.Diagnostics> namespace. This namespace includes the <xref:System.Diagnostics.Trace>, <xref:System.Diagnostics.Debug>, and <xref:System.Diagnostics.TraceSource> classes for tracing execution flow, and the <xref:System.Diagnostics.Process>, <xref:System.Diagnostics.EventLog>, and <xref:System.Diagnostics.PerformanceCounter> classes for profiling code.  
  
## In This Section  

 [Enabling JIT-Attach Debugging](enabling-jit-attach-debugging.md)  
 Shows how to configure the registry to JIT-attach a debug engine to a .NET Framework application.  
  
 [Making an Image Easier to Debug](making-an-image-easier-to-debug.md)  
 Shows how to turn JIT tracking on and optimization off to make an assembly easier to debug.  
  
 [Tracing and Instrumenting Applications](tracing-and-instrumenting-applications.md)  
 Describes how to monitor the execution of your application while it is running, and how to instrument it to display how well it is performing or whether something has gone wrong.  
  
 [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)  
 Describes managed debugging assistants (MDAs), which are debugging aids that work in conjunction with the common language runtime (CLR) to provide information on runtime state.  
  
 [Enhancing Debugging with the Debugger Display Attributes](enhancing-debugging-with-the-debugger-display-attributes.md)  
 Describes how the developer of a type can specify what that type will look like when it is displayed in a debugger.  
  
 [Performance Counters](performance-counters.md)  
 Describes the counters that you can use to track the performance of an application.  
  
## Related Sections  

 [Debug ASP.NET or ASP.NET Core apps in Visual Studio](/visualstudio/debugger/how-to-enable-debugging-for-aspnet-applications)  
 Provides prerequisites and instructions for how to debug an ASP.NET application during development or after deployment.  
  
 [Development Guide](../development-guide.md)  
 Provides a guide to all key technology areas and tasks for application development, including creating, configuring, debugging, securing, and deploying your application, and information about dynamic programming, interoperability, extensibility, memory management, and threading.
