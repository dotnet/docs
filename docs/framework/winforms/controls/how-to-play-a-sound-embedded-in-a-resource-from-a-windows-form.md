---
title: "How to: Play a Sound Embedded in a Resource from a Windows Form"
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
  - "sounds [Windows Forms], playing from resources"
  - "resources [Windows Forms], playing sounds"
  - "playing sounds [Windows Forms], from resources"
  - "SoundPlayer class [Windows Forms], playing sounds from resources"
ms.assetid: 7d148bb6-8a1e-47d7-a08d-35828d2e688f
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Play a Sound Embedded in a Resource from a Windows Form
You can use the <xref:System.Media.SoundPlayer> class to play a sound from an embedded resource.  
  
## Example  
 [!code-csharp[System.Windows.Forms.Sound#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Sound/CS/soundtestform.cs#10)]
 [!code-vb[System.Windows.Forms.Sound#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Sound/VB/soundtestform.vb#10)]  
  
## Compiling the Code  
 This example requires:  
  
 Importing the <xref:System.Media?displayProperty=nameWithType> namespace.  
  
 Including the sound file as an embedded resource in your project.  
  
 Replacing "\<AssemblyName>" with the name of the assembly in which the sound file is embedded. Do not include the ".dll" suffix.  
  
## See Also  
 <xref:System.Media.SoundPlayer>  
 [How to: Play a Sound from a Windows Form](../../../../docs/framework/winforms/controls/how-to-play-a-sound-from-a-windows-form.md)  
 [How to: Loop a Sound Playing on a Windows Form](../../../../docs/framework/winforms/controls/how-to-loop-a-sound-playing-on-a-windows-form.md)
