---
title: "User-Defined Functions"
ms.date: "03/30/2017"
ms.assetid: 3304c9b2-5c7a-4a95-9d45-4f260dcb606e
---
# User-Defined Functions
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses methods in your object model to represent user-defined functions. You designate methods as functions by applying the <xref:System.Data.Linq.Mapping.FunctionAttribute> attribute and, where required, the <xref:System.Data.Linq.Mapping.ParameterAttribute> attribute. For more information, see [The LINQ to SQL Object Model](../../../../../../docs/framework/data/adonet/sql/linq/the-linq-to-sql-object-model.md).  
  
 To avoid an <xref:System.InvalidOperationException>, user-defined functions in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] must be in one of the following forms:  
  
- A function wrapped as a method call having the correct mapping attributes. For more information, see [Attribute-Based Mapping](../../../../../../docs/framework/data/adonet/sql/linq/attribute-based-mapping.md).  
  
- A static SQL method specific to [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].  
  
- A function supported by a .NET Framework method.  
  
 The topics in this section show how to form and call these methods in your application if you write the code yourself. Developers using Visual Studio would typically use the Object Relational Designer to map user-defined functions.  
  
## In This Section  
 [How to: Use Scalar-Valued User-Defined Functions](../../../../../../docs/framework/data/adonet/sql/linq/how-to-use-scalar-valued-user-defined-functions.md)  
 Describes how to implement a function that returns scalar values.  
  
 [How to: Use Table-Valued User-Defined Functions](../../../../../../docs/framework/data/adonet/sql/linq/how-to-use-table-valued-user-defined-functions.md)  
 Describes how to implement a function that returns table values.  
  
 [How to: Call User-Defined Functions Inline](../../../../../../docs/framework/data/adonet/sql/linq/how-to-call-user-defined-functions-inline.md)  
 Describes how to make inline calls to functions and the differences in execution when the call is made inline.
