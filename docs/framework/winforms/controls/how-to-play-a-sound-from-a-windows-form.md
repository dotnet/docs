---
title: "How to: Play a Sound from a Windows Form"
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
  - "playing sounds [Windows Forms], Windows Forms"
  - "sounds [Windows Forms], playing"
  - "sounds"
  - "My.Computer.Audio object [Windows Forms], playing sounds"
  - "examples [Windows Forms], sounds"
ms.assetid: 3d3350b7-1ebd-4e05-a738-48ca1160a19d
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Play a Sound from a Windows Form
This example plays a sound at a given path at run time.  
  
## Example  
  
```vb  
Sub PlaySimpleSound()  
    My.Computer.Audio.Play("c:\Windows\Media\chimes.wav")  
End Sub  
```  
  
```csharp  
private void playSimpleSound()  
{  
    SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");  
    simpleSound.Play();  
}  
```  
  
## Compiling the Code  
 This example requires:  
  
-   That you replace the file name `"c:\Windows\Media\chimes.wav"` with a valid file name.  
  
-   (C#) A reference to the <xref:System.Media?displayProperty=nameWithType> namespace.  
  
## Robust Programming  
 File operations should be enclosed within appropriate structured exception handling blocks.  
  
 The following conditions may cause an exception:  
  
-   The path name is malformed. For example, it contains illegal characters or is only white space (<xref:System.ArgumentException> class).  
  
-   The path is read-only (<xref:System.IO.IOException> class).  
  
-   The path name is `null` (<xref:System.ArgumentNullException> class).  
  
-   The path name is too long (<xref:System.IO.PathTooLongException> class).  
  
-   The path is invalid (<xref:System.IO.DirectoryNotFoundException> class).  
  
-   The path is only a colon, ":" (<xref:System.NotSupportedException> class).  
  
## .NET Framework Security  
 Do not make decisions about the contents of the file based on the name of the file. For example, the file `Form1.vb` may not be a Visual Basic source file. Verify all inputs before using the data in your application.  
  
## See Also  
 <xref:System.Media.SoundPlayer>  
 [How to: Load a Sound Asynchronously within a Windows Form](../../../../docs/framework/winforms/controls/how-to-load-a-sound-asynchronously-within-a-windows-form.md)  
 
