---
title: "WCF Discovery Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 84fad0e4-23b1-45b5-a2d4-c9cdf90bbb22
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WCF Discovery Overview
The Discovery APIs provide a unified programming model for the dynamic publication and discovery of Web services using the WS-Discovery protocol. These APIs allow services to publish themselves and clients to find published services. Once a service is made discoverable, the service has the ability to send announcement messages as well as listen for and respond to discovery requests. Discoverable services can send Hello messages to announce their arrival on a network and Bye messages to announce their departure from a network. To find a service, clients send a `Probe` request that contains specific criteria such as service contract type, keywords, and scope on the network. Services receive the `Probe` request and determine whether they match the criteria. If a service matches, it responds by sending a `ProbeMatch` message back to the client with the information necessary to contact the service. Clients can also send `Resolve` requests that allow them to find services that may have changed their endpoint address. Matching services respond to `Resolve` requests by sending a `ResolveMatch` message back to the client.  
  
## Ad-Hoc and Managed Modes  
 The Discovery API supports two different modes: Managed and Ad-Hoc. In Managed mode there is a centralized server called a discovery proxy that maintains information about available services. The discovery proxy can be populated with information about services in a variety of ways. For example, services can send announcement messages during start up to the discovery proxy or the proxy may read data from a database or a configuration file to determine what services are available. How the discovery proxy is populated is completely up to the developer. Clients use the discovery proxy to retrieve information about available services. When a client searches for a service it sends a `Probe` message to the discovery proxy and the proxy determines whether any of the services it knows about match the service the client is searching for. If there are matches the discovery proxy sends a `ProbeMatch` response back to the client. The client can then contact the service directly using the service information returned from the proxy. The key principle behind Managed mode is that the discovery requests are sent in a unicast manner to one authority, the discovery proxy. The .NET Framework contains key components that allow you to build your own proxy. Clients and services can locate the proxy by multiple methods:  
  
-   The proxy can respond to ad-hoc messages.  
  
-   The proxy can send an announcement message during start up.  
  
-   Clients and services can be written to look for a specific well-known endpoint.  
  
 In Ad-Hoc mode, there is no centralized server. All discovery messages such as service announcements and client requests are sent in a multicast fashion. By default the .NET Framework contains support for Ad-Hoc discovery over the UDP protocol. For example, if a service is configured to send out a Hello announcement on start up, it sends it out over a well-known, multicast address using the UDP protocol. Clients have to actively listen for these announcements and process them accordingly. When a client sends a `Probe` message for a service it is sent over the network using a multicast protocol. Each service that receives the request determines whether it matches the criteria in the `Probe` message and responds directly to the client with a `ProbeMatch` message if the service matches the criteria specified in the `Probe` message.  
  
## Benefits of Using WCF Discovery  
 Because WCF Discovery is implemented using the WS-Discovery protocol it is interoperable with other clients, services, and proxies that implement WS-Discovery as well. WCF Discovery is built upon the existing WCF APIs, which makes it easy to add Discovery functionality to your existing services and clients. Service discoverability can be easily added through the application configuration settings. In addition, WCF Discovery also supports using the discovery protocol over other transports such as peer net, naming overlay, and HTTP. WCF Discovery provides support for a Managed mode of operation where a discovery proxy is used. This can reduce network traffic as messages are sent directly to the discovery proxy instead of sending multicast messages to the entire network. WCF Discovery also allows for more flexibility when working with Web services. For example, you can change the address of a service without having to reconfigure the client or the service. When a client must access the service it can issue a `Probe` message through a `Find` request and expect the service to respond with its current address. WCF Discovery allows a client to search for a service based on different criteria including contract types, binding elements, namespace, scope, and keywords or version numbers. WCF Discovery enables runtime and design time discovery. Adding discovery to your application can be used to enable other scenarios such as fault tolerance and auto configuration.  
  
## Service Publication  
 To make a service discoverable, a <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> must be added to the service host and a discovery endpoint must be added to specify where to listen for discovery messages. The following code example shows how a self-hosted service can be modified to make it discoverable.  
  
```csharp  
Uri baseAddress = new Uri(string.Format("http://{0}:8000/discovery/scenarios/calculatorservice/{1}/",  
        System.Net.Dns.GetHostName(), Guid.NewGuid().ToString()));

// Create a ServiceHost for the CalculatorService type.
using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
{
    // Add calculator endpoint
    serviceHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), string.Empty);

    // ** DISCOVERY ** //
    // Make the service discoverable by adding the discovery behavior
    serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

    // ** DISCOVERY ** //
    // Add the discovery endpoint that specifies where to publish the services
    serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());

    // Open the ServiceHost to create listeners and start listening for messages.
    serviceHost.Open();

    // The service can now be accessed.
    Console.WriteLine("Press <ENTER> to terminate service.");
    Console.ReadLine();
}
```  
  
 A <xref:System.ServiceModel.Discovery.ServiceDiscoveryBehavior> instance must be added to a service description for the service to be discoverable. A <xref:System.ServiceModel.Discovery.DiscoveryEndpoint> instance must be added to the service host to tell the service where to listen for discovery requests. In this example, a <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> (which is derived from <xref:System.ServiceModel.Discovery.DiscoveryEndpoint>) is added to specify that the service should listen for discovery requests over the UDP multicast transport. The <xref:System.ServiceModel.Discovery.UdpDiscoveryEndpoint> is used for Ad-Hoc discovery because all messages are sent in a multicast fashion.  
  
