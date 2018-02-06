---
title: "SQL Tracking"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bcaebeb1-b9e5-49e8-881b-e49af66fd341
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SQL Tracking
This sample demonstrates how to write a custom SQL tracking participant, that writes tracking records to a SQL database. [!INCLUDE[wf](../../../../includes/wf-md.md)] provides workflow tracking to gain visibility into the execution of a workflow instance. The tracking runtime emits workflow tracking records during the execution of the workflow. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] workflow tracking, see [Workflow Tracking and Tracing](../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md).  
  
#### To use this sample  
  
1.  Verify you have SQL Server 2008, SQL Server 2008 Express or newer installed. The scripts packaged with the sample assume the use of a SQL Express instance on your local computer. If you have a different instance please modify the database-related scripts before running the sample.  
  
2.  Create the SQL Server tracking database by running Trackingsetup.cmd in the scripts directory (\WF\Basic\Tracking\SqlTracking\CS\Scripts). This creates a database called TrackingSample.  
  
    > [!NOTE]
    >  The script creates the database on the default instance of SQL Express. If you want to install it on a different database instance, edit the Trackingsetup.cmd script.  
  
3.  Open SqlTrackingSample.sln in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
4.  Press CTRL+SHIFT+B to build the solution.  
  
5.  Press F5 to run the application.  
  
     The browser window opens and shows the directory listing for the application.  
  
6.  In the browser, click StockPriceService.xamlx.  
  
7.  The browser displays the StockPriceService page, which contains the local service WSDL address. Copy this address.  
  
     An example of the local service WSDL address is http://localhost:65193/StockPriceService.xamlx?wsdl.  
  
8.  Using [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], run the WCF test client (WcfTestClient.exe). It is located in the Microsoft Visual Studio 10.0\Common7\IDE directory.  
  
9. In the WCF test client, click the **File** menu and select **Add Service**. Paste the local service address in the textbox. Click **OK** to close the dialog.  
  
10. In the WCF test client, double click **GetStockPrice**. This opens the `GetStockPrice` operation that takes one parameter, type in the value `Contoso` and click **Invoke**.  
  
11. The emitted tracking records are written to a SQL database. To view the tracking records, open the TrackingSample database in SQL Management Studio and navigate to the tables. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] SQL Server Management Studio, see [Introducing SQL Server Management Studio](http://go.microsoft.com/fwlink/?LinkId=165645). SQL Server 2008 Management Studio Express can be downloaded [here](http://go.microsoft.com/fwlink/?LinkId=180520). Running a select query on the tables displays the data within the tracking records stored in the respective tables.  
  
#### To uninstall the sample  
  
1.  Run theTrackingcleanup.cmd script in the sample directory (\WF\Basic\Tracking\SqlTracking).  
  
    > [!NOTE]
    >  The Trackingcleanup.cmd attempts to delete the database in your local computer SQL Express. If you are using another SQL server instance, edit Trackingcleanup.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Tracking\SqlTracking`  
  
## See Also  
 [AppFabric Monitoring Samples](http://go.microsoft.com/fwlink/?LinkId=193959)
