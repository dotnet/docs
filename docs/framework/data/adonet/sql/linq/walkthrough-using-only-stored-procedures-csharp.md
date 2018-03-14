---
title: "Walkthrough: Using Only Stored Procedures (C#)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ecde4bf2-fa4d-4252-b5e4-96a46b9e097d
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Walkthrough: Using Only Stored Procedures (C#)
This walkthrough provides a basic end-to-end [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] scenario for accessing data by executing stored procedures only. This approach is often used by database administrators to limit how the datastore is accessed.  
  
> [!NOTE]
>  You can also use stored procedures in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] applications to override default behavior, especially for `Create`, `Update`, and `Delete` processes. For more information, see [Customizing Insert, Update, and Delete Operations](../../../../../../docs/framework/data/adonet/sql/linq/customizing-insert-update-and-delete-operations.md).  
  
 For purposes of this walkthrough, you will use two methods that have been mapped to stored procedures in the Northwind sample database: CustOrdersDetail and CustOrderHist. The mapping occurs when you run the SqlMetal command-line tool to generate a C# file. For more information, see the Prerequisites section later in this walkthrough.  
  
 This walkthrough does not rely on the [!INCLUDE[vs_ordesigner_long](../../../../../../includes/vs-ordesigner-long-md.md)]. Developers using [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] can also use the [!INCLUDE[vs_ordesigner_short](../../../../../../includes/vs-ordesigner-short-md.md)] to implement stored procedure functionality. See [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
 This walkthrough was written by using Visual C# Development Settings.  
  
## Prerequisites  
 This walkthrough requires the following:  
  
-   This walkthrough uses a dedicated folder ("c:\linqtest7") to hold files. Create this folder before you begin the walkthrough.  
  
-   The Northwind sample database.  
  
     If you do not have this database on your development computer, you can download it from the Microsoft download site. For instructions, see [Downloading Sample Databases](../../../../../../docs/framework/data/adonet/sql/linq/downloading-sample-databases.md). After you have downloaded the database, copy the northwnd.mdf file to the c:\linqtest7 folder.  
  
-   A C# code file generated from the Northwind database.  
  
     This walkthrough was written by using the SqlMetal tool with the following command line:  
  
     **sqlmetal /code:"c:\linqtest7\northwind.cs" /language:csharp "c:\linqtest7\northwnd.mdf" /sprocs /functions /pluralize**  
  
     For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../../../docs/framework/tools/sqlmetal-exe-code-generation-tool.md).  
  
## Overview  
 This walkthrough consists of six main tasks:  
  
-   Setting up the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] solution in [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)].  
  
-   Adding the System.Data.Linq assembly to the project.  
  
-   Adding the database code file to the project.  
  
-   Creating a connection with the database.  
  
-   Setting up the user interface.  
  
-   Running and testing the application.  
  
## Creating a LINQ to SQL Solution  
 In this first task, you create a [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] solution that contains the necessary references to build and run a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] project.  
  
#### To create a LINQ to SQL solution  
  
1.  On the [!INCLUDE[vs_current_short](../../../../../../includes/vs-current-short-md.md)] **File** menu, point to **New**, and then click **Project**.  
  
2.  In the **Project types** pane in the **New Project** dialog box, click **Visual C#**.  
  
3.  In the **Templates** pane, click **Windows Forms Application**.  
  
4.  In the **Name** box, type **SprocOnlyApp**.  
  
5.  In the **Location** box, verify where you want to store your project files.  
  
6.  Click **OK**.  
  
     The Windows Forms Designer opens.  
  
## Adding the LINQ to SQL Assembly Reference  
 The [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] assembly is not included in the standard Windows Forms Application template. You will have to add the assembly yourself, as explained in the following steps:  
  
#### To add System.Data.Linq.dll  
  
1.  In **Solution Explorer**, right-click **References**, and then click **Add Reference**.  
  
2.  In the **Add Reference** dialog box, click **.NET**, click the System.Data.Linq assembly, and then click **OK**.  
  
     The assembly is added to the project.  
  
## Adding the Northwind Code File to the Project  
 This step assumes that you have used the SqlMetal tool to generate a code file from the Northwind sample database. For more information, see the Prerequisites section earlier in this walkthrough.  
  
