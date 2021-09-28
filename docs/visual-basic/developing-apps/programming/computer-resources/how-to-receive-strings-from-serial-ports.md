---
description: "Learn more about: How to: Receive Strings From Serial Ports in Visual Basic"
title: "How to: Receive Strings From Serial Ports"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "serial ports, retrieving strings"
  - "strings [Visual Basic], retrieving from serial ports"
  - "My.Resources object"
ms.assetid: 8371ce2c-e1c7-476b-a86d-9afc2614b6b7
---
# How to: Receive Strings From Serial Ports in Visual Basic

This topic describes how to use `My.Computer.Ports` to receive strings from the computer's serial ports in Visual Basic.  
  
### To receive strings from the serial port  
  
1. Initialize the return string.  
  
     [!code-vb[VbVbalrMyComputer#38](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#38)]  
  
2. Determine which serial port should provide the strings. This example assumes it is `COM1`.  
  
3. Use the `My.Computer.Ports.OpenSerialPort` method to obtain a reference to the port. For more information, see <xref:Microsoft.VisualBasic.Devices.Ports.OpenSerialPort%2A>.  
  
     The `Try...Catch...Finally` block allows the application to close the serial port even if it generates an exception. All code that manipulates the serial port should appear within this block.  
  
     [!code-vb[VbVbalrMyComputer#39](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#39)]  
  
4. Create a `Do` loop for reading lines of text until no more lines are available.  
  
     [!code-vb[VbVbalrMyComputer#40](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#40)]  
  
5. Use the <xref:System.IO.Ports.SerialPort.ReadLine> method to read the next available line of text from the serial port.  
  
     [!code-vb[VbVbalrMyComputer#41](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#41)]  
  
6. Use an `If` statement to determine if the <xref:System.IO.Ports.SerialPort.ReadLine> method returns `Nothing` (which means no more text is available). If it does return `Nothing`, exit the `Do` loop.  
  
     [!code-vb[VbVbalrMyComputer#42](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#42)]  
  
7. Add an `Else` block to the `If` statement to handle the case if the string is actually read. The block appends the string from the serial port to the return string.  
  
     [!code-vb[VbVbalrMyComputer#43](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#43)]  
  
8. Return the string.  
  
     [!code-vb[VbVbalrMyComputer#44](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#44)]  
  
## Example  

 [!code-vb[VbVbalrMyComputer#37](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyComputer/VB/Class2.vb#37)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Connectivity and Networking**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Compiling the Code  

 This example assumes the computer is using `COM1`.  
  
## Robust Programming  

 This example assumes the computer is using `COM1`. For more flexibility, the code should allow the user to select the desired serial port from a list of available ports. For more information, see [How to: Show Available Serial Ports](how-to-show-available-serial-ports.md).  
  
 This example uses a `Try...Catch...Finally` block to make sure that the application closes the port and to catch any timeout exceptions. For more information, see [Try...Catch...Finally Statement](../../../language-reference/statements/try-catch-finally-statement.md).  
  
## See also

- <xref:Microsoft.VisualBasic.Devices.Ports>
- <xref:System.IO.Ports.SerialPort?displayProperty=nameWithType>
- [How to: Dial Modems Attached to Serial Ports](how-to-dial-modems-attached-to-serial-ports.md)
- [How to: Send Strings to Serial Ports](how-to-send-strings-to-serial-ports.md)
- [How to: Show Available Serial Ports](how-to-show-available-serial-ports.md)
