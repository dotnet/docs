---
title: State management
description: Learn different approaches for managing state in ASP.NET Web Forms and Blazor.
author: csharpfritz
ms.author: jefritz
ms.date: 12/2/2021
---
# State management

State management is a key concept of Web Forms applications, facilitated through ViewState, Session State, Application State, and Postback features. These stateful features of the framework helped to hide the state management required for an application and allow application developers to focus on delivering their functionality. With ASP.NET Core and Blazor, some of these features have been relocated and some have been removed altogether. This chapter reviews how to maintain state and deliver the same functionality with the new features in Blazor.

## Request state management with ViewState

When discussing state management in Web Forms application, many developers will immediately think of ViewState. In Web Forms, ViewState manages the state of the content between HTTP requests by sending a large encoded block of text back and forth to the browser. The ViewState field could be overwhelmed with content from a page containing many elements, potentially expanding to several megabytes in size.

With Blazor Server, the app maintains an ongoing connection with the server. The app's state, called a *circuit*, is held in server memory while the connection is considered active. State will only be disposed when the user navigates away from the app or a particular page in the app. All members of the active components are available between interactions with the server.

There are several advantages of this feature:

- Component state is readily available and not rebuilt between interactions.
- State isn't transmitted to the browser.

However, there are some disadvantages to in-memory component state persistence to be aware of:

- If the server restarts between request, state is lost.
- Your application web server load-balancing solution must include sticky sessions to ensure that all requests from the same browser return to the same server. If a request goes to a different server, state will be lost.
- Persistence of component state on the server can lead to memory pressure on the web server.

For the preceding reasons, don't rely on just the state of the component to reside in-memory on the server. Your application should also include some backing data store for data between requests. Some simple examples of this strategy:

- In a shopping cart application, persist the content of new items added to the cart in a database record. If the state on the server is lost, you can reconstitute it from the database records.
- In a multi-part web form, your users will expect your application to remember values between each request. Write the data between each of your user's posts to a data store so that they can be fetched and assembled into the final form response structure when the multi-part form is completed.

For additional details on managing state in Blazor apps, see [ASP.NET Core Blazor state management](/aspnet/core/blazor/state-management).

## Maintain state with Session

Web Forms developers could maintain information about the currently acting user with the <xref:Microsoft.AspNetCore.Http.ISession?displayProperty=nameWithType> dictionary object. It's easy enough to add an object with a string key to the `Session`, and that object would be available at a later time during the user's interactions with the application. In an attempt to eliminate managing interacting with HTTP, the `Session` object made it easy to maintain state.

The signature of the .NET Framework `Session` object isn't the same as the ASP.NET Core `Session` object. Consider [the documentation for the new ASP.NET Core Session](/dotnet/api/microsoft.aspnetcore.http.isession) before deciding to migrate and use the new session state feature.

Session is available in ASP.NET Core and Blazor Server, but is discouraged from use in favor of storing data in a data repository appropriately. Session state is also not functional if visitors decline the use HTTP cookies in your application due to privacy concerns.

Configuration for ASP.NET Core and Session state is available in the [Session and state management in ASP.NET Core article](/aspnet/core/fundamentals/app-state#session-state).

## Application state

The `Application` object in the Web Forms framework provides a massive, cross-request repository for interacting with application-scope configuration and state. Application state was an ideal place to store various application configuration properties that would be referenced by all requests, regardless of the user making the request. The problem with the `Application` object was that data didn't persist across multiple servers. The state of the application object was lost between restarts.

As with `Session`, it's recommended that data move to a persistent backing store that could be accessed by multiple server instances. If there is volatile data that you would like to be able to access across requests and users, you could easily store it in a singleton service that can be injected into components that require this information or interaction.

The construction of an object to maintain application state and its consumption could resemble the following implementation:

```csharp
public class MyApplicationState
{
    public int VisitorCounter { get; private set; } = 0;

    public void IncrementCounter() => VisitorCounter += 1;
}
```

```csharp
app.AddSingleton<MyApplicationState>();
```

```razor
@inject MyApplicationState AppState

<label>Total Visitors: @AppState.VisitorCounter</label>
```

The `MyApplicationState` object is created only once on the server, and the value `VisitorCounter` is fetched and output in the component's label. The `VisitorCounter` value should be persisted and retrieved from a backing data store for durability and scalability.

## In the browser

Application data can also be stored client-side on the user's device so that is available later. There are two browser features that allow for persistence of data in different scopes of the user's browser:

- `localStorage` - scoped to the user's entire browser. If the page is reloaded, the browser is closed and reopened, or another tab is opened with the same URL then the same `localStorage` is provided by the browser
- `sessionStorage` - scoped to the user's current browser tab. If the tab is reloaded, the state persists. However, if the user opens another tab to your application or closes and reopens the browser the state is lost.

You can write some custom JavaScript code to interact with these features, or there are a number of NuGet packages that you can use that provide this functionality. One such package is [Microsoft.AspNetCore.ProtectedBrowserStorage](https://www.nuget.org/packages/Microsoft.AspNetCore.ProtectedBrowserStorage).

For instructions on utilizing this package to interact with `localStorage` and `sessionStorage`, see the [Blazor State Management](/aspnet/core/blazor/state-management#protected-browser-storage-experimental-package) article.

>[!div class="step-by-step"]
>[Previous](pages-routing-layouts.md)
>[Next](forms-validation.md)
