---
description: "Learn more about: How to: Send Strings to Serial Ports in Visual Basic"
title: "How to: Send Strings to Serial Ports"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "ports, sending strings to"
  - "strings [Visual Basic], sending to serial ports"
  - "My.Computer.Ports object"
  - "serial ports, sending strings to"
ms.assetid: 6ebf46cd-b2d0-4b2c-9a1f-be177b22ad52
---
# How to: Send Strings to Serial Ports in Visual Basic

This topic describes how to use `My.Computer.Ports` to send strings to the computer's serial ports in Visual Basic.  
  
## Example  

 This example sends a string to the COM1 serial port. You may need to use a different serial port on your computer.  
  
 Use the `My.Computer.Ports.OpenSerialPort` method to obtain a reference to the port. For more information, see <xref:Microsoft.VisualBasic.Devices.Ports.OpenSerialPort%2A>.  
  
 The `Using` block allows the application to close the serial port even if it generates an exception. All code that manipulates the serial port should appear within this block or within a `Try...Catch...Finally` block.  
  
 The <xref:System.IO.Ports.SerialPort.WriteLine%2A> method sends the data to the serial port.  
  
 [!code-vb[VbVbalrMyComputer#33](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#33)]  
  
## Compiling the Code  
  
- This example assumes the computer is using `COM1`.  
  
## Robust Programming  

 This example assumes the computer is using `COM1`; for more flexibility, the code should allow the user to select the desired serial port from a list of available ports. For more information, see [How to: Show Available Serial Ports](how-to-show-available-serial-ports.md).  
  
 This example uses a `Using` block to make sure that the application closes the port even if it throws an exception. For more information, see [Using Statement](../../../language-reference/statements/using-statement.md).  
  
## See also

- <xref:Microsoft.VisualBasic.Devices.Ports>
- <xref:System.IO.Ports.SerialPort?displayProperty=nameWithType>
- [How to: Dial Modems Attached to Serial Ports](how-to-dial-modems-attached-to-serial-ports.md)
- [How to: Show Available Serial Ports](how-to-show-available-serial-ports.md)
