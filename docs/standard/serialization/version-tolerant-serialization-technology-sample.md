---
title: "Version Tolerant Serialization Technology Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2a183664-bfbf-4ff0-96f6-c836284ea916
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Version Tolerant Serialization Technology Sample
[Download Sample](https://download.microsoft.com/download/4/7/B/47B2164C-E780-4B10-8DE4-2CB5B886E0A6/Technologies/Serialization/Runtime%20Serialization/VTS.zip.exe)  
  
 This sample demonstrates the version tolerance features of .NET Serialization. The sample builds applications that use different versions of a <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> to serialize and deserialize data. Despite the presence of different type versions, the applications communicate seamlessly. For more information, see [Version Tolerant Serialization](../../../docs/standard/serialization/version-tolerant-serialization.md).  
  
### To build the sample using the command prompt  
  
1.  Open a Command Prompt window and navigate to one of the language-specific subdirectories (under V1 Application or V2 Application) for the sample.  
  
2.  Type **msbuild.exe \<ver> application.sln** at the command line (where \<ver> is either v1 or v2).  
  
### To build the sample using Visual Studio  
  
1.  Open [!INCLUDE[fileExplorer](../../../includes/fileexplorer-md.md)] and navigate to one of the language-specific subdirectories for the sample.  
  
2.  Navigate to the V1 Application subdirectory of the directory you selected in the previous step.  
  
3.  Double-click the icon for V1 Application.sln to open the file in Visual Studio.  
  
4.  On the **Build** menu, click **Build Solution**.  
  
5.  Navigate to the V2 Application subdirectory and repeat the two previous steps to build the V2 Application.  
  
 The applications will be built in the default \bin or \bin\Debug subdirectories of their respective project directories.  
  
### To run the sample  
  
1.  In the Command Prompt window, navigate to the language-specific subdirectory that you selected when you built the sample applications.  
  
2.  Type **runme.cmd** at the command line to run both applications at once.  
  
 Alternatively, navigate to the directories that contain the new executables and run them sequentially.  
  
> [!NOTE]
>  The sample builds console applications. You must launch and run them in a Command Prompt window to view their output.  
  
## See Also  
 <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter>  
 <xref:System.IO.FileStream>
