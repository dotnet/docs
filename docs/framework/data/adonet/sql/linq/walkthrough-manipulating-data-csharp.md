---
title: "Walkthrough: Manipulating Data (C#)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 24adfbe0-0ad6-449f-997d-8808e0770d2e
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Manipulating Data (C#)
This walkthrough provides a fundamental end-to-end [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] scenario for adding, modifying, and deleting data in a database. You will use a copy of the sample Northwind database to add a customer, change the name of a customer, and delete an order.  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
 This walkthrough was written by using Visual C# Development Settings.  
  
## Prerequisites  
 This walkthrough requires the following:  
  
-   This walkthrough uses a dedicated folder ("c:\linqtest6") to hold files. Create this folder before you begin the walkthrough.  
  
-   The Northwind sample database.  
  
     If you do not have this database on your development computer, you can download it from the Microsoft download site. For instructions, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md). After you have downloaded the database, copy the northwnd.mdf file to the c:\linqtest6 folder.  
  
-   A C# code file generated from the Northwind database.  
  
     You can generate this file by using either the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)] or the SQLMetal tool. This walkthrough was written by using the SQLMetal tool with the following command line:  
  
     **sqlmetal /code:"c:\linqtest6\northwind.cs" /language:csharp "C:\linqtest6\northwnd.mdf" /pluralize**  
  
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
  
1.  On the [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] **File** menu, point to **New**, and then click **Project**.  
  
2.  In the **Project types** pane in the **New Project** dialog box, click **Visual C#**.  
  
3.  In the **Templates** pane, click **Console Application**.  
  
4.  In the **Name** box, type **LinqDataManipulationApp**.  
  
5.  In the **Location** box, verify where you want to store your project files.  
  
6.  Click **OK**.  
  
## Adding LINQ References and Directives  
 This walkthrough uses assemblies that might not be installed by default in your project. If System.Data.Linq is not listed as a reference in your project, add it, as explained in the following steps:  
  
#### To add System.Data.Linq  
  
1.  In **Solution Explorer**, right-click **References**, and then click **Add Reference**.  
  
2.  In the **Add Reference** dialog box, click **.NET**, click the System.Data.Linq assembly, and then click **OK**.  
  
     The assembly is added to the project.  
  
3.  Add the following directives at the top of Program.cs:  
  
     [!code-csharp[DLinqWalk3CS#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#1)]  
  
## Adding the Northwind Code File to the Project  
 These steps assume that you have used the SQLMetal tool to generate a code file from the Northwind sample database. For more information, see the Prerequisites section earlier in this walkthrough.  
  
#### To add the northwind code file to the project  
  
1.  On the **Project** menu, click **Add Existing Item**.  
  
2.  In the **Add Existing Item** dialog box, navigate to c:\linqtest6\northwind.cs, and then click **Add**.  
  
     The northwind.cs file is added to the project.  
  
## Setting Up the Database Connection  
 First, test your connection to the database. Note especially that the database, Northwnd, has no i character. If you generate errors in the next steps, review the northwind.cs file to determine how the Northwind partial class is spelled.  
  
#### To set up and test the database connection  
  
1.  Type or paste the following code into the `Main` method in the Program class:  
  
     [!code-csharp[DLinqWalk3CS#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#2)]  
  
2.  Press F5 to test the application at this point.  
  
     A **Console** window opens.  
  
     You can close the application by pressing Enter in the **Console** window, or by clicking **Stop Debugging** on the [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] **Debug** menu.  
  
## Creating a New Entity  
 Creating a new entity is straightforward. You can create objects (such as `Customer`) by using the `new` keyword.  
  
 In this and the following sections, you are making changes only to the local cache. No changes are sent to the database until you call <xref:System.Data.Linq.DataContext.SubmitChanges%2A> toward the end of this walkthrough.  
  
#### To add a new Customer entity object  
  
1.  Create a new `Customer` by adding the following code before `Console.ReadLine();` in the `Main` method:  
  
     [!code-csharp[DLinqWalk3CS#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#3)]  
  
2.  Press F5 to debug the solution.  
  
3.  Press Enter in the **Console** window to stop debugging and continue the walkthrough.  
  
## Updating an Entity  
 In the following steps, you will retrieve a `Customer` object and modify one of its properties.  
  
#### To change the name of a Customer  
  
-   Add the following code above `Console.ReadLine();`:  
  
     [!code-csharp[DLinqWalk3CS#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#4)]  
  
## Deleting an Entity  
 Using the same customer object, you can delete the first order.  
  
 The following code demonstrates how to sever relationships between rows, and how to delete a row from the database. Add the following code before `Console.ReadLine` to see how objects can be deleted:  
  
#### To delete a row  
  
-   Add the following code just above `Console.ReadLine();`:  
  
     [!code-csharp[DLinqWalk3CS#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#5)]  
  
## Submitting Changes to the Database  
 The final step required for creating, updating, and deleting objects, is to actually submit the changes to the database. Without this step, your changes are only local and will not appear in query results.  
  
#### To submit changes to the database  
  
1.  Insert the following code just above `Console.ReadLine`:  
  
     [!code-csharp[DLinqWalk3CS#6](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#6)]  
  
2.  Insert the following code (after `SubmitChanges`) to show the before and after effects of submitting the changes:  
  
     [!code-csharp[DLinqWalk3CS#7](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk3CS/cs/Program.cs#7)]  
  
3.  Press F5 to debug the solution.  
  
4.  Press Enter in the **Console** window to close the application.  
  
> [!NOTE]
>  After you have added the new customer by submitting the changes, you cannot execute this solution again as is. To execute the solution again, change the name of the customer and customer ID to be added.  
  
## See Also  
 [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md)
