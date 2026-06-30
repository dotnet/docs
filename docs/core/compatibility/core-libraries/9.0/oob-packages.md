---
title: "New version of some OOB packages"
description: Learn about the breaking change in core .NET libraries where updates were made to TFMs and package versions for several OOB packages.
ms.date: 03/03/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/43564
---

# New version of some OOB packages

New versions of some out-of-band (OOB) packages were generated. The following changes were made that can be considered breaking:

- The supported target framework monikers (TFMs) were updated.
- The package version minor number was updated.
- In some cases, some TFMs are no longer supported.

Additionally, the source code of these packages was migrated from their old location, which was a branch of .NET that is no longer in support, to the <https://github.com/dotnet/maintenance-packages> repo.

| Package                                 | Old source code location                                        | New package version |
|-----------------------------------------|-----------------------------------------------------------------|---------------------|
| Microsoft.Bcl.HashCode                  | [dotnet/corefx](https://github.com/dotnet/corefx), 3.1 branch   | 6.0.0               |
| Microsoft.IO.Redist                     | [dotnet/runtime](https://github.com/dotnet/runtime), 6.0 branch | 6.1.0               |
| System.Buffers                          | [dotnet/corefx](https://github.com/dotnet/corefx), 2.1 branch   | 4.6.0               |
| System.Data.SqlClient                   | [dotnet/corefx](https://github.com/dotnet/corefx), 3.1 branch   | 4.9.0               |
| System.Json                             | [dotnet/corefx](https://github.com/dotnet/corefx), 3.1 branch   | 4.8.0               |
| System.Memory                           | [dotnet/corefx](https://github.com/dotnet/corefx), 2.1 branch   | 4.6.0               |
| System.Net.WebSockets.WebSocketProtocol | [dotnet/runtime](https://github.com/dotnet/runtime), 5.0 branch | 5.1.0               |
| System.Numerics.Vectors                 | [dotnet/corefx](https://github.com/dotnet/corefx), 2.1 branch   | 4.6.0               |
| System.Reflection.DispatchProxy         | [dotnet/corefx](https://github.com/dotnet/corefx), 3.1 branch   | 4.8.0               |
| System.Runtime.CompilerServices.Unsafe  | [dotnet/runtime](https://github.com/dotnet/runtime), 6.0 branch | 6.1.0               |
| System.Threading.Tasks.Extensions       | [dotnet/corefx](https://github.com/dotnet/corefx), 2.1 branch   | 4.6.0               |
| System.Xml.XPath.XmlDocument            | [dotnet/corefx](https://github.com/dotnet/corefx), 1.1 branch   | 4.7.0               |

## Version introduced

.NET 9

## Previous behavior

The old packages targeted some TFMs that became out-of-support.

## New behavior

Some TFMs that were previously supported are no longer supported. However, there are no source code changes.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The source code of these packages was moved from their old branch, which was already out of support, to a repository that is actively maintained.

## Recommended action

Depending on the package, different recommended actions are provided. For more information, see the [package support policy](https://github.com/dotnet/maintenance-packages/tree/main/package-support-policy.md).

If you're using these packages in an ASP.NET Framework web application that precompiles Razor (*.cshtml*) views with `aspnet_compiler.exe`, upgrading to new package versions might cause `CS0012` errors because some assemblies are framework facades that aren't copied to the bin folder. For more information and the fix, see [CS0012 in ASP.NET Framework web apps with Razor precompilation](../../../../csharp/language-reference/compiler-messages/assembly-references.md#cs0012-in-aspnet-framework-web-apps-with-razor-precompilation).

## Affected APIs

All APIs contained in the affected packages.
