---
description: "Learn more about: Named Type Constructor (Entity SQL)"
title: "Named Type Constructor (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 549dea04-d93d-4c87-a292-f81b1598dbfd
---
# Named Type Constructor (Entity SQL)

Used to create instances of conceptual model nominal types such as Entity or Complex types.  
  
## Syntax  
  
```sql  
[{identifier. }] identifier( [expression [{, expression }]] )  
```  
  
## Arguments  

 `identifier`  
 Value that is a simple or quoted identifier. For more information see, [Identifiers](identifiers-entity-sql.md)  
  
 `expression`  
 Attributes of the type that are assumed to be in the same order as they appear in the declaration of the type.  
  
## Return Value  

 Instances of named complex types and entity types.  
  
## Remarks  

 The following examples show how to construct nominal and complex types:  
  
 The expression below creates an instance of a `Person` type:  
  
 `Person("abc", 12)`  
  
 The expression below creates an instance of a complex type:  
  
 `MyModel.ZipCode(‘98118’, ‘4567’)`  
  
 The expression below creates an instance of a nested complex type:  
  
 `MyModel.AddressInfo('My street address', 'Seattle', 'WA', MyModel.ZipCode('98118', '4567'))`  
  
 The expression below creates an instance of an entity with a nested complex type:  
  
 `MyModel.Person("Bill", MyModel.AddressInfo('My street address', 'Seattle', 'WA', MyModel.ZipCode('98118', '4567')))`  
  
 The following example shows how to initialize a property of a complex type to null:`MyModel.ZipCode(‘98118’, null)`  
  
## Example  

 The following Entity SQL query uses the named type constructor to create an instance of a conceptual model type. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#NAMED_TYPE_CONSTRUCTOR](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#named_type_constructor)]  
  
## See also

- [Constructing Types](constructing-types-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
