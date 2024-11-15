---
title: Configure a proxy server when using the Azure SDK for .NET 
description: Learn different ways to configure a proxy server for use with the Azure SDK for .NET client libraries.
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 11/15/2024
---

# Configure a proxy server when using the Azure SDK for .NET

If your organization requires the use of a proxy server to access Internet resources, some configuration is required to use the Azure SDK for .NET client libraries. Once configured, the proxy is applied to the `HttpClient` instance used for HTTP operations.

## Configure using code

To programmatically configure a proxy for use in underlying HTTP operations supporting the Azure SDK for .NET libraries, complete the following steps:

1. Create an <xref:System.Net.Http.HttpClientHandler> object whose `Proxy` property is set.
1. Create a service client options object whose <xref:Azure.Core.ClientOptions.Transport%2A> property is set to an `HttpClientTransport` object accepting the `HttpClientHandler` instance.
1. Pass the service client options object to the service client constructor.

Using the Azure Key Vault Secrets library as an example, you'd have the following code:

:::code language="csharp" source="snippets/configure-proxy/Program.cs":::

## Configure using environment variables

Depending on if your proxy server uses HTTP or HTTPS, you'll set either the environment variable `HTTP_PROXY` or `HTTPS_PROXY`, respectively. The proxy server URL takes the form `http[s]://[username:password@]<ip_address_or_hostname>:<port>/`, where the `username:password` combination is optional. To get the IP address or hostname, port, and credentials for your proxy server, consult your network administrator.

The following examples show how to set the appropriate environment variables in command shell (Windows) and bash (Linux/macOS) environments. Setting the appropriate environment variable causes the Azure SDK for .NET libraries to use the proxy server at runtime.

### [cmd](#tab/cmd)

```cmd
rem Non-authenticated HTTP server:
set HTTP_PROXY=http://10.10.1.10:1180

rem Authenticated HTTP server:
set HTTP_PROXY=http://username:password@10.10.1.10:1180

rem Non-authenticated HTTPS server:
set HTTPS_PROXY=http://10.10.1.10:1180

rem Authenticated HTTPS server:
set HTTPS_PROXY=http://username:password@10.10.1.10:1180
```

### [bash](#tab/bash)

```bash
# Non-authenticated HTTP server:
HTTP_PROXY=http://10.10.1.10:1180

# Authenticated HTTP server:
HTTP_PROXY=http://username:password@10.10.1.10:1180

# Non-authenticated HTTPS server:
HTTPS_PROXY=http://10.10.1.10:1180

# Authenticated HTTPS server:
HTTPS_PROXY=http://username:password@10.10.1.10:1180
```

---
