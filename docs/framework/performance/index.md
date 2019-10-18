---
title: ".NET Framework Performance"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "performance [.NET Framework]"
  - "reliability [.NET Framework]"
ms.assetid: c1676cca-3f1a-41ec-b469-9029566074fc
author: "mairaw"
ms.author: "mairaw"
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
|Windows Phone Application Analysis|Use to analyze the CPU and memory, network data transfer rate, app responsiveness, and battery consumption in your Windows Phone apps.<br /><br /> This tool is available from the **Debug** menu for a Windows Phone project in Visual Studio after you install the [Windows Phone SDK](https://go.microsoft.com/fwlink/?LinkId=265773). For more information, see [App profiling for Windows Phone 8](https://docs.microsoft.com/previous-versions/windows/apps/jj215908(v=vs.105)).|  
|[PerfView](https://www.microsoft.com/download/details.aspx?id=28567)|Use to identify CPU and memory-related performance issues. This tool uses event tracing for Windows (ETW)  and CLR profiling APIs to provide advanced memory and CPU investigations as well as information about garbage collection and JIT compilation. For more information about how to use PerfView, see the tutorial and help files that are included with the app, [Channel 9 video tutorials](https://channel9.msdn.com/Series/PerfView-Tutorial), and [blog posts](https://blogs.msdn.microsoft.com/vancem/tag/perfview/).<br /><br /> For memory-specific issues, see [Using PerfView for Memory Investigations](https://channel9.msdn.com/Series/PerfView-Tutorial/PerfView-Tutorial-9-NET-Memory-Investigation-Basics-of-GC-Heap-Snapshots).|  
|[Windows Performance Analyzer](https://www.microsoft.com/download/details.aspx?id=30652)|Use to determine overall system performance such as your app's memory and storage use when multiple apps are running on the same computer. This tool is available from the download center as part of the Windows Assessment and Deployment Kit (ADK) for [!INCLUDE[win8](../../../includes/win8-md.md)]. For more information, see [Windows Performance Analyzer](/windows-hardware/test/wpt/windows-performance-analyzer).|  
  
### Event tracing for Windows (ETW)  
 ETW is a technique that lets you obtain diagnostic information about running code and is essential for many of the performance tools mentioned previously. ETW creates logs when particular events are raised by .NET Framework apps and Windows. With ETW, you can enable and disable logging dynamically, so that you can perform detailed tracing in a production environment without restarting your app. The .NET Framework offers support for ETW events, and ETW is used by many profiling and performance tools to generate performance data. These tools often enable and disable ETW events, so familiarity with them is helpful. You can use specific ETW events to collect performance information about particular components of your app. For more information about ETW support in the .NET Framework, see [ETW Events in the Common Language Runtime](etw-events-in-the-common-language-runtime.md) and [ETW Events in Task Parallel Library and PLINQ](etw-events-in-task-parallel-library-and-plinq.md).  
  
## Performance by app type  
 Each type of .NET Framework app has its own best practices, considerations, and tools for evaluating performance. The following table links to performance topics for specific .NET Framework app types.  
  
|App type|See|  
|--------------|---------|  
|.NET Framework apps for all platforms|[Garbage Collection and Performance](../../standard/garbage-collection/performance.md)<br /><br /> [Performance Tips](performance-tips.md)|  
|[!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps written in C++, C#, and Visual Basic|[Performance best practices for Windows Store apps using C++, C#, and Visual Basic](https://docs.microsoft.com/previous-versions/windows/apps/hh750313%28v=win.10%29)|  
|Windows Presentation Foundation (WPF)|[WPF Performance Suite](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/aa969767(v=vs.100))|  
|ASP.NET|[ASP.NET Performance Overview](https://docs.microsoft.com/previous-versions/aspnet/cc668225(v=vs.100))|  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Caching in .NET Framework Applications](caching-in-net-framework-applications.md)|Describes techniques for caching data to improve performance in your app.|  
|[Lazy Initialization](lazy-initialization.md)|Describes how to initialize objects as-needed to improve performance, particularly at app startup.|  
|[Reliability](reliability.md)|Provides information about preventing asynchronous exceptions in a server environment.|  
|[Writing Large, Responsive .NET Framework Apps](writing-large-responsive-apps.md)|Provides performance tips gathered from rewriting the C# and Visual Basic compilers in managed code, and includes several real examples from the C# compiler.|
