---
title: "Hello World -- Your first program - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "cs.program"
  - "vs.csharp.startpage.firstapplication"
helpviewer_keywords: 
  - "examples [C#], Hello World"
  - "Hello World example [C#]"
ms.assetid: 6493182a-b0b6-4539-a719-518a168cb730
---
# Hello World -- Your first program (C# Programming Guide)

The following procedure creates a C# version of the traditional "Hello World!" program. The program displays the string `Hello World!`

For more examples of introductory concepts, see [Getting Started with Visual C# and Visual Basic](/visualstudio/ide/getting-started-with-visual-csharp-and-visual-basic).

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## To create and run a console application

1. Start Visual Studio.

2. On the menu bar, choose **File**, **New**, **Project**.

     The **New Project** dialog box opens.

3. Expand **Installed**, expand **Templates**, expand **Visual C#**, and then choose **Console Application**.

4. In the **Name** box, specify a name for your project, and then choose the **OK** button.

     The new project appears in **Solution Explorer**.

5. If Program.cs isn't open in the **Code Editor**, open the shortcut menu for **Program.cs** in **Solution Explorer**, and then choose **View Code**.

6. Replace the contents of Program.cs with the following code.

     [!code-csharp[csProgGuide#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#21)]

7. Choose the F5 key to run the project. A Command Prompt window appears that contains the line `Hello World!`

Next, the important parts of this program are examined.

## Comments

The first line contains a comment. The characters `//` convert the rest of the line to a comment.

 [!code-csharp[csProgGuide#32](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#32)]

You can also comment out a block of text by enclosing it between the `/*` and `*/` characters. This is shown in the following example.

 [!code-csharp[csProgGuide#33](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#33)]

## Main method

A C# console application must contain a `Main` method, in which control starts and ends. The `Main` method is where you create objects and execute other methods.

The `Main` method is a [static](../../../csharp/language-reference/keywords/static.md) method that resides inside a class or a struct. In the previous "Hello World!" example, it resides in a class named `Hello`. You can declare the `Main` method in one of the following ways:

- It can return `void`.

     [!code-csharp[csProgGuideMain#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideMain/CS/Class3.cs#12)]

- It can also return an integer.

     [!code-csharp[csProgGuideMain#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideMain/CS/Class3.cs#13)]

- With either of the return types, it can take arguments.

     [!code-csharp[csProgGuideMain#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideMain/CS/Class3.cs#19)]

     -or-

     [!code-csharp[csProgGuideMain#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideMain/CS/Class3.cs#18)]

The parameter of the `Main` method, `args`, is a `string` array that contains the command-line arguments used to invoke the program. Unlike in C++, the array does not include the name of the executable (exe) file.

For more information about how to use command-line arguments, see the examples in [Main() and Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/index.md) and [How to: Create and Use Assemblies Using the Command Line](../../../csharp/programming-guide/concepts/assemblies-gac/how-to-create-and-use-assemblies-using-the-command-line.md).

The call to <xref:System.Console.ReadKey%2A> at the end of the `Main` method prevents the console window from closing before you have a chance to read the output when you run your program in debug mode, by pressing F5.

## Input and output

C# programs generally use the input/output services provided by the run-time library of the .NET Framework. The statement `System.Console.WriteLine("Hello World!");` uses the <xref:System.Console.WriteLine%2A> method. This is one of the output methods of the <xref:System.Console> class in the run-time library. It displays its string parameter on the standard output stream followed by a new line. Other <xref:System.Console> methods are available for different input and output operations. If you include the `using System;` directive at the beginning of the program, you can directly use the <xref:System> classes and methods without fully qualifying them. For example, you can call `Console.WriteLine` instead of `System.Console.WriteLine`:

 [!code-csharp[csProgGuide#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/using.cs#1)]

 [!code-csharp[csProgGuide#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuide/CS/progGuide.cs#23)]

For more information about input/output methods, see <xref:System.IO>.

## Command-line compilation and execution

You can compile the "Hello World!" program by using the command line instead of the Visual Studio Integrated Development Environment (IDE).

### To compile and run from a command prompt

1. Paste the code from the preceding procedure into any text editor, and then save the file as a text file. Name the file `Hello.cs`. C# source code files use the extension `.cs`.

2. Perform one of the following steps to open a command-prompt window:

    - In Windows 10, on the **Start** menu, search for `Developer Command Prompt`, and then tap or choose **Developer Command Prompt for VS 2017**.

         A Developer Command Prompt window appears.

    - In Windows 7, open the **Start** menu, expand the folder for the current version of Visual Studio, open the shortcut menu for **Visual Studio Tools**, and then choose **Developer Command Prompt for VS 2017**.

         A Developer Command Prompt window appears.

    - Enable command-line builds from a standard Command Prompt window.

         See [How to: Set Environment Variables for the Visual Studio Command Line](../../../csharp/language-reference/compiler-options/how-to-set-environment-variables-for-the-visual-studio-command-line.md).

3. In the command-prompt window, navigate to the folder that contains your `Hello.cs` file.

4. Enter the following command to compile `Hello.cs`.

     `csc Hello.cs`

     If your program has no compilation errors, an executable file that is named `Hello.exe` is created.

5. In the command-prompt window, enter the following command to run the program:

     `Hello`

 For more information about the C# compiler and its options, see [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md).

## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Inside a C# Program](../../../csharp/programming-guide/inside-a-program/index.md)
- [Strings](../../../csharp/programming-guide/strings/index.md)
- [Samples and tutorials](../../../samples-and-tutorials/index.md)
- [C# Reference](../../../csharp/language-reference/index.md)
- [Main() and Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/index.md)
- [Getting Started with Visual C# and Visual Basic](/visualstudio/ide/getting-started-with-visual-csharp-and-visual-basic)