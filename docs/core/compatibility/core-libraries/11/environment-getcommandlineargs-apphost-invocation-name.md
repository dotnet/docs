---
title: "Breaking change: Environment.GetCommandLineArgs()[0] preserves the apphost invocation name"
description: "Learn about the breaking change in .NET 11 where Environment.GetCommandLineArgs()[0] preserves the apphost invocation name."
ms.date: 10/13/2026
ai-usage: ai-assisted
---

# Environment.GetCommandLineArgs()[0] preserves the apphost invocation name

When you launch an app through its apphost, <xref:System.Environment.GetCommandLineArgs?displayProperty=nameWithType> now preserves the invocation name, including a relative path or symlink name. The behavior for `dotnet <application.dll>` is unchanged.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, when you launched an app through its apphost, `Environment.GetCommandLineArgs()[0]` returned the managed assembly path or the resolved executable path, rather than the invocation name.

## New behavior

Starting in .NET 11, when you launch an app through its apphost, `Environment.GetCommandLineArgs()[0]` preserves the invocation name, including relative paths and symlink names. For example, if `special_myapp` is a symlink to `myapp`, and you run `./special_myapp`, the value is `./special_myapp`.

When you launch an app with `dotnet <application.dll>`, the behavior is unchanged.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To align .NET with native process behavior, the runtime now preserves the value of `argv[0]` supplied at launch. This behavior also lets an app distinguish which symlink name launched it.

## Recommended action

To get the executable path, use <xref:System.Environment.ProcessPath?displayProperty=nameWithType>. To get the managed entry assembly location, use `Assembly.GetEntryAssembly()?.Location` (see <xref:System.Reflection.Assembly.GetEntryAssembly?displayProperty=nameWithType> and <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType>). The location is an empty string for bundled assemblies in single-file apps. Keep using `Environment.GetCommandLineArgs()[0]` when you need the invocation name.

## Affected APIs

- <xref:System.Environment.GetCommandLineArgs?displayProperty=fullName>
