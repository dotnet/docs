---
title: "How to: Show Available Serial Ports in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "serial ports, availability"
  - "My.Computer.Ports.SerialPortNames property"
  - "My.Computer.Ports object"
  - "ports, serial port availability"
ms.assetid: eaf2ee5a-8103-4e10-a205-ed1d4db120ba
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Show Available Serial Ports in Visual Basic
This topic describes how to use `My.Computer.Ports` to show the available serial ports of the computer in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
 To allow a user to select which port to use, the names of the serial ports are placed in a <xref:System.Windows.Forms.ListBox> control.  
  
## Example  
 This example loops over all the strings that the `My.Computer.Ports.SerialPortNames` property returns. These strings are the names of the available serial ports on the computer.  
  
 Typically, a user selects which serial port the application should use from the list of available ports. In this example, the serial port names are stored in a <xref:System.Windows.Forms.ListBox> control. For more information, see [ListBox Control](../../../../framework/winforms/controls/listbox-control-windows-forms.md).  
  
 [!code-vb[VbVbalrMyComputer#45](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-show-available-serial-ports_1.vb)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Connectivity and Networking**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Compiling the Code  
 This example requires:  
  
-   A project reference to System.Windows.Forms.dll.  
  
-   Access to the members of the <xref:System.Windows.Forms> namespace. Add an `Imports` statement if you are not fully qualifying member names in your code. For more information, see [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md).  
  
-   That your form have a <xref:System.Windows.Forms.ListBox> control named `ListBox1`.  
  
## Robust Programming  
 You do not have to use the <xref:System.Windows.Forms.ListBox> control to display the available serial port names. Instead, you can use a <xref:System.Windows.Forms.ComboBox> or other control. If the application does not need a response from the user, you can use a <xref:System.Windows.Forms.TextBox> control to display the information.  
  
> [!NOTE]
>  The port names returned by `My.Computer.Ports.SerialPortNames` may be incorrect when run on Windows 98. To prevent application errors, use exception handling, such as the `Try...Catch...Finally` statement or the `Using` statement, when using the port names to open ports.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Devices.Ports>  
 [How to: Dial Modems Attached to Serial Ports](../../../../visual-basic/developing-apps/programming/computer-resources/how-to-dial-modems-attached-to-serial-ports.md)  
 [How to: Send Strings to Serial Ports](../../../../visual-basic/developing-apps/programming/computer-resources/how-to-send-strings-to-serial-ports.md)  
 [How to: Receive Strings From Serial Ports](../../../../visual-basic/developing-apps/programming/computer-resources/how-to-receive-strings-from-serial-ports.md)
