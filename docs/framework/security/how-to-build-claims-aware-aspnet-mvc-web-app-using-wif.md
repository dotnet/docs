---
title: "How To: Build Claims-Aware ASP.NET MVC Web Application Using WIF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0efb76bc-9f7b-4afe-be1c-2a57c917010b
caps.latest.revision: 6
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Build Claims-Aware ASP.NET MVC Web Application Using WIF
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® MVC  
  
## Summary  
 This How-To provides detailed step-by-step procedures for creating simple claims-aware ASP.NET MVC web application. It also provides instructions how to test the simple claims-aware ASP.NET MVC web application for successful implementation of claims-based authentication. This How-To does not have detailed instructions for creating a Security Token Service (STS), and assumes you have already configured an STS.  
  
## Contents  
  
-   Objectives  
  
-   Summary of Steps  
  
-   Step 1 – Create Simple ASP.NET MVC Application  
  
-   Step 2 – Configure ASP.NET MVC Application for Claims-Based Authentication  
  
-   Step 3 – Test Your Solution  
  
-   Related Items  
  
## Objectives  
  
-   Configure ASP.NET MVC web application for claims-based authentication  
  
-   Test successful claims-aware ASP.NET MVC web application  
  
## Summary of Steps  
  
-   Step 1 – Create Simple ASP.NET MVC Application  
  
-   Step 2 – Configure ASP.NET MVC Application for Claims-Based Authentication  
  
-   Step 3 – Test Your Solution  
  
## Step 1 – Create Simple ASP.NET MVC Application  
 In this step, you will create a new ASP.NET MVC application.  
  
#### To create simple ASP.NET MVC application  
  
1.  Start Visual Studio and click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET MVC 3 Web Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
4.  In the **New ASP.NET MVC 3 Project** dialog, select **Internet Application** from the available templates, ensure **View Engine** is set to **Razor**, and then click **OK**.  
  
5.  When the new project opens, right-click the **TestApp** project in **Solution Explorer** and select the **Properties** option.  
  
6.  On the project’s properties page, click on the **Web** tab on the left and ensure that the **Use Local IIS Web Server** option is selected.  
  
## Step 2 – Configure ASP.NET MVC Application for Claims-Based Authentication  
 In this step you will add configuration entries to the *Web.config* configuration file of your ASP.NET MVC web application to make it claims-aware.  
  
#### To configure ASP.NET MVC application for claims-based authentication  
  
1.  Add the following configuration section definitions to the *Web.config* configuration file. These define configuration sections required by Windows Identity Foundation. Add the definitions immediately after the **\<configuration>** opening element:  
  
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
  
4.  Add the following Windows Identity Foundation related configuration entries and ensure that your ASP.NET application’s URL and port number match the values in the **\<audienceUris>** entry, **realm** attribute of the **\<wsFederation>** element, and the **reply** attribute of the **\<wsFederation>** element. Also ensure that the **issuer** value fits your Security Token Service (STS) URL.  
  
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
  
5.  Add reference to the <xref:System.IdentityModel> assembly.  
  
6.  Compile the solution to make sure there are errors.  
  
## Step 3 – Test Your Solution  
 In this step you will test your ASP.NET MVC web application configured for claims-based authentication. To perform basic test you will add simple code that displays claims in the token issued by the Security Token Service (STS).  
  
#### To test your ASP.NET MVC application for claims-based authentication  
  
1.  In the **Solution Explorer**, expand the **Controllers** folder and open *HomeController.cs* file in the editor. Add the following code to the **Index** method:  
  
    ```csharp  
    public ActionResult Index()  
    {  
        ViewBag.ClaimsIdentity = Thread.CurrentPrincipal.Identity;  
  
        return View();  
    }  
    ```  
  
2.  In the **Solution Explorer** expand **Views** and then **Home** folders and open *Index.cshtml* file in the editor. Delete its contents and add the following markup:  
  
    ```html  
    @{  
        ViewBag.Title = "Home Page";  
    }  
  
    <h2>Welcome: @ViewBag.ClaimsIdentity.Name</h2>  
    <h3>Values from Identity</h3>  
    <table>  
        <tr>  
            <th>  
                IsAuthenticated   
            </th>  
            <td>  
                @ViewBag.ClaimsIdentity.IsAuthenticated   
            </td>  
        </tr>  
        <tr>  
            <th>  
                Name   
            </th>          
            <td>  
                @ViewBag.ClaimsIdentity.Name  
            </td>          
        </tr>  
    </table>  
    <h3>Claims from ClaimsIdentity</h3>  
    <table>  
        <tr>  
            <th>  
                Claim Type  
            </th>  
            <th>  
                Claim Value  
            </th>  
            <th>  
                Value Type  
            </th>  
            <th>  
                Subject Name  
            </th>          
            <th>  
                Issuer Name  
            </th>          
        </tr>  
            @foreach (System.Security.Claims.Claim claim in ViewBag.ClaimsIdentity.Claims ) {  
        <tr>  
            <td>  
                @claim.Type  
            </td>  
            <td>  
                @claim.Value  
            </td>  
            <td>  
                @claim.ValueType  
            </td>  
            <td>  
                @claim.Subject.Name  
            </td>  
            <td>  
                @claim.Issuer  
            </td>  
        </tr>  
    }  
    </table>  
    ```  
  
3.  Run the solution by pressing the **F5** key.  
  
4.  You should be presented with the page that displays the claims in the token that was issued to you by Security Token Service.  
  
## Related Items  
  
-   [How To: Build Claims-Aware ASP.NET Web Forms Application Using WIF](../../../docs/framework/security/how-to-build-claims-aware-aspnet-web-forms-app-using-wif.md)
