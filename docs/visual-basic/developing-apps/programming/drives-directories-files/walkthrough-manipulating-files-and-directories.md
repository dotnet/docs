---
title: "Manipulating Files and Directories in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "files [Visual Basic], reading text"
  - "reading files [Visual Basic], text"
  - "I/O [Visual Basic], walkthroughs"
  - "text, writing to files"
  - "text, reading from files"
  - "reading text from files [Visual Basic], walkthroughs"
  - "Visual Basic code, file access"
  - "files [Visual Basic], writing text"
  - "I/O [Visual Basic], writing text to files"
  - "file access, walkthroughs"
  - "writing to files [Visual Basic], walkthroughs"
  - "I/O [Visual Basic], reading text from files"
ms.assetid: cae77565-9f78-4e46-8e42-eb2f9f8e1ffd
caps.latest.revision: 49
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Manipulating Files and Directories in Visual Basic
This walkthrough provides an introduction to the fundamentals of file I/O in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)]. It describes how to create a small application that lists and examines text files in a directory. For each selected text file, the application provides file attributes and the first line of content. There is an option to write information to a log file.  
  
 This walkthrough uses members of the `My.Computer.FileSystem Object`, which are available in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)]. See <xref:Microsoft.VisualBasic.FileIO.FileSystem> for more information. At the end of the walkthrough, an equivalent example is provided that uses classes from the <xref:System.IO> namespace.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To create the project  
  
1.  On the **File** menu, click **New Project**.  
  
     The **New Project** dialog box appears.  
  
2.  In the **Installed Templates** pane, expand **Visual Basic**, and then click **Windows**. In the **Templates** pane in the middle, click **Windows Forms Application**.  
  
3.  In the **Name** box, type `FileExplorer` to set the project name, and then click **OK**.  
  
     [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] adds the project to **Solution Explorer**, and the Windows Forms Designer opens.  
  
4.  Add the controls in the following table to the form, and set the corresponding values for their properties.  
  
    |Control|Property|Value|  
    |-------------|--------------|-----------|  
    |**ListBox**|**Name**|`filesListBox`|  
    |**Button**|**Name**<br /><br /> **Text**|`browseButton`<br /><br /> **Browse**|  
    |**Button**|**Name**<br /><br /> **Text**|`examineButton`<br /><br /> **Examine**|  
    |**CheckBox**|**Name**<br /><br /> **Text**|`saveCheckBox`<br /><br /> **Save Results**|  
    |**FolderBrowserDialog**|**Name**|`FolderBrowserDialog1`|  
  
### To select a folder, and list files in a folder  
  
1.  Create a `Click` event handler for `browseButton` by double-clicking the control on the form. The Code Editor opens.  
  
