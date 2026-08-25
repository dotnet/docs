---
title: "Breaking change: FileConfigurationSource.OnLoadException callback is called for IO errors"
description: "Learn about the breaking change in .NET 11 where FileConfigurationSource.OnLoadException is called for IO errors in addition to parsing errors."
ms.date: 08/05/2026
ai-usage: ai-assisted
---

# FileConfigurationSource.OnLoadException callback is called for IO errors

<xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> and its derived types (used by <Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile*>, <Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile*>, and <Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile*>) now forward IO errors to the <xref:Microsoft.Extensions.Configuration.FileConfigurationSource.OnLoadException> callback in addition to parsing errors.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, IO errors that occurred when a configuration file was opened (for example, from `AddJsonFile`, `AddXmlFile`, `AddIniFile`, or a reload triggered when an already-loaded file changed on disk) weren't forwarded to the <xref:Microsoft.Extensions.Configuration.FileLoadExceptionContext> passed to the <xref:Microsoft.Extensions.Configuration.FileConfigurationSource.OnLoadException> callback. Only parsing errors were forwarded to that callback. IO errors were unobservable using `OnLoadException`; instead, they were observable using <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException>.

As a consequence, the `Exception` property on `FileLoadExceptionContext` passed to `OnLoadException` was always an <xref:System.IO.InvalidDataException> or <xref:System.IO.FileNotFoundException>. Code that unconditionally cast the exception to one of those types worked correctly.

## New behavior

Starting in .NET 11, IO errors are forwarded to the `FileLoadExceptionContext` passed to the `OnLoadException` callback. IO errors are no longer observable using `TaskScheduler.UnobservedTaskException`, except when no `OnLoadException` callback is registered.

As a consequence, the `Exception` property on `FileLoadExceptionContext` can now be an exception of any type—most commonly <xref:System.IO.IOException>, but potentially any exception thrown by the configured <xref:Microsoft.Extensions.FileProviders.IFileProvider> (including custom providers). Code that unconditionally casts the exception to `InvalidDataException` or `FileNotFoundException` can now throw an <xref:System.InvalidCastException> or silently mishandle these new exception types.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change is a bug fix. Configuration file IO errors are meaningful load failures, and code that registers an `OnLoadException` callback expects to observe all failures that occur while a configuration file is loaded, not just parsing errors. For more information, see [dotnet/runtime#113964](https://github.com/dotnet/runtime/issues/113964).

## Recommended action

- If you detected IO exceptions from `FileConfigurationProvider` or a derived type using `TaskScheduler.UnobservedTaskException`, move that logic to the `OnLoadException` callback.
- Verify that any callback registered in `OnLoadException` can handle exceptions of any type, not just `InvalidDataException` or `FileNotFoundException`. Avoid unconditional casts, and use pattern matching or type checks instead.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.FileConfigurationSource.OnLoadException?displayProperty=fullName>
