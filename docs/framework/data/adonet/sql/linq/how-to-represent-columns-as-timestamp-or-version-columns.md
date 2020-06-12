---
title: "How to: Represent Columns as Timestamp or Version Columns"
ms.date: "03/30/2017"
ms.assetid: 5afd5ce8-1d20-4bc3-a34f-49d95449f493
---
# How to: Represent Columns as Timestamp or Version Columns
Use the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A> property of the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to designate a field or property as representing a database column that holds database timestamps or version numbers.  
  
 For code examples, see <xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A>.  
  
### To designate a field or property as representing a timestamp or version column  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Set the <xref:System.Data.Linq.Mapping.ColumnAttribute.IsVersion%2A> property value to `true`.  
  
## See also

- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
- [How to: Specify Which Members are Tested for Concurrency Conflicts](how-to-specify-which-members-are-tested-for-concurrency-conflicts.md)
- [How to: Customize Entity Classes by Using the Code Editor](how-to-customize-entity-classes-by-using-the-code-editor.md)
