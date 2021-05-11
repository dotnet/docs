---
title: Analyzer diagnostics in .NET 6+
description: Learn about analyzer diagnostics created by source generators in .NET 6 and later versions that produce SYSLIB compiler warnings.
ms.date: 05/11/2021
---

# Source generator diagnostics in .NET 6+

You can have source generated code if you have the right package reference which would run the analyzer. With that, you might end up getting any of the compiler diagnostics listed below.

If you encounter build warnings or errors due to usage of source generator analyzer package, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. Warnings or errors *can't* be suppressed using the corresponding `SYSLIBxxxx` diagnostic ID values. For more information, see [Suppress warnings](#suppress-warnings).

## Analyzer Warnings

The diagnostic id values reserved for .NET Libraries analyzer warnings are `SYSLIB1001` through `SYSLIB1999`.

## Reference

The following table provides an index to the `SYSLIB1XXX` diagnostics in .NET 6.

| Diagnostic ID      | Description                                                                                                  |
|--------------------|--------------------------------------------------------------------------------------------------------------|
| [SYSLIB1001][1001] | Logging method names cannot start with `_`                                                                   |
| [SYSLIB1002][1002] | Don't include log level parameters as templates in the logging message                                       |
| [SYSLIB1003][1003] | `InvalidLoggingMethodParameterNameTitle`                                                                     |
| [SYSLIB1004][1004] | Logging class cannot be in nested types                                                                      |
| [SYSLIB1005][1005] | Could not find a required type definition                                                                    |
| [SYSLIB1006][1006] | Multiple logging methods cannot use the same event id within a class                                         |
| [SYSLIB1007][1007] | Logging methods must return `void`                                                                           |
| [SYSLIB1008][1008] | One of the arguments to a logging method must implement the `Microsoft.Extensions.Logging.ILogger` interface |
| [SYSLIB1009][1009] | Logging methods must be `static`                                                                             |
| [SYSLIB1010][1010] | Logging methods must be `partial`                                                                            |
| [SYSLIB1011][1011] | Logging methods cannot be generic                                                                            |
| [SYSLIB1012][1012] | Redundant qualifier in logging message                                                                       |
| [SYSLIB1013][1013] | Don't include exception parameters as templates in the logging message                                       |
| [SYSLIB1014][1014] | Logging template has no corresponding method argument                                                        |
| [SYSLIB1015][1015] | Argument is not referenced from the logging message                                                          |
| [SYSLIB1016][1016] | Logging methods cannot have a body                                                                           |
| [SYSLIB1017][1017] | A LogLevel value must be supplied in the `LoggerMessage` attribute or as a parameter to the logging method   |
| [SYSLIB1018][1018] | Don't include logger parameters as templates in the logging message                                          |
| [SYSLIB1019][1019] | Couldn't find a field of type `Microsoft.Extensions.Logging.ILogger`                                         |
| [SYSLIB1020][1020] | Found multiple fields of type `Microsoft.Extensions.Logging.ILogger`                                         |
| [SYSLIB1021][1021] | Can't have the same template with different casing                                                           |
| [SYSLIB1022][1022] | Can't have malformed format strings (like dangling `{`, or something similar)                                |
| [SYSLIB1023][1023] | Generating more than 6 arguments is not supported                                                            |
| [SYSLIB1030][1030] | [System.Text.Json.SourceGeneration] Did not generate serialization metadata for type.                        |
| [SYSLIB1031][1031] | [System.Text.Json.SourceGeneration] Duplicate type name.                                                     |

## Suppress warnings

If the `SYSLIBXXXX` diagnostic does not surface as an error, you can suppress the warning in code or in your project file.

To suppress the warnings in code:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0001
// Code that uses obsolete API.
...
// Re-enable the warning.
#pragma warning restore SYSLIB0001
```

To suppress the warnings in a project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net6.0</TargetFramework>
   <!-- NoWarn below suppresses SYSLIB1006 project-wide -->
   <NoWarn>$(NoWarn);SYSLIB1006</NoWarn>
  </PropertyGroup>
</Project>
```

[1001]: syslib-warnings/syslib1001.md
[1002]: syslib-warnings/syslib1002.md
[1003]: syslib-warnings/syslib1003.md
[1004]: syslib-warnings/syslib1004.md
[1005]: syslib-warnings/syslib1005.md
[1006]: syslib-warnings/syslib1006.md
[1007]: syslib-warnings/syslib1007.md
[1008]: syslib-warnings/syslib1008.md
[1009]: syslib-warnings/syslib1009.md
[1010]: syslib-warnings/syslib1010.md
[1011]: syslib-warnings/syslib1011.md
[1012]: syslib-warnings/syslib1012.md
[1013]: syslib-warnings/syslib1013.md
[1014]: syslib-warnings/syslib1014.md
[1015]: syslib-warnings/syslib1015.md
[1016]: syslib-warnings/syslib1016.md
[1017]: syslib-warnings/syslib1017.md
[1018]: syslib-warnings/syslib1018.md
[1019]: syslib-warnings/syslib1019.md
[1020]: syslib-warnings/syslib1020.md
[1021]: syslib-warnings/syslib1021.md
[1022]: syslib-warnings/syslib1022.md
[1023]: syslib-warnings/syslib1023.md
[1030]: syslib-warnings/syslib1030.md
[1031]: syslib-warnings/syslib1031.md
