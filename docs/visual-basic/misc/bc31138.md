---
description: "Learn more about: 'AddHandler', 'RemoveHandler' and 'RaiseEvent' method parameters cannot be declared '<modifier>'"
title: "'AddHandler', 'RemoveHandler' and 'RaiseEvent' method parameters cannot be declared '<modifier>'"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc31138"
  - "bc31138"
helpviewer_keywords: 
  - "BC31138"
ms.assetid: 6d8df92a-95fc-4a7d-ab1e-06d312155c55
---
# 'AddHandler', 'RemoveHandler' and 'RaiseEvent' method parameters cannot be declared '\<modifier>'

The parameters of the `AddHandler`, `RemoveHandler`, and `RaiseEvent` methods cannot be declared with the `Optional` or `ParamArray` modifiers.  
  
 The `Optional` or `ParamArray` modifiers are allowed only on parameters in `Declare`, `Function`, `Property`, and `Sub` declarations.  
  
 **Error ID:** BC31138  
  
## To correct this error  
  
- Remove the `Optional` or `ParamArray` keyword from the parameter list.  
  
## See also

- [Event Statement](../language-reference/statements/event-statement.md)
- [AddHandler statement](../language-reference/statements/addhandler-statement.md)
- [RemoveHandler statement](../language-reference/statements/removehandler-statement.md)
- [RaiseEvent statement](../language-reference/statements/raiseevent-statement.md)
- [Optional](../language-reference/modifiers/optional.md)
- [ParamArray](../language-reference/modifiers/paramarray.md)
- [Events](../programming-guide/language-features/events/index.md)
