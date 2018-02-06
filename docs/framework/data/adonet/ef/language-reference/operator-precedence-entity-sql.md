---
title: "Operator Precedence (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e92e4ca5-2889-4266-9625-47f0eb01a948
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Operator Precedence (Entity SQL)
When an [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query has multiple operators, operator precedence determines the sequence in which the operations are performed. The order of execution can significantly affect the query result.  
  
 Operators have the precedence levels shown in the following table. An operator with a higher level is evaluated before an operator with a lower level.  
  
|Level|Operation type|Operator|  
|-----------|--------------------|--------------|  
|1|Primary|`. , [] ()`|  
|2|Unary|`! not`|  
|3|Multiplicative|`* / %`|  
|4|Additive|`+ -`|  
|5|Ordering|`< > <= >=`|  
|6|Equality|`= != <>`|  
|7|Conditional AND|`and &&`|  
|8|Conditional OR|`or &#124;&#124;`|  
  
 When two operators in an expression have the same operator precedence level, they are evaluated left to right, based on their position in the query. For example, `x+y-z` is evaluated as `(x+y)-z`.  
  
 You can use parentheses to override the defined precedence of the operators in a query. Everything within parentheses is evaluated first to yield a single result before that result can be used by any operator outside the parentheses. For example, `x+y*z` multiplies `y` by `z` and then adds `x`, but `(x+y)*z` adds `x` to `y` and then multiplies the result by `z`.  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
