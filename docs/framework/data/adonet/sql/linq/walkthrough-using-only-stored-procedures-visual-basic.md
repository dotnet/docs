---
description: "Learn more about: Walkthrough: Using Only Stored Procedures (Visual Basic)"
title: "Walkthrough: Using Only Stored Procedures (Visual Basic)"
ms.date: "03/30/2017"
dev_langs: 
  - "vb"
ms.assetid: 5a736a30-ba66-4adb-b87c-57d19476e862
---
# Walkthrough: Using Only Stored Procedures (Visual Basic)

This walkthrough provides a basic end-to-end [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] scenario for accessing data by using stored procedures only. This approach is often used by database administrators to limit how the datastore is accessed.  
  
> [!NOTE]
> You can also use stored procedures in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] applications to override default behavior, especially for `Create`, `Update`, and `Delete` processes. For more information, see [Customizing Insert, Update, and Delete Operations](customizing-insert-update-and-delete-operations.md).  
  
 For purposes of this walkthrough, you will use two methods that have been mapped to stored procedures in the Northwind sample database: CustOrdersDetail and CustOrderHist. The mapping occurs when you run the SqlMetal command-line tool to generate a Visual Basic file. For more information, see the Prerequisites section later in this walkthrough.  
  
 This walkthrough does not rely on the Object Relational Designer. Developers using Visual Studio can also use the O/R Designer to implement stored procedure functionality. See [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2).  
  
 [!INCLUDE[note_settings_general](../../../../../../includes/note-settings-general-md.md)]  
  
 This walkthrough was written by using Visual Basic Development Settings.  
  
## Prerequisites  

 This walkthrough requires the following:  
  
- This walkthrough uses a dedicated folder ("c:\linqtest3") to hold files. Create this folder before you begin the walkthrough.  
  
- The Northwind sample database.  
  
     If you do not have this database on your development computer, you can download it from the Microsoft download site. For instructions, see [Downloading Sample Databases](downloading-sample-databases.md). After you have downloaded the database, copy the northwnd.mdf file to the c:\linqtest3 folder.  
  
- A Visual Basic code file generated from the Northwind database.  
  
     This walkthrough was written by using the SqlMetal tool with the following command line:  
  
     **sqlmetal /code:"c:\linqtest3\northwind.vb" /language:vb "c:\linqtest3\northwnd.mdf" /sprocs /functions /pluralize**  
  
     For more information, see [SqlMetal.exe (Code Generation Tool)](../../../../tools/sqlmetal-exe-code-generation-tool.md).  
  
## Overview  

 This walkthrough consists of six main tasks:  
  
- Setting up the [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] solution in Visual Studio.  
  
- Adding the System.Data.Linq assembly to the project.  
  
- Adding the database code file to the project.  
  
- Creating a connection to the database.  
  
- Setting up the user interface.  
  
- Running and testing the application.  
  
## Creating a LINQ to SQL Solution  

 In this first task, you create a Visual Studio solution that contains the necessary references to build and run a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] project.  
  
### To create a LINQ to SQL solution  
  
1. On the Visual Studio **File** menu, click **New Project**.  
  
2. In the **Project types** pane in the **New Project** dialog box, expand **Visual Basic**, and then click **Windows**.  
  
3. In the **Templates** pane, click **Windows Forms Application**.  
  
4. In the **Name** box, type **SprocOnlyApp**.  
  
5. Click **OK**.  
  
     The Windows Forms Designer opens.  
  
## Adding the LINQ to SQL Assembly Reference  

 The [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] assembly is not included in the standard Windows Forms Application template. You will have to add the assembly yourself, as explained in the following steps:  
  
### To add System.Data.Linq.dll  
  
1. In **Solution Explorer**, click **Show All Files**.  
  
2. In **Solution Explorer**, right-click **References**, and then click **Add Reference**.  
  
3. In the **Add Reference** dialog box, click **.NET**, click the System.Data.Linq assembly, and then click **OK**.  
  
     The assembly is added to the project.  
  
