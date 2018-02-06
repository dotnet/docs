---
title: "How to: View Errors Within a DataSet with the Windows Forms ErrorProvider Component"
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
  - "errors [Windows Forms], dataset errors"
  - "error messages [Windows Forms], viewing in datasets"
  - "ErrorProvider component [Windows Forms], dataset errors"
ms.assetid: cbae023f-d651-4210-bdea-bcc5f037e321
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: View Errors Within a DataSet with the Windows Forms ErrorProvider Component
You can use the Windows Forms <xref:System.Windows.Forms.ErrorProvider> component to view column errors within a dataset or other data source. For an <xref:System.Windows.Forms.ErrorProvider> component to display data errors on a form, it does not have to be directly associated with a control. Once it is bound to a data source, it can display an error icon next to any control that is bound to the same data source.  
  
> [!NOTE]
>  If you change the error provider's <xref:System.Windows.Forms.ErrorProvider.DataSource%2A> and <xref:System.Windows.Forms.ErrorProvider.DataMember%2A> properties at run time, you should use the <xref:System.Windows.Forms.ErrorProvider.BindToDataAndErrors%2A> method to avoid conflicts.  
  
### To display data errors  
  
1.  Bind the component to a specific column within a data table.  
  
    ```vb  
    ' Assumes existence of DataSet1, DataTable1  
    TextBox1.DataBindings.Add("Text", DataSet1, "Customers.Name")  
    ErrorProvider1.DataSource = DataSet1  
    ErrorProvider1.DataMember = "Customers"  
    ```  
  
    ```csharp  
    // Assumes existence of DataSet1, DataTable1  
    textBox1.DataBindings.Add("Text", DataSet1, "Customers.Name");  
    errorProvider1.DataSource = DataSet1;  
    errorProvider1.DataMember = "Customers";  
    ```  
  
2.  Set the <xref:System.Windows.Forms.ErrorProvider.ContainerControl%2A> property to the form.  
  
    ```vb  
    ErrorProvider1.ContainerControl = Me  
    ```  
  
    ```csharp  
    errorProvider1.ContainerControl = this;  
    ```  
  
3.  Set the position of the current record to a row that contains a column error.  
  
    ```vb  
    DataTable1.Rows(5).SetColumnError("Name", "Bad data in this row.")  
    Me.BindingContext(DataTable1).Position = 5  
    ```  
  
    ```csharp  
    DataTable1.Rows[5].SetColumnError("Name", "Bad data in this row.");  
    this.BindingContext [DataTable1].Position = 5;  
    ```  
  
## See Also  
 [ErrorProvider Component Overview](../../../../docs/framework/winforms/controls/errorprovider-component-overview-windows-forms.md)  
 [How to: Display Error Icons for Form Validation with the Windows Forms ErrorProvider Component](../../../../docs/framework/winforms/controls/display-error-icons-for-form-validation-with-wf-errorprovider.md)
