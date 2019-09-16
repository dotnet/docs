---
title: "Obtaining a Single Value from a Database"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: b38526cd-a62a-48cb-822a-e91dfa68e02d
---
# Obtaining a Single Value from a Database
You may need to return database information that is simply a single value rather than in the form of a table or data stream. For example, you may want to return the result of an aggregate function such as COUNT(\*), SUM(Price), or AVG(Quantity). The **Command** object provides the capability to return single values using the **ExecuteScalar** method. The **ExecuteScalar** method returns, as a scalar value, the value of the first column of the first row of the result set.  
  
 The following code example inserts a new value in the database using a <xref:System.Data.SqlClient.SqlCommand>. The <xref:System.Data.SqlClient.SqlCommand.ExecuteScalar%2A> method is used to return the identity column value for the inserted record.  
  
 [!code-csharp[DataWorks SqlCommand.ExecuteScalar#1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlCommand.ExecuteScalar/CS/source.cs#1)]
 [!code-vb[DataWorks SqlCommand.ExecuteScalar#1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlCommand.ExecuteScalar/VB/source.vb#1)]  
  
## See also

- [Commands and Parameters](commands-and-parameters.md)
- [Executing a Command](executing-a-command.md)
- [DbConnection, DbCommand and DbException](dbconnection-dbcommand-and-dbexception.md)
- [ADO.NET Overview](ado-net-overview.md)
