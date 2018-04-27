---
title: Common web application architectures
description: Architect modern web applications with ASP.NET Core and Microsoft Azure | common web application architectures
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
# Common Web Application Architectures

> "If you think good architecture is expensive, try bad architecture."  
> _- Brian Foote and Joseph Yoder_

## Summary

Most traditional .NET applications are deployed as single units corresponding to an executable or a single web application running within a single IIS appdomain. This is the simplest deployment model and serves many internal and smaller public applications very well. However, even given this single unit of deployment, most non-trivial business applications benefit from some logical separation into several layers.

## What is a monolithic application?

A monolithic application is one that is entirely self-contained, in terms of its behavior. It may interact with other services or data stores in the course of performing its operations, but the core of its behavior runs within its own process and the entire application is typically deployed as a single unit. If such an application needs to scale horizontally, typically the entire application is duplicated across multiple servers or virtual machines.

## All-in-One applications

The smallest possible number of projects for an application architecture is one. In this architecture, the entire logic of the application is contained in a single project, compiled to a single assembly, and deployed as a single unit.

A new ASP.NET Core project, whether created in Visual Studio or from the command line, starts out as a simple "all-in-one" monolith. It contains all of the behavior of the application, including presentation, business, and data access logic. Figure 5-1 shows the file structure of a single-project app.

**Figure 5-1.** A single project ASP.NET Core app

![](./media/image5-1.png)

In a single project scenario, separation of concerns is achieved through the use of folders. The default template includes separate folders for MVC pattern responsibilities of Models, Views, and Controllers, as well as additional folders for Data and Services. In this arrangement, presentation details should be limited as much as possible to the Views folder, and data access implementation details should be limited to classes kept in the Data folder. Business logic should reside in services and classes within the Models folder.

Although simple, the single-project monolithic solution has some disadvantages. As the project's size and complexity grows, the number of files and folders will continue to grow as well. UI concerns (models, views, controllers) reside in multiple folders, which are not grouped together alphabetically. This issue only gets worse when additional UI-level constructs, such as Filters or ModelBinders, are added in their own folders. Business logic is scattered between the Models and Services folders, and there is no clear indication of which classes in which folders should depend on which others. This lack of organization at the project level frequently leads to [spaghetti code](http://deviq.com/spaghetti-code/).

In order to address these issues, applications often evolve into multi-project solutions, where each project is considered to reside in a particular *layer* of the application.

## What are layers?

As applications grow in complexity, one way to manage that complexity is to break the application up according to its responsibilities or concerns. This follows the separation of concerns principle, and can help keep a growing codebase organized so that developers can easily find where certain functionality is implemented. Layered architecture offers a number of advantages beyond just code organization, though.

By organizing code into layers, common low-level functionality can be reused throughout the application. This reuse is beneficial because it means less code needs to be written and because it can allow the application to standardize on a single implementation, following the DRY principle.

With a layered architecture, applications can enforce restrictions on which layers can communicate with other layers. This helps to achieve encapsulation. When a layer is changed or replaced, only those layers that work with it should be impacted. By limiting which layers depend on which other layers, the impact of changes can be mitigated so that a single change doesn't impact the entire application.

Layers (and encapsulation) make it much easier to replace functionality within the application. For example, an application might initially use its own SQL Server database for persistence, but later could choose to use a cloud-based persistence strategy, or one behind a web API. If the application has properly encapsulated its persistence implementation within a logical layer, that SQL Server specific layer could be replaced by a new one implementing the same public interface.

In addition to the potential of swapping out implementations in response to future changes in requirements, application layers can also make it easier to swap out implementations for testing purposes. Instead of having to write tests that operate against the real data layer or UI layer of the application, these layers can be replaced at test time with fake implementations that provide known responses to requests. This typically makes tests much easier to write and much faster to run when compared to running tests again the application's real infrastructure.

Logical layering is a common technique for improving the organization of code in enterprise software applications, and there are several ways in which code can be organized into layers.

