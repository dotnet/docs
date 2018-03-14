---
title: "How To: Enable WIF Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 271b6889-3454-46ff-96ab-9feb15e742ee
caps.latest.revision: 3
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Enable WIF Tracing
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   ASP.NET® Web Forms  
  
## Summary  
 This How-To provides detailed step-by-step procedures for enabling WIF tracing in an ASP.NET application. It also provides instructions testing the application to verify that the trace listener and log are working correctly. This How-To does not have detailed instructions for creating a Security Token Service (STS), and instead uses the Development STS that comes with the Identity and Access tool. The Development STS does not perform real authentication and is intended for testing purposes only. You will need to install the Identity and Access tool to complete this How-To. It can be downloaded from the following location: [Identity and Access Tool](http://go.microsoft.com/fwlink/?LinkID=245849)  
  
> [!IMPORTANT]
>  Enabling WIF tracing for passive applications, that is, applications that use the WS-Federation protocol, can potentially expose the application to denial of service (DoS) attacks or to information disclosure to a malicious party. This includes both passive RPs and passive STSes. For this reason, we recommend that you not enable WIF tracing for passive RPs or STSes in a production environment.  
  
## Contents  
  
-   Objectives  
  
-   Overview  
  
-   Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application and Enable Tracing  
  
-   Step 2 – Test Your Solution  
  
## Objectives  
  
-   Create a simple ASP.NET application that uses WIF and the Development STS from the Identity and Access Tool  
  
-   Enable tracing and verify that it is working  
  
## Overview  
 Tracing enables you to debug and troubleshoot many types of issues with WIF, including tokens, cookies, claims, protocol messages, and more. WIF tracing is similar to WCF tracing; for example, you can choose the verbosity of traces to display everything from critical messages to all messages. WIF traces can be generated in **.xml** files or in **.svclog** files that are viewable by using the Service Trace Viewer Tool. This tool is located in the **bin** directory of the Windows SDK install path on your computer, for example: **C:\Program Files\Microsoft SDKs\Windows\v7.1\Bin\SvcTraceViewer.exe**.  
  
## Summary of Steps  
  
-   Step 1 – Create a Simple ASP.NET Web Forms Application and Enable Tracing  
  
-   Step 2 – Test Your Solution  
  
## Step 1 – Create a Simple ASP.NET Web Forms Application and Enable Tracing  
 In this step, you will create a new ASP.NET Web Forms application and modify the *Web.config* file to enable tracing.  
  
#### To create a simple ASP.NET application  
  
1.  Start Visual Studio and click **File**, **New**, and then **Project**.  
  
2.  In the **New Project** window, click **ASP.NET Web Forms Application**.  
  
3.  In **Name**, enter `TestApp` and press **OK**.  
  
4.  Right-click the **TestApp** project under **Solution Explorer**, then select **Identity and Access**.  
  
5.  The **Identity and Access** window appears. Under **Providers**, select **Test your application with the Local Development STS**, then click **Apply**.  
  
6.  Create a new folder in named **logs** in the root of the **C:** drive, like shown: **C:\logs**  
  
7.  Add the following **\<system.diagnostics>** element to the *Web.config* configuration file immediately following the closing **\</configSections>** element, like shown:  
  
    ```xml  
    <configuration>  
        <configSections>  
        …  
        </configSections>  
        <system.diagnostics>  
            <sources>  
                <source name="System.IdentityModel" switchValue="Verbose">  
                    <listeners>  
                        <add name="xml" type="System.Diagnostics.XmlWriterTraceListener" initializeData="C:\logs\WIF.xml" />  
                    </listeners>  
                </source>  
            </sources>  
            <trace autoflush="true" />  
        </system.diagnostics>  
    ```  
  
    > [!NOTE]
    >  The directory location specified in the **initializeData** attribute must exist before logging can begin. If the location does not exist, no logs will be created.  
  
     The configuration settings above will enable **Verbose** tracing for WIF and save the resulting log to the **C:logsWIF.xml** file.  
  
## Step 2 – Test Your Solution  
 In this step, you will test your WIF-enabled ASP.NET application to verify that logs are being recorded.  
  
#### To test your WIF-enabled ASP.NET application for successful tracing  
  
1.  Run the solution by pressing the **F5** key. You should be presented with the default ASP.NET Home Page and automatically authenticated with the username *Terry*, which is the default user that is returned by the Development STS.  
  
2.  Close the browser window and then navigate to the **C:\logs** folder. Open the **C:\logs\WIF.xml** file using a text editor.  
  
3.  Inspect the **WIF.xml** file and verify that it contains entries starting with **\<E2ETraceEvent>**. These traces will contain **\<TraceRecord>** elements with descriptions for the traced activity, such as **Validating SecurityToken**.
