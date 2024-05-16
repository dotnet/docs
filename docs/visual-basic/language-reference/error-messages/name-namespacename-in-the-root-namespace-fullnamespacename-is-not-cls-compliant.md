---
description: "Learn more about: BC40039: Name <namespacename> in the root namespace <fullnamespacename> is not CLS-compliant"
title: "Name <namespacename> in the root namespace <fullnamespacename> is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "vbc40039"
  - "bc40039"
helpviewer_keywords:
  - "BC40039"
ms.assetid: c5bd5914-ae71-416a-8bed-f76f644f78be
---
# BC40039: Name \<namespacename> in the root namespace \<fullnamespacename> is not CLS-compliant

An assembly is marked as `<CLSCompliant(True)>`, but an element of the root namespace name begins with an underscore (`_`).

 A programming element can contain one or more underscores, but to be compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), it must not begin with an underscore. See [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md).

 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.

 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40039

## To correct this error

- If you require CLS compliance, change the root namespace name so that none of its elements begins with an underscore.

- If you require that the namespace name remain unchanged, then remove the <xref:System.CLSCompliantAttribute> from the assembly or mark it as `<CLSCompliant(False)>`.

## See also

- [Namespace Statement](../statements/namespace-statement.md)
- [Namespaces in Visual Basic](../../programming-guide/program-structure/namespaces.md)
- [-rootnamespace](../../reference/command-line-compiler/rootnamespace.md)
- [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic)
- [Declared Element Names](../../programming-guide/language-features/declared-elements/declared-element-names.md)
- [Visual Basic Naming Conventions](../../programming-guide/program-structure/naming-conventions.md)
