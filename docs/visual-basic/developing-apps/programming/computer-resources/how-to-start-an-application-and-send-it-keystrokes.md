---
title: "How to: Start an Application and Send it Keystrokes (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "keystrokes, sending"
  - "Shell command example [Visual Basic]"
  - "processes, starting and sending keystrokes"
  - "SendKeys.SendWait examples"
ms.assetid: f1303184-fce4-44fb-88b4-aac5f42d5d77
---
# How to: Start an Application and Send it Keystrokes (Visual Basic)
This example uses the `Shell` function to start the calculator application and then multiplies two numbers by sending keystrokes using the `My.Computer.Keyboard.SendKeys` method.  
  
## Example  
 [!code-vb[VbVbalrMyComputer#25](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-start-an-application-and-send-it-keystrokes_1.vb)]  
  
## Robust Programming  
 A <xref:System.ArgumentException> exception is raised if an application with the requested process identifier cannot be found.  
  
## .NET Framework Security  
 The call to the `Shell` function requires full trust (<xref:System.Security.SecurityException> class).  
  
## See also
- <xref:Microsoft.VisualBasic.Devices.Keyboard.SendKeys%2A>
- <xref:Microsoft.VisualBasic.Interaction.Shell%2A>
- <xref:Microsoft.VisualBasic.Interaction.AppActivate%2A>
