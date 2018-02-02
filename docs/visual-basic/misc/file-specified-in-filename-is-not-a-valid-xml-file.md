---
title: "File specified in FileName is not a valid XML file"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: c4c30bf3-e0ad-4bc8-89e0-2c3e49e9793b
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# File specified in FileName is not a valid XML file
The file name that you supplied is not a valid XML file. To specify the allowed structure and content of an XML document, you can use a Document Type Definition (DTD), a Microsoft XML-Data Reduced (XDR) schema, or an XML Schema definition language (XSD) schema. XSD schemas are the preferred way to specify XML grammars in the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)].  
  
> [!NOTE]
>  In some earlier versions of Visual Studio, the **XML Designer** is the designer for typed datasets and XML schema. The **XML Designer** can still be used to create and edit XML schema files. However, in [!INCLUDE[vs_current_long](~/includes/vs-current-long-md.md)], the designer for creating and editing typed datasets is the **Dataset Designer**. For more information, see [Creating and Editing Typed Datasets](/visualstudio/data-tools/creating-and-editing-typed-datasets).  
  
## To correct this error  
  
-   Check that you are supplying the correct file name.  
  
-   Check that the specified file contains valid XML by loading the XML file that you want to check into the **XML Designer**. From the **XML** menu, click **Validate XML**. Errors are displayed in the **Task List**.  
  
-   If the XML file has an associated XML Schema, check that the elements appear in the defined structure and that the content of the individual elements conforms to the declared data types specified in the schema.  
  
## See Also  
 <xref:System.Xml>  
 [How to: Parse File Paths](../../visual-basic/developing-apps/programming/drives-directories-files/how-to-parse-file-paths.md)
