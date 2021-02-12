---
description: "Learn more about: ParamArray (Visual Basic)"
title: "ParamArray"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.ParamArray"
  - "ParamArray"
helpviewer_keywords: 
  - "ParamArray keyword [Visual Basic]"
  - "ParamArray keyword [Visual Basic], syntax"
ms.assetid: a5f18789-92bd-488f-9c7e-cf3719963635
---
# ParamArray (Visual Basic)

Specifies that a procedure parameter takes an optional array of elements of the specified type. `ParamArray` can be used only on the last parameter of a parameter list.  
  
## Remarks  

 `ParamArray` allows you to pass an arbitrary number of arguments to the procedure. A `ParamArray` parameter is always declared using [ByVal](byval.md).  
  
 You can supply one or more arguments to a `ParamArray` parameter by passing an array of the appropriate data type, a comma-separated list of values, or nothing at all. For details, see "Calling a ParamArray" in [Parameter Arrays](../../programming-guide/language-features/procedures/parameter-arrays.md).  
  
> [!IMPORTANT]
> Whenever you deal with an array which can be indefinitely large, there is a risk of overrunning some internal capacity of your application. If you accept a parameter array from the calling code, you should test its length and take appropriate steps if it is too large for your application.  
  
 The `ParamArray` modifier can be used in these contexts:  
  
 [Declare Statement](../statements/declare-statement.md)  
  
 [Function Statement](../statements/function-statement.md)  
  
 [Property Statement](../statements/property-statement.md)  
  
 [Sub Statement](../statements/sub-statement.md)  
  
## See also

- [Keywords](../keywords/index.md)
- [Parameter Arrays](../../programming-guide/language-features/procedures/parameter-arrays.md)
