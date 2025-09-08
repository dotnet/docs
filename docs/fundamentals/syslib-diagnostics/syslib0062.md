---
title: SYSLIB0062 warning - XsltSettings.EnableScript is obsolete
description: Learn about the obsoletion of the XsltSettings.EnableScript property. Use of this property generates compile-time warning SYSLIB0062.
ms.date: 09/08/2025
f1_keywords:
  - SYSLIB0062
---
# SYSLIB0062: XsltSettings.EnableScript is obsolete

Starting in .NET 10, the <xref:System.Xml.Xsl.XsltSettings.EnableScript?displayProperty=nameWithType> property is marked obsolete.

## Reason for obsoletion

XSLT script blocks aren't supported on .NET Core or .NET 5+. This obsoletion turns a run-time error into a build warning, which provides better guidance for migration.

## Workaround

Review call sites for any assumptions made about the behavior of this property. You can likely remove any references to the property since it didn't truly enable script blocks on modern .NET.

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0062

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0062
```

To suppress all the `SYSLIB0062` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0062</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
