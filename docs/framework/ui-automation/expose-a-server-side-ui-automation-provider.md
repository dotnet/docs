---
title: "Expose a Server-side UI Automation Provider"
description: View an example that shows how to expose a server-side UI Automation provider that's hosted in a System.Windows.Forms.Control window.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "expose a server-side UI Automation provider"
  - "UI Automation, server-side provider, exposing"
  - "server-side UI Automation provider, exposing"
ms.topic: how-to
---
# Expose a Server-side UI Automation Provider

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic contains example code that shows how to expose a server-side UI Automation provider that is hosted in a <xref:System.Windows.Forms.Control?displayProperty=nameWithType> window.

 The example overrides the window procedure to trap WM_GETOBJECT, which is the message sent by the UI Automation core service when a client application requests information about the window.

## Example

 [!code-csharp[UIAFragmentProvider_snip#116](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAFragmentProvider_snip/CSharp/ListFragment.cs#116)]
 [!code-vb[UIAFragmentProvider_snip#116](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAFragmentProvider_snip/VisualBasic/ListFragment.vb#116)]

## See also

- [UI Automation Providers Overview](ui-automation-providers-overview.md)
- [Server-Side UI Automation Provider Implementation](server-side-ui-automation-provider-implementation.md)
