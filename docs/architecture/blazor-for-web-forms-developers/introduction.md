---
title: An introduction to Blazor for ASP.NET Web Forms developers
description: An introduction to Blazor and writing full-stack web apps with .NET
author: danroth27
ms.author: daroth
no-loc: [Blazor, WebAssembly]
ms.date: 12/2/2021
---
# An introduction to Blazor for ASP.NET Web Forms developers

The ASP.NET Web Forms framework has been a staple of .NET web development since the .NET Framework first shipped in 2002. Back when the Web was still largely in its infancy, ASP.NET Web Forms made building web apps simple and productive by adopting many of the patterns that were used for desktop development. In ASP.NET Web Forms, web pages can be quickly composed from reusable UI controls. User interactions are handled naturally as events. There's a rich ecosystem of Web Forms UI controls provided by Microsoft and control vendors. The controls ease the efforts of connecting to data sources and displaying rich data visualizations. For the visually inclined, the Web Forms designer provides a simple drag-and-drop interface for managing controls.

Over the years, Microsoft has introduced new ASP.NET-based web frameworks to address web development trends. Some such web frameworks include ASP.NET MVC, ASP.NET Web Pages, and more recently ASP.NET Core. With each new framework, some have predicted the imminent decline of ASP.NET Web Forms and criticized it as an outdated, outmoded web framework. Despite these predictions, many .NET web developers continue to find ASP.NET Web Forms a simple, stable, and productive way to get their work done.

At the time of writing, almost half a million web developers use ASP.NET Web Forms every month. The ASP.NET Web Forms framework is stable to the point that docs, samples, books, and blog posts from a decade ago remain useful and relevant. For many .NET web developers, "ASP.NET" is still synonymous with "ASP.NET Web Forms" as it was when .NET was first conceived. Arguments on the pros and cons of ASP.NET Web Forms compared to the other new .NET web frameworks may rage on. ASP.NET Web Forms remains a popular framework for creating web apps.

Even so, innovations in software development aren't slowing. All software developers need to stay abreast of new technologies and trends. Two trends in particular are worth considering:

1. The shift to open-source and cross-platform
2. The shift of app logic to the client

## An open-source and cross-platform .NET

When .NET and ASP.NET Web Forms first shipped, the platform ecosystem looked much different than it does today. The desktop and server markets were dominated by Windows. Alternative platforms like macOS and Linux were still struggling to gain traction. ASP.NET Web Forms ships with the .NET Framework as a Windows-only component, which means ASP.NET Web Forms apps can only run on Windows Server machines. Many modern environments now use different kinds of platforms for servers and development machines such that cross-platform support for many users is an absolute requirement.

Most modern web frameworks are now also open-source, which has a number of benefits. Users aren't beheld to a single project owner to fix bugs and add features. Open-source projects provide improved transparency on development progress and upcoming changes. Open-source projects enjoy contributions from an entire community, and they foster a supportive open-source ecosystem. Despite the risks of open-source, many consumers and contributors have found suitable mitigations that enable them to enjoy the benefits of an open-source ecosystem in a safe and reasonable way. Examples of such mitigations include contributor license agreements, friendly licenses, pedigree scans, and supporting foundations.

