---
title: "Performance Counters and In-Process Side-By-Side Applications"
description: Review performance counters and in-process side-by-side applications in .NET. Use Perfmon.exe to differentiate the performance counters on a per-runtime basis.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "performance counters"
  - "performance counters,and in-process side-by-side applications"
  - "performance,.NET Framework applications"
  - "performance monitoring,counters"
ms.assetid: 6888f9be-c65b-4b03-a07b-df7ebdee2436
---
# Performance Counters and In-Process Side-By-Side Applications

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

Using the Performance Monitor (Perfmon.exe), it is possible to differentiate the performance counters on a per-runtime basis. This topic describes the registry change needed to enable this functionality.

## The Default Behavior

 By default, the Performance Monitor displays performance counters on a per-application basis. However, there are two scenarios in which this is problematic:

- When you monitor two applications that have the same name. For example, if both applications are named myapp.exe, one will be displayed as **myapp** and the other as **myapp#1** in the **Instance** column. In this case, it is difficult to match a performance counter to a particular application. It is not clear whether the data collected for **myapp#1** refers to the first myapp.exe or the second myapp.exe.

- When an application uses multiple instances of the common language runtime. The .NET Framework 4 supports in-process side-by-side hosting scenarios; that is, a single process or application can load multiple instances of the common language runtime. If a single application named myapp.exe loads two runtime instances, by default, they will be designated in the **Instance** column as **myapp** and **myapp#1**. In this case, it is not clear whether **myapp** and **myapp#1** refer to two applications with the same name, or to the same application with two runtimes. If multiple applications with the same name load multiple runtimes, the ambiguity is even greater.

 You can set a registry key to eliminate this ambiguity. For applications developed using the .NET Framework 4, this registry change adds a process identifier followed by a runtime instance identifier to the application name in the **Instance** column. Instead of *application* or *application*#1, the application is now identified as *application*_`p`*processID*\_`r`*runtimeID* in the **Instance** column. If an application was developed using a previous version of the common language runtime, that instance is represented as *application\_*`p`*processID* provided that the .NET Framework 4 is installed.

## Performance Counters for In-Process Side-by-Side Applications

 To handle performance counters for multiple common language runtime versions that are hosted in a single application, you must change a single registry key setting, as shown in the following table.

|           | Value                                                                           |
| --------- | ------------------------------------------------------------------------------- |
| **Key**   | HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\\.NETFramework\Performance |
| **Entry** | ProcessNameFormat                                                               |
| **Type**  | REG_DWORD                                                                       |
| **Value** | 2 (0x00000002)                                                                  |

 A value of 0 for `ProcessNameFormat` indicates that the default behavior is enabled; that is, Perfmon.exe displays performance counters on a per-application basis. When you set this value to 2, Perfmon.exe disambiguates multiple versions of an application and provides performance counters on a per-runtime basis. Any other value for the `ProcessNameFormat` registry key setting is unsupported and reserved for future use.

 After you update the `ProcessNameFormat` registry key setting, you must restart Perfmon.exe or any other consumers of performance counters so that the new instance naming feature works correctly.

 The following example shows how to change the `ProcessNameFormat` value programmatically.

 [!code-csharp[Conceptual.PerfCounters.InProSxS#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.perfcounters.inprosxs/cs/regsetting1.cs#1)]
 [!code-vb[Conceptual.PerfCounters.InProSxS#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.perfcounters.inprosxs/vb/regsetting1.vb#1)]

 When you make this registry change, and if .NET Framework 4 or later is installed, Perfmon.exe displays the names of applications as *application*_`p`*processID*, where *application* is the name of the application, and *processID* is the application's process identifier. For example, if an application named myapp.exe loads two instances of the common language runtime, Perfmon.exe may identify one instance as myapp_1416 and the second as myapp_3160.

> [!NOTE]
> The process identifier eliminates the ambiguity of resolving two applications with the same name that use earlier versions of the runtime. A runtime identifier is not required for previous versions, because previous versions of the common language runtime do not support side-by-side scenarios.

 If the .NET Framework 4 or a later version is not present or was uninstalled, setting the registry key has no effect. This means that two applications with the same name will continue to appear in Perfmon.exe as *application* and *application#1* (for example, as **myapp** and **myapp#1**).
