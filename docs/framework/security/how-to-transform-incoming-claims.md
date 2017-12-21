---
title: "How To: Transform Incoming Claims"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2831d514-d9d8-4200-9192-954bb6da1126
caps.latest.revision: 4
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Transform Incoming Claims
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This How-To provides detailed step-by-step procedures for creating a simple claims-aware ASP.NET Web Forms application and transforming incoming claims. It also provides instructions for how to test the application to verify that transformed claims are presented when the application is run.  
  
## Contents  
  
-   Objectives  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Implement Claims Transformation Using a Custom ClaimsAuthenticationManager  
  
-   Step 3 – Test Your Solution  
  
## Objectives  
  
-   Configure an ASP.NET Web Forms application for claims-based authentication  
  
-   Transform incoming claims by adding an Administrator role claim  
  
-   Test the ASP.NET Web Forms application to see if it is working properly  
  
## Overview  
 WIF exposes a class named <xref:System.Security.Claims.ClaimsAuthenticationManager> that enables users to modify claims before they are presented to a relying party (RP) application. The <xref:System.Security.Claims.ClaimsAuthenticationManager> is useful for separation of concerns between authentication and the underlying application code. The example below demonstrates how to add a role to the claims in the incoming <xref:System.Security.Claims.ClaimsPrincipal> that may be required by the RP.  
  
## Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Implement Claims Transformation Using a Custom ClaimsAuthenticationManager  
  
-   Step 3 – Test Your Solution  
  
## Step 1 – Create a Simple ASP.NET Web Forms Application  
 In this step, you will create a new ASP.NET Web Forms application.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio in elevated mode as administrator.  
  
2.  In Visual Studio, click **File**, click **New**, and then click **Project**.  
  
3.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
4.  In **Name**, enter `TestApp` and press **OK**.  
  
5.  Right-click the **TestApp** project under **Solution Explorer**, then select **Identity and Access**.  
  
6.  The **Identity and Access** window appears. Under **Providers**, select **Test your application with the Local Development STS**, then click **Apply**.  
  
7.  In the *Default.aspx* file, replace the existing markup with the following, then save the file:  
  
    ```  
    <%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  
        CodeBehind="Default.aspx.cs" Inherits="TestApp._Default" %>  
  
    <asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">  
          <h3>Your Claims</h3>  
        <p>  
            <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">  
                <AlternatingRowStyle BackColor="White" />  
                <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />  
            </asp:GridView>  
        </p>  
    </asp:Content>  
    ```  
  
8.  Open the code-behind file named *Default.aspx.cs*. Replace the existing code with the following, then save the file:  
  
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
  
## Step 2 – Implement Claims Transformation Using a Custom ClaimsAuthenticationManager  
 In this step you will override default functionality in the <xref:System.Security.Claims.ClaimsAuthenticationManager> class to add an Administrator role to the incoming Principal.  
  
#### To implement claims transformation using a custom ClaimsAuthenticationManager  
  
1.  In Visual Studio, right-click the on the solution, click **Add**, and then click **New Project**.  
  
2.  In the **Add New Project** window, select **Class Library** from the **Visual C#** templates list, enter `ClaimsTransformation`, and then press **OK**. The new project will be created in your solution folder.  
  
3.  Right-click on **References** under the **ClaimsTransformation** project, and then click **Add Reference**.  
  
4.  In the **Reference Manager** window, select **System.IdentityModel**, and then click **OK**.  
  
5.  Open **Class1.cs**, or if it doesn’t exist, right-click **ClaimsTransformation**, click **Add**, then click **Class…**  
  
6.  Add the following using directives to the code file:  
  
    ```csharp  
    using System.Security.Claims;  
    using System.Security.Principal;  
    ```  
  
7.  Add the following class and method in the code file.  
  
    > [!WARNING]
    >  The following code is for demonstration purposes only; make sure that you verify your intended permissions in production code.  
  
    ```csharp  
    public class ClaimsTransformationModule : ClaimsAuthenticationManager  
    {  
        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)  
        {  
            if (incomingPrincipal != null && incomingPrincipal.Identity.IsAuthenticated == true)  
            {  
               ((ClaimsIdentity)incomingPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role, "Admin"));  
            }  
  
            return incomingPrincipal;  
        }  
    }  
    ```  
  
8.  Save the file and build the **ClaimsTransformation** project.  
  
9. In your **TestApp** ASP.NET project, right-click on References, and then click **Add Reference**.  
  
10. In the **Reference Manager** window, select **Solution** from the left menu, select **ClaimsTransformation** from the populated options, and then click **OK**.  
  
11. In the root **Web.config** file, navigate to the **\<system.identityModel>** entry. Within the **\<identityConfiguration>** elements, add the following line and save the file:  
  
    ```xml  
    <claimsAuthenticationManager type="ClaimsTransformation.ClaimsTransformationModule, ClaimsTransformation" />  
    ```  
  
## Step 3 – Test Your Solution  
 In this step you will test your ASP.NET Web Forms application, and verify that claims are presented when a user signs in with Forms authentication.  
  
#### To test your ASP.NET Web Forms application for claims using Forms authentication  
  
1.  Press **F5** to build and run the application. You should be presented with *Default.aspx*.  
  
2.  On the *Default.aspx* page, you should see a table beneath the **Your Claims** heading that includes the **Issuer**, **OriginalIssuer**, **Type**, **Value**, and **ValueType** claims information about your account. The last row should be presented in the following way:  
  
    ||||||  
    |-|-|-|-|-|  
    |LOCAL AUTHORITY|LOCAL AUTHORITY|http://schemas.microsoft.com/ws/2008/06/identity/claims/role|Admin|http://www.w3.org/2001/XMLSchema#string|
