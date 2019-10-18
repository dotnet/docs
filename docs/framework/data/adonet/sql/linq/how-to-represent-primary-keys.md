---
title: "How to: Represent Primary Keys"
ms.date: "03/30/2017"
ms.assetid: 63c65289-6539-42b2-8493-891c232018fa
---
# How to: Represent Primary Keys
Use the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.ColumnAttribute.IsPrimaryKey%2A> property on the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to designate a property or field to represent the primary key for a database column.  
  
 For code examples, see <xref:System.Data.Linq.Mapping.ColumnAttribute.IsPrimaryKey%2A>.  
  
> [!NOTE]
> [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support computed columns as primary keys.  
  
### To designate a property or field as a primary key  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.IsPrimaryKey%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Specify the value as `true`.  
  
## See also

- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
- [How to: Customize Entity Classes by Using the Code Editor](how-to-customize-entity-classes-by-using-the-code-editor.md)
