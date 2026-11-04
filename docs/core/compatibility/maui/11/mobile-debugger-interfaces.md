---
title: "Breaking change - Debugging interfaces on mobile platforms changing to ICorDebug"
description: "Learn about the .NET 11 breaking change where debugging interfaces on mobile platforms change to ICorDebug."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56485
---

# Debugging interfaces on mobile platforms changing to `ICorDebug`

In .NET 11, debugging interfaces on mobile platforms change to `ICorDebug`.

## Version introduced

.NET 11

## Previous behavior

.NET runtime debugging interfaces for Apple mobile platforms were based on the
Mono soft debugger and its underlying protocols.

## New behavior

CoreCLR debugging uses the documented `ICorDebug` interfaces. This matches the
debugging interface used by other CoreCLR platforms.

## Type of breaking change

This change is [source incompatible](../../categories.md#source-compatibility), [binary incompatible](../../categories.md#binary-compatibility), and a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Mono and CoreCLR use different debugger interfaces and components.

## Recommended action

- Replace Mono soft-debugger integration with `ICorDebug`.
- Follow the
  [mobile CoreCLR debugger initialization guidance](../../../unmanaged-api/debugging/initialize-debugger-mobile.md)
  for the target-side component and `ICorDebug` initialization sequence.
- Microsoft's Visual Studio mobile debugger proxy is not a public debugging
  protocol. The Visual Studio license doesn't allow third parties to redistribute
  that proxy.

## Affected APIs

- Mono soft-debugger interfaces and protocols. CoreCLR debugger integrations use
  `ICorDebug`.
