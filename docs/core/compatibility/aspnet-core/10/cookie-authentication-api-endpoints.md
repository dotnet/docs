---
title: "Cookie login redirects are disabled for known API endpoints"
description: "Learn about the breaking change in ASP.NET Core 10 where cookie authentication no longer redirects to login or access denied URIs for known API endpoints."
ms.date: 08/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/525
---

# Cookie login redirects are disabled for known API endpoints

By default, unauthenticated and unauthorized requests made to known API endpoints protected by cookie authentication now result in 401 and 403 responses rather than redirecting to a login or access denied URI.

Known API [endpoints](https://learn.microsoft.com/aspnet/core/fundamentals/routing) are identified using the new <xref:Microsoft.AspNetCore.Http.Metadata.IApiEndpointMetadata> interface, and metadata implementing the new interface has been added automatically to the following:

- `[ApiController]` endpoints
- Minimal API endpoints that read JSON request bodies or write JSON responses
- Endpoints using `TypedResults` return types
- SignalR endpoints

## Version introduced

.NET 10 Preview 7

## Previous behavior

The cookie authentication handler would redirect unauthenticated and unauthorized requests to a login or access denied URI by default for all requests other than [XMLHttpRequests (XHRs)](https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest).

## New behavior

Unauthenticated and unauthorized requests made to known API endpoints will result in 401 and 403 responses rather than redirecting to a login or access denied URI. XHRs continue to result in 401 and 403 responses regardless of the target endpoint.

## Type of breaking change

This change can affect [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was highly requested, and redirecting unauthenticated requests to a login page doesn't usually make sense for API endpoints which typically rely on 401 and 403 status codes rather than HTML redirects to communicate auth failures.

## Recommended action

If you want to always redirect to the login and access denied URIs for unauthenticated or unauthorized requests regardless of the target endpoint or whether the source of the request is an XHR, you can override the `RedirectToLogin` and `RedirectToAccessDenied` as follows:

```csharp
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
        };
    });
```

If you want to revert to the exact previous behavior which avoids redirecting for only XHRs, you can override the events with this slightly more complicated logic:

```csharp
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        bool IsXhr(HttpRequest request)
        {
            return string.Equals(request.Query[HeaderNames.XRequestedWith], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers.XRequestedWith, "XMLHttpRequest", StringComparison.Ordinal);
        }

        options.Events.OnRedirectToLogin = context =>
        {
            if (IsXhr(context.Request))
            {
                context.Response.Headers.Location = context.RedirectUri;
                context.Response.StatusCode = 401;
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }

            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            if (IsXhr(context.Request))
            {
                context.Response.Headers.Location = context.RedirectUri;
                context.Response.StatusCode = 403;
            }
            else
            {
                context.Response.Redirect(context.RedirectUri);
            }

            return Task.CompletedTask;
        };
    });
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Http.Metadata.IApiEndpointMetadata?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToLogin?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents.RedirectToAccessDenied?displayProperty=fullName>
