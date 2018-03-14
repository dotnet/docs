---
title: "Playing Sounds (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "system sounds, playing"
  - "system sounds"
  - "playing sounds, Visual Basic"
  - "sound loops"
  - "My.Computer.Audio object, tasks"
  - "sounds, playing"
  - "sounds, background"
  - "playing sounds"
ms.assetid: f0d9e4ab-57c7-47b6-86d3-99ff07078040
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Playing Sounds (Visual Basic)
The `My.Computer.Audio` object provides methods for playing sounds.  
  
## Playing Sounds  
 Background playing lets the application execute other code while the sound plays. The `My.Computer.Audio.Play` method allows the application to play only one background sound at a time; when the application plays a new background sound, it stops playing the previous background sound. You can also play a sound and wait for it to complete.  
  
 In the following example, the `My.Computer.Audio.Play` method plays a sound. When `AudioPlayMode.WaitToComplete` is specified, `My.Computer.Audio.Play` waits until the sound completes before calling code continues. When using this example, you should ensure that the file name refers to a .wav sound file that is on your computer  
  
 [!code-vb[VbVbalrMyComputer#15](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/playing-sounds_1.vb)]  
  
 In the following example, the `My.Computer.Audio.Play` method plays a sound. When using this example, you should ensure that the application resources include a .wav sound file that is named Waterfall.  
  
 [!code-vb[VbVbalrMyComputer#16](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/playing-sounds_2.vb)]  
  
## Playing Looping Sounds  
 In the following example, the `My.Computer.Audio.Play` method plays the specified sound in the background when `PlayMode.BackgroundLoop` is specified. When using this example, you should ensure that the file name refers to a .wav sound file that is on your computer.  
  
 [!code-vb[VbVbalrMyComputer#11](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/playing-sounds_3.vb)]  
  
 In the following example, the `My.Computer.Audio.Play` method plays the specified sound in the background when `PlayMode.BackgroundLoop` is specified. When using this example, you should ensure that the application resources include a .wav sound file that is named Waterfall.  
  
 [!code-vb[VbVbalrMyComputer#12](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/playing-sounds_4.vb)]  
  
 The preceding code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Windows Forms Applications > Sound**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
 In general, when an application plays a looping sound, it should eventually stop the sound.  
  
## Stopping the Playing of Sounds in the Background  
 Use the `My.Computer.Audio.Stop` method to stop the application's currently playing background or looping sound.  
  
 In general, when an application plays a looping sound, it should stop the sound at some point.  
  
 The following example stops a sound that is playing in the background.  
  
 [!code-vb[VbVbalrMyComputer#18](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/playing-sounds_5.vb)]  
  
 The preceding code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **Windows Forms Applications > Sound**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Playing System Sounds  
 Use the `My.Computer.Audio.PlaySystemSound` method to play the specified system sound.  
  
 The `My.Computer.Audio.PlaySystemSound` method takes as a parameter one of the shared members from the <xref:System.Media.SystemSound> class. The system sound <xref:System.Media.SystemSounds.Asterisk%2A> generally denotes errors.  
  
 The following example uses the `My.Computer.Audio.PlaySystemSound` method to play a system sound.  
  
 [!code-vb[VbVbalrMyComputer#17](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/playing-sounds_6.vb)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Devices.Audio>  
 <xref:Microsoft.VisualBasic.Devices.Audio.Play%2A>  
 <xref:Microsoft.VisualBasic.Devices.Audio.PlaySystemSound%2A>  
 <xref:Microsoft.VisualBasic.Devices.Audio.Stop%2A>  
 <xref:Microsoft.VisualBasic.AudioPlayMode>
