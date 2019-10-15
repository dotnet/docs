---
title: "Parameters (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 8d618edd-0988-4ff2-8263-ce59448af7a5
---
# Parameters (Entity SQL)
Parameters are variables that are defined outside [!INCLUDE[esql](../../../../../../includes/esql-md.md)], usually through a binding API that is used by a host language. Each parameter has a name and a type. Parameter names are defined in query expressions with the at (@) symbol as a prefix. This disambiguates them from the names of properties or other names that are defined in the query.  
  
 The host-language binding API provides APIs for binding parameters.  
  
## Example  
  
```sql  
SELECT c   
      FROM LOB.Customers AS c   
      WHERE c.Name = @name  
```  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Entity SQL Overview](entity-sql-overview.md)
