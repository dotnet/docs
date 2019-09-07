---
title: "How to: Specify Database Names"
ms.date: "03/30/2017"
ms.assetid: b80f0fd2-7f75-45fe-9e12-496f80f183df
---
# How to: Specify Database Names
Use the <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A> property on a <xref:System.Data.Linq.Mapping.DatabaseAttribute> attribute to specify the name of a database when a name is not supplied by the connection.  
  
 For code samples, see <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A>.  
  
### To specify the name of the database  
  
1. Add the <xref:System.Data.Linq.Mapping.DatabaseAttribute> attribute to the class declaration for the database.  
  
2. Add the <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A> property to the <xref:System.Data.Linq.Mapping.DatabaseAttribute> attribute.  
  
3. Set the <xref:System.Data.Linq.Mapping.DatabaseAttribute.Name%2A> property value to the name that you want to specify.  
  
## See also

- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
- [How to: Customize Entity Classes by Using the Code Editor](how-to-customize-entity-classes-by-using-the-code-editor.md)
