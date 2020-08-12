---
title: Base class library breaking changes
description: Lists the breaking changes in core .NET libraries.
ms.date: 07/27/2020
---
# Core .NET libraries breaking changes

The core .NET libraries provide the primitives and other general types used by .NET Core.

The following breaking changes are documented on this page:

| Breaking change | Version introduced |
| - | :-: |
| [Complexity of LINQ OrderBy.First{OrDefault} increased](#complexity-of-linq-orderbyfirstordefault-increased) | 5.0 |
| [IntPtr and UIntPtr implement IFormattable](#intptr-and-uintptr-implement-iformattable) | 5.0 |
| [PrincipalPermissionAttribute is obsolete as error](#principalpermissionattribute-is-obsolete-as-error) | 5.0 |
| [BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps](#binaryformatter-serialization-methods-are-obsolete-and-prohibited-in-aspnet-apps) | 5.0 |
| [UTF-7 code paths are obsolete](#utf-7-code-paths-are-obsolete) | 5.0 |
| [Vector\<T> always throws NotSupportedException for unsupported types](#vectort-always-throws-notsupportedexception-for-unsupported-types) | 5.0 |
| [Default ActivityIdFormat is W3C](#default-activityidformat-is-w3c) | 5.0 |
| [Behavior change for Vector2.Lerp and Vector4.Lerp](#behavior-change-for-vector2lerp-and-vector4lerp) | 5.0 |
| [SSE and SSE2 CompareGreaterThan methods properly handle NaN inputs](#sse-and-sse2-comparegreaterthan-methods-properly-handle-nan-inputs) | 5.0 |
| [CounterSet.CreateCounterSetInstance now throws InvalidOperationException if instance already exist](#countersetcreatecountersetinstance-now-throws-invalidoperationexception-if-instance-already-exists) | 5.0 |
| [Microsoft.DotNet.PlatformAbstractions package removed](#microsoftdotnetplatformabstractions-package-removed) | 5.0 |
| [APIs that report version now report product and not file version](#apis-that-report-version-now-report-product-and-not-file-version) | 3.0 |
| [Custom EncoderFallbackBuffer instances cannot fall back recursively](#custom-encoderfallbackbuffer-instances-cannot-fall-back-recursively) | 3.0 |
| [Floating point formatting and parsing behavior changes](#floating-point-formatting-and-parsing-behavior-changed) | 3.0 |
| [Floating-point parsing operations no longer fail or throw an OverflowException](#floating-point-parsing-operations-no-longer-fail-or-throw-an-overflowexception) | 3.0 |
| [InvalidAsynchronousStateException moved to another assembly](#invalidasynchronousstateexception-moved-to-another-assembly) | 3.0 |
| [Replacing ill-formed UTF-8 byte sequences follows Unicode guidelines](#replacing-ill-formed-utf-8-byte-sequences-follows-unicode-guidelines) | 3.0 |
| [TypeDescriptionProviderAttribute moved to another assembly](#typedescriptionproviderattribute-moved-to-another-assembly) | 3.0 |
| [ZipArchiveEntry no longer handles archives with inconsistent entry sizes](#ziparchiveentry-no-longer-handles-archives-with-inconsistent-entry-sizes) | 3.0 |
| [FieldInfo.SetValue throws exception for static, init-only fields](#fieldinfosetvalue-throws-exception-for-static-init-only-fields) | 3.0 |
| [Private fields added to built-in struct types](#private-fields-added-to-built-in-struct-types) | 2.1 |
| [Change in default value of UseShellExecute](#change-in-default-value-of-useshellexecute) | 2.1 |
| [OpenSSL versions on macOS](#openssl-versions-on-macos) | 2.1 |
| [UnauthorizedAccessException thrown by FileSystemInfo.Attributes](#unauthorizedaccessexception-thrown-by-filesysteminfoattributes) | 1.0 |
| [Handling corrupted-process-state exceptions is not supported](#handling-corrupted-state-exceptions-is-not-supported) | 1.0 |
| [UriBuilder properties no longer prepend leading characters](#uribuilder-properties-no-longer-prepend-leading-characters) | 1.0 |
| [Process.StartInfo throws InvalidOperationException for processes you didn't start](#processstartinfo-throws-invalidoperationexception-for-processes-you-didnt-start) | 1.0 |

## .NET 5.0

[!INCLUDE [orderby-firstordefault-complexity-increase](../../../includes/core-changes/corefx/5.0/orderby-firstordefault-complexity-increase.md)]

***

[!INCLUDE [intptr-uintptr-implement-iformattable](../../../includes/core-changes/corefx/5.0/intptr-uintptr-implement-iformattable.md)]

***

[!INCLUDE [principalpermissionattribute-obsolete](../../../includes/core-changes/corefx/5.0/principalpermissionattribute-obsolete.md)]

***

[!INCLUDE [binaryformatter-serialization-obsolete](../../../includes/core-changes/corefx/5.0/binaryformatter-serialization-obsolete.md)]

***

[!INCLUDE [utf-7-code-paths-obsolete](../../../includes/core-changes/corefx/5.0/utf-7-code-paths-obsolete.md)]

***

[!INCLUDE [vectort-throws-notsupportedexception](../../../includes/core-changes/corefx/5.0/vectort-throws-notsupportedexception.md)]

***

[!INCLUDE [default-activityidformat-changed](../../../includes/core-changes/corefx/5.0/default-activityidformat-changed.md)]

***

[!INCLUDE [vector-lerp-behavior-change](../../../includes/core-changes/corefx/5.0/vector-lerp-behavior-change.md)]

***

[!INCLUDE [sse-comparegreaterthan-intrinsics](../../../includes/core-changes/corefx/5.0/sse-comparegreaterthan-intrinsics.md)]

***

[!INCLUDE [createcountersetinstance-throws-invalidoperation](../../../includes/core-changes/corefx/5.0/createcountersetinstance-throws-invalidoperation.md)]

***

[!INCLUDE [platformabstractions-package-removed](../../../includes/core-changes/corefx/5.0/platformabstractions-package-removed.md)]

***

## .NET Core 3.0

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
