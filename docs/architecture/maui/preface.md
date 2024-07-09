---
title: A preface to enterprise architecture for MAUI applications
description: Guidance for what the book will cover, reference materials, and how to approach the book.
author: michaelstonis
no-loc: [MAUI]
ms.date: 05/30/2024
---

# Purpose

[!INCLUDE [download-alert](includes/download-alert.md)]

This eBook provides guidance on building cross-platform enterprise apps using .NET MAUI. .NET MAUI is a cross-platform UI toolkit that allows developers to easily create native user interface layouts that can be shared across platforms, including iOS, macOS, Android, and Windows. It provides a comprehensive solution for Business to Employee (B2E), Business to Business (B2B), and Business to Consumer (B2C) apps, providing the ability to share code across all target platforms and helping to lower the total cost of ownership (TCO).

The guide provides architectural guidance for developing adaptable, maintainable, and testable .NET MAUI enterprise apps. Guidance is provided on how to implement MVVM, dependency injection, navigation, validation, and configuration management, while maintaining loose coupling. In addition, there's also guidance on performing authentication and authorization with IdentityServer, accessing data from containerized microservices, and unit testing.

The guide comes with source code for the [eShop multi-platform app](https://github.com/dotnet/eShop/tree/main/src/ClientApp), and source code for the [eShop reference app](https://github.com/dotnet/eShop). The eShop multi-platform app is a cross-platform enterprise app developed using .NET MAUI, which connects to a series of containerized microservices known as the eShop reference app. However, the eShop multi-platform app can be configured to consume data from mock services for those who wish to avoid deploying the containerized microservices.

## What's left out of this guide's scope

This guide is aimed at readers who are already familiar with .NET MAUI. For a detailed introduction to .NET MAUI, see the [.NET MAUI documentation](/dotnet/maui/).

## Who should use this guide

The audience for this guide is mainly developers and architects who would like to learn how to architect and implement cross-platform enterprise apps using .NET MAUI.

A secondary audience is technical decision-makers who would like to receive an architectural and technology overview before deciding on what approach to select for cross-platform enterprise app development using .NET MAUI.

## How to use this guide

This guide focuses on building cross-platform enterprise apps using .NET MAUI. As such, it should be read in its entirety to provide a foundation of understanding such apps and their technical considerations. The guide and its sample app can also serve as a starting point or reference for creating a new enterprise app. Use the associated sample app as a template for the new app or see how to organize an app's component parts. Then, refer back to this guide for architectural guidance.

Feel free to forward this guide to team members to help ensure a common understanding of cross-platform enterprise app development using .NET MAUI. Having everybody working from a common set of terminologies and underlying principles will help ensure a consistent application of architectural patterns and practices.
