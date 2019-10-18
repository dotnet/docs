---
title: "How to: Open files with the OpenFileDialog component"
ms.date: "02/11/2019"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "OpenFileDialog component [Windows Forms], opening files"
  - "OpenFile method [Windows Forms], OpenFileDialog component"
  - "files [Windows Forms], opening with OpenFileDialog component"
ms.assetid: 9d88367a-cc21-4ffd-be74-89fd63767d35
---
# How to: Open files with the OpenFileDialog 

The <xref:System.Windows.Forms.OpenFileDialog?displayProperty=nameWithType> component opens the Windows dialog box for browsing and selecting files. To open and read the selected files, you can use the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A?displayProperty=nameWithType> method, or create an instance of the <xref:System.IO.StreamReader?displayProperty=nameWithType> class. The following examples show both approaches. 

In .NET Framework, to get or set the <xref:System.Windows.Forms.FileDialog.FileName%2A> property requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission?displayProperty=nameWithType> class. The examples run a <xref:System.Security.Permissions.FileIOPermission> permission check, and can throw an exception due to insufficient privileges if run in a partial-trust context. For more information, see [Code access security basics](../../misc/code-access-security-basics.md).

You can build and run these examples as .NET Framework apps from the C# or Visual Basic command line. For more information, see [Command-line building with csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) or [Build from the command line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md). 

Starting with .NET Core 3.0, you can also build and run the examples as Windows .NET Core apps from a folder that has a .NET Core Windows Forms *\<folder name>.csproj* project file. 

## Example: Read a file as a stream with StreamReader  
  
The following example uses the Windows Forms <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method. After the user chooses a file and selects **OK**, an instance of the <xref:System.IO.StreamReader> class reads the file and displays its contents in the form's text box. For more information about reading from file streams, see <xref:System.IO.FileStream.BeginRead%2A?displayProperty=nameWithType> and <xref:System.IO.FileStream.Read%2A?displayProperty=nameWithType>.  

 [!code-csharp[OpenFileDialog#1](~/samples/snippets/winforms/open-files/example1/cs/Form1.cs)]
 [!code-vb[OpenFileDialog#1](~/samples/snippets/winforms/open-files/example1/vb/Form1.vb)]  

## Example: Open a file from a filtered selection with OpenFile 

The following example uses the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event handler to open the <xref:System.Windows.Forms.OpenFileDialog> with a filter that shows only text files. After the user chooses a text file and selects **OK**, the <xref:System.Windows.Forms.OpenFileDialog.OpenFile%2A> method is used to open the file in Notepad.

 [!code-csharp[OpenFileDialog#2](~/samples/snippets/winforms/open-files/example2/cs/Form1.cs)]
 [!code-vb[OpenFileDialog#2](~/samples/snippets/winforms/open-files/example2/vb/Form1.vb)]  

## See also

- <xref:System.Windows.Forms.OpenFileDialog>
- [OpenFileDialog component](openfiledialog-component-windows-forms.md)
