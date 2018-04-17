---
title: Choose between traditional web apps and single page apps
description: Architect modern web applications with ASP.NET Core and Microsoft Azure
author: ardalis
ms.author: wiwagn
ms.date: 10/06/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Choose Between Traditional Web Apps and Single Page Apps (SPAs)

> "Atwood's Law: Any application that can be written in JavaScript, will eventually be written in JavaScript."  
> _\- Jeff Atwood_

## Summary

There are two general approaches to building web applications today: traditional web applications that perform most of the application logic on the server, and single page applications (SPAs) that perform most of the user interface logic in a web browser, communicating with the web server primarily using web APIs. A hybrid approach is also possible, the simplest being host one or more rich SPA-like sub-applications within a larger traditional web application.

You should use traditional web applications when:

-   Your application's client-side requirements are simple or even read-only.

-   Your application needs to function in browsers without JavaScript support.

-   Your team is unfamiliar with JavaScript or TypeScript development techniques.

You should use a SPA when:

-   Your application must expose a rich user interface with many features.

-   Your team is familiar with JavaScript and/or TypeScript development.

-   Your application must already expose an API for other (internal or public) clients.

Additionally, SPA frameworks require greater architectural and security expertise. They experience greater churn due to frequent updates and new frameworks than traditional web applications. Configuring automated build and deployment processes and utilizing deployment options like containers are more difficult with SPA applications than traditional web apps.

Improvements in user experience made possible by SPA model must be weighed against these considerations.

## When to choose traditional web apps

The following is a more detailed explanation of the previously-stated reasons for picking traditional web applications.

**Your application has simple, possibly read-only, client-side requirements**

Many web applications are primarily consumed in a read-only fashion by the vast majority of their users. Read-only (or read-mostly) applications tend to be much simpler than those that maintain and manipulate a great deal of state. For example, a search engine might consist of a single entry point with a textbox and a second page for displaying search results. Anonymous users can easily make requests, and there is little need for client-side logic. Likewise, a blog or content management system's public-facing application usually consists mainly of content with little client-side behavior. Such applications are easily built as traditional server-based web applications which perform logic on the web server and render HTML to be displayed in the browser. The fact that each unique page of the site has its own URL that can be bookmarked and indexed by search engines (by default, without having to add this as a separate feature of the application) is also a clear benefit in such scenarios.

**Your application needs to function in browsers without JavaScript support**

Web applications that need to function in browsers with limited or no JavaScript support should be written using traditional web app workflows (or at least be able to fall back to such behavior). SPAs require client-side JavaScript in order to function; if it's not available, SPAs are not a good choice.

**Your team is unfamiliar with JavaScript or TypeScript development techniques**

If your team is unfamiliar with JavaScript or TypeScript, but is familiar with server-side web application development, then they will probably be able to deliver a traditional web app more quickly than a SPA. Unless learning to program SPAs is a goal, or the user experience afforded by a SPA is required, traditional web apps are a more productive choice for teams who are already familiar with building them.

## When to choose SPAs

The following is a more detailed explanation of when to choose a Single Page Applications style of development for your web app.

**Your application must expose a rich user interface with many features**

SPAs can support rich client-side functionality that doesn't require reloading the page as users take actions or navigate between areas of the app. SPAs can load more quickly, fetching data in the background, and individual user actions are more responsive since full page reloads are rare. SPAs can support incremental updates, saving partially completed forms or documents without the user having to click a button to submit a form. SPAs can support rich client-side behaviors, such as drag-and-drop, much more readily than traditional applications. SPAs can be designed to run in a disconnected mode, making updates to a client-side model that are eventually synchronized back to the server once a connection is re-established. You should choose a SPA style application if your app's requirements include rich functionality that goes beyond what typical HTML forms offer.

Note that frequently SPAs need to implement features that are built-in to traditional web apps, such as displaying a meaningful URL in the address bar reflecting the current operation (and allowing users to bookmark or deep link to this URL to return to it). SPAs also should allow users to use the browser's back and forward buttons with results that won't surprise them.

**Your team is familiar with JavaScript and/or TypeScript development**

Writing SPAs requires familiarity with JavaScript and/or TypeScript and client-side programming techniques and libraries. Your team should be competent in writing modern JavaScript using a SPA framework like Angular.

> ### References – SPA Frameworks
> - **AngularJS**  
> <https://angularjs.org/>
> - **Comparison of 4 Popular JavaScript Frameworks**  
> <https://www.developereconomics.com/feature-comparison-of-4-popular-js-mv-frameworks>

**Your application must already expose an API for other (internal or public) clients**

If you're already supporting a web API for use by other clients, it may require less effort to create a SPA implementation that leverages these APIs rather than reproducing the logic in server-side form. SPAs make extensive use of web APIs to query and update data as users interact with the application.

## Decision table – Traditional Web or SPA

The following decision table summarizes some of the basic factors to consider when choosing between a traditional web application and a SPA.

  | **Factor** | **Traditional Web App** | **Single Page Application** |
  |---|---|---|
  | Required Team Familiarity with JavaScript/TypeScript | **Minimal** | **Required** |
  | Support Browsers without Scripting | **Supported** | **Not Supported** |
  | Minimal Client-Side Application Behavior | **Well-Suited** | **Overkill** |
  | Rich, Complex User Interface Requirements | **Limited** | **Well-Suited** |

>[!div class="step-by-step"]
[Previous] (modern-web-applications-characteristics.md)
[Next](architectural-principles.md)
