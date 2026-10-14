---
title: SYSLIB0066 warning - IStartupValidator is obsolete
description: Learn about the obsoletion of IStartupValidator. Use of this interface generates compile-time warning SYSLIB0066.
ms.date: 10/13/2026
ai-usage: ai-generated
f1_keywords:
  - SYSLIB0066
---

# SYSLIB0066: IStartupValidator is obsolete

Starting in .NET 11, <xref:Microsoft.Extensions.Options.IStartupValidator> is obsolete. When you reference or implement this interface, the compiler generates warning `SYSLIB0066` with the message `Implement IAsyncStartupValidator instead.` The interface remains available and functional for compatibility.

## Reason for obsoletion

Host startup has an asynchronous entry point through <xref:Microsoft.Extensions.Hosting.IHost.StartAsync*>. New custom startup validators should use <xref:Microsoft.Extensions.Options.IAsyncStartupValidator>. Its asynchronous `ValidateAsync` contract means asynchronous implementations don't need to provide an unused synchronous `Validate` method. The two interfaces are independent.

## Workaround

To migrate a custom startup validator, implement and register <xref:Microsoft.Extensions.Options.IAsyncStartupValidator> instead. Use asynchronous operations in `ValidateAsync` when validation requires them, and forward the cancellation token. Register the implementation only under the startup-validation contract it provides; don't register it under both `IStartupValidator` and `IAsyncStartupValidator`.

Applications that only call `OptionsBuilder<TOptions>.ValidateOnStart()` and don't directly implement a startup-validator interface normally don't need to change their code.

For more information, see [API obsoletions with non-default diagnostic IDs (.NET 11)](../../core/compatibility/core-libraries/11/obsolete-apis.md#syslib0066).

## Suppress a warning

If you must use the obsolete interface, you can suppress the warning in code or in your project file.

To suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
#pragma warning disable SYSLIB0066

// Code that uses the obsolete interface.

#pragma warning restore SYSLIB0066
```

To suppress all `SYSLIB0066` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <NoWarn>$(NoWarn);SYSLIB0066</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
