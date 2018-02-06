---
title: "Discovery Announcements and Announcement Client"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 426c6437-f8d2-4968-b23a-18afd671aa4b
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Discovery Announcements and Announcement Client
The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] discovery feature enables components to announce their availability. If configured to do so, a service sends Hello and Bye announcements. Clients or other components can listen for such announcement messages and act on them. This provides an alternative method for clients to be aware of services. Announcement functionality has several uses, for example, if the services enter and leave a network frequently, announcements may be a better alternative than searching for services. With this approach, the network traffic is reduced and the client can learn about the presence or departure of the service as soon as announcements are received.  
  
## Discovery Announcements  
 When a service configured for announcements joins a network and becomes discoverable, it sends a Hello message announcing its availability to listening clients. The message contains discovery related information about the service, such as its contract, endpoint address and associated scopes. You can specify where the announcement message is sent with the <xref:System.ServiceModel.Discovery.AnnouncementEndpoint> class. If the announcement endpoint is a <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint> then the Hello and Bye are multicast appropriately, or if the announcement endpoint is unicast, the messages are sent directly to the specified endpoint.  
  
> [!NOTE]
>  Announcements are sent when the service host opens and closes. If these calls do not finish properly the announcement message may not be sent out. For example if the service faults, then the Bye announcement message is not sent.  
  
> [!TIP]
>  You can customize the announcement functionality, allowing you to send announcements whenever you choose.  
  
 [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] defines the <xref:System.ServiceModel.Discovery.AnnouncementEndpoint> and <xref:System.ServiceModel.Discovery.UdpAnnouncementEndpoint> as standard endpoints to allow services and clients to easily send Hello and Bye announcements.  
  
### Announcements on the Service  
 To configure the service to send announcements, add a <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> with an announcement endpoint. The following example shows how to programmatically add this behavior to the service host. This example uses the `UdpAnnouncementEndpoint`, which implies that the announcements are multicast to a location specified by that standard endpoint.  
  
```  
ServiceDiscoveryBehavior serviceDiscoveryBehavior = new ServiceDiscoveryBehavior();
serviceDiscoveryBehavior.AnnouncementEndpoints.Add(new UdpAnnouncementEndpoint());
serviceHost.Description.Behaviors.Add(serviceDiscoveryBehavior);
```  
  
 The behavior can be configured in the configuration file as well, as shown in the following example.  
  
```xml  
<services>
  <service behaviorConfiguration="CalculatorBehavior" name="Microsoft.Samples.Discovery.CalculatorService">
    <!--Add Discovery Endpoint-->
    <endpoint name="udpDiscoveryEpt" kind="udpDiscoveryEndpoint" />
  </service>
</services>
<behaviors>
  <serviceBehaviors>
    <behavior name="CalculatorBehavior">
      <!--Add Discovery behavior-->
      <serviceDiscovery>
        <announcementEndpoints>
          <endpoint kind="udpAnnouncementEndpoint" />
        </announcementEndpoints>
      </serviceDiscovery>
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
 The preceding examples configure a service to automatically send announcement messages. You can also send announcement messages explicitly by using the <xref:System.ServiceModel.Discovery.AnnouncementClient> class.  
  
### Announcements on the Client  
 A client application must host an announcement service to respond to the Hello and Bye messages and subscribe to the <xref:System.ServiceModel.Discovery.AnnouncementService.OnlineAnnouncementReceived> and <xref:System.ServiceModel.Discovery.AnnouncementService.OfflineAnnouncementReceived> events. The following example shows how to do this.  
  
```  
// Create an AnnouncementService instance
AnnouncementService announcementService = new AnnouncementService();
  
// Subscribe the announcement events
announcementService.OnlineAnnouncementReceived += OnOnlineEvent;
announcementService.OfflineAnnouncementReceived += OnOfflineEvent;
  
// Create ServiceHost for the AnnouncementService
using (ServiceHost announcementServiceHost = new ServiceHost(announcementService))
{  
    // Listen for the announcements sent over UDP multicast
    announcementServiceHost.AddServiceEndpoint(new UdpAnnouncementEndpoint());
    announcementServiceHost.Open();
  
    Console.WriteLine("Press <ENTER> to terminate.");
    Console.ReadLine();
}  
```  
  
 When a Hello or Bye message is received, you can access the endpoint discovery metadata through <xref:System.ServiceModel.Discovery.AnnouncementEventArgs> as shown in the following example.  
  
```  
static void OnOnlineEvent(object sender, AnnouncementEventArgs e)
{
    Console.WriteLine("Received an online announcement from {0}", 
e.EndpointDiscoveryMetadata.Address);
}

static void OnOfflineEvent(object sender, AnnouncementEventArgs e)
{
    Console.WriteLine("Received an offline announcement from {0}", 
e.EndpointDiscoveryMetadata.Address);
}
```
