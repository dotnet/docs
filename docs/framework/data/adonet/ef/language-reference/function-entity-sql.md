---
title: "FUNCTION (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0bb88992-37ed-4991-ace5-55be612a2c4d
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# FUNCTION (Entity SQL)
Defines a function in the scope of an Entity SQL query command.  
  
## Syntax  
  
```  
FUNCTION function-name  
( [ { parameter_name <type_definition>   
        [ ,...n ]  
  ]  
) AS ( function_expression )   
  
<type_definition>::=  
    { data_type | COLLECTION ( <type_definition> )   
                | REF ( data_type )   
                | ROW ( row_expression )   
        }   
```  
  
## Arguments  
 `function-name`  
 Name of the function.  
  
 `parameter-name`  
 Name of a parameter in the function.  
  
 `function_expression`  
 A valid Entity SQL expression that is the function. The command in the function can act on `parameter_name` parameters passed to the function.  
  
 `data_type`  
 Name of a supported type.  
  
 COLLECTION ( <type_definition`>` )  
 An expression that returns a collection of supported types, rows, or references.  
  
 REF **(**`data_type`**)**  
 An expression that returns a reference to an entity type.  
  
 ROW **(**`row_expression`**)**  
 An expression that returns anonymous, structurally typed records from one or more values. For more information, see [ROW](../../../../../../docs/framework/data/adonet/ef/language-reference/row-entity-sql.md).  
  
## Remarks  
 Multiple functions with the same name can be declared inline, as long as the function signatures are different. For more information, see [Function Overload Resolution](../../../../../../docs/framework/data/adonet/ef/language-reference/function-overload-resolution-entity-sql.md).  
  
 An inline function can be called in an Entity SQL command only after it has been defined in that command. However, an inline function can be called inside another inline function either before or after the called function has been defined. In the following example, function A calls function B before function B is defined:  
  
 `Function A() as ('A calls B. ' + B())`  
  
 `Function B() as ('B was called.')`  
  
 `A()`  
  
 For more information, see [How to: Call a User-Defined Function](http://msdn.microsoft.com/library/ad131b86-8b4e-4747-8605-d4fc64fb9d02).  
  
 Functions can also be declared in the model itself. Functions declared in the model are executed in the same way as functions declared inline in the command. For more information, see [User-Defined Functions](../../../../../../docs/framework/data/adonet/ef/language-reference/user-defined-functions-entity-sql.md).  
  
## Example  
 The following Entity SQL command defines a function `Products` that takes an integer value to filter the returned products.  
  
 [!code-csharp[DP EntityServices Concepts 2#FUNCTION1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#function1)]  
  
## Example  
 The following Entity SQL command defines a function `StringReturnsCollection` that takes a collection of strings to filter the returned contacts.  
  
 [!code-csharp[DP EntityServices Concepts 2#FUNCTION2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#function2)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Entity SQL Language](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md)
