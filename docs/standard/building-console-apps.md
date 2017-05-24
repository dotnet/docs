---
title: "Building Console Applications in the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework, building console applications"
  - "application development [.NET Framework], console"
  - "console applications"
ms.assetid: c21fb997-9f0e-40a5-8741-f73bba376bd8
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Building Console Applications in the .NET Framework
Applications in the .NET Framework can use the <xref:System.Console?displayProperty=fullName> class to read characters from and write characters to the console. Data from the console is read from the standard input stream, data to the console is written to the standard output stream, and error data to the console is written to the standard error output stream. These streams are automatically associated with the console when the application starts and are presented as the <xref:System.Console.In%2A>, <xref:System.Console.Out%2A>, and <xref:System.Console.Error%2A> properties, respectively.  
  
 The value of the <xref:System.Console.In%2A?displayProperty=fullName> property is a <xref:System.IO.TextReader?displayProperty=fullName> object, whereas the values of the <xref:System.Console.Out%2A?displayProperty=fullName> and <xref:System.Console.Error%2A?displayProperty=fullName> properties are <xref:System.IO.TextWriter?displayProperty=fullName> objects. You can associate these properties with streams that do not represent the console, making it possible for you to point the stream to a different location for input or output. For example, you can redirect the output to a file by setting the <xref:System.Console.Out%2A?displayProperty=fullName> property to a <xref:System.IO.StreamWriter?displayProperty=fullName>, which encapsulates a <xref:System.IO.FileStream?displayProperty=fullName> by means of the <xref:System.Console.SetOut%2A?displayProperty=fullName> method. The <xref:System.Console.In%2A?displayProperty=fullName> and <xref:System.Console.Out%2A?displayProperty=fullName> properties do not need to refer to the same stream.  
  
> [!NOTE]
>  For more information about building console applications, including examples in C#, Visual Basic, and C++, see the documentation for the <xref:System.Console> class.  
  
 If the console does not exist, as in a Windows-based application, output written to the standard output stream will not be visible, because there is no console to write the information to. Writing information to an inaccessible console does not cause an exception to be raised.  
  
 Alternately, to enable the console for reading and writing within a Windows-based application that is developed using Visual Studio, open the project's **Properties** dialog box, click the **Application** tab, and set the **Application type** to **Console Application**.  
  
 Console applications lack a message pump that starts by default. Therefore, console calls to Microsoft Win32 timers might fail.  
  
 The **System.Console** class has methods that can read individual characters or entire lines from the console. Other methods convert data and format strings, and then write the formatted strings to the console. For more information on formatting strings, see [Formatting Types](../../docs/standard/base-types/formatting-types.md).  
  
## See Also  
 <xref:System.Console?displayProperty=fullName>   
 [Formatting Types](../../docs/standard/base-types/formatting-types.md)