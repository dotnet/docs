---
title: Choose between traditional web apps and single page apps
description: Learn how to choose between traditional web apps and single page applications (SPAs) when building web applications.
author: ardalis
ms.author: wiwagn
no-loc: [Blazor, WebAssembly]
ms.date: 12/12/2021
---

# Choose Between Traditional Web Apps and Single Page Apps (SPAs)

> "Atwood's Law: Any application that can be written in JavaScript, will eventually be written in JavaScript."  
> _\- Jeff Atwood_

There are two general approaches to building web applications today: traditional web applications that perform most of the application logic on the server, and single-page applications (SPAs) that perform most of the user interface logic in a web browser, communicating with the web server primarily using web APIs. A hybrid approach is also possible, the simplest being host one or more rich SPA-like subapplications within a larger traditional web application.

Use traditional web applications when:

- Your application's client-side requirements are simple or even read-only.

- Your application needs to function in browsers without JavaScript support.

Use a SPA when:

- Your application must expose a rich user interface with many features.

- Your team is familiar with JavaScript, TypeScript, or Blazor WebAssembly development.

- Your application must already expose an API for other (internal or public) clients.

Additionally, SPA frameworks require greater architectural and security expertise. They experience greater churn due to frequent updates and new client frameworks than traditional web applications. Configuring automated build and deployment processes and utilizing deployment options like containers may be more difficult with SPA applications than traditional web apps.

Improvements in user experience made possible by the SPA approach must be weighed against these considerations.

## Blazor

ASP.NET Core includes a model for building rich, interactive, and composable user interfaces called Blazor. Blazor server-side allows developers to build UI with C# and Razor on the server and for the UI to be interactively connected to the browser in real-time using a persistent SignalR connection. Blazor WebAssembly introduces another option for Blazor apps, allowing them to run in the browser using WebAssembly. Because it's real .NET code running on WebAssembly, you can reuse code and libraries from server-side parts of your application.

Blazor provides a new, third option to consider when evaluating whether to build a purely server-rendered web application or a SPA. You can build rich, SPA-like client-side behaviors using Blazor, without the need for significant JavaScript development. Blazor applications can call APIs to request data or perform server-side operations. They can interoperate with JavaScript where necessary to take advantage of JavaScript libraries and frameworks.

Consider building your web application with Blazor when:

- Your application must expose a rich user interface

- Your team is more comfortable with .NET development than JavaScript or TypeScript development

If you have an existing web forms application you're considering migrating to .NET Core or the latest .NET, you may wish to review the free e-book, [Blazor for Web Forms Developers](../blazor-for-web-forms-developers/index.md) to see whether it makes sense to consider migrating it to Blazor.

For more information about Blazor, see [Get started with Blazor](https://blazor.net/docs/get-started.html).

## When to choose traditional web apps

The following section is a more detailed explanation of the previously stated reasons for picking traditional web applications.

**Your application has simple, possibly read-only, client-side requirements**

Many web applications are primarily consumed in a read-only fashion by the vast majority of their users. Read-only (or read-mostly) applications tend to be much simpler than those applications that maintain and manipulate a great deal of state. For example, a search engine might consist of a single entry point with a textbox and a second page for displaying search results. Anonymous users can easily make requests, and there is little need for client-side logic. Likewise, a blog or content management system's public-facing application usually consists mainly of content with little client-side behavior. Such applications are easily built as traditional server-based web applications, which perform logic on the web server and render HTML to be displayed in the browser. The fact that each unique page of the site has its own URL that can be bookmarked and indexed by search engines (by default, without having to add this functionality as a separate feature of the application) is also a clear benefit in such scenarios.

**Your application needs to function in browsers without JavaScript support**

Web applications that need to function in browsers with limited or no JavaScript support should be written using traditional web app workflows (or at least be able to fall back to such behavior). SPAs require client-side JavaScript in order to function; if it's not available, SPAs are not a good choice.

**Your team is unfamiliar with JavaScript or TypeScript development techniques**

If your team is unfamiliar with JavaScript or TypeScript, but is familiar with server-side web application development, then they will probably be able to deliver a traditional web app more quickly than a SPA. Unless learning to program SPAs is a goal, or the user experience afforded by a SPA is required, traditional web apps are a more productive choice for teams who are already familiar with building them.

## When to choose SPAs

The following section is a more detailed explanation of when to choose a Single Page Applications style of development for your web app.

**Your application must expose a rich user interface with many features**

SPAs can support rich client-side functionality that doesn't require reloading the page as users take actions or navigate between areas of the app. SPAs can load more quickly, fetching data in the background, and individual user actions are more responsive since full page reloads are rare. SPAs can support incremental updates, saving partially completed forms or documents without the user having to click a button to submit a form. SPAs can support rich client-side behaviors, such as drag-and-drop, much more readily than traditional applications. SPAs can be designed to run in a disconnected mode, making updates to a client-side model that are eventually synchronized back to the server once a connection is re-established. Choose a SPA-style application if your app's requirements include rich functionality that goes beyond what typical HTML forms offer.

Frequently, SPAs need to implement features that are built into traditional web apps, such as displaying a meaningful URL in the address bar reflecting the current operation (and allowing users to bookmark or deep link to this URL to return to it). SPAs also should allow users to use the browser's back and forward buttons with results that won't surprise them.

**Your team is familiar with JavaScript and/or TypeScript development**

Writing SPAs requires familiarity with JavaScript and/or TypeScript and client-side programming techniques and libraries. Your team should be competent in writing modern JavaScript using a SPA framework like Angular.

> ### References – SPA Frameworks
>
> - **Angular**: <https://angular.io>
> - **React**: <https://reactjs.org/>
> - **Vue.js**: <https://vuejs.org/>

**Your application must already expose an API for other (internal or public) clients**

If you're already supporting a web API for use by other clients, it may require less effort to create a SPA implementation that leverages these APIs rather than reproducing the logic in server-side form. SPAs make extensive use of web APIs to query and update data as users interact with the application.

## When to choose Blazor

The following section is a more detailed explanation of when to choose Blazor for your web app.

**Your application must expose a rich user interface**

Like JavaScript-based SPAs, Blazor applications can support rich client behavior without page reloads. These applications are more responsive to users, fetching only the data (or HTML) required to respond to a given user interaction. Designed properly, server-side Blazor apps can be configured to run as client-side Blazor apps with minimal changes once this feature is supported.

**Your team is more comfortable with .NET development than JavaScript or TypeScript development**

Many developers are more productive with .NET and Razor than with client-side languages like JavaScript or TypeScript. Since the server-side of the application is already being developed with .NET, using Blazor ensures every .NET developer on the team can understand and potentially build the behavior of the front end of the application.

## Decision table

The following decision table summarizes some of the basic factors to consider when choosing between a traditional web application, a SPA, or a Blazor app.

| **Factor**                                           | **Traditional Web App** | **Single Page Application** | **Blazor App**  |
| ---------------------------------------------------- | ----------------------- | --------------------------- | --------------- |
| Required Team Familiarity with JavaScript/TypeScript | **Minimal**             | **Required**                | **Minimal**     |
| Support Browsers without Scripting                   | **Supported**           | **Not Supported**           | **Supported**   |
| Minimal Client-Side Application Behavior             | **Well-Suited**         | **Overkill**                | **Viable**      |
| Rich, Complex User Interface Requirements            | **Limited**             | **Well-Suited**             | **Well-Suited** |

>[!div class="step-by-step"]
>[Previous](modern-web-applications-characteristics.md)
>[Next](architectural-principles.md)