The .NET community has embraced both cross-platform support and open-source. .NET Core is an open-source and cross-platform implementation of .NET that runs on a plethora of platforms, including Windows, macOS, and various Linux distributions. Xamarin provides Mono, an open-source version of .NET. Mono runs on Android, iOS, and a variety of other form factors, including watches and smart TVs. In 2020, Microsoft released [.NET 5](https://devblogs.microsoft.com/dotnet/announcing-net-5-0/) that reconciled .NET Core and Mono into "a single .NET runtime and framework that can be used everywhere and that has uniform runtime behaviors and developer experiences."

Will ASP.NET Web Forms benefit from the move to open-source and cross-platform support? The answer, unfortunately, is no, or at least not to the same extent as the rest of the platform. The .NET team [made it clear](https://devblogs.microsoft.com/dotnet/net-core-is-the-future-of-net/) that ASP.NET Web Forms won't be ported to .NET Core or .NET 6. Why is that?

There were efforts in the early days of .NET Core to port ASP.NET Web Forms. The number of breaking changes required were found to be too drastic. There's also an admission here that even for Microsoft, there's a limit to the number of web frameworks that it can support simultaneously. Perhaps someone in the community will take up the cause of creating an open-source and cross-platform version of ASP.NET Web Forms. The [source code for ASP.NET Web Forms](https://github.com/microsoft/referencesource) has been made available publicly in reference form. But for the time being, it seems ASP.NET Web Forms will remain Windows-only and without an open-source contribution model. If cross-platform support or open-source become important for your scenarios, then you'll need to look for something new.

Does this mean ASP.NET Web Forms is *dead* and should no longer be used? Of course not! As long as the .NET Framework ships as part of Windows, ASP.NET Web Forms will be a supported framework. For many Web Forms developers, the lack of cross-platform and open-source support is a non-issue. If you don't have a requirement for cross-platform support, open-source, or any of the other new features in .NET Core or .NET 6, then sticking with ASP.NET Web Forms on Windows is fine. ASP.NET Web Forms will continue to be a productive way to write web apps for many years to come.

But there's another trend worth considering, and that's the shift to the client.

## Client-side web development

All of the .NET-based web frameworks, including ASP.NET Web Forms, have historically had one thing in common: they're *server-rendered*. In server-rendered web apps, the browser makes a request to the server, which executes some code (.NET code in ASP.NET apps) to produce a response. That response is sent back to the browser to handle. In this model, the browser is used as a thin rendering engine. The hard work of producing the UI, running the business logic, and managing state occurs on the server.

However, browsers have become versatile platforms. They implement an ever-increasing number of open web standards that grant access to the capabilities of the user's machine. Why not take advantage of the compute power, storage, memory, and other resources of the client device? UI interactions in particular can benefit from a richer and more interactive feel when handled at least partially or completely client-side. Logic and data that should be handled on the server can still be handled server-side. Web API calls or even real-time protocols, like WebSockets, can be used. These benefits are available to web developers for free if they're willing to write JavaScript. Client-side UI frameworks, such as Angular, React, and Vue, simplify client-side web development and have grown in popularity. ASP.NET Web Forms developers can also benefit from leveraging the client, and even have some out-of-the-box support with integrated JavaScript frameworks like ASP.NET AJAX.

But bridging two different platforms and ecosystems (.NET and JavaScript) comes with a cost. Expertise is required in two parallel worlds with different languages, frameworks, and tools. Code and logic can't be easily shared between client and server, resulting in duplication and engineering overhead. It can also be difficult to keep up with the JavaScript ecosystem, which has a history of evolving at breakneck speed. Front-end framework and build tool preferences change quickly. The industry has observed the progression from Grunt to Gulp to Webpack, and so on. The same restless churn has occurred with front-end frameworks such as jQuery, Knockout, Angular, React, and Vue. But given JavaScript's browser monopoly, there was little choice in the matter. That is, until the web community got together and caused a *miracle* to happen!

## WebAssembly fulfills a need

In 2015, the major browser vendors joined forces in a W3C Community Group to create a new open web standard called WebAssembly. WebAssembly is a byte code for the Web. If you can compile your code to WebAssembly, it can then run on any browser on any platform at near native speed. Initial efforts focused on C/C++. The result was a dramatic demonstration of running native 3D graphics engines directly in the browser without plugins. WebAssembly has since been standardized and implemented by all major browsers.

Work on running .NET on WebAssembly was announced in late 2017 and released in 2020, including support in .NET 5 and beyond. The ability to run .NET code directly in the browser enables full-stack web development with .NET.

## Blazor: full-stack web development with .NET

On its own, the ability to run .NET code in a browser doesn't provide an end-to-end experience for creating client-side web apps. That's where Blazor comes in. Blazor is a client-side web UI framework based on C# instead of JavaScript. Blazor can run directly in the browser via WebAssembly. No browser plugins are required. Alternatively, Blazor apps can run server-side on .NET and handle all user interactions over a real-time connection with the browser.

Blazor has great tooling support in Visual Studio and Visual Studio Code. The framework also includes a full UI component model and has built-in facilities for:

- Forms and validation
- Dependency injection
- Client-side routing
- Layouts
- In-browser debugging
- JavaScript interop

Blazor has a lot in common with ASP.NET Web Forms. Both frameworks offer component-based, event-driven, stateful UI programming models. The main architectural difference is that ASP.NET Web Forms runs only on the server. Blazor can run on the client in the browser. But if you're coming from an ASP.NET Web Forms background, there's a lot in Blazor that will feel familiar. Blazor is a natural solution for ASP.NET Web Forms developers looking for a way to take advantage of client-side development and the open-source, cross-platform future of .NET.

This book provides an introduction to Blazor that is catered specifically to ASP.NET Web Forms developers. Each Blazor concept is presented in the context of analogous ASP.NET Web Forms features and practices. By the end of this book, you'll have an understanding of:

- How to build Blazor apps.
- How Blazor works.
- How Blazor relates to .NET.
- Reasonable strategies for migrating existing ASP.NET Web Forms apps to Blazor where appropriate.

## Get started with Blazor

Getting started with Blazor is easy. Go to <https://blazor.net> and follow the links to install the appropriate .NET SDK and Blazor project templates. You'll also find instructions for setting up the Blazor tooling in Visual Studio or Visual Studio Code.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](architecture-comparison.md)
