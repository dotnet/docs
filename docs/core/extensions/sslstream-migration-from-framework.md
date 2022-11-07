---
title: Migrating from .NET Framework to .NET
description: How to migrate code using SslStream from .NET Framework to .NET
author: rzikm
ms.author: rzikm
ms.date: 11/04/2022
---

# Migrating from .NET Framework to .NET

.NET brought many improvements as well as breaking changes to how <xref:System.Net.Security.SslStream> works. The most important change related to <xref:System.Net.Security.SslStream> behavior is that <xref:System.Net.Security.SslStream> is no longer affected by the <xref:System.Net.ServicePointManager> class. Since .NET, allowed SSL/TLS protocols and certificate validation callbacks must be configured separately for each <xref:System.Net.Security.SslStream> instance.
