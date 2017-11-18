---
title: "How to: Provide a Progress Dialog Box for File Operations (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "progress dialog [C#]"
ms.assetid: 01b71fe7-8178-4dc8-aeb1-12053be7b51c
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Provide a Progress Dialog Box for File Operations (C# Programming Guide)
You can provide a standard dialog box that shows progress on file operations in Windows if you use the <xref:Microsoft.VisualBasic.FileIO.FileSystem.CopyFile%28System.String%2CSystem.String%2CMicrosoft.VisualBasic.FileIO.UIOption%29> method in the <xref:Microsoft.VisualBasic?displayProperty=nameWithType> namespace.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To add a reference in Visual Studio  
  
1.  On the menu bar, choose **Project**, **Add Reference**.  
  
     The **Reference Manager** dialog box appears.  
  
2.  In the **Assemblies** area, choose**Framework** if it isn’t already chosen.  
  
3.  In the list of names, select the **Microsoft.VisualBasic** check box, and then choose the **OK** button to close the dialog box.  
  
## Example  
 The following code copies the directory that `sourcePath` specifies into the directory that `destinationPath` specifies. This code also provides a standard dialog box that shows the estimated amount of time remaining before the operation finishes.  
  
 [!code-csharp[csFilesandFolders#11](../../../csharp/programming-guide/file-system/codesnippet/CSharp/how-to-provide-a-progress-dialog-box-for-file-operations_1.cs)]  
  
## See Also  
 [File System and the Registry (C# Programming Guide)](../../../csharp/programming-guide/file-system/index.md)
