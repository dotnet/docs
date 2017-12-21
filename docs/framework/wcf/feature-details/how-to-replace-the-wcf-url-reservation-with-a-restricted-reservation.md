---
title: "How to: Replace the WCF URL Reservation with a Restricted Reservation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2754d223-79fc-4e2b-a6ce-989889f2abfa
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Replace the WCF URL Reservation with a Restricted Reservation
A URL reservation allows you to restrict who can receive messages from a URL or a set of URLs. A reservation consists of a URL template, an access control list (ACL), and a set of flags. The URL template defines which URLs the reservation affects. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how URL templates are processed, see [Routing Incoming Requests](http://go.microsoft.com/fwlink/?LinkId=136764). The ACL controls what user or group of users is permitted to receive messages from the specified URLs. The flags indicate whether the reservation is to give a user or group permission to listen on the URL directly or to delegate the permission to listen to some other process.  
  
 As part of the default operating system configuration, [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] creates a globally accessible reservation for port 80 to enable all users to run applications that use a dual HTTP binding for duplex communication. Because the ACL on this reservation is for everyone, administrators cannot explicitly allow or disallow permission to listen on a URL or set of URLs. This topic explains how to delete this reservation and how to re-create the reservation with a restricted ACL.  
  
 On [!INCLUDE[wv](../../../../includes/wv-md.md)] or [!INCLUDE[lserver](../../../../includes/lserver-md.md)] you can view all of the HTTP URL reservations from an elevated command prompt by typing `netsh http show urlacl`.  The following example shows what a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] URL reservation should resemble.  
  
```  
Reserved URL : http://+:80/Temporary_Listen_Addresses/  
        User: \Everyone  
            Listen: Yes  
            Delegate: No  
            SDDL: D:(A;;GX;;;WD)  
```  
  
 The reservation consists of a URL template used when a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application is using an HTTP dual binding for duplex communication. URLs of this form are used for a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service to send messages back to the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client when communicating over a HTTP dual binding. Everyone is given permission to listen on the URL but not to delegate listening to another process. Finally, the ACL is described in Security Descriptor Definition Language (SSDL). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] SSDL, see [SSDL](http://go.microsoft.com/fwlink/?LinkId=136789)  
  
### To delete the WCF URL reservation  
  
1.  Click **Start**, point to **All Programs**, click **Accessories**, right-click **Command Prompt** and click **Run as Administrator** on the context menu that comes up. Click **Continue** on the User Account Control (UAC) window that might ask permissions to continue.  
  
2.  Type in **netsh http delete urlacl url=http://+:80/Temporary_Listen_Addresses/** in the command prompt window.  
  
3.  If the reservation is deleted successfully, the following message is displayed. **URL reservation successfully deleted**  
  
## Creating a New Security Group and New Restricted URL Reservation  
 To replace the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] URL reservation with a restricted reservation you must first create a new security group. You can do this in one of two ways: from a command prompt or from the computer management console. You only have to do one.  
  
#### To create a new security group from a command prompt  
  
1.  Click **Start**, point to **All Programs**, click **Accessories**, right-click **Command Prompt** and click **Run as Administrator** on the context menu that comes up. Click **Continue** on the User Account Control (UAC) window that might ask permissions to continue.  
  
2.  Type in **net localgroup "\<security group name>" /comment:"\<security group description>" /add** at the command prompt. Replacing **\<security group name>** with the name of the security group you want to create and **\<security group description>** with a suitable description for the security group.  
  
3.  If the security group is created successfully, the following message is displayed. **The command completed successfully.**  
  
#### To create a new security group from the computer management console  
  
1.  Click **Start**, click **Control Panel**, click **Administrative Tools**, and click **Computer Management** to open up the Computer Management Console. Click **Continue** on the User Account Control (UAC) window that might ask permissions to continue.  
  
2.  Click **System Tools**, click **Local Users and Groups**, right-click **Groups** folder and click **New Group** on the context menu that comes up. Type in the desired **Group Name**, **Description** and other details of this new security group and click the **Create** button to create the security group.  
  
#### To create the restricted URL reservation  
  
1.  Click **Start**, point to **All Programs**, click **Accessories**, right-click **Command Prompt** and click **Run as Administrator** on the context menu that comes up. Click **Continue** on the User Account Control (UAC) window that might ask permissions to continue.  
  
2.  Type in **netsh http add urlacl url=http://+:80/Temporary_Listen_Addresses/ user="\<machine name>\\<security group name\>** at the command prompt. Replacing **\<machine name>** with the computer name on which the group must be created and **\<security group name>** with the name of the security group you created previously.  
  
3.  If the reservation is created successfully, the following message is displayed. **URL reservation successfully added**.
