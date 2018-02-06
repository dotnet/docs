---
title: "How to: Loop a Sound Playing on a Windows Form"
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
  - "sound loops"
  - "SoundPlayer class [Windows Forms], play looping"
  - "sounds [Windows Forms], looping"
  - "playing sounds [Windows Forms], looping"
ms.assetid: ea95dd46-10a3-46c0-8263-4b205f00df7f
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Loop a Sound Playing on a Windows Form
The following code example plays a sound repeatedly. When the code in the `stopPlayingButton_Click` event handler runs, any sound currently playing stops. If no sound is playing, nothing happens.  
  
## Example  
 [!code-csharp[System.Media.SoundPlayer.PlayLooping#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Media.SoundPlayer.PlayLooping/CS/Form1.cs#1)]
 [!code-vb[System.Media.SoundPlayer.PlayLooping#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Media.SoundPlayer.PlayLooping/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System and System.Windows.Forms assemblies.  
  
-   That you replace the file name `"c:\Windows\Media\chimes.wav"` with a valid file name.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## Robust Programming  
 File operations should be enclosed within appropriate exception-handling blocks.  
  
 The following conditions may cause an exception:  
  
-   The path name is malformed. For example, it contains characters that are not valid or it is only white space (<xref:System.ArgumentException> class).  
  
-   The path is read-only (<xref:System.IO.IOException> class).  
  
-   The path name is `Nothing` (<xref:System.ArgumentNullException> class).  
  
-   The path name is too long (<xref:System.IO.PathTooLongException> class).  
  
-   The path is invalid (<xref:System.IO.DirectoryNotFoundException> class).  
  
-   The path is only a colon ":" (<xref:System.NotSupportedException> class).  
  
## .NET Framework Security  
 Do not make decisions about the contents of the file based on the name of the file. For example, the file Form1.vb may not be a Visual Basic source file. Verify all inputs before using the data in your application.  
  
## See Also  
 <xref:System.Media.SoundPlayer.PlayLooping%2A>  
 [How to: Play a Sound from a Windows Form](../../../../docs/framework/winforms/controls/how-to-play-a-sound-from-a-windows-form.md)  
 [SoundPlayer Class Overview](../../../../docs/framework/winforms/controls/soundplayer-class-overview.md)
