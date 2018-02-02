---
title: "How To: Build Claims-Aware ASP.NET Application Using Forms-Based Authentication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 98a3e029-1a9b-4e0c-b5d0-29d3f23f5b15
caps.latest.revision: 6
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Build Claims-Aware ASP.NET Application Using Forms-Based Authentication
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This How-To provides detailed step-by-step procedures for creating a simple claims-aware ASP.NET Web Forms application that uses Forms authentication. It also provides instructions for how to test the application to verify that claims are presented when a user signs in with Forms authentication.  
  
## Contents  
  
-   Objectives  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Configure ASP.NET Web Forms Application for Claims Using Forms Authentication  
  
-   Step 3 – Test Your Solution  
  
## Objectives  
  
-   Configure an ASP.NET Web Forms application for claims using Forms authentication  
  
-   Test the ASP.NET Web Forms application to see if it is working properly  
  
## Overview  
 In .NET 4.5, WIF and its claims-based authorization have been included as an integral part of the Framework. Previously, if you wanted claims from an ASP.NET user, you were required to install WIF, and then cast interfaces to Principal objects such as `Thread.CurrentPrincipal` or `HttpContext.Current.User`. Now, claims are served automatically by these Principal objects.  
  
 Forms authentication has benefited from WIF’s inclusion in .NET 4.5 because all users authenticated by Forms automatically have claims associated with them. You can begin using these claims immediately in an ASP.NET application that uses Forms authentication, as this How-To demonstrates.  
  
## Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Configure ASP.NET Web Forms Application for Claims Using Forms Authentication  
  
-   Step 3 – Test Your Solution  
  
## Step 1 – Create a Simple ASP.NET Web Forms Application  
 In this step, you will create a new ASP.NET Web Forms application.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio and click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
## Step 2 – Configure ASP.NET Web Forms Application for Claims Using Forms Authentication  
 In this step you will add a configuration entry to the *Web.config* configuration file and edit the *Default.aspx* file to display claims information for an account.  
  
#### To configure ASP.NET application for claims using Forms authentication  
  
1.  In the *Default.aspx* file, replace the existing markup with the following:  
  
    ```  
    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestApp._Default" %>  
  
    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">  
        <p>  
            This page displays the claims associated with a Forms authenticated user.          
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
  
     This step adds a GridView control to your *Default.aspx* page that will be populated with the claims retrieved from Forms authentication.  
  
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
  
                if (claimsPrincipal != null)  
                {  
                    this.ClaimsGridView.DataSource = claimsPrincipal.Claims;  
                    this.ClaimsGridView.DataBind();  
                }  
            }  
        }  
    }  
    ```  
  
     The above code will display claims about an authenticated user, including users identified by Forms authentication.  
  
## Step 3 – Test Your Solution  
 In this step you will test your ASP.NET Web Forms application, and verify that claims are presented when a user signs in with Forms authentication.  
  
#### To test your ASP.NET Web Forms application for claims using Forms authentication  
  
1.  Press **F5** to build and run the application. You should be presented with *Default.aspx*, which has **Register** and **Log in** links in the top right of the page. Click **Register**.  
  
2.  On the **Register** page, create a user account, and then click **Register**. Your account will be created using Forms authentication, and you will be automatically signed in.  
  
3.  After you have been redirected to the home page, you should see a table beneath the **Your Claims** heading that includes the **Issuer**, **OriginalIssuer**, **Type**, **Value**, and **ValueType** claims information about your account.
