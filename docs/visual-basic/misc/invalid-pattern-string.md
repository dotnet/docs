---
title: "Invalid pattern string"
ms.date: 07/20/2015
ms.assetid: ec1aecdb-5339-4a93-be71-eec56b1d7438
---
# Invalid pattern string
The pattern string specified in the `Like` operation of a search is invalid.  
  
## To correct this error  
  
1. Review the valid characters for list expressions.  
  
2. In the pattern range, ensure that the start range character is less than the end range character, as in `[a-z]`.  
  
3. In the pattern range, ensure that there are not multiple hyphens next to each other, as in `[a--z]`.  
  
4. End pattern ranges with a closing bracket.  
  
## See also

- [Like Operator](../../visual-basic/language-reference/operators/like-operator.md)
