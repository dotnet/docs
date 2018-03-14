---
title: "Walkthrough: Creating a Master-Detail Form Using Two Windows Forms DataGridView Controls"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], master/detail form"
  - "parent-child tables [Windows Forms], displaying on Windows Forms"
  - "master-details lists [Windows Forms], displaying on Windows Forms"
  - "walkthroughs [Windows Forms], DataGridView control"
ms.assetid: c5fa29e8-47f7-4691-829b-0e697a691f36
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Creating a Master/Detail Form Using Two Windows Forms DataGridView Controls
One of the most common scenarios for using the <xref:System.Windows.Forms.DataGridView> control is the *master/detail* form, in which a parent/child relationship between two database tables is displayed. Selecting rows in the master table causes the detail table to update with the corresponding child data.  
  
 Implementing a master/detail form is easy using the interaction between the <xref:System.Windows.Forms.DataGridView> control and the <xref:System.Windows.Forms.BindingSource> component. In this walkthrough, you will build the form using two <xref:System.Windows.Forms.DataGridView> controls and two <xref:System.Windows.Forms.BindingSource> components. The form will show two related tables in the Northwind SQL Server sample database: `Customers` and `Orders`. When you are finished, you will have a form that shows all the customers in the database in the master <xref:System.Windows.Forms.DataGridView> and all the orders for the selected customer in the detail <xref:System.Windows.Forms.DataGridView>.  
  
 To copy the code in this topic as a single listing, see [How to: Create a Master/Detail Form Using Two Windows Forms DataGridView Controls](../../../../docs/framework/winforms/controls/create-a-master-detail-form-using-two-datagridviews.md).  
  
## Prerequisites  
 In order to complete this walkthrough, you will need:  
  
-   Access to a server that has the Northwind SQL Server sample database.  
  
## Creating the form  
  
#### To create a master/detail form  
  
1.  Create a class that derives from <xref:System.Windows.Forms.Form> and contains two <xref:System.Windows.Forms.DataGridView> controls and two <xref:System.Windows.Forms.BindingSource> components. The following code provides basic form initialization and includes a `Main` method. If you use the [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] designer to create your form, you can use the designer generated code instead of this code, but be sure to use the names shown in the variable declarations here.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMasterDetails#01](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/CS/masterdetails.cs#01)]
     [!code-vb[System.Windows.Forms.DataGridViewMasterDetails#01](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/VB/masterdetails.vb#01)]  
    [!code-csharp[System.Windows.Forms.DataGridViewMasterDetails#02](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/CS/masterdetails.cs#02)]
    [!code-vb[System.Windows.Forms.DataGridViewMasterDetails#02](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/VB/masterdetails.vb#02)]  
  
2.  Implement a method in your form's class definition for handling the detail of connecting to the database. This example uses a `GetData` method that populates a <xref:System.Data.DataSet> object, adds a <xref:System.Data.DataRelation> object to the data set, and binds the <xref:System.Windows.Forms.BindingSource> components. Be sure to set the `connectionString` variable to a value that is appropriate for your database.  
  
    > [!IMPORTANT]
    >  Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md).  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMasterDetails#20](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/CS/masterdetails.cs#20)]
     [!code-vb[System.Windows.Forms.DataGridViewMasterDetails#20](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/VB/masterdetails.vb#20)]  
  
3.  Implement a handler for your form's <xref:System.Windows.Forms.Form.Load> event that binds the <xref:System.Windows.Forms.DataGridView> controls to the <xref:System.Windows.Forms.BindingSource> components and calls the `GetData` method. The following example includes code that resizes <xref:System.Windows.Forms.DataGridView> columns to fit the displayed data.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewMasterDetails#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/CS/masterdetails.cs#10)]
     [!code-vb[System.Windows.Forms.DataGridViewMasterDetails#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewMasterDetails/VB/masterdetails.vb#10)]  
  
## Testing the Application  
 You can now test the form to make sure it behaves as expected.  
  
#### To test the form  
  
-   Compile and run the application.  
  
     You will see two <xref:System.Windows.Forms.DataGridView> controls, one above the other. On top are the customers from the Northwind `Customers` table, and at the bottom are the `Orders` corresponding to the selected customer. As you select different rows in the upper <xref:System.Windows.Forms.DataGridView>, the contents of the lower <xref:System.Windows.Forms.DataGridView> change accordingly.  
  
## Next Steps  
 This application gives you a basic understanding of the <xref:System.Windows.Forms.DataGridView> control's capabilities. You can customize the appearance and behavior of the <xref:System.Windows.Forms.DataGridView> control in several ways:  
  
-   Change border and header styles. For more information, see [How to: Change the Border and Gridline Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/change-the-border-and-gridline-styles-in-the-datagrid.md).  
  
-   Enable or restrict user input to the <xref:System.Windows.Forms.DataGridView> control. For more information, see [How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/prevent-row-addition-and-deletion-datagridview.md), and [How to: Make Columns Read-Only in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-make-columns-read-only-in-the-windows-forms-datagridview-control.md).  
  
-   Validate user input to the <xref:System.Windows.Forms.DataGridView> control. For more information, see [Walkthrough: Validating Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/walkthrough-validating-data-in-the-windows-forms-datagridview-control.md).  
  
-   Handle very large data sets using virtual mode. For more information, see [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md).  
  
-   Customize the appearance of cells. For more information, see [How to: Customize the Appearance of Cells in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-cells-in-the-datagrid.md) and [How to: Set Default Cell Styles for the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-default-cell-styles-for-the-windows-forms-datagridview-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.BindingSource>  
 [Displaying Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/displaying-data-in-the-windows-forms-datagridview-control.md)  
 [How to: Create a Master/Detail Form Using Two Windows Forms DataGridView Controls](../../../../docs/framework/winforms/controls/create-a-master-detail-form-using-two-datagridviews.md)  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)
