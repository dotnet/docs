---
title: Compare ASP.NET SignalR and ASP.NET Core SignalR
description: How does ASP.NET Core SignalR differ from its predecessor, ASP.NET SignalR?
author: ardalis
ms.date: 11/13/2020
---

# Compare ASP.NET SignalR and ASP.NET Core SignalR

ASP.NET Core SignalR is not compatible with clients or servers using ASP.NET SignalR. You will need to update both clients and server to use ASP.NET Core SignalR. Some differences are described in this section, while the full list is available in the [docs](https://docs.microsoft.com/aspnet/core/signalr/version-differences). ASP.NET Core SignalR requires .NET Core 3.0 or greater.

## Feature differences

- ASP.NET SignalR automatically attempts to reconnect dropped connections; this behavior is opt-in for ASP.NET Core SignalR clients
- Both frameworks support JSON; ASP.NET Core SignalR also supports a binary protocol based on MessagePack, and custom protocols can be created.
- The Forever Frame transport, supported by ASP.NET SignalR, isn't supported in ASP.NET Core SignalR.
- ASP.NET Core SignalR must be configured by adding `services.AddSignalR()` in `ConfigureServices` as well as in `app.UseEndpoints` in `Configure`
- ASP.NET Core SignalR requires sticky sessions; ASP.NET SignalR does not.
- ASP.NET Core simplifies the connection model; connections are only made to a single hub.
- ASP.NET Core SignalR supports streaming data from the hub to the client.
- ASP.NET Core SignalR does not support passing state between clients and the hub.
- The `PersistentConnection` class does not exist in ASP.NET Core SignalR.
- ASP.NET SignalR supports SQL Server and Redis. ASP.NET Core SignalR supports [Azure SignalR](https://docs.microsoft.com/azure/azure-signalr/) and Redis.

## References

- [Differences between ASP.NET SignalR and ASP.NET Core SignalR](https://docs.microsoft.com/aspnet/core/signalr/version-differences)
- [Azure SignalR Service](https://docs.microsoft.com/azure/azure-signalr/)

>[!div class="step-by-step"]
>[Previous](razor-differences.md)
>[Next](testing-differences.md)
