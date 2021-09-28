---
description: "Learn more about: N-Tier and Remote Applications with LINQ to SQL"
title: "N-Tier and Remote Applications with LINQ to SQL"
ms.date: "03/30/2017"
ms.assetid: 854a1cdd-53cb-45f5-83ca-63962a9b3598
---
# N-Tier and Remote Applications with LINQ to SQL

You can create n-tier or multitier applications that use [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. Typically, the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] data context, entity classes, and query construction logic are located on the middle tier as the data access layer (DAL). Business logic and any non-persistent data can be implemented completely in partial classes and methods of entities and the data context, or it can be implemented in separate classes.

 The client or presentation layer calls methods on the middle-tier's remote interface, and the DAL on that tier will execute queries or stored procedures that are mapped to <xref:System.Data.Linq.DataContext> methods. The middle tier returns the data to clients typically as XML representations of entities or proxy objects.

 On the middle tier, entities are created by the data context, which tracks their state, and manages deferred loading from and submission of changes to the database. These entities are "attached" to the `DataContext`. However, after the entities are sent to another tier through serialization, they become detached, which means the `DataContext` is no longer tracking their state. Entities that the client sends back for updates must be reattached to the data context before [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] can submit the changes to the database. The client is responsible for providing original values and/or timestamps back to the middle tier if those are required for optimistic concurrency checks.

 In ASP.NET applications, the <xref:System.Web.UI.WebControls.LinqDataSource> manages most of this complexity. For more information, see [LinqDataSource Web Server Control Overview](/previous-versions/aspnet/bb547113(v=vs.100)).

## Additional Resources

 For more information about how to implement n-tier applications that use [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], see the following topics:

- [LINQ to SQL N-Tier with ASP.NET](linq-to-sql-n-tier-with-aspnet.md)

- [LINQ to SQL N-Tier with Web Services](linq-to-sql-n-tier-with-web-services.md)

- [Implementing N-Tier Business Logic](implementing-business-logic-linq-to-sql.md)

- [Data Retrieval and CUD Operations in N-Tier Applications (LINQ to SQL)](data-retrieval-and-cud-operations-in-n-tier-applications.md)

 For more information about n-tier applications that use ADO.NET DataSets, see [Work with datasets in n-tier applications](/visualstudio/data-tools/work-with-datasets-in-n-tier-applications).

## See also

- [Background Information](background-information.md)
