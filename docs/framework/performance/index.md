---
title: ".NET Framework Performance"
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
  - "performance [.NET Framework]"
  - "reliability [.NET Framework]"
ms.assetid: c1676cca-3f1a-41ec-b469-9029566074fc
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# .NET Framework Performance
If you want to create apps with great performance, you should design and plan for performance just as you would design any other feature of your app. You can use the tools provided by Microsoft to measure your app's performance, and, if needed, make improvements to memory use, code throughput, and responsiveness. This topic lists the performance analysis tools that Microsoft provides, and provides links to other topics that cover performance for specific areas of app development.  
  
## Designing and planning for performance  
 If you want a great performing app, you must design performance into your app just as you would design any other feature. You should determine the performance-critical scenarios in your app, set performance goals, and measure performance for these app scenarios early and often. Because each app is different and has different performance-critical execution paths, determining those paths early and focusing your efforts enable you to maximize your productivity.  
  
 You don’t have to be completely familiar with your target platform to create a high-performance app. However, you should develop an understanding of which parts of your target platform are costly in terms of performance. You can do this by measuring performance early in your development process.  
  
 To determine the areas that are crucial to performance and to establish your performance goals, always consider the user experience. Startup time and responsiveness are two key areas that will affect the user’s perception of your app. If your app uses a lot of memory, it may appear sluggish to the user or affect other apps running on the system, or, in some cases, it could fail the Windows Store or Windows Phone Store submission process. Also, if you determine which parts of your code execute more frequently, you can make sure that these portions of your code are well optimized.  
  
## Analyzing performance  
 As part of your overall development plan, set points during development where you will measure the performance of your app and compare the results with the goals you set previously. Measure your app in the environment and hardware that you expect your users to have. By analyzing your app’s performance early and often you can change architectural decisions that would be costly and expensive to fix later in the development cycle. The following sections describe performance tools you can use to analyze your apps and discuss event tracing, which is used by these tools.  
  
### Performance tools  
 Here are some of the performance tools you can use with your .NET Framework apps.  
  
|Tool|Description|  
|----------|-----------------|  
|Visual Studio Performance Analysis|Use to analyze the CPU usage of your .NET Framework apps that will be deployed to computers that are running the Windows operating system.<br /><br /> This tool is available from the **Debug** menu in Visual Studio after you open a project. For more information, see [Performance Explorer](/visualstudio/profiling/performance-explorer). **Note:**  Use Windows Phone Application Analysis (see next row) when targeting Windows Phone.|  
|Windows Phone Application Analysis|Use to analyze the CPU and memory, network data transfer rate, app responsiveness, and battery consumption in your Windows Phone apps.<br /><br /> This tool is available from the **Debug** menu for a Windows Phone project in Visual Studio after you install the [Windows Phone SDK](http://go.microsoft.com/fwlink/?LinkId=265773). For more information, see [App profiling for Windows Phone](http://msdn.microsoft.com/library/windowsphone/develop/jj215908\(v=vs.105\).aspx).|  
|[PerfView](http://www.microsoft.com/download/details.aspx?id=28567)|Use to identify CPU and memory-related performance issues. This tool uses event tracing for Windows (ETW)  and CLR profiling APIs to provide advanced memory and CPU investigations as well as information about garbage collection and JIT compilation. For more information about how to use PerfView, see the tutorial and help files that are included with the app, [Channel 9 video tutorials](http://channel9.msdn.com/Series/PerfView-Tutorial), and [blog posts](http://blogs.msdn.com/b/vancem/archive/tags/perfview/).<br /><br /> For memory-specific issues, see [Using PerfView for Memory Investigations](http://channel9.msdn.com/Series/PerfView-Tutorial/PerfView-Tutorial-9-NET-Memory-Investigation-Basics-of-GC-Heap-Snapshots).|  
|[Windows Performance Analyzer](http://www.microsoft.com/download/details.aspx?id=30652)|Use to determine overall system performance such as your app's memory and storage use when multiple apps are running on the same computer. This tool is available from the download center as part of the Windows Assessment and Deployment Kit (ADK) for [!INCLUDE[win8](../../../includes/win8-md.md)]. For more information, see [Windows Performance Analyzer](http://msdn.microsoft.com/library/windows/desktop/hh448170.aspx).|  
  
### Event tracing for Windows (ETW)  
 ETW is a technique that lets you obtain diagnostic information about running code and is essential for many of the performance tools mentioned previously. ETW creates logs when particular events are raised by .NET Framework apps and Windows. With ETW, you can enable and disable logging dynamically, so that you can perform detailed tracing in a production environment without restarting your app. The .NET Framework offers support for ETW events, and ETW is used by many profiling and performance tools to generate performance data. These tools often enable and disable ETW events, so familiarity with them is helpful. You can use specific ETW events to collect performance information about particular components of your app. For more information about ETW support in the .NET Framework, see [ETW Events in the Common Language Runtime](../../../docs/framework/performance/etw-events-in-the-common-language-runtime.md) and [ETW Events in Task Parallel Library and PLINQ](../../../docs/framework/performance/etw-events-in-task-parallel-library-and-plinq.md).  
  
## Performance by app type  
 Each type of .NET Framework app has its own best practices, considerations, and tools for evaluating performance. The following table links to performance topics for specific .NET Framework app types.  
  
|App type|See|  
|--------------|---------|  
|.NET Framework apps for all platforms|[Garbage Collection and Performance](../../../docs/standard/garbage-collection/performance.md)<br /><br /> [Performance Tips](../../../docs/framework/performance/performance-tips.md)|  
|[!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps written in C++, C#, and Visual Basic|[Performance best practices for Windows Store apps using C++, C#, and Visual Basic](http://msdn.microsoft.com/library/windows/apps/hh750313.aspx)|  
|Windows Phone|[App performance considerations for Windows Phone](http://msdn.microsoft.com/library/windowsphone/develop/ff967560\(v=vs.105\).aspx)<br /><br /> [Windows Phone Application Analysis](http://msdn.microsoft.com/library/windowsphone/develop/hh202934\(v=vs.105\).aspx)<br /><br /> [Get Your Windows Phone Applications in the Marketplace Faster](http://msdn.microsoft.com/magazine/hh781024.aspx)|  
|Windows Presentation Foundation (WPF)|[WPF Performance Suite](http://msdn.microsoft.com/library/67cafaad-57ad-4ecb-9c08-57fac144393e)|  
|Silverlight|[Performance tips](http://msdn.microsoft.com/library/cc189071\(v=vs.95\).aspx)|  
|ASP.NET|[ASP.NET Performance Overview](http://msdn.microsoft.com/library/f882bf1b-a009-4312-ac06-74370ffabc0b)|  
|Windows Forms|[Practical Tips for Boosting the Performance of Windows Forms Apps](http://msdn.microsoft.com/magazine/cc163630.aspx)|  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Caching in .NET Framework Applications](../../../docs/framework/performance/caching-in-net-framework-applications.md)|Describes techniques for caching data to improve performance in your app.|  
|[Lazy Initialization](../../../docs/framework/performance/lazy-initialization.md)|Describes how to initialize objects as-needed to improve performance, particularly at app startup.|  
|[Reliability](../../../docs/framework/performance/reliability.md)|Provides information about preventing asynchronous exceptions in a server environment.|  
|[Writing Large, Responsive .NET Framework Apps](../../../docs/framework/performance/writing-large-responsive-apps.md)|Provides performance tips gathered from rewriting the C# and Visual Basic compilers in managed code, and includes several real examples from the C# compiler.|
