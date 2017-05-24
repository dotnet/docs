---
title: Application tour | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Application tour
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Application tour

You can load the Catalog.WebForms solution and run the application as a standalone application. In this configuration, instead of a persistent storage database, the application uses a fake service to return data. The application uses Autofac (<https://autofac.org/>) as an inversion of control (IOC) container. Using Dependency Injection (DI), you can configure the application to use the fake data or the live catalog data service. (We will explain more about DI shortly.) The startup code reads a useFake setting from the web.config files, and configures the Autofac container to inject either the fake data service or the live catalog service. If you run the application with useFake set to false in the web.config file, you see the Web Forms application displaying the catalog data.

Most of the techniques used in this application should be very familiar to anyone who has used Web Forms. However, the catalog microservice introduces two techniques that might be unfamiliar: Dependency Injection (DI), which was mentioned earlier, and working with asynchronous data stores in Web Forms.

DI inverts the typical object-oriented strategy of writing classes that allocate all needed resources. Instead, classes request their dependencies from a service container. The advantage of DI is that you can replace external services with fakes (mocks) to support testing or other environments.

The DI container uses the web.config appSettings configuration to control whether to use the fake catalog data or the live data from the running service. The application registers an HttpModule object that builds the container and registers a pre-request handler to inject dependencies. You can see that code in the Modules/AutoFacHttpModule.cs file, which looks like the following example:

  ---------------------------------------------------------------
  private static IContainer CreateContainer()
  
  {
  
  // Configure AutoFac:
  
  // Register Containers:
  
  var settings = WebConfigurationManager.AppSettings;
  
  var useFake = settings\["usefake"\];
  
  bool fake = useFake == "true";
  
  var builder = new ContainerBuilder();
  
  if (fake)
  
  {
  
  builder.RegisterType&lt;CatalogMockService&gt;()
  
  .As&lt;ICatalogService&gt;();
  
  }
  
  else
  
  {
  
  builder.RegisterType&lt;CatalogService&gt;()
  
  .As&lt;ICatalogService&gt;();
  
  builder.RegisterType&lt;RequestProvider&gt;()
  
  .As&lt;IRequestProvider&gt;();
  
  }
  
  var container = builder.Build();
  
  return container;
  
  }
  
  private void InjectDependencies()
  
  {
  
  if (HttpContext.Current.CurrentHandler is Page page)
  
  {
  
  // Get the code-behind class that we may have written
  
  var pageType = page.GetType().BaseType;
  
  // Determine if there is a constructor to inject, and grab it
  
  var ctor = (from c in pageType.GetConstructors()
  
  where c.GetParameters().Length &gt; 0
  
  select c).FirstOrDefault();
  
  if (ctor != null)
  
  {
  
  // Resolve the parameters for the constructor
  
  var args = (from parm in ctor.GetParameters()
  
  select Container.Resolve(parm.ParameterType))
  
  .ToArray();
  
  // Execute the constructor method with the arguments resolved
  
  ctor.Invoke(page, args);
  
  }
  
  // Use the Autofac method to inject any
  
  // properties that can be filled by Autofac
  
  Container.InjectProperties(page);
  
  }
  
  }
  ---------------------------------------------------------------

The application’s pages (Default.aspx.cs and EditPage.aspx.cs) define constructors that take these dependencies. Note that the default constructor is still present and accessible. The infrastructure needs the following code.

  -------------------------------------------------
  protected \_Default() { }
  
  public \_Default(ICatalogService catalog) =&gt;
  
  this.catalog = catalog;
  -------------------------------------------------

The catalog APIs are all asynchronous methods. Web Forms now supports these for all data controls. The Catalog.WebForms application uses model binding for the list and edit pages; controls on the pages define SelectMethod, UpdateMethod, InsertMethod, and DeleteMethod properties that specify Task-returning asynchronous operations. Web Forms controls understand when the methods bound to a control are asynchronous. The only restriction you encounter when using asynchronous select methods is that you cannot support paging. The paging signature requires an out parameter, and asynchronous methods cannot have out parameters. This same technique is used on other pages that require data from the catalog service.

The default configuration for the catalog Web Forms application uses a mock implementation of the catalog.api service. This mock uses a hard-coded dataset for its data, which simplifies some tasks by removing the dependency on the catalog.api service in development environments.


>[!div class="step-by-step"]
[Previous] (possible-migration-paths.md)
[Next] (lifting-and-shifting.md)