#### To add the northwind code file to the project  
  
1.  On the **Project** menu, click **Add Existing Item**.  
  
2.  In the **Add Existing Item** dialog box, move to c:\linqtest7\northwind.cs, and then click **Add**.  
  
     The northwind.cs file is added to the project.  
  
## Creating a Database Connection  
 In this step, you define the connection to the Northwind sample database. This walkthrough uses "c:\linqtest7\northwnd.mdf" as the path.  
  
#### To create the database connection  
  
1.  In **Solution Explorer**, right-click **Form1.cs**, and then click **View Code**.  
  
2.  Type the following code into the `Form1` class:  
  
     [!code-csharp[DLinqWalk4CS#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk4CS/cs/Form1.cs#1)]  
  
## Setting up the User Interface  
 In this task you set up an interface so that users can execute stored procedures to access data in the database. In the applications that you are developing with this walkthrough, users can access data in the database only by using the stored procedures embedded in the application.  
  
#### To set up the user interface  
  
1.  Return to the Windows Forms Designer (**Form1.cs[Design]**).  
  
2.  On the **View** menu, click **Toolbox**.  
  
     The toolbox opens.  
  
    > [!NOTE]
    >  Click the **AutoHide** pushpin to keep the toolbox open while you perform the remaining steps in this section.  
  
3.  Drag two buttons, two text boxes, and two labels from the toolbox onto **Form1**.  
  
     Arrange the controls as in the accompanying illustration. Expand **Form1** so that the controls fit easily.  
  
4.  Right-click **label1**, and then click **Properties**.  
  
5.  Change the **Text** property from **label1** to **Enter OrderID:**.  
  
6.  In the same way for **label2**, change the **Text** property from **label2** to **Enter CustomerID:**.  
  
7.  In the same way, change the **Text** property for **button1** to **Order Details**.  
  
8.  Change the **Text** property for **button2** to **Order History**.  
  
     Widen the button controls so that all the text is visible.  
  
#### To handle button clicks  
  
1.  Double-click **Order Details** on **Form1** to open the button1 event handler in the code editor.  
  
2.  Type the following code into the `button1` handler:  
  
     [!code-csharp[DLinqWalk4CS#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk4CS/cs/Form1.cs#2)]  
  
3.  Now double-click **button2** on **Form1** to open the `button2` handler  
  
4.  Type the following code into the `button2` handler:  
  
     [!code-csharp[DLinqWalk4CS#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqWalk4CS/cs/Form1.cs#3)]  
  
## Testing the Application  
 Now it is time to test your application. Note that your contact with the datastore is limited to whatever actions the two stored procedures can take. Those actions are to return the products included for any orderID you enter, or to return a history of products ordered for any CustomerID you enter.  
  
#### To test the application  
  
1.  Press F5 to start debugging.  
  
     Form1 appears.  
  
2.  In the **Enter OrderID** box, type `10249`, and then click **Order Details**.  
  
     A message box lists the products included in order 10249.  
  
     Click **OK** to close the message box.  
  
3.  In the **Enter CustomerID** box, type `ALFKI`, and then click **Order History**.  
  
     A message box appears that lists the order history for customer ALFKI.  
  
     Click **OK** to close the message box.  
  
4.  In the **Enter OrderID** box, type `123`, and then click **Order Details**.  
  
     A message box appears that displays "No results."  
  
     Click **OK** to close the message box.  
  
5.  On the **Debug** menu, click **Stop debugging**.  
  
     The debug session closes.  
  
6.  If you have finished experimenting, you can click **Close Project** on the **File** menu, and save your project when you are prompted.  
  
## Next Steps  
 You can enhance this project by making some changes. For example, you could list available stored procedures in a list box and have the user select which procedures to execute. You could also stream the output of the reports to a text file.  
  
## See Also  
 [Learning by Walkthroughs](../../../../../../docs/framework/data/adonet/sql/linq/learning-by-walkthroughs.md)  
 [Stored Procedures](../../../../../../docs/framework/data/adonet/sql/linq/stored-procedures.md)
