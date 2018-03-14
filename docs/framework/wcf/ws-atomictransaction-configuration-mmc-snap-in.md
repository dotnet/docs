---
title: "WS-AtomicTransaction Configuration MMC Snap-in"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 23592973-1d51-44cc-b887-bf8b0d801e9e
caps.latest.revision: 17
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WS-AtomicTransaction Configuration MMC Snap-in
The WS-AtomicTransaction Configuration MMC Snap-in is used to configure a portion of the WS-AtomicTransaction settings on both local and remote machines.  
  
## Remarks  
 If you are running [!INCLUDE[wxp](../../../includes/wxp-md.md)] or [!INCLUDE[ws2003](../../../includes/ws2003-md.md)], the MMC snap-in can be found by navigating to **Control Panel/Administrative Tools/Component Services/**, right-clicking **My Computer**, and selecting **Properties**. This is the same location where you can configure the MSDTC. Options available for configuration are grouped under the **WS-AT** tab.  
  
 If you are running Windows Vista or [!INCLUDE[lserver](../../../includes/lserver-md.md)], MMC snap-in can be found by clicking the **Start** button, and typing in `dcomcnfg.exe` in the **Search** box. When the MMC is opened, navigate to the **My Computer\Distributed Transaction Coordinator\Local DTC** node, right click and select **Properties**. Options available for configuration are grouped under the **WS-AT** tab.  
  
 The previous steps are used to launch the snap-in for configuring a local machine. If you want to configure a remote machine, you should locate the remote machine's name in **Control Panel/Administrative Tools/Component Services/**, and perform similar steps if you are running [!INCLUDE[wxp](../../../includes/wxp-md.md)] or [!INCLUDE[ws2003](../../../includes/ws2003-md.md)]. If you are running Windows Vista or [!INCLUDE[lserver](../../../includes/lserver-md.md)], follow the previous steps for Vista and [!INCLUDE[lserver](../../../includes/lserver-md.md)], but use the **Distributed Transaction Coordinator\Local DTC** node under the remote computer's node.  
  
 To use the user interface provided by the tool, you have to register the WsatUI.dll file, which is located at the following path,  
  
 **%PROGRAMFILES%\Microsoft SDKs\Windows\v6.0\Bin\WsatUI.dll**  
  
 The registration can be done by the following command.  
  
```Output  
regasm.exe /codebase WsatUI.dll  
```  
  
 You can use this tool to modify the basic WS-AtomicTransaction settings. For example, you can enable and disable the WS-AtomicTransaction protocol support, configure the HTTP ports for WS-AT, bind an SSL Certificate to the HTTP port, configure certificates by specifying certificate subject names, select the Tracing mode and set default and maximum timeouts.  
  
 If you must configure WS-AtomicTransaction support on the local machine only, you can use the command line version of this tool. [!INCLUDE[crabout](../../../includes/crabout-md.md)] the command line tool, see the [WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](../../../docs/framework/wcf/ws-atomictransaction-configuration-utility-wsatconfig-exe.md) topic.  
  
 You should be aware that both the MMC Snap-in and the command-line tool do not support configuring all WS-AT settings. These settings can be edited only by modifying the registry directly. [!INCLUDE[crabout](../../../includes/crabout-md.md)] these registry settings, see [Configuring WS-Atomic Transaction Support](../../../docs/framework/wcf/feature-details/configuring-ws-atomic-transaction-support.md).  
  
### User Interface Description  
 **Enable WS-Atomic Transaction Network Support**:  
  
 Toggling this checkbox enables or disables all the GUI components of this snap-in.  
  
 Before you check this box, you should make sure that Network DTC Access is enabled with inbound or outbound communication, or both. This value can be verified in the **Security** Tab of the MSDTC snap-in.  
  
#### Network Group Box  
 You can specify the HTTPS port and additional security settings such as SSL encryption in the Network group. This group is disabled (grayed out) if DTC Network Transactions are not enabled.  
  
 **HTTPS Port**  
  
 This is the value of the HTTPS port used for WS-AT. The value must be a number in the range 1-65535 (as to represent a valid port). Changing the HTTP Port modifies the HTTP Service Configuration, which means that the previously used WS-AT Service Address is released, and a new WS-AT Service Address is registered based on the new port. In addition, the newly selected port is encrypted with the currently selected certificate for SSL Encryption.  
  
> [!NOTE]
>  If you have already enabled the firewall before running this tool, the port is automatically registered in the exception list. If the firewall is disabled before running this tool, nothing additional is configured regarding the firewall.  
  
 If you enable the firewall after configuring WS-AT, you must run this tool again and supply the port number using this parameter. If you disable the firewall after configuring, WS-AT continues to work without additional input.  
  
 **Endpoint Certificate**  
  
 Clicking the **Select** button displays a list with the currently available certificates on the Local Machine, allowing the user to select the certificate that can be used for SSL encryption. The certificates must have a private key. Otherwise, you receive an error message.  
  
> [!NOTE]
>  When you set an SSL certificate for a selected port, you overwrite the original SSL certificate associated with that port if one exists.  
  
 **Authorized Accounts**  
  
 Clicking the **Select** button invokes the Windows Access Control List editor, where you can specify the user or group that can participate in WS-Atomic transactions by checking the **Allow** or **Deny** box in the **Participate** permission group.  
  
 **Authorized Certificates**  
  
 Clicking the **Select** button displays a list of currently available certificates on the LocalMachine. You can then select which certificate identities are allowed to participate in WS-Atomic transactions.  
  
#### Timeout Group Box  
 The **Timeout** group box allows you to specify the default and maximum timeout for a WS-Atomic transaction. A valid value for outgoing timeout is between 1 and 3600. A valid value for incoming timeout is between 0 and 3600.  
  
#### Tracing and Logging Group Box  
 The **Tracing and Logging** group Box allows you to configure the desired tracing and logging level.  
  
 Clicking the **Options** button invokes a page where you can specify additional settings.  
  
 The **Trace Level** combination box allows you to choose from any valid value of the <xref:System.Diagnostics.TraceLevel> enumeration. You can also use the checkboxes to specify if you want to perform activity tracing, activity propagation or collect personal identifiable information.  
  
 You can also specify logging sessions in the **Logging Session** group box.  
  
> [!NOTE]
>  When another trace consumer is using the WS-AT trace provider, you cannot create a new logging session for trace events. Any attempt to configure logging during this time results in the error message "Failed to enable provider. Error code: 1".  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] tracing and logging, see [Administration and Diagnostics](../../../docs/framework/wcf/diagnostics/index.md).  
  
## See Also  
 [Configuring WS-Atomic Transaction Support](../../../docs/framework/wcf/feature-details/configuring-ws-atomic-transaction-support.md)  
 [WS-AtomicTransaction Configuration Utility (wsatConfig.exe)](../../../docs/framework/wcf/ws-atomictransaction-configuration-utility-wsatconfig-exe.md)  
 [Administration and Diagnostics](../../../docs/framework/wcf/diagnostics/index.md)
