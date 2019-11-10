---
title: "Migration Guide to the .NET Framework 4.8, 4.7, 4.6, and 4.5 "
ms.custom: "updateeachrelease"
ms.date: "04/18/2019"
helpviewer_keywords: 
  - ".NET Framework, migrating applications to"
  - "migration, .NET Framework"
ms.assetid: 02d55147-9b3a-4557-a45f-fa936fadae3b
---
# Migration Guide to the .NET Framework 4.8, 4.7, 4.6, and 4.5

If you created your app using an earlier version of the .NET Framework, you can generally upgrade it to .NET Framework 4.5 and its point releases (4.5.1 and 4.5.2), .NET Framework 4.6 and its point releases (4.6.1 and 4.6.2), .NET Framework 4.7 and its point releases (4.7.1 and 4.7.2), or .NET Framework 4.8 easily. Open your project in Visual Studio. If your project was created in an earlier version of Visual Studio, the **Project Compatibility** dialog box automatically opens. For more information about upgrading a project in Visual Studio, see [Port, Migrate, and Upgrade Visual Studio Projects](/visualstudio/porting/port-migrate-and-upgrade-visual-studio-projects) and [Visual Studio 2019 Platform Targeting and Compatibility](/visualstudio/releases/2019/compatibility).

 However, some changes in the .NET Framework require changes to your code. You may also want to take advantage of functionality that is new in .NET Framework 4.5 and its point releases, in .NET Framework 4.6 and its point releases, in .NET Framework 4.7 and its point releases, or in .NET Framework 4.8. Making these types of changes to your app for a new version of the .NET Framework is typically referred to as *migration*. If your app doesn't have to be migrated, you can run it in the .NET Framework 4.5 or a later version without recompiling it.

## Migration resources

Review the following documents before you migrate your app from earlier versions of the .NET Framework to version 4.5, 4.5.1, 4.5.2, 4.6, 4.6.1, 4.6.2, 4.7, 4.7.1, 4.7.2, or 4.8:

- See [Versions and Dependencies](versions-and-dependencies.md) to understand the CLR version underlying each version of the .NET Framework and to review guidelines for targeting your apps successfully.

- Review [Application compatibility](application-compatibility.md) to find out about runtime and retargeting changes that might affect your app and how to handle them.

- Review [What's Obsolete in the Class Library](../whats-new/whats-obsolete.md) to determine any types or members in your code that have been made obsolete, and the recommended alternatives.

- See [What's New](../whats-new/index.md) for descriptions of new features that you may want to add to your app.

## See also

- [Application compatibility](application-compatibility.md)
- [Migrating from the .NET Framework 1.1](migrating-from-the-net-framework-1-1.md)
- [Version Compatibility](version-compatibility.md)
- [Versions and Dependencies](versions-and-dependencies.md)
- [How to: Configure an app to support .NET Framework 4 or later versions](how-to-configure-an-app-to-support-net-framework-4-or-4-5.md)
- [What's New](../whats-new/index.md)
- [What's Obsolete in the Class Library](../whats-new/whats-obsolete.md)
- [.NET Framework official support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework)
- [.NET Framework 4 migration issues](net-framework-4-migration-issues.md)
