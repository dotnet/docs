---
description: "Learn more about: How to: Represent Tables as Classes"
title: "How to: Represent Tables as Classes"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 84dda12b-88a2-4cd2-92b3-8db87b28d14c
---
# How to: Represent Tables as Classes

Use the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.TableAttribute> attribute to designate a class as an entity class associated with a database table.  
  
### To map a class to a database table  
  
- Add the <xref:System.Data.Linq.Mapping.TableAttribute> attribute to the class declaration.  
  
## Example  

 The following code establishes the `Customer` class as an entity class that is associated with the `Customers` database table.  
  
 [!code-csharp[DLinqCustomize#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqCustomize/cs/Program.cs#1)]
 [!code-vb[DLinqCustomize#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqCustomize/vb/Module1.vb#1)]  
  
 You do not have to specify the <xref:System.Data.Linq.Mapping.TableAttribute.Name%2A> property if the name can be inferred. If you do not specify a name, the name is presumed to be the same name as that of the property or field.  
  
## See also

- [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md)
- [How to: Customize Entity Classes by Using the Code Editor](how-to-customize-entity-classes-by-using-the-code-editor.md)
