---
title: "#ExternalSource Directive"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "#Externalsource"
  - "#ExternalSource"
  - "vb.ExternalSource"
  - "Externalsource"
  - "vb.#ExternalSource"
  - "ExternalSource"
helpviewer_keywords: 
  - "ExternalSource directive (#ExternalSource)"
  - "#ExternalSource directive"
ms.assetid: 243bc6a2-34c3-4eeb-a776-9fd2bf988149
caps.latest.revision: 160
author: dotnet-bot
ms.author: dotnetcontent
---
# #ExternalSource Directive
Indicates a mapping between specific lines of source code and text external to the source.  
  
## Syntax  
  
```  
#ExternalSource( StringLiteral , IntLiteral )  
    [ LogicalLine+ ]  
#End ExternalSource  
```  
  
## Parts  
 `StringLiteral`  
 The path to the external source.  
  
 `IntLiteral`  
 The line number of the first line of the external source.  
  
 `LogicalLine`  
 The line where the error occurs in the external source.  
  
 `#End ExternalSource`  
 Terminates the `#ExternalSource` block.  
  
## Remarks  
 This directive is used only by the compiler and the debugger.  
  
 A source file may include external source directives, which indicate a mapping between specific lines of code in the source file and text external to the source, such as an .aspx file. If errors are encountered in the designated source code during compilation, they are identified as coming from the external source.  
  
 External source directives have no effect on compilation and cannot be nested. They are intended for internal use by the application only.  
  
## See Also  
 [Conditional Compilation](../../../visual-basic/programming-guide/program-structure/conditional-compilation.md)
