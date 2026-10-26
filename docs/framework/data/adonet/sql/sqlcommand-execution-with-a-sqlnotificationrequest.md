---
description: "Learn more about: SqlCommand Execution with a SqlNotificationRequest"
title: "SqlCommand Execution with a SqlNotificationRequest"
ms.date: "10/21/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 1776f48f-9bea-41f6-83a4-c990c7a2c991
---

# SqlCommand Execution with a SqlNotificationRequest

To receive a notification when query results change, configure the <xref:Microsoft.Data.SqlClient.SqlCommand> with a notification request. Use notification requests for custom server queues or when you don't want to maintain live dependency objects.

## Creating the Notification Request

Create the <xref:Microsoft.Data.Sql.SqlNotificationRequest> object and assign it to the command's `Notification` property before execution. After the server registers the request, you don't need to retain the request object. Query the queue for notifications and respond as your application requires. Notifications can arrive while the application is shut down and remain available after it restarts.

When the command with the associated notification is executed, any changes to the original result set trigger sending a message to the SQL Server queue that was configured in the notification request.

How you poll the SQL Server queue and interpret the message is specific to your application. The application is responsible for polling the queue and reacting based on the contents of the message.

> [!NOTE]
> When using SQL Server notification requests with <xref:Microsoft.Data.SqlClient.SqlDependency>, create your own queue name instead of using the default service name.

Grant users the server permissions required to request notifications. The <xref:Microsoft.Data.Sql.SqlNotificationRequest> class doesn't add client-side security requirements.

### Example

The following fragment creates the <xref:Microsoft.Data.Sql.SqlNotificationRequest> object and associates it with the <xref:Microsoft.Data.SqlClient.SqlCommand>. Install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package and import `Microsoft.Data.Sql` and `Microsoft.Data.SqlClient`. The `Options` value names a Service Broker service and the database that hosts it, not the queue itself. Create the service and queue as described in [Enabling Query Notifications](enabling-query-notifications.md).

```vb
' Assume connection is an open SqlConnection.
' Create a new SqlCommand object.
Dim command As New SqlCommand( _
  "SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers", connection)

' Create a SqlNotificationRequest object.
Dim notificationRequest As New SqlNotificationRequest()
notificationRequest.UserData = "NotificationID"
notificationRequest.Options = "service=ContactChangeNotifications;local database=AdventureWorks"

' Associate the notification request with the command.
command.Notification = notificationRequest
' Execute the command.
command.ExecuteReader()
' Process the DataReader.
' You can use Transact-SQL syntax to periodically poll the
' SQL Server queue to see if you have a new message.
```

```csharp
// Assume connection is an open SqlConnection.
// Create a new SqlCommand object.
SqlCommand command=new SqlCommand(
 "SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers", connection);

// Create a SqlNotificationRequest object.
SqlNotificationRequest notificationRequest=new SqlNotificationRequest();
notificationRequest.UserData = "NotificationID";
notificationRequest.Options = "service=ContactChangeNotifications;local database=AdventureWorks";

// Associate the notification request with the command.
command.Notification=notificationRequest;
// Execute the command.
command.ExecuteReader();
// Process the DataReader.
// You can use Transact-SQL syntax to periodically poll the
// SQL Server queue to see if you have a new message.
```

## See also

- [Query Notifications in SQL Server](query-notifications-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
