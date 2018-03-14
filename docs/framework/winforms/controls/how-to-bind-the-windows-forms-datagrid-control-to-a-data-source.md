---
title: "How to: Bind the Windows Forms DataGrid Control to a Data Source"
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
  - "cpp"
helpviewer_keywords: 
  - "datasets [Windows Forms], binding to DataGrid control"
  - "data binding [Windows Forms], DataGrid control"
  - "DataGrid control [Windows Forms], data binding"
  - "bound controls [Windows Forms], DataGrid control"
  - "Windows Forms controls, data binding"
  - "bound controls [Windows Forms]"
  - "data-bound controls [Windows Forms], DataGrid"
ms.assetid: 128cdb07-dfd3-4d60-9d6a-902847667c36
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind the Windows Forms DataGrid Control to a Data Source
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 The Windows Forms <xref:System.Windows.Forms.DataGrid> control is specifically designed to display information from a data source. You bind the control at run time by calling the <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method. Although you can display data from a variety of data sources, the most typical sources are datasets and data views.  
  
### To data-bind the DataGrid control programmatically  
  
1.  Write code to fill the dataset.  
  
     If the data source is a dataset or a data view based on a dataset table, add code to the form to fill the dataset.  
  
     The exact code you use depends on where the dataset is getting data. If the dataset is being populated directly from a database, you typically call the `Fill` method of a data adapter, as in the following example, which populates a dataset called `DsCategories1`:  
  
    ```vb  
    sqlDataAdapter1.Fill(DsCategories1)  
    ```  
  
    ```csharp  
    sqlDataAdapter1.Fill(DsCategories1);  
    ```  
  
    ```cpp  
    sqlDataAdapter1->Fill(dsCategories1);  
    ```  
  
     If the dataset is being filled from an XML Web service, you typically create an instance of the service in your code and then call one of its methods to return a dataset. You then merge the dataset from the XML Web service into your local dataset. The following example shows how you can create an instance of an XML Web service called `CategoriesService`, call its `GetCategories` method, and merge the resulting dataset into a local dataset called `DsCategories1`:  
  
    ```vb  
    Dim ws As New MyProject.localhost.CategoriesService()  
    ws.Credentials = System.Net.CredentialCache.DefaultCredentials  
    DsCategories1.Merge(ws.GetCategories())  
    ```  
  
    ```csharp  
    MyProject.localhost.CategoriesService ws = new MyProject.localhost.CategoriesService();  
    ws.Credentials = System.Net.CredentialCache.DefaultCredentials;  
    DsCategories1.Merge(ws.GetCategories());  
    ```  
  
    ```cpp  
    MyProject::localhost::CategoriesService^ ws =   
       new MyProject::localhost::CategoriesService();  
    ws->Credentials = System::Net::CredentialCache::DefaultCredentials;  
    dsCategories1->Merge(ws->GetCategories());  
    ```  
  
2.  Call the <xref:System.Windows.Forms.DataGrid> control's <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method, passing it the data source and a data member. If you do not need to explicitly pass a data member, pass an empty string.  
  
    > [!NOTE]
    >  If you are binding the grid for the first time, you can set the control's <xref:System.Windows.Forms.DataGrid.DataSource%2A> and <xref:System.Windows.Forms.DataGrid.DataMember%2A> properties. However, you cannot reset these properties once they have been set. Therefore, it is recommended that you always use the <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method.  
  
     The following example shows how you can programmatically bind to the Customers table in a dataset called `DsCustomers1`:  
  
    ```vb  
    DataGrid1.SetDataBinding(DsCustomers1, "Customers")  
    ```  
  
    ```csharp  
    DataGrid1.SetDataBinding(DsCustomers1, "Customers");  
    ```  
  
    ```cpp  
    dataGrid1->SetDataBinding(dsCustomers1, "Customers");  
    ```  
  
     If the Customers table is the only table in the dataset, you could alternatively bind the grid this way:  
  
    ```vb  
    DataGrid1.SetDataBinding(DsCustomers1, "")  
    ```  
  
    ```csharp  
    DataGrid1.SetDataBinding(DsCustomers1, "");  
    ```  
  
    ```cpp  
    dataGrid1->SetDataBinding(dsCustomers1, "");  
    ```  
  
3.  (Optional) Add the appropriate table styles and column styles to the grid. If there are no table styles, you will see the table, but with minimal formatting and with all columns visible.  
  
## See Also  
 [DataGrid Control Overview](../../../../docs/framework/winforms/controls/datagrid-control-overview-windows-forms.md)  
 [How to: Add Tables and Columns to the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-add-tables-and-columns-to-the-windows-forms-datagrid-control.md)  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)  
 [Windows Forms Data Binding](../../../../docs/framework/winforms/windows-forms-data-binding.md)
