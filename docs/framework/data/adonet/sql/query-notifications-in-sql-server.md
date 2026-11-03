---
title: "Query Notifications in SQL Server"
description: Learn how to use query notifications to notify applications when data has changed in a SQL Server database, for instance, to refresh application displays.
ms.date: "10/23/2026"
ai-usage: ai-assisted
ms.assetid: 0f0ba1a1-3180-4af8-87f7-c795dc8f8f55
---
# Query Notifications in SQL Server

Built upon the Service Broker infrastructure, query notifications allow applications to be notified when data has changed. This feature is particularly useful for applications that provide a cache of information from a database, such as a Web application, and need to be notified when the source data is changed.

Microsoft.Data.SqlClient provides two classes for query notifications:

- Use <xref:Microsoft.Data.Sql.SqlNotificationRequest> to execute a command with a notification request and process the Service Broker messages yourself.

- Use <xref:Microsoft.Data.SqlClient.SqlDependency> to detect changes through the `OnChange` event. Microsoft.Data.SqlClient manages the listener and exposes notification information in the event arguments.

> [!IMPORTANT]
> Don't use `System.Data.SqlClient` for new development. Use Microsoft.Data.SqlClient instead. The ASP.NET Framework <xref:System.Web.Caching.SqlCacheDependency> class requires `System.Data.SqlClient` and doesn't integrate with Microsoft.Data.SqlClient. For new Microsoft.Data.SqlClient applications, subscribe to `SqlDependency.OnChange` and invalidate entries through your application's cache API.

 Query notifications are used for applications that need to refresh displays or caches in response to changes in underlying data. SQL Server allows .NET applications to send a command and request notification if the same command would produce result sets different from those initially retrieved. Notifications generated at the server are sent through queues to be processed later.

 You can set up notifications for `SELECT` and `EXECUTE` statements. When using an `EXECUTE` statement, SQL Server registers a notification for the command executed rather than the `EXECUTE` statement itself. The command must meet the requirements and limitations for a `SELECT` statement. When a command that registers a notification contains more than one statement, the Database Engine creates a notification for each statement in the batch.

 If you are developing an application where you need reliable sub-second notifications when data changes, review the sections **Planning an Efficient Query Notifications Strategy** and **Alternatives to Query Notifications** in the [Planning for Notifications](/previous-versions/sql/sql-server-2008-r2/ms187528(v=sql.105)) article. For more information about Query Notifications and SQL Server Service Broker, see the following links to articles in the SQL Server documentation.

 **SQL Server documentation**

- [Using Query Notifications](/previous-versions/sql/sql-server-2008-r2/ms175110(v=sql.105))

- [Creating a Query for Notification](/previous-versions/sql/sql-server-2008-r2/ms181122(v=sql.105))

- [Development (Service Broker)](/previous-versions/sql/sql-server-2008-r2/bb522889(v=sql.105))

- [Service Broker Developer InfoCenter](/previous-versions/sql/sql-server-2008-r2/ms166100(v=sql.105))

- [Developer's Guide (Service Broker)](/previous-versions/sql/sql-server-2008-r2/bb522908(v=sql.105))

## In This Section

 [Enabling Query Notifications](enabling-query-notifications.md)
 Discusses how to use query notifications, including the requirements for enabling and using them.

 [Detecting Changes with SqlDependency](detecting-changes-with-sqldependency.md)
 Demonstrates how to detect when query results will be different from those originally received.

 [SqlCommand Execution with a SqlNotificationRequest](sqlcommand-execution-with-a-sqlnotificationrequest.md)
 Demonstrates how to configure the <xref:Microsoft.Data.SqlClient.SqlCommand> object for a query notification.

## Reference

 <xref:Microsoft.Data.Sql.SqlNotificationRequest>
 Describes the <xref:Microsoft.Data.Sql.SqlNotificationRequest> class and all of its members.

 <xref:Microsoft.Data.SqlClient.SqlDependency>
 Describes the <xref:Microsoft.Data.SqlClient.SqlDependency> class and all of its members.

 <xref:System.Web.Caching.SqlCacheDependency>
 Describes the ASP.NET Framework cache dependency class for System.Data.SqlClient. It doesn't wrap Microsoft.Data.SqlClient dependencies.

## See also

- [SQL Server and ADO.NET](index.md)
- [ADO.NET Overview](../ado-net-overview.md)
