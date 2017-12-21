---
title: "How to: Install and Configure WCF Activation Components"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "HTTP activation [WCF]"
ms.assetid: 33a7054a-73ec-464d-83e5-b203aeded658
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Install and Configure WCF Activation Components
This topic describes the steps required to set up Windows Process Activation Service (also known as WAS) on [!INCLUDE[wv](../../../../includes/wv-md.md)] to host [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services that do not communicate over HTTP network protocols. The following sections outline the steps for this configuration:  
  
-   Install (or confirm the installation of) the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] activation components.  
  
-   Configure WAS to support a non-HTTP protocol. The following procedure configures [!INCLUDE[wv](../../../../includes/wv-md.md)] for TCP activation.  
  
 After installing and configuring WAS, see [How to: Host a WCF Service in WAS](../../../../docs/framework/wcf/feature-details/how-to-host-a-wcf-service-in-was.md) for the procedures to create a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service that exposes an non-HTTP endpoint that employs WAS.  
  
### To install the WCF non-HTTP activation components  
  
1.  Click the **Start** button, and then click **Control Panel**.  
  
2.  Click **Programs**, and then click **Programs and Features**.  
  
3.  On the **Tasks** menu, click **Turn Windows features on or off**.  
  
4.  Find the [!INCLUDE[vstecwinfx](../../../../includes/vstecwinfx-md.md)] node, select and then expand it.  
  
5.  Select the **WCF Non-Http Activation Components** box and save the setting.  
  
### To configure the WAS to support TCP activation  
  
1.  To support net.tcp activation, the default Web site must first be bound to a net.tcp port. You can do this by using Appcmd.exe, which is installed with the [!INCLUDE[iisver](../../../../includes/iisver-md.md)] management toolset. In an administrator-level Command Prompt window, run the following command.  
  
    ```  
    %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.tcp',bindingInformation='808:*']  
    ```  
  
    > [!NOTE]
    >  This command is a single line of text. This command adds a net.tcp site binding to the default Web site listening on TCP port 808 with any host name.  
  
2.  Although all applications within a site share a common net.tcp binding, each application can enable net.tcp support individually. To enable net.tcp for the application, run the following command from an administrator-level command prompt.  
  
    ```  
    %windir%\system32\inetsrv\appcmd.exe set app   
    "Default Web Site/<WCF Application>" /enabledProtocols:http,net.tcp  
    ```  
  
    > [!NOTE]
    >  This command is a single line of text. This command enables the /\<*WCF Application*> application to be accessed using both http://localhost*/\<WCF Application>* and net.tcp://localhost/*\<WCF Application>*.  
  
     Remove the net.tcp site binding you added for this sample.  
  
     As a convenience, the following two steps are implemented in a batch file called RemoveNetTcpSiteBinding.cmd located in the sample directory.  
  
    1.  Remove net.tcp from the list of enabled protocols by running the following command in an administrator-level Command Prompt window.  
  
        ```  
        %windir%\system32\inetsrv\appcmd.exe set app   
        "Default Web Site/servicemodelsamples<WCF Application>" " /enabledProtocols:http  
        ```  
  
        > [!NOTE]
        >  This command is a single line of text.  
  
    2.  Remove the net.tcp site binding by running the following command in an elevated Command Prompt window:  
  
        ```  
        %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site"   
        --bindings.[protocol='net.tcp',bindingInformation='808:*']  
        ```  
  
        > [!NOTE]
        >  This command is a single line of text.  
  
### To remove net.tcp from the list of enabled protocols  
  
1.  To remove net.tcp from the list of enabled protocols, run the following command in an administrator-level Command Prompt window.  
  
    ```  
    %windir%\system32\inetsrv\appcmd.exe set app "Default Web Site/servicemodelsamples<WCF Application>" " /enabledProtocols:http  
    ```  
  
    > [!NOTE]
    >  This command is a single line of text.  
  
### To remove the net.tcp site binding  
  
1.  To remove the net.tcp site binding run the following command in an administrator-level Command Prompt window.  
  
    ```  
    %windir%\system32\inetsrv\appcmd.exe set site "Default Web Site"   
    -bindings.[protocol='net.tcp',bindingInformation='808:*']  
    ```  
  
    > [!NOTE]
    >  This command is a single line of text.  
  
## See Also  
 [TCP Activation](../../../../docs/framework/wcf/samples/tcp-activation.md)  
 [MSMQ Activation](../../../../docs/framework/wcf/samples/msmq-activation.md)  
 [NamedPipe Activation](../../../../docs/framework/wcf/samples/namedpipe-activation.md)  
 [Windows Server App Fabric Hosting Features](http://go.microsoft.com/fwlink/?LinkId=201276)
