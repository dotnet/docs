---
description: "Learn more about: -imports (Visual Basic)"
title: "-imports"
ms.date: 03/10/2018
helpviewer_keywords: 
  - "/imports compiler option [Visual Basic]"
  - "imports compiler option [Visual Basic]"
  - "-imports compiler option [Visual Basic]"
ms.assetid: 9a93fb53-c080-497b-bf9b-441022dbbc39
---
# -imports (Visual Basic)

Imports namespaces from a specified assembly.  
  
## Syntax  
  
```console  
-imports:namespaceList  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`namespaceList`|Required. Comma-delimited list of namespaces to be imported.|  
  
## Remarks  

 The `-imports` option imports any namespace defined within the current set of source files or from any referenced assembly.  
  
 The members in a namespace specified with `-imports` are available to all source-code files in the compilation. Use the [Imports Statement (.NET Namespace and Type)](../../language-reference/statements/imports-statement-net-namespace-and-type.md) to use a namespace in a single source-code file.  
  
|To set -imports in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **References** tab.<br />3.  Enter the namespace name in the box beside the **Add User Import** button.<br />4.  Click the **Add User Import** button.|  
  
## Example  

 The following code compiles when `-imports:system.globalization` is specified. Without it, successful compilation requires either that an `Imports System.Globalization` statement be included at the beginning of the source code file, or that the property be fully qualified as `System.Globalization.CultureInfo.CurrentCulture.Name`.

```vb
Module Example
   Public Sub Main()
      Console.WriteLine($"The current culture is {CultureInfo.CurrentCulture.Name}")
   End Sub
End Module
```

## See also

- [Visual Basic Command-Line Compiler](index.md)
- [References and the Imports Statement](../../programming-guide/program-structure/references-and-the-imports-statement.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
