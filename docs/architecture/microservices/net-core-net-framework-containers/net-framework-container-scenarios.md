---
title: When to choose .NET Framework for Docker containers
description: .NET Microservices Architecture for Containerized .NET Applications | When to choose .NET Framework for Docker containers
ms.date: 11/19/2021
---
# When to choose .NET Framework for Docker containers

While .NET 6 offers significant benefits for new applications and application patterns, .NET Framework will continue to be a good choice for many existing scenarios.

## Migrating existing applications directly to a Windows Server container

You might want to use Docker containers just to simplify deployment, even if you are not creating microservices. For example, perhaps you want to improve your DevOps workflow with Docker—containers can give you better isolated test environments and can also eliminate deployment issues caused by missing dependencies when you move to a production environment. In cases like these, even if you are deploying a monolithic application, it makes sense to use Docker and Windows Containers for your current .NET Framework applications.

In most cases for this scenario, you will not need to migrate your existing applications to .NET 6; you can use Docker containers that include the traditional .NET Framework. However, a recommended approach is to use .NET 6 as you extend an existing application, such as writing a new service in ASP.NET Core.

## Using third-party .NET libraries or NuGet packages not available for .NET 6

Third-party libraries are quickly embracing [.NET Standard](../../../standard/net-standard.md), which enables code sharing across all .NET flavors, including .NET 6. With .NET Standard 2.0 and later, the API surface compatibility across different frameworks has become significantly larger. Even more, .NET Core 2.x and newer applications can also directly reference existing .NET Framework libraries (see [.NET Framework 4.6.1 supporting .NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/planning/netstandard-2.0/README.md#net-framework-461-supporting-net-standard-20)).

In addition, the [Windows Compatibility Pack](../../../core/porting/windows-compat-pack.md) extends the API surface available for .NET Standard 2.0 on Windows. This pack allows recompiling most existing code to .NET Standard 2.x with little or no modification, to run on Windows.

However, even with that exceptional progression since .NET Standard 2.0 and .NET Core 2.1 or later, there might be cases where certain NuGet packages need Windows to run and might not support .NET Core or later. If those packages are critical for your application, then you will need to use .NET Framework on Windows Containers.

## Using .NET technologies not available for .NET 6

Some .NET Framework technologies aren't available in the current version of .NET (version 5.0 as of this writing). Some of them might become available in later releases, but others don't fit the new application patterns targeted by .NET Core and might never be available.

The following list shows most of the technologies that aren't available in .NET 6:

- ASP.NET Web Forms. This technology is only available on .NET Framework. Currently there are no plans to bring ASP.NET Web Forms to .NET  or later.

- WCF services. Even when a [WCF-Client library](https://github.com/dotnet/wcf) is available to consume WCF services from .NET 6, as of Jan-2021, the WCF server implementation is only available on .NET Framework.

- Workflow-related services. Windows Workflow Foundation (WF), Workflow Services (WCF + WF in a single service), and WCF Data Services (formerly known as ADO.NET Data Services) are only available on .NET Framework. There are currently no plans to bring them to .NET 6.

In addition to the technologies listed in the official [.NET roadmap](https://github.com/dotnet/core/blob/main/roadmap.md), other features might be ported to the new [unified .NET platform](https://devblogs.microsoft.com/dotnet/introducing-net-5/). You might consider participating in the discussions on GitHub so that your voice can be heard. And if you think something is missing, file a new issue in the [dotnet/runtime](https://github.com/dotnet/runtime/issues/new) GitHub repository.

## Using a platform or API that doesn't support .NET 6

Some Microsoft and third-party platforms don't support .NET 6. For example, some Azure services provide an SDK that isn't yet available for consumption on .NET 6 yet. Most Azure SDK should eventually be ported to .NET 6/.NET Standard, but some might not for several reasons. You can see the available Azure SDKs in the [Azure SDK Latest Releases](https://azure.github.io/azure-sdk/releases/latest/index.html) page.

In the meantime, if any platform or service in Azure still doesn't support .NET 6 with its client API, you can use the equivalent REST API from the Azure service or the client SDK on .NET Framework.

## Porting existing ASP.NET application to .NET 6

.NET Core is a revolutionary step forward from .NET Framework. It offers a host of advantages over .NET Framework across the board from productivity to performance, and from cross-platform support to developer satisfaction. If you are using .NET Framework and planning to migrate your application to .NET Core or .NET 5+, see [Porting Existing ASP.NET Apps to .NET Core](../../porting-existing-aspnet-apps/index.md).

### Additional resources

- **.NET fundamentals** \
  [https://docs.microsoft.com/dotnet/fundamentals](../../../fundamentals/index.yml)

- **Porting Projects to .NET 5** \
  [https://docs.microsoft.com/events/dotnetconf-2020/porting-projects-to-net-5](/Events/dotnetConf/2020/Porting-Projects-to-NET-5)

- **.NET on Docker Guide** \
  [https://docs.microsoft.com/dotnet/core/docker/introduction](../../../core/docker/introduction.md)

- **.NET Components Overview** \
  [https://docs.microsoft.com/dotnet/standard/components](../../../standard/components.md)

>[!div class="step-by-step"]
>[Previous](net-core-container-scenarios.md)
>[Next](container-framework-choice-factors.md)
