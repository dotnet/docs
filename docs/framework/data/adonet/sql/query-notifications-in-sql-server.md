---
title: "Query Notifications in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0f0ba1a1-3180-4af8-87f7-c795dc8f8f55
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Query Notifications in SQL Server
Built upon the Service Broker infrastructure, query notifications allow applications to be notified when data has changed. This feature is particularly useful for applications that provide a cache of information from a database, such as a Web application, and need to be notified when the source data is changed.  
  
 There are three ways you can implement query notifications using ADO.NET:  
  
1.  The low-level implementation is provided by the `SqlNotificationRequest` class that exposes server-side functionality, enabling you to execute a command with a notification request.  
  
2.  The high-level implementation is provided by the `SqlDependency` class, which is a class that provides a high-level abstraction of notification functionality between the source application and SQL Server, enabling you to use a dependency to detect changes in the server. In most cases, this is the simplest and most effective way to leverage SQL Server notifications capability by managed client applications using the .NET Framework Data Provider for SQL Server.  
  
3.  In addition, Web applications built using ASP.NET 2.0 or later can use the `SqlCacheDependency` helper classes.  
  
 Query notifications are used for applications that need to refresh displays or caches in response to changes in underlying data. Microsoft SQL Server allows .NET Framework applications to send a command to SQL Server and request notification if executing the same command would produce result sets different from those initially retrieved. Notifications generated at the server are sent through queues to be processed later.  
  
 You can set up notifications for SELECT and EXECUTE statements. When using an EXECUTE statement, SQL Server registers a notification for the command executed rather than the EXECUTE statement itself. The command must meet the requirements and limitations for a SELECT statement. When a command that registers a notification contains more than one statement, the Database Engine creates a notification for each statement in the batch.  
  
 If you are developing an application where you need reliable sub-second notifications when data changes, review the sections **Planning an Efficient Query Notifications Strategy** and **Alternatives to Query Notifications** in the [Planning for Notifications](http://go.microsoft.com/fwlink/?LinkId=211984) topic in SQL Server Books Online. For more information about Query Notifications and SQL Server Service Broker, see the following links to topics in SQL Server Books Online.  
  
 **SQL Server Books Online**  
  
-   [Using Query Notifications](http://msdn.microsoft.com/library/ms175110.aspx)  
  
-   [Creating a Query for Notification](http://msdn.microsoft.com/library/ms181122.aspx)  
  
-   [Service Broker](http://msdn.microsoft.com/library/bb522889.aspx)  
  
-   [Service Broker Developer InfoCenter](http://msdn.microsoft.com/library/ms166100.aspx)  
  
-   [Development (Service Broker)](http://msdn.microsoft.com/library/bb522908.aspx)  
  
## In This Section  
 [Enabling Query Notifications](../../../../../docs/framework/data/adonet/sql/enabling-query-notifications.md)  
 Discusses how to use query notifications, including the requirements for enabling and using them.  
  
 [SqlDependency in an ASP.NET Application](../../../../../docs/framework/data/adonet/sql/sqldependency-in-an-aspnet-app.md)  
 Demonstrates how to use query notifications from an ASP.NET application.  
  
 [Detecting Changes with SqlDependency](../../../../../docs/framework/data/adonet/sql/detecting-changes-with-sqldependency.md)  
 Demonstrates how to detect when query results will be different from those originally received.  
  
 [SqlCommand Execution with a SqlNotificationRequest](../../../../../docs/framework/data/adonet/sql/sqlcommand-execution-with-a-sqlnotificationrequest.md)  
 Demonstrates configuring a <xref:System.Data.SqlClient.SqlCommand> object to work with a query notification.  
  
## Reference  
 <xref:System.Data.Sql.SqlNotificationRequest>  
 Describes the <xref:System.Data.Sql.SqlNotificationRequest> class and all of its members.  
  
 <xref:System.Data.SqlClient.SqlDependency>  
 Describes the <xref:System.Data.SqlClient.SqlDependency> class and all of its members.  
  
 <xref:System.Web.Caching.SqlCacheDependency>  
 Describes the <xref:System.Web.Caching.SqlCacheDependency> class and all of its members.  
  
## See Also  
 [SQL Server and ADO.NET](../../../../../docs/framework/data/adonet/sql/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
