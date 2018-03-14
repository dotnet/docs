---
title: "LINQ to SQL N-Tier with Web Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9cb10eb8-957f-4beb-a271-5f682016fed2
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# LINQ to SQL N-Tier with Web Services
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] is designed especially for use on the middle tier in a loosely-coupled data access layer (DAL) such as a Web service. If the presentation tier is an ASP.NET Web page, then you use the <xref:System.Web.UI.WebControls.LinqDataSource> Web server control to manage the data transfer between the user interface and [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] on the middle-tier. If the presentation tier is not an ASP.NET page, then both the middle-tier and the presentation tier must do some additional work to manage the serialization and deserialization of data.  
  
## Setting up LINQ to SQL on the Middle Tier  
 In a Web service or n-tier application, the middle tier contains the data context and the entity classes. You can create these classes manually, or by using either SQLMetal.exe or the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] as described elsewhere in the documentation. At design time, you have the option to make the entity classes serializable. For more information, see [How to: Make Entities Serializable](../../../../../../docs/framework/data/adonet/sql/linq/how-to-make-entities-serializable.md). Another option is to create a separate set of classes that encapsulate the data to be serialized, and then project into those serializable types when you return data in your [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)] queries.  
  
 You then define the interface with the methods that the clients will call to retrieve, insert and update data. The interface methods wrap your [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)] queries. You can use any kind of serialization mechanism to handle the remote method calls and the serialization of data. The only requirement is that if you have cyclic or bi-directional relationships in your object model, such as that between Customers and Orders in the standard Northwind object model, then you must use a serializer that supports it. The Windows Communication Foundation (WCF) <xref:System.Runtime.Serialization.DataContractSerializer> supports bi-directional relationships but the XmlSerializer that is used with non-WCF Web services does not. If you select to use the XmlSerializer, then you must make sure that your object model has no cyclic relationships.  
  
 For more information about Windows Communication Foundation, see [Windows Communication Foundation Services and WCF Data Services in Visual Studio](/visualstudio/data-tools/windows-communication-foundation-services-and-wcf-data-services-in-visual-studio).  
  
 Implement your business rules or other domain-specific logic by using the partial classes and methods on the <xref:System.Data.Linq.DataContext> and entity classes to hook into [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] runtime events. For more information, see [Implementing N-Tier Business Logic](../../../../../../docs/framework/data/adonet/sql/linq/implementing-business-logic-linq-to-sql.md).  
  
## Defining the Serializable Types  
 The client or presentation tier must have type definitions for the classes that it will be receiving from the middle tier. Those types may be the entity classes themselves, or special classes that wrap only certain fields from the entity classes for remoting. In any case, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] is completely unconcerned about how the presentation tier acquires those type definitions. For example, the presentation tier could use WCF to generate the types automatically, or it could have a copy of a DLL in which those types are defined, or it could just define its own versions of the types.  
  
## Retrieving and Inserting Data  
 The middle tier defines an interface that specifies how the presentation tier accesses the data. For example `GetProductByID(int productID)`, or `GetCustomers()`. On the middle tier, the method body typically creates a new instance of the <xref:System.Data.Linq.DataContext>, executes a query against one or more of its table. The middle tier then returns the result as an <xref:System.Collections.Generic.IEnumerable%601>, where `T` is either an entity class or another type that is used for serialization. The presentation tier never sends or receives query variables directly to or from the middle tier. The two tiers exchange values, objects, and collections of concrete data. After it has received a collection, the presentation tier can use [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)] to Objects to query it if necessary.  
  
 When inserting data, the presentation tier can construct a new object and send it to the middle tier, or it can have the middle tier construct the object based on values that it provides. In general, retrieving and inserting data in n-tier applications does not differ much from the process in 2-tier applications. For more information, see [Querying the Database](../../../../../../docs/framework/data/adonet/sql/linq/querying-the-database.md) and [Making and Submitting Data Changes](../../../../../../docs/framework/data/adonet/sql/linq/making-and-submitting-data-changes.md).  
  
## Tracking Changes for Updates and Deletes  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports optimistic concurrency based on timestamps (also named RowVersions) and on original values. If the database tables have timestamps, then updates and deletions require little extra work on either the middle-tier or presentation tier. However, if you must use original values for optimistic concurrency checks, then the presentation tier is responsible for tracking those values and sending them back when it makes updates. This is because changes that were made to entities on the presentation tier are not tracked on the middle tier. In fact, the original retrieval of an entity, and the eventual update made to it are typically performed by two completely separate instances of the <xref:System.Data.Linq.DataContext>.  
  
 The greater the number of changes that the presentation tier makes, the more complex it becomes to track those changes and package them back to the middle tier. The implementation of a mechanism for communicating changes is completely up to the application. The only requirement is that [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] must be given those original values that are required for optimistic concurrency checks.  
  
 For more information, see [Data Retrieval and CUD Operations in N-Tier Applications (LINQ to SQL)](../../../../../../docs/framework/data/adonet/sql/linq/data-retrieval-and-cud-operations-in-n-tier-applications.md).  
  
## See Also  
 [N-Tier and Remote Applications with LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/n-tier-and-remote-applications-with-linq-to-sql.md)  
 [NIB: LinqDataSource Web Server Control Overview](http://msdn.microsoft.com/library/104cfc3f-7385-47d3-8a51-830dfa791136)
