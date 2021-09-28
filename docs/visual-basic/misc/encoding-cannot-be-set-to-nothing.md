---
description: "Learn more about: Encoding cannot be set to Nothing"
title: "Encoding cannot be set to Nothing"
ms.date: 07/20/2015
ms.assetid: 59f7c731-8291-4a85-bf51-c225e48cdc84
---
# Encoding cannot be set to Nothing

An attempt to read from or write to a file has failed because the parameter `encoding` has been set to `Nothing` but requires a valid value.  
  
 <xref:System.Text.Encoding> is used to determine what encoding to use when writing to a file. The default is UTF-8.  
  
## To correct this error  
  
- Supply a valid value for the `encoding` parameter.  
  
## See also

- [File Encodings](../developing-apps/programming/drives-directories-files/file-encodings.md)
- [Reading from Files](../developing-apps/programming/drives-directories-files/reading-from-files.md)
- [Writing to Files](../developing-apps/programming/drives-directories-files/writing-to-files.md)
- [My.Computer.FileSystem.ReadAllText](xref:Microsoft.VisualBasic.FileIO.FileSystem.ReadAllText%2A)
- [My.Computer.FileSystem.WriteAllText](xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A)
