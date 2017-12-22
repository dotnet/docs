---
title: "How to: Get the Binding Object from a Bound Target Property"
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
  - "data binding [WPF], getting binding objects from bound target properties"
  - "properties [WPF], getting binding objects from"
ms.assetid: 87974c5f-136b-4de7-b07d-9285b62ab123
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Get the Binding Object from a Bound Target Property
This example shows how to obtain the binding object from a data-bound target property.  
  
## Example  
 You can do the following to get the <xref:System.Windows.Data.Binding> object:  
  
 [!code-csharp[BindValidation#GetBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BindValidation/CSharp/Window1.xaml.cs#getbinding)]  
  
> [!NOTE]
>  You must specify the dependency property for the binding you want because it is possible that more than one property of the target object is using data binding.  
  
 Alternatively, you can get the <xref:System.Windows.Data.BindingExpression> and then get the value of the <xref:System.Windows.Data.BindingExpression.ParentBinding%2A> property.  
  
 For the complete example see [Binding Validation Sample](http://go.microsoft.com/fwlink/?LinkID=159972).  
  
> [!NOTE]
>  If your binding is a <xref:System.Windows.Data.MultiBinding>, use <xref:System.Windows.Data.BindingOperations>.<xref:System.Windows.Data.BindingOperations.GetMultiBinding%2A>. If it is a <xref:System.Windows.Data.PriorityBinding>, use <xref:System.Windows.Data.BindingOperations>.<xref:System.Windows.Data.BindingOperations.GetPriorityBinding%2A>. If you are uncertain whether the target property is bound using a <xref:System.Windows.Data.Binding>, a <xref:System.Windows.Data.MultiBinding>, or a <xref:System.Windows.Data.PriorityBinding>, you can use <xref:System.Windows.Data.BindingOperations>.<xref:System.Windows.Data.BindingOperations.GetBindingBase%2A>.  
  
## See Also  
 [Create a Binding in Code](../../../../docs/framework/wpf/data/how-to-create-a-binding-in-code.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
