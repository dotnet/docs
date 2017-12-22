---
title: "SoundPlayer Class Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "playing sounds [Windows Forms], SoundPlayer class"
  - "SoundPlayer class [Windows Forms], about SoundPlayer class"
  - "sounds [Windows Forms], playing"
ms.assetid: fcebb938-62b9-4677-9cbe-6465bc863e22
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# SoundPlayer Class Overview
The <xref:System.Media.SoundPlayer> class enables you to easily include sounds in your applications.  
  
 The <xref:System.Media.SoundPlayer> class can play sound files in the .wav format, either from a resource or from UNC or HTTP locations. Additionally, the <xref:System.Media.SoundPlayer> class enables you to load or play sounds asynchronously.  
  
 You can also use the <xref:System.Media.SystemSounds> class to play common system sounds, including a beep.  
  
## Commonly Used Properties, Methods, and Events  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Media.SoundPlayer.SoundLocation%2A> property|The file path or Web address of the sound. Acceptable values can be UNC or HTTP.|  
|<xref:System.Media.SoundPlayer.LoadTimeout%2A> property|The number of milliseconds your program will wait to load a sound before it throws an exception. The default is 10 seconds.|  
|<xref:System.Media.SoundPlayer.IsLoadCompleted%2A> property|A Boolean value indicating whether the sound has finished loading.|  
|<xref:System.Media.SoundPlayer.Load%2A> method|Loads a sound synchronously.|  
|<xref:System.Media.SoundPlayer.LoadAsync%2A> method|Begins to load a sound asynchronously. When loading is complete, it raises the <xref:System.Media.SoundPlayer.OnLoadCompleted%2A> event.|  
|<xref:System.Media.SoundPlayer.Play%2A> method|Plays the sound specified in the <xref:System.Media.SoundPlayer.SoundLocation%2A> or <xref:System.Media.SoundPlayer.Stream%2A> property in a new thread.|  
|<xref:System.Media.SoundPlayer.PlaySync%2A> method|Plays the sound specified in the <xref:System.Media.SoundPlayer.SoundLocation%2A> or <xref:System.Media.SoundPlayer.Stream%2A> property in the current thread.|  
|<xref:System.Media.SoundPlayer.Stop%2A> method|Stops any sound currently playing.|  
|<xref:System.Media.SoundPlayer.LoadCompleted> event|Raised after the load of a sound is attempted.|  
  
## See Also  
 <xref:System.Media.SoundPlayer>  
 <xref:System.Media.SystemSounds>
