---
title: "How to use platform invoke to play a WAV file - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords:
  - "platform invoke, sound files"
  - "interoperability [C#], playing WAV files using pinvoke"
  - "wav files"
  - ".wav files"
ms.assetid: f7f62f53-e026-4c40-b221-3a26adb0c2c5
---
# How to use platform invoke to play a WAV file (C# Programming Guide)

The following C# code example illustrates how to use platform invoke services to play a WAV sound file on the Windows operating system.

## Example

This example code uses <xref:System.Runtime.InteropServices.DllImportAttribute> to import `winmm.dll`'s `PlaySound` method entry point as `Form1 PlaySound()`. The example has a simple Windows Form with a button. Clicking the button opens a standard windows <xref:System.Windows.Forms.OpenFileDialog> dialog box so that you can open a file to play. When a wave file is selected, it is played by using the `PlaySound()` method of the *winmm.dll* library. For more information about this method, see [Using the PlaySound function with Waveform-Audio Files](https://docs.microsoft.com/windows/desktop/multimedia/using-playsound-to-play-waveform-audio-files). Browse and select a file that has a .wav extension, and then click **Open** to play the wave file by using platform invoke. A text box shows the full path of the file selected.

The **Open Files** dialog box is filtered to show only files that have a .wav extension through the filter settings:

[!code-csharp[csProgGuideInterop#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInterop/CS/WinSound.cs#5)]

[!code-csharp[csProgGuideInterop#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInterop/CS/WinSound.cs#3)]

## Compiling the code

1. Create a new C# Windows Forms Application project in Visual Studio and name it **WinSound**.

2. Copy the code above, and paste it over the contents of the *Form1.cs* file.

3. Copy the following code, and paste it in the *Form1.Designer.cs* file, in the `InitializeComponent()` method, after any existing code.

     [!code-csharp[csProgGuideInterop#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInterop/CS/WinSound.cs#4)]

4. Compile and run the code.

## See also

- [C# Programming Guide](../index.md)
- [Interoperability Overview](interoperability-overview.md)
- [A Closer Look at Platform Invoke](../../../framework/interop/consuming-unmanaged-dll-functions.md#a-closer-look-at-platform-invoke)
- [Marshaling Data with Platform Invoke](../../../framework/interop/marshaling-data-with-platform-invoke.md)
