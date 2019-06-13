---
title: "Passing a URI to the Windows Runtime"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Windows Runtime, .NET Framework support for"
  - "Windows Runtime, passing a URI to"
ms.assetid: 3eb5ce6f-f304-4f87-8e81-0f25092f5ad4
author: "mairaw"
ms.author: "mairaw"
---
# Passing a URI to the Windows Runtime
Windows Runtime methods accept only absolute URIs. If you pass a relative URI to a Windows Runtime method, an <xref:System.ArgumentException> exception is thrown. Here's why: When you use the Windows Runtime in .NET Framework code, the <xref:Windows.Foundation.Uri?displayProperty=nameWithType> class appears as <xref:System.Uri?displayProperty=nameWithType> in Intellisense. The <xref:System.Uri?displayProperty=nameWithType> class allows relative URIs, but the <xref:Windows.Foundation.Uri?displayProperty=nameWithType> class does not. This is also true for methods you expose in Windows Runtime Components. If your component exposes a method that takes a URI, the signature in your code includes <xref:System.Uri?displayProperty=nameWithType>. However, to users of your component, the signature includes <xref:Windows.Foundation.Uri?displayProperty=nameWithType>. A URI that is passed to your component must be an absolute URI.  
  
This topic shows how to detect an absolute URI and how to create one when referring to a resource in the app package.  
  
## Detecting and using an absolute URI  
Use the <xref:System.Uri.IsAbsoluteUri%2A?displayProperty=nameWithType> property to ensure that a URI is absolute before passing it to the Windows Runtime. Using this property is more efficient than catching and handling the <xref:System.ArgumentException> exception.  
  
## Using an absolute URI for a resource in the app package  
If you want to specify a URI for a resource that your app package contains, you can use the `ms-appx` or `ms-appx-web` scheme to create an absolute URI.  
  
The following example shows how to set the <xref:Windows.UI.Xaml.Controls.WebView.Source%2A> property for a <xref:Windows.UI.Xaml.Controls.WebView> control and the <xref:Windows.UI.Xaml.Controls.Image.Source%2A> property for an <xref:Windows.UI.Xaml.Controls.Image> control to resources that are contained in a folder named Pages, using both XAML and code.  
  
[!code-xaml[System.URIToWindowsURI#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.uritowindowsuri/cs/mainpage.xaml#1)]  
[!code-csharp[System.URIToWindowsURI#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.uritowindowsuri/cs/mainpage.xaml.cs#2)]
[!code-vb[System.URIToWindowsURI#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.uritowindowsuri/vb/mainpage.xaml.vb#2)]  
  
For more information about these schemes, see [URI schemes](/windows/uwp/app-resources/uri-schemes) in the Windows Dev Center.  
  
## See also

- [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md)
