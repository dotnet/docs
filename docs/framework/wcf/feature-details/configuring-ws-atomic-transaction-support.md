---
title: "Configuring WS-Atomic Transaction Support"
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
  - "WS-AT protocol [WCF], configuring WS-Atomic Transaction"
ms.assetid: cb9f1c9c-1439-4172-b9bc-b01c3e09ac48
caps.latest.revision: 31
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring WS-Atomic Transaction Support
This topic describes how you can configure WS-AtomicTransaction (WS-AT) support by using the WS-AT Configuration Utility.  
  
## Using the WS-AT Configuration Utility  
 The WS-AT Configuration Utility (wsatConfig.exe) is used to configure WS-AT settings. In order to enable the WS-AT protocol service, you must use the configuration utility to configure the HTTPS port for WS-AT, bind an X.509 certificate to the HTTPS port, and configure authorized partner certificates by specifying certificate subject names or thumbprints. The configuration utility also allows you to select the tracing mode and set default outgoing and maximum incoming transaction timeouts.  
  
 You can access this tool's functionality by using a Microsoft Management Console (MMC) property page snap-in in the Component Services management console, or from a command-line window. Configure WS-AT support on the local machine through the command-line window; configure settings on both local and remote machines by using the MMC snap-in.  
  
 The command-line window can be accessed in the Windows SDK installation location "%WINDIR%\Microsoft.NET\Framework\v3.0\Windows Communication Foundation".  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the command-line tool, see [WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](../../../../docs/framework/wcf/ws-atomictransaction-configuration-utility-wsatconfig-exe.md).  
  
 If you are running [!INCLUDE[wxp](../../../../includes/wxp-md.md)] or [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], you can access the MMC snap-in by navigating to **Control Panel/Administrative Tools/Component Services**, right-clicking **My Computer**, and selecting **Properties**. This is the same location where you can configure the Microsoft Distributed Transaction Coordinator (MSDTC). Options available for configuration are grouped under the **WS-AT** tab. If you are running Windows Vista or [!INCLUDE[lserver](../../../../includes/lserver-md.md)], the MMC snap-in can be found by clicking the **Start** button, and entering `dcomcnfg.exe` in the **Search** box. When the MMC is opened, navigate to the **My Computer\Distributed Transaction Coordinator\Local DTC** node, right click and select **Properties**. Options available for configuration are grouped under the **WS-AT** tab.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the snap-in, see the [WS-AtomicTransaction Configuration MMC Snap-in](../../../../docs/framework/wcf/ws-atomictransaction-configuration-mmc-snap-in.md).  
  
 To enable the tool's user interface, you must first register the WsatUI.dll file, located at the following path  
  
 %PROGRAMFILES%\Microsoft SDKs\Windows\v6.0\Bin  
  
 To register the product, execute the following command from a Command Prompt window:  
  
 `regasm.exe /codebase WsatUI.dll`  
  
## Enabling WS-AT  
 To enable the WS-AT protocol service inside MSDTC using port 443 and an X.509 certificate with a private key that has been installed in the local machine store, use the wsatConfig.exe tool with the following command.  
  
 `WsatConfig.exe –network:enable –port:8443 –endpointCert:<machine|"Issuer\SubjectName"> -accountsCerts:<thumbprint|"Issuer\SubjectName"> -restart`  
  
 Substitute the respective parameters with values relevant to your environment.  
  
 To disable the WS-AT protocol service inside MSDTC, use the wsatConfig.exe tool with the following command.  
  
 `WsatConfig.exe –network:disable -restart`  
  
## Configuring Trust Between Two Machines  
 The WS-AT protocol service requires the administrator to explicitly authorize individual accounts to participate in distributed transactions. If you are an administrator for two machines, you can configure both machines to establish a mutual trust relationship by exchanging the right set of certificates between the machines, installing them into the appropriate certificate stores, and using the wsatConfig.exe tool to add each machine's certificate to the other's list of authorized participant certificates. This step is necessary to perform distributed transactions between two machines using WS-AT.  
  
 In the following example outlines the steps to establish trust between two machines, A and B.  
  