> [!NOTE]
> *Layers* represent logical separation within the application. In the event that application logic is physically distributed to separate servers or processes, these separate physical deployment targets are referred to as *tiers*. It's possible, and quite common, to have an N-Layer application that is deployed to a single tier.

## Traditional "N-Layer" architecture applications

The most common organization of application logic into layers it shown in Figure 5-2.

**Figure 5-2.** Typical application layers.

![](./media/image5-2.png)

These layers are frequently abbreviated as UI, BLL (Business Logic Layer), and DAL (Data Access Layer). Using this architecture, users make requests through the UI layer, which interacts only with the BLL. The BLL, in turn, can call the DAL for data access requests. The UI layer should not make any requests to the DAL directly, nor should it interact with persistence directly through other means. Likewise, the BLL should only interact with persistence by going through the DAL. In this way, each layer has its own well-known responsibility.

One disadvantage of this traditional layering approach is that compile-time dependencies run from the top to the bottom. That is, the UI layer depends on the BLL, which depends on the DAL. This means that the BLL, which usually holds the most important logic in the application, is dependent on data access implementation details (and often on the existence of a database). Testing business logic in such an architecture is often difficult, requiring a test database. The dependency inversion principle can be used to address this issue, as you'll see in the next section.

Figure 5-3 shows an example solution, breaking the application into three projects by responsibility (or layer).

**Figure 5-3.** A simple monolithic application with three projects.

![](./media/image5-3.png)

Although this application uses several projects for organizational purposes, it is still deployed as a single unit and its clients will interact with it as a single web app. This allows for very simple deployment process. Figure 5-4 shows how such an app might be hosted using Windows Azure.

![](./media/image5-4.png)

**Figure 5-4.** Simple deployment of Azure Web App

As application needs grow, more complex and robust deployment solutions may be required. Figure 5-5 shows an example of a more complex deployment plan that supports additional capabilities.

![](./media/image5-5.png)

**Figure 5-5.** Deploying a web app to an Azure App Service

Internally, this project's organization into multiple projects based on responsibility improves the maintainability of the application.

This unit can be scaled up or out to take advantage of cloud-based on-demand scalability. Scaling up means adding additional CPU, memory, disk space, or other resources to the server(s) hosting your app. Scaling out means adding additional instances of such servers, whether these are physical servers or virtual machines. When your app is hosted across multiple instances, a load balancer is used to assign requests to individual app instances.

The simplest approach to scaling a web application in Azure is to configure scaling manually in the application's App Service Plan. Figure 5-6 show the appropriate Azure dashboard screen to configure how many instances are serving an app.

![](./media/image5-6.png)

**Figure 5-6.** App Service Plan scaling in Azure.

## Clean architecture

Applications that follow the Dependency Inversion Principle as well as Domain-Driven Design (DDD) principles tend to arrive at a similar architecture. This architecture has gone by many names over the years. One of the first names was Hexagonal Architecture, followed by Ports-and-Adapters. More recently, it's been cited as the [Onion Architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/) or [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html). It is this last name, Clean Architecture, that is used as the basis for describing the architecture in this e-book.

> [!NOTE]
> The term Clean Architecture can be applied to applications that are built using DDD Principles as well as to those that are not built using DDD. In the case of the former, this combination may be referred to as "Clean DDD Architecture".

Clean architecture puts the business logic and application model at the center of the application. Instead of having business logic depend on data access or other infrastructure concerns, this dependency is inverted: infrastructure and implementation details depend on the Application Core. This is achieved by defining abstractions, or interfaces, in the Application Core, which are then implemented by types defined in the Infrastructure layer. A common way of visualizing this architecture is to use a series of concentric circles, similar to an onion. Figure 5-X shows an example of this style of architectural representation.

![](./media/image5-7.png)

**Figure 5-7.** Clean Architecture; onion view

In this diagram, dependencies flow toward the innermost circle. Thus, you can see that the Application Core (which takes its name from its position at the core of this diagram) has no dependencies on other application layers. At the very center are the application's entities and interfaces. Just outside, but still in the Application Core, are domain services, which typically implement interfaces defined in the inner circle. Outside of the Application Core, both the User Interface and the Infrastructure layers depend on the Application Core, but not on one another (necessarily).

