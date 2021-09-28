---
description: "Learn more about: BC36550: 'Extension' attribute can be applied only to 'Module', 'Sub', or 'Function' declarations"
title: "'Extension' attribute can be applied only to 'Module', 'Sub', or 'Function' declarations"
ms.date: 07/20/2015
f1_keywords:
  - "bc36550"
  - "vbc36550"
helpviewer_keywords:
  - "BC36550"
ms.assetid: 4387a51f-733c-45d7-abdb-eb64d4f51078
---
# BC36550: 'Extension' attribute can be applied only to 'Module', 'Sub', or 'Function' declarations

The only way to extend a data type in Visual Basic is to define an extension method inside a standard module. The extension method can be a `Sub` procedure or a `Function` procedure. All extension methods must be marked with the extension attribute, `<Extension()>`, from the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace. Optionally, a module that contains an extension method may be marked in the same way. No other use of the extension attribute is valid.

**Error ID:** BC36550

## To correct this error

- Remove the extension attribute.

- Redesign your extension as a method, defined in an enclosing module.

## Example

The following example defines a `Print` method for the `String` data type.

```vb
Imports StringUtility
Imports System.Runtime.CompilerServices
Namespace StringUtility
    <Extension()>
    Module StringExtensions
        <Extension()>
        Public Sub Print (ByVal str As String)
            Console.WriteLine(str)
        End Sub
    End Module
End Namespace
```

## See also

- [Attributes overview](../../programming-guide/concepts/attributes/index.md)
- [Extension Methods](../../programming-guide/language-features/procedures/extension-methods.md)
- [Module Statement](../statements/module-statement.md)
