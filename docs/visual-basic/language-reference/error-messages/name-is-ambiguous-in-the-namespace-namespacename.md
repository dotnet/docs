---
description: "Learn more about: BC30560: '<name>' is ambiguous in the namespace '<namespacename>'"
title: "'<name>' is ambiguous in the namespace '<namespacename>'"
ms.date: 07/20/2015
f1_keywords:
  - "bc30560"
  - "vbc30560"
helpviewer_keywords:
  - "BC30560"
ms.assetid: 7f032293-054b-4eae-8d97-3db8e7ddde3b
---
# BC30560: '\<name>' is ambiguous in the namespace '\<namespacename>'

You have provided a name that is ambiguous and therefore conflicts with another name. The Visual Basic compiler does not have any conflict resolution rules; you must disambiguate names yourself.This happens when two versions of the same library are included from different references, and the solution is to look in the Object Explorer to find which references are causing the ambiguity and remove one of them.

 
 **Error ID:** BC30560

## To correct this error

- Fully qualify the name. 

## See also

- [Namespaces in Visual Basic](../../programming-guide/program-structure/namespaces.md)
- [Namespace Statement](../statements/namespace-statement.md)
