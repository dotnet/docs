---
title: "Migration Guide to the .NET Framework 4.7, 4.6, and 4.5 "
ms.custom: "updateeachrelease"
ms.date: "10/17/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework, migrating applications to"
  - "migration, .NET Framework"
ms.assetid: 02d55147-9b3a-4557-a45f-fa936fadae3b
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Migration Guide to the .NET Framework 4.7, 4.6, and 4.5 
If you created your app using an earlier version of the .NET Framework, you can generally upgrade it to the .NET Framework 4.5 and its point releases (4.5.1 and 4.5.2), the .NET Framework 4.6 and its point releases (4.6.1 and 4.6.2), or the .NET Framework 4.7 and its point release, the .NET Framework 4.7.1, easily. Open your project in Visual Studio. If your project was created in an earlier version of Visual Studio, the **Project Compatibility** dialog box automatically opens. For more information about upgrading a project in Visual Studio, see [Port, Migrate, and Upgrade Visual Studio Projects](/visualstudio/porting/port-migrate-and-upgrade-visual-studio-projects) and [Visual Studio 2017 Platform Targeting and Compatibility](/visualstudio/productinfo/vs2017-compatibility-vs).  
  
 However, some changes in the .NET Framework require changes to your code. You may also want to take advantage of functionality that is new in the .NET Framework 4.5 and its point releases, in the .NET Framework 4.6 and its point releases, or in the .NET Framework 4.7 and its point release, the .NET Framework 4.7.1. Making these types of changes to your app for a new version of the .NET Framework is typically referred to as *migration*. If your app doesn't have to be migrated, you can run it in the .NET Framework 4.5 or a later version without recompiling it.  
  
## Migration resources  
 Review the following documents before you migrate your app from earlier versions of the .NET Framework to version 4.5, 4.5.1, 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, or 4.7.1:  
  
-   See [Versions and Dependencies](../../../docs/framework/migration-guide/versions-and-dependencies.md) to understand the CLR version underlying each version of the .NET Framework and to review guidelines for targeting your apps successfully.  
  
-   Review [Application Compatibility](../../../docs/framework/migration-guide/application-compatibility.md) to find out about runtime and retargeting changes that might affect your app and how to handle them.  
  
-   Review [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md) to determine any types or members in your code that have been made obsolete, and the recommended alternatives.  
  
-   See [What's New](../../../docs/framework/whats-new/index.md) for descriptions of new features that you may want to add to your app.  
  
## See Also  
 [Application Compatibility](../../../docs/framework/migration-guide/application-compatibility.md)  
 [Migrating from the .NET Framework 1.1](../../../docs/framework/migration-guide/migrating-from-the-net-framework-1-1.md)  
 [Version Compatibility](../../../docs/framework/migration-guide/version-compatibility.md)  
 [Versions and Dependencies](../../../docs/framework/migration-guide/versions-and-dependencies.md)  
 [How to: Configure an App to Support .NET Framework 4 or 4.5](../../../docs/framework/migration-guide/how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)  
 [What's New](../../../docs/framework/whats-new/index.md)  
 [What's Obsolete in the Class Library](../../../docs/framework/whats-new/whats-obsolete.md)  
 [.NET Framework Version and Assembly Information](http://go.microsoft.com/fwlink/?LinkId=201701)  
 [Microsoft .NET Framework Support Lifecycle Policy](http://go.microsoft.com/fwlink/?LinkId=196607)
 [.NET Framework 4 migration issues](net-framework-4-migration-issues.md)
