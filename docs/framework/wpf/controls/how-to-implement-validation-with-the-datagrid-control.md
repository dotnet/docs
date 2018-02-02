---
title: "How to: Implement Validation with the DataGrid Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGrid [WPF], validation"
  - "validation [WPF], DataGrid"
ms.assetid: ec6078a8-1e42-4648-b414-f4348e81bda1
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Implement Validation with the DataGrid Control
The <xref:System.Windows.Controls.DataGrid> control enables you to perform validation at both the cell and row level. With cell-level validation, you validate individual properties of a bound data object when a user updates a value. With row-level validation, you validate entire data objects when a user commits changes to a row. You can also provide customized visual feedback for validation errors, or use the default visual feedback that the <xref:System.Windows.Controls.DataGrid> control provides.  
  
 The following procedures describe how to apply validation rules to <xref:System.Windows.Controls.DataGrid> bindings and customize the visual feedback.  
  
### To validate individual cell values  
  
-   Specify one or more validation rules on the binding used with a column. This is similar to validating data in simple controls, as described in [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
     The following example shows a <xref:System.Windows.Controls.DataGrid> control with four columns bound to different properties of a business object. Three of the columns specify the <xref:System.Windows.Controls.ExceptionValidationRule> by setting the <xref:System.Windows.Data.Binding.ValidatesOnExceptions%2A> property to `true`.  
  
     [!code-xaml[DataGrid_Validation#BasicXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/window1.xaml#basicxaml)]  
  
     When a user enters an invalid value (such as a non-integer in the Course ID column), a red border appears around the cell. You can change this default validation feedback as described in the following procedure.  
  
### To customize cell validation feedback  
  
-   Set the column's <xref:System.Windows.Controls.DataGridBoundColumn.EditingElementStyle%2A> property to a style appropriate for the column's editing control. Because the editing controls are created at run time, you cannot use the <xref:System.Windows.Controls.Validation.ErrorTemplate%2A?displayProperty=nameWithType> attached property like you would with simple controls.  
  
     The following example updates the previous example by adding an error style shared by the three columns with validation rules. When a user enters an invalid value, the style changes the cell background color and adds a ToolTip. Note the use of a trigger to determine whether there is a validation error. This is required because there is currently no dedicated error template for cells.  
  
     [!code-xaml[DataGrid_Validation#CellValidationXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/mainwindow.xaml#cellvalidationxaml)]  
  
     You can implement more extensive customization by replacing the <xref:System.Windows.Controls.DataGridColumn.CellStyle%2A> used by the column.  
  
### To validate multiple values in a single row  
  
1.  Implement a <xref:System.Windows.Controls.ValidationRule> subclass that checks multiple properties of the bound data object. In your <xref:System.Windows.Controls.ValidationRule.Validate%2A> method implementation, cast the `value` parameter value to a <xref:System.Windows.Data.BindingGroup> instance. You can then access the data object through the <xref:System.Windows.Data.BindingGroup.Items%2A> property.  
  
     The following example demonstrates this process to validate whether the `StartDate` property value for a `Course` object is earlier than its `EndDate` property value.  
  
     [!code-csharp[DataGrid_Validation#CourseValidationRule](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/mainwindow.xaml.cs#coursevalidationrule)]
     [!code-vb[DataGrid_Validation#CourseValidationRule](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/datagrid_validation/vb/mainwindow.xaml.vb#coursevalidationrule)]  
  
2.  Add the validation rule to the <xref:System.Windows.Controls.DataGrid.RowValidationRules%2A?displayProperty=nameWithType> collection. The <xref:System.Windows.Controls.DataGrid.RowValidationRules%2A> property provides direct access to the <xref:System.Windows.Data.BindingGroup.ValidationRules%2A> property of a <xref:System.Windows.Data.BindingGroup> instance that groups all the bindings used by the control.  
  
     The following example sets the <xref:System.Windows.Controls.DataGrid.RowValidationRules%2A> property in XAML. The <xref:System.Windows.Controls.ValidationRule.ValidationStep%2A> property is set to <xref:System.Windows.Controls.ValidationStep.UpdatedValue> so that the validation occurs only after the bound data object is updated.  
  
     [!code-xaml[DataGrid_Validation#RowValidationRulesXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/mainwindow.xaml#rowvalidationrulesxaml)]  
  
     When a user specifies an end date that is earlier than the start date, a red exclamation mark (!) appears in the row header. You can change this default validation feedback as described in the following procedure.  
  
### To customize row validation feedback  
  
-   Set the <xref:System.Windows.Controls.DataGrid.RowValidationErrorTemplate%2A?displayProperty=nameWithType> property. This property enables you to customize row validation feedback for individual <xref:System.Windows.Controls.DataGrid> controls. You can also affect multiple controls by using an implicit row style to set the <xref:System.Windows.Controls.DataGridRow.ValidationErrorTemplate%2A?displayProperty=nameWithType> property.  
  
     The following example replaces the default row validation feedback with a more visible indicator. When a user enters an invalid value, a red circle with a white exclamation mark appears in the row header. This occurs for both row and cell validation errors. The associated error message is displayed in a ToolTip.  
  
     [!code-xaml[DataGrid_Validation#RowValidationFeedbackXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/mainwindow.xaml#rowvalidationfeedbackxaml)]  
  
## Example  
 The following example provides a complete demonstration for cell and row validation. The `Course` class provides a sample data object that implements <xref:System.ComponentModel.IEditableObject> to support transactions. The <xref:System.Windows.Controls.DataGrid> control interacts with <xref:System.ComponentModel.IEditableObject> to enable users to revert changes by pressing ESC.  
  
> [!NOTE]
>  If you are using Visual Basic, in the first line of MainWindow.xaml, replace `x:Class="DataGridValidation.MainWindow"` with `x:Class="MainWindow"`.  
  
 To test the validation, try the following:  
  
-   In the Course ID column, enter a non-integer value.  
  
-   In the End Date column, enter a date that is earlier than the Start Date.  
  
-   Delete the value in Course ID, Start Date, or End Date.  
  
-   To undo an invalid cell value, put the cursor back in the cell and press the ESC key.  
  
-   To undo changes for an entire row when the current cell is in edit mode, press the ESC key twice.  
  
-   When a validation error occurs, move your mouse pointer over the indicator in the row header to see the associated error message.  
  
 [!code-csharp[DataGrid_Validation#FullCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/mainwindow.xaml.cs#fullcode)]
 [!code-vb[DataGrid_Validation#FullCode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/datagrid_validation/vb/mainwindow.xaml.vb#fullcode)]  
  
 [!code-xaml[DataGrid_Validation#FullXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/datagrid_validation/cs/mainwindow.xaml#fullxaml)]  
  
## See Also  
 <xref:System.Windows.Controls.DataGrid>  
 [DataGrid](../../../../docs/framework/wpf/controls/datagrid.md)  
 [Data Binding](../../../../docs/framework/wpf/data/data-binding-wpf.md)  
 [Implement Binding Validation](../../../../docs/framework/wpf/data/how-to-implement-binding-validation.md)  
 [Implement Validation Logic on Custom Objects](../../../../docs/framework/wpf/data/how-to-implement-validation-logic-on-custom-objects.md)
