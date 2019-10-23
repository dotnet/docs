---
title: "How to: Start an Application and Send it Keystrokes - Visual Basic"
ms.date: 10/23/2019
helpviewer_keywords: 
  - "keystrokes, sending"
  - "Shell command example [Visual Basic]"
  - "processes, starting and sending keystrokes"
  - "SendKeys.SendWait examples"
ms.assetid: f1303184-fce4-44fb-88b4-aac5f42d5d77
---
# How to: Start an Application and Send it Keystrokes (Visual Basic)

This example uses the `Shell` function to start the Notepad application and then prints a sentence by sending keystrokes using the `My.Computer.Keyboard.SendKeys` method.

## Example

[!code-vb[VbVbalrMyComputer#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#25)]

## Robust Programming

A <xref:System.ArgumentException> exception is raised if an application with the requested process identifier cannot be found.  
  
## .NET Framework Security

The call to the `Shell` function requires full trust (<xref:System.Security.SecurityException> class).

## See also

- <xref:Microsoft.VisualBasic.Devices.Keyboard.SendKeys%2A>
- <xref:Microsoft.VisualBasic.Interaction.Shell%2A>
- <xref:Microsoft.VisualBasic.Interaction.AppActivate%2A>
