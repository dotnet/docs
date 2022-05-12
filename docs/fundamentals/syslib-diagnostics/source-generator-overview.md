---
title: Analyzer diagnostics in .NET 6+
description: Learn about analyzer diagnostics created by source generators in .NET 6 and later versions that produce SYSLIB compiler warnings.
ms.date: 05/11/2021
---

# Source-generator diagnostics in .NET 6+

If your .NET 6+ project references a package that enables source generation of code, for example, a logging solution, then the analyzers that are specific to source generation will run at compile time. This article lists the compiler diagnostics related to source-generated code.

If you encounter one of these build warnings or errors, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. Warnings can also be suppressed using the specific `SYSLIB1XXX` diagnostic ID value. For more information, see [Suppress warnings](#suppress-warnings).

## Analyzer warnings

The diagnostic ID values reserved for source-generated code analyzer warnings are `SYSLIB1001` through `SYSLIB1999`.

## Reference

The following table provides an index to the `SYSLIB1XXX` diagnostics in .NET 6 and later versions.

| Diagnostic ID      | Description                                                                                                  |
|--------------------|--------------------------------------------------------------------------------------------------------------|
| [SYSLIB1001][1001] | Logging method names cannot start with `_`                                                                   |
| [SYSLIB1002][1002] | Don't include log level parameters as templates in the logging message                                       |
| [SYSLIB1003][1003] | `InvalidLoggingMethodParameterNameTitle`                                                                     |
| [SYSLIB1005][1005] | Could not find a required type definition                                                                    |
| [SYSLIB1006][1006] | Multiple logging methods cannot use the same event ID within a class                                         |
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
| [SYSLIB1021][1021] | Multiple message-template item names differ only by case                                              |
| [SYSLIB1022][1022] | Can't have malformed format strings (for example, dangling curly braces)                                     |
| [SYSLIB1023][1023] | Generating more than six arguments is not supported                                                          |
| [SYSLIB1030][1030] | The `System.Text.Json` source generator did not generate serialization metadata for type |
| [SYSLIB1031][1031] | The `System.Text.Json` source generator encountered a duplicate `JsonTypeInfo` property name |
| [SYSLIB1032][1032] | The `System.Text.Json` source generator encountered a context class that is not partial |
| [SYSLIB1033][1033] | The `System.Text.Json` source generator encountered a type that has multiple `[JsonConstructor]` annotations|
| [SYSLIB1035][1035] | The `System.Text.Json` source generator encountered a type that has multiple `[JsonExtensionData]` annotations |
| [SYSLIB1036][1036] | The `System.Text.Json` source generator encountered an invalid `[JsonExtensionData]` annotation |
| [SYSLIB1037][1037] | The `System.Text.Json` source generator encountered a type with init-only properties for which deserialization is not supported |
| [SYSLIB1038][1038] | The `System.Text.Json` source generator encountered a property annotated with `[JsonInclude]` that has inaccessible accessors |

<!-- Include adds ## Suppress warnings (H2 heading) -->
[!INCLUDE [suppress-source-generator-diagnostics](includes/suppress-source-generator-diagnostics.md)]

[1001]: syslib1001.md
[1002]: syslib1002.md
[1003]: syslib1003.md
[1005]: syslib1005.md
[1006]: syslib1006.md
[1007]: syslib1007.md
[1008]: syslib1008.md
[1009]: syslib1009.md
[1010]: syslib1010.md
[1011]: syslib1011.md
[1012]: syslib1012.md
[1013]: syslib1013.md
[1014]: syslib1014.md
[1015]: syslib1015.md
[1016]: syslib1016.md
[1017]: syslib1017.md
[1018]: syslib1018.md
[1019]: syslib1019.md
[1020]: syslib1020.md
[1021]: syslib1021.md
[1022]: syslib1022.md
[1023]: syslib1023.md
[1030]: syslib1030.md
[1031]: syslib1031.md
[1032]: syslib1032.md
[1033]: syslib1033.md
[1035]: syslib1035.md
[1036]: syslib1036.md
[1037]: syslib1037.md
[1038]: syslib1038.md
