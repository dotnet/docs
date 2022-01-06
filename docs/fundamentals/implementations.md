---
title: .NET implementations
description: Describes the various .NET implementations, including .NET 5+, .NET Framework, Mono, and UWP.
ms.date: 01/05/2022
ms.custom: updateeachrelease
---
# .NET implementations

A .NET app is developed for one or more *[implementations](../standard/glossary.md#implementation-of-net) of .NET*. Implementations of .NET include .NET Framework, .NET 5+ (and .NET Core), and Mono.

Each implementation of .NET includes the following components:

- One or more runtimes&mdash;for example, .NET Framework CLR and .NET 5 CLR.
- A class library&mdash;for example, .NET Framework Base Class Library and .NET 5 Base Class Library.
- Optionally, one or more application frameworks&mdash;for example, [ASP.NET](https://www.asp.net/), [Windows Forms](/dotnet/desktop/winforms/windows-forms-overview), and [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/) are included in .NET Framework and .NET 5+.
- Optionally, development tools. Some development tools are shared among multiple implementations.

There are four .NET implementations that Microsoft supports:

- .NET 5 (and .NET Core) and later versions
- .NET Framework
- Mono
- UWP

.NET 6 is currently the primary implementation, and the one that's the focus of ongoing development. .NET 6 is built on a single code base that supports multiple platforms and many workloads, such as Windows desktop apps and cross-platform console apps, cloud services, and websites. [Some workloads](../core/whats-new/dotnet-6.md#sdk-workloads), such as .NET WebAssembly build tools, are available as optional installations.

## .NET 5 and later versions

.NET 5+, previously referred to as .NET Core, is a cross-platform implementation of .NET that's designed to handle server and cloud workloads at scale. It also supports other workloads, including desktop apps. It runs on Windows, macOS, and Linux. It implements .NET Standard, so code that targets .NET Standard can run on .NET 5+. [ASP.NET Core](https://dotnet.microsoft.com/learn/aspnet/what-is-aspnet-core), [Windows Forms](/dotnet/desktop/winforms/windows-forms-overview), and [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/) all run on .NET 5+.

.NET 6 is the latest version of this .NET implementation.

For more information, see the following resources:

- [.NET introduction](../core/introduction.md)
- [.NET vs. .NET Framework for server apps](../standard/choosing-core-framework-server.md)
- [.NET 5+ and .NET Standard](../standard/net-standard.md#net-5-and-net-standard)

## .NET Framework

.NET Framework is the original .NET implementation that has existed since 2002. Versions 4.5 and later implement .NET Standard, so code that targets .NET Standard can run on those versions of .NET Framework. It contains additional Windows-specific APIs, such as APIs for Windows desktop development with Windows Forms and WPF. .NET Framework is optimized for building Windows desktop applications.

For more information, see the [.NET Framework guide](../framework/index.yml).

## Mono

Mono is a .NET implementation that is mainly used when a small runtime is required. It is the runtime that powers Xamarin applications on Android, macOS, iOS, tvOS, and watchOS and is focused primarily on a small footprint. Mono also powers games built using the Unity engine.

It supports all of the currently published .NET Standard versions.

Historically, Mono implemented the larger API of .NET Framework and emulated some of the most popular capabilities on Unix. It is sometimes used to run .NET applications that rely on those capabilities on Unix.

Mono is typically used with a just-in-time compiler, but it also features a full static compiler (ahead-of-time compilation) that is used on platforms like iOS.

For more information, see the [Mono documentation](https://www.mono-project.com/docs/).

## Universal Windows Platform (UWP)

UWP is an implementation of .NET that is used for building modern, touch-enabled Windows applications and software for the Internet of Things (IoT). It's designed to unify the different types of devices that you may want to target, including PCs, tablets, phones, and even the Xbox. UWP provides many services, such as a centralized app store, an execution environment (AppContainer), and a set of Windows APIs to use instead of Win32 (WinRT). Apps can be written in C++, C#, Visual Basic, and JavaScript.

For more information, see [Introduction to the Universal Windows Platform](/windows/uwp/get-started/universal-application-platform-guide).
