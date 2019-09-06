---
title: "Enabling Query Notifications"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: a5333e19-8e55-4aa9-82dc-ca8745e516ed
---
# Enabling Query Notifications
Applications that consume query notifications have a common set of requirements. Your data source must be correctly configured to support SQL query notifications, and the user must have the correct client-side and server-side permissions.  
  
 To use query notifications you must:  
  
- Enable query notifications for your database.  
  
- Ensure that the user ID used to connect to the database has the necessary permissions.  
  
- Use a <xref:System.Data.SqlClient.SqlCommand> object to execute a valid SELECT statement with an associated notification object—either <xref:System.Data.SqlClient.SqlDependency> or <xref:System.Data.Sql.SqlNotificationRequest>.  
  
- Provide code to process the notification if the data being monitored changes.  
  
## Query Notifications Requirements  
 Query notifications are supported only for SELECT statements that meet a list of specific requirements. The following table provides links to the Service Broker and Query Notifications documentation in SQL Server Books Online.  
  
 **SQL Server documentation**  
  
- [Creating a Query for Notification](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/ms181122(v=sql.105))  
  
- [Security Considerations for Service Broker](https://docs.microsoft.com/previous-versions/sql/sql-server-2005/ms166059(v=sql.90))  
  
- [Security and Protection (Service Broker)](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/bb522911(v=sql.105))  
  
- [Security Considerations for Notifications Services](https://docs.microsoft.com/previous-versions/sql/sql-server-2005/ms172604(v=sql.90))  
  
- [Query Notification Permissions](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/ms188311(v=sql.105))  
  
- [International Considerations for Service Broker](https://docs.microsoft.com/previous-versions/sql/sql-server-2005/ms166028(v=sql.90))  
  
- [Solution Design Considerations (Service Broker)](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/bb522899(v=sql.105))  
  
- [Service Broker Developer InfoCenter](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/ms166100(v=sql.105))  
  
- [Developer's Guide (Service Broker)](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/bb522908(v=sql.105))  
  
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
  
## See also

- [Query Notifications in SQL Server](query-notifications-in-sql-server.md)
- [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
