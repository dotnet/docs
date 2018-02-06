---
title: "How to: Use Spell Checking with a Context Menu"
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
  - "enabling spell checking in a text box [WPF]"
  - "reenabling spell checking in a text box [WPF]"
  - "spell checking with a context menu [WPF]"
ms.assetid: 61f69a20-2ff3-4056-9060-e32f4483ec5e
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Spell Checking with a Context Menu
By default, when you enable spell checking in an editing control like <xref:System.Windows.Controls.TextBox> or <xref:System.Windows.Controls.RichTextBox>, you get spell-checking choices in the context menu. For example, when users right-click a misspelled word, they get a set of spelling suggestions or the option to **Ignore All**. However, when you override the default context menu with your own custom context menu, this functionality is lost, and you need to write code to reenable the spell-checking feature in the context menu. The following example shows how to enable this on a <xref:System.Windows.Controls.TextBox>.  
  
## Example  
 The following example shows the [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] that creates a <xref:System.Windows.Controls.TextBox> with some events that are used to implement the context menu.  
  
 [!code-xaml[TextBoxMiscSnippets_snip#SpellerCustomContextMenuExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/csharp/speller_custom_context_menu.xaml#spellercustomcontextmenuexamplewholepage)]  
  
## Example  
 The following example shows the code that implements the context menu.  
  
 [!code-csharp[TextBoxMiscSnippets_snip#SpellerCustomContextMenuCodeExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/csharp/speller_custom_context_menu.xaml.cs#spellercustomcontextmenucodeexamplewholepage)]
 [!code-vb[TextBoxMiscSnippets_snip#SpellerCustomContextMenuCodeExampleWholePage](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/visualbasic/speller_custom_context_menu.xaml.vb#spellercustomcontextmenucodeexamplewholepage)]  
  
 The code used for doing this with a <xref:System.Windows.Controls.RichTextBox> is similar. The main difference is in the parameter passed to the `GetSpellingError` method. For a <xref:System.Windows.Controls.TextBox>, pass the integer index of the caret position:  
  
 `spellingError = myTextBox.GetSpellingError(caretIndex);`  
  
 For a <xref:System.Windows.Controls.RichTextBox>, pass the <xref:System.Windows.Documents.TextPointer> that specifies the caret position:  
  
 `spellingError = myRichTextBox.GetSpellingError(myRichTextBox.CaretPosition);`  
  
## See Also  
 [TextBox Overview](../../../../docs/framework/wpf/controls/textbox-overview.md)  
 [RichTextBox Overview](../../../../docs/framework/wpf/controls/richtextbox-overview.md)  
 [Enable Spell Checking in a Text Editing Control](../../../../docs/framework/wpf/controls/how-to-enable-spell-checking-in-a-text-editing-control.md)  
 [Use a Custom Context Menu with a TextBox](../../../../docs/framework/wpf/controls/how-to-use-a-custom-context-menu-with-a-textbox.md)
