---
description: "Learn more about: Enabling Query Notifications"
title: "Enabling Query Notifications"
ms.date: "10/23/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: a5333e19-8e55-4aa9-82dc-ca8745e516ed
---
# Enabling Query Notifications

To use query notifications, configure your database to support them and grant the database principal the required permissions.

 To use query notifications you must:

- Enable query notifications for your database.

- Ensure that the user ID used to connect to the database has the necessary permissions.

- Use <xref:Microsoft.Data.SqlClient.SqlCommand> to execute a valid `SELECT` statement with an associated <xref:Microsoft.Data.SqlClient.SqlDependency> or <xref:Microsoft.Data.Sql.SqlNotificationRequest> object.

- Provide code to process the notification if the data being monitored changes.

## Query Notifications Requirements

 Query notifications are supported only for `SELECT` statements that meet a list of specific requirements. The following table provides links to the Service Broker and Query Notifications documentation in the SQL Server docs.

 **SQL Server documentation**

- [Creating a Query for Notification](/previous-versions/sql/sql-server-2008-r2/ms181122(v=sql.105))

- [Security Considerations for Service Broker](/previous-versions/sql/sql-server-2005/ms166059(v=sql.90))

- [Security and Protection (Service Broker)](/previous-versions/sql/sql-server-2008-r2/bb522911(v=sql.105))

- [Security Considerations for Notifications Services](/previous-versions/sql/sql-server-2005/ms172604(v=sql.90))

- [Query Notification Permissions](/previous-versions/sql/sql-server-2008-r2/ms188311(v=sql.105))

- [International Considerations for Service Broker](/previous-versions/sql/sql-server-2005/ms166028(v=sql.90))

- [Solution Design Considerations (Service Broker)](/previous-versions/sql/sql-server-2008-r2/bb522899(v=sql.105))

- [Service Broker Developer InfoCenter](/previous-versions/sql/sql-server-2008-r2/ms166100(v=sql.105))

- [Developer's Guide (Service Broker)](/previous-versions/sql/sql-server-2008-r2/bb522908(v=sql.105))

## Enabling Query Notifications to Run Sample Code

 To enable Service Broker on the `AdventureWorks` database by using SQL Server Management Studio, execute the following Transact-SQL statement:

 `ALTER DATABASE AdventureWorks SET ENABLE_BROKER;`

 For the query notification samples to run correctly, the following Transact-SQL statements must be executed on the database server.

```sql
CREATE QUEUE ContactChangeMessages;

CREATE SERVICE ContactChangeNotifications
  ON QUEUE ContactChangeMessages
([http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification]);
```

## Query Notifications Permissions

Grant the database principal `SUBSCRIBE QUERY NOTIFICATIONS` and the Service Broker permissions required by your queue configuration. For example, replace the placeholder with an existing database user:

```sql
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [<database_user>];
```

Modern .NET doesn't support code access security. Don't use `SqlClientPermission.Demand` to authorize query notifications; configure database permissions instead.

## Choosing a Notification Object

Query notification support provides two objects to process notifications: <xref:Microsoft.Data.SqlClient.SqlDependency> and <xref:Microsoft.Data.Sql.SqlNotificationRequest>. Use `SqlDependency` to receive change events and invalidate your application's cache. Use `SqlNotificationRequest` when you need to implement your own notification listener.

> [!IMPORTANT]
> Don't use `System.Data.SqlClient` for new development. Use Microsoft.Data.SqlClient instead. The ASP.NET Framework <xref:System.Web.Caching.SqlCacheDependency> class requires `System.Data.SqlClient` and doesn't integrate with Microsoft.Data.SqlClient. For new Microsoft.Data.SqlClient applications, handle `SqlDependency.OnChange` and update the cache through your application's cache API.

### Using SqlDependency

 To use <xref:Microsoft.Data.SqlClient.SqlDependency>, Service Broker must be enabled for the SQL Server database being used, and users must have permissions to receive notifications. Service Broker objects, such as the notification queue, are predefined.

 In addition, <xref:Microsoft.Data.SqlClient.SqlDependency> automatically launches a worker thread to process notifications as they are posted to the queue; it also parses the Service Broker message, exposing the information as event argument data. <xref:Microsoft.Data.SqlClient.SqlDependency> must be initialized by calling the `Start` method to establish a dependency to the database. This is a static method that needs to be called only once during application initialization for each database connection required. The `Stop` method should be called at application termination for each dependency connection that was made.

### Using SqlNotificationRequest

 In contrast, <xref:Microsoft.Data.Sql.SqlNotificationRequest> requires you to implement the entire listening infrastructure yourself. In addition, all the supporting Service Broker objects such as the queue, service, and message types supported by the queue must be defined. This manual approach is useful if your application requires special notification messages or notification behaviors, or if your application is part of a larger Service Broker application.

## See also

- [Query Notifications in SQL Server](query-notifications-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
