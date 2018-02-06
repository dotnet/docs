---
title: "How to: Download a File in the Background"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "BackgroundWorker component"
  - "background tasks"
  - "Asynchronous Pattern"
  - "forms [Windows Forms], multithreading"
  - "components [Windows Forms], asynchronous"
  - "forms [Windows Forms], background operations"
  - "threading [Windows Forms], background operations"
  - "background operations"
ms.assetid: 9b7bc5ae-051c-4904-9720-18f6667388bd
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Download a File in the Background
Downloading a file is a common task, and it is often useful to run this potentially time-consuming operation on a separate thread. Use the <xref:System.ComponentModel.BackgroundWorker> component to accomplish this task with very little code.  
  
## Example  
 The following code example demonstrates how to use a <xref:System.ComponentModel.BackgroundWorker> component to load an XML file from a URL. When the user clicks the **Download** button, the <xref:System.Windows.Forms.Control.Click> event handler calls the <xref:System.ComponentModel.BackgroundWorker.RunWorkerAsync%2A> method of a <xref:System.ComponentModel.BackgroundWorker> component to start the download operation. The button is disabled for the duration of the download, and then enabled when the download is complete. A <xref:System.Windows.Forms.MessageBox> displays the contents of the file.  
  
 [!code-csharp[System.ComponentModel.BackgroundWorker.IsBusy#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/CS/Form1.cs#1)]
 [!code-vb[System.ComponentModel.BackgroundWorker.IsBusy#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/VB/Form1.vb#1)]  
  
 **Downloading the file**  
  
 The file is downloaded on the <xref:System.ComponentModel.BackgroundWorker> component's worker thread, which runs the <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler. This thread starts when your code calls the <xref:System.ComponentModel.BackgroundWorker.RunWorkerAsync%2A> method.  
  
 [!code-csharp[System.ComponentModel.BackgroundWorker.IsBusy#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/CS/Form1.cs#3)]
 [!code-vb[System.ComponentModel.BackgroundWorker.IsBusy#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/VB/Form1.vb#3)]  
  
 **Waiting for a BackgroundWorker to finish**  
  
 The `downloadButton_Click` event handler demonstrates how to wait for a <xref:System.ComponentModel.BackgroundWorker> component to finish its asynchronous task.  
  
 If you only want the application to respond to events and do not want to do any work in the main thread while you wait for the background thread to complete, just exit the handler.  
  
 If you want to continue doing work in the main thread, use the <xref:System.ComponentModel.BackgroundWorker.IsBusy%2A> property to determine whether the <xref:System.ComponentModel.BackgroundWorker> thread is still running. In the example, a progress bar is updated while the download is processing. Be sure to call the <xref:System.Windows.Forms.Application.DoEvents%2A?displayProperty=nameWithType> method to keep the UI responsive.  
  
 [!code-csharp[System.ComponentModel.BackgroundWorker.IsBusy#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/CS/Form1.cs#2)]
 [!code-vb[System.ComponentModel.BackgroundWorker.IsBusy#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/VB/Form1.vb#2)]  
  
 **Displaying the result**  
  
 The `backgroundWorker1_RunWorkerCompleted` method handles the <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event and is called when the background operation is completed. This method first checks the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A?displayProperty=nameWithType> property. If <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A?displayProperty=nameWithType> is `null`, then this method displays the contents of the file. It then enables the download button, which was disabled when the download began, and it resets the progress bar.  
  
 [!code-csharp[System.ComponentModel.BackgroundWorker.IsBusy#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/CS/Form1.cs#4)]
 [!code-vb[System.ComponentModel.BackgroundWorker.IsBusy#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.IsBusy/VB/Form1.vb#4)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System.Drawing, System.Windows.Forms, and System.Xml assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## Robust Programming  
 Always check the <xref:System.ComponentModel.AsyncCompletedEventArgs.Error%2A?displayProperty=nameWithType> property in your <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted> event handler before attempting to access the <xref:System.ComponentModel.RunWorkerCompletedEventArgs.Result%2A?displayProperty=nameWithType> property or any other object that may have been affected by the <xref:System.ComponentModel.BackgroundWorker.DoWork> event handler.  
  
## See Also  
 <xref:System.ComponentModel.BackgroundWorker>  
 [How to: Run an Operation in the Background](../../../../docs/framework/winforms/controls/how-to-run-an-operation-in-the-background.md)  
 [How to: Implement a Form That Uses a Background Operation](../../../../docs/framework/winforms/controls/how-to-implement-a-form-that-uses-a-background-operation.md)
