---
title: "Walkthrough: Manipulating Data (Visual Basic)"
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
ms.assetid: 1f6a54f6-ec33-452a-a37d-48122207bf14
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Manipulating Data (Visual Basic)
This walkthrough provides a fundamental end-to-end [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] scenario for adding, modifying, and deleting data in a database. You will use a copy of the sample Northwind database to add a customer, change the name of a customer, and delete an order.  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
 This walkthrough was written by using Visual Basic Development Settings.  
  
## Prerequisites  
 This walkthrough requires the following:  
  
-   This walkthrough uses a dedicated folder ("c:\linqtest2") to hold files. Create this folder before you begin the walkthrough.  
  
-   The Northwind sample database.  
  
     If you do not have this database on your development computer, you can download it from the Microsoft download site. For instructions, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md). After you have downloaded the database, copy the northwnd.mdf file to the c:\linqtest2 folder.  
  
-   A Visual Basic code file generated from the Northwind database.  
  
     You can generate this file by using either the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] or the SQLMetal tool. This walkthrough was written by using the SQLMetal tool with the following command line:  
  
     **sqlmetal /code:"c:\linqtest2\northwind.vb" /language:vb "C:\linqtest2\northwnd.mdf" /pluralize**  
  
     For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md).  
  
## Overview  
 This walkthrough consists of six main tasks:  
  
-   Creating the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] solution in [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)].  
  
-   Adding the database code file to the project.  
  
-   Creating a new customer object.  
  
-   Modifying the contact name of a customer.  
  
-   Deleting an order.  
  
-   Submitting these changes to the Northwind database.  
  
## Creating a LINQ to SQL Solution  
 In this first task, you create a [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] solution that contains the necessary references to build and run a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] project.  
  
#### To create a LINQ to SQL solution  
  
1.  On the [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] **File** menu, click **New Project**.  
  
2.  In the **Project types** pane in the **New Project** dialog box, click **Visual Basic**.  
  
3.  In the **Templates** pane, click **Console Application**.  
  
4.  In the **Name** box, type **LinqDataManipulationApp**.  
  
5.  Click **OK**.  
  
## Adding LINQ References and Directives  
 This walkthrough uses assemblies that might not be installed by default in your project. If `System.Data.Linq` is not listed as a reference in your project (click **Show All Files** in **Solution Explorer** and expand the **References** node), add it, as explained in the following steps.  
  
#### To add System.Data.Linq  
  
1.  In **Solution Explorer**, right-click **References**, and then click **Add Reference**.  
  
2.  In the **Add Reference** dialog box, click **.NET**, click the System.Data.Linq assembly, and then click **OK**.  
  
     The assembly is added to the project.  
  
3.  In the code editor, add the following directives above **Module1**:  
  
     [!code-vb[DLinqWalk3VB#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#1)]  
  
## Adding the Northwind Code File to the Project  
 These steps assume that you have used the SQLMetal tool to generate a code file from the Northwind sample database. For more information, see the Prerequisites section earlier in this walkthrough.  
  
#### To add the northwind code file to the project  
  
1.  On the **Project** menu, click **Add Existing Item**.  
  
2.  In the **Add Existing Item** dialog box, navigate to c:\linqtest2\northwind.vb, and then click **Add**.  
  
     The northwind.vb file is added to the project.  
  
## Setting Up the Database Connection  
 First, test your connection to the database. Note especially that the name of the database, Northwnd, has no i character. If you generate errors in the next steps, review the northwind.vb file to determine how the Northwind partial class is spelled.  
  
#### To set up and test the database connection  
  
1.  Type or paste the following code into `Sub Main`:  
  
     [!code-vb[DLinqWalk3VB#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#2)]  
  
2.  Press F5 to test the application at this point.  
  
     A **Console** window opens.  
  
     Close the application by pressing Enter in the **Console** window, or by clicking **Stop Debugging** on the [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] **Debug** menu.  
  
## Creating a New Entity  
 Creating a new entity is straightforward. You can create objects (such as `Customer`) by using the `New` keyword.  
  
 In this and the following sections, you are making changes only to the local cache. No changes are sent to the database until you call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> toward the end of this walkthrough.  
  
#### To add a new Customer entity object  
  
1.  Create a new `Customer` by adding the following code before `Console.ReadLine` in `Sub Main`:  
  
     [!code-vb[DLinqWalk3VB#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#3)]  
  
2.  Press F5 to debug the solution.  
  
     The results that are shown in the console window are as follows:  
  
     `Customers matching CA before insert:`  
  
     `Customer ID: CACTU`  
  
     `Customer ID: RICAR`  
  
     Note that the new row does not appear in the results. The new data has not yet been submitted to the database.  
  
3.  Press Enter in the **Console** window to stop debugging.  
  
## Updating an Entity  
 In the following steps, you will retrieve a `Customer` object and modify one of its properties.  
  
#### To change the name of a Customer  
  
-   Add the following code above `Console.ReadLine()`:  
  
     [!code-vb[DLinqWalk3VB#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#4)]  
  
## Deleting an Entity  
 Using the same customer object, you can delete the first order.  
  
 The following code demonstrates how to sever relationships between rows, and how to delete a row from the database.  
  
#### To delete a row  
  
-   Add the following code just above `Console.ReadLine()`:  
  
     [!code-vb[DLinqWalk3VB#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#5)]  
  
## Submitting Changes to the Database  
 The final step required for creating, updating, and deleting objects is to actually submit the changes to the database. Without this step, your changes are only local and will not appear in query results.  
  
#### To submit changes to the database  
  
1.  Insert the following code just above `Console.ReadLine`:  
  
     [!code-vb[DLinqWalk3VB#6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#6)]  
  
2.  Insert the following code (after `SubmitChanges`) to show the before and after effects of submitting the changes:  
  
     [!code-vb[DLinqWalk3VB#7](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk3VB/vb/Module1.vb#7)]  
  
3.  Press F5 to debug the solution.  
  
     The console window appears as follows:  
  
    ```  
    Customers matching CA before update:  
    Customer ID: CACTU  
    Customer ID: RICAR  
  
    The Order Detail to be deleted is: OrderID = 10643  
  
    Customers matching CA after update:  
    Customer ID: A3VCA  
    Customer ID: CACTU  
    Customer ID: RICAR  
    ```  
  
4.  Press Enter in the **Console** window to stop debugging.  
  
> [!NOTE]
>  After you have added the new customer by submitting the changes, you cannot execute this solution again as is, because you cannot add the same customer again as is. To execute the solution again, change the value of the customer ID to be added.  
  
## See Also  
 [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md)
