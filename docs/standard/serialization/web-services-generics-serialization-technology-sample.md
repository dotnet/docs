---
title: "Web Services Generics Serialization Technology Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cdc15ea4-f678-4729-8ebe-188ae720bef7
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Web Services Generics Serialization Technology Sample
[Download Sample](https://download.microsoft.com/download/4/7/B/47B2164C-E780-4B10-8DE4-2CB5B886E0A6/Technologies/Serialization/Xml%20Serialization/GenericsSerialization.zip.exe)  
  
 This sample shows how to use and control the serialization of generics in ASP.NET Web Services.  
  
### To build the sample using Visual Studio  
  
1.  Open Visual Studio and select **New Web Site** from the **File** menu.  
  
2.  In the **New Web Site** dialog, select from the left pane your desired programming language, then from the right pane, select **ASP.NET Web Service**.  
  
3.  Click **Browse** and navigate to the \CS\GenericsService subdirectory.  
  
4.  Select Service.asmx to open the file in Visual Studio.  
  
5.  On the **Build** menu, click **Build Solution**.  
  
> [!NOTE]
>  The first five steps in this list are optional. The .NET Framework runtime will automatically generate the Web service the first time the service is requested.  
  
> [!NOTE]
>  The following steps are required to build the sample.  
  
1.  Open [!INCLUDE[fileExplorer](../../../includes/fileexplorer-md.md)] and navigate to the \CS subdirectory.  
  
2.  Right-click the icon for the GenericsService subdirectory, and select **Sharing and Security**.  
  
3.  In the **Web Sharing** tab, select **Share this Folder**.  
  
> [!IMPORTANT]
>  Take note of the virtual directory name that is listed in the **Aliases** pane, because you will need it to run the sample.  
  
### To build the sample using Internet Information Services  
  
1.  Open the **Internet Information Services** management snap-in and expand **Web Sites**.  
  
2.  Left-click **Default Web Site**, select **New**, and then select **Virtual Directory?** to create the **Virtual Directory Creation Wizard**.  
  
3.  Click **Next**, enter the public alias for your virtual directory, and click **Next**.  
  
4.  Enter the path to the directory where you saved the sample (normally the \CS\GenericsService subdirectory) and click **Next**. Click **Next** to finish the wizard.  
  
> [!IMPORTANT]
>  Take note of the virtual directory name that is listed in the **Alias** pane, because you will need it to run the sample.  
  
### To run the sample  
  
1.  Open a browser window and select its address bar.  
  
2.  Type **http://localhost/[virtual directory]/Service.asmx**, where [virtual directory] represents the virtual directory you created when you built the sample.  
  
## Remarks  
 The sample displays a default ASP.NET page that contains links to the definition of the Web Service. You can customize the display in addition to modifying the source code for the Web service. For more information, see [Building XML Web Service Clients](https://msdn.microsoft.com/library/c606f3cb-4111-45b4-ae42-9300420fa16c).  
  
## See Also  
 <xref:System.Collections.Generic>  
 <xref:System.Web.Services>  
 <xref:System.Xml.Serialization>  
 [Serialization](../../../docs/standard/serialization/index.md)  
 [XML Web Services Created Using ASP.NET and XML Web Service Clients](https://msdn.microsoft.com/library/1e64af78-d705-4384-b08d-591a45f4379c)
