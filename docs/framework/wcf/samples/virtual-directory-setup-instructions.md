---
title: "Virtual Directory Setup Instructions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3c62cab5-81a4-48b6-ac8c-9ce33a85a157
caps.latest.revision: 36
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Virtual Directory Setup Instructions
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] samples are intended to share a common virtual directory named servicemodelsamples that is mapped to the %SystemDrive%\inetpub\wwwroot\servicemodelsamples folder.  
  
> [!NOTE]
>  %SystemDrive% is usually C: or D:, depending on the drive location where Internet Information Services (IIS) is installed.  
  
 You can run the Setupvroot.bat and Cleanupvroot.bat files from the [One-Time Setup Procedure for the Windows Communication Foundation Samples](../../../../docs/framework/wcf/samples/one-time-setup-procedure-for-the-wcf-samples.md) to create the virtual directory. If you prefer to create the virtual directory manually, use the following procedures.  
  
## Procedures  
  
#### To create a virtual directory in IIS 7.0 or 7.5  
  
1.  From the **Start** menu, click **Run**, then type **inetmgr** to open the Internet Information Services (IIS) MMC snap-in.  
  
2.  In the left pane, expand the node with the computer's name, and then expand the **Sites** node.  
  
3.  Right-click **Default Web Site**, and then select **Add Application** to open the **Add Application window**.  
  
4.  In the window, type `servicemodelsamples` as the alias for the virtual directory that you are creating.  
  
5.  Create the following directory: %SystemDrive%\inetpub\wwwroot\servicemodelsamples  
  
6.  Set the physical path to %SystemDrive%\inetpub\wwwroot\servicemodelsamples.  Most of the WCF samples copy service executable files to this location when built.  
  
7.  Click **OK**. The Web application is now created for the WCF samples.  
  
    > [!NOTE]
    >  This task must be performed only once, because all of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples use the same servicemodelsamples Web application.  
  
    > [!NOTE]
    >  For the purpose of this documentation, the term `virtual directory` is synonymous with `Web application`.  
  
     In addition to creating the virtual directory, you must also set its properties to enable [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services to run. See below for details.  
  
#### To create a virtual directory in IIS 5.1 or 6.0  
  
1.  Open a command prompt window and type `start inetmgr` to open the Internet Information Services (IIS) MMC snap-in.  
  
2.  In the left pane, expand the node with the computer's name, and then expand the **Web Sites** node.  
  
3.  Right-click **Default Web Site** and select **New, Virtual Directory** to open the Virtual Directory Creation wizard.  
  
4.  In the wizard, type `servicemodelsamples` as the alias for the virtual directory that you are creating.  
  
5.  Set the path to %SystemDrive%\inetpub\wwwroot\servicemodelsamples. Most of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples copy service executable files to this location when built.  
  
6.  Click **Next**.  
  
7.  By default, the following check boxes are selected:  
  
    -   **Read**  
  
    -   **Run scripts (such as ASP)**  
  
8.  Click **Next**, and then click **Finish** to complete the wizard.  
  
    > [!NOTE]
    >  This task must be performed only once because all of the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] samples use the same servicemodelsamples virtual directory.  
  
#### To set additional virtual directory properties in IIS 7.0 or 7.5  
  
1.  Click the servicemodelsamples node. Along the bottom of the window, two views are listed. Select **Features View** if it isn’t already selected.  
  
2.  Double-click the entry for **Directory Browsing**.  
  
3.  In the Actions pane, select the **Enable** option. This enables you to access the directory of the directory by using Internet Explorer, which helps when debugging a service.  
  
 Finally, you must set the security properties of the servicemodelsamples folder to allow it to be accessed by others. See below for details.  
  
#### To set additional virtual directory properties in IIS 5.1 or 6.0  
  
1.  Right-click the servicemodelsamples node and then click **Properties**.  
  
2.  By default, the following check boxes are selected:  
  
    -   **Read**  
  
    -   **Log visits**  
  
    -   **Index this resource**  
  
3.  Select the **Directory browsing** check box. This enables you to access the directory of the directory by using Internet Explorer, which helps when debugging a service.  
  
