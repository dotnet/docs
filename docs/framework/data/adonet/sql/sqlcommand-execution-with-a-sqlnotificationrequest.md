---
title: "SqlCommand Execution with a SqlNotificationRequest"
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
ms.assetid: 1776f48f-9bea-41f6-83a4-c990c7a2c991
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# SqlCommand Execution with a SqlNotificationRequest
A <xref:System.Data.SqlClient.SqlCommand> can be configured to generate a notification when data changes after it has been fetched from the server and the result set would be different if the query were executed again. This is useful for scenarios where you want to use custom notification queues on the server or when you do not want to maintain live objects.  
  
## Creating the Notification Request  
 You can use a <xref:System.Data.Sql.SqlNotificationRequest> object to create the notification request by binding it to a `SqlCommand` object. Once the request is created, you no longer need the `SqlNotificationRequest` object. You can query the queue for any notifications and respond appropriately. Notifications can occur even if the application is shut down and subsequently restarted.  
  
 When the command with the associated notification is executed, any changes to the original result set trigger sending a message to the SQL Server queue that was configured in the notification request.  
  
 How you poll the SQL Server queue and interpret the message is specific to your application. The application is responsible for polling the queue and reacting based on the contents of the message.  
  
> [!NOTE]
>  When using SQL Server notification requests with <xref:System.Data.SqlClient.SqlDependency>, create your own queue name instead of using the default service name.  
  
 There are no new client-side security elements for <xref:System.Data.Sql.SqlNotificationRequest>. This is primarily a server feature, and the server has created special privileges that users must have to request a notification.  
  
### Example  
 The following code fragment demonstrates how to create a <xref:System.Data.Sql.SqlNotificationRequest> and associate it with a <xref:System.Data.SqlClient.SqlCommand>.  
  
```vb  
' Assume connection is an open SqlConnection.  
' Create a new SqlCommand object.  
Dim command As New SqlCommand( _  
  "SELECT ShipperID, CompanyName, Phone FROM dbo.Shippers", connection)  
  
' Create a SqlNotificationRequest object.  
Dim notficationRequest As New SqlNotificationRequest()  
notficationRequest.id = "NotificationID"  
notficationRequest.Service = "mySSBQueue"  
  
' Associate the notification request with the command.  
command.Notification = notficationRequest  
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
SqlNotificationRequest notficationRequest=new SqlNotificationRequest();  
notficationRequest.id="NotificationID";  
notficationRequest.Service="mySSBQueue";  
  
// Associate the notification request with the command.  
command.Notification=notficationRequest;  
// Execute the command.  
command.ExecuteReader();  
// Process the DataReader.  
// You can use Transact-SQL syntax to periodically poll the   
// SQL Server queue to see if you have a new message.  
```  
  
## See Also  
 [Query Notifications in SQL Server](../../../../../docs/framework/data/adonet/sql/query-notifications-in-sql-server.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
