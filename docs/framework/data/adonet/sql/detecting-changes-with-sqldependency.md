---
title: "Detecting Changes with SqlDependency"
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
ms.assetid: e6a58316-f005-4477-92e1-45cc2eb8c5b4
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Detecting Changes with SqlDependency
A <xref:System.Data.SqlClient.SqlDependency> object can be associated with a <xref:System.Data.SqlClient.SqlCommand> in order to detect when query results differ from those originally retrieved. You can also assign a delegate to the `OnChange` event, which will fire when the results change for an associated command. You must associate the <xref:System.Data.SqlClient.SqlDependency> with the command before you execute the command. The `HasChanges` property of the <xref:System.Data.SqlClient.SqlDependency> can also be used to determine if the query results have changed since the data was first retrieved.  
  
## Security Considerations  
 The dependency infrastructure relies on a <xref:System.Data.SqlClient.SqlConnection> that is opened when <xref:System.Data.SqlClient.SqlDependency.Start%2A> is called in order to receive notifications that the underlying data has changed for a given command. The ability for a client to initiate the call to `SqlDependency.Start` is controlled through the use of <xref:System.Data.SqlClient.SqlClientPermission> and code access security attributes. For more information, see [Enabling Query Notifications](../../../../../docs/framework/data/adonet/sql/enabling-query-notifications.md) and [Code Access Security and ADO.NET](../../../../../docs/framework/data/adonet/code-access-security.md).  
  
### Example  
 The following steps illustrate how to declare a dependency, execute a command, and receive a notification when the result set changes:  
  
1.  Initiate a `SqlDependency` connection to the server.  
  
2.  Create <xref:System.Data.SqlClient.SqlConnection> and <xref:System.Data.SqlClient.SqlCommand> objects to connect to the server and define a Transact-SQL statement.  
  
3.  Create a new `SqlDependency` object, or use an existing one, and bind it to the `SqlCommand` object. Internally, this creates a <xref:System.Data.Sql.SqlNotificationRequest> object and binds it to the command object as needed. This notification request contains an internal identifier that uniquely identifies this `SqlDependency` object. It also starts the client listener if it is not already active.  
  
4.  Subscribe an event handler to the `OnChange` event of the `SqlDependency` object.  
  
5.  Execute the command using any of the `Execute` methods of the `SqlCommand` object. Because the command is bound to the notification object, the server recognizes that it must generate a notification, and the queue information will point to the dependencies queue.  
  
6.  Stop the `SqlDependency` connection to the server.  
  
 If any user subsequently changes the underlying data, Microsoft SQL Server detects that there is a notification pending for such a change, and posts a notification that is processed and forwarded to the client through the underlying `SqlConnection` that was created by calling `SqlDependency.Start`. The client listener receives the invalidation message. The client listener then locates the associated `SqlDependency` object and fires the `OnChange` event.  
  
 The following code fragment shows the design pattern you would use to create a sample application.  
  
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
        Dim dependency As New SqlDependency(command)  
        ' Maintain the refence in a class member.  
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
        SqlDependency dependency=new SqlDependency(command);  
        // Maintain the refence in a class member.  
  
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
  
## See Also  
 [Query Notifications in SQL Server](../../../../../docs/framework/data/adonet/sql/query-notifications-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
