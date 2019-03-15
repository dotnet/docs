---
title: "No mouse is present"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrMouse_NoMouseIsPresent"
ms.assetid: 4472fd57-4217-4463-9d3c-dc4a8fe88f1b
---
# No mouse is present
One of the properties of the `My.Computer.Mouse` object was called, but the computer has no mouse or mouse port installed.  
  
## To correct this error  
  
-   Add a `Try...Catch` block around the call to the property of the `My.Computer.Mouse` object.  
  
     — or —  
  
-   Install a mouse on the computer.  
  
## See also

- [My.Computer.Mouse](xref:Microsoft.VisualBasic.Devices.Mouse)
- [Handling and throwing exceptions in .NET](../../standard/exceptions/index.md)
- [Try...Catch...Finally Statement](../../visual-basic/language-reference/statements/try-catch-finally-statement.md)
