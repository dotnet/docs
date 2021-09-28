---
description: "Learn more about: Console apps in .NET"
title: "Create Console Applications in .NET"
ms.date: "03/30/2017"
helpviewer_keywords:
  - ".NET, creating console applications"
  - "application development [.NET], console"
  - "console applications"
ms.assetid: c21fb997-9f0e-40a5-8741-f73bba376bd8
---
# Console apps in .NET

.NET applications can use the <xref:System.Console?displayProperty=nameWithType> class to read characters from and write characters to the console. Data from the console is read from the standard input stream, data to the console is written to the standard output stream, and error data to the console is written to the standard error output stream. These streams are automatically associated with the console when the application starts and are presented as the <xref:System.Console.In%2A>, <xref:System.Console.Out%2A>, and <xref:System.Console.Error%2A> properties, respectively.

The value of the <xref:System.Console.In%2A?displayProperty=nameWithType> property is a <xref:System.IO.TextReader?displayProperty=nameWithType> object, whereas the values of the <xref:System.Console.Out%2A?displayProperty=nameWithType> and <xref:System.Console.Error%2A?displayProperty=nameWithType> properties are <xref:System.IO.TextWriter?displayProperty=nameWithType> objects. You can associate these properties with streams that do not represent the console, making it possible for you to point the stream to a different location for input or output. For example, you can redirect the output to a file by setting the <xref:System.Console.Out%2A?displayProperty=nameWithType> property to a <xref:System.IO.StreamWriter?displayProperty=nameWithType>, which encapsulates a <xref:System.IO.FileStream?displayProperty=nameWithType> by means of the <xref:System.Console.SetOut%2A?displayProperty=nameWithType> method. The <xref:System.Console.In%2A?displayProperty=nameWithType> and <xref:System.Console.Out%2A?displayProperty=nameWithType> properties do not need to refer to the same stream.

> [!NOTE]
> For more information about building console applications, including examples in C#, Visual Basic, and C++, see the documentation for the <xref:System.Console> class.

If the console does not exist, for example, in a Windows Forms application, output written to the standard output stream will not be visible, because there is no console to write the information to. Writing information to an inaccessible console does not cause an exception to be raised. (You can always change the application type to **Console Application**, for example, in the project property pages in Visual Studio).

The **System.Console** class has methods that can read individual characters or entire lines from the console. Other methods convert data and format strings, and then write the formatted strings to the console. For more information on formatting strings, see [Formatting types](base-types/formatting-types.md).

> [!TIP]
> Console applications lack a message pump that starts by default. Therefore, console calls to Microsoft Win32 timers might fail.

## See also

- <xref:System.Console?displayProperty=nameWithType>
- [Formatting Types](base-types/formatting-types.md)
