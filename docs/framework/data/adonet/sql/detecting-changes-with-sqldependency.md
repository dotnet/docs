---
title: "Detecting Changes with SqlDependency"
description: Associate a SqlDependency object with a SqlCommand to detect when query results differ from those originally retrieved in ADO.NET.
ms.date: "10/21/2026"
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
ms.custom: sfi-ropc-nochange
---

# Detect changes with SqlDependency

To detect when query results differ from those originally retrieved, associate the <xref:Microsoft.Data.SqlClient.SqlDependency> object with the <xref:Microsoft.Data.SqlClient.SqlCommand> before you execute the command. Subscribe to the `OnChange` event to receive a notification when the results change. You can also check the dependency's `HasChanges` property to determine whether the results have changed.

## Security Considerations

To receive notifications when the underlying data changes, call <xref:Microsoft.Data.SqlClient.SqlDependency.Start*>. The dependency infrastructure opens the <xref:Microsoft.Data.SqlClient.SqlConnection> for the listener. Grant the database principal the required Service Broker and query notification permissions. Code access security isn't supported in modern .NET. For more information, see [Enabling Query Notifications](enabling-query-notifications.md).

### Example

The following steps illustrate how to declare a dependency, execute a command, and receive a notification when the result set changes:

1. At application initialization, call `SqlDependency.Start` to start the client listener.

1. Create <xref:Microsoft.Data.SqlClient.SqlConnection> and <xref:Microsoft.Data.SqlClient.SqlCommand> objects to connect to the server and define a Transact-SQL (T-SQL) statement.

1. Create or reuse the `SqlDependency` object and associate it with the `SqlCommand` object. The dependency creates and associates the <xref:Microsoft.Data.Sql.SqlNotificationRequest> object with the command as needed. The notification request contains an internal identifier for the dependency. The constructor doesn't start the listener.

1. Subscribe an event handler to the `OnChange` event of the `SqlDependency` object.

1. Execute the command with one of its `Execute` methods. Because the command includes a notification request, the server registers the query for notifications to the specified queue.

1. At application termination, call `SqlDependency.Stop` with the same connection string and queue name.

If any user subsequently changes the underlying data, Microsoft SQL Server detects that there is a notification pending for such a change, and posts a notification that is processed and forwarded to the client through the underlying `SqlConnection` that was created by calling `SqlDependency.Start`. The client listener receives the invalidation message. The client listener then locates the associated `SqlDependency` object and fires the `OnChange` event.

The following code fragment shows the design pattern for a sample application. Install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package and import `Microsoft.Data.SqlClient` in C# or Visual Basic.

These fragments use an existing Service Broker queue. Set `queueName` to the queue's unqualified name and `notificationOptions` to `service=<service-name>;local database=<database-name>`. Specify the service that routes notifications to that queue. Pass the same connection string and queue name to `Start` and `Stop`. For more information, see [Enable query notifications](enabling-query-notifications.md).

```vb
Sub Initialization()
    ' Create a dependency connection.
    SqlDependency.Start(connectionString, queueName)
End Sub

Sub SomeMethod()
    ' Assume connection is an open SqlConnection.
    ' Create a new SqlCommand object.
    Using command As New SqlCommand( _
      "SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers", _
      connection)

        ' Create a dependency and associate it with the SqlCommand.
        Dim dependency As New SqlDependency(command, notificationOptions, 0)
        ' Maintain the reference in a class member.
        ' Subscribe to the SqlDependency event.
        AddHandler dependency.OnChange, AddressOf OnDependencyChange

        ' Execute the command.
        Using reader = command.ExecuteReader()
            ' Process the DataReader.
        End Using
    End Using
End Sub

' Handler method
Sub OnDependencyChange(ByVal sender As Object, _
    ByVal e As SqlNotificationEventArgs)
    ' Handle the event (for example, invalidate this cache entry).
End Sub

Sub Termination()
    ' Release the dependency
    SqlDependency.Stop(connectionString, queueName)
End Sub
```

```csharp
void Initialization()
{
    // Create a dependency connection.
    SqlDependency.Start(connectionString, queueName);
}

void SomeMethod()
{
    // Assume connection is an open SqlConnection.

    // Create a new SqlCommand object.
    using (SqlCommand command=new SqlCommand(
        "SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers",
        connection))
    {

        // Create a dependency and associate it with the SqlCommand.
        SqlDependency dependency=new SqlDependency(command, notificationOptions, 0);
        // Maintain the reference in a class member.

        // Subscribe to the SqlDependency event.
        dependency.OnChange+=new
           OnChangeEventHandler(OnDependencyChange);

        // Execute the command.
        using (SqlDataReader reader = command.ExecuteReader())
        {
            // Process the DataReader.
        }
    }
}

// Handler method
void OnDependencyChange(object sender,
   SqlNotificationEventArgs e )
{
  // Handle the event (for example, invalidate this cache entry).
}

void Termination()
{
    // Release the dependency.
    SqlDependency.Stop(connectionString, queueName);
}
```

## See also

- [Query Notifications in SQL Server](query-notifications-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
