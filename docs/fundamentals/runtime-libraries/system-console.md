---
title: System.Console class
description: Learn about the System.Console class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Console class

[!INCLUDE [context](includes/context.md)]

The console is an operating system window where users interact with the operating system or with a text-based console application by entering text input through the computer keyboard, and by reading text output from the computer terminal. For example, in the Windows operating system, the console is called the Command Prompt window and accepts MS-DOS commands. The <xref:System.Console> class provides basic support for applications that read characters from, and write characters to, the console.

## Console I/O streams

When a console application starts, the operating system automatically associates three I/O streams with the console: standard input stream, standard output stream, and standard error output stream. Your application can read user input from the standard input stream; write normal data to the standard output stream; and write error data to the standard error output stream. These streams are presented to your application as the values of the <xref:System.Console.In%2A?displayProperty=nameWithType>, <xref:System.Console.Out%2A?displayProperty=nameWithType>, and <xref:System.Console.Error%2A?displayProperty=nameWithType> properties.

By default, the value of the <xref:System.Console.In%2A> property is a <xref:System.IO.TextReader?displayProperty=nameWithType> object that represents the keyboard, and the values of the <xref:System.Console.Out%2A> and <xref:System.Console.Error%2A> properties are <xref:System.IO.TextWriter?displayProperty=nameWithType> objects that represent a console window. However, you can set these properties to streams that do not represent the console window or keyboard; for example, you can set these properties to streams that represent files. To redirect the standard input, standard output, or standard error stream, call the <xref:System.Console.SetIn%2A?displayProperty=nameWithType>, <xref:System.Console.SetOut%2A?displayProperty=nameWithType>, or <xref:System.Console.SetError%2A?displayProperty=nameWithType> method, respectively. I/O operations that use these streams are synchronized, which means that multiple threads can read from, or write to, the streams. This means that methods that are ordinarily asynchronous, such as <xref:System.IO.TextReader.ReadLineAsync%2A?displayProperty=nameWithType>, execute synchronously if the object represents a console stream.

> [!NOTE]
> Do not use the <xref:System.Console> class to display output in unattended applications, such as server applications. Calls to methods such as <xref:System.Console.Write%2A?displayProperty=nameWithType> and <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> have no effect in GUI applications.

<xref:System.Console> class members that work normally when the underlying stream is directed to a console might throw an exception if the stream is redirected, for example, to a file. Program your application to catch <xref:System.IO.IOException?displayProperty=nameWithType> exceptions if you redirect a standard stream. You can also use the <xref:System.Console.IsOutputRedirected%2A>, <xref:System.Console.IsInputRedirected%2A>, and <xref:System.Console.IsErrorRedirected%2A> properties to determine whether a standard stream is redirected before performing an operation that throws an <xref:System.IO.IOException?displayProperty=nameWithType> exception.

It is sometimes useful to explicitly call the members of the stream objects represented by the <xref:System.Console.In%2A>, <xref:System.Console.Out%2A>, and <xref:System.Console.Error%2A> properties. For example, by default, the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method reads input from the standard input stream. Similarly, the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method writes data to the standard output stream, and the data is followed by the default line termination string, which can be found at <xref:System.Environment.NewLine?displayProperty=nameWithType>. However, the <xref:System.Console> class does not provide a corresponding method to write data to the standard error output stream, or a property to change the line termination string for data written to that stream.

You can solve this problem by setting the <xref:System.IO.TextWriter.NewLine%2A?displayProperty=nameWithType> property of the <xref:System.Console.Out%2A> or <xref:System.Console.Error%2A> property to another line termination string. For example, the following C# statement sets the line termination string for the standard error output stream to two carriage return and line feed sequences:

`Console.Error.NewLine = "\r\n\r\n";`

You can then explicitly call the <xref:System.IO.TextWriter.WriteLine%2A> method of the error output stream object, as in the following C# statement:

`Console.Error.WriteLine();`

## Screen buffer and console window

Two closely related features of the console are the screen buffer and the console window. Text is actually read from or written to streams owned by the console, but appear to be read from or written to an area owned by the console called the screen buffer. The screen buffer is an attribute of the console, and is organized as a rectangular grid of rows and columns where each grid intersection, or character cell, can contain a character. Each character has its own foreground color, and each character cell has its own background color.

The screen buffer is viewed through a rectangular region called the console window. The console window is another attribute of the console; it is not the console itself, which is an operating system window. The console window is arranged in rows and columns, is less than or equal to the size of the screen buffer, and can be moved to view different areas of the underlying screen buffer. If the screen buffer is larger than the console window, the console automatically displays scroll bars so the console window can be repositioned over the screen buffer area.

