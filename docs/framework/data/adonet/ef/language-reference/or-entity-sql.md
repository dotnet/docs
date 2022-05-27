---
description: "Learn more about: || (OR) (Entity SQL)"
title: "|| (OR) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 8e649648-eb9a-4380-9d74-36e62260628c
---
# || (OR) (Entity SQL)

Combines two `Boolean` expressions.

## Syntax

```sql
boolean_expression OR boolean_expression
-- or
boolean_expression || boolean_expression
```

## Arguments

 `boolean_expression`
 Any valid expression that returns a `Boolean`.

## Return Value

 `true` when either of the conditions is `true`; otherwise, `false`.

## Remarks

 OR is an Entity SQL logical operator. It is used to combine two conditions. When more than one logical operator is used in a statement, OR operators are evaluated after AND operators. However, you can change the order of evaluation by using parentheses.

 Double vertical bars (&#124;&#124;) have the same functionality as the OR operator.

 The following matrix shows possible input value combinations and return values.

|             | `TRUE` | `FALSE` | `NULL` |
| ----------- | ------ | ------- | ------ |
| **`TRUE`**  | TRUE   | TRUE    | TRUE   |
| **`FALSE`** | TRUE   | FALSE   | NULL   |
| **`NULL`**  | TRUE   | NULL    | NULL   |

## Example

 The following Entity SQL query uses the OR operator to combine two `Boolean` expressions. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts 2#OR](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#or)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
