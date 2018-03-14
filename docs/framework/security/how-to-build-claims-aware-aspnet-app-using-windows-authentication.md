---
title: "How To: Build Claims-Aware ASP.NET Application Using Windows Authentication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 11c53d9d-d34a-44b4-8b5e-22e3eaeaee93
caps.latest.revision: 5
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Build Claims-Aware ASP.NET Application Using Windows Authentication
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This How-To provides detailed step-by-step procedures for creating a simple claims-aware ASP.NET Web Forms application that uses Windows authentication. It also provides instructions for how to test the application to verify that claims are presented when a user signs in using Windows authentication.  
  
## Contents  
  
-   Objectives  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Configure ASP.NET Web Forms Application for Claims Using Windows Authentication  
  
-   Step 3 – Test Your Solution  
  
## Objectives  
  
-   Configure an ASP.NET Web Forms application for claims using Windows authentication  
  
-   Test the ASP.NET Web Forms application to see if it is working properly  
  
## Overview  
 In .NET 4.5, WIF and its claims-based authorization have been included as an integral part of the Framework. Previously, if you wanted claims from an ASP.NET user, you were required to install WIF, and then cast interfaces to Principal objects such as `Thread.CurrentPrincipal` or `HttpContext.Current.User`. Now, claims are served automatically by these Principal objects.  
  
 Windows authentication has benefited from WIF’s inclusion in .NET 4.5 because all users authenticated by Windows credentials automatically have claims associated with them. You can begin using these claims immediately in an ASP.NET application that uses Windows authentication, as this How-To demonstrates.  
  
## Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Configure ASP.NET Web Forms Application for Claims Using Windows Authentication  
  
-   Step 3 – Test Your Solution  
  
## Step 1 – Create a Simple ASP.NET Web Forms Application  
 In this step, you will create a new ASP.NET Web Forms application.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio, then click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
4.  After the **TestApp** project has been created, click on it in **Solution Explorer**. The project’s properties will appear in the **Properties** pane below **Solution Explorer**. Set the **Windows Authentication** property to **Enabled**.  
  
    > [!WARNING]
    >  Windows authentication is disabled by default in new ASP.NET applications, so you must manually enable it.  
  
## Step 2 – Configure ASP.NET Web Forms Application for Claims Using Windows Authentication  
 In this step you will add a configuration entry to the *Web.config* configuration file and modify the *Default.aspx* file to display claims information for an account.  
  
#### To configure ASP.NET application for claims using Windows authentication  
  
1.  In the **TestApp** project’s *Default.aspx* file, replace the existing markup with the following:  
  
    ```  
    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  
        CodeBehind="Default.aspx.cs" Inherits="TestApp._Default" %>  
  
    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">  
        <p>  
            This page displays the claims associated with a Windows authenticated user.          
        </p>  
        <h3>Your Claims</h3>  
        <p>  
            <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">  
                <AlternatingRowStyle BackColor="White" />  
                <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />  
            </asp:GridView>  
        </p>  
    </asp:Content>  
    ```  
  
     This step adds a GridView control to your *Default.aspx* page that will be populated with the claims retrieved from Windows authentication.  
  
2.  Save the *Default.aspx* file, then open its code-behind file named *Default.aspx.cs*. Replace the existing code with the following:  
  
    ```csharp  
    using System;  
    using System.Web.UI;  
    using System.Security.Claims;  
  
    namespace TestApp  
    {  
        public partial class _Default : Page  
        {  
            protected void Page_Load(object sender, EventArgs e)  
            {  
                ClaimsPrincipal claimsPrincipal = Page.User as ClaimsPrincipal;  
                this.ClaimsGridView.DataSource = claimsPrincipal.Claims;  
                this.ClaimsGridView.DataBind();  
            }  
        }  
    }  
    ```  
  
     The above code will display claims about an authenticated user.  
  
3.  To change the application’s authentication type, modify the **\<authentication>** block in the **\<system.web>** section of the project’s root *Web.config* file so that it only includes the following configuration entry:  
  
    ```xml  
    <authentication mode="Windows" />  
    ```  
  
4.  Finally, modify the **\<authorization>** block in the **\<system.web>** section of the same *Web.config* file to force authentication:  
  
    ```xml  
    <authorization>  
        <deny users="?" />  
    </authorization>  
    ```  
  
## Step 3 – Test Your Solution  
 In this step you will test your ASP.NET Web Forms application, and verify that claims are presented when a user signs in with Windows authentication.  
  
#### To test your ASP.NET Web Forms application for claims using Windows authentication  
  
1.  Press **F5** to build and run the application. You should be presented with *Default.aspx*, and your Windows account name (including domain name) should already appear as the authenticated user in the top right of the page. The page’s content should include a table filled with claims retrieved from your Windows account.
