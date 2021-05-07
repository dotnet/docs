---
title: Analyzer diagnostics in .NET 6+
description: Learn about analyzer diagnostics created by source generators in .NET 6 and later versions that produce SYSLIB compiler warnings.
ms.date: 05/07/2021
---
# Source generator diagnostics in .NET 6+

You can have source generated code if you have the right package reference which would run the analyzer. With that, you might end up getting any of the compiler diagnostics listed below.

If you encounter build warnings or errors due to usage of source generator analyzer package, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. Warnings or errors *can't* be suppressed using the corresponding `SYSLIBxxxx` diagnostic ID values. For more information, see [Suppress warnings](#suppress-warnings).

## Analyzer Warnings

The diagnostic id values reserved for .NET Libraries analyzer warnings are `SYSLIB1001` through `SYSLIB1999`.

## Reference

The following table provides an index to the `SYSLIBxxxx` diagnostics in .NET 6+.

| Diagnostic ID | Description |
| - | - |
| [SYSLIB1001](syslib-warnings/syslib1001.md) | Logging method names cannot start with _ |
| [SYSLIB1002](syslib-warnings/syslib1002.md) | Don't include log level parameters as templates in the logging message |
| [SYSLIB1003](syslib-warnings/syslib1003.md) | InvalidLoggingMethodParameterNameTitle |
| [SYSLIB1004](syslib-warnings/syslib1004.md) | Logging class cannot be in nested types |
| [SYSLIB1005](syslib-warnings/syslib1005.md) | Could not find a required type definition |
| [SYSLIB1006](syslib-warnings/syslib1006.md) | Multiple logging methods cannot use the same event id within a class |
| [SYSLIB1007](syslib-warnings/syslib1007.md) | Logging methods must return void |
| [SYSLIB1008](syslib-warnings/syslib1008.md) | One of the arguments to a logging method must implement the Microsoft.Extensions.Logging.ILogger interface 
| [SYSLIB1009](syslib-warnings/syslib1009.md) | Logging methods must be static |
| [SYSLIB1010](syslib-warnings/syslib1010.md) | Logging methods must be partial |
| [SYSLIB1011](syslib-warnings/syslib1011.md) | Logging methods cannot be generic |
| [SYSLIB1012](syslib-warnings/syslib1012.md) | Redundant qualifier in logging message |
| [SYSLIB1013](syslib-warnings/syslib1013.md) | Don't include exception parameters as templates in the logging message |
| [SYSLIB1014](syslib-warnings/syslib1014.md) | Logging template has no corresponding method argument |
| [SYSLIB1015](syslib-warnings/syslib1015.md) | Argument is not referenced from the logging message |
| [SYSLIB1016](syslib-warnings/syslib1016.md) | Logging methods cannot have a body |
| [SYSLIB1017](syslib-warnings/syslib1017.md) | A LogLevel value must be supplied in the LoggerMessage attribute or as a parameter to the logging method |
| [SYSLIB1018](syslib-warnings/syslib1018.md) | Don't include logger parameters as templates in the logging message |
| [SYSLIB1019](syslib-warnings/syslib1019.md) | Couldn't find a field of type Microsoft.Extensions.Logging.ILogger |
| [SYSLIB1020](syslib-warnings/syslib1020.md) | Found multiple fields of type Microsoft.Extensions.Logging.ILogger |
| [SYSLIB1021](syslib-warnings/syslib1021.md) | Can't have the same template with different casing |
| [SYSLIB1022](syslib-warnings/syslib1022.md) | Can't have malformed format strings (like dangling {, etc)  |
| [SYSLIB1023](syslib-warnings/syslib1023.md) | Generating more than 6 arguments is not supported |
| [SYSLIB1030](syslib-warnings/syslib1030.md) | [System.Text.Json.SourceGeneration] Did not generate serialization metadata for type. |
| [SYSLIB1031](syslib-warnings/syslib1031.md) | [System.Text.Json.SourceGeneration] Duplicate type name. |

## Suppress warnings

If the `SYSLIBxxxx` diagnostic does not surface as an error, you can suppress the warning in code or in your project file.

In code:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0001
// Code that uses obsolete API.
...
// Re-enable the warning.
#pragma warning restore SYSLIB0001
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net6.0</TargetFramework>
   <!-- NoWarn below suppresses SYSLIB1006 project-wide -->
   <NoWarn>$(NoWarn);SYSLIB1006</NoWarn>
  </PropertyGroup>
</Project>
```