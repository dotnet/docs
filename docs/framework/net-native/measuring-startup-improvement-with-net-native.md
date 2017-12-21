---
title: "Measuring Startup Improvement with .NET Native"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c4d25b24-9c1a-4b3e-9705-97ba0d6c0289
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Measuring Startup Improvement with .NET Native
[!INCLUDE[net_native](../../../includes/net-native-md.md)] significantly improves the launch time of apps. This improvement is particularly noticeable on portable, low-powered devices and with complex apps. This topic helps you get started with the basic instrumentation needed to measure this startup improvement.  
  
 To facilitate performance investigations, the .NET Framework and Windows use an event framework called Event Tracing for Windows (ETW) that allows your app to notify tooling when events happen. You can then use a tool called PerfView to easily view and analyze of ETW events. This topic explains how to:  
  
-   Use the <xref:System.Diagnostics.Tracing.EventSource> class to emit events.  
  
-   Use PerfView to gather those events.  
  
-   Use PerfView to display those events.  
  
## Using EventSource to emit events  
 <xref:System.Diagnostics.Tracing.EventSource> provides a base class from which to create a custom event provider. Generally, you create a subclass of <xref:System.Diagnostics.Tracing.EventSource> and wrap the `Write*` methods with your own event methods. A singleton pattern is generally used for each <xref:System.Diagnostics.Tracing.EventSource>.  
  
 For example, the class in the following example can be used to measure two performance characteristics:  
  
-   The time until the `App` class constructor was called.  
  
-   The time until the `MainPage` constructor was called.  
  
 [!code-csharp[ProjectN_ETW#1](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_etw/cs/etw1.cs#1)]  
  
 There are a few things to notice here. First, a singleton is created in `AppEventSource.Log`. That instance will be used for all logging. Second, each event method has an <xref:System.Diagnostics.Tracing.EventAttribute>. This helps tooling associate the index of the <xref:System.Diagnostics.Tracing.EventSource.WriteEvent%2A> method with the method that was called on `AppEventSource`.  
  
 Note that these events are purely illustrative. Most app code will run after these events. You should understand which events in code correspond to user interactions, measure those, and improve those benchmarks. Also, the events themselves log only a single instance in time. It’s often useful to have paired start and stop events for every operation. When examining app startup, the start event is generally the "Process/Start" event that the operating system emits.  
  
 For example, suppose you are creating an RSS reader. A few interesting locations to log an event are:  
  
-   When the main page is first rendered.  
  
-   When old RSS stories are deserialized from local storage.  
  
-   When your app begins syncing new stories.  
  
-   When your app has finished syncing new stories.  
  
 Instrumenting an app is straightforward: Just call the appropriate method on the derived class. Using `AppEventSource` from the previous example, you can instrument an app as follows:  
  
 [!code-csharp[ProjectN_ETW#2](../../../samples/snippets/csharp/VS_Snippets_CLR/projectn_etw/cs/etw2.cs#2)]  
  
 When the app is instrumented, you’re ready to gather events.  
  
## Gathering events with PerfView  
 PerfView uses ETW events to help you do all sorts of performance investigations on your app. It also includes a configuration GUI that lets you turn logging for different types of events on or off. PerfView is a free tool and can be downloaded from the [Microsoft Download Center](http://www.microsoft.com/download/details.aspx?id=28567). For more information, watch the [PerfView tutorial videos](http://channel9.msdn.com/Series/PerfView-Tutorial).  
  
> [!NOTE]
>  PerfView cannot be used to collect events on ARM systems. To collect events on ARM systems, use Windows Performance Recorder (WPR). For more information, see [Vance Morrison's blog post](http://blogs.msdn.com/b/vancem/archive/2012/12/19/collecting-etw-perfview-data-on-an-windows-rt-winrt-arm-surface-device.aspx).  
  
 You can also invoke PerfView from the command line. To log only the events from your provider, open the Command Prompt window and enter the command:  
  
```  
perfview -KernelEvents:Process -OnlyProviders:*MyCompany-MyApp collect outputFile   
```  
  
 where:  
  
 `-KernelEvents:Process`  
 Indicates that you want to know when the process starts and stops. You need the Process/Start event for your app so it can be subtracted from other event times.  
  
 `-OnlyProviders:*MyCompany-MyApp`  
 Turns off other providers that PerfView turns on by default, and turns on the MyCompany-MyApp provider.  (The asterisk indicates that it is an <xref:System.Diagnostics.Tracing.EventSource>.)  
  
 `collect outputFile`  
 Indicates that you want to start collection and save the data to outputFile.etl.zip.  
  
 Run your app after starting PerfView. There are a few things to remember when running your app:  
  
-   Use a release build, not a debug build. Debug builds often contain extra error checking and error handling code that can cause your app to run slower than expected.  
  
-   Running your app with a debugger attached affects the performance of your app.  
  
-   Windows uses multiple caching strategies to speed up app launch times. If your app is currently cached in memory and doesn't have to be loaded from disk, it will start faster. To ensure consistency, start and close your app a few times before measuring it.  
  
 When you’ve run your app so that PerfView can collect emitted events, choose the **Stop Collection** button. Generally, you should stop collection before closing your app so you don’t get extraneous events. However, if you’re measuring shutdown or suspension performance, you’ll want to continue collection.  
  
## Displaying the events  
 To view the events that have already been collected, use PerfView to open the .etl or .etl.zip file you created and choose **Events**. ETW will have collected information about a large number of events, including events from other processes. To focus your investigation, complete the following text boxes in the events view:  
  
-   In the **Process Filter** box, specify your app name (without ".exe").  
  
-   In the **Event Types Filter** box, specify `Process/Start | MyCompany-MyApp`. This sets a filter for events from MyCompany-MyApp and the Windows Kernel/Process/Start event.  
  
 Select all the events listed in the left pane (Ctrl-A) and choose the **Enter** key. Now, you should be able to see the timestamps from each event. These timestamps are relative to the start of the trace, so you have to subtract the time of each event from the start time of the process to identify the elapsed time since startup. If you use Ctrl+Click to select two timestamps, you'll see the difference between them displayed in the status bar at the bottom of the page. This makes it easy to see the elapsed time between any two events in the display (including process start). You can open the shortcut menu for the view and select from a number of useful options, like exporting to CSV files or opening Microsoft Excel to save or process the data.  
  
 By repeating the procedure for both your original app and the version you built by using the [!INCLUDE[net_native](../../../includes/net-native-md.md)] tool chain, you can compare the difference in performance.   [!INCLUDE[net_native](../../../includes/net-native-md.md)] apps generally start faster than non-[!INCLUDE[net_native](../../../includes/net-native-md.md)] apps. If you’re interested in digging deeper, PerfView can also identify the parts of your code that are taking the most time. For more information, watch the [PerfView tutorials](http://channel9.msdn.com/Series/PerfView-Tutorial) or read [Vance Morrison’s blog entry](http://blogs.msdn.com/b/vancem/archive/2011/12/28/publication-of-the-perfview-performance-analysis-tool.aspx).  
  
## See Also  
 <xref:System.Diagnostics.Tracing.EventSource>
