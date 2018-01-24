---
title: "Walkthrough: Simple Object Model and Query (Visual Basic)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "vb"
ms.assetid: c878e457-f715-46e4-a136-ff14d6c86018
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Simple Object Model and Query (Visual Basic)
This walkthrough provides a fundamental end-to-end [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] scenario with minimal complexities. You will create an entity class that models the Customers table in the sample Northwind database. You will then create a simple query to list customers who are located in London.  
  
 This walkthrough is code-oriented by design to help show [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] concepts. Normally speaking, you would use the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] to create your object model.  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
 This walkthrough was written by using Visual Basic Development Settings.  
  
## Prerequisites  
  
-   This walkthrough uses a dedicated folder ("c:\linqtest") to hold files. Create this folder before you begin the walkthrough.  
  
-   This walkthrough requires the Northwind sample database. If you do not have this database on your development computer, you can download it from the Microsoft download site. For instructions, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md). After you have downloaded the database, copy the file to the c:\linqtest folder.  
  
## Overview  
 This walkthrough consists of six main tasks:  
  
-   Creating a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] solution in [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)].  
  
-   Mapping a class to a database table.  
  
-   Designating properties on the class to represent database columns.  
  
-   Specifying the connection to the Northwind database.  
  
-   Creating a simple query to run against the database.  
  
-   Executing the query and observing the results.  
  
## Creating a LINQ to SQL Solution  
 In this first task, you create a [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] solution that contains the necessary references to build and run a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] project.  
  
#### To create a LINQ to SQL solution  
  
1.  On the **File** menu, click **New Project**.  
  
2.  In the **Project types** pane of the **New Project** dialog box, click **Visual Basic**.  
  
3.  In the **Templates** pane, click **Console Application**.  
  
4.  In the **Name** box, type **LinqConsoleApp**.  
  
5.  Click **OK**.  
  
## Adding LINQ References and Directives  
 This walkthrough uses assemblies that might not be installed by default in your project. If `System.Data.Linq` is not listed as a reference in your project (click **Show All Files** in **Solution Explorer** and expand the **References** node), add it, as explained in the following steps.  
  
#### To add System.Data.Linq  
  
1.  In **Solution Explorer**, right-click **References**, and then click **Add Reference**.  
  
2.  In the **Add Reference** dialog box, click **.NET**, click the System.Data.Linq assembly, and then click **OK**.  
  
     The assembly is added to the project.  
  
3.  Also in the **Add Reference** dialog box, click **.NET**, scroll to and click System.Windows.Forms, and then click **OK**.  
  
     This assembly, which supports the message box in the walkthrough, is added to the project.  
  
4.  Add the following directives above `Module1`:  
  
     [!code-vb[DLinqWalk1VB#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk1VB/vb/Module1.vb#1)]  
  
## Mapping a Class to a Database Table  
 In this step, you create a class and map it to a database table. Such a class is termed an *entity class*. Note that the mapping is accomplished by just adding the <xref:System.Data.Linq.Mapping.TableAttribute> attribute. The <xref:System.Data.Linq.Mapping.TableAttribute.Name%2A> property specifies the name of the table in the database.  
  
#### To create an entity class and map it to a database table  
  
-   Type or paste the following code into Module1.vb immediately above `Sub Main`:  
  
     [!code-vb[DLinqWalk1VB#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk1VB/vb/Module1.vb#2)]  
  
## Designating Properties on the Class to Represent Database Columns  
 In this step, you accomplish several tasks.  
  
-   You use the <xref:System.Data.Linq.Mapping.ColumnAttribute> attribute to designate `CustomerID` and `City` properties on the entity class as representing columns in the database table.  
  
-   You designate the `CustomerID` property as representing a primary key column in the database.  
  
-   You designate `_CustomerID` and `_City` fields for private storage. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] can then store and retrieve values directly, instead of using public accessors that might include business logic.  
  
#### To represent characteristics of two database columns  
  
-   Type or paste the following code into Module1.vb just before `End Class`:  
  
     [!code-vb[DLinqWalk1VB#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk1VB/vb/Module1.vb#3)]  
  
## Specifying the Connection to the Northwind Database  
 In this step you use a <xref:System.Data.Linq.DataContext> object to establish a connection between your code-based data structures and the database itself. The <xref:System.Data.Linq.DataContext> is the main channel through which you retrieve objects from the database and submit changes.  
  
 You also declare a `Table(Of Customer)` to act as the logical, typed table for your queries against the Customers table in the database. You will create and execute these queries in later steps.  
  
#### To specify the database connection  
  
-   Type or paste the following code into the `Sub Main` method.  
  
     Note that the `northwnd.mdf` file is assumed to be in the linqtest folder. For more information, see the Prerequisites section earlier in this walkthrough.  
  
     [!code-vb[DLinqWalk1VB#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk1VB/vb/Module1.vb#4)]  
  
## Creating a Simple Query  
 In this step, you create a query to find which customers in the database Customers table are located in London. The query code in this step just describes the query. It does not execute it. This approach is known as *deferred execution*. For more information, see [Introduction to LINQ Queries (C#)](~/docs/csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).  
  
 You will also produce a log output to show the SQL commands that [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] generates. This logging feature (which uses <xref:System.Data.Linq.DataContext.Log%2A>) is helpful in debugging, and in determining that the commands being sent to the database accurately represent your query.  
  
#### To create a simple query  
  
-   Type or paste the following code into the `Sub Main` method after the `Table(Of Customer)` declaration:  
  
     [!code-vb[DLinqWalk1AVB#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk1AVB/vb/Module1.vb#5)]  
  
## Executing the Query  
 In this step, you actually execute the query. The query expressions you created in the previous steps are not evaluated until the results are needed. When you begin the `For Each` iteration, a SQL command is executed against the database and objects are materialized.  
  
#### To execute the query  
  
1.  Type or paste the following code at the end of the `Sub Main` method (after the query description):  
  
     [!code-vb[DLinqWalk1AVB#6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk1AVB/vb/Module1.vb#6)]  
  
2.  Press F5 to debug the application.  
  
    > [!NOTE]
    >  If your application generates a run-time error, see the Troubleshooting section of [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md).  
  
     The message box displays a list of six customers. The Console window displays the generated SQL code.  
  
3.  Click **OK** to dismiss the message box.  
  
     The application closes.  
  
4.  On the **File** menu, click **Save All**.  
  
     You will need this application if you continue with the next walkthrough.  
  
## Next Steps  
 The [Walkthrough: Querying Across Relationships (Visual Basic)](../../../../../../docs/framework/data/adonet/sql/linq/walkthrough-querying-across-relationships-visual-basic.md) topic continues where this walkthrough ends. The Querying Across Relationships walkthrough demonstrates how [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] can query across tables, similar to *joins* in a relational database.  
  
 If you want to do the Querying Across Relationships walkthrough, make sure to save the solution for the walkthrough you have just completed, which is a prerequisite.  
  
## See Also  
 [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md)
