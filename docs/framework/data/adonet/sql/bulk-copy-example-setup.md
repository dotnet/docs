---
description: "Learn more about: Bulk Copy Example Setup"
title: "Bulk Copy Example Setup"
ms.date: "10/23/2026"
ms.assetid: d4dde6ac-b8b6-4593-965a-635c8fb2dadb
---
# Bulk Copy Example Setup

The <xref:Microsoft.Data.SqlClient.SqlBulkCopy> class can be used to write data only to SQL Server tables. The code samples shown in this topic use the SQL Server sample database, `AdventureWorks`. To avoid altering the existing tables code samples write data to tables that you must create first.

 The `BulkCopyDemoMatchingColumns` and `BulkCopyDemoDifferentColumns` tables are both based on the `AdventureWorks` `Production.Products` table. In code samples that use these tables, data is added from the `Production.Products` table to one of these sample tables. The `BulkCopyDemoDifferentColumns` table is used when the sample illustrates how to map columns from the source data to the destination table; `BulkCopyDemoMatchingColumns` is used for most other samples.

 A few of the code samples demonstrate how to use one <xref:Microsoft.Data.SqlClient.SqlBulkCopy> class to write to multiple tables. For these samples, the `BulkCopyDemoOrderHeader` and `BulkCopyDemoOrderDetail` tables are used as the destination tables. These tables are based on the `Sales.SalesOrderHeader` and `Sales.SalesOrderDetail` tables in `AdventureWorks`.

> [!NOTE]
> The `SqlBulkCopy` code samples demonstrate its syntax. If the source and destination tables are in the same SQL Server instance, use a Transact-SQL (T-SQL) `INSERT ... SELECT` statement for a faster copy.

## Table Setup

 To create the tables necessary for the code samples to run correctly, you must run the following Transact-SQL statements in a SQL Server database.

```sql
USE AdventureWorks

IF EXISTS (SELECT * FROM dbo.sysobjects
 WHERE id = object_id(N'[dbo].[BulkCopyDemoMatchingColumns]')
 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[BulkCopyDemoMatchingColumns]

CREATE TABLE [dbo].[BulkCopyDemoMatchingColumns]([ProductID] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [ProductNumber] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_ProductID] PRIMARY KEY CLUSTERED
(
    [ProductID] ASC
) ON [PRIMARY]) ON [PRIMARY]

IF EXISTS (SELECT * FROM dbo.sysobjects
 WHERE id = object_id(N'[dbo].[BulkCopyDemoDifferentColumns]')
 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[BulkCopyDemoDifferentColumns]

CREATE TABLE [dbo].[BulkCopyDemoDifferentColumns]([ProdID] [int] IDENTITY(1,1) NOT NULL,
    [ProdNum] [nvarchar](25) NOT NULL,
    [ProdName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProdID] PRIMARY KEY CLUSTERED
(
    [ProdID] ASC
) ON [PRIMARY]) ON [PRIMARY]

IF EXISTS (SELECT * FROM dbo.sysobjects
 WHERE id = object_id(N'[dbo].[BulkCopyDemoOrderHeader]')
 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[BulkCopyDemoOrderHeader]

CREATE TABLE [dbo].[BulkCopyDemoOrderHeader]([SalesOrderID] [int] IDENTITY(1,1) NOT NULL,
    [OrderDate] [datetime] NOT NULL,
    [AccountNumber] [nvarchar](15) NULL,
 CONSTRAINT [PK_SalesOrderID] PRIMARY KEY CLUSTERED
(
    [SalesOrderID] ASC
) ON [PRIMARY]) ON [PRIMARY]

IF EXISTS (SELECT * FROM dbo.sysobjects
 WHERE id = object_id(N'[dbo].[BulkCopyDemoOrderDetail]')
 AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[BulkCopyDemoOrderDetail]

CREATE TABLE [dbo].[BulkCopyDemoOrderDetail]([SalesOrderID] [int] NOT NULL,
    [SalesOrderDetailID] [int] NOT NULL,
    [OrderQty] [smallint] NOT NULL,
    [ProductID] [int] NOT NULL,
    [UnitPrice] [money] NOT NULL,
 CONSTRAINT [PK_LineNumber] PRIMARY KEY CLUSTERED
(
    [SalesOrderID] ASC,
    [SalesOrderDetailID] ASC
) ON [PRIMARY]) ON [PRIMARY]
```

## See also

- [Bulk Copy Operations in SQL Server](bulk-copy-operations-in-sql-server.md)
- [ADO.NET Overview](../ado-net-overview.md)
