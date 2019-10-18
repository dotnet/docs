---
title: "Optional parameters must specify a default value"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30812"
  - "bc30812"
helpviewer_keywords:
  - "BC30812"
ms.assetid: 5091a250-be66-413b-98a3-2a9974c4d600
---
# Optional parameters must specify a default value

Optional parameters must provide default values that can be used if no parameter is supplied by a calling procedure.

**Error ID:** BC30812

## Example

The following example generates BC30812:

```vb
Sub Proc1(x As Integer, Optional y As String)
    Console.WriteLine("Default argument is: " & y)
End Sub
```

## To correct this error

Specify default values for optional parameters:

```vb
Sub Proc1(x As Integer, Optional y As String = "Default Value")
    Console.WriteLine("Default argument is: " & y)
End Sub
```

## See also

- [Optional](../modifiers/optional.md)
