---
title: "Breaking change - CoreCLR replaces Mono runtime for .NET mobile apps"
description: "Learn about the breaking change in .NET 11 where CoreCLR replaces Mono runtime for .NET mobile apps."
ms.date: 11/20/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/56476
---

# CoreCLR replaces Mono runtime for .NET mobile apps

.NET 11 mobile workloads use CoreCLR as their supported runtime.

## Version introduced

.NET 11

## Previous behavior

Supported .NET 10 Android, iOS, tvOS, and Mac Catalyst projects used Mono by
default. A project could set `UseMonoRuntime=true` to select Mono.

Apps and tools could also see Mono names in runtime information, package files,
stack traces, symbols, and diagnostic events.

Mono could run static field initializers during instance creation for classes
without an explicit static constructor. This timing wasn't guaranteed and could
vary by runtime configuration.

## New behavior

Supported .NET 11 Android, iOS, tvOS, and Mac Catalyst projects use CoreCLR.
Setting `UseMonoRuntime=true` causes build error
[NETSDK1242](../../../tools/sdk-errors/netsdk1242.md).

Apps and tools can see new runtime names. For example:

- <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription>
  reports .NET instead of Mono.
- Android packages contain CoreCLR files instead of `libmonosgen-2.0`.
- Stack traces, symbols, and diagnostic events identify CoreCLR.

### Static field initialization

Without an explicit static constructor, CoreCLR can wait until code first reads
a static field before it runs the field initializer. The C# compiler usually
marks these classes as `beforefieldinit`. The
[ECMA-335 specification, section I.8.9.5](https://www.ecma-international.org/wp-content/uploads/ECMA-335_6th_edition_june_2012.pdf)
allows initialization at or before the first access to a static field. Don't
depend on the exact timing. Instance creation and static methods that don't
read those fields don't have to trigger initialization. `readonly` doesn't
change the timing.

For the C# rules, see
[Static field initialization](/dotnet/csharp/language-reference/language-specification/classes#15562-static-field-initialization).

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility), [binary compatibility](../../categories.md#binary-compatibility), and [behavior](../../categories.md#behavioral-change).

## Reason for change

.NET 11 mobile workloads use CoreCLR as their supported runtime.

## Recommended action

- Remove `UseMonoRuntime=true` from .NET 11 projects.
- If an app must use Mono, keep it on .NET 10.
- Update tools that look for Mono package files, symbols, stack frames, or
  diagnostic names.
- Don't add code that checks whether the runtime is Mono or CoreCLR. Check for
  the feature that the app needs instead.

### Control static initialization

Add an explicit static constructor, even if its body is empty, to run field
initializers before the first instance constructor.

Field initializers run immediately before the static constructor. The first
instance creation or an earlier static-member reference can trigger it. An
earlier reference can initialize the field before any instance exists. See
[Static constructors](/dotnet/csharp/language-reference/language-specification/classes#1512-static-constructors).

## Affected APIs

- <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription>
  reports .NET instead of Mono.
