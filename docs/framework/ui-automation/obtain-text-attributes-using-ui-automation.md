---
title: "Obtain Text Attributes Using UI Automation"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "getting, text attributes"
  - "UI Automation, getting text attributes"
  - "text attributes, getting"
ms.assetid: fdefc6c3-b836-4cfe-8dec-1484bfdc5551
---
# Obtain Text Attributes Using UI Automation
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](https://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic shows how to use [!INCLUDE[TLA#tla_uiautomation](../../../includes/tlasharptla-uiautomation-md.md)] to obtain text attributes from a text range. A text range can correspond to the current location of the caret (or degenerate selection) within a document, a contiguous selection of text, a collection of disjoint text selections, or the entire textual content of a document.  
  
## Example  
 The following code example demonstrates how to obtain the <xref:System.Windows.Automation.TextPattern.FontNameAttribute> from a text range.  
  
 [!code-csharp[UIATextPattern_snip#StartTarget](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIATextPattern_snip/CSharp/SearchWindow.cs#starttarget)]
 [!code-vb[UIATextPattern_snip#StartTarget](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIATextPattern_snip/VisualBasic/SearchWindow.vb#starttarget)]  
[!code-csharp[UIATextPattern_snip#GetTextElement](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIATextPattern_snip/CSharp/SearchWindow.cs#gettextelement)]
[!code-vb[UIATextPattern_snip#GetTextElement](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIATextPattern_snip/VisualBasic/SearchWindow.vb#gettextelement)]  
[!code-csharp[UIATextPattern_snip#FontName](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIATextPattern_snip/CSharp/SearchWindow.cs#fontname)]
[!code-vb[UIATextPattern_snip#FontName](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIATextPattern_snip/VisualBasic/SearchWindow.vb#fontname)]  
  
 The <xref:System.Windows.Automation.TextPattern> control pattern, in tandem with the <xref:System.Windows.Automation.Text.TextPatternRange> class, supports basic text attributes, properties, and methods. For control-specific functionality that is not supported by <xref:System.Windows.Automation.TextPattern> or <xref:System.Windows.Automation.Text.TextPatternRange> the <xref:System.Windows.Automation.AutomationElement>, class provides methods for a UI Automation client to access the corresponding native object model.  
  
## See also

- [UI Automation TextPattern Overview](ui-automation-textpattern-overview.md)
- [Add Content to a Text Box Using UI Automation](add-content-to-a-text-box-using-ui-automation.md)
- [Find and Highlight Text Using UI Automation](find-and-highlight-text-using-ui-automation.md)
- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [Obtain Mixed Text Attribute Details Using UI Automation](obtain-mixed-text-attribute-details-using-ui-automation.md)
