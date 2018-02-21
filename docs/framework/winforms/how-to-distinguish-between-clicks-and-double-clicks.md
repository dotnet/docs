---
title: "How to: Distinguish Between Clicks and Double-Clicks"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "mouse [Windows Forms], click"
  - "mouse [Windows Forms], double-click"
  - "mouse clicks [Windows Forms], single versus double"
ms.assetid: d836ac8c-85bc-4f3a-a761-8aee03dc682c
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Distinguish Between Clicks and Double-Clicks
Typically, a single *click* initiates a user interface (UI) action and a *double-click* extends the action. For example, one click usually selects an item, and a double-click edits the selected item. However, the Windows Forms click events do not easily accommodate a scenario where a click and a double-click perform incompatible actions, because an action tied to the <xref:System.Windows.Forms.Control.Click> or <xref:System.Windows.Forms.Control.MouseClick> event is performed before the action tied to the <xref:System.Windows.Forms.Control.DoubleClick> or <xref:System.Windows.Forms.Control.MouseDoubleClick> event. This topic demonstrates two solutions to this problem. One solution is to handle the double-click event and roll back the actions in the handling of the click event. In rare situations you may need to simulate click and double-click behavior by handling the <xref:System.Windows.Forms.Control.MouseDown> event and by using the <xref:System.Windows.Forms.SystemInformation.DoubleClickTime%2A> and <xref:System.Windows.Forms.SystemInformation.DoubleClickSize%2A> properties of the <xref:System.Windows.Forms.SystemInformation> class. You measure the time between clicks and if a second click occurs before the value of <xref:System.Windows.Forms.SystemInformation.DoubleClickTime%2A> is reached and the click is within a rectangle defined by <xref:System.Windows.Forms.SystemInformation.DoubleClickSize%2A>, perform the double-click action; otherwise, perform the click action.  
  
### To roll back a click action  
  
-   Ensure that the control you are working with has standard double-click behavior. If not, enable the control with the <xref:System.Windows.Forms.Control.SetStyle%2A> method. Handle the double-click event and roll back the click action as well as the double-click action. The following code example demonstrates a how to create a custom button with double-click enabled, as well as how to roll back the click action in the double-click event handling code.  
  
     [!code-csharp[System.Windows.Forms.ButtonDoubleClick#1](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ButtonDoubleClick/CS/Form1.cs#1)]
     [!code-vb[System.Windows.Forms.ButtonDoubleClick#1](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ButtonDoubleClick/VB/Form1.vb#1)]  
  
### To distinguish between clicks in the MouseDown event  
  
-   Handle the <xref:System.Windows.Forms.Control.MouseDown> event and determine the location and time span between clicks using the appropriate <xref:System.Windows.Forms.SystemInformation> properties and a <xref:System.Windows.Forms.Timer> component. Perform the appropriate action depending on whether a click or double-click takes place. The following code example demonstrates how this can be done.  
  
     [!code-cpp[System.Windows.Forms.SingleVersusDoubleClick#0](../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.SingleVersusDoubleClick/cpp/form1.cpp#0)]
     [!code-csharp[System.Windows.Forms.SingleVersusDoubleClick#0](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.SingleVersusDoubleClick/CS/form1.cs#0)]
     [!code-vb[System.Windows.Forms.SingleVersusDoubleClick#0](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.SingleVersusDoubleClick/VB/form1.vb#0)]  
  
## Compiling the Code  
 These examples require:  
  
-   References to the System, System.Drawing, and System.Windows.Forms assemblies.  
  
 For information about building these examples from the command line for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build these examples in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] by pasting the code into new projects.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)
