---
title: Migrating from .NET Framework to .NET
description: How to migrate code using SslStream from .NET Framework to .NET
author: rzikm
ms.author: radekzikmund
ms.date: 11/04/2022
---

# Migrating from .NET Framework to .NET

.NET Core brought many improvements as well as breaking changes to how <xref:System.Net.Security.SslStream> works. The most important change related to network security is that
the <xref:System.Net.ServicePointManager> class has been mostly obsoleted and affects only the legacy <xref:System.Net.WebRequest> interface.

Since .NET, allowed SSL/TLS protocols and certificate validation callbacks must be configured separately for each <xref:System.Net.Security.SslStream> instance via the <xref:System.Net.Security.SslServerAuthenticationOptions> or <xref:System.Net.Security.SslClientAuthenticationOptions>. In order to configure network security options used in HTTPS in <xref:System.Net.Http.HttpClient>, you need to configure the security options in the underlying handler, such as <xref:System.Net.Http.SocketsHttpHandler.SslOptions?displayName=nameWithType>.
