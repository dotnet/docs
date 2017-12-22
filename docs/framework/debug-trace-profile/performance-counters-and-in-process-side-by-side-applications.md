---
title: "Performance Counters and In-Process Side-By-Side Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "performance counters"
  - "performance counters,and in-process side-by-side applications"
  - "performance,.NET Framework applications"
  - "performance monitoring,counters"
ms.assetid: 6888f9be-c65b-4b03-a07b-df7ebdee2436
caps.latest.revision: 26
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Performance Counters and In-Process Side-By-Side Applications
Using the Performance Monitor (Perfmon.exe), it is possible to differentiate the performance counters on a per-runtime basis. This topic describes the registry change needed to enable this functionality.  
  
## The Default Behavior  
 By default, the Performance Monitor displays performance counters on a per-application basis. However, there are two scenarios in which this is problematic:  
  
-   When you monitor two applications that have the same name. For example, if both applications are named myapp.exe, one will be displayed as **myapp** and the other as **myapp#1** in the **Instance** column. In this case, it is difficult to match a performance counter to a particular application. It is not clear whether the data collected for **myapp#1** refers to the first myapp.exe or the second myapp.exe.  
  
-   When an application uses multiple instances of the common language runtime. The [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] supports in-process side-by-side hosting scenarios; that is, a single process or application can load multiple instances of the common language runtime. If a single application named myapp.exe loads two runtime instances, by default, they will be designated in the **Instance** column as **myapp** and **myapp#1**. In this case, it is not clear whether **myapp** and **myapp#1** refer to two applications with the same name, or to the same application with two runtimes. If multiple applications with the same name load multiple runtimes, the ambiguity is even greater.  
  
 You can set a registry key to eliminate this ambiguity. For applications developed using the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], this registry change adds a process identifier followed by a runtime instance identifier to the application name in the **Instance** column. Instead of *application* or *application*#1, the application is now identified as *application*_`p`*processID*\_`r`*runtimeID* in the **Instance** column. If an application was developed using a previous version of the common language runtime, that instance is represented as *application\_*`p`*processID* provided that the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] is installed.  
  
## Performance Counters for In-Process Side-by-Side Applications  
 To handle performance counters for multiple common language runtime versions that are hosted in a single application, you must change a single registry key setting, as shown in the following table.  
  
|||  
|-|-|  
|Key name|HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\\.NETFramework\Performance|  
|Value name|ProcessNameFormat|  
|Value type|REG_DWORD|  
|Value|1 (0x00000001)|  
  
 A value of 0 for `ProcessNameFormat` indicates that the default behavior is enabled; that is, Perfmon.exe displays performance counters on a per-application basis. When you set this value to 1, Perfmon.exe disambiguates multiple versions of an application and provides performance counters on a per-runtime basis. Any other value for the `ProcessNameFormat` registry key setting is unsupported and reserved for future use.  
  
 After you update the `ProcessNameFormat` registry key setting, you must restart Perfmon.exe or any other consumers of performance counters so that the new instance naming feature works correctly.  
  
 The following example shows how to change the `ProcessNameFormat` value programmatically.  
  
 [!code-csharp[Conceptual.PerfCounters.InProSxS#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.perfcounters.inprosxs/cs/regsetting1.cs#1)]
 [!code-vb[Conceptual.PerfCounters.InProSxS#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.perfcounters.inprosxs/vb/regsetting1.vb#1)]  
  
 When you make this registry change, Perfmon.exe displays the names of applications that target the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] as *application*_`p`*processID*\_`r`*runtimeID*, where *application* is the name of the application, *processID* is the application's process identifier, and *runtimeID* is a common language runtime identifier. For example, if an application named myapp.exe loads two instances of the common language runtime, Perfmon.exe may identify one instance as myapp_p1416_r10 and the second as myapp_p3160_r10. The runtime identifier only disambiguates the runtimes within a process; it does not provide any other information about the runtime. (For example, the runtime ID has no relation to the version or the SKU of the runtime.)  
  
 If the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] is installed, the registry change also affects applications that were developed using earlier versions of the .NET Framework. These appear in Perfmon.exe as *application_*`p`*processID*, where *application* is the application name and *processID* is the process identifier. For example, if the performance counters of two applications named myapp.exe are monitored, one might appear as myapp_p23900 and the other as myapp_p24908.  
  
> [!NOTE]
>  The process identifier eliminates the ambiguity of resolving two applications with the same name that use earlier versions of the runtime. A runtime identifier is not required for previous versions, because previous versions of the common language runtime do not support side-by-side scenarios.  
  
 If the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] is not present or was uninstalled, setting the registry key has no effect. This means that two applications with the same name will continue to appear in Perfmon.exe as *application* and *application#1* (for example, as **myapp** and **myapp#1**).
