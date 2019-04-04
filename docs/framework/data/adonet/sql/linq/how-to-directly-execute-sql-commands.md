---
title: "How to: Directly Execute SQL Commands"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 04671bb0-40c0-4465-86e5-77986f454661
---
# How to: Directly Execute SQL Commands
Assuming a <xref:System.Data.Linq.DataContext> connection, you can use <xref:System.Data.Linq.DataContext.ExecuteCommand%2A> to execute SQL commands that do not return objects.  
  
## Example  
 The following example causes SQL Server to increase UnitPrice by 1.00.  
  
 [!code-csharp[DLinqCommunicatingWithDatabase#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqCommunicatingWithDatabase/cs/Program.cs#3)]
 [!code-vb[DLinqCommunicatingWithDatabase#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqCommunicatingWithDatabase/vb/Module1.vb#3)]  
  
## See also
- [How to: Directly Execute SQL Queries](../../../../../../docs/framework/data/adonet/sql/linq/how-to-directly-execute-sql-queries.md)
- [Communicating with the Database](../../../../../../docs/framework/data/adonet/sql/linq/communicating-with-the-database.md)
