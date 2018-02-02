---
title: "How to: Create a Control That Has an Access Key and Text Wrapping"
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
  - "access keys [WPF], control for"
  - "controls [WPF], text wrapping"
  - "wrapping text [WPF]"
  - "keys [WPF], control for"
  - "controls [WPF], access keys"
  - "text wrapping [WPF]"
ms.assetid: 205099d9-2551-4302-a25e-a15af9f67e04
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Control That Has an Access Key and Text Wrapping
This example shows how to create a control that has an access key and supports text wrapping. The example uses a <xref:System.Windows.Controls.Label> control to illustrate these concepts.  
  
## Example  
 **Add Text Wrapping to Your Label**  
  
 The <xref:System.Windows.Controls.Label> control does not support text wrapping. If you need a label that wraps across multiple lines, you can nest another element that does support text wrapping and put the element inside the label. The following example shows how to use a <xref:System.Windows.Controls.TextBlock> to make a label that wraps several lines of text.  
  
 [!code-xaml[LabelSnippet#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LabelSnippet/CS/Pane1.xaml#5)]  
  
 **Add an Access Key and Text Wrapping to Your Label**  
  
 If you need a <xref:System.Windows.Controls.Label> that has an access key (mnemonic), use the <xref:System.Windows.Controls.AccessText> element that is inside the <xref:System.Windows.Controls.Label>.  
  
 Controls such as <xref:System.Windows.Controls.Label>, <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.RadioButton>, <xref:System.Windows.Controls.CheckBox>, <xref:System.Windows.Controls.MenuItem>, <xref:System.Windows.Controls.TabItem>, <xref:System.Windows.Controls.Expander>, and <xref:System.Windows.Controls.GroupBox> have default control templates. These templates contain a <xref:System.Windows.Controls.ContentPresenter>. One of the properties that you can set on the <xref:System.Windows.Controls.ContentPresenter> is <xref:System.Windows.Controls.ContentPresenter.RecognizesAccessKey%2A>="true", which you can use to specify an access key for the control.  
  
 The following example shows how to create a <xref:System.Windows.Controls.Label> that has an access key and supports text wrapping. To enable text wrapping, the example sets the <xref:System.Windows.Controls.AccessText.TextWrapping%2A> property and uses an underline character to specify the access key. (The character that immediately follows the underline character is the access key.)  
  
 [!code-xaml[LabelSnippet#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LabelSnippet/CS/Pane1.xaml#4)]  
  
## See Also  
 [How to: Set the Target Property of a Label](http://msdn.microsoft.com/library/b24c6977-ebcb-4855-a9bb-3fd4435af8f8)
