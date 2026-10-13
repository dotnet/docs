---
title: "Breaking change: IStartupValidator is obsolete"
description: Learn about the .NET 11 breaking change where IStartupValidator is obsolete and IAsyncStartupValidator is the contract for new custom startup validators.
ms.date: 10/13/2026
ai-usage: ai-generated
---

# IStartupValidator is obsolete

Starting in .NET 11 RC 1, <xref:Microsoft.Extensions.Options.IStartupValidator> is obsolete. When you reference or implement it, the compiler generates warning `SYSLIB0066`. The interface remains available and functional for compatibility.

## Version introduced

.NET 11 RC 1

## Previous behavior

Previously, you could implement and register a custom <xref:Microsoft.Extensions.Options.IStartupValidator> without a compiler warning.

## New behavior

Starting in .NET 11 RC 1, you receive warning `SYSLIB0066` when you reference or implement <xref:Microsoft.Extensions.Options.IStartupValidator>. The interface remains available, and existing synchronous implementations continue to work.

New custom startup validators should implement the independent <xref:Microsoft.Extensions.Options.IAsyncStartupValidator> contract. Register a custom validator only under the startup-validation contract it implements; don't register the same implementation under both `IStartupValidator` and `IAsyncStartupValidator`.

Applications that use `OptionsBuilder<TOptions>.ValidateOnStart()` without directly implementing a startup-validator interface normally don't need to change their code.

For warning details and suppression guidance, see [SYSLIB0066](../../../../fundamentals/syslib-diagnostics/syslib0066.md).

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Host startup has an asynchronous entry point through <xref:Microsoft.Extensions.Hosting.IHost.StartAsync*>. New startup validators should use an asynchronous contract. Because <xref:Microsoft.Extensions.Options.IAsyncStartupValidator> is independent from <xref:Microsoft.Extensions.Options.IStartupValidator>, asynchronous implementations don't need to provide an unused synchronous `Validate` method or use sync-over-async code. The asynchronous `ValidateAsync` method is the complete contract for new custom startup validators.

The runtime retains <xref:Microsoft.Extensions.Options.IStartupValidator> to preserve compatibility with existing synchronous implementations. For more information, see the [approved design](https://github.com/dotnet/runtime/issues/131906) and the [implementation](https://github.com/dotnet/runtime/pull/131197).

## Recommended action

Replace custom <xref:Microsoft.Extensions.Options.IStartupValidator> implementations with <xref:Microsoft.Extensions.Options.IAsyncStartupValidator>. Implement `ValidateAsync(CancellationToken)` and use asynchronous operations when validation requires them. Register the validator as `IAsyncStartupValidator`, and don't also register it as `IStartupValidator`.

If your application only calls `ValidateOnStart()`, you normally don't need to change anything for this warning because the options framework handles startup validation.

## Affected APIs

- <xref:Microsoft.Extensions.Options.IStartupValidator>
