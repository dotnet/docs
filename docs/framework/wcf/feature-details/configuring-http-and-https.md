---
title: "Configuring HTTP and HTTPS"
ms.date: "04/08/2019"
helpviewer_keywords: 
  - "configuring HTTP [WCF]"
ms.assetid: b0c29a86-bc0c-41b3-bc1e-4eb5bb5714d4
---
# Configuring HTTP and HTTPS

WCF services and clients can communicate over HTTP and HTTPS. The HTTP/HTTPS settings are configured by using Internet Information Services (IIS) or through the use of a command-line tool. When a WCF service is hosted under IIS HTTP or HTTPS settings can be configured within IIS (using the inetmgr.exe tool). If a WCF service is self-hosted, HTTP or HTTPS settings are configured by using a command-line tool.

At a minimum, you want to configure a URL registration and add a Firewall exception for the URL your service will be using. You can configure these settings with the Netsh.exe tool.

## Configuring namespace reservations

Namespace reservation assigns the rights for a portion of the HTTP URL namespace to a particular group of users. A reservation gives those users the right to create services that listen on that portion of the namespace. Reservations are URL prefixes, meaning that the reservation covers all subpaths of the reservation path. Namespace reservations permit two ways to use wildcards. The HTTP Server API documentation describes the [order of resolution between namespace claims that involve wildcards](/windows/desktop/Http/routing-incoming-requests).

A running application can create a similar request to add namespace registrations. Registrations and reservations compete for portions of the namespace. A reservation may have precedence over a registration according to the order of resolution given in the [order of resolution between namespace claims that involve wildcards](/windows/desktop/Http/routing-incoming-requests). In this case, the reservation blocks the running application from receiving requests.

The following example uses the Netsh.exe tool:

```console
netsh http add urlacl url=http://+:80/MyUri user=DOMAIN\user
```

This command adds a URL reservation for the specified URL namespace for the DOMAIN\user account. For more information on using the netsh command, type `netsh http add urlacl /?` in a command-prompt and press Enter.

## Configuring a firewall exception

When self-hosting a WCF service that communicates over HTTP, an exception must be added to the firewall configuration to allow inbound connections using a particular URL.

## Configuring SSL certificates

The Secure Sockets Layer (SSL) protocol uses certificates on the client and server to store encryption keys. The server provides its SSL certificate when a connection is made so that the client can verify the server identity. The server can also request a certificate from the client to provide mutual authentication of both sides of the connection.

Certificates are stored in a centralized store according to the IP address and port number of the connection. The special IP address 0.0.0.0 matches any IP address for the local machine. Note that the certificate store doesn't distinguish URLs based on the path. Services with the same IP address and port combination must share certificates even if the path in the URL for the services is different.

For step-by-step instructions, see [How to: Configure a Port with an SSL Certificate](how-to-configure-a-port-with-an-ssl-certificate.md).

## Configuring the IP Listen List

The HTTP Server API only binds to an IP address and port once a user registers a URL. By default, the HTTP Server API binds to the port in the URL for all of the IP addresses of the machine. A conflict arises if an application that doesn't use the HTTP Server API has previously bound to that combination of IP address and port. The IP Listen List allows WCF services to coexist with applications that use a port for some of the IP addresses of the machine. If the IP Listen List contains any entries, the HTTP Server API only binds to those IP addresses that the list specifies. Modifying the IP Listen List requires administrative privileges.

Use the netsh tool to modify the IP Listen List, as shown in the following example:

```console
netsh http add iplisten ipaddress=0.0.0.0:8000
```

## Other configuration settings

When using <xref:System.ServiceModel.WSDualHttpBinding>, the client connection uses defaults that are compatible with namespace reservations and the Windows firewall. If you choose to customize the client base address of a dual connection, then you also must configure these HTTP settings on the client to match the new address.

The HTTP Server API has some advanced configuration settings that aren't available through HttpCfg. These settings are maintained in the registry and apply to all applications running on the systems that use the HTTP Server APIs. For information about these settings, see [Http.sys registry settings for IIS](https://support.microsoft.com/help/820129/http-sys-registry-settings-for-windows). Most users don't need to change these settings.

## See also

- <xref:System.ServiceModel.WSDualHttpBinding>
- [How to: Configure a Port with an SSL Certificate](how-to-configure-a-port-with-an-ssl-certificate.md)
