---
title: "How to: Bind a Windows Forms ComboBox or ListBox Control to Data"
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
  - "data [Windows Forms], binding to controls"
  - "list boxes [Windows Forms], data binding"
  - "ComboBox control [Windows Forms], data binding"
  - "data binding [Windows Forms], combo boxes"
  - "ListBox control [Windows Forms], data binding"
  - "combo boxes [Windows Forms], data binding"
  - "bound controls [Windows Forms], combo boxes"
  - "Windows Forms controls, data binding"
  - "data-bound controls [Windows Forms], Windows Forms"
ms.assetid: dfd7f081-8bea-4a41-86a3-86a1934828ef
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind a Windows Forms ComboBox or ListBox Control to Data
You can bind the <xref:System.Windows.Forms.ComboBox> and <xref:System.Windows.Forms.ListBox> to data to perform tasks such as browsing data in a database, entering new data, or editing existing data.  
  
### To bind a ComboBox or ListBox control  
  
1.  Set the `DataSource` property to a data source object. Possible data sources include a <xref:System.Windows.Forms.BindingSource> bound to data, a data table, a data view, a dataset, a data view manager, an array, or any class that implements the <xref:System.Collections.IList> interface. For more information, see [Data Sources Supported by Windows Forms](../../../../docs/framework/winforms/data-sources-supported-by-windows-forms.md).  
  
2.  If you are binding to a table, set the `DisplayMember` property to the name of a column in the data source.  
  
     \- or -  
  
     If you are binding to an <xref:System.Collections.IList>, set the display member to a public property of the type in the list.  
  
    ```vb  
    Private Sub BindComboBox()  
      ComboBox1.DataSource = DataSet1.Tables("Suppliers")  
      ComboBox1.DisplayMember = "ProductName"  
    End Sub  
    ```  
  
    ```csharp  
    private void BindComboBox()  
    {  
      comboBox1.DataSource = dataSet1.Tables["Suppliers"];  
      comboBox1.DisplayMember = "ProductName";  
    }  
    ```  
  
    > [!NOTE]
    >  If you are bound to a data source that does not implement the <xref:System.ComponentModel.IBindingList> interface, such as an <xref:System.Collections.ArrayList>, the bound control's data will not be updated when the data source is updated. For example, if you have a combo box bound to an <xref:System.Collections.ArrayList> and data is added to the <xref:System.Collections.ArrayList>, these new items will not appear in the combo box. However, you can force the combo box to be updated by calling the <xref:System.Windows.Forms.BindingManagerBase.SuspendBinding%2A> and <xref:System.Windows.Forms.BindingManagerBase.ResumeBinding%2A> methods on the instance of the <xref:System.Windows.Forms.BindingContext> class to which the control is bound.  
  
## See Also  
 <xref:System.Windows.Forms.ComboBox>  
 <xref:System.Windows.Forms.ListBox>  
 [Windows Forms Data Binding](../../../../docs/framework/winforms/windows-forms-data-binding.md)  
 [Data Binding and Windows Forms](../../../../docs/framework/winforms/data-binding-and-windows-forms.md)  
 [Windows Forms Controls Used to List Options](../../../../docs/framework/winforms/controls/windows-forms-controls-used-to-list-options.md)
