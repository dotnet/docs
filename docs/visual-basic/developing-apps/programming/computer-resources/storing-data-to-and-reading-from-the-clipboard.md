---
title: "Storing data to and reading from the Clipboard (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Clipboard, storing data to (My.Computer.Clipboard)"
  - "Clipboard, reading from (My.Computer.Clipboard)"
  - "Clipboard"
  - "My.Computer.Clipboard object, tasks"
  - "data [Visual Basic], Clipboard"
  - "reading data, from Clipboard"
ms.assetid: f690119a-4378-4f7d-b20e-d9377ef49496
---
# Storing data to and reading from the Clipboard (Visual Basic)
The Clipboard can be used to store data, such as text and images. Because the Clipboard is shared by all active processes, it can be used to transfer data between them. The `My.Computer.Clipboard` object allows you to easily access the Clipboard and to read from and write to it.  
  
## Reading from the Clipboard  
 Use the <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.GetText%2A> method to read the text in the Clipboard. The following code reads the text and displays it in a message box. There must be text stored on the Clipboard for the example to run correctly.  
  
 [!code-vb[VbVbcnMyClipboard#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyClipboard/VB/Class1.vb#4)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Windows Forms Applications > Clipboard**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
 Use the <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.GetImage%2A> method to retrieve an image from the Clipboard. This example checks to see if there is an image on the Clipboard before retrieving it and assigning it to `PictureBox1`.  
  
 [!code-vb[VbResourceTasks#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbResourceTasks/VB/Class1.vb#16)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Windows Forms Applications > Clipboard**.For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
 Items placed on the Clipboard will persist even after the application is shut down.  
  
## Determining the type of file stored in the Clipboard  
 Data on the Clipboard may take a number of different forms, such as text, an audio file, or an image. In order to determine what sort of file is on the Clipboard, you can use methods such as <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.ContainsAudio%2A>, <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.ContainsFileDropList%2A>, <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.ContainsImage%2A>, and <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.ContainsText%2A>. The <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.ContainsData%2A> method can be used if you have a custom format that you want to check.  
  
 Use the `ContainsImage` function to determine whether the data contained on the Clipboard is an image. The following code checks to see whether the data is an image and reports accordingly.  
  
 [!code-vb[VbResourceTasks#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbResourceTasks/VB/Class1.vb#13)]  
  
## Clearing the Clipboard  
 The <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.Clear%2A> method clears the Clipboard. Because the Clipboard is shared by other processes, clearing it may have an impact on those processes.  
  
 The following code shows how to use the `Clear` method.  
  
 [!code-vb[VbVbcnMyClipboard#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyClipboard/VB/Class1.vb#3)]  
  
## Writing to the Clipboard  
 Use the <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.SetText%2A> method to write text to the Clipboard. The following code writes the string "This is a test string" to the Clipboard.  
  
 [!code-vb[VbVbcnMyClipboard#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyClipboard/VB/Class1.vb#1)]  
  
 The `SetText` method can accept a format parameter that contains a type of <xref:System.Windows.Forms.TextDataFormat>. The following code writes the string "This is a test string" to the Clipboard as RTF text.  
  
 [!code-vb[VbVbcnMyClipboard#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyClipboard/VB/Class1.vb#2)]  
  
 Use the <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.SetData%2A> method to write data to the Clipboard. This example writes the `DataObject` `dataChunk` to the Clipboard in the custom format `specialFormat`.  
  
 [!code-vb[VbVbcnMyClipboard#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyClipboard/VB/Class1.vb#7)]  
  
 Use the <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.SetAudio%2A> method to write audio data to the Clipboard. This example creates the byte array `musicReader`, reads the file `cool.wav` into it, and then writes it to the Clipboard.  
  
 [!code-vb[VbResourceTasks#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbResourceTasks/VB/Class1.vb#5)]  
  
> [!IMPORTANT]
> Because the Clipboard can be accessed by other users, do not use it to store sensitive information, such as passwords or confidential data.  
  
## See also

- <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy>
- <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.GetAudioStream%2A>
- <xref:Microsoft.VisualBasic.MyServices.ClipboardProxy.SetDataObject%2A>
- [How to: Read Object Data from an XML File](../../../programming-guide/concepts/serialization/how-to-read-object-data-from-an-xml-file.md)
- [How to: Write Object Data to an XML File](../../../programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file.md)
