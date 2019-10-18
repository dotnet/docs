---
title: "How to:Determine the Discovery Version of a Probe Request"
ms.date: "03/30/2017"
ms.assetid: b3c4e2e2-2957-4074-ae6a-776a5ca84278
---
# How to:Determine the Discovery Version of a Probe Request

A discovery proxy may expose multiple discovery endpoints using different discovery versions. When a UDP multicast Probe request arrives at the proxy, the proxy should respond with a multicast suppression message. In order to do this, it would have to know the discovery version of the request.

## To Determine the Discovery Version of a Probe Request

In the method that responds to a Probe request (for example <xref:System.ServiceModel.Discovery.DiscoveryProxy.OnBeginFind%2A?displayProperty=nameWithType>) use the static <xref:System.ServiceModel.OperationContext.Current%2A?displayProperty=nameWithType> property to search for a <xref:System.ServiceModel.Discovery.DiscoveryOperationContextExtension>, as shown in the following code.

```csharp
DiscoveryOperationContextExtension doce = OperationContext.Current.Extensions.Find<DiscoveryOperationContextExtension>();
// Access the discovery version from the DiscoveryOperationContextExtension
doce.DiscoveryVersion;
```

## See also

- <xref:System.ServiceModel.Discovery.Configuration.AnnouncementEndpointElement.DiscoveryVersion%2A>
- [Implementing a Discovery Proxy](../../../../docs/framework/wcf/feature-details/implementing-a-discovery-proxy.md)
