---
title: "Namespace or type specified in the project-level Imports &#39;&lt;qualifiedelementname&gt;&#39; doesn&#39;t contain any public member or cannot be found"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc40057"
  - "bc40057"
helpviewer_keywords: 
  - "BC40057"
ms.assetid: 4ae3506e-2ebe-4ff3-995d-14ac60db5e9f
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Namespace or type specified in the project-level Imports &#39;&lt;qualifiedelementname&gt;&#39; doesn&#39;t contain any public member or cannot be found
Namespace or type specified in the project-level Imports '\<qualifiedelementname>' doesn't contain any public member or cannot be found. Make sure the namespace or the type is defined and contains at least one public member. Make sure the alias name doesn't contain other aliases.  
  
 An import property of a project specifies a containing element that either cannot be found or does not define any `Public` members.  
  
 A *containing element* can be a namespace, class, structure, module, interface, or enumeration. The containing element contains members, such as variables, procedures, or other containing elements.  
  
 The purpose of importing is to allow your code to access namespace or type members without having to qualify them. Your project might also need to add a reference to the namespace or type. For more information, see "Importing Containing Elements" in [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md).  
  
 If the compiler cannot find the specified containing element, then it cannot resolve references that use it. If it finds the element but the element does not expose any `Public` members, then no reference can be successful. In either case it is meaningless to import the element.  
  
 You use the **Project Designer** to specify elements to import. Use the **Imported namespaces** section of the **References** page. You can get to the **Project Designer** by double-clicking the **My Project** icon in **Solution Explorer**.  
  
 **Error ID:** BC40057  
  
## To correct this error  
  
1.  Open the **Project Designer** and switch to the **Reference** page.  
  
2.  In the **Imported namespaces** section, verify that the containing element is accessible from your project.  
  
3.  Verify that the containing element exposes at least one `Public` member.  
  
## See Also  
 [References Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/references-page-project-designer-visual-basic)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)  
 [Public](../../../visual-basic/language-reference/modifiers/public.md)  
 [Namespaces in Visual Basic](../../../visual-basic/programming-guide/program-structure/namespaces.md)  
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)
