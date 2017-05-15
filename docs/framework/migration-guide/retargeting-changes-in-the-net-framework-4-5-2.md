---
title: "Retargeting Changes in the .NET Framework 4.5.2 | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2be2a828-9052-4738-a965-d4a836cc6384
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Retargeting Changes in the .NET Framework 4.5.2
In rare cases, retargeting changes may affect apps that are recompiled to target the .NET Framework 4.5.2. Unless specified otherwise in the following tables, these changes do not affect binaries that target a previous version of the .NET Framework but are running under version 4.5.2. The .NET Framework 4.5.2 includes retargeting changes in the following areas:  
  
-   [Entity Framework](#EF)  
  
-   [Windows Forms](#WinForms)  
  
<a name="EF"></a>   
## Entity Framework retargeting changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Simpler queries when using unsorted limiting operations|Queries that produce `JOIN` statements and contain a call to a limiting operation without first using <xref:System.Data.Objects.ObjectQuery%601.OrderBy%2A> now produce simpler SQL. After upgrading to [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], these queries produced more complicated SQL than previous versions.|This feature is disabled by default. If Entity Framework generates extra `JOIN` statements that cause performance degradation, you can enable this feature by adding the following entry to the `<appSettings>` section of the application configuration (app.config) file:<br /><br /> `<add key="EntityFramework_SimplifyLimitOperations" value="true" />`|Minor|  
  
<a name="WinForms"></a>   
## Windows Forms retargeting changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Retrieving data in HTML format from the Clipboard with the <xref:System.Windows.Forms.DataObject.GetData%2A?displayProperty=fullName> method|For apps that target the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] or that run on the .NET Framework 4.5.1 or earlier versions, <xref:System.Windows.Forms.DataObject.GetData%2A?displayProperty=fullName> retrieves HTML-formatted data as an ASCII string. As a result, non-ASCII characters (characters whose ASCII codes are greater than 0x7F) are represented by two random characters. For example, é (0xE9) is represented by Ã© (0xC3 0xA9).<br /><br /> For apps that target the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] or later and run on the .NET Framework 4.5.2, <xref:System.Windows.Forms.DataObject.GetData%2A?displayProperty=fullName> retrieves HTML-formatted data as UTF-8, which represents characters greater than 0x7F correctly.|If you implemented a workaround for the encoding problem with HTML-formatted strings (for example, by explicitly encoding the HTML string retrieved from the Clipboard by passing it to the <xref:System.Text.UTF8Encoding.GetString%2A?displayProperty=fullName> method) and you're retargeting your app from version 4 to 4.5, that workaround should be removed.|Minor|  
  
## See Also  
 [Runtime Changes](../../../docs/framework/migration-guide/runtime-changes-in-the-net-framework-4-5-2.md)   
 [Application Compatibility in 4.5](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5.md)   
 [Application Compatibility in 4.5.1](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5-1.md)