Figure 5-X shows a more traditional horizontal layer diagram that better reflects the dependency between the UI and other layers.

![](./media/image5-8.png)

**Figure 5-8.** Clean Architecture; horizontal layer view

Note that the solid arrows represent compile-time dependencies, while the dashed arrow represents a runtime-only dependency. Using the clean architecture, the UI layer works with interfaces defined in the Application Core at compile time, and ideally should not have any knowledge of the implementation types defined in the Infrastructure layer. At runtime, however, these implementation types will be required for the app to execute, so they will need to be present and wired up to the Application Core interfaces via dependency injection.

Figure 5-9 shows a more detailed view of an ASP.NET Core application's architecture when built following these recommendations.

![ASPNET Core Architecture](./media/image5-9.png)

**Figure 5-9.** ASP.NET Core architecture diagram following Clean Architecture.

Because the Application Core doesn't depend on Infrastructure, it is very easy to write automated unit tests for this layer. Figures 5-10 and 5-11 show how tests fit into this architecture.

![UnitTestCore](./media/image5-10.png)

**Figure 5-10.** Unit testing Application Core in isolation.

![IntegrationTests](./media/image5-11.png)

**Figure 5-11.** Integration testing Infrastructure implementations with external dependencies.

Since the UI layer doesn't have any direct dependency on types defined in the Infrastructure project, it is likewise very easy to swap out implementations, either to facilitate testing or in response to changing application requirements. ASP.NET Core's built-in use of and support for dependency injection makes this architecture the most appropriate way to structure non-trivial monolithic applications.

For monolithic applications the Application Core, Infrastructure, and User Interface projects are all run as a single application. The runtime application architecture might look something like Figure 5-12.

![ASPNET Core Architecture 2](./media/image5-12.png)

**Figure 5-12.** A sample ASP.NET Core app's runtime architecture.

### Organizing Code in Clean Architecture

In a Clean Architecture solution, each project has clear responsibilities. As such, certain types will belong in each project and you'll frequently find folders corresponding to these types in the appropriate project.

The Application Core holds the business model, which includes entities, services, and interfaces. These interfaces include abstractions for operations that will be performed using Infrastructure, such as data access, file system access, network calls, etc. Sometimes services or interfaces defined at this layer will need to work with non-entity types that have no dependencies on UI or Infrastructure. These can be defined as simple Data Transfer Objects (DTOs).

> ### Application Core Types
> -   Entities (business model classes that are persisted)
> -   Interfaces
> -   Services
> -   DTOs

