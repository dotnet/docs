---
title: "Invoke a Control Using UI Automation"
description: Use UI Automation to find a control matching certain property conditions, create an AutomationElement, get an InvokePattern, and use Invoke on the control.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "invoking controls"
  - "UI Automation, invoking controls"
  - "controls, invoking"
ms.topic: how-to
---
# Invoke a Control Using UI Automation

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic demonstrates how to perform the following tasks:

- Find a control that matches specific property conditions by walking the control view of the UI Automation tree for the target application.

- Create an <xref:System.Windows.Automation.AutomationElement> for each control.

- Obtain an <xref:System.Windows.Automation.InvokePattern> object from any UI Automation element found that supports the <xref:System.Windows.Automation.InvokePattern> control pattern.

- Use <xref:System.Windows.Automation.InvokePattern.Invoke%2A> to invoke the control from a client event handler.

## Example

 This example uses the <xref:System.Windows.Automation.AutomationElement.TryGetCurrentPattern%2A> method of the <xref:System.Windows.Automation.AutomationElement> class to generate an <xref:System.Windows.Automation.InvokePattern> object and invoke a control by using the <xref:System.Windows.Automation.InvokePattern.Invoke%2A> method.

 [!code-csharp[InvokePatternApp#1100](../../../samples/snippets/csharp/VS_Snippets_Wpf/InvokePatternApp/CSharp/InvokePatternApp.cs#1100)]
 [!code-vb[InvokePatternApp#1100](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/InvokePatternApp/VisualBasic/Client.vb#1100)]
[!code-csharp[InvokePatternApp#1102](../../../samples/snippets/csharp/VS_Snippets_Wpf/InvokePatternApp/CSharp/InvokePatternApp.cs#1102)]
[!code-vb[InvokePatternApp#1102](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/InvokePatternApp/VisualBasic/Client.vb#1102)]

## See also

- [InvokePattern, ExpandCollapsePattern, and TogglePattern Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Accessibility/InvokePattern)
