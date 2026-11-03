---
description: "Learn more about: Asynchronous Operations"
title: "Asynchronous Operations"
ms.date: "10/21/2026"
ai-usage: ai-assisted
ms.assetid: e7d32c3c-bf78-4bfc-a357-c9e82e4a4b3c
---
# Asynchronous Operations

Database operations can take significant time to complete. To keep a user interface responsive or avoid blocking a request thread, use asynchronous database methods instead of waiting synchronously for a command to finish.

Install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package for SQL client code. For new applications, use <xref:Microsoft.Data.SqlClient.SqlConnection.OpenAsync*> and the <xref:Microsoft.Data.SqlClient.SqlCommand.ExecuteNonQueryAsync*>, <xref:Microsoft.Data.SqlClient.SqlCommand.ExecuteReaderAsync*>, and <xref:Microsoft.Data.SqlClient.SqlCommand.ExecuteXmlReaderAsync*> methods with `await`. These methods perform asynchronous input/output (I/O) without requiring you to create a background thread.

Microsoft.Data.SqlClient also supports the callback, wait-handle, and polling patterns described in this section. The <xref:Microsoft.Data.SqlClient.SqlCommand.BeginExecuteNonQuery*>, <xref:Microsoft.Data.SqlClient.SqlCommand.BeginExecuteReader*>, and <xref:Microsoft.Data.SqlClient.SqlCommand.BeginExecuteXmlReader*> methods pair with <xref:Microsoft.Data.SqlClient.SqlCommand.EndExecuteNonQuery*>, <xref:Microsoft.Data.SqlClient.SqlCommand.EndExecuteReader*>, and <xref:Microsoft.Data.SqlClient.SqlCommand.EndExecuteXmlReader*>. Don't add `Asynchronous Processing=true` to the connection string; Microsoft.Data.SqlClient doesn't support that keyword.

> [!NOTE]
> For new code, use the [Task-based asynchronous pattern](../../../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md). The examples in this section show the supported `Begin`/`End` pattern for applications that need callbacks, wait handles, or polling.

Keep each connection and command alive until its operation completes. Observe exceptions when you call the matching `End` method or await the task. In a desktop application, update controls only from the user interface thread.

## In This Section

 [Windows Applications Using Callbacks](windows-applications-using-callbacks.md)
 Provides an example demonstrating how to execute an asynchronous command safely, correctly handling interaction with a form and its contents from a separate thread.

 [ASP.NET Applications Using Wait Handles](aspnet-apps-using-wait-handles.md)
 Provides an example demonstrating how to execute multiple concurrent commands from an ASP.NET page, using Wait handles to manage the operation at completion of all the commands.

 [Polling in Console Applications](polling-in-console-applications.md)
 Provides an example demonstrating the use of polling to wait for the completion of an asynchronous command execution from a console application. This technique is also valid in a class library or other application without a user interface.

## See also

- [SQL Server and ADO.NET](index.md)
- [Calling Synchronous Methods Asynchronously](../../../../standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md)
- [ADO.NET Overview](../ado-net-overview.md)
