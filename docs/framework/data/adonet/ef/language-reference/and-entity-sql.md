---
description: "Learn more about: &amp;&amp; (AND) (Entity SQL)"
title: "&amp;&amp; (AND) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: e7d24213-471d-4807-b85e-570375df89b5
---
# &amp;&amp; (AND) (Entity SQL)

Returns `true` if both expressions are `true`; otherwise, `false` or `NULL`.  
  
## Syntax  
  
```csharp  
boolean_expression AND boolean_expression
```

or  

```csharp
boolean_expression && boolean_expression  
```  
  
## Arguments  

 `boolean_expression`  
 Any valid expression that returns a Boolean.  
  
## Remarks  

 Double ampersands (&&) have the same functionality as the `AND` operator.  
  
 The following matrix shows possible input value combinations and return values.  
  
|             | `TRUE` | `FALSE` | `NULL` |
| ----------- | ------ | ------- | ------ |
| **`TRUE`**  | TRUE   | FALSE   | NULL   |
| **`FALSE`** | FALSE  | FALSE   | FALSE  |
| **`NULL`**  | NULL   | FALSE   | NULL   |
  
## Example  

 The following Entity SQL query demonstrates how to use the AND operator. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#AND](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#and)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
