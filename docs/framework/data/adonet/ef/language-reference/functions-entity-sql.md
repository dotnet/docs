---
title: "Functions (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 52b3d776-5acc-4f69-b614-5a43ce56ef9f
---
# Functions (Entity SQL)
Entity SQL supports user-defined functions, canonical functions, and provider-specific functions. User-defined functions are specified in the conceptual model or inline in the query. For more information, see [User-Defined Functions](user-defined-functions-entity-sql.md).  
  
 Canonical functions are predefined in the Entity Framework and should be supported by data providers. Entity SQL commands will fail if a user calls a function that is not supported by a provider. Therefore, canonical functions are generally recommended over store-specific functions, which are in a provider-specific namespace. For more information, see [Canonical Functions](canonical-functions.md).  
  
 The Microsoft SQL Client Managed Provider provides a set of provider-specific functions. For more information, see [SqlClient for Entity Framework Functions](../sqlclient-for-ef-functions.md).  
  
## In This Section  
 [User-Defined Functions](user-defined-functions-entity-sql.md)  
  
 [Function Overload Resolution](function-overload-resolution-entity-sql.md)  
  
 [Aggregate Functions](../aggregate-functions-sqlclient-for-entity-framework.md)  
  
## See also

- [Entity SQL Overview](entity-sql-overview.md)
