---
title: "Change Selection in a RichTextBox Programmatically"
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
  - "changing selections in a text box [WPF]"
  - "changing selections in a RichTextBox [WPF]"
ms.assetid: f1213205-1ad7-4cd2-b115-460173cc5aa3
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Change Selection in a RichTextBox Programmatically
This example shows how to programmatically change the current selection in a <xref:System.Windows.Controls.RichTextBox>. This selection is the same as if the user had selected the content by using the user interface.  
  
## Example  
 The following [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] code describes a named <xref:System.Windows.Controls.RichTextBox> control with simple content.  
  
 [!code-xaml[RichTextBoxMiscSnippets_snip#ChangeSelectionProgrammaticalyExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RichTextBoxMiscSnippets_snip/CSharp/ChangeSelectionProgrammaticaly.xaml#changeselectionprogrammaticalyexamplewholepage)]  
  
## Example  
 The following code programmatically selects some arbitrary text when the user clicks inside the <xref:System.Windows.Controls.RichTextBox>.  
  
 [!code-csharp[RichTextBoxMiscSnippets_snip#ChangeSelectionProgrammaticalyCodeExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RichTextBoxMiscSnippets_snip/CSharp/ChangeSelectionProgrammaticaly.xaml.cs#changeselectionprogrammaticalycodeexamplewholepage)]
 [!code-vb[RichTextBoxMiscSnippets_snip#ChangeSelectionProgrammaticalyCodeExampleWholePage](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/RichTextBoxMiscSnippets_snip/VisualBasic/ChangeSelectionProgrammaticaly.xaml.vb#changeselectionprogrammaticalycodeexamplewholepage)]  
  
## See Also  
 [RichTextBox Overview](../../../../docs/framework/wpf/controls/richtextbox-overview.md)  
 [TextBox Overview](../../../../docs/framework/wpf/controls/textbox-overview.md)
