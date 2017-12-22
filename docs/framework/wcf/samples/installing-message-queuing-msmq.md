---
title: "Installing Message Queuing (MSMQ)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7ddcd497-3e04-427e-bc04-3610ad98b01e
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Installing Message Queuing (MSMQ)
The following procedures show how to install Message Queuing 4.0 and Message Queuing 3.0.  
  
> [!NOTE]
>  Message Queuing 4.0 is not available in [!INCLUDE[wxp](../../../../includes/wxp-md.md)] and [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)].  
  
#### To install Message Queuing 4.0 on Windows Server 2008 or Windows Server 2008 R2  
  
1.  In Server Manager, click **Features**.  
  
2.  In the right-hand pane under **Features Summary**, click **Add Features**.  
  
3.  In the resulting window, expand **Message Queuing**.  
  
4.  Expand **Message Queuing Services**.  
  
5.  Click **Directory Services Integration** (for computers joined to a Domain), then click **HTTP Support**.  
  
6.  Click **Next**,then click **Install**.  
  
#### To install Message Queuing 4.0 on Windows 7 or Windows Vista  
  
1.  Open **Control Panel**.  
  
2.  Click **Programs** and then, under **Programs and Features**, click **Turn Windows Features on and off**.  
  
3.  Expand Microsoft Message Queue (MSMQ) Server, expand Microsoft Message Queue (MSMQ) Server Core, and then select the check boxes for the following Message Queuing features to install:  
  
    -   MSMQ Active Directory Domain Services Integration (for computers joined to a Domain).  
  
    -   MSMQ HTTP Support.  
  
4.  Click **OK**.  
  
5.  If you are prompted to restart the computer, click **OK** to complete the installation.  
  
#### To install Message Queuing 3.0 on Windows XP and Windows Server 2003  
  
1.  Open **Control Panel**.  
  
2.  Click **Add Remove Programs** and then click **Add Windows Components**.  
  
3.  Select Message Queuing and click **Details**.  
  
    > [!NOTE]
    >  If you are running [!INCLUDE[ws2003](../../../../includes/ws2003-md.md)], select Application Server to access Message Queuing.  
  
4.  Ensure that the option MSMQ HTTP Support is selected on the details page.  
  
5.  Click **OK** to exit the details page, and then click **Next**. Complete the installation.  
  
6.  If you are prompted to restart the computer, click **OK** to complete the installation.  
  
## See Also  
 [Set-Up Instructions](../../../../docs/framework/wcf/samples/set-up-instructions.md)
