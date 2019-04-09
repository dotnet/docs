---
title: "How to: Add Web Browser Capabilities to a Windows Forms Application"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "WebBrowser control [Windows Forms], adding Web browser capabilities to your application"
  - "WebBrowser control [Windows Forms], examples"
  - "Web browsers [.NET Framework], adding to Windows Forms"
  - "examples [Windows Forms], WebBrowser control"
  - "Windows Forms, adding Web browser functionality"
ms.assetid: 3871f072-b57a-435b-9976-e5da28df04a7
---
# How to: Add Web Browser Capabilities to a Windows Forms Application
With the <xref:System.Windows.Forms.WebBrowser> control, you can add Web browser functionality to your application. The control works like a Web browser by default. After you load an initial URL by setting the <xref:System.Windows.Forms.WebBrowser.Url%2A> property, you can navigate by clicking hyperlinks or by using keyboard shortcuts to move backward and forward through navigation history. By default, you can access additional browser functionality through the right-click shortcut menu. You can also open new documents by dropping them onto the control. The <xref:System.Windows.Forms.WebBrowser> control also has several properties, methods, and events that you can use to implement user interface features similar to those found in Internet Explorer.  
  
 The following code example implements an address bar, typical browser buttons, a **File** menu, a status bar, and a title bar that displays the current page title.  
  
## Example  
 [!code-cpp[System.Windows.Forms.WebBrowser#0](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.WebBrowser/CPP/form1.cpp#0)]
 [!code-csharp[System.Windows.Forms.WebBrowser#0](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.WebBrowser/CS/form1.cs#0)]
 [!code-vb[System.Windows.Forms.WebBrowser#0](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.WebBrowser/VB/form1.vb#0)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the `System`, `System.Drawing`, and `System.Windows.Forms` assemblies.  
  
 For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## See also

- <xref:System.Windows.Forms.WebBrowser>
- [WebBrowser Control](webbrowser-control-windows-forms.md)
