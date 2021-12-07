---
title: "How to read a text file one line at a time - C# Programming Guide"
description: Learn how to read a text file one line at a time. See a code example and view additional available resources.
ms.date: 07/20/2015
ms.topic: how-to
helpviewer_keywords: 
  - "ReadLine method [C#]"
  - "reading text files, line by line"
  - "text files [C#]"
ms.assetid: d62e22c5-a13c-48db-af9b-f10c801b0cb1
---
# How to read a text file one line at a time (C# Programming Guide)

This example reads the contents of a text file, one line at a time, into a string using the `ReadLines` method of the `File` class. Each text line is stored into the string `line` and displayed on the screen.  
  
## Example  
  
```csharp
int counter = 0;  
  
// Read the file and display it line by line.  
foreach (string line in System.IO.File.ReadLines(@"c:\test.txt"))
{  
    System.Console.WriteLine(line);  
    counter++;  
}  
  
System.Console.WriteLine("There were {0} lines.", counter);  
// Suspend the screen.  
System.Console.ReadLine();  
```  
  
## Compiling the Code  

 Copy the code and paste it into the `Main` method of a console application.  
  
 Replace `"c:\test.txt"` with the actual file name.  
  
## Robust Programming  

 The following conditions may cause an exception:  
  
- The file may not exist.  
  
## .NET Security  

 Do not make decisions about the contents of the file based on the name of the file. For example, the file `myFile.cs` may not be a C# source file.  
  
## See also

- <xref:System.IO?displayProperty=nameWithType>
- [C# Programming Guide](../index.md)
- [File System and the Registry (C# Programming Guide)](./index.md)
