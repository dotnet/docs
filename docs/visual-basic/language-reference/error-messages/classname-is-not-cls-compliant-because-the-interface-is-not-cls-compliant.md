---
description: "Learn more about: BC40029: '<classname>' is not CLS-compliant because the interface '<interfacename>' it implements is not CLS-compliant"
title: "'<classname>' is not CLS-compliant because the interface '<interfacename>' it implements is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "bc40029"
  - "vbc40029"
helpviewer_keywords:
  - "BC40029"
ms.assetid: 178452f3-5575-4da0-9d6c-53bcddb6a338
---
# BC40029: '\<classname>' is not CLS-compliant because the interface '\<interfacename>' it implements is not CLS-compliant

A class or interface is marked as `<CLSCompliant(True)>` when it derives from or implements a type that is marked as `<CLSCompliant(False)>` or is not marked.

 For a class or interface to be compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), its entire inheritance hierarchy must be compliant. That means every type from which it inherits, directly or indirectly, must be compliant. Similarly, if a class implements one or more interfaces, they must all be compliant throughout their inheritance hierarchies.

 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.

 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40029

## To correct this error

- If you require CLS compliance, define this type within a different inheritance hierarchy or implementation scheme.

- If you require that this type remain within its current inheritance hierarchy or implementation scheme, remove the <xref:System.CLSCompliantAttribute> from its definition or mark it as `<CLSCompliant(False)>`.
