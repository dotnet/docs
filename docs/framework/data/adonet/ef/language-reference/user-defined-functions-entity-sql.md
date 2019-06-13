---
title: "User-Defined Functions (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 3f9e6bbd-8e5a-43e1-809f-f8a61338e522
---
# User-Defined Functions (Entity SQL)
Entity SQL supports calling user-defined functions in a query. You can define these functions inline with the query (see [How to: Call a User-Defined Function](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/dd490951(v=vs.100))) or as part of the conceptual model (see [How to: Define Custom Functions in the Conceptual Model](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/dd456812(v=vs.100))). Conceptual model functions are defined as an Entity SQL command in the [DefiningExpression](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec#definingexpression-element-csdl) element of a [Function](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec#function-element-csdl) element in the conceptual model.  
  
 Entity SQL enables you to define functions in the query command itself. The [FUNCTION](../../../../../../docs/framework/data/adonet/ef/language-reference/function-entity-sql.md) operator defines inline functions. You can define multiple functions in a single command, and these functions can have the same function name, as long as the function signatures are unique. For more information, see [Function Overload Resolution](../../../../../../docs/framework/data/adonet/ef/language-reference/function-overload-resolution-entity-sql.md).  
  
## See also

- [Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/functions-entity-sql.md)
