---
title: "How to: Create a Bound Control and Format the Displayed Data"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "data [Windows Forms], formatting"
  - "bound controls [Windows Forms], creating"
  - "bound controls [Windows Forms], formatting data"
ms.assetid: d5a56228-899d-41d9-8af8-87b3f4ec2f94
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Bound Control and Format the Displayed Data
With Windows Forms data binding, you can format the data displayed in a data-bound control by using the **Formatting and Advanced Binding** dialog box.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To bind a control and format the displayed data  
  
1.  Connect to a data source.  
  
     For more information, see [Connecting to a Data Source](../../../docs/framework/data/adonet/connecting-to-a-data-source.md).  
  
2.  In the form, select the control, and then open the Properties window.  
  
3.  Expand the **(DataBindings)** property, and then in the **(Advanced)** box, click the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) to display the **Formatting and Advanced Binding** dialog box, which has a complete list of properties for that control.  
  
4.  Select the property you want to bind, and then click the **Binding** arrow.  
  
     A list of available data sources is displayed.  
  
5.  Expand the data source you want to bind to until you find the single data element you want.  
  
     For example, if you are binding to a column value in a dataset's table, expand the name of the dataset, and then expand the table name to display column names.  
  
6.  Click the name of an element to bind to.  
  
7.  In the **Format type** box, click the format you want to apply to the data displayed in the control.  
  
     In every case, you can specify the value displayed in the control if the data source contains <xref:System.DBNull>. Otherwise, the options vary slightly, depending on the format type you choose. The following table shows the format types and options.  
  
    |Format type|Formatting option|  
    |-----------------|-----------------------|  
    |No Formatting|No options.|  
    |Numeric|Specify number of decimal places by using **Decimal places** up-down control.|  
    |Currency|Specify number of decimal places by using **Decimal places** up-down control.|  
    |Date Time|Select how the date and time should be displayed by selecting one of the items in the **Type** selection box.|  
    |Scientific|Specify number of decimal places by using **Decimal places** up-down control.|  
    |Custom|Specify a custom format string using.<br /><br /> For more information, see [Formatting Types](../../../docs/standard/base-types/formatting-types.md). **Note:**  Custom format strings are not guaranteed to successfully round trip between the data source and bound control. Instead handle the <xref:System.Windows.Forms.Binding.Parse> or <xref:System.Windows.Forms.Binding.Format> event for the binding and apply custom formatting in the event-handling code.|  
  
8.  Click **OK** to close the **Formatting and Advanced Binding** dialog box and return to the Properties window.  
  
## See Also  
 [How to: Create a Simple-Bound Control on a Windows Form](../../../docs/framework/winforms/how-to-create-a-simple-bound-control-on-a-windows-form.md)  
 [User Input Validation in Windows Forms](../../../docs/framework/winforms/user-input-validation-in-windows-forms.md)  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)
