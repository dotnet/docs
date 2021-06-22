---
title: .NET library breaking changes
description: Lists the breaking changes in core .NET libraries for .NET Core versions 1.0-3.0.
ms.date: 07/27/2020
---
# Core .NET libraries breaking changes in .NET Core 1.0-3.0

The core .NET libraries provide the primitives and other general types used by .NET Core.

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | :-: |
| [Passing GroupCollection to extension methods taking IEnumerable\<T> requires disambiguation](#passing-groupcollection-to-extension-methods-taking-ienumerablet-requires-disambiguation) | .NET Core 3.0 |
| [APIs that report version now report product and not file version](#apis-that-report-version-now-report-product-and-not-file-version) | .NET Core 3.0 |
| [Custom EncoderFallbackBuffer instances cannot fall back recursively](#custom-encoderfallbackbuffer-instances-cannot-fall-back-recursively) | .NET Core 3.0 |
| [Floating point formatting and parsing behavior changes](#floating-point-formatting-and-parsing-behavior-changed) | .NET Core 3.0 |
| [Floating-point parsing operations no longer fail or throw an OverflowException](#floating-point-parsing-operations-no-longer-fail-or-throw-an-overflowexception) | .NET Core 3.0 |
| [InvalidAsynchronousStateException moved to another assembly](#invalidasynchronousstateexception-moved-to-another-assembly) | .NET Core 3.0 |
| [Replacing ill-formed UTF-8 byte sequences follows Unicode guidelines](#replacing-ill-formed-utf-8-byte-sequences-follows-unicode-guidelines) | .NET Core 3.0 |
| [TypeDescriptionProviderAttribute moved to another assembly](#typedescriptionproviderattribute-moved-to-another-assembly) | .NET Core 3.0 |
| [ZipArchiveEntry no longer handles archives with inconsistent entry sizes](#ziparchiveentry-no-longer-handles-archives-with-inconsistent-entry-sizes) | .NET Core 3.0 |
| [FieldInfo.SetValue throws exception for static, init-only fields](#fieldinfosetvalue-throws-exception-for-static-init-only-fields) | .NET Core 3.0 |
| [Path APIs don't throw an exception for invalid characters](#path-apis-dont-throw-an-exception-for-invalid-characters) | .NET Core 2.1 |
| [Private fields added to built-in struct types](#private-fields-added-to-built-in-struct-types) | .NET Core 2.1 |
| [Change in default value of UseShellExecute](#change-in-default-value-of-useshellexecute) | .NET Core 2.1 |
| [OpenSSL versions on macOS](#openssl-versions-on-macos) | .NET Core 2.1 |
| [UnauthorizedAccessException thrown by FileSystemInfo.Attributes](#unauthorizedaccessexception-thrown-by-filesysteminfoattributes) | .NET Core 1.0 |
| [Handling corrupted-process-state exceptions is not supported](#handling-corrupted-state-exceptions-is-not-supported) | .NET Core 1.0 |
| [UriBuilder properties no longer prepend leading characters](#uribuilder-properties-no-longer-prepend-leading-characters) | .NET Core 1.0 |
| [Process.StartInfo throws InvalidOperationException for processes you didn't start](#processstartinfo-throws-invalidoperationexception-for-processes-you-didnt-start) | .NET Core 1.0 |

## .NET Core 3.0

[!INCLUDE [disambiguate-generic-type-for-groupcollection](../../../includes/core-changes/corefx/3.0/disambiguate-generic-type-for-groupcollection.md)]

***

[!INCLUDE[APIs that report version now report product and not file version](~/includes/core-changes/corefx/3.0/version-information-changes.md)]

***

[!INCLUDE[Custom EncoderFallbackBuffer instances cannot fall back recursively](~/includes/core-changes/corefx/3.0/custom-encoderfallbackbuffer-cannot-be-recursive.md)]

***

[!INCLUDE[Floating point formatting and parsing behavior changes](~/includes/core-changes/corefx/3.0/floating-point-changes.md)]

***

[!INCLUDE[Floating-point parsing operations no longer fail or throw an OverflowException](~/includes/core-changes/corefx/3.0/floating-point-parsing-does-not-overflow.md)]

***

[!INCLUDE[InvalidAsynchronousStateException moved to another assembly](~/includes/core-changes/corefx/3.0/move-invalidasynchronousstateexception.md)]

***

[!INCLUDE[NET Core 3.0 follows Unicode best practices when replacing ill-formed UTF-8 byte sequences](~/includes/core-changes/corefx/3.0/net-core-3-0-follows-unicode-utf8-best-practices.md)]

***

[!INCLUDE[TypeDescriptionProviderAttribute moved to another assembly](~/includes/core-changes/corefx/3.0/move-typedescriptionproviderattribute.md)]

***

[!INCLUDE[ZipArchiveEntry no longer handles archives with inconsistent entry sizes](~/includes/core-changes/corefx/3.0/ziparchiveentry-and-inconsistent-entry-sizes.md)]

***

[!INCLUDE [FieldInfo.SetValue throws exception for static, init-only fields](~/includes/core-changes/corefx/3.0/fieldinfo-setvalue-exception.md)]

***

## .NET Core 2.1

[!INCLUDE [path-apis-dont-throw-exception-for-invalid-paths](../../../includes/core-changes/corefx/2.1/path-apis-dont-throw-exception-for-invalid-paths.md)]

***

[!INCLUDE[Private fields added to built-in struct types](~/includes/core-changes/corefx/2.1/instantiate-struct.md)]

***

[!INCLUDE[Change in default value of UseShellExecute](~/includes/core-changes/corefx/2.1/process-start-changes.md)]

***

[!INCLUDE [OpenSSL versions on macOS](../../../includes/core-changes/corefx/openssl-dependencies-macos.md)]

***

## .NET Core 1.0

[!INCLUDE [UnauthorizedAccessException thrown by FileSystemInfo.Attributes](~/includes/core-changes/corefx/1.0/filesysteminfo-attributes-exceptions.md)]

***

[!INCLUDE [corrupted-state-exceptions](~/includes/core-changes/corefx/1.0/corrupted-state-exceptions.md)]

***

[!INCLUDE [uribuilder-behavior-changes](../../../includes/core-changes/corefx/1.0/uribuilder-behavior-changes.md)]

***

[!INCLUDE [startinfo-throws-exception](../../../includes/core-changes/corefx/1.0/startinfo-throws-exception.md)]

***
