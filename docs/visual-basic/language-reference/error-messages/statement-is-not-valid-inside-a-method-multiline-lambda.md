---
description: "Learn more about: BC30024: Statement is not valid inside a method/multiline lambda"
title: "Statement is not valid inside a method-multiline lambda"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30024"
  - "bc30024"
helpviewer_keywords:
  - "BC30024"
ms.assetid: 758e7a8f-429b-42c1-9a78-778e5b480e04
---
# BC30024: Statement is not valid inside a method/multiline lambda

The statement is not valid within a `Sub`, `Function`, property `Get`, or property `Set` procedure. Some statements can be placed at the module or class level. Others, such as `Option Strict`, must be at namespace level and precede all other declarations.

 **Error ID:** BC30024

## To correct this error

- Remove the statement from the procedure.

## See also

- [Sub Statement](../statements/sub-statement.md)
- [Function Statement](../statements/function-statement.md)
- [Get Statement](../statements/get-statement.md)
- [Set Statement](../statements/set-statement.md)
