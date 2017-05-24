---
title: "Retargeting Changes in the .NET Framework 4.5.1 | Microsoft Docs"
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
  - "application compatibility"
  - "retargeting changes"
  - ".NET Framework 4.5.1"
  - "retargeting changes, .NET Framework 4.5.1"
  - "retargeting changes, .NET Framework"
ms.assetid: 8087326d-77e9-4804-ba33-ff1bb1bec2b8
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Retargeting Changes in the .NET Framework 4.5.1
In rare cases, retargeting changes may affect apps that are recompiled to target the [!INCLUDE[net_v451](../../../includes/net-v451-md.md)]. They do not affect binaries that target a previous version of the .NET Framework but are running under version 4.5.1. The [!INCLUDE[net_v451](../../../includes/net-v451-md.md)] includes retargeting changes in the following areas:  
  
-   [Core](#Core)  
  
-   [ADO.NET](#ADO)  
  
-   [MSBuild](#MSBuild)  
  
 The Scope column in the following tables specifies the significance of each change:  
  
-   Major. A significant change that affects a large number of apps or that requires substantial modification of code. Note that none of the retargeting changes fall into this category.  
  
-   Minor. A change that either affects a small number of apps or that requires minor modification of code.  
  
-   Edge. A change that affects apps under very specific scenarios that are not common.  
  
-   Transparent. A change that has no noticeable effect on the app's developer or user. The app should not require modification because of this change.  
  
<a name="Core"></a>   
## Core retargeting changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.ObsoleteAttribute?displayProperty=fullName> attribute|When you create a Windows Metadata library (.winmd file), the <xref:System.ObsoleteAttribute> attribute is exported as both <xref:System.ObsoleteAttribute> and [Windows.Foundation.DeprecatedAttribute](http://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.deprecatedattribute.aspx).|Recompilation of existing source code that uses the <xref:System.ObsoleteAttribute> attribute may generate warnings when consuming that code from C++/CX or JavaScript.<br /><br /> We do not recommend applying both <xref:System.ObsoleteAttribute> and [Windows.Foundation.DeprecatedAttribute](http://msdn.microsoft.com/library/windows/apps/windows.foundation.metadata.deprecatedattribute.aspx) to code in managed assemblies; it may result in build warnings.<br /><br /> For more information, see the <xref:System.ObsoleteAttribute> reference topic.|Edge|  
  
<a name="ADO"></a>   
## ADO.NET retargeting changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|<xref:System.Data.Common.DbParameter?displayProperty=fullName> class|<xref:System.Data.Common.DbParameter.Precision%2A?displayProperty=fullName> and <xref:System.Data.Common.DbParameter.Scale%2A?displayProperty=fullName> are implemented as public virtual properties. They replace the corresponding explicit interface implementations, <xref:System.Data.Common.DbParameter.System%23Data%23IDbDataParameter%23Precision%2A?displayProperty=fullName> and <xref:System.Data.Common.DbParameter.System%23Data%23IDbDataParameter%23Scale%2A?displayProperty=fullName>.|The change only affects developers who build an ADO.NET database provider.|Edge|  
  
<a name="MSBuild"></a>   
## MSBuild retargeting changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|`ResolveAssemblyReference` task|The task emits a warning, MSB3270, which indicates that a reference or any of its dependencies does not match the app's architecture. For example, this occurs if an app that was compiled with the `anycpu` option includes an x86 reference. Such a scenario could result in an app failure at run time (in this case, if the app is deployed as an x64 process).|There are two areas of impact:<br /><br /> -   Recompilation generates warnings that did not appear when the app was compiled under a previous version of MSBuild. However, because the warning identifies a possible source of runtime failure, it should be investigated and addressed.<br />-   If warnings are treated as errors, the app will fail to compile.|Minor|  
  
## See Also  
 [Runtime Changes](../../../docs/framework/migration-guide/runtime-changes-in-the-net-framework-4-5-1.md)   
 [Application Compatibility in 4.5](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5.md)   
 [Application Compatibility in 4.5.2](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5-2.md)