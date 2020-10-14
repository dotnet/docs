---
title: Deployment strategies
description: What deployment strategies can teams use while migrating from ASP.NET to .NET Core? Can an incremental migration allow side-by-side deployment of .NET Framework and .NET Core apps, providing a seamless end user experience?
author: ardalis
ms.date: 11/13/2020
---

# Deployment strategies

One consideration as you plan the migration of your large ASP.NET app to ASP.NET Core is how you will deploy the new app. With ASP.NET, deployment options were limited to IIS on Windows. With .NET Core, a much wider array of deployment options are available.

## Cross-platform options

Because .NET Core supports Linux, you may now find some hosting options available that weren't a consideration previously. Some hosting providers may offer attractive features or pricing for Linux-based hosting that make it an attractive option, or you may have your own non-Windows servers you'd like to leverage as part of your new app deployment strategy. .NET Core opens to door to these options.

## Cloud native development

Most organizations today are leveraging cloud platforms for at least some of their software capabilities. With a migration of an app to .NET Core, it's a good time to consider whether the app should be purposefully written with cloud hosting in mind. Such *cloud native* apps are better able to leverage cloud capabilities like serverless, microservices, and can be less concerned with the low level details of how and where they may be deployed.

Learn more about cloud native app development in this free e-book, [Architecting Cloud Native .NET Applications for Azure](/dotnet/architecture/cloud-native/).

## Leveraging containers

Modern apps often leverage containers as a means of reducing variation between hosting environments. By deploying an app to a particular container, the container-hosted app will run the same whether it's running on a developer's laptop or in production. As part of a migration to .NET Core, it may make sense to consider whether the app would benefit from deployment via container, either as a full monolith or broken up into multiple smaller containerized apps.

TODO: Add figure showing migration to container-hosted app or apps.

## Side-by-side deployment options

Migrating large .NET apps to .NET Core often requires a substantial effort. Most organizations will want to be able to break this effort up in some fashion, so that pieces of the app can be migrated and deployed in production before the entire migration is complete. Running both the original ASP.NET application and its newly-migrated ASP.NET Core sub-app(s) side by side is a frequently cited goal. This can be achieved through a number of mechanisms including leveraging IIS routing, which is covered in [chapter 5](deployment-scenarios.md). Other options include leveraging application gateways or cloud design patterns like [backends for frontends](https://docs.microsoft.com/azure/architecture/patterns/backends-for-frontends) to manage sets of ASP.NET Web APIs and ASP.NET Core API endpoints.

## References

- [Host and deploy ASP.NET Core](https://docs.microsoft.com/aspnet/core/host-and-deploy/)
- [Host ASP.NET Core on Windows with IIS](https://docs.microsoft.com/aspnet/core/host-and-deploy/iis/)
- [Troubleshooting ASP.NET Core on Azure App Service and IIS](https://docs.microsoft.com/aspnet/core/test/troubleshoot-azure-iis)

>[!div class="step-by-step"]
>[Previous](migrating-web-forms.md)
>[Next](additional-migration-resources.md)
