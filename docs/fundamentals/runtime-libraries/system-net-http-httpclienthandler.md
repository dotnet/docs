---
title: System.Net.Http.HttpClientHandler class
description: Learn about the System.Net.Http.HttpClientHandler class.
ms.date: 12/31/2023
---
# System.Net.Http.HttpClientHandler class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Net.Http.HttpClientHandler> class and classes derived from it enable developers to configure a variety of options ranging from proxies to authentication.

## HttpClientHandler in .NET Core

Starting in .NET Core 2.1, the implementation of the `HttpClientHandler` class was changed to be based on the cross-platform HTTP protocol stack used by the <xref:System.Net.Http.SocketsHttpHandler?displayProperty=nameWithType> class. Prior to .NET Core 2.1, the `HttpClientHandler` class used older HTTP protocol stacks (<xref:System.Net.Http.WinHttpHandler> on Windows and `CurlHandler`, an internal class implemented on top of Linux's native `libcurl` component, on Linux).

On .NET Core 2.1 - 3.1 only, you can configure your app to use the older HTTP protocol stacks in one of the following three ways:

- Call the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method:

  ```csharp
  AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
  ```

  ```vb
  AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", False)
  ```

- Define the `System.Net.Http.UseSocketsHttpHandler` switch in the *.netcore.runtimeconfig.json* configuration file:

  ```json
  "runtimeOptions": {
    "configProperties": {
        "System.Net.Http.UseSocketsHttpHandler": false
    }
  }
  ```

- Define an environment variable named `DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER` and set it to either `false` or **0**.

These configuration options are not available starting with .NET 5.
