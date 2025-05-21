---
title: ".NET 8 breaking change: Legacy Console.ReadKey removed"
description: Learn about the .NET 8 breaking change in core .NET libraries where the legacy Console.ReadKey implementation has been removed.
ms.date: 01/27/2023
ms.topic: article
---
# Legacy Console.ReadKey removed

The ability to use the legacy <xref:System.Console.ReadKey%2A?displayProperty=nameWithType> implementation exposed via the `System.Console.UseNet6CompatReadKey` JSON setting and the `DOTNET_SYSTEM_CONSOLE_USENET6COMPATREADKEY` environment variable has been removed.

## Previous behavior

Previously, you could request the .NET 6 console key parsing logic via a runtime configuration switch.

## New behavior

Starting in .NET 8, you can't request the .NET 6 compatibility mode for <xref:System.Console.ReadKey%2A?displayProperty=nameWithType>.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The compatibility mode was introduced as a safety switch in case the <xref:System.Console.ReadKey%2A?displayProperty=nameWithType> implementation rewrite introduced any bugs. Only one bug was reported, and it was fixed in .NET 7, so there's no need to keep the previous implementation anymore.

## Recommended action

If the new implementation doesn't work as expected, open a bug at <https://github.com/dotnet/runtime/issues> so it can be fixed.

## Affected APIs

- <xref:System.Console.ReadKey%2A?displayProperty=fullName>
