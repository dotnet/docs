---
title: "How To: Build Claims-Aware ASP.NET Web Forms Application Using WIF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: efb264dd-f47b-49a9-85ee-9f45d4425765
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Build Claims-Aware ASP.NET Web Forms Application Using WIF
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This How-To provides detailed step-by-step procedures for creating simple claims-aware ASP.NET Web Forms application. It also provides instructions for how to test the simple claims-aware ASP.NET Web Forms application for successful implementation of federated authentication. This How-To does not have detailed instructions for creating a Security Token Service (STS), and assumes you have already configured an STS.  
  
## Contents  
  
-   Objectives  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application  
  
-   Step 2 – Configure ASP.NET Web Forms Application for Claims-Based Authentication  
  
-   Step 3 – Test Your Solution  
  
## Objectives  
  
-   Configure ASP.NET Web Forms application for claims-based authentication  
  
-   Test successful claims-aware ASP.NET Web Forms application  
  
## Summary of Steps  
  
-   Step 1 – Create Simple ASP.NET Web Forms Application  
  
-   Step 2 – Configure ASP.NET Web Forms Application for Federated Authentication  
  
-   Step 3 – Test Your Solution  
  
## Step 1 – Create a Simple ASP.NET Web Forms Application  
 In this step, you will create a new ASP.NET Web Forms application.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio and click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
## Step 2 – Configure ASP.NET Web Forms Application for Claims-Based Authentication  
 In this step you will add configuration entries to the *Web.config* configuration file of your ASP.NET Web Forms application to make it claims-aware.  
  
#### To configure ASP.NET application for claims-based authentication  
  
1.  Add the following configuration section entries to the *Web.config* configuration file immediately after the **\<configuration>** opening element:  
  
    ```xml  
    <configSections>  
      <section name="system.identityModel" type="System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />  
      <section name="system.identityModel.services" type="System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" />  
    </configSections>  
    ```  
  
2.  Add a **\<location>** element that enables access to the application’s federation metadata:  
  
    ```xml  
    <location path="FederationMetadata">  
      <system.web>  
        <authorization>  
          <allow users="*" />  
        </authorization>  
      </system.web>  
    </location>  
    ```  
  
3.  Add the following configuration entries within the **\<system.web>** elements to deny users, disable native authentication, and enable WIF to manage authentication.  
  
    ```xml  
    <authorization>  
      <deny users="?" />  
    </authorization>  
    <authentication mode="None" />  
    ```  
  
4.  Add a **\<system.webServer>** element that defines the modules for federated authentication. Note that the *PublicKeyToken* attribute must be the same as the *PublicKeyToken* attribute for the **\<configSections>** entries added earlier:  
  
    ```xml  
    <system.webServer>  
      <modules>  
        <add name="WSFederationAuthenticationModule" type="System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="managedHandler" />  
        <add name="SessionAuthenticationModule" type="System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" preCondition="managedHandler" />  
      </modules>  
    </system.webServer>  
    ```  
  
5.  Add the following Windows Identity Foundation related configuration entries and ensure that your ASP.NET application’s URL and port number match the values in the **\<audienceUris>** entry, **realm** attribute of the **\<wsFederation>** element, and the **reply** attribute of the **\<wsFederation>** element. Also ensure that the **issuer** value fits your Security Token Service (STS) URL.  
  
    ```xml  
    <system.identityModel>  
        <identityConfiguration>  
            <audienceUris>  
                <add value="http://localhost:28503/" />  
            </audienceUris>  
            <issuerNameRegistry type="System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">  
                <trustedIssuers>  
                    <add thumbprint="1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ1234" name="YourSTSName" />  
                </trustedIssuers>   
            </issuerNameRegistry>  
            <certificateValidation certificateValidationMode="None" />  
        </identityConfiguration>  
    </system.identityModel>  
    <system.identityModel.services>  
        <federationConfiguration>  
            <cookieHandler requireSsl="false" />  
            <wsFederation passiveRedirectEnabled="true" issuer="http://localhost:13922/wsFederationSTS/Issue" realm="http://localhost:28503/" reply="http://localhost:28503/" requireHttps="false" />  
        </federationConfiguration>  
    </system.identityModel.services>  
    ```  
  
6.  Add reference to the <xref:System.IdentityModel> assembly.  
  
7.  Compile the solution to make sure there are no errors.  
  
## Step 3 – Test Your Solution  
 In this step you will test your ASP.NET Web Forms application configured for claims-based authentication. To perform a basic test, you will add code that displays claims in the token issued by the Security Token Service (STS).  
  
#### To test your ASP.NET Web Form application for claims-based authentication  
  
1.  Open the **Default.aspx** file under the **TestApp** project and replace its existing markup with the following markup:  
  
    ```  
    %@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>  
  
    <!DOCTYPE html>  
  
    <html>  
    <head id="Head1" runat="server">  
        <title></title>  
    </head>  
    <body>  
        <h1><asp:label ID="signedIn" runat="server" /></h1>  
        <asp:label ID="claimType" runat="server" />  
        <asp:label ID="claimValue" runat="server" />  
        <asp:label ID="claimValueType" runat="server" />  
        <asp:label ID="claimSubjectName" runat="server" />  
        <asp:label ID="claimIssuer" runat="server" />  
    </body>  
    </html>  
    ```  
  
2.  Save **Default.aspx**, and then open its code behind file named **Default.aspx.cs**.  
  
    > [!NOTE]
    >  **Default.aspx.cs** may be hidden beneath **Default.aspx** in Solution Explorer. If **Default.aspx.cs** is not visible, expand **Default.aspx** by clicking on the triangle next to it.  
  
3.  Replace the existing code in the **Page_Load** method of **Default.aspx.cs** with the following code:  
  
    ```csharp  
    using System;  
    using System.IdentityModel;  
    using System.Security.Claims;  
    using System.Threading;  
    using System.Web.UI;  
  
    namespace TestApp  
    {  
        public partial class _Default : System.Web.UI.Page  
        {  
            protected void Page_Load(object sender, EventArgs e)  
            {  
                ClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;  
  
                if (claimsPrincipal != null)  
                {  
                    signedIn.Text = "You are signed in.";  
  
                    foreach (Claim claim in claimsPrincipal.Claims)  
                    {  
                        claimType.Text = claim.Type;  
                        claimValue.Text = claim.Value;  
                        claimValueType.Text = claim.ValueType;  
                        claimSubjectName.Text = claim.Subject.Name;  
                        claimIssuer.Text = claim.Issuer;  
                    }  
                }  
                else  
                {  
                    signedIn.Text = "You are not signed in.";  
                }  
            }  
        }  
    }  
    ```  
  
4.  Save **Default.aspx.cs**, and build the solution.  
  
5.  Run the solution by pressing the **F5** key.  
  
6.  You should be presented with the page that displays the claims in the token that was issued to you by the Security Token Service.
