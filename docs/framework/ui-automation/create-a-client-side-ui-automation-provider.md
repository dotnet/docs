---
title: "Create a Client-Side UI Automation Provider"
description: View an example of how to create a client-side UI Automation provider. The example implements a simple client-side provider for a console window.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "UI Automation, creating client-side provider"
  - "client-side UI Automation provider, creating"
ms.assetid: d91edaf2-be28-41ec-a508-af421cb43c3d
---
# Create a Client-Side UI Automation Provider

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic contains example code that shows how to implement a client-side UI Automation provider.

## Example

 The following example code can be built into a dynamic-link library (DLL) that implements a very simple client-side provider for a console window. The code does not have any useful functionality, but is intended to demonstrate the basic steps in setting up a provider assembly that can be registered by a UI Automation client application.

 [!code-csharp[UIAClientSideProvider_snip#101](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIAClientSideProvider_snip/CSharp/CSProviderProgram.cs#101)]
 [!code-vb[UIAClientSideProvider_snip#101](../../../samples/snippets/visualbasic/VS_Snippets_Wpf/UIAClientSideProvider_snip/visualbasic/csproviderprogram.vb#101)]

## See also

- [UI Automation Providers Overview](ui-automation-providers-overview.md)
- [Register a Client-Side Provider Assembly](register-a-client-side-provider-assembly.md)
