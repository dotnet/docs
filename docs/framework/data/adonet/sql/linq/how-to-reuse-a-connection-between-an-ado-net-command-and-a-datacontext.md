---
description: "Learn more about: How to: Reuse a Connection Between an ADO.NET Command and a DataContext"
title: "How to: Reuse a Connection Between an ADO.NET Command and a DataContext"
ms.date: "10/19/2026"
ai-usage: ai-assisted
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 7e26c7eb-c18a-43b5-a8f0-28fd8b04b0f0
---
# How to: Reuse a Connection Between an ADO.NET Command and a DataContext

> [!IMPORTANT]
> Do not use `System.Data.SqlClient` for new development. Use [Microsoft.Data.SqlClient](/sql/connect/ado-net/introduction-microsoft-data-sqlclient-namespace) for new SQL Server data-access code. These examples retain `System.Data.SqlClient` because .NET Framework's built-in LINQ to SQL provider requires it. Changing the connection type alone doesn't migrate LINQ to SQL.

Because [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] is a part of the ADO.NET family of technologies and is based on services provided by ADO.NET, you can reuse a connection between an ADO.NET command and a <xref:System.Data.Linq.DataContext>.  
  
## Example  

 The following example shows how to reuse the same connection between an ADO.NET command and the <xref:System.Data.Linq.DataContext>.  
  
 [!code-csharp[DLinqCommunicatingWithDatabase#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqCommunicatingWithDatabase/cs/Program.cs#4)]
 [!code-vb[DLinqCommunicatingWithDatabase#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqCommunicatingWithDatabase/vb/Module1.vb#4)]  
  
## See also

- [Background Information](background-information.md)
- [ADO.NET and LINQ to SQL](ado-net-and-linq-to-sql.md)
- [Communicating with the Database](communicating-with-the-database.md)
