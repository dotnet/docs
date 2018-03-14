---
title: "How to: Create a Simple Binding"
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
  - "simple binding [WPF], creating"
  - "data binding [WPF], creating simple bindings"
  - "binding data [WPF], creating"
ms.assetid: 69b80f72-6259-44cb-8294-5bdcebca1e08
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Simple Binding
This example shows you how to create a simple <xref:System.Windows.Data.Binding>.  
  
## Example  
 In this example, you have a `Person` object with a string property named `PersonName`. The `Person` object is defined in the namespace called `SDKSample`.  
  
 The highlighted line that contains the `<src>` element in the following example instantiates the `Person` object with a `PersonName` property value of `Joe`. This is done in the `Resources` section and assigned an `x:Key`.  
  
 [!code-xaml[SimpleBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SimpleBinding/CSharp/Page1.xaml?highlight=9,37)]  
  
 The highlighted line that contains the `<TextBlock>` element then binds the <xref:System.Windows.Controls.TextBlock> control to the `PersonName` property. As a result, the <xref:System.Windows.Controls.TextBlock> appears with the value "Joe".  
  
## See Also  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
