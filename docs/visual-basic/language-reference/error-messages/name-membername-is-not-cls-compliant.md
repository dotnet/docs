---
description: "Learn more about: BC40031: Name <membername> is not CLS-compliant"
title: "Name <membername> is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "bc40031"
  - "vbc40031"
helpviewer_keywords:
  - "BC40031"
ms.assetid: e2b885dc-cbf9-49ff-bbbe-531657ea99f7
---
# BC40031: Name \<membername> is not CLS-compliant

An assembly is marked as `<CLSCompliant(True)>` but exposes a member with a name that begins with an underscore (`_`).

 A programming element can contain one or more underscores, but to be compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), it must not begin with an underscore. See [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md).

 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.

 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40031

## To correct this error

- If you have control over the source code, change the member name so that it does not begin with an underscore.

- If you require that the member name remain unchanged, remove the <xref:System.CLSCompliantAttribute> from its definition or mark it as `<CLSCompliant(False)>`. You can still mark the assembly as `<CLSCompliant(True)>`.

## See also

- [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md)
- [Visual Basic Naming Conventions](../../programming-guide/program-structure/naming-conventions.md)
