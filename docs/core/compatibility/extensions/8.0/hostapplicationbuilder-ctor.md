---
title: "Breaking change: HostApplicationBuilderSettings.Args respected by HostApplicationBuilder ctor"
description: Learn about the .NET 8 breaking change in .NET extensions where the HostApplicationBuilder constructor respects the HostApplicationBuilderSettings.Args value even if DisableDefaults is true.
ms.date: 03/13/2023
---
# HostApplicationBuilderSettings.Args respected by HostApplicationBuilder ctor

The <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder> constructor that accepts a <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings> object now applies the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.Args?displayProperty=nameWithType> property, regardless of whether <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.DisableDefaults> is set to `true` or `false`.

## Version introduced

.NET 8 Preview 2

## Previous behavior

Previously, the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.Args?displayProperty=nameWithType> property was ignored when <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.DisableDefaults?displayProperty=nameWithType> was set to `true`.

## New behavior

Starting in .NET 8, the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.Args?displayProperty=nameWithType> value is added to <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder.Configuration?displayProperty=nameWithType> regardless of whether <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.DisableDefaults> is set to `true` or `false`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The behavior of ignoring <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.Args?displayProperty=nameWithType> was unexpected, even when <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.DisableDefaults?displayProperty=nameWithType> was set to `true`. That's because if the caller didn't want the command-line arguments applied to the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder>, they wouldn't have set them on the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings> object. Since the caller *did* pass the command-line arguments on the settings, those arguments should be respected.

## Recommended action

If you don't want the command-line arguments to be added to the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder> configuration, leave the <xref:Microsoft.Extensions.Hosting.HostApplicationBuilderSettings.Args?displayProperty=nameWithType> property set to `null`.

## Affected APIs

- <xref:Microsoft.Extensions.Hosting.HostApplicationBuilder.%23ctor(Microsoft.Extensions.Hosting.HostApplicationBuilderSettings)>
