---
title: "Runtime Profiling"
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
  - "performance counters"
  - "common language runtime, profiling"
  - "Perfmon.exe"
  - "System Monitor"
  - "profiling"
  - "runtime, profiling"
  - "profiling applications"
  - "Performance Console"
ms.assetid: ccd68284-f3a8-47b8-bc3f-92e5fe3a1640
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Profiling
Profiling is a method of gathering performance data in any development or deployment scenario. This section is for developers and system administrators who want to gather information about application performance.  
  
## Tracking Performance Using the Performance Monitor (Perfmon.exe)  
 The Performance Monitor is the easiest tool to use to profile your [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] application. The Performance Monitor graphically represents data found in the .NET Framework performance counters that are installed with the common language runtime and the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)]. These counters can be used to monitor everything from memory management to just-in-time (JIT) compiler performance. They tell you about the resources your application uses, which is an indirect measure of your application's performance. Use these counters to understand how your application works internally.  
  
#### To run Perfmon.exe on Windows Vista and later versions  
  
1.  At the command prompt, type **perfmon**. The **Performance Monitor** console appears.  
  
2.  In the **Monitoring Tools** folder, click **Performance Monitor**.  
  
3.  In the Performance Monitor toolbar, click the **Add** icon (the plus sign), if it is present. If it is not present, right-click in the monitor window and select the **Add Counters** option.  
  
     This opens the **Add Counters** dialog box. The **Available counters** list box displays the available performance objects. There are a number of predefined objects for .NET Framework applications, including those for memory management (**.NET CLR Memory**), interoperability (**.NET CLR Interop**), exception handling (**.NET CLR Exceptions**), and multithreading (**.NET CLR LocksAndThreads**). Each performance object includes a number of individual performance counters. For a list of the performance counters available in Performance Monitor, see [Performance Counters](../../../docs/framework/debug-trace-profile/performance-counters.md).  
  
4.  Select the check box next to a performance object's name to view the list of individual performance counters that it supports.  
  
5.  Click the performance counter you want to view.  
  
6.  In the **Instances of selected object** list box, click **\<All instances>** to specify that you want to monitor the performance counter for the common language runtime globally (that is, on a system-wide basis).  
  
     -or-  
  
     In the **Instances of selected object** list box, click an application name to monitor the performance counter for that application.  
  
     To differentiate multiple versions of the runtime, or to disambiguate multiple applications with the same name, you must also modify a registry key. For more information, see [Performance Counters and In-Process Side-By-Side Applications](../../../docs/framework/debug-trace-profile/performance-counters-and-in-process-side-by-side-applications.md).  
  
> [!NOTE]
>  When new performance counters are installed while the Performance console is running, stop and restart the Performance console to make the new counters visible.  
  
 If you want to profile an assembly that exists in a zone or on a remote share, make sure that the remote assembly has full trust on the computer that runs the performance counters. If the assembly does not have sufficient trust, the performance counters will not work. For information about granting trust to different zones, see [Caspol.exe (Code Access Security Policy Tool)](../../../docs/framework/tools/caspol-exe-code-access-security-policy-tool.md).  
  
> [!NOTE]
>  On systems on which the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] is installed, the Performance Monitor may not display data for performance counters in some categories, such as **.NET CLR Data** and **.NET CLR Networking**, for applications that were developed using the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)]. If this is the case, you can configure Performance Monitor to display this data by adding the [\<forcePerformanceCounterUniqueSharedMemoryReads>](../../../docs/framework/configure-apps/file-schema/runtime/forceperformancecounteruniquesharedmemoryreads-element.md) element to the application's configuration file.  
  
## Reading and Creating Performance Counters Programmatically  
 The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] provides classes you can use to programmatically access the same performance information that is available in the Performance console. You can also use these classes to create custom performance counters. The following table describes some of the performance monitoring classes that are provided in the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)].  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType>|Represents a Windows NT performance counter component. Use this class to read existing predefined or custom counters and publish (write) performance data to custom counters.|  
|<xref:System.Diagnostics.PerformanceCounterCategory?displayProperty=nameWithType>|Provides several methods for interacting with counters and categories of counters on the computer.|  
|<xref:System.Diagnostics.PerformanceCounterInstaller?displayProperty=nameWithType>|Specifies an installer for the `PerformanceCounter` component.|  
|<xref:System.Diagnostics.PerformanceCounterType?displayProperty=nameWithType>|Specifies the formula to calculate the `NextValue` method for a `PerformanceCounter`.|  
  
## See Also  
 [Performance Counters](../../../docs/framework/debug-trace-profile/performance-counters.md)
