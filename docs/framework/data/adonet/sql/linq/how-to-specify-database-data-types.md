---
description: "Learn more about: How to: Specify Database Data Types"
title: "How to: Specify Database Data Types"
ms.date: "03/30/2017"
ms.assetid: 2228fdad-7e6a-4b1b-b4d1-79d0198b7c28
---
# How to: Specify Database Data Types

Use the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.ColumnAttribute.DbType%2A> property on a <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to specify the exact text that defines the column in a T-SQL table declaration.  
  
 You must specify the <xref:System.Data.Linq.Mapping.ColumnAttribute.DbType%2A> property only if you plan to use <xref:System.Data.Linq.DataContext.CreateDatabase%2A> to create an instance of the database.  
  
 For code examples, see <xref:System.Data.Linq.Mapping.ColumnAttribute.DbType%2A>.  
  
### To specify text to define a data type in a T-SQL table  
  
1. Add the <xref:System.Data.Linq.Mapping.ColumnAttribute.DbType%2A> property to the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute.  
  
2. Set the value of the <xref:System.Data.Linq.Mapping.ColumnAttribute.DbType%2A> property to the exact text that is used by T-SQL.  
  
## See also

- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
- [How to: Customize Entity Classes by Using the Code Editor](how-to-customize-entity-classes-by-using-the-code-editor.md)
