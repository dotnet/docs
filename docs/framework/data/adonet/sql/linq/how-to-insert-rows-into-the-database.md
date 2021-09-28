---
title: "How to: Insert Rows Into the Database"
description: Learn to insert rows into a database by adding LINQ to SQL objects to a table-related collection. LINQ to SQL translates additions to SQL INSERT commands.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 44d99680-69c7-4879-a732-f6771b334211
---
# How to: Insert Rows Into the Database

You insert rows into a database by adding objects to the associated [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Table%601> collection and then submitting the changes to the database. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates your changes into the appropriate SQL `INSERT` commands.

> [!NOTE]
> You can override [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] default methods for `Insert`, `Update`, and `Delete` database operations. For more information, see [Customizing Insert, Update, and Delete Operations](customizing-insert-update-and-delete-operations.md).
>
> Developers using Visual Studio can use the Object Relational Designer to develop stored procedures for the same purpose.

The following steps assume that a valid <xref:System.Data.Linq.DataContext> connects you to the Northwind database. For more information, see [How to: Connect to a Database](how-to-connect-to-a-database.md).

### To insert a row into the database

1. Create a new object that includes the column data to be submitted.

2. Add the new object to the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] `Table` collection associated with the target table in the database.

3. Submit the change to the database.

## Example

The following code example creates a new object of type `Order` and populates it with appropriate values. It then adds the new object to the `Order` collection. Finally, it submits the change to the database as a new row in the `Orders` table.

[!code-csharp[System.Data.Linq.Table#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.table/cs/program.cs#1)]
[!code-vb[System.Data.Linq.Table#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.table/vb/module1.vb#1)]

## See also

- [How to: Manage Change Conflicts](how-to-manage-change-conflicts.md)
- [DataContext Methods (O/R Designer)](/visualstudio/data-tools/datacontext-methods-o-r-designer)
- [How to: Assign stored procedures to perform updates, inserts, and deletes (O/R Designer)](/visualstudio/data-tools/how-to-assign-stored-procedures-to-perform-updates-inserts-and-deletes-o-r-designer)
- [Making and Submitting Data Changes](making-and-submitting-data-changes.md)
