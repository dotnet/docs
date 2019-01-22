---
title: "How to: Implement Validation Logic on Custom Objects"
ms.date: "08/02/2018"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "checking for validation errors [WPF]"
  - "validation errors [WPF], checking for"
  - "implementing validation logic on custom objects [WPF]"
  - "custom objects [WPF], implementing validation logic on"
ms.assetid: 751fda9b-44f9-4d63-b4f2-1df07ac41e0f
---
# How to: Implement Validation Logic on Custom Objects
This example shows how to implement validation logic on a custom object and then bind to it.  
  
## Example  
 You can provide validation logic on the business layer if your source object implements <xref:System.ComponentModel.IDataErrorInfo>, as in the following example, which defines a `Person` object that implements <xref:System.ComponentModel.IDataErrorInfo>:  
  
 [!code-csharp[BusinessLayerValidation#IDataErrorInfo](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BusinessLayerValidation/CSharp/Data.cs#idataerrorinfo)]
 [!code-vb[BusinessLayerValidation#IDataErrorInfo](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/BusinessLayerValidation/VisualBasic/Data.vb#idataerrorinfo)]  
  
 In the following example, the text property of the text box binds to the `Person.Age` property, which has been made available for binding through a resource declaration that is given the `x:Key` `data`. The <xref:System.Windows.Controls.DataErrorValidationRule> checks for the validation errors raised by the <xref:System.ComponentModel.IDataErrorInfo> implementation.  
  
 [!code-xaml[BusinessLayerValidation#BoundTextBox](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BusinessLayerValidation/CSharp/Window1.xaml?highlight=8,11-19,25-42)]  
  
 Alternatively, instead of using the <xref:System.Windows.Controls.DataErrorValidationRule>, you can set the <xref:System.Windows.Data.Binding.ValidatesOnDataErrors%2A> property to `true`.  
  
## See also
 <xref:System.Windows.Controls.ExceptionValidationRule>  
 [Implement Binding Validation](../../../../docs/framework/wpf/data/how-to-implement-binding-validation.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
