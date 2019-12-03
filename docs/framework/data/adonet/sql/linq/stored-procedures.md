---
title: "Stored Procedures"
ms.date: "03/30/2017"
ms.assetid: 4d23dd7a-a85f-44ff-a717-af7d0950c0fc
---
# Stored Procedures
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses methods in your object model to represent stored procedures in the database. You designate methods as stored procedures by applying the <xref:System.Data.Linq.Mapping.FunctionAttribute> attribute and, where required, the <xref:System.Data.Linq.Mapping.ParameterAttribute> attribute. For more information, see [The LINQ to SQL Object Model](the-linq-to-sql-object-model.md).  
  
 Developers using Visual Studio would typically use the Object Relational Designer to map stored procedures. The topics in this section show how to form and call these methods in your application if you write the code yourself.  
  
## In This Section  
 [How to: Return Rowsets](how-to-return-rowsets.md)  
 Describes how to return rows of data and shows how to use an input parameter.  
  
 [How to: Use Stored Procedures that Take Parameters](how-to-use-stored-procedures-that-take-parameters.md)  
 Describes how to use input and output parameters.  
  
 [How to: Use Stored Procedures Mapped for Multiple Result Shapes](how-to-use-stored-procedures-mapped-for-multiple-result-shapes.md)  
 Describes how to provide for returns of multiple shapes in the same stored procedure.  
  
 [How to: Use Stored Procedures Mapped for Sequential Result Shapes](how-to-use-stored-procedures-mapped-for-sequential-result-shapes.md)  
 Describes how to provide for multiple shapes where the return sequence is known.  
  
 [Customizing Operations By Using Stored Procedures](customizing-operations-by-using-stored-procedures.md)  
 Describes how to use stored procedures to implement insert, update, and delete operations.  
  
 [Customizing Operations by Using Stored Procedures Exclusively](customizing-operations-by-using-stored-procedures-exclusively.md)  
 Describes how to use nothing but stored procedures to implement insert, update, and delete operations.  
  
## Related Sections  
 [Programming Guide](programming-guide.md)  
 Provides information about how to create and use your [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] object model.  
  
 [Walkthrough: Using Only Stored Procedures (Visual Basic)](walkthrough-using-only-stored-procedures-visual-basic.md)  
 Includes procedures that illustrate how to use stored procedures in Visual Basic.  
  
 [Walkthrough: Using Only Stored Procedures (C#)](walkthrough-using-only-stored-procedures-csharp.md)  
 Includes procedures that illustrate how to use stored procedures in C#.