## Adding the Northwind Code File to the Project  

 This step assumes that you have used the SqlMetal tool to generate a code file from the Northwind sample database. For more information, see the Prerequisites section earlier in this walkthrough.  
  
### To add the northwind code file to the project  
  
1. On the **Project** menu, click **Add Existing Item**.  
  
2. In the **Add Existing Item** dialog box, move to c:\linqtest3\northwind.vb, and then click **Add**.  
  
     The northwind.vb file is added to the project.  
  
## Creating a Database Connection  

 In this step, you define the connection to the Northwind sample database. This walkthrough uses "c:\linqtest3\northwnd.mdf" as the path.  
  
### To create the database connection  
  
1. In **Solution Explorer**, right-click **Form1.vb**, and then click **View Code**.  
  
     `Class Form1` appears in the code editor.  
  
2. Type the following code into the `Form1` code block:  
  
     [!code-vb[DLinqWalk4VB#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk4VB/vb/Form1.vb#1)]  
  
## Setting up the User Interface  

 In this task you create an interface so that users can execute stored procedures to access data in the database. In the application that you are developing with this walkthrough, users can access data in the database only by using the stored procedures embedded in the application.  
  
### To set up the user interface  
  
1. Return to the Windows Forms Designer (**Form1.vb[Design]**).  
  
2. On the **View** menu, click **Toolbox**.  
  
     The toolbox opens.  
  
    > [!NOTE]
    > Click the **AutoHide** pushpin to keep the toolbox open while you perform the remaining steps in this section.  
  
3. Drag two buttons, two text boxes, and two labels from the toolbox onto **Form1**.  
  
     Arrange the controls as in the accompanying illustration. Expand **Form1** so that the controls fit easily.  
  
4. Right-click **Label1**, and then click **Properties**.  
  
5. Change the **Text** property from **Label1** to **Enter OrderID:**.  
  
6. In the same way for **Label2**, change the **Text** property from **Label2** to **Enter CustomerID:**.  
  
7. In the same way, change the **Text** property for **Button1** to **Order Details**.  
  
8. Change the **Text** property for **Button2** to **Order History**.  
  
     Widen the button controls so that all the text is visible.  
  
### To handle button clicks  
  
1. Double-click **Order Details** on **Form1** to create the `Button1` event handler and open the code editor.  
  
2. Type the following code into the `Button1` handler:  
  
     [!code-vb[DLinqWalk4VB#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk4VB/vb/Form1.vb#2)]  
  
3. Now double-click **Button2** on Form1 to create the `Button2` event handler and open the code editor.  
  
4. Type the following code into the `Button2` handler:  
  
     [!code-vb[DLinqWalk4VB#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqWalk4VB/vb/Form1.vb#3)]  
  
## Testing the Application  

 Now it is time to test your application. Note that your contact with the datastore is limited to whatever actions the two stored procedures can take. Those actions are to return the products included for any orderID you enter, or to return a history of products ordered for any CustomerID you enter.  
  
### To test the application  
  
1. Press F5 to start debugging.  
  
     Form1 appears.  
  
2. In the **Enter OrderID** box, type **10249** and then click **Order Details**.  
  
     A message box lists the products included in order 10249.  
  
     Click **OK** to close the message box.  
  
3. In the **Enter CustomerID** box, type `ALFKI`, and then click **Order History**.  
  
     A message box lists the order history for customer ALFKI.  
  
     Click **OK** to close the message box.  
  
4. In the **Enter OrderID** box, type `123`, and then click **Order Details**.  
  
     A message box displays "No results."  
  
     Click **OK** to close the message box.  
  
5. On the **Debug** menu, click **Stop debugging**.  
  
     The debug session closes.  
  
6. If you have finished experimenting, you can click **Close Project** on the **File** menu, and save your project when you are prompted.  
  
## Next Steps  

 You can enhance this project by making some changes. For example, you could list available stored procedures in a list box and have the user select which procedures to execute. You could also stream the output of the reports to a text file.  
  
## See also

- [Learning by Walkthroughs](learning-by-walkthroughs.md)
- [Stored Procedures](stored-procedures.md)
