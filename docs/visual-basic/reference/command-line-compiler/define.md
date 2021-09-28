---
description: "Learn more about: -define (Visual Basic)"
title: "-define"
ms.date: 03/10/2018
helpviewer_keywords: 
  - "-d compiler option [Visual Basic]"
  - "/d compiler option [Visual Basic]"
  - "-define compiler option [Visual Basic]"
  - "d compiler option [Visual Basic]"
  - "/define compiler option [Visual Basic]"
  - "define compiler option [Visual Basic]"
ms.assetid: f735c57d-1cf9-4f2f-a26f-0de630fd4077
---
# -define (Visual Basic)

Defines conditional compiler constants.  
  
## Syntax  
  
```console  
-define:["]symbol[=value][,symbol[=value]]["]  
```

or

```console  
-d:["]symbol[=value][,symbol[=value]]["]  
```  
  
## Arguments  
  
|Term|Definition|  
|---|---|  
|`symbol`|Required. The symbol to define.|  
|`value`|Optional. The value to assign `symbol`. If `value` is a string, it must be surrounded by backslash/quotation-mark sequences (\\") instead of quotation marks. If no value is specified, then it is taken to be True.|  
  
## Remarks  

 The `-define` option has an effect similar to using a `#Const` preprocessor directive in your source file, except that constants defined with `-define` are public and apply to all files in the project.  
  
 You can use symbols created by this option with the `#If`...`Then`...`#Else` directive to compile source files conditionally.  
  
 `-d` is the short form of `-define`.  
  
 You can define multiple symbols with `-define` by using a comma to separate symbol definitions.  
  
|To set -define in the Visual Studio integrated development environment|  
|---|  
|1.  Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties**. <br />2.  Click the **Compile** tab.<br />3.  Click **Advanced**.<br />4.  Modify the value in the **Custom Constants** box.|  
  
## Example  

 The following code defines and then uses two conditional compiler constants.  
  
 [!code-vb[VbVbalrCompiler#45](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrCompiler/VB/Class1.vb#45)]  
  
## See also

- [Visual Basic Command-Line Compiler](index.md)
- [#If...Then...#Else Directives](../../language-reference/directives/if-then-else-directives.md)
- [#Const Directive](../../language-reference/directives/const-directive.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
