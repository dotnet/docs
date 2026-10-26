---
description: "Learn more about: Multiple Bulk Copy Operations"
title: "Multiple Bulk Copy Operations"
ms.date: "10/21/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 5ad12f94-7459-4a93-a421-4160d1a90715
---
# Multiple Bulk Copy Operations

You can perform multiple bulk copy operations with one instance of the <xref:Microsoft.Data.SqlClient.SqlBulkCopy> class. If the operation parameters change between copies (for example, the destination table name), update them before the next `WriteToServer` call. Unless you change them, property values remain the same between operations on the same instance.

> [!NOTE]
> Performing multiple bulk copy operations using the same instance of <xref:Microsoft.Data.SqlClient.SqlBulkCopy> is usually more efficient than using a separate instance for each operation.

 If you perform several bulk copy operations using the same <xref:Microsoft.Data.SqlClient.SqlBulkCopy> object, there are no restrictions on whether source or target information is equal or different in each operation. However, you must ensure that column association information is properly set each time you write to the server.

> [!IMPORTANT]
> Before you run this sample, create the work tables described in [Bulk Copy Example Setup](bulk-copy-example-setup.md). The sample demonstrates `SqlBulkCopy` syntax. If the source and destination tables are in the same SQL Server instance, use a Transact-SQL (T-SQL) `INSERT ... SELECT` statement for a faster copy.

To preserve the relationship between orders and their details, this example specifies `SqlBulkCopyOptions.KeepIdentity`. The destination header table has an identity column, so the copy must retain the source `SalesOrderID` values that the detail rows reference. Column mappings alone don't preserve identity values.

 [!code-csharp[DataWorks SqlBulkCopy.ColumnMappingOrdersDetails#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.ColumnMappingOrdersDetails/CS/source.cs#1)]
 [!code-vb[DataWorks SqlBulkCopy.ColumnMappingOrdersDetails#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks SqlBulkCopy.ColumnMappingOrdersDetails/VB/source.vb#1)]

## See also

- [Bulk Copy Operations in SQL Server](bulk-copy-operations-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
