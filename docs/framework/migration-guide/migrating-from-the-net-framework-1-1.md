---
title: "Migrating from the .NET Framework 1.1"
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
  - ".NET Framework 4.5, migrating from 1.1"
  - ".NET Framework 1.1, migrating to .NET Framework 4.5"
ms.assetid: 7ead0cb3-3b19-414a-8417-a1c1fa198d9e
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Migrating from the .NET Framework 1.1
[!INCLUDE[win7](../../../includes/win7-md.md)] and later versions of the Windows operating system do not support the [!INCLUDE[net_v11_long](../../../includes/net-v11-long-md.md)]. As a result, applications that target the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)] will not run without modification on [!INCLUDE[win7](../../../includes/win7-md.md)] or later operating system versions. This topic discusses the steps required to run an application that targets the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)] under [!INCLUDE[win7](../../../includes/win7-md.md)] and later versions of the Windows operating system. For more information about the [!INCLUDE[net_v11_long](../../../includes/net-v11-long-md.md)] and [!INCLUDE[win8](../../../includes/win8-md.md)], see [Running .NET Framework 1.1 Apps on Windows 8 and later versions](../../../docs/framework/install/run-net-framework-1-1-apps.md).  
  
## Retargeting or Recompiling  
 There are two ways to get an application that was compiled using the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)] to run on [!INCLUDE[win7](../../../includes/win7-md.md)] or a later Windows operating system:  
  
-   You can retarget the application to run under [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)]. Retargeting requires that you add a [\<supportedRuntime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) element to the application's configuration file that allows it to run under [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. Such a configuration file takes the following form:  
  
    ```xml  
    <configuration>   
       <startup>  
          <supportedRuntime version="v4.0"/>  
       </startup>  
    </configuration>  
    ```  
  
-   You can recompile the application with a compiler that targets the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. If you originally used Visual Studio 2003 to develop and compile your solution, you can open the solution in [!INCLUDE[vs_dev10_long](../../../includes/vs-dev10-long-md.md)] and use the **Project Compatibility** dialog box to convert the solution and project files from the formats used by Visual Studio 2003 to the Microsoft Build Engine (MSBuild) format used by [!INCLUDE[vs_dev10_long](../../../includes/vs-dev10-long-md.md)].  
  
 Regardless of whether you prefer to recompile or retarget your application, you must determine whether your application is affected by any changes introduced in later versions of the .NET Framework. These changes are of two kinds:  
  
-   Breaking changes that occurred between the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)] and later versions of the .NET Framework.  
  
-   Types and type members that have been marked as deprecated or obsolete between the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)] and later versions of the .NET Framework.  
  
 Whether you retarget your application or recompile it, you should review both the breaking changes and the obsolete types and members for each version of the .NET Framework that was released after [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)].  
  
## Breaking Changes  
 When a breaking change occurs, depending on the specific change, a workaround may be available both for retargeted and recompiled applications. In some cases, you can add a child element to the [\<runtime>](../../../docs/framework/configure-apps/file-schema/startup/supportedruntime-element.md) element of your application's configuration file to restore the previous behavior. For example, the following configuration file restores the string sorting and comparison behavior used in the [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)] and can be used either with a retargeted or a recompiled application.  
  
```xml  
<configuration>  
   <runtime>  
      <CompatSortNLSVersion enabled="4096"/>  
   </runtime>  
</configuration>  
```  
  
 However, in some cases, you may have to modify your source code and recompile your application.  
  
 To assess the impact of possible breaking changes on your application, you must review the following lists of changes:  
  
-   [Breaking Changes in .NET Framework 2.0](http://go.microsoft.com/fwlink/?LinkId=125263) documents changes in [!INCLUDE[net_v20SP1_short](../../../includes/net-v20sp1-short-md.md)] that can affect an application that targets [!INCLUDE[net_v11_short](../../../includes/net-v11-short-md.md)].  
  
-   [Changes in .NET Framework 3.5 SP1](http://go.microsoft.com/fwlink/?LinkID=186989) documents changes between the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and the [!INCLUDE[net_v35SP1_short](../../../includes/net-v35sp1-short-md.md)].  
  
-   [.NET Framework 4 Migration Issues](../../../docs/framework/migration-guide/net-framework-4-migration-issues.md) documents changes between the [!INCLUDE[net_v35SP1_short](../../../includes/net-v35sp1-short-md.md)] and the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)].  
  
## Obsolete Types and Members  
 The impact of deprecated types and members is somewhat different for retargeted applications and recompiled applications. The use of obsolete types and members will not affect a retargeted application unless the obsolete type or member has been physically removed from its assembly. Recompiling an application that uses obsolete types or members usually produces a compiler warning rather than a compiler error. However, in some cases, it produces a compiler error, and code that uses the obsolete type or member does not compile successfully. In this case, you must rewrite the source code that calls the obsolete type or member before you recompile your application. For more information about obsolete types and members, see [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md).  
  
 To assess the impact of types and members that have been deprecated since the release of the [!INCLUDE[net_v20SP1_short](../../../includes/net-v20sp1-short-md.md)], see [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md). Review the lists of obsolete types and member for the [!INCLUDE[net_v20SP1_short](../../../includes/net-v20sp1-short-md.md)], the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)], and the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)].
