---
title: "Enabling Query Notifications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: a5333e19-8e55-4aa9-82dc-ca8745e516ed
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Enabling Query Notifications
Applications that consume query notifications have a common set of requirements. Your data source must be correctly configured to support SQL query notifications, and the user must have the correct client-side and server-side permissions.  
  
 To use query notifications you must:  
  
-   Enable query notifications for your database.  
  
-   Ensure that the user ID used to connect to the database has the necessary permissions.  
  
-   Use a <xref:System.Data.SqlClient.SqlCommand> object to execute a valid SELECT statement with an associated notification object—either <xref:System.Data.SqlClient.SqlDependency> or <xref:System.Data.Sql.SqlNotificationRequest>.  
  
-   Provide code to process the notification if the data being monitored changes.  
  
## Query Notifications Requirements  
 Query notifications are supported only for SELECT statements that meet a list of specific requirements. The following table provides links to the Service Broker and Query Notifications documentation in SQL Server Books Online.  
  
 **SQL Server Books Online**  
  
-   [Creating a Query for Notification](http://msdn.microsoft.com/library/ms181122.aspx)  
  
-   [Security Considerations for Service Broker](http://msdn.microsoft.com/library/ms166059.aspx)  
  
-   [Security and Protection (Service Broker)](http://msdn.microsoft.com/library/bb522911.aspx)  
  
-   [Security Considerations for Notifications Services](http://msdn.microsoft.com/library/ms172604.aspx)  
  
-   [Query Notification Permissions](http://msdn.microsoft.com/library/ms188311.aspx)  
  
-   [International Considerations for Service Broker](http://msdn.microsoft.com/library/ms166028.aspx)  
  
-   [Solution Design Considerations (Service Broker)](http://msdn.microsoft.com/library/bb522899.aspx)  
  
-   [Service Broker Developer InfoCenter](http://msdn.microsoft.com/library/ms166100.aspx)  
  
-   [Developer's Guide (Service Broker)](http://msdn.microsoft.com/library/bb522908.aspx)  
  
## Enabling Query Notifications to Run Sample Code  
 To enable Service Broker on the **AdventureWorks** database by using SQL Server Management Studio, execute the following Transact-SQL statement:  
  
 `ALTER DATABASE AdventureWorks SET ENABLE_BROKER;`  
  
 For the query notification samples to run correctly, the following Transact-SQL statements must be executed on the database server.  
  
```  
CREATE QUEUE ContactChangeMessages;  
  
CREATE SERVICE ContactChangeNotifications  
  ON QUEUE ContactChangeMessages  
([http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification]);  
```  
  
## Query Notifications Permissions  
 Users who execute commands requesting notification must have SUBSCRIBE QUERY NOTIFICATIONS database permission on the server.  
  
 Client-side code that runs in a partial trust situation requires the <xref:System.Data.SqlClient.SqlClientPermission>.  
  
 The following code creates a <xref:System.Data.SqlClient.SqlClientPermission> object, setting the <xref:System.Security.Permissions.PermissionState> to <xref:System.Security.Permissions.PermissionState.Unrestricted>. The <xref:System.Security.CodeAccessPermission.Demand%2A> will force a <xref:System.Security.SecurityException> at run time if all callers higher in the call stack have not been granted the permission.  
  
 [!code-csharp[DataWorks SqlNotification.Perms#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlNotification.Perms/CS/source.cs#1)]
 [!code-vb[DataWorks SqlNotification.Perms#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlNotification.Perms/VB/source.vb#1)]  
  
## Choosing a Notification Object  
 The query notifications API provides two objects to process notifications: <xref:System.Data.SqlClient.SqlDependency> and <xref:System.Data.Sql.SqlNotificationRequest>. In general, most non-ASP.NET applications should use the <xref:System.Data.SqlClient.SqlDependency> object. ASP.NET applications should use the higher-level <xref:System.Web.Caching.SqlCacheDependency>, which wraps <xref:System.Data.SqlClient.SqlDependency> and provides a framework for administering the notification and cache objects.  
  
### Using SqlDependency  
 To use <xref:System.Data.SqlClient.SqlDependency>, Service Broker must be enabled for the SQL Server database being used, and users must have permissions to receive notifications. Service Broker objects, such as the notification queue, are predefined.  
  
 In addition, <xref:System.Data.SqlClient.SqlDependency> automatically launches a worker thread to process notifications as they are posted to the queue; it also parses the Service Broker message, exposing the information as event argument data. <xref:System.Data.SqlClient.SqlDependency> must be initialized by calling the `Start` method to establish a dependency to the database. This is a static method that needs to be called only once during application initialization for each database connection required. The `Stop` method should be called at application termination for each dependency connection that was made.  
  
### Using SqlNotificationRequest  
 In contrast, <xref:System.Data.Sql.SqlNotificationRequest> requires you to implement the entire listening infrastructure yourself. In addition, all the supporting Service Broker objects such as the queue, service, and message types supported by the queue must be defined. This manual approach is useful if your application requires special notification messages or notification behaviors, or if your application is part of a larger Service Broker application.  
  
## See Also  
 [Query Notifications in SQL Server](../../../../../docs/framework/data/adonet/sql/query-notifications-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
