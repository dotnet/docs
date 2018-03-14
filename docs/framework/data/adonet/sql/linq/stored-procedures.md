---
title: "Stored Procedures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4d23dd7a-a85f-44ff-a717-af7d0950c0fc
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Stored Procedures
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses methods in your object model to represent stored procedures in the database. You designate methods as stored procedures by applying the <xref:System.Data.Linq.Mapping.FunctionAttribute> attribute and, where required, the <xref:System.Data.Linq.Mapping.ParameterAttribute> attribute. For more information, see [The LINQ to SQL Object Model](../../../../../../docs/framework/data/adonet/sql/linq/the-linq-to-sql-object-model.md).  
  
 Developers using [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] would typically use the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] to map stored procedures. The topics in this section show how to form and call these methods in your application if you write the code yourself.  
  
## In This Section  
 [How to: Return Rowsets](../../../../../../docs/framework/data/adonet/sql/linq/how-to-return-rowsets.md)  
 Describes how to return rows of data and shows how to use an input parameter.  
  
 [How to: Use Stored Procedures that Take Parameters](../../../../../../docs/framework/data/adonet/sql/linq/how-to-use-stored-procedures-that-take-parameters.md)  
 Describes how to use input and output parameters.  
  
 [How to: Use Stored Procedures Mapped for Multiple Result Shapes](../../../../../../docs/framework/data/adonet/sql/linq/how-to-use-stored-procedures-mapped-for-multiple-result-shapes.md)  
 Describes how to provide for returns of multiple shapes in the same stored procedure.  
  
 [How to: Use Stored Procedures Mapped for Sequential Result Shapes](../../../../../../docs/framework/data/adonet/sql/linq/how-to-use-stored-procedures-mapped-for-sequential-result-shapes.md)  
 Describes how to provide for multiple shapes where the return sequence is known.  
  
 [Customizing Operations By Using Stored Procedures](../../../../../../docs/framework/data/adonet/sql/linq/customizing-operations-by-using-stored-procedures.md)  
 Describes how to use stored procedures to implement insert, update, and delete operations.  
  
 [Customizing Operations by Using Stored Procedures Exclusively](../../../../../../docs/framework/data/adonet/sql/linq/customizing-operations-by-using-stored-procedures-exclusively.md)  
 Describes how to use nothing but stored procedures to implement insert, update, and delete operations.  
  
## Related Sections  
 [Programming Guide](../../../../../../docs/framework/data/adonet/sql/linq/programming-guide.md)  
 Provides information about how to create and use your [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] object model.  
  
 [Walkthrough: Using Only Stored Procedures (Visual Basic)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-using-only-stored-procedures-visual-basic.md)  
 Includes procedures that illustrate how to use stored procedures in Visual Basic.  
  
 [Walkthrough: Using Only Stored Procedures (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-using-only-stored-procedures-csharp.md)  
 Includes procedures that illustrate how to use stored procedures in C#.
