---
title: "Learning by Walkthroughs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a8ae2965-6a49-4155-89b0-7fab2c488ab1
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Learning by Walkthroughs
The [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] documentation provides several walkthroughs. This topic addresses some general walkthrough issues (including troubleshooting), and provides links to several entry-level walkthroughs for learning about [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].  
  
> [!NOTE]
>  The walkthroughs in this Getting Started section expose you to the basic code that supports [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] technology. In actual practice, you will typically use the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] and Windows Forms projects to implement your [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] applications. The [!INCLUDE[vs_ordesigner_short](../../../../../../includes/vs-ordesigner-short-md.md)] documentation provides examples and walkthroughs for this purpose.  
  
## Getting Started Walkthroughs  
 Several walkthroughs are available in this section. These walkthroughs are based on the sample Northwind database, and present [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] features at a gentle pace with minimal complexities.  
  
 A typical progression to follow would be as follows:  
  
|Objective|Visual Basic|C#|  
|---------------|------------------|---------|  
|Create an entity class and execute a simple query.|[Walkthrough: Simple Object Model and Query (Visual Basic)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-simple-object-model-and-query-visual-basic.md)|[Walkthrough: Simple Object Model and Query (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-simple-object-model-and-query-csharp.md)|  
|Add a second class and execute a more complex query.<br /><br /> (Requires completion of previous walkthrough).|[Walkthrough: Querying Across Relationships (Visual Basic)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-querying-across-relationships-visual-basic.md)|[Walkthrough: Querying Across Relationships (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-querying-across-relationships-csharp.md)|  
|Add, change, and delete items in the database.|[Walkthrough: Manipulating Data (Visual Basic)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-manipulating-data-visual-basic.md)|[Walkthrough: Manipulating Data (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-manipulating-data-csharp.md)|  
|Use stored procedures.|[Walkthrough: Using Only Stored Procedures (Visual Basic)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-using-only-stored-procedures-visual-basic.md)|[Walkthrough: Using Only Stored Procedures (C#)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-using-only-stored-procedures-csharp.md)|  
  
## General  
 The following information pertains to these walkthroughs in general:  
  
-   Environment: Each [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] walkthrough uses [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] as its integrated development environment (IDE).  
  
-   SQL engines: These walkthroughs are written to be implemented by using SQL Server Express. If you do not have SQL Server Express, you can download it free of charge. For more information, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
    > [!NOTE]
    >  [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] walkthroughs use a file name as a connection string. Simply specifying a file name is a convenience that [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides for SQL Server Express users. Always pay attention to security issues. For more information, see [Security in LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/security-in-linq-to-sql.md).  
  
-   [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] walkthroughs typically require the Northwind sample database. For more information, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
-   The dialog boxes and menu commands you see in walkthroughs might differ from those described in Help, depending on your active settings or [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] edition. To change your settings, click **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
-   For walkthroughs that address multi-tier scenarios, a server must be located on a computer that is distinct from the development computer, and you must have appropriate permissions to access the server.  
  
-   The name of the class that typically represents the Orders table in the Northwind sample database is `[Order]`. The escaping is required because `Order` is a keyword in [!INCLUDE[vbprvb](../../../../../../includes/vbprvb-md.md)].  
  
## Troubleshooting  
 Run-time errors can occur because you do not have sufficient permissions to access the databases used in these walkthroughs. See the following steps to help resolve the most common of these issues.  
  
### Log-On Issues  
 Your application might be trying to access the database by way of a database logon it does not accept.  
  
##### To verify or change the database log on  
  
1.  On the Windows **Start** menu, point to **All Programs**, **Microsoft SQL Server 2005**, point to **Configuration Tools**, and then click **SQL Server Configuration Manager**.  
  
2.  In the left pane of the **SQL Server Configuration Manager**, click **SQL Server 2005 Services**.  
  
3.  In the right pane, right-click **SQL Server (SQLEXPRESS)**, and then click **Properties**.  
  
4.  Click the **Log On** tab and verify how you are trying to log on to the server.  
  
     In most cases, **Local System** works.  
  
     If you make a change, click **Restart** to restart the service.  
  
### Protocols  
 At times, protocols might not be set correctly for your application to access the database. For example, the **Named Pipes** protocol, which is required for walkthroughs in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], is not enabled by default.  
  
##### To enable the Named Pipes protocol  
  
1.  In the left pane of the **SQL Server Configuration Manager**, expand **SQL Server 2005 Network Configuration**, and then click **Protocols for SQLEXPRESS**.  
  
2.  In the right pane, make sure that the **Named Pipes** protocol is enabled. If it is not, right-click **Name Pipes** and then click **Enable**.  
  
     You will have to stop and restart the service. Follow the steps in the next block.  
  
### Stopping and Restarting the Service  
 You must stop and restart services before your changes can take effect.  
  
##### To stop and restart the service  
  
1.  In the left pane of the **SQL Server Configuration Manager**, click **SQL Server 2005 Services**.  
  
2.  In the right pane, right-click **SQL Server (SQLEXPRESS)**, and then click **Stop**.  
  
3.  Right-click **SQL Server (SQLEXPRESS)**, and then click **Restart**.  
  
## See Also  
 [Getting Started](../../../../../../docs/framework/data/adonet/sql/linq/getting-started.md)
