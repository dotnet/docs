---
title: "How to: Use Platform Invoke to Play a Wave File (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "platform invoke, sound files"
  - "interoperability [C#], playing WAV files using pinvoke"
  - "wav files"
  - ".wav files"
ms.assetid: f7f62f53-e026-4c40-b221-3a26adb0c2c5
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# How to: Use Platform Invoke to Play a Wave File (C# Programming Guide)
The following C# code example illustrates how to use platform invoke services to play a wave sound file on the Windows operating system.  
  
## Example  
 This example code uses `DllImport` to import `winmm.dll`'s `PlaySound` method entry point as `Form1 PlaySound()`. The example has a simple Windows Form with a button. Clicking the button opens a standard windows <xref:System.Windows.Forms.OpenFileDialog> dialog box so that you can open a file to play. When a wave file is selected, it is played by using the `PlaySound()` method of the winmm.DLL assembly method. For more information about winmm.dll's `PlaySound` method, see [Using the PlaySound function with Waveform-Audio Files](http://go.microsoft.com/fwlink/?LinkId=148553). Browse and select a file that has a .wav extension, and then click **Open** to play the wave file by using platform invoke. A text box shows the full path of the file selected.  
  
 The **Open Files** dialog box is filtered to show only files that have a .wav extension through the filter settings:  
  
 [!code-cs[csProgGuideInterop#5](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-use-platform-invoke-to-play-a-wave-file_1.cs)]  
  
 [!code-cs[csProgGuideInterop#3](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-use-platform-invoke-to-play-a-wave-file_2.cs)]  
  
## Compiling the Code  
  
### To compile the code  
  
1.  Create a new C# Windows Application project in Visual Studio and name it **WinSound**.  
  
2.  Copy the code above, and paste it over the contents of the `Form1.cs` file.  
  
3.  Copy the following code, and paste it in the `Form1.Designer.cs` file, in the `InitializeComponent()` method, after any existing code.  
  
     [!code-cs[csProgGuideInterop#4](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-use-platform-invoke-to-play-a-wave-file_3.cs)]  
  
4.  Compile and run the code.  
  
## .NET Framework Security  
 For more information, see [.NET Framework Security](http://go.microsoft.com/fwlink/?LinkId=37122).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Interoperability Overview](../../../csharp/programming-guide/interop/interoperability-overview.md)   
 [Interoperability Overview](../../../csharp/programming-guide/interop/interoperability-overview.md)   
 [A Closer Look at Platform Invoke](http://msdn.microsoft.com/en-us/ba9dd55b-2eaa-45cd-8afd-75cb8d64d243)   
 [Marshaling Data with Platform Invoke](../../../framework/interop/marshaling-data-with-platform-invoke.md)