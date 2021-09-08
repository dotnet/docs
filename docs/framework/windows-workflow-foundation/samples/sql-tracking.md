---
description: "Learn more about: SQL tracking"
title: "SQL Tracking"
ms.date: "03/30/2017"
ms.assetid: bcaebeb1-b9e5-49e8-881b-e49af66fd341
---
# SQL tracking

The [SqlTracking sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Tracking/SqlTracking/CS) demonstrates how to write a custom SQL tracking participant that writes tracking records to a SQL database. Windows Workflow Foundation (WF) provides workflow tracking to gain visibility into the execution of a workflow instance. The tracking runtime emits workflow tracking records during the execution of the workflow. For more information about workflow tracking, see [Workflow Tracking and Tracing](../workflow-tracking-and-tracing.md).

## Use the sample

1. Verify you have SQL Server 2008, SQL Server 2008 Express or newer installed. The scripts packaged with the sample assume the use of a SQL Express instance on your local computer. If you have a different instance please modify the database-related scripts before running the sample.

2. Create the SQL Server tracking database by running Trackingsetup.cmd in the scripts directory (\WF\Basic\Tracking\SqlTracking\CS\Scripts). This creates a database called TrackingSample.

   > [!NOTE]
   > The script creates the database on the default instance of SQL Express. If you want to install it on a different database instance, edit the Trackingsetup.cmd script.

3. Open SqlTrackingSample.sln in Visual Studio.

4. Press **Ctrl**+**Shift**+**B** to build the solution.

5. Press **F5** to run the application.

   The browser window opens and shows the directory listing for the application.

6. In the browser, click StockPriceService.xamlx.

7. The browser displays the StockPriceService page, which contains the local service WSDL address. Copy this address.

   An example of the local service WSDL address is `http://localhost:65193/StockPriceService.xamlx?wsdl`.

8. Using File Explorer, run the WCF test client (WcfTestClient.exe). It's located in the *Microsoft Visual Studio 10.0\Common7\IDE directory*.

9. In the WCF test client, click the **File** menu and select **Add Service**. Paste the local service address in the textbox. Click **OK** to close the dialog.

10. In the WCF test client, double click **GetStockPrice**. This opens the `GetStockPrice` operation that takes one parameter, type in the value `Contoso` and click **Invoke**.

11. The emitted tracking records are written to a SQL database. To view the tracking records, open the TrackingSample database in SQL Management Studio and navigate to the tables. Running a select query on the tables displays the data within the tracking records stored in the respective tables.

   For more information about SQL Server Management Studio, see [Introducing SQL Server Management Studio](/sql/ssms/sql-server-management-studio-ssms). Download SQL Server Management Studio [here](https://aka.ms/ssmsfullsetup).

## Uninstall the sample

1. Run theTrackingcleanup.cmd script in the sample directory (*\WF\Basic\Tracking\SqlTracking*).

    > [!NOTE]
    > The Trackingcleanup.cmd attempts to delete the database in your local computer SQL Express. If you are using another SQL server instance, edit Trackingcleanup.cmd.

## See also

- [AppFabric Monitoring Samples](/previous-versions/appfabric/ff383407(v=azure.10))
