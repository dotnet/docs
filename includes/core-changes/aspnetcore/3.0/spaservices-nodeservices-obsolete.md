### SpaServices and NodeServices are obsolete

The contents of the following NuGet packages have all been unnecessary since ASP.NET Core 2.1. Consequently, the packages are being marked as obsolete.

- [Microsoft.AspNetCore.SpaServices](https://www.nuget.org/packages/Microsoft.AspNetCore.SpaServices/)
- [Microsoft.AspNetCore.NodeServices](https://www.nuget.org/packages/Microsoft.AspNetCore.NodeServices/)

For the same reason, the following npm modules are being marked as deprecated:

- [aspnet-angular](https://www.npmjs.com/package/aspnet-angular)
- [aspnet-prerendering](https://www.npmjs.com/package/aspnet-prerendering)
- [aspnet-webpack](https://www.npmjs.com/package/aspnet-webpack)
- [aspnet-webpack-react](https://www.npmjs.com/package/aspnet-webpack-react)
- [domain-task](https://www.npmjs.com/package/domain-task)

The preceding packages and npm modules will later be removed in .NET 5.

#### Version introduced

3.0

#### Old behavior

The deprecated packages and npm modules were intended to integrate ASP.NET Core with various Single-Page App (SPA) frameworks. Such frameworks include Angular, React, and React with Redux.

#### New behavior

A new integration mechanism exists in the [Microsoft.AspNetCore.SpaServices.Extensions](https://www.nuget.org/packages/Microsoft.AspNetCore.SpaServices.Extensions/) NuGet package. The package remains the basis of the Angular and React project templates since ASP.NET Core 2.1.

#### Reason for change

ASP.NET Core supports integration with various Single-Page App (SPA) frameworks, including Angular, React, and React with Redux. Initially, integration with these frameworks was accomplished with ASP.NET Core-specific components that handled scenarios like server-side prerendering and integration with Webpack. As time went on, industry standards changed. Each of the SPA frameworks released their own standard command-line interfaces. For example, Angular CLI and create-react-app.

When ASP.NET Core 2.1 was released in May 2018, the team responded to the change in standards. A newer and simpler way to integrate with the SPA frameworks' own toolchains was provided. The new integration mechanism exists in the package `Microsoft.AspNetCore.SpaServices.Extensions` and remains the basis of our Angular and React project templates since ASP.NET Core 2.1.

To clarify that the older ASP.NET Core-specific components are irrelevant and not recommended:

- The pre-2.1 integration mechanism is marked as obsolete.
- The supporting npm packages are marked as deprecated.

#### Recommended action

If you're using these packages, update your apps to use the functionality:

- In the `Microsoft.AspNetCore.SpaServices.Extensions` package.
- Provided by the SPA frameworks you're using

To enable features like server-side prerendering and hot module reload, refer to the documentation for the corresponding SPA framework. The functionality in `Microsoft.AspNetCore.SpaServices.Extensions` is *not* obsolete and will continue to be supported.

#### Category

ASP.NET Core

#### Affected APIs

- [Microsoft.AspNetCore.Builder.SpaRouteExtensions](/dotnet/api/microsoft.aspnetcore.builder.sparouteextensions?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.Builder.WebpackDevMiddleware](/dotnet/api/microsoft.aspnetcore.builder.webpackdevmiddleware?view=aspnetcore-2.2)

- [Microsoft.AspNetCore.NodeServices.EmbeddedResourceReader](/dotnet/api/microsoft.aspnetcore.nodeservices.embeddedresourcereader?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.INodeServices](/dotnet/api/microsoft.aspnetcore.nodeservices.inodeservices?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.NodeServicesFactory](/dotnet/api/microsoft.aspnetcore.nodeservices.nodeservicesfactory?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.NodeServicesOptions](/dotnet/api/microsoft.aspnetcore.nodeservices.nodeservicesoptions?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.StringAsTempFile](/dotnet/api/microsoft.aspnetcore.nodeservices.stringastempfile?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.HostingModels.INodeInstance](/dotnet/api/microsoft.aspnetcore.nodeservices.hostingmodels.inodeinstance?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.HostingModels.NodeInvocationException](/dotnet/api/microsoft.aspnetcore.nodeservices.hostingmodels.nodeinvocationexception?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.HostingModels.NodeInvocationInfo](/dotnet/api/microsoft.aspnetcore.nodeservices.hostingmodels.nodeinvocationinfo?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.HostingModels.NodeServicesOptionsExtensions](/dotnet/api/microsoft.aspnetcore.nodeservices.hostingmodels.nodeservicesoptionsextensions?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.NodeServices.HostingModels.OutOfProcessNodeInstance](/dotnet/api/microsoft.aspnetcore.nodeservices.hostingmodels.outofprocessnodeinstance?view=aspnetcore-2.2)

- [Microsoft.AspNetCore.SpaServices.Prerendering.ISpaPrerenderer](/dotnet/api/microsoft.aspnetcore.spaservices.prerendering.ispaprerenderer?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SpaServices.Prerendering.ISpaPrerendererBuilder](/dotnet/api/microsoft.aspnetcore.spaservices.prerendering.ispaprerendererbuilder?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SpaServices.Prerendering,JavaScriptModuleExport](/dotnet/api/microsoft.aspnetcore.spaservices.prerendering.javascriptmoduleexport?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SpaServices.Prerendering.Prerenderer](/dotnet/api/microsoft.aspnetcore.spaservices.prerendering.prerenderer?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SpaServices.Prerendering.PrerenderTagHelper](/dotnet/api/microsoft.aspnetcore.spaservices.prerendering.prerendertaghelper?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SpaServices.Prerendering.RenderToStringResult](/dotnet/api/microsoft.aspnetcore.spaservices.prerendering.rendertostringresult?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.SpaServices.Webpack.WebpackDevMiddlewareOptions](/dotnet/api/microsoft.aspnetcore.spaservices.webpack.webpackdevmiddlewareoptions?view=aspnetcore-2.2)

- [Microsoft.Extensions.DependencyInjection.NodeServicesServiceCollectionExtensions](/dotnet/api/microsoft.extensions.dependencyinjection.nodeservicesservicecollectionextensions?view=aspnetcore-2.2)
- [Microsoft.Extensions.DependencyInjection.PrerenderingServiceCollectionExtensions](/dotnet/api/microsoft.extensions.dependencyinjection.prerenderingservicecollectionextensions?view=aspnetcore-2.2)
