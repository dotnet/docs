---
description: "Learn more about: Private (Visual Basic)"
title: "Private"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Private"
helpviewer_keywords: 
  - "Private keyword [Visual Basic]"
  - "Private keyword [Visual Basic], syntax"
ms.assetid: aba74a2e-5824-4613-bf63-b9ec7787f4e6
---
# Private (Visual Basic)

Specifies that one or more declared programming elements are accessible only from within their declaration context, including from within any contained types.  
  
## Remarks  

 If a programming element represents proprietary functionality, or contains confidential data, you usually want to limit access to it as strictly as possible. You achieve the maximum limitation by allowing only the module, class, or structure that defines it to access it. To limit access to an element in this way, you can declare it with `Private`.  

> [!NOTE]
> You can also use the [Private Protected](private-protected.md) access modifier, which makes a member accessible from within that class and from derived classes located in its containing assembly.

## Rules  

- **Declaration Context.** You can use `Private` only at module level. This means the declaration context for a `Private` element must be a module, class, or structure, and cannot be a source file, namespace, interface, or procedure.  
  
## Behavior  
  
- **Access Level.** All code within a declaration context can access its `Private` elements. This includes code within a contained type, such as a nested class or an assignment expression in an enumeration. No code outside of the declaration context can access its `Private` elements.  
  
- **Access Modifiers.** The keywords that specify access level are called *access modifiers*. For a comparison of the access modifiers, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).  
  
 The `Private` modifier can be used in these contexts:  
  
 [Class Statement](../statements/class-statement.md)  
  
 [Const Statement](../statements/const-statement.md)  
  
 [Declare Statement](../statements/declare-statement.md)  
  
 [Delegate Statement](../statements/delegate-statement.md)  
  
 [Dim Statement](../statements/dim-statement.md)  
  
 [Enum Statement](../statements/enum-statement.md)  
  
 [Event Statement](../statements/event-statement.md)  
  
 [Function Statement](../statements/function-statement.md)  
  
 [Interface Statement](../statements/interface-statement.md)  
  
 [Property Statement](../statements/property-statement.md)  
  
 [Structure Statement](../statements/structure-statement.md)  
  
 [Sub Statement](../statements/sub-statement.md)  
  
## See also

- [Public](public.md)
- [Protected](protected.md)
- [Friend](friend.md)
- [Private Protected](./private-protected.md)
- [Protected Friend](./protected-friend.md)
- [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
