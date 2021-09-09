---
description: "Learn more about: Announcements Sample"
title: "Announcements Sample"
ms.date: "03/30/2017"
ms.assetid: 954a75e4-9a97-41d6-94fc-43765d4205a9
---
# Announcements Sample

The [Announcements sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Discovery/Announcements) shows how to use the Announcement functionality of the Discovery feature. Announcements allow services to send out announcement messages that contain metadata about the service. By default a hello announcement is sent when the service starts up and a bye announcement is sent when the service shuts down. These announcements can be multicast or they can be sent point-to-point. This sample consists of two projects service and client.

## Service

This project contains a self-hosted calculator service. In the `Main` method, a service host is created and a service endpoint is added to it. Next, a <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> is created. To enable announcements, an announcement endpoint must be added to the <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior>. In this case a standard endpoint, using UDP multicast is added as the announcement endpoint. This broadcasts the announcements over a well-known UDP address.

```csharp
Uri baseAddress = new Uri("http://localhost:8000/" + Guid.NewGuid().ToString());

// Create a ServiceHost for the CalculatorService type.
using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
{
     serviceHost.AddServiceEndpoint(typeof(ICalculatorService), new WSHttpBinding(), String.Empty);

     ServiceDiscoveryBehavior serviceDiscoveryBehavior = new ServiceDiscoveryBehavior();

     // Announce the availability of the service over UDP multicast
    serviceDiscoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());

    // Make the service discoverable over UDP multicast.
    serviceHost.Description.Behaviors.Add(serviceDiscoveryBehavior);
    serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());
    serviceHost.Open();
    // ...
}
```

## Client

In this project, note that the client hosts an <xref:System.ServiceModel.Discovery.AnnouncementService>. Furthermore, two delegates are registered with events. These events dictate what the client does when online and offline announcements are received.

```csharp
// Create an AnnouncementService instance
AnnouncementService announcementService = new AnnouncementService();

// Subscribe the announcement events
announcementService.OnlineAnnouncementReceived += OnOnlineEvent;
announcementService.OfflineAnnouncementReceived += OnOfflineEvent;
```

The `OnOnlineEvent` and `OnOfflineEvent` methods handle the hello and bye announcement messages respectively.

```csharp
static void OnOnlineEvent(object sender, AnnouncementEventArgs e)
{
    Console.WriteLine();
    Console.WriteLine("Received an online announcement from {0}:", e.AnnouncementMessage.EndpointDiscoveryMetadata.Address);
PrintEndpointDiscoveryMetadata(e.AnnouncementMessage.EndpointDiscoveryMetadata);
}

static void OnOfflineEvent(object sender, AnnouncementEventArgs e)
{
    Console.WriteLine();
    Console.WriteLine("Received an offline announcement from {0}:", e.AnnouncementMessage.EndpointDiscoveryMetadata.Address);
            PrintEndpointDiscoveryMetadata(e.AnnouncementMessage.EndpointDiscoveryMetadata);
}
```

#### To use this sample

1. This sample uses HTTP endpoints and to run this sample, proper URL ACLs must be added. For more information, see [Configuring HTTP and HTTPS](../feature-details/configuring-http-and-https.md). Executing the following command at an elevated privilege should add the appropriate ACLs. You may want to substitute your Domain and Username for the following arguments if the command does not work as is. `netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\%UserName%`

2. Build the solution.

3. Run the client.exe application.

4. Run the service.exe application. Note the client receives an online announcement.

5. Close the service.exe application. Note the client receives an offline announcement.
