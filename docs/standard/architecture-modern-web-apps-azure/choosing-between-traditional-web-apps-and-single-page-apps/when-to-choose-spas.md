---
title: When to choose SPAs | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | When to choose SPAs
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# When to choose SPAs

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

>[!div class="step-by-step"]
[Previous] (when-to-choose-traditional-web-apps.md)
[Next] (decision-table-–-traditional-web-or-spa.md)
