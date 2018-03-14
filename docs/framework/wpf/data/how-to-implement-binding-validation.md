---
title: "How to: Implement Binding Validation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "validation of binding [WPF]"
  - "data binding [WPF], validation of binding"
  - "binding [WPF], validation of"
ms.assetid: eb98b33d-9866-49ae-b981-bc5ff20d607a
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Implement Binding Validation
This example shows how to use an <xref:System.Windows.Controls.Validation.ErrorTemplate%2A> and a style trigger to provide visual feedback to inform the user when an invalid value is entered, based on a custom validation rule.  
  
## Example  
 The text content of the <xref:System.Windows.Controls.TextBox> in the following example is bound to the `Age` property (of type int) of a binding source object named `ods`. The binding is set up to use a validation rule named `AgeRangeRule` so that if the user enters non-numeric characters or a value that is smaller than 21 or greater than 130, a red exclamation mark appears next to the text box and a tool tip with the error message appears when the user moves the mouse over the text box.  
  
 [!code-xaml[BindValidation#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindValidation/CSharp/Window1.xaml#2)]  
  
 The following example shows the implementation of `AgeRangeRule`, which inherits from <xref:System.Windows.Controls.ValidationRule> and overrides the <xref:System.Windows.Controls.ValidationRule.Validate%2A> method. The Int32.Parse() method is called on the value to make sure that it does not contain any invalid characters. The <xref:System.Windows.Controls.ValidationRule.Validate%2A> method returns a <xref:System.Windows.Controls.ValidationResult> that indicates if the value is valid based on whether an exception is caught during the parsing and whether the age value is outside of the lower and upper bounds.  
  
 [!code-csharp[BindValidation#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindValidation/CSharp/AgeRangeRule.cs#3)]  
  
 The following example shows the custom <xref:System.Windows.Controls.ControlTemplate> `validationTemplate` that creates a red exclamation mark to notify the user of a validation error. Control templates are used to redefine the appearance of a control.  
  
 [!code-xaml[BindValidation#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindValidation/CSharp/Window1.xaml#4)]  
  
 As shown in the following example, the <xref:System.Windows.Controls.ToolTip> that shows the error message is created using the style named `textBoxInError`. If the value of <xref:System.Windows.Controls.Validation.HasError%2A> is `true`, the trigger sets the tool tip of the current <xref:System.Windows.Controls.TextBox> to its first validation error. The <xref:System.Windows.Data.Binding.RelativeSource%2A> is set to <xref:System.Windows.Data.RelativeSourceMode.Self>, referring to the current element.  
  
 [!code-xaml[BindValidation#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindValidation/CSharp/Window1.xaml#5)]  
  
 For the complete example, see [Binding Validation Sample](http://go.microsoft.com/fwlink/?LinkID=159972).  
  
 Note that if you do not provide a custom <xref:System.Windows.Controls.Validation.ErrorTemplate%2A> the default error template appears to provide visual feedback to the user when there is a validation error. See "Data Validation" in [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md) for more information. Also, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a built-in validation rule that catches exceptions that are thrown during the update of the binding source property. For more information, see <xref:System.Windows.Controls.ExceptionValidationRule>.  
  
## See Also  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
