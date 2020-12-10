---
title: Configuring proxies when using the Azure SDK for .NET 
description: Use HTTP[S]_PROXY environment variables to define a proxy for the Azure SDK for .NET
ms.date: 12/10/2020
ms.topic: conceptual
ms.custom: devx-track-dotnet
---

# Configuring proxies when using the Azure SDK for .NET

Some organizations require the use of a proxy server to access internet resources.  If this is true of your organization, you will need to configure the Azure SDK for .NET to use your organization's proxy server.  This is done through the use of environment variables.

## Configuration using environment variables

Depending on if your proxy server uses HTTP or HTTPS, you will set either the environment variable HTTP_PROXY or HTTPS_PROXY respectively.  The proxy server URL has the form `http[s]://[username:password@]<ip_address_or_hostname>:<port>/` where the username:password combination is optional. To get the ip address or hostname, port and login information for your proxy server, consult your network administrator.

The following examples show how to do this in command shell (Windows) and bash (Linux/Mac) environments.  Setting the appropriate environment variable will then cause the Azure SDK for .NET to use the proxy server at runtime.

# [cmd](#tab/cmd)

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

# [bash](#tab/bash)

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
