---
title: "Breaking change: Resolving disposed ServiceProvider throws exception"
description: Learn about the .NET 6 breaking change in .NET extensions where resolving a disposed service provider throws an exception.
ms.date: 11/08/2021
---
# Resolving disposed ServiceProvider throws exception

When a service is resolved after the service provider has been disposed, the affected methods now throw an <xref:System.ObjectDisposedException> instead of causing a deadlock.

## Version introduced

6.0 RC 1

## Previous behavior

Previously, in the rare case that an application resolved a service after the service provider was disposed, it led to a deadlock.

## New behavior

Starting in .NET 6, an <xref:System.ObjectDisposedException> is thrown when a service is resolved after the service provider has been disposed, and there's no deadlock.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was introduced to fix the deadlock scenario.

## Recommended action

Catch <xref:System.ObjectDisposedException> when calling any of the affected APIs.

## Affected APIs

- <xref:System.IServiceProvider.GetService(System.Type)?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.ISupportRequiredService.GetRequiredService(System.Type)?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(System.IServiceProvider,System.Type)?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%60%601(System.IServiceProvider)?displayProperty=fullName>
