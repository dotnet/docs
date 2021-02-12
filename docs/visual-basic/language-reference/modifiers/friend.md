---
description: "Learn more about: Friend (Visual Basic)"
title: "Friend"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Friend"
helpviewer_keywords: 
  - "Friend keyword [Visual Basic]"
  - "Friend access modifier"
  - "Friend keyword [Visual Basic], syntax"
  - "Protected Friend keyword combination"
  - "Friend keyword [Visual Basic], and Protected"
ms.assetid: b664605e-1c79-4728-b996-aa59c50846bc
---
# Friend (Visual Basic)

Specifies that one or more declared programming elements are accessible only from within the assembly that contains their declaration.  
  
## Remarks  

 In many cases, you want programming elements such as classes and structures to be used by the entire assembly, not only by the component that declares them. However, you might not want them to be accessible by code outside the assembly (for example, if the application is proprietary). If you want to limit access to an element in this way, you can declare it by using the `Friend` modifier.  
  
 Code in other classes, structures, and modules that are compiled to the same assembly can access all the `Friend` elements in that assembly.  
  
 `Friend` access is often the preferred level for an application's programming elements, and `Friend` is the default access level of an interface, a module, a class, or a structure.  
  
 You can use `Friend` only at the module, interface, or namespace level. Therefore, the declaration context for a `Friend` element must be a source file, a namespace, an interface, a module, a class, or a structure; it can't be a procedure.  

> [!NOTE]
> You can also use the [Protected Friend](protected-friend.md) access modifier, which makes a class member accessible from within that class, from derived classes, and from the same assembly in which the class is defined. To restrict access to a member from within its class and from derived classes in the same assembly, you use the [Private Protected](private-protected.md) access modifier.

 For a comparison of `Friend` and the other access modifiers, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).  
  
> [!NOTE]
> You can specify that another assembly is a friend assembly, which allows it to access all types and members that are marked as `Friend`. For more information, see [Friend Assemblies](../../../standard/assembly/friend.md).

## Example  

 The following class uses the `Friend` modifier to allow other programming elements within the same assembly to access certain members.  
  
 [!code-vb[VbVbalrAccessModifiers#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalraccessmodifiers/vb/class1.vb#1)]  
  
## Usage  

 You can use the `Friend` modifier in these contexts:  
  
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
  
 [Property Statement](../statements/property-statement.md)  
  
 [Structure Statement](../statements/structure-statement.md)  
  
 [Sub Statement](../statements/sub-statement.md)  
  
## See also

- <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>
- [Public](public.md)
- [Protected](protected.md)
- [Private](private.md)
- [Private Protected](./private-protected.md)
- [Protected Friend](./protected-friend.md)
- [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md)
- [Procedures](../../programming-guide/language-features/procedures/index.md)
- [Structures](../../programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
