---
title: "How to: Handle User Input Events in Windows Forms Controls"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "Windows Forms controls, user input"
  - "user input [Windows Forms], Windows Forms controls"
ms.assetid: 3de74dcf-fae3-42d0-92b5-bc04a61a6888
---
# How to: Handle User Input Events in Windows Forms Controls
This example demonstrates how to handle most keyboard, mouse, focus, and validation events that can occur in a Windows Forms control. The text box named `TextBoxInput` receives the events when it has focus, and information about each event is written in the text box named `TextBoxOutput` in the order in which the events are raised. The application also includes a set of check boxes that can be used to filter which events to report.  
  
## Example  
 [!code-cpp[System.Windows.Forms.UserInputWalkthrough#0](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.UserInputWalkthrough/cpp/form1.cpp#0)]
 [!code-csharp[System.Windows.Forms.UserInputWalkthrough#0](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.UserInputWalkthrough/CS/form1.cs#0)]
 [!code-vb[System.Windows.Forms.UserInputWalkthrough#0](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.UserInputWalkthrough/VB/form1.vb#0)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- [User Input in Windows Forms](user-input-in-windows-forms.md)
