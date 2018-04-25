---
title: "Web Services IXmlSerializable Technology Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0202d3f1-a50b-427d-a5bb-79208b8f1c22
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Web Services IXmlSerializable Technology Sample
[Download Sample](https://download.microsoft.com/download/4/7/B/47B2164C-E780-4B10-8DE4-2CB5B886E0A6/Technologies/Serialization/Xml%20Serialization/IXmlSerializable.zip.exe)  
  
 This sample shows how to use <xref:System.Xml.Serialization.IXmlSerializable> to control the serialization of custom types in ASP.NET Web Services.  
  
### To build the sample using Visual Studio  
  
1.  Open [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] and select **New Web Site** from the **File** menu.  
  
2.  In the left pane of the **New Web Site** dialog, select your desired programming language, then from the right pane, select **ASP.NET Web Service**.  
  
3.  Type **IXmlSerializable** as the name of the new Web service.  
  
4.  In the Solution Explorer window, right-click the icon for Service.asmx and select **Delete**; repeat this step for the Service.asmx codebehind file.  
  
5.  Right-click the project directory and select **Add Existing Item**. In the dialog, navigate to the Service subdirectory of the language-specific directory.  
  
6.  Select Service.asmx, then repeat this step for the Service.asmx codebehind file.  
  
7.  Open [!INCLUDE[fileExplorer](../../../includes/fileexplorer-md.md)] and navigate to the directory that contains IXmlSerializable directory that you created in step 3 above.  
  
8.  Right-click the icon for the IXmlSerializable directory and select **Sharing and Security**.  
  
9. In the Web Sharing tab, select **Share this Folder**, and confirm the default settings, including the name IXmlSerializable.  
  
10. Click **OK**.  
  
### To run the sample  
  
1.  Open a browser window and select its address bar.  
  
2.  Type **http://localhost/IXmlSerializable/Service.asmx**.  
  
## See Also  
 <xref:System.Xml.Serialization.IXmlSerializable>  
 <xref:System.Xml.Serialization>  
 <xref:System.Xml.XmlConvert>  
 <xref:System.Xml.XmlQualifiedName>  
 <xref:System.Xml.XmlReader>  
 <xref:System.Xml.Schema.XmlSchema>  
 <xref:System.Xml.Schema.XmlSchemaSet>  
 <xref:System.Xml.XmlUrlResolver>  
 <xref:System.Xml.XmlWriter>