### Creating and Exporting Certificates  
 This procedure requires the MMC Certificates snap-in. The snap-in can be accessed by opening the Start/Run menu, typing "mmc" in the input box and pressing OK. Then, in the **Console1** window, navigate to **the File/Add-Remove** Snap-in, click Add, and choose **Certificates** from the **Available Standalone Snapins** list. Finally, select **Computer Account** to manage and click **OK**. The **Certificates** node appears in the snap-in console.  
  
 You must already possess the required certificates to establish trust. To learn how to create and install new certificates prior to the following steps, see [How to: Create and Install Temporary Client Certificates in WCF During Development](http://go.microsoft.com/fwlink/?LinkId=158925).  
  
1.  On machine A, using the MMC Certificates snap-in, import the existing certificate (certA) into the LocalMachine\MY (Personal Node) and LocalMachine\ROOT store (trusted root certification authority node). To import a certificate to a specific node, right-click the node and choose **All Tasks/Import**.  
  
2.  On machine B, using the MMC Certificates snap-in, create or obtain a certificate certB with a private key and import it into the LocalMachine\MY (Personal Node) and LocalMachine\ROOT store (trusted root certification authority node).  
  
3.  Export certA's public key to a file if this has not been done already.  
  
4.  Export certB's public key to a file if this has not been done already.  
  
### Establishing Mutual Trust Between Machines  
  
1.  On machine A, import the file representation of certB into the LocalMachine\MY and LocalMachine\ROOT stores. This declares that machine A trusts certB to communicate with it.  
  
2.  On machine B, import certA’s file into the LocalMachine\MY and LocalMachine\ROOT stores. This implies that machine B trusts certA to communicate with it.  
  
 After completing these steps, trust is established between the two machines, and they can be configured to communicate with each other using WS-AT.  
  
### Configuring MSDTC to Use Certificates  
 Since the WS-AT protocol service acts as both a client and a server, it must both listen for incoming connections and initiate outgoing connections. Therefore, you need to configure MSDTC so that it knows which certificate to use when communicating with external parties, and which certificates to authorize when accepting incoming communication.  
  
 You can configure this by using the MMC WS-AT snap-in. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this tool, see the [WS-AtomicTransaction Configuration MMC Snap-in](../../../../docs/framework/wcf/ws-atomictransaction-configuration-mmc-snap-in.md) topic. The following steps describe how to establish trust between two computers running MSDTC.  
  
1.  Configure machine A's settings. For "Endpoint Certificate", select certA. For "Authorized Certificates", select the certB.  
  
2.  Configure machine B's settings. For "Endpoint Certificate", select certB. For "Authorized Certificates", select the certA.  
  
> [!NOTE]
>  When one machine sends a message to the other machine, the sender attempts to verify that the subject name of the recipient’s certificate and the name of the recipient’s machine match. If they do not match, certificate verification fails and the two machines cannot communicate.  
>   
>  For a machine joined to a domain, the name is the fully qualified domain name. By default, the name of a machine on a workgroup is the machine’s NetBIOS name. However, the name can also include a Domain Name System (DNS) suffix if one is present for the connection being used between the two machines.  
>   
>  If the name of the machine changes, for example, when a workgroup machine joins a domain, you must reissue certificates or manually configure DNS suffixes.  
  
## Security  
 Since some of the settings related to MSDTC and WS-AT are stored in the registry at HKLM\Software\Microsoft\MSDTC and at HKLM\Software\Microsoft\WSAT, respectively, ensure that these registry keys are secured so that only administrators can write to them. In the Registry Editor tool, right-click the key you want to secure and select **Permission** to set the appropriate access control. It is crucial to the security and integrity of the system that important keys are read-only for low-privileged users.  
  
 When deploying MSDTC, the administrator must ensure that any MSDTC data interchange is secure. In a workgroup deployment, isolate the transactional infrastructure from malicious users; in a cluster deployment, secure the cluster registry.  
  
## Tracing  
 The WS-AT protocol service supports integrated, transaction specific tracing that can be enabled and managed through the use of the [WS-AtomicTransaction Configuration MMC Snap-in](../../../../docs/framework/wcf/ws-atomictransaction-configuration-mmc-snap-in.md) tool.  Traces can include data indicating the time an enlistment is made for a specific transaction, the time a transaction reaches its terminal state, the outcome each transaction enlistment has received. All traces can be viewed using the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) tool.  
  
 The WS-AT protocol service also supports integrated ServiceModel tracing through the ETW trace session. This provides more detailed, communication-specific traces in addition to the existing transaction traces.  To enable these additional traces, follow these steps  
  
1.  Open the **Start/Run** menu, type "regedit" in the input box and select **OK**.  
  
2.  In the **Registry Editor**, navigate to the following folder on the left pane, Hkey_Local_Machine\SOFTWARE\Microsoft\WSAT\3.0\  
  
3.  Right click the `ServiceModelDiagnosticTracing` value in the right pane and select **Modify**.  
  
4.  In the **Value data** input box, enter one of the following valid values to specify the trace level you want to enable.  
  
-   0: off  
  
-   1: critical  
  
-   3: error. This is the default value  
  
-   7: warning  
  
-   15: information  
  
-   31: verbose  
  
## See Also  
 [WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](../../../../docs/framework/wcf/ws-atomictransaction-configuration-utility-wsatconfig-exe.md)  
 [WS-AtomicTransaction Configuration MMC Snap-in](../../../../docs/framework/wcf/ws-atomictransaction-configuration-mmc-snap-in.md)
