---
title: Orleans sample projects
description: Explore the various sample projects written with .NET Orleans.
ms.date: 02/04/2022
---

# Orleans sample projects

## [Hello, World!](https://github.com/dotnet/orleans/raw/main/samples/HelloWorld/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/HelloWorld/code.png?sanitize=true" />
</p>
-->

A *Hello, World!* application that demonstrates how to create and use your first grains.

### Demonstrates

* How to get started with Orleans
* How to define and implement grain interface
* How to get a reference to a grain and call a grain

## [Adventure](https://github.com/dotnet/orleans/raw/main/samples/Adventure/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Adventure/assets/BoxArt.jpg?sanitize=true" />
</p>
-->

Before there were graphical user interfaces, before the era of game consoles and massive-multiplayer games, there were VT100 terminals and there was [Colossal Cave Adventure](https://en.wikipedia.org/wiki/Colossal_Cave_Adventure), [Zork](https://en.wikipedia.org/wiki/Zork), and [Microsoft Adventure](https://en.wikipedia.org/wiki/Microsoft_Adventure).
Possibly lame by today's standards, back then it was a magical world of monsters, chirping birds, and things you could pick up.
It's the inspiration for this sample.

### Demonstrates

* How to structure an application (in this case, a game) using grains
* How to connect an external client to an Orleans cluster (`ClientBuilder`)

## [Chirper](https://github.com/dotnet/orleans/raw/main/samples/Chirper/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Chirper/screenshot.png?sanitize=true" />
</p>
-->

A social network pub/sub system, with short text messages being sent between users.
Publishers send out short *"Chirp"* messages (not to be confused with *"Tweets"*, for a variety of legal reasons) to any other users that are following them.

### Demonstrates

* How to build a simplified social media / social network application using Orleans
* How to store state within a grain using grain persistence (`IPersistentState<T>`)
* Grains that implement multiple grain interfaces
* Reentrant grains, which allow for multiple grain calls to be executed concurrently, in a single-threaded, interleaving fashion
* Using a *grain observer* (`IGrainObserver`) to receive push notifications from grains

## [GPS Tracker](https://github.com/dotnet/orleans/raw/main/samples/GPSTracker/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/GPSTracker/screenshot.jpeg?sanitize=true" />
</p>
-->

A service for tracking GPS-equipped [IoT](https://en.wikipedia.org/wiki/Internet_of_Things) devices on a map.
Device locations are updated in near-real-time using SignalR and hence this sample demonstrates one approach to integrating Orleans with SignalR. The device updates originate from a *device gateway*, which is implemented using a separate process that connects to the main service and simulates several devices moving in a pseudorandom fashion around an area of San Francisco.

### Demonstrates

* How to use Orleans to build an [Internet of Things](https://en.wikipedia.org/wiki/Internet_of_Things) application
* How Orleans can be co-hosted and integrated with [ASP.NET Core SignalR](/aspnet/core/signalr/introduction)
* How to broadcast real-time updates from a grain to a set of clients using Orleans and SignalR

## [HanBaoBao](https://github.com/ReubenBond/hanbaobao-web)

<!-- TODO
<p align="center">
    <img src="https://github.com/ReubenBond/hanbaobao-web/blob/main/assets/demo-1.png?raw=true" />
</p>
-->

An English-Mandarin dictionary Web application demonstrating deployment to Kubernetes, fan-out grain calls, and request throttling.

### Demonstrates

* How to build a realistic application using Orleans
* How to deploy an Orleans-based application to Kubernetes
* How to integrate Orleans with ASP.NET Core and a [*Single-page Application*](https://en.wikipedia.org/wiki/Single-page_application) JavaScript framework ([Vue.js](https://vuejs.org/))
* How to implement leaky-bucket request throttling
* How to load and query data from a database
* How to cache results lazily and temporarily
* How to fan-out requests to many grains and collect the results

## [Presence Service](https://github.com/dotnet/orleans/raw/main/samples/Presence/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Presence/screenshot.png?sanitize=true" />
</p>
-->

A gaming presence service, similar to one of the Orleans-based services built for [Halo](https://www.xbox.com/games/halo).
A presence service tracks players and game sessions in near-real-time.

### Demonstrates

* A simplified version of a real-world use of Orleans
* Using a *grain observer* (`IGrainObserver`) to receive push notifications from grains

## [Tic Tac Toe](https://github.com/dotnet/orleans/raw/main/samples/TicTacToe/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/TicTacToe/logo.png?sanitize=true"/>
</p>
-->

A Web-based [Tic-tac-toe](https://en.wikipedia.org/wiki/Tic-tac-toe) game using ASP.NET MVC, JavaScript, and Orleans.

### Demonstrates

* How to build an online game using Orleans
* How to build a basic game lobby system
* How to access Orleans grains from an ASP.NET Core MVC application

## [Voting](https://github.com/dotnet/orleans/raw/main/samples/Voting/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Voting/screenshot.png?sanitize=true"/>
</p>
-->

A Web application for voting on a set of choices. This sample demonstrates deployment to Kubernetes.
The application uses [.NET generic host](/dotnet/core/extensions/generic-host) to co-host [ASP.NET Core](/aspnet/core) and Orleans as well as the [Orleans Dashboard](https://github.com/OrleansContrib/OrleansDashboard) together in the same process.

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Voting/dashboard.png?sanitize=true"/>
</p>
-->

### Demonstrates

* How to deploy an Orleans-based application to Kubernetes
* How to configure the [Orleans Dashboard](https://github.com/OrleansContrib/OrleansDashboard)

## [Chat Room](https://github.com/dotnet/orleans/raw/main/samples/ChatRoom/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/ChatRoom/screenshot.png?sanitize=true" />
</p>
-->

A terminal-based chat application built using [Orleans Streams](https://dotnet.github.io/orleans/docs/streaming/index.html).

### Demonstrates

* How to build a chat application using Orleans
* How to use [Orleans Streams](https://dotnet.github.io/orleans/docs/streaming/index.html)

## [Bank Account](https://github.com/dotnet/orleans/raw/main/samples/BankAccount/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/BankAccount/assets/BankClient.png?sanitize=true"/>
</p>
-->

Simulates bank accounts, using ACID transactions to transfer random amounts between a set of accounts.

### Demonstrates

* How to use Orleans Transactions to safely perform operations involving multiple stateful grains with ACID guarantees and serializable isolation.

## [Blazor Server](https://github.com/dotnet/orleans/raw/main/samples/Blazor/BlazorServer/#readme) and [Blazor WebAssembly](https://github.com/dotnet/orleans/raw/main/samples/Blazor/BlazorWasm/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Blazor/BlazorServer/screenshot.jpeg?sanitize=true"/>
</p>
-->

These two Blazor samples are based on the [Blazor introductory tutorials](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro), adapted for use with Orleans.
The [Blazor WebAssembly](https://github.com/dotnet/orleans/raw/main/samples/Blazor/BlazorWasm/#readme) sample uses the [Blazor WebAssembly hosting model](/aspnet/core/blazor/hosting-models#blazor-webassembly).
The [Blazor Server](https://github.com/dotnet/orleans/raw/main/samples/Blazor/BlazorServer/#readme) sample uses the [Blazor Server hosting model](/aspnet/core/blazor/hosting-models#blazor-server).
They include an interactive counter, a TODO list, and a Weather service.

### Demonstrates

* How to integrate ASP.NET Core Blazor Server with Orleans
* How to integrate ASP.NET Core Blazor WebAssembly (WASM) with Orleans

## [Stocks](https://github.com/dotnet/orleans/raw/main/samples/Stocks/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/Stocks/screenshot.png?sanitize=true" />
</p>
-->

A stock price application that fetches prices from a remote service using an HTTP call and caches prices temporarily in a grain. A [BackgroundService](../../core/extensions/workers.md) periodically polls for updated stock prices from various `StockGrain` grains which correspond to a set of stock symbols.

### Demonstrates

* How to use Orleans from within a [BackgroundService](../../core/extensions/workers.md).
* How to use timers within a grain
* How to make external service calls using .NET's `HttpClient` and cache the results within a grain.

## [Transport Layer Security](https://github.com/dotnet/orleans/raw/main/samples/TransportLayerSecurity/#readme)

<!-- TODO
<p align="center">
    <img src="https://raw.githubusercontent.com/dotnet/orleans/main/samples/TransportLayerSecurity/screenshot.png?sanitize=true" />
</p>
-->

A *Hello, World!* application configured to use mutual [*Transport Layer Security*](https://en.wikipedia.org/wiki/Transport_Layer_Security) to secure network communication between every server.

### Demonstrates

* How to configure mutual-TLS (mTLS) authentication for Orleans

## [Visual Basic Hello World](https://github.com/dotnet/orleans/raw/main/samples/VBHelloWorld/#readme)

A *Hello, World!* application using Visual Basic.

### Demonstrates

* How to develop Orleans-based applications using Visual Basic

## [F# Hello World](https://github.com/dotnet/orleans/raw/main/samples/FSharpHelloWorld/#readme)

A *Hello, World!* application using F#.

### Demonstrates

* How to develop Orleans-based applications using F#

## [Streaming: Pub/Sub Streams over Azure Event Hubs](https://github.com/dotnet/orleans/raw/main/samples/Streaming/Simple/#readme)

An application using Orleans Streams with [Azure Event Hubs](https://azure.microsoft.com/services/event-hubs/) as the provider and implicit subscribers.

### Demonstrates

* How to use [Orleans Streams](https://dotnet.github.io/orleans/docs/streaming/index.html)
* How to use the `[ImplicitStreamSubscription(namespace)]` attribute to implicitly subscribe a grain to the stream with the corresponding id
* How to configure Orleans Streams for use with [Azure Event Hubs](https://azure.microsoft.com/services/event-hubs/)

## [Streaming: Custom Data Adapter](https://github.com/dotnet/orleans/raw/main/samples/Streaming/CustomDataAdapter/#readme)

An application using Orleans Streams with a non-Orleans publisher pushing to a stream which a grain consumes via a *custom data adapter* which tells Orleans how to interpret stream messages.

### Demonstrates

* How to use [Orleans Streams](https://dotnet.github.io/orleans/docs/streaming/index.html)
* How to use the `[ImplicitStreamSubscription(namespace)]` attribute to implicitly subscribe a grain to the stream with the corresponding id
* How to configure Orleans Streams for use with [Azure Event Hubs](https://azure.microsoft.com/services/event-hubs/)
* How to consume stream messages published by non-Orleans publishers by providing a custom `EventHubDataAdapter` implementation (a custom data adapter)
