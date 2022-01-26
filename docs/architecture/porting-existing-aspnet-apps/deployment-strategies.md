---
title: Deployment strategies
description: What deployment strategies can teams use while migrating from ASP.NET to ASP.NET Core? Can an incremental migration allow side-by-side deployment of .NET Framework and .NET Core apps, providing a seamless end user experience?
author: ardalis
ms.date: 12/10/2021
---

# Deployment strategies

One consideration as you plan the migration of your large ASP.NET app to ASP.NET Core is how you'll deploy the new app. With ASP.NET, deployment options were limited to IIS on Windows. With ASP.NET Core, a much wider array of deployment options is available.

## Cross-platform options

Because .NET Core runs on Linux, you'll find some hosting options available that weren't a consideration previously. Linux-based hosting may be preferable for the following reasons:

* Your organization has infrastructure or expertise.
* Hosting providers offer attractive features or pricing for Linux-based hosting.

.NET Core opens the door to these options.

## Cloud native development

Most organizations today are using cloud platforms for at least some of their software capabilities. With an app migration to .NET Core, it's a good time to consider whether the app should be purposefully written with cloud hosting in mind. Such *cloud native* apps are better able to apply cloud capabilities like serverless, microservices, and can be less concerned with the low-level details of how and where they may be deployed.

Learn more about cloud native app development in this free e-book, [Architecting Cloud Native .NET Applications for Azure](../cloud-native/index.md).

## Leverage containers

Modern apps often leverage containers as a means of reducing variation between hosting environments. By deploying an app to a particular container, the container-hosted app will run the same whether it's running on a developer's laptop or in production. As part of a migration to .NET Core, it may make sense to consider whether the app would benefit from deployment via container, either as a full monolith or broken up into multiple smaller containerized apps.

## Side-by-side deployment options

Migrating large .NET Framework apps to .NET Core often requires a substantial effort. Most organizations will want to be able to break this effort up in some fashion, so that pieces of the app can be migrated and deployed in production before the entire migration is complete. Running both the original ASP.NET app and its newly-migrated ASP.NET Core sub-app(s) side by side is a frequently cited goal. This can be achieved through a number of mechanisms including leveraging IIS routing, which is covered in [chapter 5](deployment-scenarios.md). Other options include leveraging app gateways or cloud design patterns like [backends for frontends](/azure/architecture/patterns/backends-for-frontends) to manage sets of ASP.NET Web APIs and ASP.NET Core API endpoints.

## IIS on Windows

You can continue hosting your apps on IIS running on Windows. This is a fine option for customers who want to take advantage of ASP.NET Core features without changing their current deployment model. While moving to ASP.NET Core provides more options in terms of how and where to deploy your apps, it doesn't require that you change from the status quo of using the proven combination of IIS on Windows.

## Other options on Windows

You can host apps side-by-side apps on Windows using any combination of Kestrel, HTTP.sys, and IIS hosts, in addition to Docker containers, if needed. If your app requires a combination of Windows and Linux services, hosting on a Windows server with [WSL](/windows/wsl/about) and/or Linux Docker containers provides a single server solution to hosting all parts of the app.

## References

- [Host and deploy ASP.NET Core](/aspnet/core/host-and-deploy/)
- [Host ASP.NET Core on Windows with IIS](/aspnet/core/host-and-deploy/iis/)
- [Troubleshooting ASP.NET Core on Azure App Service and IIS](/aspnet/core/test/troubleshoot-azure-iis)

>[!div class="step-by-step"]
>[Previous](migrate-web-forms.md)
>[Next](additional-migration-resources.md)
