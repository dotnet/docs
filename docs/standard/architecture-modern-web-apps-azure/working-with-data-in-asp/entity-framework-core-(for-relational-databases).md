---
title: Entity Framework Core (for relational databases) | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Entity Framework Core (for relational databases)
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Entity Framework Core (for relational databases)

If you're writing a new ASP&period;NET Core application that needs to work with relational data, then Entity Framework Core (EF Core) is the recommended way for your application to access its data. EF Core is an object-relational mapper (O/RM) that enables .NET developers to persist objects to and from a data source. It eliminates the need for most of the data access code developers would typically need to write. Like ASP&period;NET Core, EF Core has been rewritten from the ground up to support modular cross-platform applications. You add it to your application as a NuGet package, configure it in Startup, and request it through dependency injection wherever you need it.

To use EF Core with a SQL Server database, run the following dotnet CLI command:

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

To add support for an InMemory data source, for testing:

dotnet add package Microsoft.EntityFrameworkCore.InMemory

## The DbContext

To work with EF Core, you need a subclass of DbContext. This class holds properties representing collections of the entities your application will work with. The eShopOnWeb sample includes a CatalogContext with collections for items, brands, and types:

```cs
public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {

    }

    public DbSet&lt;CatalogItem&gt; CatalogItems { get; set; }

    public DbSet&lt;CatalogBrand&gt; CatalogBrands { get; set; }

    public DbSet&lt;CatalogType&gt; CatalogTypes { get; set; }
}
```

Your DbContext must have a constructor that accepts DbContextOptions and pass this argument to the base DbContext constructor. Note that if you have only one DbContext in your application, you can pass an instance of DbContextOptions, but if you have more than one you must use the generic DbContextOptions&lt;T&gt; type, passing in your DbContext type as the generic parameter.

## Configuring EF Core

In your ASP&period;NET Core application, you'll typically configure EF Core in your ConfigureServices method. EF Core uses a DbContextOptionsBuilder, which supports several helpful extension methods to streamline its configuration. Tp configure CatalogContext to use a SQL Server database with a connection string defined in Configuration, you would add the following code to ConfigureServices:

```cs
services.AddDbContext<CatalogContext>(options => options.UseSqlServer (Configuration.GetConnectionString("DefaultConnection")));
```

To use the in-memory database:

```cs
services.AddDbContext<CatalogContext>(options =>
    options.UseInMemoryDatabase());
```

Once you have installed EF Core, created a DbContext child type, and configured it in ConfigureServices, you are ready to use EF Core. You can request an instance of your DbContext type in any service that needs it, and start working with your persisted entities using LINQ as if they were simply in a collection. EF Core does the work of translating your LINQ expressions into SQL queries to store and retrieve your data.

You can see the queries EF Core is executing by configuring a logger and ensuring its level is set to at least Information, as shown in Figure 8-X.

![](./media/image1.png)

Figure 8-1 Logging EF Core queries to the console

## Fetching and Storing Data

To retrieve data from EF Core, you access the appropriate property and use LINQ to filter the result. You can also use LINQ to perform projection, transforming the result from one type to another. The following example would retrieve CatalogBrands, ordered by name, filtered by their Enabled property, and projected onto a SelectListItem type:

```cs
var brandItems = await _context.CatalogBrands
    .Where(b => b.Enabled)
    .OrderBy(b => b.Name)
    .Select(b => new SelectListItem {
        Value = b.Id, Text = b.Name })
    .ToListAsync();
```

It's important in the above example to add the call to ToListAsync in order to execute the query immediately. Otherwise, the statement will assign an IQueryable&lt;SelectListItem&gt; to brandItems, which will not be executed until it is enumerated. There are pros and cons to returning IQueryable results from methods. It allows the query EF Core will construct to be further modified, but can also result in errors that only occur at runtime, if operations are added to the query that EF Core cannot translate. It's generally safer to pass any filters into the method performing the data access, and return back an in-memory collection (e.g. List&lt;T&gt;) as the result.

EF Core tracks changes on entities it fetches from persistence. To save changes to a tracked entity, you just call the SaveChanges method on the DbContext, making sure it's the same DbContext instance that was used to fetch the entity. Adding and removing entities is directly on the appropriate DbSet property, again with a call to SaveChanges to execute the database commands. The following example demonstrates adding, updating, and removing entities from persistence.

```cs
// create
var newBrand = new CatalogBrand() { Brand = "Acme" };
_context.Add(newBrand);
await _context.SaveChangesAsync();

// read and update
var existingBrand = _context.CatalogBrands.Find(1);
existingBrand.Brand = "Updated Brand";
await _context.SaveChangesAsync();

// read and delete (alternate Find syntax)
var brandToDelete = _context.Find<CatalogBrand>(2);
_context.CatalogBrands.Remove(brandToDelete);
await _context.SaveChangesAsync();
```

