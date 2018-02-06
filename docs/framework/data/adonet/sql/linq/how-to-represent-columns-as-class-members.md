---
title: "How to: Represent Columns as Class Members"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 7ab28021-4d15-4d9c-bf2e-6ccc0daa7d1a
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Represent Columns as Class Members
Use the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to associate a field or property with a database column.  
  
### To map a field or property to a database column  
  
-   Add the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to the property or field declaration.  
  
## Example  
 The following code maps the `CustomerID` field in the `Customer` class to the `CustomerID` column in the `Customers` database table.  
  
 [!code-csharp[DLinqCustomize#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqCustomize/cs/Program.cs#2)]
 [!code-vb[DLinqCustomize#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqCustomize/vb/Module1.vb#2)]  
  
 You do not have to specify the <xref:System.Data.Linq.Mapping.DataAttribute.Name%2A> property if the name can be inferred. If you do not specify a name, the name is presumed to be the same name as that of the property or field.  
  
## See Also  
 [The LINQ to SQL Object Model](../../../../../../docs/framework/data/adonet/sql/linq/the-linq-to-sql-object-model.md)  
 [How to: Customize Entity Classes by Using the Code Editor](../../../../../../docs/framework/data/adonet/sql/linq/how-to-customize-entity-classes-by-using-the-code-editor.md)
