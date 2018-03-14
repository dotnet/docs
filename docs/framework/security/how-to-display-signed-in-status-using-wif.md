---
title: "How To: Display Signed In Status Using WIF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4d1174e4-5397-4962-9a5f-3b1ad7b3fc14
caps.latest.revision: 6
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Display Signed In Status Using WIF
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF) 4.5  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This topic describes how to display the sign in status in a WIF-enabled ASP.NET application. WIF provides the mechanism for making your application claims-aware, and managing authentication and authorization for application resources.  
  
## Contents  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Install the Identity and Access Extension  
  
-   Step 2 – Create a Relying Party ASP.NET Application  
  
-   Step 3 – Enable Local Development STS to Authenticate Users  
  
-   Step 4 – Modify Your ASP.NET Application to Display Sign In Status  
  
-   Step 5 – Test the Integration Between WIF and Your ASP.NET Application  
  
## Overview  
 This topic demonstrates how to create a simple claims-aware application using WIF and how to easily display whether a user is signed in or not. The following steps use the Local Development STS that is included with the Identity and Access Visual Studio Extension. The Local Development STS is intended for a testing and development environment to provide a simple method of integrating claims into your application. It should never be used in a production environment, as it does not perform real authentication and credentials are not required. However, the imperative code in the following steps is the same for a production-ready application using real authentication.  
  
## Summary of Steps  
  
-   Step 1 – Install the Identity and Access Extension  
  
-   Step 2 – Create a Relying Party ASP.NET Application  
  
-   Step 3 – Enable Local Development STS to Authenticate Users  
  
-   Step 4 – Modify Your ASP.NET Application to Display Sign In Status  
  
-   Step 5 – Test the Integration Between WIF and Your ASP.NET Application  
  
## Step 1 – Install the Identity and Access Extension  
 This step describes how to configure the Identity and Access extension to Visual Studio 2012. This extension automates the process of configuring your application to communicate with STS endpoints.  
  
#### To install the Identity and Access extension  
  
1.  Start Visual Studio in elevated mode as administrator.  
  
2.  In Visual Studio, click **Tools** and click **Extension Manager**. The **Extension Manager** window appears.  
  
3.  In **Extension Manager**, click **Online Extensions** from the left menu, then select **Visual Studio Gallery**.  
  
4.  In the top right corner of **Extension Manager**, search for *Identity and Access*.  
  
5.  The **Identity and Access** item will appear in the search results. Click it, and then click **Download**.  
  
6.  The **Download and Install** dialog appears. If you agree with the license terms, click **Install**.  
  
7.  When the **Identity and Access** extension has finished installing, restart Visual Studio in administrator mode.  
  
## Step 2 – Create a Relying Party ASP.NET Application  
 This step describes how to create a relying party ASP.NET Web Forms application that will integrate with WIF.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio and click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
## Step 3 – Enable Local Development STS to Authenticate Users  
 This step describes how to enable Local Development STS in your application. Local Development STS is enabled by using the Identity and Access extension for Visual Studio.  
  
#### To enable Local Development STS in your ASP.NET application  
  
1.  In Visual Studio, right-click the **TestApp** project under **Solution Explorer**, then select **Identity and Access**.  
  
2.  The **Identity and Access** window appears. Under **Providers**, select **Test your application with the Local Development STS**, then click **Apply**.  
  
## Step 4 – Modify Your ASP.NET Application to Display Sign In Status  
 This step describes how to modify your ASP.NET application to dynamically display whether the current user is signed in. Once your STS provider has been configured, WIF handles the incoming claims. Now you need to configure your application’s code to display the result of the authentication.  
  
#### To display sign in status  
  
1.  In Visual Studio, open the **Default.aspx** file under the **TestApp** project.  
  
2.  Replace the existing markup in the **Default.aspx** file with the following markup:  
  
    ```  
    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>  
  
    <!DOCTYPE html>  
  
    <html>  
    <head runat="server">  
        <title>Logged In Status</title>  
    </head>  
    <body>  
        <asp:label ID="myLabel" runat="server" />  
    </body>  
    </html>  
    ```  
  
3.  Save **Default.aspx**, and then open its code behind file named **Default.aspx.cs**.  
  
    > [!NOTE]
    >  **Default.aspx.cs** may be hidden beneath **Default.aspx** in Solution Explorer. If **Default.aspx.cs** is not visible, expand **Default.aspx** by clicking on the triangle next to it.  
  
4.  Replace the existing code in **Default.aspx.cs** with the following code:  
  
    ```csharp  
    using System;  
    using System.Web.UI;  
    using System.Security.Claims;  
  
    namespace TestApp  
    {  
        protected void Page_Load(object sender, EventArgs e)  
        {  
            ClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;  
  
            if (claimsPrincipal != null)  
            {  
                myLabel.Text = "You are signed in.";  
            }  
            else  
            {  
                myLabel.Text = "You are not signed in.";  
            }  
        }  
    }  
    ```  
  
5.  Save **Default.aspx.cs**, and build the application.  
  
## Step 5 – Test the Integration Between WIF and Your ASP.NET Application  
 This step describes how you can test the integration between WIF and your ASP.NET application.  
  
#### To test the integration between WIF and ASP.NET  
  
1.  In Visual Studio, press **F5** to start debugging your application. If no errors are found, a new browser window will open.  
  
2.  You may notice that the browser silently redirects your request to the STS, and then opens the Default.aspx page. If WIF is properly configured, you should see the site display the following text: **"You are signed in"**.
