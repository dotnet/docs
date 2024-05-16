---
description: "Learn more about: How to: Show Available Serial Ports in Visual Basic"
title: "How to: Show Available Serial Ports"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "serial ports, availability"
  - "My.Computer.Ports.SerialPortNames property"
  - "My.Computer.Ports object"
  - "ports, serial port availability"
ms.assetid: eaf2ee5a-8103-4e10-a205-ed1d4db120ba
---
# How to: Show Available Serial Ports in Visual Basic

This topic describes how to use `My.Computer.Ports` to show the available serial ports of the computer in Visual Basic.  
  
 To allow a user to select which port to use, the names of the serial ports are placed in a <xref:System.Windows.Forms.ListBox> control.  
  
## Example  

 This example loops over all the strings that the `My.Computer.Ports.SerialPortNames` property returns. These strings are the names of the available serial ports on the computer.  
  
 Typically, a user selects which serial port the application should use from the list of available ports. In this example, the serial port names are stored in a <xref:System.Windows.Forms.ListBox> control. For more information, see [ListBox Control](/dotnet/desktop/winforms/controls/listbox-control-windows-forms).  
  
 [!code-vb[VbVbalrMyComputer#45](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#45)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Connectivity and Networking**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Compiling the Code  

 This example requires:  
  
- A project reference to System.Windows.Forms.dll.  
  
- Access to the members of the <xref:System.Windows.Forms> namespace. Add an `Imports` statement if you are not fully qualifying member names in your code. For more information, see [Imports Statement (.NET Namespace and Type)](../../../language-reference/statements/imports-statement-net-namespace-and-type.md).  
  
- That your form have a <xref:System.Windows.Forms.ListBox> control named `ListBox1`.  
  
## Robust Programming  

 You do not have to use the <xref:System.Windows.Forms.ListBox> control to display the available serial port names. Instead, you can use a <xref:System.Windows.Forms.ComboBox> or other control. If the application does not need a response from the user, you can use a <xref:System.Windows.Forms.TextBox> control to display the information.
  
## See also

- <xref:Microsoft.VisualBasic.Devices.Ports>
- [How to: Dial Modems Attached to Serial Ports](how-to-dial-modems-attached-to-serial-ports.md)
- [How to: Send Strings to Serial Ports](how-to-send-strings-to-serial-ports.md)
- [How to: Receive Strings From Serial Ports](how-to-receive-strings-from-serial-ports.md)