2.  Add the following code to the `Click` event handler.  
  
     [!code-vb[VbVbcnMyFileSystem#103](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_1.vb)]  
  
     The `FolderBrowserDialog1.ShowDialog` call opens the **Browse For Folder** dialog box. After the user clicks **OK**, the <xref:System.Windows.Forms.FolderBrowserDialog.SelectedPath%2A> property is sent as an argument to the `ListFiles` method, which is added in the next step.  
  
3.  Add the following `ListFiles` method.  
  
     [!code-vb[VbVbcnMyFileSystem#104](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_2.vb)]  
  
     This code first clears the **ListBox**.  
  
     The <xref:Microsoft.VisualBasic.FileIO.FileSystem.GetFiles%2A> method then retrieves a collection of strings, one for each file in the directory. The `GetFiles` method accepts a search pattern argument to retrieve files that match a particular pattern. In this example, only files that have the extension .txt are returned.  
  
     The strings that are returned by the `GetFiles` method are then added to the **ListBox**.  
  
4.  Run the application. Click the **Browse** button. In the **Browse For Folder** dialog box, browse to a folder that contains .txt files, and then select the folder and click **OK**.  
  
     The `ListBox` contains a list of .txt files in the selected folder.  
  
5.  Stop running the application.  
  
### To obtain attributes of a file, and content from a text file  
  
1.  Create a `Click` event handler for `examineButton` by double-clicking the control on the form.  
  
2.  Add the following code to the `Click` event handler.  
  
     [!code-vb[VbVbcnMyFileSystem#105](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_3.vb)]  
  
     The code verifies that an item is selected in the `ListBox`. It then obtains the file path entry from the `ListBox`. The <xref:Microsoft.VisualBasic.FileIO.FileSystem.FileExists%2A> method is used to check whether the file still exists.  
  
     The file path is sent as an argument to the `GetTextForOutput` method, which is added in the next step. This method returns a string that contains file information. The file information appears in a **MessageBox**.  
  
3.  Add the following `GetTextForOutput` method.  
  
     [!code-vb[VbVbcnMyFileSystem#107](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_4.vb)]  
  
     The code uses the <xref:Microsoft.VisualBasic.FileIO.FileSystem.GetFileInfo%2A> method to obtain file parameters. The file parameters are added to a <xref:System.Text.StringBuilder>.  
  
     The <xref:Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileReader%2A> method reads the file contents into a <xref:System.IO.StreamReader>. The first line of the contents is obtained from the `StreamReader` and is added to the `StringBuilder`.  
  
4.  Run the application. Click **Browse**, and browse to a folder that contains .txt files. Click **OK**.  
  
     Select a file in the `ListBox`, and then click **Examine**. A `MessageBox` shows the file information.  
  
5.  Stop running the application.  
  
### To add a log entry  
  
1.  Add the following code to the end of the `examineButton_Click` event handler.  
  
     [!code-vb[VbVbcnMyFileSystem#106](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_5.vb)]  
  
     The code sets the log file path to put the log file in the same directory as that of the selected file. The text of the log entry is set to the current date and time followed by the file information.  
  
     The <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A> method, with the `append` argument set to `True`, is used to create the log entry.  
  
2.  Run the application. Browse to a text file, select it in the `ListBox`, select the **Save Results** check box, and then click **Examine**. Verify that the log entry is written to the `log.txt` file.  
  
3.  Stop running the application.  
  
### To use the current directory  
  
1.  Create an event handler for `Form1_Load` by double-clicking the form.  
  
2.  Add the following code to the event handler.  
  
     [!code-vb[VbVbcnMyFileSystem#102](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_6.vb)]  
  
     This code sets the default directory of the folder browser to the current directory.  
  
3.  Run the application. When you click **Browse** the first time, the **Browse For Folder** dialog box opens to the current directory.  
  
4.  Stop running the application.  
  
### To selectively enable controls  
  
1.  Add the following `SetEnabled` method.  
  
     [!code-vb[VbVbcnMyFileSystem#108](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_7.vb)]  
  
     The `SetEnabled` method enables or disables controls depending on whether an item is selected in the `ListBox`.  
  
2.  Create a `SelectedIndexChanged` event handler for `filesListBox` by double-clicking the `ListBox` control on the form.  
  
3.  Add a call to `SetEnabled` in the new `filesListBox_SelectedIndexChanged` event handler.  
  
4.  Add a call to `SetEnabled` at the end of the `browseButton_Click` event handler.  
  
5.  Add a call to `SetEnabled` at the end of the `Form1_Load` event handler.  
  
6.  Run the application. The **Save Results** check box and the **Examine** button are disabled if an item is not selected in the `ListBox`.  
  
## Full example using My.Computer.FileSystem  
 Following is the complete example.  
  
 [!code-vb[VbVbcnMyFileSystem#101](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_8.vb)]  
  
## Full example using System.IO  
 The following equivalent example uses classes from the <xref:System.IO> namespace instead of using `My.Computer.FileSystem` objects.  
  
 [!code-vb[VbVbcnMyFileSystem#111](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/walkthrough-manipulating-files-and-directories_9.vb)]  
  
## See Also  
 <xref:System.IO>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory%2A>  
 [Walkthrough: Manipulating Files by Using .NET Framework Methods](../../../../visual-basic/developing-apps/programming/drives-directories-files/walkthrough-manipulating-files-by-using-net-framework-methods.md)