#### To set security properties of the folder in IIS 7.0 or 7.5  
  
1.  Navigate to %SystemDrive%\inetpub\wwwroot\servicemodelsamples.  
  
2.  Right-click the servicemodelsamples folder and click **Share** or **Share With**.  
  
3.  Click the down arrow to the left of the **Add** button.  
  
4.  Select the **Find** entry. The **Select Users or Groups** window opens.  
  
5.  Click **Advanced**.  
  
6.  Click **Locations**. The **Locations** window is now open.  
  
7.  Select the entry for the computer being used. It is important to select the local computer and not an entry for any domains or networks that are listed. After you have selected the computer, click **OK**.  
  
8.  Click **Find Now**. This populates the search results with objects associated with the local computer.  
  
9. Find the **IIS_IUSRS** entry in the **Name (Relative Distinguished Name)** column. Select that entry and click **OK** to close the search results window.  
  
10. Click **OK** to close the **Select Users or Groups** window.  
  
11. Click **Share** to persist the changes.  
  
12. After the changes to enable sharing are complete, click **Done** to close the **File Sharing** window.  
  
#### To set security properties of the folder in IIS 5.1 or 6.0  
  
1.  Navigate to %SystemDrive%\inetpub\wwwroot\servicemodelsamples.  
  
2.  Right-click the **servicemodelsamples** folder and then click **Sharing and Security.**  
  
3.  Click the **Security** tab.  
  
4.  If you are using IIS 6.0, in the **Group or user names** box, check whether **Internet Guest Account** is listed.  
  
     If it is not listed:  
  
    1.  Click **Start** and then click **Control Panel**.  
  
    2.  If you do not see the **User Accounts** icon, click **Switch to Category View**.  
  
    3.  Click the **User Accounts** icon.  
  
    4.  Under "or pick a Control Panel icon," click **User Accounts**.  
  
    5.  In the **User Accounts** dialog box, click the **Advanced** tab.  
  
    6.  Click **Advanced**.  
  
    7.  In the **Local Users and Groups** dialog box, click to expand the **Users** folder.  
  
    8.  In the right pane, double-click **Internet Guest Account**.  
  
    9. In the **Properties** dialog box, copy the name used as the Internet guest account. By default, the name begins with "USR_" followed by the name of the computer.  
  
    10. Close the **Properties** dialog box.  
  
    11. Close the **Local Users and Groups** dialog box.  
  
    12. Close the **User Accounts** dialog box.  
  
    13. Close the other **User Accounts** dialog box.  
  
    14. In the **servicemodelsamples Properties** dialog box, on the **Security** tab, click **Add**.  
  
    15. Type the name of the computer followed by a backslash, then paste the name of the Internet user account, for example, myMachineName\\%InternetGuestAccountName%  
  
    16. Click **Check Names** to verify the addition. If it is valid, the name is in all capital letters and is underlined.  
  
5.  For IIS 6.0, also check that NETWORK SERVICE is listed in the **Group or user names** box.  
  
     If NETWORK SERVICE is not listed:  
  
    1.  Click **Add**.  
  
    2.  In the **Select Users or Groups** dialog box, type the name of the computer followed by a backslash.  
  
    3.  Type **service** after the backslash (no space).  
  
    4.  Click **Check names**.  
  
    5.  If multiple names are found, select **NETWORK SERVICE** and click **OK**.  
  
    6.  Click **OK** to close the **Select Users or Groups** dialog box.  
  
6.  If you are using Windows XP SP2 with IIS 5.1, check that both Internet Guest Account and ASPNET are listed in the **Group or user names** box.  
  
     Note that the ASPNET user may be a member of the built-in **Users** security group. If so, then if the **Users** group is listed in the dialog box, you do not need to add it as a separate item to the list of permitted users.  
  
     To check if ASPNET is part of the **Users** security group:  
  
    1.  On the **Start** menu, click **Control Panel**.  
  
    2.  Click the **User Accounts** icon.  
  
    3.  In the **Group** column, check that the value for **ASPNET** is "Users."  
  
## See Also  
 [Internet Information Service Hosting Instructions](../../../../docs/framework/wcf/samples/internet-information-service-hosting-instructions.md)
