---
title: "Downloading Sample Databases (LINQ to DataSet)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eb42a7af-d410-4b7f-b4a8-13c72ce6fd09
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Downloading Sample Databases (LINQ to DataSet)
The samples and walkthroughs in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] documentation use the AdventureWorks sample database. You can download this product free of charge from the Microsoft download site. The samples and walkthroughs in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] documentation use SQL Server as the data store. SQL Server Express Edition, which is available without charge, can also be used as the data store instead of SQL Server.  
  
## Downloading and Installing the AdventureWorks Database  
  
#### To download and install the AdventureWorks sample database for SQL Server  
  
1.  Open Internet Explorer.  
  
2.  Go to the [SQL Server 2005 Samples and Sample Databases](http://go.microsoft.com/fwlink/?linkid=31046) Web site.  
  
3.  Follow the instructions for downloading the AdventureWorks sample database for your processor type (such as AdventureWorksDB.msi), and save the .MSI file to your local computer.  
  
4.  If you have a previous version of AdventureWorks installed from the download or during the SQL Server setup, you must remove it before running AdventureWorks.msi.  
  
#### To remove a previous download of an AdventureWorks sample database  
  
1.  Drop the AdventureWorks or AdventureWorksDW database.  
  
2.  From **Add or Remove Programs**, select **AdventureWorksDB** or **AdventureWorksBI** and click **Remove**.  
  
#### To remove an AdventureWorks sample database previously installed using Setup  
  
1.  Drop the AdventureWorks or AdventureWorksDW database.  
  
2.  From **Add or Remove Programs**, select **Microsoft SQL Server 2005** and click **Change**.  
  
3.  From **Component Selection**, select **Workstation Components** and then click **Next**.  
  
4.  From **Welcome to the SQL Server Installation Wizard**, click **Next**.  
  
5.  From **System Configuration Check**, click **Next**.  
  
6.  From **Change or Remove Instance**, click **Change Installed Components**.  
  
7.  From **Feature Selection**, expand the **Documentation, Samples, and Sample Databases** node.  
  
8.  Select **Sample Code and Applications**. Expand **Sample Databases**, select the sample database to be removed, and select **Entire feature will be unavailable**. Click **Next**.  
  
9. Click **Install** and finish the installation wizard.  
  
#### To attach the AdventureWorks sample database files to an instance of SQL Server  
  
1.  After the file sample database installer file has downloaded, double-click the **AdventureWorksDB.msi** file (or the file you downloaded) to install the database. By default, the database is installed at c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data.  
  
2.  Attach the AdventureWorks database files to an instance of SQL Server by executing the following script SQLCMD or SQL Server Management Studio:  
  
    ```  
    exec sp_attach_db @dbname=N'AdventureWorks', @filename1=N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf', @filename2=N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_log.ldf'  
    ```  
  
     If you have installed these files to a different drive or directory, you must revise the paths appropriately before you execute the `sp_attach_db` stored procedure.  
  
## Downloading SQL Server Express Edition  
 The samples and walkthroughs in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] section use SQL Server 2005 as the data store but can be modified to use SQL Server Express Edition, instead. SQL Server Express Edition is available without charge, and you can redistribute it with applications. If you are using [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)], SQL Server Express Edition is included in the Pro and higher editions.  
  
#### To download and install SQL Server Express Edition  
  
1.  Start Internet Explorer.  
  
2.  Go to the  [Microsoft SQL Server 2005 Express Edition](http://go.microsoft.com/fwlink/?LinkID=31070) download page.  
  
3.  Follow the installation instructions on the Web site.  
  
## See Also  
 [Getting Started](../../../../docs/framework/data/adonet/getting-started-linq-to-dataset.md)
