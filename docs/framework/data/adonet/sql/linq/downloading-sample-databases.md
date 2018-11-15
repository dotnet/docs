---
title: "Get the sample databases for ADO.NET code samples"
description: "Download the sample databases used in the code samples in the ADO.NET documentation, as well as SQL Server and management tools"
ms.date: "10/18/2018"
ms.assetid: ef9d69a1-9461-43fe-94bb-7c836754bcb5
---
# Get the sample databases for ADO.NET code samples

A number of examples and walkthroughs in the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] documentation use sample SQL Server databases and SQL Server Express. You can download these products free of charge from Microsoft.

## Get the Northwind sample database

Download the script `instnwnd.sql` to create and load the Northwind sample database from the following GitHub repository:

[Northwind and pubs sample databases for Microsoft SQL Server](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)

Before you can use the Northwind database, you have to run the downloaded `instnwnd.sql` script file to recreate the database on an instance of SQL Server by using [SQL Server Management Studio](#get_ssms) or a similar tool. Follow the instructions in the Readme file in the repository.

## Get the AdventureWorks sample database

Download the AdventureWorks sample database from the following GitHub repository:

[AdventureWorks sample databases](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks)

After you download one of the database backup (\*.bak) files, restore the backup to an instance of SQL Server by using SQL Server Management Studio (SSMS). See [Get SQL Server Management Studio](#get_ssms).

## <a name="get_sql"></a> Get SQL Server Express

SQL Server Express is a free, entry-level edition of SQL Server that you can redistribute with applications. Download SQL Server Express from the following page:
  
[SQL Server Express Edition](https://www.microsoft.com/sql-server/sql-server-editions-express)

If you're using [Visual Studio](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017), SQL Server Express LocalDB is included in the free Community edition of Visual Studio, as well as the Professional and higher editions.  

## <a name="get_ssms"></a> Get SQL Server Management Studio
If you want to view or modify a database that you've downloaded, you can use SQL Server Management Studio (SSMS). Download SSMS from the following page:

[Download SQL Server Management Studio (SSMS)](/sql/ssms/download-sql-server-management-studio-ssms) 

You can also view and manage databases in the Visual Studio integrated development environment (IDE). In [Visual Studio](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017), connect to the database from **SQL Server Object Explorer**, or create a Data Connection to the database in **Server Explorer**. Open these explorer panes from the **View** menu.
  
## See also

- [Getting Started](../../../../../../docs/framework/data/adonet/sql/linq/getting-started.md)
