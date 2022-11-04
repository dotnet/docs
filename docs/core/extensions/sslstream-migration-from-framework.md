---
title: Migrating from .NET Framework to .NET Core
description: How to migrate code using SslStream from .NET Framework to .NET Core
author: rzikm
ms.author: rzikm
ms.date: 11/04/2022
---

# Migrating from .NET Framework to .NET Core

.NET Core brought many improvements as well as breaking changes to how `SslStream` works. The most important change related to `SslStream` behavior is that `SslStream` is no longer affected by the [`ServicePointManager`](https://learn.microsoft.com/en-us/dotnet/api/system.net.servicepointmanager?view=net-6.0) class. Since .NET Core, allowed SSL/TLS protocols and certificate validation callbacks must be configured separately for each `SslStream` instance.
