---
title: Reverse Proxies with YARP
description: Architecture for Distributed Cloud-Native Apps with .NET Aspire & Containers | Reverse Proxies with YARP
ms.date: 01/13/2021
---
# Reverse Proxies with YARP

[!INCLUDE [download-alert](../includes/download-alert.md)]

YARP is a versatile toolkit for building high-performance reverse proxy servers in .NET. Originating from the need within Microsoft to unify various teams' efforts around reverse proxy development, YARP is designed for flexibility and customization, making it suitable for a wide range of deployment scenarios. YARP is now an open-source project, allowing developers to leverage its capabilities for their own projects.

**Key Features of YARP**

YARP has several key features that make it a powerful tool for building your reverse proxy servers:

- **Customizable Routing**: YARP can direct incoming requests to different backend services based on URL paths, headers, or other attributes.

- **Load Balancing**: It supports various strategies to distribute load evenly across service instances.

- **Seamless Integration with ASP.NET Core Middleware**: This allows for custom request/response handling.

- **Health Checks**: YARP ensures traffic is only sent to healthy service instances.

- **Session Affinity**: It can maintain user sessions with specific services when needed.

- **Cross-Platform Freedom**: YARP works seamlessly across Windows, Linux, and macOS.

- **Protocol Prowess**: It embraces gRPC, HTTP/2, and WebSockets for modern communication needs.

- **Performance**: YARP is built for speed and efficiency, ensuring low latency and high throughput.


**Getting Started with YARP**

1. **Installation**: Add YARP to your .NET project using NuGet

    ```shell
    dotnet add package Yarp.ReverseProxy
    ```

2. **Basic Configuration**: Configure YARP in your `Startup.cs` file

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddReverseProxy()
                .LoadFromConfig(Configuration.GetSection("ReverseProxy"));
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapReverseProxy();
        });
    }
    ```

3. **Configuration Files**: Add the YARP configuration to `appsettings.json` for basic configuration

    ```json
    "ReverseProxy": {
      "Routes": {
        "route1" : {
          "ClusterId": "cluster1",
          "Match": {
            "Path": "/customer/{**catch-all}"
          }
        }
      },
      "Clusters": {
        "cluster1": {
          "Destinations": {
            "destination1": {
              "Address": "https://example.com/api/customers/"
            }
          }
        }
      }
    }
    ```

4. **Programmatic Configuration**: Customize the configuration dynamically with C# code

    ```csharp
    builder.Services.AddReverseProxy()
    .LoadFromMemory(GetRoutes(), GetClusters());

    ...


    RouteConfig[] GetRoutes()
    {
        return
        [
            new RouteConfig()
            {
                RouteId = "route1",
                ClusterId = "cluster1",
                Match = new RouteMatch
                {
                    // Path or Hosts are required for each route. This catch-all pattern matches all request paths.
                    Path = "/customer/{**catch-all}"
                }
            }
        ];
    }
    
    ClusterConfig[] GetClusters()
    {

        return
        [
            new ClusterConfig()
            {
                ClusterId = "cluster1",
                SessionAffinity = new SessionAffinityConfig { Enabled = true, Policy = "Cookie", AffinityKeyName = ".Yarp.ReverseProxy.Affinity" },
                Destinations = { "destination1", new DestinationConfig() { Address = "https://example.com/api/customers" } 
                }
            }
        ];
    }
    ```

## Additional resources

- **Getting Started with YARP** \ <https://microsoft.github.io/reverse-proxy/articles/getting-started.html>


>[!div class="step-by-step"]
>[Previous](gateway-patterns.md)
>[Next](..TODO..)
