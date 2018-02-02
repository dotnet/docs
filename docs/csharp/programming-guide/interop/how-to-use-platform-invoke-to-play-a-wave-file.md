---
title: "How to: Use Platform Invoke to Play a Wave File (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "platform invoke, sound files"
  - "interoperability [C#], playing WAV files using pinvoke"
  - "wav files"
  - ".wav files"
ms.assetid: f7f62f53-e026-4c40-b221-3a26adb0c2c5
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Use Platform Invoke to Play a Wave File (C# Programming Guide)
The following C# code example illustrates how to use platform invoke services to play a wave sound file on the Windows operating system.  
  
## Example  
 This example code uses `DllImport` to import `winmm.dll`'s `PlaySound` method entry point as `Form1 PlaySound()`. The example has a simple Windows Form with a button. Clicking the button opens a standard windows <xref:System.Windows.Forms.OpenFileDialog> dialog box so that you can open a file to play. When a wave file is selected, it is played by using the `PlaySound()` method of the winmm.DLL assembly method. For more information about winmm.dll's `PlaySound` method, see [Using the PlaySound function with Waveform-Audio Files](https://msdn.microsoft.com/library/aa910379.aspx). Browse and select a file that has a .wav extension, and then click **Open** to play the wave file by using platform invoke. A text box shows the full path of the file selected.  
  
 The **Open Files** dialog box is filtered to show only files that have a .wav extension through the filter settings:  
  
 [!code-csharp[csProgGuideInterop#5](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-use-platform-invoke-to-play-a-wave-file_1.cs)]  
  
 [!code-csharp[csProgGuideInterop#3](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-use-platform-invoke-to-play-a-wave-file_2.cs)]  
  
## Compiling the Code  
  
### To compile the code  
  
1.  Create a new C# Windows Application project in Visual Studio and name it **WinSound**.  
  
2.  Copy the code above, and paste it over the contents of the `Form1.cs` file.  
  
3.  Copy the following code, and paste it in the `Form1.Designer.cs` file, in the `InitializeComponent()` method, after any existing code.  
  
     [!code-csharp[csProgGuideInterop#4](../../../csharp/programming-guide/interop/codesnippet/CSharp/how-to-use-platform-invoke-to-play-a-wave-file_3.cs)]  
  
4.  Compile and run the code.  
  
## .NET Framework Security  
 For more information, see [.NET Framework Security](https://technet.microsoft.com/en-us/security/).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Interoperability Overview](../../../csharp/programming-guide/interop/interoperability-overview.md)  
 [A Closer Look at Platform Invoke](../../../framework/interop/consuming-unmanaged-dll-functions.md#a-closer-look-at-platform-invoke)  
 [Marshaling Data with Platform Invoke](../../../framework/interop/marshaling-data-with-platform-invoke.md)
