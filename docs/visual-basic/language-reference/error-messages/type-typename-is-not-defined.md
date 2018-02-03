---
title: "Type &#39;&lt;typename&gt;&#39; is not defined"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30002"
  - "bc30002"
helpviewer_keywords: 
  - "BC30002"
ms.assetid: b0faf204-57fd-44de-8c05-9db027eea663
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Type &#39;&lt;typename&gt;&#39; is not defined
The statement has made reference to a type that has not been defined. You can define a type in a declaration statement such as `Enum`, `Structure`, `Class`, or `Interface`.  
  
 **Error ID:** BC30002  
  
## To correct this error  
  
-   Ensure that the type definition and its reference both use the same spelling.  
  
-   Ensure that the type definition is accessible to the reference. For example, if the type is in another module and has been declared `Private`, move the type definition to the referencing module or declare it `Public`.  
  
-   Ensure that the namespace of the type is not redefined within your project. If it is, use the `Global` keyword to fully qualify the type name. For example, if a project defines a namespace named `System`, the <xref:System.Object?displayProperty=nameWithType> type cannot be accessed unless it is fully qualified with the `Global` keyword: `Global.System.Object`.  
  
-   If the type is defined, but the object library or type library in which it is defined is not registered in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], click **Add Reference** on the **Project** menu, and then select the appropriate object library or type library.  
  
-   Ensure that the type is in an assembly that is part of the targeted .NET Framework profile. For more information, see [Troubleshooting .NET Framework Targeting Errors](/visualstudio/msbuild/troubleshooting-dotnet-framework-targeting-errors).  
  
## See Also  
 [Namespaces in Visual Basic](../../../visual-basic/programming-guide/program-structure/namespaces.md)  
 [Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md)  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
 [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  
 [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)