## Announcement  
 By default, service publication does not send out announcement messages. The service must be configured to send out announcement messages. This provides additional flexibility for service writers because they can announce the service separately from listening for discovery messages. Service announcement can also be used as a mechanism for registering services with a discovery proxy or other service registries. The following code shows how to configure a service to send announcement messages over a UDP binding.  
  
```csharp  
Uri baseAddress = new Uri(string.Format("http://{0}:8000/discovery/scenarios/calculatorservice/{1}/",
        System.Net.Dns.GetHostName(), Guid.NewGuid().ToString()));

// Create a ServiceHost for the CalculatorService type.
using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
{
    // Add calculator endpoint
    serviceHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), string.Empty);

    // ** DISCOVERY ** //
    // Make the service discoverable by adding the discovery behavior
    ServiceDiscoveryBehavior discoveryBehavior = new ServiceDiscoveryBehavior();
    serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

    // Send announcements on UDP multicast transport
    discoveryBehavior.AnnouncementEndpoints.Add(
      new UdpAnnouncementEndpoint());

    // ** DISCOVERY ** //
    // Add the discovery endpoint that specifies where to publish the services
    serviceHost.Description.Endpoints.Add(new UdpDiscoveryEndpoint());

    // Open the ServiceHost to create listeners and start listening for messages.
    serviceHost.Open();

    // The service can now be accessed.
    Console.WriteLine("Press <ENTER> to terminate service.");
    Console.ReadLine();
}
```  
  
## Service Discovery  
 A client application can use the <xref:System.ServiceModel.Discovery.DiscoveryClient> class to find services. The developer creates an instance of the <xref:System.ServiceModel.Discovery.DiscoveryClient> class that passes in a discovery endpoint that specifies where to send `Probe` or `Resolve` messages. The client then calls <xref:System.ServiceModel.Discovery.DiscoveryClient.Find%2A> that specifies search criteria within a <xref:System.ServiceModel.Discovery.FindCriteria> instance. If matching services are found, <xref:System.ServiceModel.Discovery.DiscoveryClient.Find%2A> returns a collection of <xref:System.ServiceModel.Discovery.EndpointDiscoveryMetadata>. The following code shows how to call the `Find` method and then connect to a discovered service.  
  
```csharp  
class Client
{
    static EndpointAddress serviceAddress;
  
    static void Main()
    {  
        if (FindService()) 
        {
            InvokeService();
        }
    }  
  
    // ** DISCOVERY ** //  
    static bool FindService()  
    {  
        Console.WriteLine("\nFinding Calculator Service ..");  
        DiscoveryClient discoveryClient =   
            new DiscoveryClient(new UdpDiscoveryEndpoint());  
  
        Collection<EndpointDiscoveryMetadata> calculatorServices =   
            (Collection<EndpointDiscoveryMetadata>)discoveryClient.Find(new FindCriteria(typeof(ICalculator))).Endpoints;  
  
        discoveryClient.Close();  
  
        if (calculatorServices.Count == 0)  
        {  
            Console.WriteLine("\nNo services are found.");  
            return false;  
        }  
        else  
        {  
            serviceAddress = calculatorServices[0].Address;  
            return true;  
        }  
    }  
  
    static void InvokeService()  
    {  
        Console.WriteLine("\nInvoking Calculator Service at {0}\n", serviceAddress);  
  
        // Create a client  
        CalculatorClient client = new CalculatorClient();  
        client.Endpoint.Address = serviceAddress;  
        client.Add(10,3);  
    }
}  
```  
  
## Discovery and Message Level Security  
 When using message level security it is necessary to specify an <xref:System.ServiceModel.EndpointIdentity> on the service discovery endpoint and a matching <xref:System.ServiceModel.EndpointIdentity> on the client discovery endpoint. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] message level security, see [Message Security](../../../../docs/framework/wcf/feature-details/message-security-in-wcf.md).  
  
## Discovery and Web Hosted Services  
 In order for WCF services to be discoverable they must be running. WCF services hosted under IIS or WAS do not run until IIS/WAS receives a message bound for the service, so they cannot be discoverable by default.  There are two options for making Web-Hosted services discoverable:  
  
1.  Use the Windows Server AppFabric Auto-Start feature  
  
2.  Use a discovery proxy to communicate on behalf of the service  
  
 Windows Server AppFabric has an Auto-Start feature that will allow a service to be started before receiving any messages. With this Auto-Start set, an IIS/WAS hosted service can be configured to be discoverable. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the Auto-Start feature see, [Windows Server AppFabric Auto-Start Feature](http://go.microsoft.com/fwlink/?LinkId=205545). Along with turning on the Auto-Start feature, you must configure the service for discovery. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Programmatically Add Discoverability to a WCF Service and Client](../../../../docs/framework/wcf/feature-details/how-to-programmatically-add-discoverability-to-a-wcf-service-and-client.md)[Configuring Discovery in a Configuration File](../../../../docs/framework/wcf/feature-details/configuring-discovery-in-a-configuration-file.md).  
  
 A discovery proxy can be used to communicate on behalf of the WCF service when the service is not running. The proxy can listen for probe or resolve messages and respond to the client. The client can then send messages directly to the service. When the client sends a message to the service it will be instantiated to respond to the message. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] implementing a discovery proxy see, [Implementing a Discovery Proxy](../../../../docs/framework/wcf/feature-details/implementing-a-discovery-proxy.md).  
  
> [!NOTE]
>  For WCF Discovery to work correctly, all NICs (Network Interface Controller) should only have 1 IP address.
