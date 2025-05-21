---
title: "Breaking change: System.diagnostics entry in app.config"
description: Learn about the .NET 7 breaking change in configuration where the `<section name="system.diagnostics">` entry is no longer allowed in an app.config file.
ms.date: 11/03/2022
ms.topic: concept-article
---
# System.diagnostics entry in app.config

For applications that have an *app.config* file, the `<configuration><configSections>` entry is no longer allowed to contain a `<section name="system.diagnostics">` entry. If present, you must remove the entry.

Having a `<section name="system.diagnostics">` entry throws the following run-time exception when the configuration system is first used:

> **ConfigurationErrorsException: Section or group name 'system.diagnostics' is already defined. Updates to this may only occur at the configuration level where it is defined.**

For example, the following *app.config* file contains the unnecessary entry:

```xml
<configuration>
 <configSections>
   <section name="system.diagnostics"
            type="System.Diagnostics.SystemDiagnosticsSection,
            System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
 </configSections>
```

This break will likely only occur for apps that:

- Were migrated from .NET Framework to .NET.
- Had explicitly added `<section name="system.diagnostics">` to the *app.config* file to support manual reading of the `<system.diagnostics>` section.
- Were upgraded to .NET 7, which has an implicit `<section name="system.diagnostics">` entry.

## Previous behavior

Specifying `<section name="system.diagnostics">` was allowed and necessary if there was a later `<system.diagnostics>` configuration section like the following:

```xml
<configuration>
    <system.diagnostics>
```

However, the section wasn't automatically read. That's because <xref:System.Diagnostics?displayProperty=fullName> did not yet support the feature to add listeners and configure other diagnostic features by processing that section.

.NET Framework, however, does support processing of a `<system.diagnostics>` section and has a `<section name="system.diagnostics">` entry in the *machine.config* file.

## New behavior

<xref:System.Diagnostics?displayProperty=fullName> now supports reading the `<system.diagnostics>` section from the config file and adds an implicit `<section name="system.diagnostics">` entry. Having an explicit `<section name="system.diagnostics">` entry in the *app.config* file causes a duplicate entry, which throws <xref:System.Configuration.ConfigurationErrorsException>.

## Version introduced

.NET 7 RC 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

To support a new feature where <xref:System.Diagnostics?displayProperty=fullName> reads from the *app.config* file, we had to add the implicit `<section name="system.diagnostics">` element.

## Recommended action

Remove the unnecessary `<section name="system.diagnostics" ... >` section.

## Affected APIs

N/A
