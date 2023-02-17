---
title: "How to use platform invoke to play a WAV file"
description: This C# code example illustrates how to use platform invoke services to play a WAV sound file on the Windows operating system.
ms.topic: how-to
ms.date: 02/15/2023
helpviewer_keywords:
  - "platform invoke, sound files"
  - "interoperability [C#], playing WAV files using pinvoke"
  - "wav files"
  - ".wav files"
---
# How to use platform invoke to play a WAV file

The following C# code example illustrates how to use platform invoke services to play a WAV sound file on the Windows operating system.

## Example

This example code uses <xref:System.Runtime.InteropServices.DllImportAttribute> to import `winmm.dll`'s `PlaySound` method entry point as `Form1 PlaySound()`. The example has a simple Windows Form with a button. Clicking the button opens a standard windows <xref:System.Windows.Forms.OpenFileDialog> dialog box so that you can open a file to play. When a wave file is selected, it's played by using the `PlaySound()` method of the *winmm.dll* library. For more information about this method, see [Using the PlaySound function with Waveform-Audio Files](/windows/desktop/multimedia/using-playsound-to-play-waveform-audio-files). Browse and select a file that has a .wav extension, and then select **Open** to play the wave file by using platform invoke. A text box shows the full path of the file selected.

:::code language="csharp" source="snippets/WinSound/Form1.cs":::

The **Open Files** dialog box is filtered to show only files that have a .wav extension through the filter settings.

## Compiling the code

Create a new C# Windows Forms Application project in Visual Studio and name it **WinSound**. Copy the preceding code, and paste it over the contents of the *Form1.cs* file. Copy the following code, and paste it in the *Form1.Designer.cs* file, in the `InitializeComponent()` method, after any existing code.

:::code language="csharp" source="snippets/WinSound/Form1.Designer.cs" id="Initialization":::

Compile and run the code.

## See also

- [A Closer Look at Platform Invoke](../../../framework/interop/consuming-unmanaged-dll-functions.md#a-closer-look-at-platform-invoke)
- [Marshaling Data with Platform Invoke](../../../framework/interop/marshalling-data-with-platform-invoke.md)
