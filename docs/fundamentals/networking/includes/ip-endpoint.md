---
ms.date: 08/24/2022
author: IEvangelist
ms.author: dapine
ms.topic: include
---

## Create an IP endpoint

When working with <xref:System.Net.Sockets?displayProperty=fullName>, you represent a network endpoint as an <xref:System.Net.IPEndPoint> object. The `IPEndPoint` is constructed with an <xref:System.Net.IPAddress> and its corresponding port number. Before you can initiate a conversation through a <xref:System.Net.Sockets.Socket>, you create a data pipe between your app and the remote destination.

TCP/IP uses a network address and a service port number to uniquely identify a service. The network address identifies a specific network destination; the port number identifies the specific service on that device to connect to. The combination of network address and service port is called an endpoint, which is represented in the .NET by the <xref:System.Net.EndPoint> class. A descendant of `EndPoint` is defined for each supported address family; for the IP address family, the class is <xref:System.Net.IPEndPoint>.

The <xref:System.Net.Dns> class provides domain-name services to apps that use TCP/IP internet services. The <xref:System.Net.Dns.GetHostEntryAsync%2A> method queries a DNS server to map a user-friendly domain name (such as "host.contoso.com") to a numeric Internet address (such as `192.168.1.1`). `GetHostEntryAsync` returns a `Task<IPHostEntry>` that when awaited contains a list of addresses and aliases for the requested name. In most cases, you can use the first address returned in the <xref:System.Net.IPHostEntry.AddressList%2A> array. The following code gets an <xref:System.Net.IPAddress> containing the IP address for the server `host.contoso.com`.

```csharp
IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync("host.contoso.com");
IPAddress ipAddress = ipHostInfo.AddressList[0];
```

> [!TIP]
> For manual testing and debugging purposes, you can typically use the <xref:System.Net.Dns.GetHostEntryAsync%2A> method to get given the <xref:System.Net.Dns.GetHostName?displayProperty=nameWithType> value to resolve the localhost name to an IP address.

The Internet Assigned Numbers Authority (IANA) defines port numbers for common services. For more information, see [IANA: Service Name and Transport Protocol Port Number Registry](https://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml)). Other services can have registered port numbers in the range 1,024 to 65,535. The following code combines the IP address for `host.contoso.com` with a port number to create a remote endpoint for a connection.

```csharp
IPEndPoint ipEndPoint = new(ipAddress, 11_000);
```

After determining the address of the remote device and choosing a port to use for the connection, the app can establish a connection with the remote device.
