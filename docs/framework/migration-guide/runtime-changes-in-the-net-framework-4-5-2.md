---
title: "Runtime Changes in the .NET Framework 4.5.2 | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 94ac01ea-8b12-44d2-b12b-5220a5d14d87
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Runtime Changes in the .NET Framework 4.5.2
In rare cases, runtime changes may affect existing apps that target the previous versions of the .NET Framework but run on the .NET Framework 4.5.2 runtime. They include changes in the following areas:  
  
-   [ASP.NET](#ASP_NET)  
  
-   [Entity Framework](#EF)  
  
<a name="ASP_NET"></a>   
## ASP.NET runtime changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|`enableViewStateMac` attribute of the [pages element](http://msdn.microsoft.com/en-us/4123bb66-3fe4-4d62-b70e-33758656b458)|ASP.NET no longer allows developers to specify:<br /><br /> `<pages enableViewStateMac="false" />`<br /><br /> or:<br /><br /> `<@Page EnableViewStateMac="false" %>`|The view state message authentication code (MAC) is now enforced for all requests with embedded view state. Only apps that explicitly set the <xref:System.Web.UI.Page.EnableViewStateMac%2A> property to `false` are affected.<br /><br /> For more information, see [Resolving view state message authentication code (MAC) errors](http://support.microsoft.com/kb/2915218).|Major|  
  
<a name="EF"></a>   
## Entity Framework runtime changes  
  
|Feature|Change|Impact|Scope|  
|-------------|------------|------------|-----------|  
|Relationships over a QueryView|Entity Framework no longer throws a <xref:System.StackOverflowException> exception when an app executes a query that involves a QueryView with a 0..1 navigation property that attempts to include the related entities as part of the query (for example, by calling `.Include(e=>e.RelatedNavProp)`.|This change only affects code that uses QueryViews with 1-0..1 relationships when running queries that call `.Include`. It improves reliability and should be transparent to almost all apps. However, if it causes unexpected behavior, you can disable it by adding the following entry to the `<appSettings>` section of the app's configuration file:<br /><br /> `<add key="EntityFramework_SimplifyUserSpecifiedViews"  value="false" />`|Edge|  
  
## See Also  
 [Retargeting Changes](../../../docs/framework/migration-guide/retargeting-changes-in-the-net-framework-4-5-2.md)   
 [Application Compatibility in 4.5](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5.md)   
 [Application Compatibility in 4.5.1](../../../docs/framework/migration-guide/application-compatibility-in-the-net-framework-4-5-1.md)