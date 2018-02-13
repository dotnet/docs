---
title: "Using the Row for New Records in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], adding rows for new records"
  - "rows [Windows Forms], new records"
  - "DataGridView control [Windows Forms], data entry"
ms.assetid: 6110f1ea-9794-442c-a98a-f104a1feeaf4
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using the Row for New Records in the Windows Forms DataGridView Control
When you use a <xref:System.Windows.Forms.DataGridView> for editing data in your application, you will often want to give your users the ability to add new rows of data to the data store. The <xref:System.Windows.Forms.DataGridView> control supports this functionality by providing a row for new records, which is always shown as the last row. It is marked with an asterisk (*) symbol in its row header. The following sections discuss some of the things you should consider when you program with the row for new records enabled.  
  
## Displaying the Row for New Records  
 Use the <xref:System.Windows.Forms.DataGridView.AllowUserToAddRows%2A> property to indicate whether the row for new records is displayed. The default value of this property is `true`.  
  
 For the data bound case, the row for new records will be shown if the <xref:System.Windows.Forms.DataGridView.AllowUserToAddRows%2A> property of the control and the <xref:System.ComponentModel.IBindingList.AllowNew%2A?displayProperty=nameWithType> property of the data source are both `true`. If either is `false` then the row will not be shown.  
  
## Populating the Row for New Records with Default Data  
 When the user selects the row for new records as the current row, the <xref:System.Windows.Forms.DataGridView> control raises the <xref:System.Windows.Forms.DataGridView.DefaultValuesNeeded> event.  
  
 This event provides access to the new <xref:System.Windows.Forms.DataGridViewRow> and enables you to populate the new row with default data. For more information, see [How to: Specify Default Values for New Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/specify-default-values-for-new-rows-in-the-datagrid.md)  
  
## The Rows Collection  
 The row for new records is contained in the <xref:System.Windows.Forms.DataGridView> control's <xref:System.Windows.Forms.DataGridView.Rows%2A> collection but behaves differently in two respects:  
  
-   The row for new records cannot be removed from the <xref:System.Windows.Forms.DataGridView.Rows%2A> collection programmatically. An <xref:System.InvalidOperationException> is thrown if this is attempted. The user also cannot delete the row for new records. The <xref:System.Windows.Forms.DataGridViewRowCollection.Clear%2A?displayProperty=nameWithType> method does not remove this row from the <xref:System.Windows.Forms.DataGridView.Rows%2A> collection.  
  
-   No row can be added after the row for new records. An <xref:System.InvalidOperationException> is raised if this is attempted. As a result, the row for new records is always the last row in the <xref:System.Windows.Forms.DataGridView> control. The methods on <xref:System.Windows.Forms.DataGridViewRowCollection> that add rows—<xref:System.Windows.Forms.DataGridViewRowCollection.Add%2A>, <xref:System.Windows.Forms.DataGridViewRowCollection.AddCopy%2A>, and <xref:System.Windows.Forms.DataGridViewRowCollection.AddCopies%2A>—all call insertion methods internally when the row for new records is present.  
  
## Visual Customization of the Row for New Records  
 When the row for new records is created, it is based on the row specified by the <xref:System.Windows.Forms.DataGridView.RowTemplate%2A> property. Any cell styles that are not specified for this row are inherited from other properties. For more information about cell style inheritance, see [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md).  
  
 The initial values displayed by cells in the row for new records are retrieved from each cell's <xref:System.Windows.Forms.DataGridViewCell.DefaultNewRowValue%2A> property. For cells of type <xref:System.Windows.Forms.DataGridViewImageCell>, this property returns a placeholder image. Otherwise, this property returns `null`. You can override this property to return a custom value. However, these initial values can be replaced by a <xref:System.Windows.Forms.DataGridView.DefaultValuesNeeded> event handler when focus enters the row for new records.  
  
 The standard icons for this row's header, which are an arrow or an asterisk, are not exposed publicly. If you want to customize the icons, you will need to create a custom <xref:System.Windows.Forms.DataGridViewRowHeaderCell> class.  
  
 The standard icons use the <xref:System.Windows.Forms.DataGridViewCellStyle.ForeColor%2A> property of the <xref:System.Windows.Forms.DataGridViewCellStyle> in use by the row header cell. The standard icons are not rendered if there is not enough space to display them completely.  
  
 If the row header cell has a string value set, and if there is not enough room for both the text and icon, the icon is dropped first.  
  
## Sorting  
 In unbound mode, new records will always be added to the end of the <xref:System.Windows.Forms.DataGridView> even if the user has sorted the content of the <xref:System.Windows.Forms.DataGridView>. The user will need to apply the sort again in order to sort the row to the correct position; this behavior is similar to that of the <xref:System.Windows.Forms.ListView> control.  
  
 In data bound and virtual modes, the insertion behavior when a sort is applied will be dependent on the implementation of the data model. For [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)], the row is immediately sorted into the correct position.  
  
## Other Notes on the Row for New Records  
 You cannot set the <xref:System.Windows.Forms.DataGridViewRow.Visible%2A> property of this row to `false`. An <xref:System.InvalidOperationException> is raised if this is attempted.  
  
 The row for new records is always created in the unselected state.  
  
## Virtual Mode  
 If you are implementing virtual mode, you will need to track when a row for new records is needed in the data model and when to roll back the addition of the row. The exact implementation of this functionality depends on the implementation of the data model and its transaction semantics, for example, whether commit scope is at the cell or row level. For more information, see [Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/virtual-mode-in-the-windows-forms-datagridview-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.DefaultValuesNeeded?displayProperty=nameWithType>  
 [Data Entry in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-entry-in-the-windows-forms-datagridview-control.md)  
 [How to: Specify Default Values for New Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/specify-default-values-for-new-rows-in-the-datagrid.md)
