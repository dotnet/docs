---
title: "Cannot refer to '<name>' because it is a member of the value-typed field '<name>' of class '<classname>' which has 'System.MarshalByRefObject' as a base class"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc30310"
  - "bc30310"
helpviewer_keywords: 
  - "BC30310"
ms.assetid: 2aeb8872-7c87-4f01-98ef-9714ba3eebbe
---
# Cannot refer to '\<name>' because it is a member of the value-typed field '\<name>' of class '\<classname>' which has 'System.MarshalByRefObject' as a base class
The `System.MarshalByRefObject` class enables applications that support remote access to objects across application domain boundaries. Types must inherit from the `MarshalByRejectObject` class when the type is used across application domain boundaries. The state of the object must not be copied because the members of the object are not usable outside the application domain in which they were created.  
  
 **Error ID:** BC30310  
  
## To correct this error  
  
1.  Check the reference to make sure the member being referred to is valid.  
  
2.  Explicitly qualify the member with the `Me` keyword.  
  
## See also
- <xref:System.MarshalByRefObject>
- [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)
