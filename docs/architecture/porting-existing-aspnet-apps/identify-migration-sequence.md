---
title: Identifying sequence of projects to migrate
description: 
author: ardalis
ms.date: 11/13/2020
---

# Identifying sequence of projects to migrate

For solutions that involve multiple front end apps, it's usually best to migrate these one by one. It may make sense to create a solution that only includes one front end app and its dependencies so you can easily identify the scope of work involved. Solutions are very lightweight and you can include projects in multiple solutions if needed, so take advantage of them as an organizational tool when migrating.

Once you've identified the ASP.NET app you wish to migrate and have its dependent projects located with it (ideally in a solution), the next step is to identify framework and NuGet dependencies. Having identified all dependencies, the simplest migration approach is a "bottom up" approach, in which the lowest level dependencies are migrated first, then the next level of dependencies, until eventually the only thing left is the front end app. Figure 3-1 shows an example set of projects composing an app, with low-level class libraries at the bottom and the ASP.NET MVC project at the top.

![Project dependencies](./media/Figure3-1.png)

Choose a particular front end application, an ASP.NET MVC 5 / Web API 2 project. Identify its dependencies in the solution, and map out their dependencies until you have a complete list. A diagram like the one shown in Figure 3-1 may be useful when mapping out project dependencies.

Once you've mapped out the projects and their relationships with one another, you're ready to begin plan the order in which you'll migrate the projects. You typically want to begin with projects that have no dependencies, and then work your way up the tree to the projects that depend on these projects.

In the example shown in Figure 3-1, you would start with the "Contoso.Utils" project, since it doesn't depend on any other projects. Next, "Contoso.Data" since it only depends on "Utils". Then migrate the "BusinessLogic" library, and finally the front end ASP.NET "Web" project. Following this "bottom up" approach works well for relatively small and well-factored apps that can be migrated as a unit once all of their projects have migrated. Larger apps with more complexity or just more code that will take longer to migrate may need to consider more incremental strategies.

>[!div class="step-by-step"]
>[Previous](migrating-large-solutions.md)
>[Next](understand-update-dependencies.md)
