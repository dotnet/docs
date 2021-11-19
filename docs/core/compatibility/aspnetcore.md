---
title: ASP.NET Core breaking changes
titleSuffix: ""
description: Lists the breaking changes in ASP.NET Core 3.0 and 3.1.
ms.date: 11/03/2020
ms.author: scaddie
---
# ASP.NET Core breaking changes for versions 3.0 and 3.1

ASP.NET Core provides the web app development features used by .NET Core.

Select one of the following links for breaking changes in a specific version:

* [ASP.NET Core 3.1](#aspnet-core-31)
* [ASP.NET Core 3.0](#aspnet-core-30)

The following breaking changes in ASP.NET Core 3.0 and 3.1 are documented on this page:

- [Obsolete Antiforgery, CORS, Diagnostics, MVC, and Routing APIs removed](#obsolete-antiforgery-cors-diagnostics-mvc-and-routing-apis-removed)
- [Authentication: Google+ deprecation](#authentication-google-deprecated-and-replaced)
- [Authentication: HttpContext.Authentication property removed](#authentication-httpcontextauthentication-property-removed)
- [Authentication: Newtonsoft.Json types replaced](#authentication-newtonsoftjson-types-replaced)
- [Authentication: OAuthHandler ExchangeCodeAsync signature changed](#authentication-oauthhandler-exchangecodeasync-signature-changed)
- [Authorization: AddAuthorization overload moved to different assembly](#authorization-addauthorization-overload-moved-to-different-assembly)
- [Authorization: IAllowAnonymous removed from AuthorizationFilterContext.Filters](#authorization-iallowanonymous-removed-from-authorizationfiltercontextfilters)
- [Authorization: IAuthorizationPolicyProvider implementations require new method](#authorization-iauthorizationpolicyprovider-implementations-require-new-method)
- [Caching: CompactOnMemoryPressure property removed](#caching-compactonmemorypressure-property-removed)
- [Caching: Microsoft.Extensions.Caching.SqlServer uses new SqlClient package](#caching-microsoftextensionscachingsqlserver-uses-new-sqlclient-package)
- [Data Protection: DataProtection.Blobs uses new Azure Storage APIs](#data-protection-dataprotectionblobs-uses-new-azure-storage-apis)
- [Hosting: AspNetCoreModule V1 removed from Windows Hosting Bundle](#hosting-aspnetcoremodule-v1-removed-from-windows-hosting-bundle)
- [Hosting: Generic host restricts Startup constructor injection](#hosting-generic-host-restricts-startup-constructor-injection)
- [Hosting: HTTPS redirection enabled for IIS out-of-process apps](#hosting-https-redirection-enabled-for-iis-out-of-process-apps)
- [Hosting: IHostingEnvironment and IApplicationLifetime types replaced](#hosting-ihostingenvironment-and-iapplicationlifetime-types-marked-obsolete-and-replaced)
- [Hosting: ObjectPoolProvider removed from WebHostBuilder dependencies](#hosting-objectpoolprovider-removed-from-webhostbuilder-dependencies)
- [HTTP: Browser SameSite changes impact authentication](#http-browser-samesite-changes-impact-authentication)
- [HTTP: DefaultHttpContext extensibility removed](#http-defaulthttpcontext-extensibility-removed)
- [HTTP: HeaderNames fields changed to static readonly](#http-headernames-constants-changed-to-static-readonly)
- [HTTP: Response body infrastructure changes](#http-response-body-infrastructure-changes)
- [HTTP: Some cookie SameSite default values changed](#http-some-cookie-samesite-defaults-changed-to-none)
- [HTTP: Synchronous IO disabled by default](#http-synchronous-io-disabled-in-all-servers)
- [Identity: AddDefaultUI method overload removed](#identity-adddefaultui-method-overload-removed)
- [Identity: UI Bootstrap version change](#identity-default-bootstrap-version-of-ui-changed)
- [Identity: SignInAsync throws exception for unauthenticated identity](#identity-signinasync-throws-exception-for-unauthenticated-identity)
- [Identity: SignInManager constructor accepts new parameter](#identity-signinmanager-constructor-accepts-new-parameter)
- [Identity: UI uses static web assets feature](#identity-ui-uses-static-web-assets-feature)
- [Kestrel: Connection adapters removed](#kestrel-connection-adapters-removed)
- [Kestrel: Empty HTTPS assembly removed](#kestrel-empty-https-assembly-removed)
- [Kestrel: Request trailer headers moved to new collection](#kestrel-request-trailer-headers-moved-to-new-collection)
- [Kestrel: Transport abstraction layer changes](#kestrel-transport-abstractions-removed-and-made-public)
- [Localization: APIs marked obsolete](#localization-resourcemanagerwithculturestringlocalizer-and-withculture-marked-obsolete)
- [Logging: DebugLogger class made internal](#logging-debuglogger-class-made-internal)
- [MVC: Controller action Async suffix removed](#mvc-async-suffix-trimmed-from-controller-action-names)
- [MVC: JsonResult moved to Microsoft.AspNetCore.Mvc.Core](#mvc-jsonresult-moved-to-microsoftaspnetcoremvccore)
- [MVC: Precompilation tool deprecated](#mvc-precompilation-tool-deprecated)
- [MVC: Types changed to internal](#mvc-pubternal-types-changed-to-internal)
- [MVC: Web API compatibility shim removed](#mvc-web-api-compatibility-shim-removed)
- [Razor: RazorTemplateEngine API removed](#razor-razortemplateengine-api-removed)
- [Razor: Runtime compilation moved to a package](#razor-runtime-compilation-moved-to-a-package)
- [Session state: Obsolete APIs removed](#session-state-obsolete-apis-removed)
- [Shared framework: Assembly removal from Microsoft.AspNetCore.App](#shared-framework-assemblies-removed-from-microsoftaspnetcoreapp)
- [Shared framework: Microsoft.AspNetCore.All removed](#shared-framework-removed-microsoftaspnetcoreall)
- [SignalR: HandshakeProtocol.SuccessHandshakeData replaced](#signalr-handshakeprotocolsuccesshandshakedata-replaced)
- [SignalR: HubConnection methods removed](#signalr-hubconnection-resetsendping-and-resettimeout-methods-removed)
- [SignalR: HubConnectionContext constructors changed](#signalr-hubconnectioncontext-constructors-changed)
- [SignalR: JavaScript client package name change](#signalr-javascript-client-package-name-changed)
- [SignalR: Obsolete APIs](#signalr-usesignalr-and-useconnections-methods-marked-obsolete)
- [SPAs: SpaServices and NodeServices console logger fallback default change](#spas-spaservices-and-nodeservices-no-longer-fall-back-to-console-logger)
- [SPAs: SpaServices and NodeServices marked obsolete](#spas-spaservices-and-nodeservices-marked-obsolete)
- [Target framework: .NET Framework not supported](#target-framework-net-framework-support-dropped)

## ASP.NET Core 3.1

[!INCLUDE[HTTP: Browser SameSite changes impact authentication](~/includes/core-changes/aspnetcore/3.1/http-cookie-samesite-authn-impacts.md)]

***

## ASP.NET Core 3.0

[!INCLUDE[Obsolete Antiforgery, CORS, Diagnostics, MVC, and Routing APIs removed](~/includes/core-changes/aspnetcore/3.0/obsolete-apis-removed.md)]

***

[!INCLUDE[Authentication: Google+ deprecation](~/includes/core-changes/aspnetcore/3.0/authn-google-plus-authn-changes.md)]

***

[!INCLUDE[Authentication: HttpContext.Authentication property removed](~/includes/core-changes/aspnetcore/3.0/authn-httpcontext-property-removed.md)]

***

[!INCLUDE[Authentication: Newtonsoft.Json types replaced](~/includes/core-changes/aspnetcore/3.0/authn-apis-json-types.md)]

***

[!INCLUDE[Authentication: OAuthHandler ExchangeCodeAsync signature changed](~/includes/core-changes/aspnetcore/3.0/authn-exchangecodeasync-signature-change.md)]

***

[!INCLUDE[Authorization: AddAuthorization overload assembly change](~/includes/core-changes/aspnetcore/3.0/authz-assembly-change.md)]

***

[!INCLUDE[Authorization: IAllowAnonymous removed from AuthorizationFilterContext.Filters](~/includes/core-changes/aspnetcore/3.0/authz-iallowanonymous-removed-from-collection.md)]

***

[!INCLUDE[Authorization: IAuthorizationPolicyProvider implementations require new method](~/includes/core-changes/aspnetcore/3.0/authz-iauthzpolicyprovider-new-method.md)]

***

[!INCLUDE[Caching: CompactOnMemoryPressure property removed](~/includes/core-changes/aspnetcore/3.0/caching-memory-property-removed.md)]

***

[!INCLUDE[Caching: Microsoft.Extensions.Caching.SqlServer uses new SqlClient package](~/includes/core-changes/aspnetcore/3.0/caching-new-sqlclient-package.md)]

***

[!INCLUDE[Caching: ResponseCaching types changed to internal](~/includes/core-changes/aspnetcore/3.0/caching-response-pubternal-to-internal.md)]

***

[!INCLUDE[Data Protection: DataProtection.AzureStorage uses new Azure Storage APIs](~/includes/core-changes/aspnetcore/3.0/dataprotection-azstorage-using-azstorage-apis.md)]

***

[!INCLUDE[Hosting: ANCM version 1 removed from hosting bundle](~/includes/core-changes/aspnetcore/3.0/hosting-ancmv1-hosting-bundle-removal.md)]

***

[!INCLUDE[Hosting: Generic host restriction on Startup constructor injection](~/includes/core-changes/aspnetcore/3.0/hosting-generic-host-startup-ctor-restriction.md)]

***

[!INCLUDE[Hosting: HTTPS redirection enabled for IIS OutOfProcess](~/includes/core-changes/aspnetcore/3.0/hosting-https-redirection-iis-outofprocess.md)]

***

[!INCLUDE[Hosting: IHostingEnvironment and IApplicationLifetime types replaced](~/includes/core-changes/aspnetcore/3.0/hosting-ihostingenv-iapplifetime-types-replaced.md)]

***

[!INCLUDE[Hosting: ObjectPoolProvider removed from WebHostBuilder dependencies](~/includes/core-changes/aspnetcore/3.0/hosting-objectpoolprovider-webhostbuilder-dependencies.md)]

***

[!INCLUDE[HTTP: DefaultHttpContext extensibility removed](~/includes/core-changes/aspnetcore/3.0/http-defaulthttpcontext-extensibility-removed.md)]

***

[!INCLUDE[HTTP: HeaderNames fields changed to static readonly](~/includes/core-changes/aspnetcore/3.0/http-headernames-constants-staticreadonly.md)]

***

[!INCLUDE[HTTP: Response body infrastructure changes](~/includes/core-changes/aspnetcore/3.0/http-response-body-changes.md)]

***

[!INCLUDE[HTTP: Some cookie SameSite default values changed](~/includes/core-changes/aspnetcore/3.0/http-cookie-samesite-defaults-change.md)]

***

[!INCLUDE[HTTP: Synchronous IO disabled by default](~/includes/core-changes/aspnetcore/3.0/http-synchronous-io-disabled.md)]

***

[!INCLUDE[Identity: AddDefaultUI method overload removed](~/includes/core-changes/aspnetcore/3.0/identity-ui-adddefaultui-overload-removed.md)]

***

[!INCLUDE[Identity: UI Bootstrap version change](~/includes/core-changes/aspnetcore/3.0/identity-ui-bootstrap-version.md)]

***

[!INCLUDE[Identity: SignInAsync throws exception for unauthenticated identity](~/includes/core-changes/aspnetcore/3.0/identity-signinasync-throws-exception.md)]

***

[!INCLUDE[Identity: SignInManager constructor accepts new parameter](~/includes/core-changes/aspnetcore/3.0/identity-signinmanager-ctor-parameter.md)]

***

[!INCLUDE[Identity: UI uses static web assets feature](~/includes/core-changes/aspnetcore/3.0/identity-ui-static-web-assets.md)]

***

[!INCLUDE[Kestrel: Connection adapters removed](~/includes/core-changes/aspnetcore/3.0/kestrel-connection-adapters-removed.md)]

***

[!INCLUDE[Kestrel: Empty HTTPS assembly removed](~/includes/core-changes/aspnetcore/3.0/kestrel-empty-assembly-removed.md)]

***

[!INCLUDE[Kestrel: Request trailer headers moved to new collection](~/includes/core-changes/aspnetcore/3.0/kestrel-request-trailer-headers.md)]

***

[!INCLUDE[Kestrel: Transport abstraction layer changes](~/includes/core-changes/aspnetcore/3.0/kestrel-transport-abstractions.md)]

***

[!INCLUDE[Localization: APIs marked obsolete](~/includes/core-changes/aspnetcore/3.0/localization-apis-marked-obsolete.md)]

***

[!INCLUDE[Logging: DebugLogger class made internal](~/includes/core-changes/aspnetcore/3.0/logging-debuglogger-to-internal.md)]

***

[!INCLUDE[MVC: Controller action Async suffix removed](~/includes/core-changes/aspnetcore/3.0/mvc-action-async-suffix-trimmed.md)]

***

[!INCLUDE[MVC: JsonResult moved to Microsoft.AspNetCore.Mvc.Core](~/includes/core-changes/aspnetcore/3.0/mvc-jsonresult-moved.md)]

***

[!INCLUDE[MVC: Precompilation tool deprecated](~/includes/core-changes/aspnetcore/3.0/mvc-precompilation-tool-deprecated.md)]

***

[!INCLUDE[MVC: Types changed to internal](~/includes/core-changes/aspnetcore/3.0/mvc-pubternal-to-internal.md)]

***

[!INCLUDE[MVC: Web API compatibility shim removed](~/includes/core-changes/aspnetcore/3.0/mvc-webapi-compat-shim-removed.md)]

***

[!INCLUDE[Razor: RazorTemplatEengine API removed](~/includes/core-changes/aspnetcore/3.0/razor-razortemplateengine-api-removed.md)]

***

[!INCLUDE[Razor: Runtime compilation moved to a package](~/includes/core-changes/aspnetcore/3.0/razor-runtime-compilation-package.md)]

***

[!INCLUDE[Session state: Obsolete APIs removed](~/includes/core-changes/aspnetcore/3.0/session-obsolete-apis-removed.md)]

***

[!INCLUDE[Shared framework: Assembly removal from Microsoft.AspNetCore.App](~/includes/core-changes/aspnetcore/3.0/sharedfx-app-shared-framework-assemblies.md)]

***

[!INCLUDE[Shared framework: Microsoft.AspNetCore.All removed](~/includes/core-changes/aspnetcore/3.0/sharedfx-all-framework-removed.md)]

***

[!INCLUDE[SignalR: HandshakeProtocol.SuccessHandshakeData replaced](~/includes/core-changes/aspnetcore/3.0/signalr-successhandshakedata-replaced.md)]

***

[!INCLUDE[SignalR: HubConnection methods removed](~/includes/core-changes/aspnetcore/3.0/signalr-hubconnection-methods-removed.md)]

***

[!INCLUDE[SignalR: HubConnectionContext constructors changed](~/includes/core-changes/aspnetcore/3.0/signalr-hubconnectioncontext-ctors.md)]

***

[!INCLUDE[SignalR: JavaScript client package name change](~/includes/core-changes/aspnetcore/3.0/signalr-js-client-package-name.md)]

***

[!INCLUDE[SignalR: Obsolete APIs](~/includes/core-changes/aspnetcore/3.0/signalr-obsolete-apis.md)]

***

[!INCLUDE[SPAs: SpaServices and NodeServices marked obsolete](~/includes/core-changes/aspnetcore/3.0/spas-spaservices-nodeservices-obsolete.md)]

***

[!INCLUDE[SPAs: SpaServices and NodeServices console logger fallback default change](~/includes/core-changes/aspnetcore/3.0/spas-spaservices-nodeservices-fallback.md)]

***

[!INCLUDE[Target framework: .NET Framework not supported](~/includes/core-changes/aspnetcore/3.0/targetfx-netfx-tfm-support.md)]

***
