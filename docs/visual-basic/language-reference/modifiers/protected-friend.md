---
title: "Protected Friend (Visual Basic)"
ms.date: 05/10/2018
helpviewer_keywords: 
  - "Protected Friend keyword [Visual Basic]"
  - "Protected Friend keyword [Visual Basic], syntax"
---
# Protected Friend (Visual Basic)

The `Protected Friend` keyword combination is a member access modifier. It confers both [Friend](friend.md) access and [Protected](protected.md) access on the declared elements, so they are accessible from anywhere in the same assembly, from their own class, and from derived classes. You can specify `Protected Friend` only on members of classes; you cannot apply `Protected Friend` to members of a structure because structures cannot be inherited.

> [!NOTE]
> In Visual Studio, selecting F1 help on `protected friend` provides help for either [protected](protected.md) or [friend](friend.md). The IDE picks the single token under the cursor rather than the compound word.

## Rules

- **Declaration Context.** You can use `Protected Friend` only at the class level. This means the declaration context for a `Protected` element must be a class, and cannot be a source file, namespace, interface, module, structure, or procedure. 


## See also

- [Public](../../../visual-basic/language-reference/modifiers/public.md)
- [Protected](../../../visual-basic/language-reference/modifiers/protected.md)
- [Friend](friend.md)
- [Private](../../../visual-basic/language-reference/modifiers/private.md)
- [Private Protected](./private-protected.md)
- [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)
- [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)
- [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)
- [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
