---
title: Dependency loading - .NET Core
description: Overview of managed and unmanaged dependency loading in .NET Core
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
ms.topic: overview
#customer intent: As a .NET Core developer, I want to understand assembly loading so that I can design and debug assembly loading issues.
---
# Dependency Loading in .NET Core

Every .NET Core application has dependencies. Even the simple `hello world` app has dependencies on portions of the .NET Core framework.

Understanding .NET Core default assembly loading logic can help understanding and debugging typical deployment issues.

In some applications dependencies are dynamically determined at runtime. In these situations, it's critical to understand how managed assemblies and unmanaged dependencies are loaded.

## TBD
