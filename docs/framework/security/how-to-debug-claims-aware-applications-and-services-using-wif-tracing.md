---
title: "How To: Debug Claims-Aware Applications And Services Using WIF Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3d51ba59-3adb-4ca4-bd33-5027531af687
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How To: Debug Claims-Aware Applications And Services Using WIF Tracing
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF)  
  
-   Service Trace Viewer Tool (SvcTraceViewer.exe)  
  
-   Troubleshooting and Debugging WIF Applications  
  
## Summary  
 This How-To describes required steps for how to configure WIF tracing, collect trace logs, and how to analyze the trace logs using Trace Viewer tool. It provides general mapping for trace entries to actions needed to troubleshoot issues related to WIF.  
  
## Contents  
  
-   Objectives  
  
-   Summary of Steps  
  
-   Step 1 – Configure WIF Tracing Using Web.config Configuration File  
  
-   Step 2 – Analyze WIF Trace Files Using Trace Viewer Tool  
  
-   Step 3 – Identify Solutions to Fix WIF Related Issues  
  
-   Related Items  
  
## Objectives  
  
-   Configure WIF tracing.  
  
-   View trace logs in the Trace Viewer tool.  
  
-   Identify WIF related issues in the trace logs.  
  
-   Apply corrective actions to WIF related issues found in the trace logs.  
  
## Summary of Steps  
  
-   Step 1 – Configure WIF Tracing Using Web.config Configuration File  
  
-   Step 2 – Analyze WIF Trace Files Using Trace Viewer Tool  
  
-   Step 3 – Identify Solutions to Fix WIF Related Issues  
  
## Step 1 – Configure WIF Tracing Using Web.config Configuration File  
 In this step, you will add changes to configuration sections in the *Web.config* file that enable WIF to trace its events and store them in a trace log.  
  
#### To configure WIF tracing using Web.config configuration file  
  
1.  Open the root **Web.config** or **App.config** configuration file in the Visual Studio editor by double clicking on it in **Solution Explorer**. If your solution does not have **Web.config** or **App.config** configuration file, add it by right clicking on the solution in the **Solution Explorer** and clicking **Add**, then clicking **New Item…**. On the **New Item** dialog, Select **Application Configuration File** for **App.config** or **Web Configuration File** for **Web.config** from the list and click **OK**.  
  
2.  Add the configuration entries similar to the following to the configuration file inside **\<configuration>** node at the end of the configuration file:  
  
    ```xml  
    <system.diagnostics>  
        <sources>  
            <source name="System.IdentityModel" switchValue="Verbose">  
                <listeners>  
                    <add name="xml" type="System.Diagnostics.XmlWriterTraceListener" initializeData="WIFTrace.e2e"/>  
                </listeners>  
            </source>  
        </sources>  
        <trace autoflush="true"/>  
    </system.diagnostics>  
    ```  
  
3.  The above configuration instructs WIF to generate verbose trace events and log them into *WIFTrace.e2e* file. For a complete list of values for the **switchValue** switch, refer to the Trace Level table found in the following topic: [Configuring Tracing](http://msdn.microsoft.com/library/ms733025.aspx).  
  
## Step 2 – Analyze WIF Trace Files Using Trace Viewer Tool  
 In this step, you will use the Trace Viewer Tool (SvcTraceViewer.exe) to analyze WIF trace logs.  
  
#### To analyze WIF trace logs using Trace Viewer tool (SvcTraceViewer.exe)  
  
1.  Trace Viewer tool (SvcTraceViewer.exe) ships as part of the Windows SDK. If you haven’t already installed the Windows SDK, you can download it here: [Windows SDK](http://www.microsoft.com/download/en/details.aspx?id=8279).  
  
2.  Run the Trace Viewer tool (SvcTraceViewer.exe). It is typically available in the **Bin** folder of the installation path.  
  
3.  Open the WIF trace log file, for example, WIFTrace.e2e by selecting **File**, **Open…** option in the menu or using the **Ctrl+O** shortcut. The trace log file opens in the Trace Viewer tool.  
  
4.  Review entries in the **Activity** tab. Each entry should contain an activity number, the number of traces that were logged, duration of the activity and its start and end timestamps.  
  
5.  Click on the **Activity** tab. You should see detailed trace entries in the main area of the tool. Use the **Level** dropdown list on the menu to filter specific level of traces, for example: **All**, **Warning**, **Errors**, **Information**, etc.  
  
6.  Click on specific trace entries to review the details in the lower area of the tool. The details can be viewed using **Formatted** and **XML** view by choosing corresponding tabs.  
  
## Step 3 – Identify Solutions to Fix WIF Related Issues  
 In this step, you can identify solutions for WIF-related issues identified by using the WIF trace log and Trace Viewer tool. It outlines general mapping of WIF related exceptions to potential solutions or required actions to troubleshoot the issue.  
  
#### To identify solutions to fix WIF related issues  
  
1.  Review the following table of WIF exceptions and the required actions to correct the issues.  
  
|**Error ID**|**Error Message**|**Action needed to fix the error**|  
|-|-|-|  
|ID4175|The issuer of the security token was not recognized by the IssuerNameRegistry.  To accept security tokens from this issuer, configure the IssuerNameRegistry to return a valid name for this issuer.|This error can be caused by copying a thumbprint from the MMC snap-in and pasting it into the *Web.config* file. Specifically, you can get an extra non-printable character in the text string when copying from the certificate properties window. This extra character causes the thumbprint match to fail.The procedure for correctly copying the thumbprint can be found here: [http://msdn.microsoft.com/library/ff359102.aspx](http://msdn.microsoft.com/library/ff359102.aspx)|  
  
## Related Items  
  
-   [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](http://msdn.microsoft.com/library/aa751795.aspx)
