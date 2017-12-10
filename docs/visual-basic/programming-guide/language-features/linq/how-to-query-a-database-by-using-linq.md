---
title: "How to: Query a Database by Using LINQ (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "query samples [LINQ]"
  - "database querying [LINQ]"
  - "queries [LINQ in Visual Basic], database querying"
  - "querying databases [LINQ]"
  - "queries [LINQ in Visual Basic], how-to topics"
  - "query samples [Visual Basic]"
ms.assetid: bcf5e9c3-a236-4399-9a7f-3991eca7cf56
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Query a Database by Using LINQ (Visual Basic)
Language-Integrated Query (LINQ) makes it easy to access database information and execute queries.  
  
 The following example shows how to create a new application that performs queries against a SQL Server database.  
  
 The examples in this topic use the Northwind sample database. If you do not have the Northwind sample database on your development computer, you can download it from the [Microsoft Download Center](http://go.microsoft.com/fwlink/?LinkID=98088) Web site. For instructions, see [Downloading Sample Databases](../../../../framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
## To create a connection to a database  
  
1.  In Visual Studio, open **Server Explorer**/**Database Explorer** by clicking **Server Explorer**/**Database Explorer** on the **View** menu.  
  
2.  Right-click **Data Connections** in **Server Explorer**/**Database Explorer** and then click **Add Connection**.  
  
3.  Specify a valid connection to the Northwind sample database.  
  
## To add a project that contains a LINQ to SQL file  
  
1.  In Visual Studio, on the **File** menu, point to **New** and then click **Project**. Select Visual Basic **Windows Forms Application** as the project type.  
  
2.  On the **Project** menu, click **Add New Item**. Select the **LINQ to SQL Classes** item template.  
  
3.  Name the file `northwind.dbml`. Click **Add**. The Object Relational Designer (O/R Designer) is opened for the northwind.dbml file.  
  
## To add tables to query to the O/R Designer  
  
1.  In **Server Explorer**/**Database Explorer**, expand the connection to the Northwind database. Expand the **Tables** folder.  
  
     If you have closed the O/R Designer, you can reopen it by double-clicking the northwind.dbml file that you added earlier.  
  
2.  Click the Customers table and drag it to the left pane of the designer. Click the Orders table and drag it to the left pane of the designer.  
  
     The designer creates new `Customer` and `Order` objects for your project. Notice that the designer automatically detects relationships between the tables and creates child properties for related objects. For example, IntelliSense will show that the `Customer` object has an `Orders` property for all orders related to that customer.  
  
3.  Save your changes and close the designer.  
  
4.  Save your project.  
  
## To add code to query the database and display the results  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.DataGridView> control onto the default Windows Form for your project, Form1.  
  
2.  Double-click Form1 to add code to the `Load` event of the form.  
  
3.  When you added tables to the O/R Designer, the designer added a <xref:System.Data.Linq.DataContext> object for your project. This object contains the code that you must have to access those tables, in addition to individual objects and collections for each table. The <xref:System.Data.Linq.DataContext> object for your project is named based on the name of your .dbml file. For this project, the <xref:System.Data.Linq.DataContext> object is named `northwindDataContext`.  
  
     You can create an instance of the <xref:System.Data.Linq.DataContext> in your code and query the tables specified by the O/R Designer.  
  
     Add the following code to the `Load` event to query the tables that are exposed as properties of your data context.  
  
     [!code-vb[VbLINQToSQLHowTos#3](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/how-to-query-a-database-by-using-linq_1.vb)]  
  
4.  Press F5 to run your project and view the results.  
  
5.  Following are some additional queries that you can try:  
  
     [!code-vb[VbLINQToSQLHowTos#4](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/how-to-query-a-database-by-using-linq_2.vb)]  
    [!code-vb[VbLINQToSQLHowTos#5](../../../../visual-basic/programming-guide/language-features/linq/codesnippet/VisualBasic/how-to-query-a-database-by-using-linq_3.vb)]  
  
## See Also  
 [LINQ](../../../../visual-basic/programming-guide/language-features/linq/index.md)  
 [Queries](../../../../visual-basic/language-reference/queries/queries.md)  
 [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)  
 [DataContext Methods (O/R Designer)](/visualstudio/data-tools/datacontext-methods-o-r-designer)
