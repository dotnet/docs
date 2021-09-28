---
description: "Learn more about: BC36635: Lambda expressions are not valid in the first expression of a 'Select Case' statement"
title: "Lambda expressions are not valid in the first expression of a 'Select Case' statement"
ms.date: 07/20/2015
f1_keywords:
  - "bc36635"
  - "vbc36635"
helpviewer_keywords:
  - "BC36635"
ms.assetid: 74609979-9c03-4864-bbce-f588aa2e0917
---
# BC36635: Lambda expressions are not valid in the first expression of a 'Select Case' statement

You cannot use a lambda expression for the test expression in a `Select Case` statement. Lambda expression definitions return functions, and the test expression of a `Select Case` statement must be an elementary data type.

 The following code causes this error:

```vb
' Select Case (Function(arg) arg Is Nothing)
    ' List of the cases.
' End Select
```

 **Error ID:** BC36635

## To correct this error

- Examine your code to determine whether a different conditional construction, such as an `If...Then...Else` statement, would work for you.

- You may have intended to call the function, as shown in the following code:

```vb
Dim num? As Integer
Select Case ((Function(arg? As Integer) arg Is Nothing)(num))
    ' List of the cases
End Select
```

## See also

- [Lambda Expressions](../../programming-guide/language-features/procedures/lambda-expressions.md)
- [If...Then...Else Statement](../statements/if-then-else-statement.md)
- [Select...Case Statement](../statements/select-case-statement.md)
