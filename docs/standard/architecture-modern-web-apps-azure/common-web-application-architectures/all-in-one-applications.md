---
title: All-in-One applications | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | All-in-One applications
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# All-in-One applications

The smallest possible number of projects for an application architecture is one. In this architecture, the entire logic of the application is contained in a single project, compiled to a single assembly, and deployed as a single unit.

A new ASP&period;NET Core project, whether created in Visual Studio or from the command line, starts out as a simple "all-in-one" monolith. It contains all of the behavior of the application, including presentation, business, and data access logic. Figure 5-1 shows the file structure of a single-project app.

**Figure 5-1.** A single project ASP&period;NET Core app

![](./media/image1.png)

In a single project scenario, separation of concerns is achieved through the use of folders. The default template includes separate folders for MVC pattern responsibilities of Models, Views, and Controllers, as well as additional folders for Data and Services. In this arrangement, presentation details should be limited as much as possible to the Views folder, and data access implementation details should be limited to classes kept in the Data folder. Business logic should reside in services and classes within the Models folder.

Although simple, the single-project monolithic solution has some disadvantages. As the project's size and complexity grows, the number of files and folders will continue to grow as well. UI concerns (models, views, controllers) reside in multiple folders, which are not grouped together alphabetically. This issue only gets worse when additional UI-level constructs, such as Filters or ModelBinders, are added in their own folders. Business logic is scattered between the Models and Services folders, and there is no clear indication of which classes in which folders should depend on which others. This lack of organization at the project level frequently leads to [spaghetti code](http://deviq.com/spaghetti-code/).

In order to address these issues, applications often evolve into multi-project solutions, where each project is considered to reside in a particular *layer* of the application.


>[!div class="step-by-step"]
[Previous] (what-is-a-monolithic-application.md)
[Next] (what-are-layers.md)
