---
title: "Calling Functions in LINQ to Entities Queries"
ms.date: "03/30/2017"
ms.assetid: 12a525a9-727c-4464-a0c7-71a0ef541792
---
# Calling Functions in LINQ to Entities Queries
The topics in this section describe how to call functions in LINQ to Entities queries.  
  
 The <xref:System.Data.Objects.EntityFunctions> and <xref:System.Data.Objects.SqlClient.SqlFunctions> classes provide access to canonical and database functions as part of the Entity Framework. For more information, see [How to: Call Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-canonical-functions.md) and [How to: Call Database Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-database-functions.md).  
  
 The process for calling a custom function requires three basic steps:  
  
1.  Define a function in your conceptual model or declare a function in your storage model.  
  
2.  Add a method to your application and map it to the function in the model with an <xref:System.Data.Objects.DataClasses.EdmFunctionAttribute>.  
  
3.  Call the function in a LINQ to Entities query.  
  
 For more information, see the topics in this section.  
  
## In This Section  
 [How to: Call Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-canonical-functions.md)  
  
 [How to: Call Database Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-database-functions.md)  
  
 [How to: Call Custom Database Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-custom-database-functions.md)  
  
 [How to: Call Model-Defined Functions in Queries](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-model-defined-functions-in-queries.md)  
  
 [How to: Call Model-Defined Functions as Object Methods](../../../../../../docs/framework/data/adonet/ef/language-reference/how-to-call-model-defined-functions-as-object-methods.md)  
  
## See also
- [Queries in LINQ to Entities](../../../../../../docs/framework/data/adonet/ef/language-reference/queries-in-linq-to-entities.md)
- [Canonical Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/canonical-functions.md)
- [.edmx File Overview](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/cc982042(v=vs.100))
- [How to: Define Custom Functions in the Conceptual Model](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/dd456812(v=vs.100))
