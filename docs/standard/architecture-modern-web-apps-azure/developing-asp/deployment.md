---
title: Deployment | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Deployment
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Deployment

There are a few steps involved in the process of deploying your ASP&period;NET Core application, regardless of where it will be hosted. The first step is to publish the application, which can be done using the dotnet publish CLI command. This will compile the application and place all of the files needed to run the application into a designated folder. When you deploy from Visual Studio, this step is performed for you automatically. The publish folder contains .exe and .dll files for the application and its dependencies. A self-contained application will also include a version of the .NET runtime. ASP&period;NET Core applications will also include configuration files, static client assets, and MVC views.

ASP&period;NET Core applications are console applications that must be started when the server boots and restarted if the application (or server) crashes. A process manager can be used to automate this process. The most common process managers for ASP&period;NET Core are Nginx and Apache on Linux and IIS or Windows Service on Windows.

In addition to a process manager, ASP&period;NET Core applications hosted in the Kestrel web server must use a reverse proxy server. A reverse proxy server receives HTTP requests from the internet and forwards them to Kestrel after some preliminary handling. Reverse proxy servers provide a layer of security for the application, and are required for edge deployments (exposed to traffic from the Internet). Kestrel is relatively new and does not yet offer defenses against certain attacks. Kestrel also doesn't support hosting multiple applications on the same port, so techniques like host headers cannot be used with it to enable hosting multiple applications on the same port and IP address.

![Kestrel to Internet](./media/image5.png)

Figure 7-X ASP&period;NET hosted in Kestrel behind a reverse proxy server

Another scenario in which a reverse proxy can be helpful is to secure multiple applications using SSL/HTTPS. In this case, only the reverse proxy would need to have SSL configured. Communication between the reverse proxy server and Kestrel could take place over HTTP, as shown in Figure 7-X.

![](./media/image6.png)

Figure 7-X ASP&period;NET hosted behind an HTTPS-secured reverse proxy server

An increasingly popular approach is to host your ASP&period;NET Core application in a Docker container, which then can be hosted locally or deployed to Azure for cloud-based hosting. The Docker container could contain your application code, running on Kestrel, and would be deployed behind a reverse proxy server, as shown above.

If you're hosting your application on Azure, you can use Microsoft Azure Application Gateway as a dedicated virtual appliance to provide several services. In addition to acting as a reverse proxy for individual applications, Application Gateway can also offer the following features:

-   HTTP load balancing

-   SSL offload (SSL only to Internet)

-   End to End SSL

-   Multi-site routing (consolidate up to 20 sites on a single Application Gateway)

-   Web application firewall

-   Websocket support

-   Advanced diagnostics

*Learn more about Azure deployment options in Chapter 10.*

> ### References – Deployment
> - **Hosting and Deployment Overview**  
> <https://docs.microsoft.com/en-us/aspnet/core/publishing/>
> - **When to use Kestrel with a reverse proxy**  
> <https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy>
> - **Host ASP&period;NET Core apps in Docker**  
> <https://docs.microsoft.com/en-us/aspnet/core/publishing/docker>
> - **Introducing Azure Application Gateway**  
> <https://docs.microsoft.com/en-us/azure/application-gateway/application-gateway-introduction>

>[!div class="step-by-step"]
[Previous] (.md)
[Next] (../working-with-data-in-asp/index.md)