A cursor indicates the screen buffer position where text is currently read or written. The cursor can be hidden or made visible, and its height can be changed. If the cursor is visible, the console window position is moved automatically so the cursor is always in view.

The origin for character cell coordinates in the screen buffer is the upper left corner, and the positions of the cursor and the console window are measured relative to that origin. Use zero-based indexes to specify positions; that is, specify the topmost row as row 0, and the leftmost column as column 0. The maximum value for the row and column indexes is <xref:System.Int16.MaxValue?displayProperty=nameWithType>.

## Unicode support for the console

In general, the console reads input and writes output by using the current console code page, which the system locale defines by default. A code page can handle only a subset of available Unicode characters, so if you try to display characters that are not mapped by a particular code page, the console won't be able to display all characters or represent them accurately. The following example illustrates this problem. It tries to display the characters of the Cyrillic alphabet from U+0410 to U+044F to the console. If you run the example on a system that uses console code page 437, each character is replaced by a question mark (?), because Cyrillic characters do not map to the characters in code page 437.

:::code language="csharp" source="./snippets/System/Console/Overview/csharp/unicode1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Console/Overview/vb/unicode1.vb" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Console/Overview/fsharp/unicode1.fs" id="Snippet1":::

In addition to supporting code pages, the <xref:System.Console> class supports UTF-8 encoding with the <xref:System.Text.UTF8Encoding> class. Beginning with .NET Framework 4.5, the <xref:System.Console> class also supports UTF-16 encoding with the <xref:System.Text.UnicodeEncoding> class. To display Unicode characters to the console. you set the <xref:System.Console.OutputEncoding%2A> property to either <xref:System.Text.UTF8Encoding> or  <xref:System.Text.UnicodeEncoding>.

Support for Unicode characters requires the encoder to recognize a particular Unicode character, and also requires a font that has the glyphs needed to render that character. To successfully display Unicode characters to the console, the console font must be set to a non-raster or TrueType font such as Consolas or Lucida Console. The following example shows how you can programmatically change the font from a raster font to Lucida Console.

:::code language="csharp" source="./snippets/System/Console/Overview/csharp/setfont1.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Console/Overview/vb/setfont1.vb" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Console/Overview/fsharp/setfont1.fs" id="Snippet3":::

However, TrueType fonts can display only a subset of glyphs. For example, the Lucida Console font displays only 643 of the approximately 64,000 available characters from U+0021 to U+FB02. To see which characters a particular font supports, open the **Fonts** applet in Control Panel, choose the **Find a character** option, and choose the font whose character set you'd like to examine in the **Font** list of the **Character Map** window.

