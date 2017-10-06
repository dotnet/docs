---
title: Client Communication | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Client Communication
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Client Communication

In addition to serving pages and responding to requests for data via web APIs, ASP&period;NET Core apps can communicate directly with connected clients. This outbound communication can use a variety of transport technologies, the most common being WebSockets. ASP&period;NET Core SignalR is a library that makes it simple to kind of real-time server-to-client communication functionality to your applications. SignalR supports a variety of transport technologies, including WebSockets, and abstracts away many of the implementation details from the developer.

ASP&period;NET Core SignalR is currently under development, and will be available in the next release of ASP&period;NET Core. However, other [open source WebSockets libraries](https://github.com/radu-matei/websocket-manager) are currently available.

Real-time client communication, whether using WebSockets directly or other techniques, are useful in a variety of application scenarios. Some examples include:

-   Live chat room applications

-   Monitoring applications

-   Job progress updates

-   Notifications

-   Interactive forms applications

When building client communication into your applications, there are typically two components:

-   Server-side connection manager (SignalR Hub, WebSocketManager WebSocketHandler)

-   Client-side library

Clients are not limited to browsers – mobile apps, console apps, and other native apps can also communicate using SignalR/WebSockets. The following simple program echoes all content sent to a chat application to the console, as part of a WebSocketManager sample application:

```cs
public class Program
{
    private static Connection _connection;
    public static void Main(string[] args)
    {
        StartConnectionAsync();
        _connection.On("receiveMessage", (arguments) =>;
        {
            Console.WriteLine(\$"{arguments\[0\]} said: {arguments\[1\]}");
        });
        Console.ReadLine();
        StopConnectionAsync();
    }
    
    public static async Task StartConnectionAsync()
    {
        _connection = new Connection();
        await _connection.StartConnectionAsync("ws://localhost:65110/chat");
    }
    
    public static async Task StopConnectionAsync()
    {
        await _connection.StopConnectionAsync();
    }
```

Consider ways in which your applications communicate directly with client applications, and consider whether real-time communication would improve your app's user experience.

> ### References – Client Communication
> - **ASP&period;NET Core SignalR**  
> <https://github.com/aspnet/SignalR>
> - **WebSocket Manager**  
> https://github.com/radu-matei/websocket-manager


>[!div class="step-by-step"]
[Previous] (security.md)
[Next] (domain-driven-design-–-should-you-apply-it.md)
