---
title: "Performance Considerations (Entity Framework)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 61913f3b-4f42-4d9b-810f-2a13c2388a4a
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Performance Considerations (Entity Framework)
This topic describes performance characteristics of the ADO.NET Entity Framework and provides some considerations to help improve the performance of Entity Framework applications.  
  
## Stages of Query Execution  
 In order to better understand the performance of queries in the Entity Framework, it is helpful to understand the operations that occur when a query executes against a conceptual model and returns data as objects. The following table describes this series of operations.  
  
|Operation|Relative Cost|Frequency|Comments|  
|---------------|-------------------|---------------|--------------|  
|Loading metadata|Moderate|Once in each application domain.|Model and mapping metadata used by the Entity Framework is loaded into a <xref:System.Data.Metadata.Edm.MetadataWorkspace>. This metadata is cached globally and is available to other instances of <xref:System.Data.Objects.ObjectContext> in the same application domain.|  
|Opening the database connection|Moderate<sup>1</sup>|As needed.|Because an open connection to the database consumes a valuable resource, the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] opens and closes the database connection only as needed. You can also explicitly open the connection. For more information, see [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99).|  
|Generating views|High|Once in each application domain. (Can be pre-generated.)|Before the Entity Framework can execute a query against a conceptual model or save changes to the data source, it must generate a set of local query views to access the database. Because of the high cost of generating these views, you can pre-generate the views and add them to the project at design-time. For more information, see [How to: Pre-Generate Views to Improve Query Performance](http://msdn.microsoft.com/library/b18a9d16-e10b-4043-ba91-b632f85a2579).|  
|Preparing the query|Moderate<sup>2</sup>|Once for each unique query.|Includes the costs to compose the query command, generate a command tree based on model and mapping metadata, and define the shape of the returned data. Because now both Entity SQL query commands and LINQ queries are cached, later executions of the same query take less time. You can still use compiled LINQ queries to reduce this cost in later executions and compiled queries can be more efficient than LINQ queries that are automatically cached. For more information, see [Compiled Queries  (LINQ to Entities)](../../../../../docs/framework/data/adonet/ef/language-reference/compiled-queries-linq-to-entities.md). For general information about LINQ query execution, see [LINQ to Entities](../../../../../docs/framework/data/adonet/ef/language-reference/linq-to-entities.md). **Note:**  LINQ to Entities queries that apply the `Enumerable.Contains` operator to in-memory collections are not automatically cached. Also parameterizing in-memory collections in compiled LINQ queries is not allowed.|  
|Executing the query|Low<sup>2</sup>|Once for each query.|The cost of executing the command against the data source by using the ADO.NET data provider. Because most data sources cache query plans, later executions of the same query may take even less time.|  
|Loading and validating types|Low<sup>3</sup>|Once for each <xref:System.Data.Objects.ObjectContext> instance.|Types are loaded and validated against the types that the conceptual model defines.|  
|Tracking|Low<sup>3</sup>|Once for each object that a query returns. <sup>4</sup>|If a query uses the <xref:System.Data.Objects.MergeOption.NoTracking> merge option, this stage does not affect performance.<br /><br /> If the query uses the <xref:System.Data.Objects.MergeOption.AppendOnly>, <xref:System.Data.Objects.MergeOption.PreserveChanges>, or <xref:System.Data.Objects.MergeOption.OverwriteChanges> merge option, query results are tracked in the <xref:System.Data.Objects.ObjectStateManager>. An <xref:System.Data.EntityKey> is generated for each tracked object that the query returns and is used to create an <xref:System.Data.Objects.ObjectStateEntry> in the <xref:System.Data.Objects.ObjectStateManager>. If an existing <xref:System.Data.Objects.ObjectStateEntry> can be found for the <xref:System.Data.EntityKey>, the existing object is returned. If the <xref:System.Data.Objects.MergeOption.PreserveChanges>, or <xref:System.Data.Objects.MergeOption.OverwriteChanges> option is used, the object is updated before it is returned.<br /><br /> For more information, see [Identity Resolution, State Management, and Change Tracking](http://msdn.microsoft.com/library/3bd49311-0e72-4ea4-8355-38fe57036ba0).|  
|Materializing the objects|Moderate<sup>3</sup>|Once for each object that a query returns. <sup>4</sup>|The process of reading the returned <xref:System.Data.Common.DbDataReader> object and creating objects and setting property values that are based on the values in each instance of the <xref:System.Data.Common.DbDataRecord> class. If the object already exists in the <xref:System.Data.Objects.ObjectContext> and the query uses the <xref:System.Data.Objects.MergeOption.AppendOnly> or <xref:System.Data.Objects.MergeOption.PreserveChanges> merge options, this stage does not affect performance. For more information, see [Identity Resolution, State Management, and Change Tracking](http://msdn.microsoft.com/library/3bd49311-0e72-4ea4-8355-38fe57036ba0).|  
  
 <sup>1</sup> When a data source provider implements connection pooling, the cost of opening a connection is distributed across the pool. The .NET Provider for SQL Server supports connection pooling.  
  
 <sup>2</sup> Cost increases with increased query complexity.  
  
 <sup>3</sup> Total cost increases proportional to the number of objects returned by the query.  
  
 <sup>4</sup> This overhead is not required for EntityClient queries because EntityClient queries return an <xref:System.Data.EntityClient.EntityDataReader> instead of objects. For more information, see [EntityClient Provider for the Entity Framework](../../../../../docs/framework/data/adonet/ef/entityclient-provider-for-the-entity-framework.md).  
  
## Additional Considerations  
 The following are other considerations that may affect the performance of Entity Framework applications.  
  
### Query Execution  
 Because queries can be resource intensive, consider at what point in your code and on what computer a query is executed.  
  
#### Deferred versus immediate execution  
 When you create an <xref:System.Data.Objects.ObjectQuery%601> or LINQ query, the query may not be executed immediately. Query execution is deferred until the results are needed, such as during a `foreach` (C#) or `For Each` (Visual Basic) enumeration or when it is assigned to fill a <xref:System.Collections.Generic.List%601> collection. Query execution begins immediately when you call the <xref:System.Data.Objects.ObjectQuery%601.Execute%2A> method on an <xref:System.Data.Objects.ObjectQuery%601> or when you call a LINQ method that returns a singleton query, such as <xref:System.Linq.Enumerable.First%2A> or <xref:System.Linq.Enumerable.Any%2A>. For more information, see [Object Queries](http://msdn.microsoft.com/library/0768033c-876f-471d-85d5-264884349276) and [Query Execution (LINQ to Entities)](../../../../../docs/framework/data/adonet/ef/language-reference/query-execution.md).  
  
#### Client-side execution of LINQ queries  
 Although the execution of a LINQ query occurs on the computer that hosts the data source, some parts of a LINQ query may be evaluated on the client computer. For more information, see the Store Execution section of [Query Execution (LINQ to Entities)](../../../../../docs/framework/data/adonet/ef/language-reference/query-execution.md).  
  
### Query and Mapping Complexity  
 The complexity of individual queries and of the mapping in the entity model will have a significant effect on query performance.  
  
#### Mapping complexity  
 Models that are more complex than a simple one-to-one mapping between entities in the conceptual model and tables in the storage model generate more complex commands than models that have a one-to-one mapping.  
  
#### Query complexity  
 Queries that require a large number of joins in the commands that are executed against the data source or that return a large amount of data may affect performance in the following ways:  
  
-   Queries against a conceptual model that seem simple may result in the execution of more complex queries against the data source. This can occur because the Entity Framework translates a query against a conceptual model into an equivalent query against the data source. When a single entity set in the conceptual model maps to more than one table in the data source, or when a relationship between entities is mapped to a join table, the query command executed against the data source query may require one or more joins.  
  
    > [!NOTE]
    >  Use the <xref:System.Data.Objects.ObjectQuery.ToTraceString%2A> method of the <xref:System.Data.Objects.ObjectQuery%601> or <xref:System.Data.EntityClient.EntityCommand> classes to view the commands that are executed against the data source for a given query. For more information, see [How to: View the Store Commands](http://msdn.microsoft.com/library/f9771c6e-3b62-4b24-a5d4-55d68e14fa79).  
  
-   Nested Entity SQL queries may create joins on the server and can return a large number of rows.  
  
     The following is an example of a nested query in a projection clause:  
  
    ```  
    SELECT c, (SELECT c, (SELECT c FROM AdventureWorksModel.Vendor AS c  ) As Inner2   
        FROM AdventureWorksModel.JobCandidate AS c  ) As Inner1   
        FROM AdventureWorksModel.EmployeeDepartmentHistory AS c  
    ```  
  
     In addition, such queries cause the query pipeline to generate a single query with duplication of objects across nested queries. Because of this, a single column may be duplicated multiple times. On some databases, including SQL Server, this can cause the TempDB table to grow very large, which can decrease server performance. Care should be taken when you execute nested queries.  
  
-   Any queries that return a large amount of data can cause decreased performance if the client is performing operations that consume resources in a way that is proportional to the size of the result set. In such cases, you should consider limiting the amount of data returned by the query. For more information, see [How to: Page Through Query Results](http://msdn.microsoft.com/library/ffc0f920-e7de-42e0-9b12-ef356421d030).  
  
 Any commands automatically generated by the Entity Framework may be more complex than similar commands written explicitly by a database developer. If you need explicit control over the commands executed against your data source, consider defining a mapping to a table-valued function or stored procedure.  
  
#### Relationships  
 For optimal query performance, you must define relationships between entities both as associations in the entity model and as logical relationships in the data source.  
  
### Query Paths  
 By default, when you execute an <xref:System.Data.Objects.ObjectQuery%601>, related objects are not returned (although objects that represent the relationships themselves are). You can load related objects in one of three ways:  
  
1.  Set the query path before the <xref:System.Data.Objects.ObjectQuery%601> is executed.  
  
2.  Call the `Load` method on the navigation property that the object exposes.  
  
3.  Set the <xref:System.Data.Objects.ObjectContextOptions.LazyLoadingEnabled%2A> option on the <xref:System.Data.Objects.ObjectContext> to `true`. Note that this is done automatically when you generate object-layer code with the [Entity Data Model Designer](http://msdn.microsoft.com/library/4ccd7ad6-b934-4f7c-82a0-cfd2d4a95faf). For more information see [Generated Code Overview](http://msdn.microsoft.com/library/6a88ea38-6a90-4107-bc33-531b79ce5b6a).  
  
 When you consider which option to use, be aware that there is a tradeoff between the number of requests against the database and the amount of data returned in a single query. For more information, see [Loading Related Objects](http://msdn.microsoft.com/library/452347d2-7b3b-44cd-9001-231299a28cb1).  
  
#### Using query paths  
 Query paths define the graph of objects that a query returns. When you define a query path, only a single request against the database is required to return all objects that the path defines. Using query paths can result in complex commands being executed against the data source from seemingly simple object queries. This occurs because one or more joins are required to return related objects in a single query. This complexity is greater in queries against a complex entity model, such as an entity with inheritance or a path that includes many-to-many relationships.  
  
> [!NOTE]
>  Use the <xref:System.Data.Objects.ObjectQuery.ToTraceString%2A> method to see the command that will be generated by an <xref:System.Data.Objects.ObjectQuery%601>. For more information, see [How to: View the Store Commands](http://msdn.microsoft.com/library/f9771c6e-3b62-4b24-a5d4-55d68e14fa79).  
  
 When a query path includes too many related objects or the objects contain too much row data, the data source might be unable to complete the query. This occurs if the query requires intermediate temporary storage that exceeds the capabilities of the data source. When this occurs, you can reduce the complexity of the data source query by explicitly loading related objects.  
  
#### Explicitly loading related objects  
 You can explicitly load related objects by calling the `Load` method on a navigation property that returns an <xref:System.Data.Objects.DataClasses.EntityCollection%601> or <xref:System.Data.Objects.DataClasses.EntityReference%601>. Explicitly loading objects requires a round-trip to the database every time `Load` is called.  
  
> [!NOTE]
>  if you call `Load` while looping through a collection of returned objects, such as when you use the `foreach` statement (`For Each` in Visual Basic), the data source-specific provider must support multiple active results sets on a single connection. For a SQL Server database, you must specify a value of `MultipleActiveResultSets = true` in the provider connection string.  
  
 You can also use the <xref:System.Data.Objects.ObjectContext.LoadProperty%2A> method when there is no <xref:System.Data.Objects.DataClasses.EntityCollection%601> or <xref:System.Data.Objects.DataClasses.EntityReference%601> properties on entities. This is useful when you are using POCO entities.  
  
 Although explicitly loading related objects will reduce the number of joins and reduced the amount of redundant data, `Load` requires repeated connections to the database, which can become costly when explicitly loading a large number of objects.  
  
### Saving Changes  
 When you call the <xref:System.Data.Objects.ObjectContext.SaveChanges%2A> method on an <xref:System.Data.Objects.ObjectContext>, a separate create, update, or delete command is generated for every added, updated, or deleted object in the context. These commands are executed on the data source in a single transaction. As with queries, the performance of create, update, and delete operations depends on the complexity of the mapping in the conceptual model.  
  
### Distributed Transactions  
 Operations in an explicit transaction that require resources that are managed by the distributed transaction coordinator (DTC) will be much more expensive than a similar operation that does not require the DTC. Promotion to the DTC will occur in the following situations:  
  
-   An explicit transaction with an operation against a SQL Server 2000 database or other data source that always promote explicit transactions to the DTC.  
  
-   An explicit transaction with an operation against SQL Server 2005 when the connection is managed by the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)]. This occurs because SQL Server 2005 promotes to a DTC whenever a connection is closed and reopened within a single transaction, which is the default behavior of the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)]. This DTC promotion does not occur when using SQL Server 2008. To avoid this promotion when using SQL Server 2005, you must explicitly open and close the connection within the transaction. For more information, see [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99).  
  
 An explicit transaction is used when one or more operations are executed inside a <xref:System.Transactions> transaction. For more information, see [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99).  
  
## Strategies for Improving Performance  
 You can improve the overall performance of queries in the Entity Framework by using the following strategies.  
  
#### Pre-generate views  
 Generating views based on an entity model is a significant cost the first time that an application executes a query. Use the EdmGen.exe utility to pre-generate views as a Visual Basic or C# code file that can be added to the project during design. You could also use the Text Template Transformation Toolkit to generate pre-compiled views. Pre-generated views are validated at runtime to ensure that they are consistent with the current version of the specified entity model. For more information, see [How to: Pre-Generate Views to Improve Query Performance](http://msdn.microsoft.com/library/b18a9d16-e10b-4043-ba91-b632f85a2579) and [Isolating Performance with Precompiled/Pre-generated Views in the Entity Framework 4](http://go.microsoft.com/fwlink/?LinkID=201337&clcid=0x409).  
  
 When working with very large models, the following consideration applies:  
  
 The .NET metadata format limits the number of user string characters in a given binary to 16,777,215 (0xFFFFFF). If you are generating views for a very large model and the view file reaches this size limit, you will get the "No logical space left to create more user strings." compile error. This size limitation applies to all managed binaries. For more information see the [blog](http://go.microsoft.com/fwlink/?LinkId=201476) that demonstrates how to avoid the error when working with large and complex models.  
  
#### Consider using the NoTracking merge option for queries  
 There is a cost required to track returned objects in the object context. Detecting changes to objects and ensuring that multiple requests for the same logical entity return the same object instance requires that objects be attached to an <xref:System.Data.Objects.ObjectContext> instance. If you do not plan to make updates or deletes to objects and do not require identity management , consider using the <xref:System.Data.Objects.MergeOption.NoTracking> merge options when you execute queries.  
  
#### Return the correct amount of data  
 In some scenarios, specifying a query path using the <xref:System.Data.Objects.ObjectQuery%601.Include%2A> method is much faster because it requires fewer round trips to the database. However, in other scenarios, additional round trips to the database to load related objects may be faster because the simpler queries with fewer joins result in less redundancy of data. Because of this, we recommend that you test the performance of various ways to retrieve related objects. For more information, see [Loading Related Objects](http://msdn.microsoft.com/library/452347d2-7b3b-44cd-9001-231299a28cb1).  
  
 To avoid returning too much data in a single query, consider paging the results of the query into more manageable groups. For more information, see [How to: Page Through Query Results](http://msdn.microsoft.com/library/ffc0f920-e7de-42e0-9b12-ef356421d030).  
  
#### Limit the scope of the ObjectContext  
 In most cases, you should create an <xref:System.Data.Objects.ObjectContext> instance within a `using` statement (`Using…End Using` in Visual Basic). This can increase performance by ensuring that the resources associated with the object context are disposed automatically when the code exits the statement block. However, when controls are bound to objects managed by the object context, the <xref:System.Data.Objects.ObjectContext> instance should be maintained as long as the binding is needed and disposed of manually. For more information, see [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99).  
  
#### Consider opening the database connection manually  
 When your application executes a series of object queries or frequently calls <xref:System.Data.Objects.ObjectContext.SaveChanges%2A> to persist create, update, and delete operations to the data source, the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] must continuously open and close the connection to the data source. In these situations, consider manually opening the connection at the start of these operations and either closing or disposing of the connection when the operations are complete. For more information, see [Managing Connections and Transactions](http://msdn.microsoft.com/library/b6659d2a-9a45-4e98-acaa-d7a8029e5b99).  
  
## Performance Data  
 Some performance data for the Entity Framework is published in the following posts on the [ADO.NET team blog](http://go.microsoft.com/fwlink/?LinkId=91905):  
  
-   [Exploring the Performance of the ADO.NET Entity Framework - Part 1](http://go.microsoft.com/fwlink/?LinkId=123907)  
  
-   [Exploring the Performance of the ADO.NET Entity Framework – Part 2](http://go.microsoft.com/fwlink/?LinkId=123909)  
  
-   [ADO.NET Entity Framework Performance Comparison](http://go.microsoft.com/fwlink/?LinkID=123913)  
  
## See Also  
 [Development and Deployment Considerations](../../../../../docs/framework/data/adonet/ef/development-and-deployment-considerations.md)
