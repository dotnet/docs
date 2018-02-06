---
title: "How to: Modify Data in a Database by Using LINQ (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "inserting rows [LINQ to SQL]"
  - "deleting rows [LINQ to SQL]"
  - "updating rows [LINQ to SQL]"
  - "inserting data [Visual Basic]"
  - "deleting data"
  - "data [Visual Basic], updating"
  - "updating data [LINQ]"
  - "queries [LINQ in Visual Basic], data changes in database"
  - "queries [LINQ in Visual Basic], how-to topics"
ms.assetid: cf52635f-0c1b-46c3-aff1-bdf181cf19b1
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Modify Data in a Database by Using LINQ (Visual Basic)
Language-Integrated Query (LINQ) queries make it easy to access database information and modify values in the database.  
  
 The following example shows how to create a new application that retrieves and updates information in a SQL Server database.  
  
 The examples in this topic use the Northwind sample database. If you do not have the Northwind sample database on your development computer, you can download it from the [Microsoft Download Center](http://go.microsoft.com/fwlink/?LinkID=98088) Web site. For instructions, see [Downloading Sample Databases](../../../../framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
### To create a connection to a database  
  
1.  In Visual Studio, open **Server Explorer**/**Database Explorer** by clicking the **View** menu, and then select **Server Explorer**/**Database Explorer**.  
  
2.  Right-click **Data Connections** in **Server Explorer**/**Database Explorer**, and click **Add Connection**.  
  
3.  Specify a valid connection to the Northwind sample database.  
  
### To add a Project with a LINQ to SQL file  
  
1.  In Visual Studio, on the **File** menu, point to **New** and then click **Project**. Select Visual Basic **Windows Forms Application** as the project type.  
  
2.  On the **Project** menu, click **Add New Item**. Select the **LINQ to SQL Classes** item template.  
  
3.  Name the file `northwind.dbml`. Click **Add**. The Object Relational Designer (O/R Designer) is opened for the `northwind.dbml` file.  
  
### To add tables to query and modify to the designer  
  
1.  In **Server Explorer**/**Database Explorer**, expand the connection to the Northwind database. Expand the **Tables** folder.  
  
     If you have closed the O/R Designer, you can reopen it by double-clicking the `northwind.dbml` file that you added earlier.  
  
2.  Click the Customers table and drag it to the left pane of the designer.  
  
     The designer creates a new Customer object for your project.  
  
3.  Save your changes and close the designer.  
  
4.  Save your project.  
  
### To add code to modify the database and display the results  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.DataGridView> control onto the default Windows Form for your project, Form1.  
  
2.  When you added tables to the O/R Designer, the designer added a <xref:System.Data.Linq.DataContext> object to your project. This object contains code that you can use to access the Customers table. It also contains code that defines  a local Customer object and a Customers collection for the table. The <xref:System.Data.Linq.DataContext> object for your project is named based on the name of your .dbml file. For this project, the <xref:System.Data.Linq.DataContext> object is named `northwindDataContext`.  
  
     You can create an instance of the <xref:System.Data.Linq.DataContext> object in your code and query and modify the Customers collection specified by the O/R Designer. Changes that you make to the Customers collection are not reflected in the database until you submit them by calling the <xref:System.Data.Linq.DataContext.SubmitChanges%2A> method of the <xref:System.Data.Linq.DataContext> object.  
  
     Double-click the Windows Form, Form1, to add code to the <xref:System.Windows.Forms.Form.Load> event to query the Customers table that is exposed as a property of your <xref:System.Data.Linq.DataContext>. Add the following code:  
  
    ```vb  
    Private db As northwindDataContext  
  
    Private Sub Form1_Load(ByVal sender As System.Object,   
                           ByVal e As System.EventArgs  
                          ) Handles MyBase.Load  
      db = New northwindDataContext()  
  
      RefreshData()  
    End Sub  
  
    Private Sub RefreshData()  
      Dim customers = From cust In db.Customers   
                      Where cust.City(0) = "W"   
                      Select cust  
  
      DataGridView1.DataSource = customers  
    End Sub  
    ```  
  
3.  From the **Toolbox**, drag three <xref:System.Windows.Forms.Button> controls onto the form. Select the first `Button` control. In the **Properties** window, set the `Name` of the `Button` control to `AddButton` and the `Text` to `Add`. Select the second button and set the `Name` property to `UpdateButton` and the `Text` property to `Update`. Select the third button and set the `Name` property to `DeleteButton` and the `Text` property to `Delete`.  
  
4.  Double-click the **Add** button to add code to its `Click` event. Add the following code:  
  
    ```vb  
    Private Sub AddButton_Click(ByVal sender As System.Object,   
                                ByVal e As System.EventArgs  
                               ) Handles AddButton.Click  
      Dim cust As New Customer With {   
        .City = "Wellington",   
        .CompanyName = "Blue Yonder Airlines",   
        .ContactName = "Jill Frank",   
        .Country = "New Zealand",   
        .CustomerID = "JILLF"}  
  
      db.Customers.InsertOnSubmit(cust)  
  
      Try  
        db.SubmitChanges()  
      Catch  
        ' Handle exception.  
      End Try  
  
      RefreshData()  
    End Sub  
    ```  
  
5.  Double-click the **Update** button to add code to its `Click` event. Add the following code:  
  
    ```vb  
    Private Sub UpdateButton_Click(ByVal sender As System.Object, _  
                                   ByVal e As System.EventArgs  
                                  ) Handles UpdateButton.Click  
      Dim updateCust = (From cust In db.Customers   
                        Where cust.CustomerID = "JILLF").ToList()(0)  
  
      updateCust.ContactName = "Jill Shrader"  
  
      Try  
        db.SubmitChanges()  
      Catch  
        ' Handle exception.  
      End Try  
  
      RefreshData()  
    End Sub  
    ```  
  
6.  Double-click the **Delete** button to add code to its `Click` event. Add the following code:  
  
    ```vb  
    Private Sub DeleteButton_Click(ByVal sender As System.Object, _  
                                   ByVal e As System.EventArgs  
                                  ) Handles DeleteButton.Click  
      Dim deleteCust = (From cust In db.Customers   
                        Where cust.CustomerID = "JILLF").ToList()(0)  
  
      db.Customers.DeleteOnSubmit(deleteCust)  
  
      Try  
        db.SubmitChanges()  
      Catch  
        ' Handle exception.  
      End Try  
  
      RefreshData()  
    End Sub  
    ```  
  
7.  Press F5 to run your project. Click **Add** to add a new record. Click **Update** to modify the new record. Click **Delete** to delete the new record.  
  
## See Also  
 [LINQ](../../../../visual-basic/programming-guide/language-features/linq/index.md)  
 [Queries](../../../../visual-basic/language-reference/queries/queries.md)  
 [LINQ to SQL](../../../../framework/data/adonet/sql/linq/index.md)  
 [DataContext Methods (O/R Designer)](/visualstudio/data-tools/datacontext-methods-o-r-designer)  
 [How to: Assign stored procedures to perform updates, inserts, and deletes (O/R Designer)](http://msdn.microsoft.com/library/e88224ab-ff61-4a3a-b6b8-6f3694546cac)
