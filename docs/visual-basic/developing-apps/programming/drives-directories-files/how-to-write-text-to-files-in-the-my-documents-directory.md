---
title: "How to: Write Text to Files in the My Documents Directory in Visual Basic"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "files [Visual Basic], writing to"
  - "text, writing to files"
  - "examples [Visual Basic], text files"
  - "writing to files [Visual Basic], in My Documents"
ms.assetid: 1c726124-781d-4976-9baa-ed46814ff3fe
---
# How to: Write Text to Files in the My Documents Directory in Visual Basic

The `My.Computer.FileSystem.SpecialDirectories` object allows you to access special directories, such as the **MyDocuments** directory.  
  
## Procedure  
  
#### To write new text files in the My Documents directory  
  
1. Use the `My.Computer.FileSystem.SpecialDirectories.MyDocuments` property to supply the path.  
  
     [!code-vb[VbFileIOWrite#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOWrite/VB/Class1.vb#1)]  
  
2. Use the `WriteAllText` method to write text to the specified file.  
  
     [!code-vb[VbVbcnMyFileSystem#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#14)]  
  
## Example  

 [!code-vb[VbFileIOWrite#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOWrite/VB/Class1.vb#2)]  
  
## Compiling the Code  

 Replace `test.txt` with the name of the file you want to write to.  
  
## Robust Programming  

 This code rethrows all the exceptions that may occur when writing text to the file. You can reduce the likelihood of exceptions by using Windows Forms controls such as the [OpenFileDialog](../../../../framework/winforms/controls/openfiledialog-component-windows-forms.md) and the [SaveFileDialog](../../../../framework/winforms/controls/savefiledialog-component-windows-forms.md) components that limit the user choices to valid file names. Using these controls is not foolproof, however. The file system can change between the time the user selects a file and the time that the code executes. Exception handling is therefore nearly always necessary when with working with files.  
  
## .NET Framework Security  

 If you are running in a partial-trust context, the code might throw an exception due to insufficient privileges. For more information, see [Code Access Security Basics](../../../../framework/misc/code-access-security-basics.md).  
  
 This example creates a new file. If an application needs to create a file, that application needs Create permission for the folder. Permissions are set using access control lists. If the file already exists, the application needs only Write permission, a lesser privilege. Where possible, it is more secure to create the file during deployment, and only grant Read privileges to a single file, rather than to grant Create privileges for a folder. Also, it is more secure to write data to user folders than to the root folder or the **Program Files** folder. For more information, see [ACL Technology Overview](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/ms229742(v=vs.100)).  
  
## See also

- <xref:System.IO.Path.Combine%2A?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Devices.Computer>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem>
- <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A>
- <xref:Microsoft.VisualBasic.FileIO.SpecialDirectories>
