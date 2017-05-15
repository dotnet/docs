---
title: "How to: Play a System Sound from a Windows Form | Microsoft Docs"
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
  - "jsharp"
helpviewer_keywords: 
  - "sounds, playing for system events"
  - "playing sounds, Windows Forms"
  - "system sounds, playing from Windows Forms"
  - "playing sounds, system"
  - "SoundPlayer class, system sounds"
  - "sounds, playing"
  - "examples [Windows Forms], sounds"
ms.assetid: afb206ff-4824-4804-a8d4-185bf5ad8e7c
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
---
# How to: Play a System Sound from a Windows Form
The following code example plays the `Exclamation` system sound at run time. For more information about system sounds, see <xref:System.Media.SystemSounds>.  
  
## Example  
  
```vb  
Public Sub PlayExclamation()  
    SystemSounds.Exclamation.Play()  
End Sub  
  
```  
  
```csharp  
public void playExclamation()  
{  
    SystemSounds.Exclamation.Play();  
}  
```  
  
## Compiling the Code  
 This example requires:  
  
-   A reference to the <xref:System.Media?displayProperty=fullName> namespace.  
  
## See Also  
 <xref:System.Media.SoundPlayer>   
 <xref:System.Media.SystemSounds>   
 [How to: Play a Beep from a Windows Form](../../../../docs/framework/winforms/controls/how-to-play-a-beep-from-a-windows-form.md)   
 [How to: Play a Sound from a Windows Form](../../../../docs/framework/winforms/controls/how-to-play-a-sound-from-a-windows-form.md)