---
description: "Learn more about: Public (Visual Basic)"
title: "Public"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Public"
helpviewer_keywords: 
  - "Public keyword [Visual Basic]"
  - "Public keyword [Visual Basic], syntax"
  - "Public access modifier"
ms.assetid: 284c9e1b-ed23-499b-9bc9-ad87c11485a5
---
# Public (Visual Basic)

Specifies that one or more declared programming elements have no access restrictions.  
  
## Remarks  

 If you are publishing a component or set of components, such as a class library, you usually want the programming elements to be accessible by any code that interoperates with your assembly. To confer such unlimited access on an element, you can declare it with `Public`.  
  
 Public access is the normal level for a programming element when you do not need to limit access to it. Note that the access level of an element declared within an interface, module, class, or structure defaults to `Public` if you do not declare it otherwise.  
  
## Rules  
  
- **Declaration Context.** You can use `Public` only at module, interface, or namespace level. This means the declaration context for a `Public` element must be a source file, namespace, interface, module, class, or structure, and cannot be a procedure.  
  
## Behavior  
  
- **Access Level.** All code that can access a module, class, or structure can access its `Public` elements.  
  
- **Default Access.** Local variables inside a procedure default to public access, and you cannot use any access modifiers on them.  
  
- **Access Modifiers.** The keywords that specify access level are called *access modifiers*. For a comparison of the access modifiers, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).  
  
 The `Public` modifier can be used in these contexts:  
  
 [Class Statement](../statements/class-statement.md)  
  
 [Const Statement](../statements/const-statement.md)  
  
 [Declare Statement](../statements/declare-statement.md)  
  
 [Delegate Statement](../statements/delegate-statement.md)  
  
 [Dim Statement](../statements/dim-statement.md)  
  
 [Enum Statement](../statements/enum-statement.md)  
  
 [Event Statement](../statements/event-statement.md)  
  
 [Function Statement](../statements/function-statement.md)  
  
 [Interface Statement](../statements/interface-statement.md)  
  
 [Module Statement](../statements/module-statement.md)  
  
 [Operator Statement](../statements/operator-statement.md)  
  
 [Property Statement](../statements/property-statement.md)  
  
 [Structure Statement](../statements/structure-statement.md)  
  
 [Sub Statement](../statements/sub-statement.md)  
  
## See also

- [Protected](protected.md)
- [Friend](friend.md)
- [Private](private.md)
- [Private Protected](private-protected.md)
- [Protected Friend](protected-friend.md)
- [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
