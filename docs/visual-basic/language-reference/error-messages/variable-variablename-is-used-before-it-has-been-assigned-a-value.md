---
description: "Learn more about: BC42104: Variable '<variablename>' is used before it has been assigned a value"
title: "Variable '<variablename>' is used before it has been assigned a value"
ms.date: 07/20/2015
f1_keywords:
  - "vbc42104"
  - "BC42104"
helpviewer_keywords:
  - "BC42104"
ms.assetid: 6909aa0b-b4a1-46f5-a18c-ba3e565c1dd8
---
# BC42104: Variable '\<variablename>' is used before it has been assigned a value

Variable '\<variablename>' is used before it has been assigned a value. A null reference exception could result at run time.

 An application has at least one possible path through its code that reads a variable before any value is assigned to it.

 If a variable has never been assigned a value, it holds the default value for its data type. For a reference data type, that default value is [Nothing](../nothing.md). Reading a reference variable that has a value of `Nothing` can cause a <xref:System.NullReferenceException> in some circumstances.

 By default, this message is a warning. For more information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC42104

## To correct this error

- Check your control flow logic and make sure the variable has a valid value before control passes to any statement that reads it.

- One way to guarantee that the variable always has a valid value is to initialize it as part of its declaration. See "Initialization" in [Dim Statement](../statements/dim-statement.md).

## See also

- [Dim Statement](../statements/dim-statement.md)
- [Variable Declaration](../../programming-guide/language-features/variables/variable-declaration.md)
- [Troubleshooting Variables](../../programming-guide/language-features/variables/troubleshooting-variables.md)
