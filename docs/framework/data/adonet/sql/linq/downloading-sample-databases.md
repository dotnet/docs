---
title: "Downloading Sample Databases"
ms.date: "10/18/2018"
ms.assetid: ef9d69a1-9461-43fe-94bb-7c836754bcb5
---
# Download the Sample Databases, SQL Server Express, and tools
A number of samples and walkthroughs in the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] documentation use the Northwind sample database and SQL Server Express. You can download these products free of charge from Microsoft.

## Download the Sample Databases

### To download the sample databases

1.  In your browser, go to the [Northwind and Pubs Sample Databases](https://go.microsoft.com/fwlink?linkid=64296) download page.  
  
1.  Select **Download**.  
  
1.  After the file has downloaded, double-click the file to extract the databases and scripts.  
  
     By default, the databases are installed in the folder *drive*:\SQL Server 2000 Sample Databases.

1. Before you can use the Northwind database, you have to choose one of two options:

    - Recreate the database by running the `instnwnd.sql` script file in the installation folder.

    - Attach the `northwnd.mdf` file with its corresponding `*.ldf` log file.

    Optionally, you can also install the Pubs sample database in the same way.
  
## Download SQL Server Express  
SQL Server Express is available without charge, and you can redistribute it with applications. If you are using Visual Studio, SQL Server Express is included in the Pro and higher editions.  
  
### To download and install SQL Server Express 
  
1.  Go to the [SQL Server Express Editions](https://www.microsoft.com/sql-server/sql-server-editions-express) page.  
  
1.  Select **Download now**. 
  
1.  After the file has downloaded, double-click the file and follow the installation instructions in the setup program.  
  
## Download SQL Server Management Studio
If you want to modify a database that you have downloaded, you can access the database from **Server Explorer** in the Visual Studio integrated development environment (IDE), or you can use Microsoft SQL Server Management Studio (SSMS).  
  
### To download SQL Server Management Studio  
  
-   Follow the instructions at the [Download SQL Server Management Studio (SSMS)](/sql/ssms/download-sql-server-management-studio-ssms) page.  
  
## See Also  
 [Getting Started](../../../../../../docs/framework/data/adonet/sql/linq/getting-started.md)
