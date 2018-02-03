---
title: "ByteStream Encoder"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e674a8ab-f79a-4a93-b984-54b34392dafc
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ByteStream Encoder
This sample demonstrates how to create a `ByteStreamHttpBinding`, a <xref:System.ServiceModel.Channels.Binding> that demonstrates the functionality of the byte stream encoder.  
  
## Discussion  
 This sample demonstrates how to create a standard <xref:System.ServiceModel.Channels.Binding> using the standard binding elements <xref:System.ServiceModel.Channels.ByteStreamMessageEncodingBindingElement> and <xref:System.ServiceModel.Channels.HttpTransportBindingElement>. This sample shows how to use the byte stream encoder to upload and download an image. The byte stream encoder feature only supports the HTTP transport and it does not support features such as reliable messaging or security. The only <xref:System.ServiceModel.Channels.MessageVersion> supported is <xref:System.ServiceModel.Channels.MessageVersion.None%2A>.  
  
> [!IMPORTANT]
>  If you are running this sample in [!INCLUDE[windowsver](../../../../includes/windowsver-md.md)] or [!INCLUDE[win7_client_firstref](../../../../includes/win7-client-firstref-md.md)], ensure that you are running [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)] with elevated privileges.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Binding\ByteStreamEncoder`  
  
#### To set up, build, and run the sample  
  
1.  Open the ByteStreamHttpBinding.sln file in [!INCLUDE[vs_current_long](../../../../includes/vs-current-long-md.md)].  
  
2.  Start a new instance of the ByteStreamHttpBindingServer project by right-clicking the project in the Solution Explorer and selecting **Debug**, and then **Start new instance** from the context menu.  
  
3.  Start a new instance of the ByteStreamHttpBindingClient project by right-clicking the project in the Solution Explorer and selecting **Debug**, **Start new instance** from the context menu.
