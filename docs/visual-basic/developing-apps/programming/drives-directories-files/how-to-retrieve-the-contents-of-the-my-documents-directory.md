---
title: "How to: Retrieve the Contents of the My Documents Directory in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "My Documents directory"
ms.assetid: 26560d01-7dda-4457-8e95-21db23d71aea
---
# How to: Retrieve the Contents of the My Documents Directory in Visual Basic
The <xref:Microsoft.VisualBasic.FileIO.SpecialDirectories> object can be used to read from many of the **All Users** directories, such as **My Documents** or **Desktop**.  
  
### To read from the My Documents folder  
  
-   Use the `ReadAllText` method to read the text from each file in a specific directory. The following code specifies a directory and file and then uses `ReadAllText` to read them into the string named `patients`.  
  
     [!code-vb[VbVbcnMyFileSystem#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#15)]  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.SpecialDirectories>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem.ReadAllText%2A>
