---
title: "Private Protected (Visual Basic)"
ms.date: 05/10/2018
helpviewer_keywords: 
  - "Private Protected keyword [Visual Basic]"
  - "Private Protected keyword [Visual Basic], syntax"
---
# Private Protected (Visual Basic)

The `Private Protected` keyword combination is a member access modifier. A `Private Protected` member is accessible by types derived from the containing class, but only if they are found in its containing assembly.

## Rules

- **Declaration Context.** You can use `Private Protected` only at the class level. This means the declaration context for a `Protected` element must be a class, and cannot be a source file, namespace, interface, module, structure, or procedure.

## See Also

[Public](../../../visual-basic/language-reference/modifiers/public.md)  
[Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
[Friend](friend.md)   
[Private](../../../visual-basic/language-reference/modifiers/private.md)  
[Protected Friend](./protected-friend.md)   
[Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
[Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)  
[Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
[Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
