---
title: "LIKE (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8300e6d2-875b-481e-9ef4-e1e7c12d46fa
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# LIKE (Entity SQL)
Determines whether a specific character `String` matches a specified pattern.  
  
## Syntax  
  
```  
match [NOT] LIKE pattern [ESCAPE escape]  
```  
  
## Arguments  
 `match`  
 An [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expression that evaluates to a `String`.  
  
 `pattern`  
 A pattern to match to the specified `String`.  
  
 `escape`  
 An escape character.  
  
 NOT  
 Specifies that the result of LIKE be negated.  
  
## Return Value  
 `true` if the `string` matches the pattern; otherwise, `false`.  
  
## Remarks  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expressions that use the LIKE operator are evaluated in much the same way as expressions that use equality as the filter criteria. However, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expressions that use the LIKE operator can include both literals and wildcard characters.  
  
 The following table describes the syntax of the pattern `string`.  
  
|Wildcard Character|Description|Example|  
|------------------------|-----------------|-------------|  
|%|Any `string` of zero or more characters.|`title like '%computer%'` finds all titles with the word `"computer"` anywhere in the title.|  
|_ (underscore)|Any single character.|`firstname like '_ean'` finds all four-letter first names that end with `"ean`," such as Dean or Sean.|  
|[ ]|Any single character in the specified range ([a-f]) or set ([abcdef]).|`lastname like '[C-P]arsen'` finds last names ending with "arsen" and beginning with any single character between C and P, such as Carsen or Larsen.|  
|[^]|Any single character not in the specified range ([^a-f]) or set ([^abcdef]).|`lastname like 'de[^l]%'` finds all last names that begin with "de" and do not include "l" as the following letter.|  
  
> [!NOTE]
>  The [!INCLUDE[esql](../../../../../../includes/esql-md.md)] LIKE operator and ESCAPE clause cannot be applied to `System.DateTime` or `System.Guid` values.  
  
 LIKE supports ASCII pattern matching and Unicode pattern matching. When all parameters are ASCII characters, ASCII pattern matching is performed. If one or more of the arguments are Unicode, all arguments are converted to Unicode and Unicode pattern matching is performed. When you use Unicode with LIKE, trailing blanks are significant; however, for non-Unicode, trailing blanks are not significant. The pattern string syntax of [!INCLUDE[esql](../../../../../../includes/esql-md.md)] is the same as that of [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)].  
  
 A pattern can include regular characters and wildcard characters. During pattern matching, regular characters must exactly match the characters specified in the character `string`. However, wildcard characters can be matched with arbitrary fragments of the character string. When it is used with wildcard characters, the LIKE operator is more flexible than the = and != string comparison operators.  
  
> [!NOTE]
>  You may use provider-specific extensions if you target a specific provider. However, such constructs may be treated differently by other providers, for example. SqlServer supports [first-last] and [^first-last] patterns where the former matches exactly one character between first and last, and the latter matches exactly one character that is not between first and last.  
  
### Escape  
 By using the ESCAPE clause, you can search for character strings that include one or more of the special wildcard characters described in the table in the previous section. For example, assume several documents include the literal "100%" in the title and you want to search for all of those documents. Because the percent (%) character is a wildcard character, you must escape it using the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] ESCAPE clause to successfully execute the search. The following is an example of this filter.  
  
```  
"title like '%100!%%' escape '!'"  
```  
  
 In this search expression, the percent wildcard character (%) immediately following the exclamation point character (!) is treated as a literal, instead of as a wildcard character. You can use any character as an escape character except for the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] wildcard characters and the square bracket (`[ ]`) characters. In the previous example, the exclamation point (!) character is the escape character.  
  
## Example  
 The following two [!INCLUDE[esql](../../../../../../includes/esql-md.md)] queries use the LIKE and ESCAPE operators to determine whether a specific character string matches a specified pattern. The first query searches for the `Name` that starts with the characters `Down_`. This query uses the ESCAPE option because the underscore (`_`) is a wildcard character. Without specifying the ESCAPE option, the query would search for any `Name` values that start with the word `Down` followed by any single character other than the underscore character. The queries are based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2.  Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#LIKE](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#like)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
