---
title: "Creating Multicasting Applications using the UDP Transport"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7485154a-6e85-4a67-a9d4-9008e741d4df
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating Multicasting Applications using the UDP Transport
Multicasting applications send small messages to a large number of recipients at the same time without the need to establish point to point connections. The emphasis of such applications is speed over reliability. In other words, it is more important to send timely data than to ensure any specific message is actually received. WCF now supports writing multicasting applications using the <xref:System.ServiceModel.UdpBinding>. This transport is useful in scenarios where a service needs to send out small messages to a number of clients simultaneously. A stock ticker application is an example of such a service.  
  
## Implementing a Multicast Application  
 To implement a multicast application, define a service contract and for each software component that needs to respond to the multicast messages, implement the service contract. For example, a stock ticker application might define a service contract:  
  
```  
// Shared contracts between the client and the service  
[ServiceContract]
interface IStockTicker
{
    [OperationContract(IsOneWay = true)]
    void SendStockInfo(StockInfo[] stockInfo);
}

[DataContract]
class StockInfo
{
    [DataMember]
    public string Symbol;

    [DataMember]
    public float Price;

    public StockInfo(string symbol, float price)
    {
        this.Symbol = symbol;
        this.Price = price;
    }
}
```  
  
 Each application that wants to receive multicast messages must host a service that exposes this interface.  For example, here is a code sample that illustrates how to receive multicast messages:  
  
```  
// Service Address
string serviceAddress = "soap.udp://224.0.0.1:40000";
// Binding
UdpBinding myBinding = new UdpBinding();
// Host
ServiceHost host = new ServiceHost(typeof(StockTickerService), new Uri(serviceAddress));
// Add service endpoint
host.AddServiceEndpoint(typeof(IStockTicker), myBinding, string.Empty);
// Openup the service host
host.Open();

Console.WriteLine("Start receiving stock information");
Console.ReadLine();
```  
  
 The application specifies the UDP address that all services will be listening on. A new <xref:System.ServiceModel.ServiceHost> is created and a service endpoint is exposed using the <xref:System.ServiceModel.UdpBinding>. The <xref:System.ServiceModel.ServiceHost> is then opened and will start listening for incoming messages.  
  
 In this type of a scenario it is the client that actually sends out multicast messages. Each service that is listening at the correct UDP address will receive the multicast messages. Here is an example of a client that sends out multicast messages:  
  
```  
// Multicast Address
string serviceAddress = "soap.udp://224.0.0.1:40000";

// Binding
UdpBinding myBinding = new UdpBinding();

// Channel factory
ChannelFactory<IStockTicker> factory 
    = new ChannelFactory<IStockTicker>(myBinding,
                new EndpointAddress(serviceAddress));

// Call service
IStockTicker proxy = factory.CreateChannel();

while (true)
{
    // This will continue to mulicast stock information
    proxy.SendStockInfo(GetStockInfo());
    Console.WriteLine(String.Format("sent stock info at {0}", DateTime.Now));
    // Wait for one second before sending another update
    System.Threading.Thread.Sleep(new TimeSpan(0, 0, 1));
}
```  
  
 This code generates stock information and then uses the service contract IStockTicker to send multicast messages to call services listening on the correct UDP address.  
  
### UDP and Reliable Messaging  
 The UDP binding does not support reliable messaging because of the lightweight nature of the UDP protocol. If you need to confirm that messages are received by a remote endpoint, use a transport that supports reliable messaging like  HTTP or TCP. For more information about reliable messaging see http://go.microsoft.com/fwlink/?LinkId=231830  
  
### Two-way Multicast Messaging  
 While multicast messages are generally one-way, the UdpBinding does support request/reply message exchange. Messages sent using the UDP transport contain both a From and To address. Care must be taken when using the From address as it could be maliciously changed en-route.  The address can be checked using the following code:  
  
```  
if (address.AddressFamily == AddressFamily.InterNetwork)
{
    // IPv4
    byte[] addressBytes = address.GetAddressBytes();
    return ((addressBytes[0] & 0xE0) == 0xE0);
}
else
{
    // IPv6
    return address.IsIPv6Multicast;
}
```  
  
 This code checks the first byte of the From address to see if it contains 0xE0 which signifies that the address is a multi-cast address.  
  
### Security Considerations  
 When listening for multicast messages an ICMP packet is sent to the router notifying it you are listening on the multicast address. Anyone on the local subnet who has permissions could listen for these types of packets and determine which multicast address and port you are listening on.  
  
 Do not use the IP address of the sender for any security purposes. This information can be spoofed and can cause an application to send responses to the wrong machine. One way to mitigate this threat is to enable message level security. At the network level IPSec  (Internet Protocol Security) and/or NAP (Network Access Protection) could also be used.
