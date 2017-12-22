---
title: "How To: Enable Token Replay Detection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5a9f5771-f5f6-4100-8501-406aa20d731a
caps.latest.revision: 4
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Enable Token Replay Detection
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This How-To provides detailed step-by-step procedures for enabling token replay detection in an ASP.NET application that uses WIF. It also provides instructions for how to test the application to verify that token replay detection is enabled. This How-To does not have detailed instructions for creating a Security Token Service (STS), and instead uses the Development STS that comes with the Identity and Access tool. The Development STS does not perform real authentication and is intended for testing purposes only. You will need to install the Identity and Access tool to complete this How-To. It can be downloaded from the following location: [Identity and Access Tool](http://go.microsoft.com/fwlink/?LinkID=245849)  
  
## Contents  
  
-   Objectives  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application and Enable Replay Detection  
  
-   Step 2 – Test Your Solution  
  
## Objectives  
  
-   Create a simple ASP.NET application that uses WIF and the Development STS from the Identity and Access Tool  
  
-   Enable token replay detection and verify that it is working  
  
## Overview  
 A replay attack occurs when a client attempts to authenticate to a relying party with an STS token that the client has already used. To help prevent this attack, WIF contains a replay detection cache of previously used STS tokens. When enabled, replay detection checks the token of the incoming request and verifies whether or not the token has been previously used. If the token has been used already, the request is refused and a <xref:System.IdentityModel.Tokens.SecurityTokenReplayDetectedException> exception is thrown.  
  
 The following steps demonstrate the configuration changes required to enable replay detection.  
  
## Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application and Enable Replay Detection  
  
-   Step 2 – Test Your Solution  
  
## Step 1 – Create a Simple ASP.NET Web Forms Application and Enable Replay Detection  
 In this step, you will create a new ASP.NET Web Forms application and modify the *Web.config* file to enable replay detection.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio and click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
4.  Right-click the **TestApp** project under **Solution Explorer**, then select **Identity and Access**.  
  
5.  The **Identity and Access** window appears. Under **Providers**, select **Test your application with the Local Development STS**, then click **Apply**.  
  
6.  Add the following **\<tokenReplayDetection>** element to the *Web.config* configuration file immediately following the **\<system.identityModel>** and **\<identityConfiguration>** elements, like shown:  
  
    ```xml  
    <system.identityModel>  
        <identityConfiguration>  
            <tokenReplayDetection enabled="true"/>  
    ```  
  
## Step 2 – Test Your Solution  
 In this step, you will test your WIF-enabled ASP.NET application to verify that replay detection has been enabled.  
  
#### To test your WIF-enabled ASP.NET application for replay detection  
  
1.  Run the solution by pressing the **F5** key. You should be presented with the default ASP.NET Home Page and automatically authenticated with the username *Terry*, which is the default user that is returned by the Development STS.  
  
2.  Press the browser’s **Back** button. You should be presented with a **Server Error in ‘/’ Application** page with the following description: *ID1062: Replay has been detected for: Token: 'System.IdentityModel.Tokens.SamlSecurityToken'*, followed by an *AssertionId* and an *Issuer*.  
  
     You are seeing this error page because an exception of type <xref:System.IdentityModel.Tokens.SecurityTokenReplayDetectedException> was thrown when the token replay was detected. This error occurs because you are attempting to re-send the initial POST request when the token was first presented. The **Back** button will not cause this behavior on subsequent requests to the server.
