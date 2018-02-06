---
title: "How to: Produce a Value Based on a List of Bound Items"
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
  - "data binding [WPF], MultiBinding"
  - "Multibinding [WPF]"
ms.assetid: b3d06378-b511-4181-95aa-316d60c9229b
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Produce a Value Based on a List of Bound Items
<xref:System.Windows.Data.MultiBinding> allows you to bind a binding target property to a list of source properties and then apply logic to produce a value with the given inputs. This example demonstrates how to use <xref:System.Windows.Data.MultiBinding>.  
  
## Example  
 In the following example, `NameListData` refers to a collection of `PersonName` objects, which are objects that contain two properties, `firstName` and `lastName`. The following example produces a <xref:System.Windows.Controls.TextBlock> that shows the first and last names of a person with the last name first.  
  
 [!code-xaml[MultiBinding#Resources1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MultiBinding/CSharp/Window1.xaml#resources1)]  
[!code-xaml[MultiBinding#Resources2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MultiBinding/CSharp/Window1.xaml#resources2)]  
[!code-xaml[MultiBinding#MultiBindingTextBox2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MultiBinding/CSharp/Window1.xaml#multibindingtextbox2)]  
[!code-xaml[MultiBinding#Window](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MultiBinding/CSharp/Window1.xaml#window)]  
  
 To understand how the last-name-first format is produced, let's take a look at the implementation of the `NameConverter`:  
  
 [!code-csharp[MultiBinding#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MultiBinding/CSharp/NameConverter.cs#3)]
 [!code-vb[MultiBinding#3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/MultiBinding/VisualBasic/NameConverter.vb#3)]  
  
 `NameConverter` implements the <xref:System.Windows.Data.IMultiValueConverter> interface. `NameConverter` takes the values from the individual bindings and stores them in the values object array. The order in which the <xref:System.Windows.Data.Binding> elements appear under the <xref:System.Windows.Data.MultiBinding> element is the order in which those values are stored in the array. The value of the <xref:System.Windows.Data.MultiBinding.ConverterParameter%2A> attribute is referenced by the parameter argument of the <xref:System.Windows.Data.MultiBinding.Converter%2A> method, which performs a switch on the parameter to determine how to format the name.  
  
## See Also  
 [Convert Bound Data](../../../../docs/framework/wpf/data/how-to-convert-bound-data.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
