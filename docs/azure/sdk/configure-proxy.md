---
title: Configure a proxy when using the Azure SDK for .NET 
description: Learn different approaches for configuring a proxy for use with the Azure SDK for .NET client libraries.
ms.topic: conceptual
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 11/18/2024
---

# Configure a proxy when using the Azure SDK for .NET

If your organization requires the use of a proxy server to access Internet resources, some configuration is required to use the Azure SDK for .NET client libraries. Once configured, the proxy is applied to the underlying `HttpClient` instance used for HTTP operations.

The proxy can be configured via code or via an environment variable. The approach you choose depends on the desired behavior. Set the appropriate environment variable if you want the proxy to apply globally to all service clients created within the current process. Alternatively, configure the proxy via code to selectively apply the settings to service clients.

> [!IMPORTANT]
> The following instructions apply only to [libraries with a dependency on Azure.Core](protocol-convenience-methods.md#azure-sdk-client-library-dependency-patterns).

## Configure using code

To programmatically configure a proxy, complete the following steps:

1. Create an <xref:System.Net.Http.HttpClientHandler> object whose `Proxy` property is set.
1. Create a service client options object whose <xref:Azure.Core.ClientOptions.Transport%2A> property is set to an `HttpClientTransport` object accepting the `HttpClientHandler` instance.
1. Pass the service client options object to the service client constructor.

Using the Azure Key Vault Secrets library as an example, you'd have the following code:

:::code language="csharp" source="snippets/configure-proxy/Program.cs":::

## Configure using environment variables

The following table provides an inventory of environment variables that can be set to configure a proxy for use.

| Environment variable           | Purpose                                                                                                     |
|--------------------------------|-------------------------------------------------------------------------------------------------------------|
| `HTTP_PROXY` or `http_proxy`   | The proxy server used on HTTP requests.                                                                     |
| `HTTPS_PROXY` or `https_proxy` | The proxy server used on HTTPS requests.                                                                    |
| `ALL_PROXY` or `all_proxy`     | The proxy server used for both HTTP and HTTPS requests.                                                     |
| `NO_PROXY` or `no_proxy`       | A comma-delimited list of hostnames to exclude from proxying.                                               |
| `GATEWAY_INTERFACE`            | Indicator that the app is running in a Common Gateway Interface (CGI) environment. Example value: `CGI/1.1` |

For a deep understanding of how these environment variables are processed, see [the code](https://github.com/Azure/azure-sdk-for-net/blob/9aa3b3a44f81bc0be5a4fc86607e0150ba9815d5/sdk/core/Azure.Core/src/Pipeline/Internal/HttpEnvironmentProxy.cs#L31). Be aware of the following behaviors:

- Each environment variable in the preceding table, except `GATEWAY_INTERFACE`, can alternatively be defined as lowercase. The lowercase form takes precedence over the uppercase form.
- If both `http_proxy` and `GATEWAY_INTERFACE` are undefined, `HTTP_PROXY` is used.
- `ALL_PROXY` is considered only when either an HTTP or an HTTPS proxy is undefined.
- Protocol-specific environment variables take precedence over `ALL_PROXY`.

The proxy server URL takes the form `http[s]://[username:password@]<ip_address_or_hostname>:<port>/`, where the `username:password` combination is optional. To get the IP address or hostname, port, and credentials for your proxy server, consult your network administrator.

The following examples show how to set the appropriate environment variables in command shell (Windows) and bash (Linux/macOS) environments. Setting the appropriate environment variable causes the Azure SDK for .NET libraries to use the proxy server at runtime.

### [cmd](#tab/cmd)

```cmd
rem Non-authenticated HTTP server:
set HTTP_PROXY=http://10.10.1.10:1180

rem Authenticated HTTP server:
set HTTP_PROXY=http://username:password@10.10.1.10:1180

rem Non-authenticated HTTPS server:
set HTTPS_PROXY=https://10.10.1.10:1180

rem Authenticated HTTPS server:
set HTTPS_PROXY=https://username:password@10.10.1.10:1180
```

### [bash](#tab/bash)

```bash
# Non-authenticated HTTP server:
HTTP_PROXY=http://10.10.1.10:1180

# Authenticated HTTP server:
HTTP_PROXY=http://username:password@10.10.1.10:1180

# Non-authenticated HTTPS server:
HTTPS_PROXY=https://10.10.1.10:1180

# Authenticated HTTPS server:
HTTPS_PROXY=https://username:password@10.10.1.10:1180
```

---
