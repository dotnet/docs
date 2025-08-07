---
title: Build file-based programs
description: File-based programs are command line utilities that are built and execute without a project file. The build and run commands are implicit. New syntax supports project settings in source.
ms.date: 08/08/2025
ms.topic: tutorial
#customer intent: As a developer, I want build utilities so that more work is automated.
---

# Tutorial: Build file-based C# programs

> [!IMPORTANT]
>
> File-based programs are a feature of .NET 10, which is in preview.
> Some information relates to prerelease product that may be modified before it's released. Microsoft makes no warranties, express or implied, with respect to the information provided here.

*File-based programs* are programs contained within a single `*.cs` file that are built and run without a corresponding project (`*.csproj`) file. File-based programs are ideal for learning C# because they have less complexity: The entire program is stored in a single file. File-based programs are also useful for building command line utilities. On Unix platforms, file-based programs can be executed using `#!` (shebang) directives.

In this tutorial, you:

> [!div class="checklist"]
>
> * Create a file-based program
> * Run the program using the .NET CLI and `#!` directives
> * Add features and NuGet packages to the program
> * Test the final application

## Prerequisites

- The .NET 10 preview SDK. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet/10.0).
- Visual Studio Code. Download it from the [Visual Studio Code homepage](https://code.visualstudio.com/Download).
- (Optional) The C# DevKit extension for Visual Studio Code. Download it from the [Visual Studio Code marketplace](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Create a file-based program

Open Visual Studio code and create a new file named `AsciiArt.cs`. Enter the following text:

```csharp
Console.WriteLine("Hello, world!");
```

Save the file. Then, open the integrated terminal in Visual Studio code and type:

```dotnetcli
dotnet run AsciiArt.cs
```

The first time you run this program, the `dotnet` host builds the executable from your source file, stores that executable in a temporary folder, then runs the executable. You can verify this by typing `dotnet run AsciiArt.cs` again. This time, the `dotnet` host determines that the executable is current, and just runs the executable without building it again. You won't see any build output. The executable runs without the delay for a build.

The preceding steps demonstrates that file based programs aren't script files. They are C# source files that are built using a default project file in a temporary folder. One of the lines of output when you built the program should look something like this (on Windows):

```dotnetcli
AsciiArt succeeded (7.3s) → AppData\Local\Temp\dotnet\runfile\AsciiArt-85c58ae0cd68371711f06f297fa0d7891d0de82afde04d8c64d5f910ddc04ddc\bin\debug\AsciiArt.dll
```

On unix platforms, the output folder is something similar to:

```dotnetcli
AsciiArt succeeded (7.3s) → Library/Application Support/dotnet/runfile/AsciiArt-85c58ae0cd68371711f06f297fa0d7891d0de82afde04d8c64d5f910ddc04ddc/bin/debug/AsciiArt.dll
```

That output tells you where the temporary files and build outputs are placed. Throughout this tutorial anytime you edit the source file, the `dotnet` host updates the executable before it runs.

File based programs are regular C# programs. The only limitation is that they must be written in one source file. You can use top-level statements or a classic `Main` method as an entry point. You can declare any types: classes, interfaces, and structs. You can structure the algorithms in a file based program the same as you would in any C# program. You can even declare multiple namespaces to organize your code.

In this tutorial, you'll build a file-based program that writes text as ASCII art. You'll learn how to include packages in file-based programs, process command input, and read arguments either from the command line or standard input.

As a first step, let's write all arguments on the command line to the output. Replace the current contents of `AsciiArt.cs` with the following code:

```csharp
if (args.Length > 0)
{
    string message = string.Join(' ', args);
    Console.WriteLine(message);
}
```

You can run this version by typing the following command:

```dotnetcli
dotnet run AsciiArt.cs -- This is the command line.
```

The `--` option indicates that all following command arguments should be passed to the AsciiArt program. The arguments `This is the command line.` are passed as an array of strings, where each string is one word: `This`, `is`, `the`, `command` and `line.`.

This version demonstrates several new concepts:

1. The command line arguments are passed to the program using the predefined variable `args`. This is an array of strings (`string[]`). If the length of `args` is 0, that means no arguments were provided. Otherwise, each word on the argument list is stored in the corresponding entry in the array.
1. The `string.Join` method joins multiple strings into a single string, with the specfied separator. In this case, the separator is a single space.

That handles command line arguments correctly. Now, add the code to handle reading input from standard input (`stdin`) instead of command line arguments. Add the following `else` clause to the `if` statement you added in the preceding code:

```csharp
else
{
    while (Console.ReadLine() is string line && line.Length > 0)
    {
        Console.WriteLine(line);
    }
}
```

You can test this by creating a new text file in the same folder. Name the file `input.txt` and add the following lines:

```text
This is the input file
for a file based program.
It prints the messages
from a file or the
command line.
There are options you
can choose for ASCII
art and colors.
```

Keep the lines short so they format correctly when you add the feature to use ASCII art. Now, run the program again:

```dotnetcli
cat input.txt | dotnet run AsciiArt.cs
```

Now your program can accept either command line arguments or standard input.

> [!NOTE]
>
> Support for `#!` directives applies on unix platforms only. There isn't a similar directive for Windows to directly execute a C# program. On Windows you must use `dotnet run` on the command line.

On unix, you can run file-based programs directly, typing the source file name on the command line instead of `dotnet run`. You need to make two changes. First, set *execute* permissions on the source file:

```bash
chmod +x AsciiArt.cs
```

Then, add a `#!` directive as the first line of the `AsciiArt.cs` file:

```csharp
#!/usr/local/share/dotnet/dotnet run
```

The location of `dotnet` may be different on different unix installations.

After making these two changes, you can run the program from the command line directly:

```bash
./AsciiArt.cs
```

If you prefer, you can rename the file to remove the extension.

## Add features and NuGet packages to the program

Next, add a package that supports ASCII art, [Colorful.Console](https://www.nuget.org/packages/Colorful.Console). To add a package to a file based program, you use the `#:package` directive. Add the following directive after the `#!` directive in your AsciiArt.cs file:

```csharp
#:package Colorful.Console@1.2.15
```

> [!IMPORTANT]
>
> The version `1.2.15` was the latest version when this tutorial was last updated. If there is a newer version available, use the latest version to ensure you have the latest security packages.

Next, change the lines that call `Console.WriteLine` to use the `Colorful.Console.WriteAscii` method instead:

```csharp
Colorful.Console.WriteAscii(message);
```

Next, let's add command line parsing. The current version writes each work as a different line of output. The tool doesn't support any command line options. We like to support two new features:

1. Quote multiple words that should be written on one line:

   ```dotnetcli
   AsciiArt.cs "This is line one" "This is another line" "This is the last line"
   ```

1. Add a `--delay` option to pause between each line:

   ```dotnetcli
   AsciiArt.cs --delay 1000
   ```

Users should be able to use both.

Most command line applications need to parse command line arguments to handle options, commands, and user input effectively. The [`System.CommandLine` library](../../../standard/commandline/index.md) provides comprehensive capabilities to handle commands, subcommands, options, and arguments, allowing you to concentrate on what your application does rather than the mechanics of parsing command line input.

The `System.CommandLine` library offers several key benefits:

- Automatic help text generation and validation
- Support for POSIX and Windows command-line conventions  
- Built-in tab completion capabilities
- Consistent parsing behavior across applications

To add command line parsing capabilities, first add the `System.CommandLine` package. Add this directive after the existing package directive:

```csharp
#:package System.CommandLine@2.0.0-beta6
```

> [!IMPORTANT]
>
> The version `2.0.0-beta6` was the latest version when this tutorial was last updated. If there is a newer version available, use the latest version to ensure you have the latest security packages.

Next, add the necessary using statements at the top of your file (after the `#!` and `#:package` directives):

```csharp
using System.CommandLine;
using System.CommandLine.Parsing;
```

Define the delay option and messages argument. In command-line applications, options typically begin with `--` (double dash) and can accept arguments. The `--delay` option accepts an integer argument that specifies the delay in milliseconds. The `messagesArgument` defines how any remaining tokens after options are parsed as text. Each token becomes a separate string in the array, but text can be quoted to include multiple words in one token. For example, `"This is one message"` becomes a single token, while `This is four tokens` becomes four separate tokens. Add the following code:

```csharp
Option<int> delayOption = new("--delay")
{
    Description = "Delay between lines, specified as milliseconds.",
    DefaultValueFactory = parseResult => 100
};

Argument<string[]> messagesArgument = new("Messages")
{
    Description = "Text to render."
};
```

This application has only one root command, so you'll add the argument and option directly to the root command. Create a root command and configure it with the option and argument:

```csharp
RootCommand rootCommand = new("Ascii Art file-based program sample");

rootCommand.Options.Add(delayOption);
rootCommand.Arguments.Add(messagesArgument);
```

Parse the command line arguments and handle any errors. This validates the command line arguments and stores parsed arguments in the `ParseResult` object:

```csharp
ParseResult result = rootCommand.Parse(args);
foreach (ParseError parseError in result.Errors)
{
    Console.Error.WriteLine(parseError.Message);
}
if (result.Errors.Count > 0)
{
    return 1;
}
```

## Use parsed command line results

Now, let's finish the utility to use the parsed options and write the output. First, define a record to hold the parsed options. File-based apps can include type declarations, like records. They must be after all top-level statements and local functions. Add a `record` declaration to store the messages and the delay option value:

```csharp
public record AsciiMessageOptions(string[] Messages, int Delay);
```

Now that you've declared the record to store those results, add a local function to process the parse results and store the values in an instance of the record. Add the following local function before the record declaration. This method handles both command line arguments and standard input, and returns a new record instance:

```csharp
async Task<AsciiMessageOptions> ProcessParseResults(ParseResult result)
{
    int delay = result.GetValue(delayOption);
    List<string> messages = [.. result.GetValue(messagesArgument) ?? Array.Empty<string>()];

    if (messages.Count == 0)
    {
        while (Console.ReadLine() is string line && line.Length > 0)
        {
            Colorful.Console.WriteAscii(line);
            await Task.Delay(delay);
        }
    }
    return new ([..messages], delay);
}
```

Next, create a local function to write the ASCII art with the specified delay. This function writes each message in the record with the specified delay between each message:

```csharp
async Task WriteAsciiArt(AsciiMessageOptions options)
{
    foreach(string message in options.Messages)
    {
        Colorful.Console.WriteAscii(message);
        await Task.Delay(options.Delay);
    }
}
```

Finally, replace the `if` clause you wrote earlier with the following code to write the process the command line arguments and write the output:

```csharp
var parsedArgs = await ProcessParseResults(result);

await WriteAsciiArt(parsedArgs);
return 0;
```

## Test the final application

Test the application by running several different commands. If you have trouble, here's the finished sample to compare with what you built:

:::code language="csharp" source="./snippets/file-based-programs/AsciiArt.cs":::

In this tutorial, you learned to build a file-based program, where you build the program in a single C# file. These utilities don't need a project file, and can use the `#!` directive on unix systems. These programs provide a learning platform between our [online tutorials](../../tour-of-csharp/tutorials/hello-world.md) and larger project-based programs. They also are a great platform for smaller command line utilitie.

## Related content

- [Top level statement](../program-structure/top-level-statements.md)
- [Preprocessor directives](../../language-reference/preprocessor-directives.md#file-based-programs)
- [What's new in C# 14](../../whats-new/csharp-14.md)
