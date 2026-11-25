---
title: "Breaking change - Mono runtime settings no longer configure mobile apps"
description: "Learn about the breaking change in .NET 11 where Mono runtime settings no longer configure mobile apps."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56479
---

# Mono runtime settings no longer configure mobile apps

In .NET 11, Mono runtime settings no longer configure mobile apps.

## Version introduced

.NET 11

## Previous behavior

Mono environment variables and launcher settings controlled logging, profiling,
diagnostics, GC, the interpreter, the JIT, thread suspension, assembly lookup,
and debugging.

Common settings included:

- `MONO_LOG_*`
- `MONO_PROFILE`
- `MONO_DIAGNOSTICS`
- `MONO_SDB_ENV_OPTIONS`
- `MONO_GC_*`
- `MONO_INTERPRETER_OPTIONS`
- `MONO_THREADS_SUSPEND`
- `MONO_PATH`
- `MONO_DEBUG`

## New behavior

CoreCLR doesn't use these Mono settings.

Android `debug.mono.*` system properties are being replaced by
`debug.dotnet.*` properties that work with CoreCLR. The old names remain as
fallbacks, but those fallbacks might be removed in .NET 12. Use the new names
when they are available.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [behavior](../../categories.md#behavioral-change).

## Reason for change

CoreCLR and Mono use different runtime settings.

## Recommended action

- Remove Mono environment variables and launcher settings.
- Don't replace the `MONO_*` prefix with `DOTNET_*` or `COMPlus_*` and assume
  that the setting has the same meaning.
- Use a CoreCLR setting only when its documentation says that it provides the
  behavior you need.
- Shared settings such as `DOTNET_DiagnosticPorts` still work where the mobile
  workload supports them.

## Affected APIs

None. This change affects runtime configuration.
