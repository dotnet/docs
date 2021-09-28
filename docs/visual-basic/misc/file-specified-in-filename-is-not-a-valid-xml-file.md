---
description: "Learn more about: File specified in FileName is not a valid XML file"
title: "File specified in FileName is not a valid XML file"
ms.date: 07/20/2015
ms.assetid: c4c30bf3-e0ad-4bc8-89e0-2c3e49e9793b
---
# File specified in FileName is not a valid XML file

The file name that you supplied is not a valid XML file. To specify the allowed structure and content of an XML document, you can use a Document Type Definition (DTD), a Microsoft XML-Data Reduced (XDR) schema, or an XML Schema definition language (XSD) schema. XSD schemas are the preferred way to specify XML grammars in the .NET Framework.

> [!NOTE]
> In some earlier versions of Visual Studio, the **XML Designer** is the designer for typed datasets and XML schema. The **XML Designer** can still be used to create and edit XML schema files. However, in Visual Studio 2012, the designer for creating and editing typed datasets is the **Dataset Designer**. For more information, see [Creating and Editing Typed Datasets](/previous-versions/visualstudio/visual-studio-2013/314t4see(v=vs.120)).

## To correct this error

- Check that you are supplying the correct file name.

- Check that the specified file contains valid XML by loading the XML file that you want to check into the **XML Designer**. From the **XML** menu, click **Validate XML**. Errors are displayed in the **Task List**.

- If the XML file has an associated XML Schema, check that the elements appear in the defined structure and that the content of the individual elements conforms to the declared data types specified in the schema.

## See also

- <xref:System.Xml>
- [How to: Parse File Paths](../developing-apps/programming/drives-directories-files/how-to-parse-file-paths.md)
