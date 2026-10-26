---
description: "Learn more about: The Context Connection"
title: "The Context Connection"
ms.date: "10/21/2026"
ai-usage: ai-assisted
ms.assetid: e443ca86-9243-4234-a822-ed10a53a9de0
---
# The Context Connection

> [!IMPORTANT]
> Don't use `System.Data.SqlClient` for new development. Use <xref:Microsoft.Data.SqlClient> instead for standalone client applications. The exception is common language runtime (CLR) code inside SQL Server: context connections with `Context Connection=true` require the .NET Framework provider <xref:System.Data.SqlClient>. Microsoft.Data.SqlClient doesn't support context connections.

A CLR stored procedure or function often needs to access the server where it executes. You can open a separate connection with <xref:System.Data.SqlClient.SqlConnection> and a connection string for the local server, but that requires login credentials. The new connection uses a different session and transaction, might have different `SET` options, and doesn't see the caller's temporary tables.

To use the caller's session, open a context connection instead. The stored procedure or function then uses the connection that invoked it, including that connection's transaction and `SET` options.
  
 The context connection lets you execute Transact-SQL statements in the same context that your code was invoked in the first place. For more detailed information, see [The Context Connection](/sql/relational-databases/clr-integration/data-access/context-connection).
  
## See also

- [ADO.NET Overview](../ado-net-overview.md)
