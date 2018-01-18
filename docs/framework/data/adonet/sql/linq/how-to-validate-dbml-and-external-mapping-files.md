---
title: "How to: Validate DBML and External Mapping Files"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d9ea37f5-0a9e-4401-8fc3-1e6fd44c49f9
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Validate DBML and External Mapping Files
External mapping files and .dbml files that you modify must be validated against their respective schema definitions. This topic provides [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] users with the steps to implement the validation process.  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
### To validate a .dbml or XML file  
  
1.  On the Visual Studio **File** menu, point to **Open**, and then click **File**.  
  
2.  In the **Open File** dialog box, click the .dbml or XML mapping file that you want to validate.  
  
     The file opens in the **XML Editor**.  
  
3.  Right-click the window, and then click **Properties**.  
  
4.  In the **Properties** window, click the ellipsis for the **Schemas** property.  
  
     The **XML Schemas** dialog box opens.  
  
5.  Note the appropriate schema definition for your purpose.  
  
    -   DbmlSchema.xsd is the schema definition for validating a .dbml file. For more information, see [Code Generation in LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/code-generation-in-linq-to-sql.md).  
  
    -   LinqToSqlMapping.xsd is the schema definition for validating an external XML mapping file. For more information, see [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md).  
  
6.  In the **Use** column of the desired schema definition row, click to open the drop-down box, and then click **Use this schema**.  
  
     The schema definition file is now associated with your DBML or XML mapping file.  
  
     Make sure no other schema definitions are selected.  
  
7.  On the **View** menu, click **Error List**.  
  
     Determine whether errors, warnings, or messages have been generated. If not, the XML file is valid against the schema definition.  
  
## Alternate Method for Supplying Schema Definition  
 If for some reason the appropriate .xsd file does not appear in the **XML Schemas** dialog box, you can download the .xsd file from a Help topic. The following steps help you save the downloaded file in the Unicode format required by the [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] XML Editor.  
  
#### To copy a schema definition file from a Help topic  
  
1.  Locate the Help topic that contains the schema definition as described earlier in this topic.  
  
    -   For .dbml files, see [Code Generation in LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/code-generation-in-linq-to-sql.md).  
  
    -   For external mapping files, see [External Mapping](../../../../../../docs/framework/data/adonet/sql/linq/external-mapping.md).  
  
2.  Click **Copy Code** to copy the code file to the Clipboard.  
  
3.  Start Notepad to create a new file.  
  
4.  Paste the code from the clipboard into Notepad file.  
  
5.  On the Notepad **File** menu, click **Save As**.  
  
6.  In the **Encoding** box, select **Unicode**.  
  
    > [!IMPORTANT]
    >  This selection guarantees that the Unicode-16 byte-order marker (`FFFE`) is prepended to the text file.  
  
7.  In the **File name** box, create a file name with an .xsd extension.  
  
## See Also  
 [Reference](../../../../../../docs/framework/data/adonet/sql/linq/reference.md)
