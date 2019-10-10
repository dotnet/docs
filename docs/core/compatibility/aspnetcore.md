---
title: ASP.NET Core breaking changes - .NET Core
description: Lists the breaking changes in ASP.NET Core.
ms.date: "10/09/2019"
author: "scottaddie"
ms.author: "scaddie"
---
# ASP.NET Core breaking changes

> [!IMPORTANT]
> This article is under construction. This is not a complete list of ASP.NET Core breaking changes. For more information on ASP.NET Core breaking changes, you can examine individual [breaking changes issues](https://github.com/dotnet/docs/issues?q=is%3Aissue+is%3Aopen+label%3Abreaking-change) in the dotnet/docs repository on GitHub.

The following is a list of ASP.NET Core breaking changes by ASP.NET Core version. ASP.NET Core provides the web app development features used by .NET Core.

## ASP.NET Core 3.0

[!INCLUDE[obsolete Antiforgery, CORS, Diagnostics, MVC, and Routing APIs removed](~/includes/core-changes/aspnetcore/3.0/obsolete-apis-removed.md)]

***

[!INCLUDE[AddAuthorization overload assembly change](~/includes/core-changes/aspnetcore/3.0/add-authz-assembly-change.md)]

***

[!INCLUDE[Microsoft.AspNetCore.All shared framework removed](~/includes/core-changes/aspnetcore/3.0/all-shared-framework-removed.md)]

***

[!INCLUDE[MVC precompilation tool deprecated](~/includes/core-changes/aspnetcore/3.0/mvc-precompilation-tool-deprecated.md)]

***

[!INCLUDE[Web API compatibility shim removed](~/includes/core-changes/aspnetcore/3.0/webapi-compat-shim-removed.md)]

***

[!INCLUDE[.NET Framework not supported](~/includes/core-changes/aspnetcore/3.0/netfx-tfm-support.md)]

***

[!INCLUDE[Assembly removal from Microsoft.AspNetCore.App](~/includes/core-changes/aspnetcore/3.0/app-shared-framework-assemblies.md)]

***

[!INCLUDE[MVC types changed to internal](~/includes/core-changes/aspnetcore/3.0/mvc-pubternal-to-internal.md)]

***

[!INCLUDE[empty Kestrel HTTPS assembly removed](~/includes/core-changes/aspnetcore/3.0/empty-kestrel-assembly-removed.md)]

***

[!INCLUDE[obsolete session APIs removed](~/includes/core-changes/aspnetcore/3.0/obsolete-session-apis-removed.md)]

***

[!INCLUDE[Google+ authentication deprecation](~/includes/core-changes/aspnetcore/3.0/google-plus-authn-changes.md)]

***

[!INCLUDE[ObjectPoolProvider removed from WebHostBuilder dependencies](~/includes/core-changes/aspnetcore/3.0/objectpoolprovider-webhostbuilder-dependencies.md)]

***

[!INCLUDE[removed HttpContext.Authentication property](~/includes/core-changes/aspnetcore/3.0/httpcontext-authn-property-removed.md)]

***

[!INCLUDE[removed DefaultHttpContext extensibility](~/includes/core-changes/aspnetcore/3.0/defaulthttpcontext-extensibility-removed.md)]

***

[!INCLUDE[ANCM version 1 removed from hosting bundle](~/includes/core-changes/aspnetcore/3.0/ancmv1-hosting-bundle-removal.md)]

***

[!INCLUDE[obsolete CompactOnMemoryPressure property removed](~/includes/core-changes/aspnetcore/3.0/memorycacheoptions-property-removed.md)]

***

[!INCLUDE[Json.NET types replaced in Authentication APIs](~/includes/core-changes/aspnetcore/3.0/authn-apis-json-types.md)]

***

[!INCLUDE[synchronous IO disabled by default](~/includes/core-changes/aspnetcore/3.0/synchronous-io-disabled.md)]

***

[!INCLUDE[Razor file runtime compilation moved to a package](~/includes/core-changes/aspnetcore/3.0/razor-runtime-compilation-package.md)]

***

[!INCLUDE[IHostingEnvironment and IApplicationLifetime types replaced](~/includes/core-changes/aspnetcore/3.0/ihostingenv-iapplifetime-types-replaced.md)]

***

[!INCLUDE[localization APIs marked obsolete](~/includes/core-changes/aspnetcore/3.0/localization-apis-marked-obsolete.md)]

***

[!INCLUDE[controller action Async suffix removed](~/includes/core-changes/aspnetcore/3.0/action-async-suffix-trimmed.md)]

***

[!INCLUDE[generic host restriction on Startup constructor injection](~/includes/core-changes/aspnetcore/3.0/generic-host-startup-ctor-restriction.md)]

***

[!INCLUDE[ResponseCaching types changed to internal](~/includes/core-changes/aspnetcore/3.0/responsecaching-pubternal-to-internal.md)]

***

[!INCLUDE[DataProtection.AzureStorage uses new Azure Storage APIs](~/includes/core-changes/aspnetcore/3.0/dpazstorage-using-azstorage-apis.md)]

***

[!INCLUDE[HeaderNames fields changed to static readonly](~/includes/core-changes/aspnetcore/3.0/headernames-constants-staticreadonly.md)]

***

[!INCLUDE[HeaderNames fields changed to static readonly](~/includes/core-changes/aspnetcore/3.0/identityui-bootstrap-version.md)]

***

[!INCLUDE[Kestrel request trailer headers moved to new collection](~/includes/core-changes/aspnetcore/3.0/kestrel-request-trailer-headers.md)]

***

[!INCLUDE[SignInAsync throws exception for unauthenticated identity](~/includes/core-changes/aspnetcore/3.0/signinasync-throws-exception.md)]

***

[!INCLUDE[Kestrel transport abstraction layer changes](~/includes/core-changes/aspnetcore/3.0/kestrel-transport-abstractions.md)]

***

[!INCLUDE[OAuthHandler ExchangeCodeAsync signature change](~/includes/core-changes/aspnetcore/3.0/exchangecodeasync-signature-change.md)]

***

[!INCLUDE[DebugLogger class made internal](~/includes/core-changes/aspnetcore/3.0/debuglogger-to-internal.md)]

***

[!INCLUDE[obsolete SignalR APIs](~/includes/core-changes/aspnetcore/3.0/obsolete-signalr-apis.md)]

***

[!INCLUDE[SignalR HandshakeProtocol.SuccessHandshakeData replaced](~/includes/core-changes/aspnetcore/3.0/signalr-successhandshakedata-replaced.md)]

***

[!INCLUDE[SignalR HubConnection methods removed](~/includes/core-changes/aspnetcore/3.0/signalr-hubconnection-methods-removed.md)]

***

[!INCLUDE[SignalR HubConnectionContext constructors changed](~/includes/core-changes/aspnetcore/3.0/signalr-hubconnectioncontext-ctors.md)]

***

[!INCLUDE[SignalR JavaScript client package name change](~/includes/core-changes/aspnetcore/3.0/signalr-js-client-package-name.md)]

***

[!INCLUDE[Microsoft.Extensions.Caching.SqlServer uses the new Microsoft.Data.SqlClient package](~/includes/core-changes/aspnetcore/3.0/new-sqlclient-package.md)]

***

[!INCLUDE[Kestrel connection adapters removed](~/includes/core-changes/aspnetcore/3.0/kestrel-connection-adapters-removed.md)]

***

[!INCLUDE[SignInManager constructor accepts new parameter](~/includes/core-changes/aspnetcore/3.0/signinmanager-ctor-parameter.md)]

***

[!INCLUDE[IAuthorizationPolicyProvider implementations require a new method](~/includes/core-changes/aspnetcore/3.0/iauthzpolicyprovider-new-method.md)]

***

[!INCLUDE[HttpResponse body infrastructure changes](~/includes/core-changes/aspnetcore/3.0/httpresponse-body-changes.md)]

***

[!INCLUDE[SpaServices and NodeServices are obsolete](~/includes/core-changes/aspnetcore/3.0/spaservices-nodeservices-obsolete.md)]

***

[!INCLUDE[SpaServices and NodeServices console logger fallback default change](~/includes/core-changes/aspnetcore/3.0/spaservices-nodeservices-fallback.md)]

***

[!INCLUDE[Identity UI uses static web assets feature](~/includes/core-changes/aspnetcore/3.0/identityui-static-web-assets.md)]
