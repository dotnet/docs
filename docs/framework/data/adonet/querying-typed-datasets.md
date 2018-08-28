---
title: "Querying Typed DataSets"
ms.date: 08/15/2018
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: ad712fa1-2baf-462a-b163-574cce6d376a
---
# Query typed DataSets

If the schema of the <xref:System.Data.DataSet> is known at application design time, we recommend that you use a typed <xref:System.Data.DataSet> when using LINQ to DataSet. A typed <xref:System.Data.DataSet> is a class that derives from a <xref:System.Data.DataSet>. As such, it inherits all the methods, events, and properties of a <xref:System.Data.DataSet>. Additionally, a typed <xref:System.Data.DataSet> provides strongly typed methods, events, and properties. This means that you can access tables and columns by name, instead of using collection-based methods. This makes queries simpler and more readable. For more information, see [Typed DataSets](../../../../docs/framework/data/adonet/dataset-datatable-dataview/typed-datasets.md).

LINQ to DataSet also supports querying over a typed <xref:System.Data.DataSet>. With a typed <xref:System.Data.DataSet>, you do not have to use the generic <xref:System.Data.DataRowExtensions.Field%2A> method or <xref:System.Data.DataRowExtensions.SetField%2A> method to access column data. Property names are available at compile time because the type information is included in the <xref:System.Data.DataSet>. LINQ to DataSet provides access to column values as the correct type, so that type mismatch errors are caught when the code is compiled instead of at run time.

Before you can begin querying a typed <xref:System.Data.DataSet>, you must generate the class by using the **DataSet Designer** in Visual Studio. For more information, see [Create and configure DataSets](/visualstudio/data-tools/create-and-configure-datasets-in-visual-studio).

## Example

The following example shows a query over a typed <xref:System.Data.DataSet>:

```csharp
var query = from o in orders
            where o.OnlineOrderFlag == true
            select new { o.SalesOrderID,
                         o.OrderDate,
                         o.SalesOrderNumber };

foreach(var order in query)
{
    Console.WriteLine("{0}\t{1:d}\t{2}",
      order.SalesOrderID,
      order.OrderDate,
      order.SalesOrderNumber);
}
```

```vb
Dim orders = ds.Tables("SalesOrderHeader")

Dim query = _
       From o In orders _
       Where o.OnlineOrderFlag = True _
       Select New {SalesOrderID := o.SalesOrderID, _
                   OrderDate := o.OrderDate, _
                   SalesOrderNumber := o.SalesOrderNumber}

For Each Dim onlineOrder In query
 Console.WriteLine("{0}\t{1:d}\t{2}", _
 onlineOrder.SalesOrderID, _
 onlineOrder.OrderDate, _
 onlineOrder.SalesOrderNumber)
Next
```

## See also

- [Querying DataSets](../../../../docs/framework/data/adonet/querying-datasets-linq-to-dataset.md)
- [Cross-Table Queries](../../../../docs/framework/data/adonet/cross-table-queries-linq-to-dataset.md)
- [Single-Table Queries](../../../../docs/framework/data/adonet/single-table-queries-linq-to-dataset.md)
