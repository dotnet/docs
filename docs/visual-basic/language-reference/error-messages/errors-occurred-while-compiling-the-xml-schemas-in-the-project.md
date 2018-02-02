---
title: "Errors occurred while compiling the XML schemas in the project"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc36810"
  - "vbc36810"
helpviewer_keywords: 
  - "BC36810"
ms.assetid: 9323b5d2-ba14-4e49-91f1-9ad647162144
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Errors occurred while compiling the XML schemas in the project
Errors occurred while compiling the XML schemas in the project. Because of this, XML IntelliSense is not available.  
  
 There is an error in an XML Schema Definition (XSD) schema included in the project. This error occurs when you add an XSD schema (.xsd) file that conflicts with the existing XSD schema set for the project.  
  
 **Error ID:** BC36810  
  
## To correct this error  
  
-   Double-click the warning in the **Errors List** window. Visual Basic will take you to the location in the XSD file that is the source of the warning. Correct the error in the XSD schema.  
  
-   Ensure that all required XSD schema (.xsd) files are included in the project. You may need to click **Show All Files** on the **Project** menu to see your .xsd files in **Solution Explorer**. Right-click an .xsd file and then click **Include In Project** to include the file in your project.  
  
-   If you are using the XML to Schema Wizard, this error can occur if you infer schemas more than one time from the same source. In this case, you can remove the existing XSD schema files from the project, add a new XML to Schema item template, and then provide the XML to Schema Wizard with all the applicable XML sources for your project.  
  
-   If no error is identified in your XSD schema, the XML compiler may not have enough information to provide a detailed error message. You may be able to get more detailed error information if you ensure that the XML namespaces for the .xsd files included in your project match the XML namespaces identified for the XML Schema set in Visual Studio.  
  
## See Also  
 [Error List Window](/visualstudio/ide/reference/error-list-window)  
 [XML](../../../visual-basic/programming-guide/language-features/xml/index.md)