EF Core supports both synchronous and async methods for fetching and saving. In web applications, it's recommended to use the async/await pattern with the async methods, so that web server threads are not blocked while waiting for data access operations to complete.

## Fetching Related Data

When EF Core retrieves entities, it populates all of the properties that are stored directly with that entity in the database. Navigation properties, such as lists of related entities, are not populated and may have their value set to null. This ensures EF Core is not fetching more data than is needed, which is especially important for web applications, which must quickly process requests and return responses in an efficient manner. To include relationships with an entity using *eager loading*, you specify the property using the Include extension method on the query, as shown:

```cs
// .Include requires using Microsoft.EntityFrameworkCore
var brandsWithItems = await _context.CatalogBrands
    .Include(b =&gt; b.Items)
    .ToListAsync();
```

You can include multiple relationships, and you can also include sub-relationships using ThenInclude. EF Core will execute a single query to retrieve the resulting set of entities.

Another option for loading related data is to use *explicit loading*. Explicit loading allows you to load additional data into an entity that has already been retrieved. Since this involves a separate request to the database, it's not recommended for web applications, which should minimize the number of database round trips made per request.

*Lazy loading* is a feature that automatically loads related data as it is referenced by the application. It's not currently supported by EF Core, but as with explicit loading it should typically be disabled for web applications.

## Resilient Connections

External resources like SQL databases may occasionally be unavailable. In cases of temporary unavailability, applications can use retry logic to avoid raising an exception. This technique is commonly referred to as *connection resiliency*. You can implement your [own retry with exponential backoff](https://docs.microsoft.com/en-us/azure/architecture/patterns/retry) technique by attempting to rety with an exponentially increasing wait time, until a maximum retry count has been reached. This technique embraces the fact that cloud resources might intermittently be unavailable for short periods of time, resulting in failure of some requests.

For Azure SQL DB, Entity Framework Core already provides internal database connection resiliency and retry logic. But you need to enable the Entity Framework execution strategy for each DbContext connection if you want to have resilient EF Core connections.

For instance, the following code at the EF Core connection level enables resilient SQL connections that are retried if the connection fails.

```cs
// Startup.cs from any ASP.NET Core Web API
public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        //...
        services.AddDbContext<OrderingContext>(options =>
        {
            options.UseSqlServer(Configuration["ConnectionString"],
            sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30), 
            errorNumbersToAdd: null); 
        });
    });
}
//...
```

  ### Execution strategies and explicit transactions using BeginTransaction and multiple DbContexts 
  
  When retries are enabled in EF Core connections, each operation you perform using EF Core becomes its own retriable operation. Each query and each call to SaveChanges will be retried as a unit if a transient failure occurs.
  
  However, if your code initiates a transaction using BeginTransaction, you are defining your own group of operations that need to be treated as a unit—everything inside the transaction has be rolled back if a failure occurs. You will see an exception like the following if you attempt to execute that transaction when using an EF execution strategy (retry policy) and you include several SaveChanges from multiple DbContexts in it.

System.InvalidOperationException: The configured execution strategy 'SqlServerRetryingExecutionStrategy' does not support user initiated transactions. Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.

The solution is to manually invoke the EF execution strategy with a delegate representing everything that needs to be executed. If a transient failure occurs, the execution strategy will invoke the delegate again. The following code shows how to implement this approach:

```cs
// Use of an EF Core resiliency strategy when using multiple DbContexts
// within an explicit transaction
// See:
// https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
var strategy = _catalogContext.Database.CreateExecutionStrategy(); 
await strategy.ExecuteAsync(async () =>
{
    // Achieving atomicity between original Catalog database operation and the
    // IntegrationEventLog thanks to a local transaction
    using (var transaction = _catalogContext.Database.BeginTransaction())
    {
        _catalogContext.CatalogItems.Update(catalogItem);
        await _catalogContext.SaveChangesAsync();
        
        // Save to EventLog only if product price changed
        if (raiseProductPriceChangedEvent)
        await _integrationEventLogService.SaveEventAsync(priceChangedEvent);
        transaction.Commit();
    }
});
```

The first DbContext is the \_catalogContext and the second DbContext is within the \_integrationEventLogService object. Finally, the Commit action would be performed multiple DbContexts and using an EF Execution Strategy.

> ### References – Entity Framework Core
> - **EF Core Docs**  
> <https://docs.microsoft.com/en-us/ef/>
> - **EF Core: Related Data**  
> <https://docs.microsoft.com/en-us/ef/core/querying/related-data>
> - **Avoid Lazy Loading Entities in ASPNET Applications**  
> <http://ardalis.com/avoid-lazy-loading-entities-in-asp-net-applications>


>[!div class="step-by-step"]
[Previous] (summary.md)
[Next] (ef-core-or-micro-orm.md)
