---
title: "How to: Load a Sound Asynchronously within a Windows Form"
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
  - "SoundPlayer class [Windows Forms], loading sounds asynchronously"
  - "sounds [Windows Forms], loading on separate threads"
  - "threading [Windows Forms], sounds"
ms.assetid: 3b6a9296-1d5e-4d52-a4ba-94366d6fe302
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Load a Sound Asynchronously within a Windows Form
The following code example asynchronously loads a sound from an URL and then plays it on a new thread.  
  
## Example  
 [!code-csharp[System.Media.SoundPlayer.LoadAsync#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Media.SoundPlayer.LoadAsync/CS/Form1.cs#1)]
 [!code-vb[System.Media.SoundPlayer.LoadAsync#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Media.SoundPlayer.LoadAsync/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System and System.Windows.Forms assemblies.  
  
-   That you replace the file name `"http://www.tailspintoys.com/sounds/stop.wav"` with a valid file name.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## Robust Programming  
 File operations should be enclosed within appropriate exception-handling blocks.  
  
 The following conditions may cause an exception:  
  
-   The path name is malformed. For example, it contains characters that are not valid or is only white space (<xref:System.ArgumentException> class).  
  
-   The path is read-only (<xref:System.IO.IOException> class).  
  
-   The path name is `Nothing` (<xref:System.ArgumentNullException> class).  
  
-   The path name is too long (<xref:System.IO.PathTooLongException> class).  
  
-   The path is not valid (<xref:System.IO.DirectoryNotFoundException> class).  
  
-   The path is only a colon ":" (<xref:System.NotSupportedException> class).  
  
## .NET Framework Security  
 Do not make decisions about the contents of the file based on the name of the file. For example, the file `Form1.vb` may not be a Visual Basic source file. Verify all inputs before using the data in your application.  
  
## See Also  
 <xref:System.Media.SoundPlayer.LoadAsync%2A>  
 <xref:System.Media.SoundPlayer.LoadCompleted>  
 <xref:System.Media.SoundPlayer.Play%2A>  
 [How to: Play a Sound from a Windows Form](../../../../docs/framework/winforms/controls/how-to-play-a-sound-from-a-windows-form.md)
