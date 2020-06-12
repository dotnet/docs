---
title: "Migrating from the .NET Framework 1.1"
ms.date: "03/30/2017"
helpviewer_keywords:
  - ".NET Framework 4.5, migrating from 1.1"
  - ".NET Framework 1.1, migrating to .NET Framework 4.5"
ms.assetid: 7ead0cb3-3b19-414a-8417-a1c1fa198d9e
---
# Migrate from the .NET Framework 1.1

Windows 7 and later versions of the Windows operating system do not support the .NET Framework 1.1. As a result, applications that target the .NET Framework 1.1 will not run without modification on Windows 7 or later operating system versions. This topic discusses the steps required to run an application that targets the .NET Framework 1.1 under Windows 7 and later versions of the Windows operating system. For more information about the .NET Framework 1.1 and Windows 8, see [Run .NET Framework 1.1 Apps on Windows 8 and later versions](../install/run-net-framework-1-1-apps.md).

## Retarget or recompile

There are two ways to get an application that was compiled using the .NET Framework 1.1 to run on Windows 7 or a later Windows operating system:

- Retarget the application to run under .NET Framework 4 and later versions. Retargeting requires that you add a [\<supportedRuntime>](../configure-apps/file-schema/startup/supportedruntime-element.md) element to the application's configuration file that allows it to run under .NET Framework 4 and later versions. Such a configuration file takes the following form:

    ```xml
    <configuration>
       <startup>
          <supportedRuntime version="v4.0"/>
       </startup>
    </configuration>
    ```

- Recompile the application with a compiler that targets the .NET Framework 4 or a later version. If you originally used Visual Studio 2003 to develop and compile your solution, you can open the solution in Visual Studio 2010 (and possibly later versions too) and use the **Project Compatibility** dialog box to convert the solution and project files from the formats used by Visual Studio 2003 to the Microsoft Build Engine (MSBuild) format.

Regardless of whether you prefer to recompile or retarget your application, you must determine whether your application is affected by any changes introduced in later versions of the .NET Framework. These changes are of two kinds:

- Breaking changes that occurred between the .NET Framework 1.1 and later versions of the .NET Framework.

- Types and type members that have been marked as deprecated or obsolete between the .NET Framework 1.1 and later versions of the .NET Framework.

Whether you retarget your application or recompile it, you should review both the breaking changes and the obsolete types and members for each version of the .NET Framework that was released after .NET Framework 1.1.

## Breaking changes

When a breaking change occurs, depending on the specific change, a workaround may be available both for retargeted and recompiled applications. In some cases, you can add a child element to the [\<runtime>](../configure-apps/file-schema/startup/supportedruntime-element.md) element of your application's configuration file to restore the previous behavior. For example, the following configuration file restores the string sorting and comparison behavior used in the .NET Framework 1.1 and can be used either with a retargeted or a recompiled application.

```xml
<configuration>
   <runtime>
      <CompatSortNLSVersion enabled="4096"/>
   </runtime>
</configuration>
```

However, in some cases, you may have to modify your source code and recompile your application.

To assess the impact of possible breaking changes on your application, you must review the following lists of changes:

- [Breaking Changes in .NET Framework 2.0](https://docs.microsoft.com/previous-versions/aa570326(v=msdn.10)) documents changes in .NET Framework 2.0 SP1 that can affect an application that targets .NET Framework 1.1.

- [Changes in .NET Framework 3.5 SP1](https://docs.microsoft.com/previous-versions/dotnet/articles/dd310284(v=msdn.10)) documents changes between the .NET Framework 3.5 and the .NET Framework 3.5 SP1.

- [.NET Framework 4 Migration Issues](net-framework-4-migration-issues.md) documents changes between the .NET Framework 3.5 SP1 and the .NET Framework 4.

## Obsolete types and members

The impact of deprecated types and members is somewhat different for retargeted applications and recompiled applications. The use of obsolete types and members will not affect a retargeted application unless the obsolete type or member has been physically removed from its assembly. Recompiling an application that uses obsolete types or members usually produces a compiler warning rather than a compiler error. However, in some cases, it produces a compiler error, and code that uses the obsolete type or member does not compile successfully. In this case, you must rewrite the source code that calls the obsolete type or member before you recompile your application. For more information about obsolete types and members, see [What's Obsolete in the Class Library](../whats-new/whats-obsolete.md).

To assess the impact of types and members that have been deprecated since the release of the .NET Framework 2.0 SP1, see [What's Obsolete in the Class Library](../whats-new/whats-obsolete.md). Review the lists of obsolete types and member for the .NET Framework 2.0 SP1, the .NET Framework 3.5, and the .NET Framework 4.
