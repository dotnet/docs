---
title: "Internet Information Service Hosting Instructions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 959a21c8-9d9d-4757-b255-4e57793ae9d6
caps.latest.revision: 30
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Internet Information Service Hosting Instructions
To run the samples that are hosted by Internet Information Services (IIS), you must make sure that IIS is properly installed and is running.  
  
### To install IIS version 7.5 on Windows Server 2008 R2  
  
1.  From **Server Manager**, select **Roles.** Under **Roles Summary**, click **Add Roles**.  
  
2.  Click **Next** to display the **Select Server Roles** dialog.  
  
3.  Select **Application Server** from the **Roles** list, and then click **Next** twice to display the **Select Role Services** dialog for the Application Server role.  
  
4.  Select the **Web Server (IIS)** check box. If you are prompted to install additional role services and features, click **Add Required Features**. Click **Next** twice to display the **Select Role Services** dialog for the Web Server (IIS) role.  
  
5.  Expand **Management Tools**, and then expand **IIS 6 Management Compatibility**. Select **IIS 6 Scripting Tools**. If you are prompted to install additional role services and features, click **Add Required Role Services**. Click **Next**.  
  
6.  If the summary of selections is correct, click **Install**.  
  
7.  When installation completes, click **Close**.  
  
### To install IIS version 7.5 on Windows 7  
  
1.  Click **Start**, and then click **Control Panel**.  
  
2.  Open the **Programs** group.  
  
3.  Under **Programs and Features**, click **Turn Windows Features on or off**.  
  
4.  The **User Account Control** dialog is displayed. Click **Continue**.  
  
5.  The **Windows Features** dialog is displayed. Expand the item labeled **Internet Information Services**.  
  
6.  Expand the item labeled **World Wide Web Services**.  
  
7.  Expand the item labeled **Application Development Features**.  
  
8.  Make sure the following items are selected:  
  
    1.  **.NET Extensibility**  
  
    2.  **ASP.NET**  
  
    3.  **ISAPI Extensions**  
  
    4.  **ISAPI Filters**  
  
9. Under the item labeled **World Wide Web Services**, expand **Common Http Features**.  
  
10. Make sure **Static Content** is selected.  
  
11. Under the item labeled **World Wide Web Services**, expand **Security**.  
  
12. Make sure that **Windows Authentication** is selected.  
  
13. Under the **Internet Information Services** directory, expand the item labeled **Web Management Tools**, and then select **IIS Management Console**.  
  
14. Expand the item labeled **IIS 6 Management Compatibility**, and then select **IIS 6 Scripting Tools**.  
  
15. Under the **Internet Information Services** directory, expand the item labeled **Microsoft .NET Framework 3.5.1**, and then select **Windows Communication Foundation Http Activation**.  
  
16. Click **OK**.  
  
### To install IIS version 7.0 on Windows Server 2008  
  
1.  From **Server Manager**, select **Roles**. Under **Roles Summary**, click **Add Roles**.  
  
2.  Click **Next** to display the **Select Server Roles** dialog.  
  
3.  Select **Application Server** from the **Roles** list, and then click **Next** twice to display the **Select Role Services** dialog for the Application Server role.  
  
4.  Select **Web Server (IIS)** check box. If you are prompted to install additional role services and features, click **Add Required Features**. Click **Next** twice to display the **Select Role Services** dialog for the Web Server (IIS) role.  
  
5.  Expand **Management Tools**, and then expand **IIS 6 Management Compatibility**. Select **IIS 6 Scripting Tools**. If you are prompted to install additional role services and features, click **Add Required Role Services**. Click **Next**.  
  
6.  If the summary of selections is correct, click **Install**.  
  
7.  When installation completes, click **Close**.  
  
### To install IIS version 7.0 on Windows Vista  
  
1.  Click Start, and then click Control Panel.  
  
2.  Select the **Programs** group.  
  
3.  Under **Programs and Features**, click **Turn Windows Features on or off**.  
  
4.  The **User Account Control** dialog is displayed. Click **Continue**.  
  
5.  The **Windows Features** dialog is displayed. Expand the item labeled **Internet Information Services**.  
  
6.  Expand the item labeled **World Wide Web Services**.  
  
7.  Expand the item labeled **Application Development Features**.  
  
8.  Make sure the following items are selected:  
  
    1.  **.NET Extensibility**  
  
    2.  **ASP.NET**  
  
    3.  **ISAPI Extensions**  
  
    4.  **ISAPI Filters**  
  
9. Expand the item labeled **Web Management Tools**, and then select **IIS Management Console**.  
  
10. Under the item labeled **World Wide Web Services**, expand **Common Http Features**.  
  
11. Make sure **Static Content** is selected.  
  
12. Under the item labeled **World Wide Web Services**, expand **Security**.  
  
13. Make sure **Windows Authentication** is selected.  
  
14. Expand the item labeled **IIS 6 Management Compatibility**, and then select **IIS 6 Scripting Tools**.  
  
15. Expand the item labeled **Microsoft .NET Framework 3.0**, and then select **Windows Communication Foundation Http Activation**.  
  
16. Click**OK**.  
  
### To install IIS version 6.0 on Windows Server 2003  
  
1.  From **Manage Your Server**, click **Add or remove a role**, and then click **Next**.  
  
2.  Select **Application server (IIS, ASP.NET)** from the **Server Role** list, and then click **Next**.  
  
3.  Select **Enable ASP.NET** check box, and then click **Next**.  
  
4.  If the summary of selections is correct, click Next.  
  
### To install IIS version 5.1 on Windows XP with Service Pack 2 and Service Pack 3 installed  
  
1.  In Control Panel, click **Add or Remove Programs**.  
  
2.  In the **Add or Remove Programs** dialog box, click **Add/Remove Windows Components**.  
  
3.  In the **Windows Components Wizard**, select the **Internet Information Services (IIS)** check box, and then click **Next**.  
  
4.  If the **Files Needed** dialog box is displayed, insert your operating system installation disc, browse to the i386 folder, and then click **OK**.  
  
5.  When installation completes, click **Finish**.  
  
6.  Close the **Add or Remove Programs** dialog box, and then close **Control Panel**.  
  
### To verify the installation of IIS and ASP.NET  
  
1.  Save the HTML file found at the end of this topic in the root \InetPub\wwwroot directory and name it Default.aspx.  
  
2.  Open a browser window.  
  
3.  Type `http://localhost/Default.aspx` in the address box, and then press ENTER.  
  
4.  A Web page with the text "Hello World" should appear.  
  
> [!NOTE]
>  Each time you install a new version of the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)], you must re-register aspnet_isapi as a Web service extension for IIS. To do so, issue the `aspnet_regiis –I –enable` command.  
  
## Sample Code  
  
```xml  
<html>  
   <body>  
       <form >  
           <h3> Hello World  
           </h3>  
       </form>  
   </body>  
</html>  
```
