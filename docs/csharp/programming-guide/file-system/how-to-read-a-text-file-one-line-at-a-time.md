---
title: "How to: Read a Text File One Line at a Time (Visual C#)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "ReadLine method [C#]"
  - "reading text files, line by line"
  - "text files [C#]"
ms.assetid: d62e22c5-a13c-48db-af9b-f10c801b0cb1
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Read a Text File One Line at a Time (Visual C#)
This example reads the contents of a text file, one line at a time, into a string using the `ReadLine` method of the `StreamReader` class. Each text line is stored into the string `line` and displayed on the screen.  
  
## Example  
  
```  
int counter = 0;  
string line;  
  
// Read the file and display it line by line.  
System.IO.StreamReader file =   
    new System.IO.StreamReader(@"c:\test.txt");  
while((line = file.ReadLine()) != null)  
{  
    System.Console.WriteLine (line);  
    counter++;  
}  
  
file.Close();  
System.Console.WriteLine("There were {0} lines.", counter);  
// Suspend the screen.  
System.Console.ReadLine();  
```  
  
## Compiling the Code  
 Copy the code and paste it into the `Main` method of a console application.  
  
 Replace `"c:\test.txt"` with the actual file name.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The file may not exist.  
  
## .NET Framework Security  
 Do not make decisions about the contents of the file based on the name of the file. For example, the file `myFile.cs` may not be a C# source file.  
  
## See Also  
 <xref:System.IO?displayProperty=nameWithType>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [File System and the Registry (C# Programming Guide)](../../../csharp/programming-guide/file-system/index.md)