Windows uses font linking to display glyphs that are not available in a particular font. For information about font linking to display additional character sets, see [Globalization Step-by-Step: Fonts](https://go.microsoft.com/fwlink/?LinkId=229111). Linked fonts are defined in the HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\FontLink\SystemLink subkey of the registry. Each entry associated with this subkey corresponds to the name of a base font, and its value is a string array that defines the font files and the fonts that are linked to the base font. Each member of the array defines a linked font and takes the form *font-file-name*,*font-name*. The following example illustrates how you can programmatically define a linked font named SimSun found in a font file named simsun.ttc that displays Simplified Han characters.

:::code language="csharp" source="./snippets/System/Console/Overview/csharp/fontlink1.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Console/Overview/vb/fontlink1.vb" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Console/Overview/fsharp/fontlink1.fs" id="Snippet2":::

Unicode support for the console has the following limitations:

- UTF-32 encoding is not supported. The only supported Unicode encodings are UTF-8 and UTF-16, which are represented by the <xref:System.Text.UTF8Encoding> and <xref:System.Text.UnicodeEncoding> classes, respectively.

- Bidirectional output is not supported.

- Display of characters outside the Basic Multilingual Plane (that is, of surrogate pairs) is not supported, even if they are defined in a linked font file.

- Display of characters in complex scripts is not supported.

- Combining character sequences (that is, characters that consist of a base character and one or more combining characters) are displayed as separate characters. To work around this limitation, you can normalize the string to be displayed by calling the <xref:System.String.Normalize%2A?displayProperty=nameWithType> method before sending output to the console. In the following example, a string that contains the combining character sequence U+0061 U+0308 is displayed to the console as two characters before the output string is normalized, and as a single character after the <xref:System.String.Normalize%2A?displayProperty=nameWithType> method is called.

  :::code language="csharp" source="./snippets/System/Console/Overview/csharp/normalize1.cs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Console/Overview/vb/normalize1.vb" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Console/Overview/fsharp/normalize1.fs" id="Snippet5":::

  Normalization is a viable solution only if the Unicode standard for the character includes a pre-composed form that corresponds to a particular combining character sequence.

- If a font provides a glyph for a code point in the private use area, that glyph will be displayed. However, because characters in the private use area are application-specific, this may not be the expected glyph.

The following example displays a range of Unicode characters to the console. The example accepts three command-line parameters: the start of the range to display, the end of the range to display, and whether to use the current console encoding (`false`) or UTF-16 encoding (`true`). It assumes that the console is using a TrueType font.

:::code language="csharp" source="./snippets/System/Console/Overview/csharp/example3.cs" id="Snippet4":::
:::code language="vb" source="./snippets/System/Console/Overview/vb/example3.vb" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Console/Overview/fsharp/example3.fs" id="Snippet4":::

## Common operations

The <xref:System.Console> class contains the following methods for reading console input and writing console output:

- The overloads of the <xref:System.Console.ReadKey%2A> method read an individual character.

- The <xref:System.Console.ReadLine%2A> method reads an entire line of input.

- The <xref:System.Console.Write%2A> method overloads convert an instance of a value type, an array of characters, or a set of objects to a formatted or unformatted string, and then write that string to the console.

- A parallel set of <xref:System.Console.WriteLine%2A> method overloads output the same string as the <xref:System.Console.Write%2A> overloads but also add a line termination string.

The <xref:System.Console> class also contains methods and properties to perform the following operations:

- Get or set the size of the screen buffer. The <xref:System.Console.BufferHeight%2A> and <xref:System.Console.BufferWidth%2A> properties let you get or set the buffer height and width, respectively, and the <xref:System.Console.SetBufferSize%2A> method lets you set the buffer size in a single method call.

- Get or set the size of the console window. The <xref:System.Console.WindowHeight%2A> and <xref:System.Console.WindowWidth%2A> properties let you get or set the window height and width, respectively, and the <xref:System.Console.SetWindowSize%2A> method lets you set the window size in a single method call.

- Get or set the size of the cursor. The <xref:System.Console.CursorSize%2A> property specifies the height of the cursor in a character cell.

- Get or set the position of the console window relative to the screen buffer. The <xref:System.Console.WindowTop%2A> and <xref:System.Console.WindowLeft%2A> properties let you get or set the top row and leftmost column of the screen buffer that appears in the console window, and the <xref:System.Console.SetWindowPosition%2A> method lets you set these values in a single method call.

- Get or set the position of the cursor by getting or setting the <xref:System.Console.CursorTop%2A> and <xref:System.Console.CursorLeft%2A> properties, or set the position of the cursor by calling the <xref:System.Console.SetCursorPosition%2A> method.

- Move or clear data in the screen buffer by calling the <xref:System.Console.MoveBufferArea%2A> or <xref:System.Console.Clear%2A> method.

- Get or set the foreground and background colors by using the <xref:System.Console.ForegroundColor%2A> and <xref:System.Console.BackgroundColor%2A> properties, or reset the background and foreground to their default colors by calling the <xref:System.Console.ResetColor%2A> method.

- Play the sound of a beep through the console speaker by calling the <xref:System.Console.Beep%2A> method.

## .NET Core notes

In .NET Framework on the desktop, the <xref:System.Console> class uses the encoding returned by `GetConsoleCP` and `GetConsoleOutputCP`, which typically is a code page encoding. For example code, on systems whose culture is English (United States), code page 437 is the encoding that is used by default. However, .NET Core may make only a limited subset of these encodings available. Where this is the case, <xref:System.Text.Encoding.UTF8%2A?displayProperty=nameWithType> is used as the default encoding for the console.

If your app depends on specific code page encodings, you can still make them available by doing the following *before* you call any <xref:System.Console> methods:

1. Retrieve the <xref:System.Text.EncodingProvider> object from the <xref:System.Text.CodePagesEncodingProvider.Instance%2A?displayProperty=nameWithType> property.

2. Pass the <xref:System.Text.EncodingProvider> object to the <xref:System.Text.Encoding.RegisterProvider%2A?displayProperty=nameWithType> method to make the additional encodings supported by the encoding provider available.

The <xref:System.Console> class will then automatically use the default system encoding rather than UTF8, provided that you have registered the encoding provider before calling any <xref:System.Console> output methods.

## Examples

The following example demonstrates how to read data from, and write data to, the standard input and output streams. Note that these streams can be redirected by using the <xref:System.Console.SetIn%2A> and <xref:System.Console.SetOut%2A> methods.

:::code language="csharp" source="./snippets/System/Console/Overview/csharp/source.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Console/Overview/vb/source.vb" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Console/Overview/fsharp/source.fs" id="Snippet1":::
