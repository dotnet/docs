---
description: "Learn more about: How to: Represent Computed Columns"
title: "How to: Represent Computed Columns"
ms.date: "03/30/2017"
ms.assetid: 4025f1fd-9dfa-46c0-b04f-34e8bc7957a2
---
# How to: Represent Computed Columns

Use the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.ColumnAttribute.Expression%2A> property on a <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to represent a column whose contents are the result of calculation.  
  
 For code examples, see <xref:System.Data.Linq.Mapping.ColumnAttribute.Expression%2A>.  
  
> [!NOTE]
> [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support computed columns as primary keys.  
  
### To represent a computed column  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.Expression%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Assign a string representation of the formula to the <xref:System.Data.Linq.Mapping.ColumnAttribute.Expression%2A> property.  
  
## See also

- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
- [How to: Customize Entity Classes by Using the Code Editor](how-to-customize-entity-classes-by-using-the-code-editor.md)
