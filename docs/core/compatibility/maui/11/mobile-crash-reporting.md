---
title: "Breaking change - Crash-reporting behavior changes on mobile platforms"
description: "Learn about the breaking change in .NET 11 where crash-reporting behavior changes on mobile platforms."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56484
---

# Crash-reporting behavior changes on mobile platforms

In .NET 11, CoreCLR and Mono use different crash handlers and report formats.

## Version introduced

.NET 11

## Previous behavior

Mono mobile launchers wrote managed exception text and managed stack traces to
Android logcat or the Apple device log. Fatal native crashes continued through
the Android tombstone or Apple crash-report path.

## New behavior

CoreCLR still writes the crashing thread's managed call stack to Android logcat
or the Apple console/device log. The text format differs from Mono. Mono can
print more text for a native crash, while CoreCLR uses a layout closer to other
CoreCLR platforms.

Android tombstones and Apple crash reports contain the same kinds of data as
before, but runtime module names change because `libmonosgen` is gone. The
native stack can also be shorter because CoreCLR has fewer native frames before
managed code.

CoreCLR also adds an opt-in in-process crash reporter. It can write a compact
report to Android logcat or the Apple console/device log, depending on the
platform, and a JSON report to a writable directory. Mobile CoreCLR doesn't
create binary dumps for later SOS analysis.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

CoreCLR and Mono use different crash handlers and report formats.

## Recommended action

- Don't assume that Mono and CoreCLR produce the same crash files or log text.
- Update crash collection and parsing tools for CoreCLR names and JSON fields.
- Test custom native signal handlers with the CoreCLR crash reporter.

## Affected APIs

None. This change affects crash-report environment variables, files, and tools.
