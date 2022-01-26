---
title: Compare ASP.NET SignalR and ASP.NET Core SignalR
description: How does ASP.NET Core SignalR differ from its predecessor, ASP.NET SignalR?
author: ardalis
ms.date: 12/10/2021
---

# Compare ASP.NET SignalR and ASP.NET Core SignalR

ASP.NET Core SignalR is incompatible with clients or servers using ASP.NET SignalR. You'll need to update both clients and server to use ASP.NET Core SignalR. Some differences are described in this section, while the full list is available in the [docs](/aspnet/core/signalr/version-differences). ASP.NET Core SignalR requires .NET Core 2.1 or greater.

## Feature differences

- ASP.NET SignalR automatically attempts to reconnect dropped connections; this behavior is opt-in for ASP.NET Core SignalR clients
- Both frameworks support JSON; ASP.NET Core SignalR also supports a binary protocol based on MessagePack, and custom protocols can be created.
- The Forever Frame transport, supported by ASP.NET SignalR, isn't supported in ASP.NET Core SignalR.
- ASP.NET Core SignalR must be configured by adding `services.AddSignalR()` and `app.UseEndpoints` in `Startup.ConfigureServices` and `Startup.Configure`, respectively.
- ASP.NET Core SignalR requires sticky sessions; ASP.NET SignalR doesn't.
- ASP.NET Core simplifies the connection model; connections are only made to a single hub.
- ASP.NET Core SignalR supports streaming data from the hub to the client.
- ASP.NET Core SignalR doesn't support passing state between clients and the hub (but method calls still allow passing information between hubs and clients).
- The `PersistentConnection` class doesn't exist in ASP.NET Core SignalR.
- ASP.NET SignalR supports SQL Server and Redis. ASP.NET Core SignalR supports [Azure SignalR](/azure/azure-signalr/) and Redis.

## References

- [Differences between ASP.NET SignalR and ASP.NET Core SignalR](/aspnet/core/signalr/version-differences)
- [Azure SignalR Service](/azure/azure-signalr/)

>[!div class="step-by-step"]
>[Previous](razor-differences.md)
>[Next](testing-differences.md)