The Infrastructure project will typically include data access implementations. In a typical ASP.NET Core web application, this will include the Entity Framework DbContext, any EF Core Migrations that have been defined, and data access implementation classes. The most common way to abstract data access implementation code is through the use of the [Repository design pattern](http://deviq.com/repository-pattern/).

In addition to data access implementations, the Infrastructure project should contain implementations of services that must interact with infrastructure concerns. These services should implement interfaces defined in the Application Core, and so Infrastructure should have a reference to the Application Core project.

> ### Infrastructure Types
> -   EF Core types (DbContext, Migrations)
> -   Data access implementation types (Repositories)
> -   Infrastructure-specific services (FileLogger, SmtpNotifier, etc.)

The user interface layer in an ASP.NET Core MVC application will be the entry point for the application, and will be an ASP.NET Core MVC project. This project should reference the Application Core project, and its types should interact with infrastructure strictly through interfaces defined in Application Core. No direct instantiation of (or static calls to) Infrastructure layer types should be permitted in the UI layer.

> ### UI Layer Types
> -   Controllers
> -   Filters
> -   Views
> -   ViewModels
> -   Startup

The Startup class is responsible for configuring the application, and for wiring up implementation types to interfaces, allowing dependency injection to work properly at run time.

> [!NOTE]
> In order to wire up dependency injection in ConfigureServices in the Startup.cs file of the UI project, the project may need to reference the Infrastructure project. This dependency can be eliminated, most easily by using a custom DI container. For the purposes of this sample, the simplest approach is to allow the UI project to reference the Infrastructure project.

## Monolithic Applications and Containers 

You can build a single and monolithic-deployment based Web Application or Service and deploy it as a container. Within the application, it might not be monolithic but organized into several libraries, components or layers. Externally it is a single container like a single process, single web application or single service.

To manage this model, you deploy a single container to represent the application. To scale, just add additional copies with a load balancer in front. The simplicity comes from managing a single deployment in a single container or VM.

![](./media/image5-13.png)

You can include multiple components/libraries or internal layers within each container, as illustrated in Figure 5-X. But, following the container principal of *"a container does one thing, and does it in one process*", the monolithic pattern might be a conflict.

The downside of this approach comes if/when the application grows, requiring it to scale. If the entire application scaled, it's not really a problem. However, in most cases, a few parts of the application are the choke points requiring scaling, while other components are used less.

Using the typical eCommerce example; what you likely need to scale is the product information component. Many more customers browse products than purchase them. More customers use their basket than use the payment pipeline. Fewer customers add comments or view their purchase history. And you likely only have a handful of employees, in a single region, that need to manage the content and marketing campaigns. By scaling the monolithic design, all the code is deployed multiple times.

In addition to the scale everything problem, changes to a single component require complete retesting of the entire application, and a complete redeployment of all the instances.

The monolithic approach is common, and many organizations are developing with this architectural approach. Many are having good enough results, while others are hitting limits. Many designed their applications in this model, because the tools and infrastructure were too difficult to build service oriented architectures (SOA), and they didn't see the need - until the app grew. If you find you're hitting the limits of the monolithic approach, breaking the app up to enable it to better leverage containers and microservices may be the next logical step.

![](./media/image5-14.png)

Deploying monolithic applications in Microsoft Azure can be achieved using dedicated VMs for each instance. Using [Azure VM Scale Sets](https://docs.microsoft.com/azure/virtual-machine-scale-sets/), you can easily scale the VMs. [Azure App Services](https://azure.microsoft.com/services/app-service/) can run monolithic applications and easily scale instances without having to manage the VMs. Azure App Services can run single instances of Docker containers as well, simplifying the deployment. Using Docker, you can deploy a single VM as a Docker host, and run multiple instances. Using the Azure balancer, as shown in the Figure 5-14, you can manage scaling.

The deployment to the various hosts can be managed with traditional deployment techniques. The Docker hosts can be managed with commands like **docker run** performed manually, or through automation such as Continuous Delivery (CD) pipelines.

### Monolithic application deployed as a container

There are benefits of using containers to manage monolithic application deployments. Scaling the instances of containers is far faster and easier than deploying additional VMs. Even when using VM Scale Sets to scale VMs, they take time to instance. When deployed as app instances, the configuration of the app is managed as part of the VM.

Deploying updates as Docker images is far faster and network efficient. Docker Images typically start in seconds, speeding rollouts. Tearing down a Docker instance is as easy as issuing a **docker stop** command, typically completing in less than a second.

As containers are inherently immutable by design, you never need to worry about corrupted VMs, whereas update scripts might forget to account for some specific configuration or file left on disk.

While monolithic apps can benefit from Docker, breaking up the monolithic application into sub systems which can be scaled, developed and deployed individually may be your entry point into the realm of microservices.

> ### References – Common Web Architectures
> - **The Clean Architecture**  
> <https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html>
> - **The Onion Architecture**  
> <http://jeffreypalermo.com/blog/the-onion-architecture-part-1/>
> - **The Repository Pattern**  
> <http://deviq.com/repository-pattern/>
> - **Clean Architecture Solution Sample**  
> <https://github.com/ardalis/cleanarchitecture>
> - **Architecting Microservices e-book** <http://aka.ms/MicroservicesEbook>

>[!div class="step-by-step"]
[Previous] (architectural-principles.md)
[Next] (common-client-side-web-technologies.md)
