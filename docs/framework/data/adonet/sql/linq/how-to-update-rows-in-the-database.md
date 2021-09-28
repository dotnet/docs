---
title: "How to: Update Rows in the Database"
description: Learn to update rows in a database by modifying LINQ to SQL objects in a table-related collection. LINQ to SQL translates additions to SQL UPDATE commands.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: a2b5c90f-6cc3-4128-bfab-1db488d5af26
---
# How to: Update Rows in the Database

You can update rows in a database by modifying member values of the objects associated with the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Table%601> collection and then submitting the changes to the database. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates your changes into the appropriate SQL `UPDATE` commands.

> [!NOTE]
> You can override [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] default methods for `Insert`, `Update`, and `Delete` database operations. For more information, see [Customizing Insert, Update, and Delete Operations](customizing-insert-update-and-delete-operations.md).
>
> Developers using Visual Studio can use the Object Relational Designer to develop stored procedures for the same purpose.

The following steps assume that a valid <xref:System.Data.Linq.DataContext> connects you to the Northwind database. For more information, see [How to: Connect to a Database](how-to-connect-to-a-database.md).

### To update a row in the database

1. Query the database for the row to be updated.

2. Make desired changes to member values in the resulting [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] object.

3. Submit the changes to the database.

## Example

The following example queries the database for order #11000, and then changes the values of `ShipName` and `ShipVia` in the resulting `Order` object. Finally, the changes to these member values are submitted to the database as changes in the `ShipName` and `ShipVia` columns.

[!code-csharp[System.Data.Linq.Table#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.table/cs/program.cs#2)]
[!code-vb[System.Data.Linq.Table#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.table/vb/module1.vb#2)]

## See also

- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
- [How to: Assign stored procedures to perform updates, inserts, and deletes (O/R Designer)](/visualstudio/data-tools/how-to-assign-stored-procedures-to-perform-updates-inserts-and-deletes-o-r-designer)
- [Making and Submitting Data Changes](making-and-submitting-data-changes.md)
