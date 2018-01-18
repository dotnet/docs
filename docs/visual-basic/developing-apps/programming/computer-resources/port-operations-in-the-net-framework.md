---
title: "Port Operations in the .NET Framework with Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "ports, Visual Basic"
ms.assetid: 1eba223b-7bd3-401a-b097-982bce96df1b
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Port Operations in the .NET Framework with Visual Basic
You can access your computer's serial ports through the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] classes in the <xref:System.IO.Ports?displayProperty=nameWithType> namespace. The most important class, <xref:System.IO.Ports.SerialPort>, provides a framework for synchronous and event-driven I/O, access to pin and break states, and access to serial driver properties. It can be wrapped in a <xref:System.IO.Stream> object, accessible through the <xref:System.IO.Ports.SerialPort.BaseStream> property. Wrapping <xref:System.IO.Ports.SerialPort> in a <xref:System.IO.Stream> object allows the serial port to be accessed by classes that use streams. The namespace includes enumerations that simplify the control of serial ports.  
  
 The simplest way to create a <xref:System.IO.Ports.SerialPort> object is through the <xref:Microsoft.VisualBasic.Devices.Ports.OpenSerialPort%2A> method.  
  
> [!NOTE]
>  You cannot use [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] classes to directly access other types of ports, such as parallel ports, USB ports, and so on.  
  
## Enumerations  
 This table lists and describes the main enumerations used for accessing a serial port:  
  
|Enumeration|Description|  
|---|---|   
|<xref:System.IO.Ports.Handshake>|Specifies the control protocol used in establishing a serial port communication for a <xref:System.IO.Ports.SerialPort> object.|  
|<xref:System.IO.Ports.Parity>|Specifies the parity bit for a <xref:System.IO.Ports.SerialPort> object.|  
|<xref:System.IO.Ports.SerialData>|Specifies the type of character that was received on the serial port of the <xref:System.IO.Ports.SerialPort> object.|  
|<xref:System.IO.Ports.SerialError>|Specifies errors that occur on the <xref:System.IO.Ports.SerialPort> object|  
|<xref:System.IO.Ports.SerialPinChange>|Specifies the type of change that occurred on the <xref:System.IO.Ports.SerialPort> object.|  
|<xref:System.IO.Ports.StopBits>|Specifies the number of stop bits used on the <xref:System.IO.Ports.SerialPort> object.|  
  
## See Also  
 <xref:Microsoft.VisualBasic.Devices.Ports>  
 [Accessing the Computer's Ports](../../../../visual-basic/developing-apps/programming/computer-resources/accessing-the-computer-s-ports.md)
