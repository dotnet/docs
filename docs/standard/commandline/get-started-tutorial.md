---
title: "Tutorial: Get started with System.CommandLine"
description: Learn how to use the System.CommandLine library for command-line apps.
ms.date: 04/07/2022
ms.topic: tutorial
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
---
# Tutorial: Get started with System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

This tutorial shows how to create a .NET command-line app that uses the [`System.CommandLine` library](index.md). You'll begin by creating a simple root command that has one option. Then you'll build on that base, creating a more complex app that contains multiple subcommands and different options for each command.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Create commands, options, and arguments.
> * Specify default values for options.
> * Assign options and arguments to commands.
> * Assign an option recursively to all subcommands under a command.
> * Work with multiple levels of nested subcommands.
> * Create aliases for commands and options.
> * Work with `string`, `string[]`, `int`, `bool`, `FileInfo`, and enum option types.
> * Read option values in command action code.
> * Use custom code for parsing and validating options.

## Prerequisites

[!INCLUDE [Prerequisites](../../../includes/prerequisites-basic.md)]

Or

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **.NET desktop development** workload installed.

## Create the app

Create a .NET 9 console app project named "scl".

1. Create a folder named *scl* for the project, and then open a command prompt in the new folder.

1. Run the following command:

   ```dotnetcli
   dotnet new console --framework net9.0
   ```

### Install the System.CommandLine package

* Run the following command:

  ```dotnetcli
  dotnet add package System.CommandLine --prerelease
  ```

  Or, in .NET 10+:

  ```dotnetcli
  dotnet package add System.CommandLine --prerelease
  ```

  The `--prerelease` option is necessary because the library is still in beta.

### Parse the arguments

1. Replace the contents of *Program.cs* with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage0/Program.cs" id="all" :::

The preceding code:

* Creates an [option](syntax.md#options) named `--file` of type <xref:System.IO.FileInfo> and adds it to the [root command](syntax.md#root-command):

  :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage1/Program.cs" id="symbols" :::

* Parses the `args` and checks whether any value was provided for `--file` option. If so, it calls the `ReadFile` method using parsed value and returns `0` exit code:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage0/Program.cs" id="parse" :::

* If no value was provided for `--file`, it prints available parse errors and returns `1` exit code:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage0/Program.cs" id="errors" :::

* The `ReadFile` method reads the specified file and displays its contents on the console:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage0/Program.cs" id="action" :::

## Test the app

You can use any of the following ways to test while developing a command-line app:

* Run the `dotnet build` command, and then open a command prompt in the *scl/bin/Debug/net9.0* folder to run the executable:

  ```console
  dotnet build
  cd bin/Debug/net9.0
  scl --file scl.runtimeconfig.json
  ```

* Use `dotnet run` and pass option values to the app instead of to the `run` command by including them after `--`, as in the following example:

  ```dotnetcli
  dotnet run -- --file bin/Debug/net9.0/scl.runtimeconfig.json
  ```

This tutorial assumes you're using the first of these options.

When you run the app, it displays the contents of the file specified by the `--file` option.

```output
{
  "runtimeOptions": {
    "tfm": "net9.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "9.0.0"
    }
  }
}
```

But what happens if you ask it to display the help by providing `--help`? Nothing gets printed to the console, because the app doesn't yet handle a scenario, where `--file` is not provided and there are no parse errors.

## Parse the arguments and invoke the ParseResult

System.CommandLine allows the users to specify an action that is invoked when given symbol (command, directive or option) is parsed successfully. The action is a delegate that takes a <xref:System.CommandLine.ParseResult> parameter and returns an `int` exit code (async actions are also [available](parse-and-invoke.md#asynchronous-actions)). The exit code is returned by the <xref:System.CommandLine.Parsing.ParseResult.Invoke> method and can be used to indicate whether the command was executed successfully or not.

1. Replace the contents of *Program.cs* with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage1/Program.cs" id="all" :::

The preceding code:

* Specifies that `ReadFile` is the method that will be called when the root command is **invoked**:

  :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage1/Program.cs" id="setaction" :::

* Parses the `args` and **invokes** the result:

  :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage1/Program.cs" id="invoke" :::

When you run the app, it displays the contents of the file specified by the `--file` option.

What happens if you ask it to display the help by providing `--help`?

```console
scl --help
```

Following output gets printed:

```output
Description:
  Sample app for System.CommandLine

Usage:
  scl [options]

Options:
  -?, -h, --help  Show help and usage information
  --version       Show version information
  --file          The file to read and display on the conso
```

<xref:System.CommandLine.RootCommand> by default provides [Help option](help.md#help-option), [Version option](syntax.md#version-option) and [Suggest directive](syntax.md#suggest-directive). `ParseResult.Invoke` method is responsible for invoking the action of parsed symbol. It could be the action explicitly defined for our command, or the help action defined by `System.CommandLine` for <xref:System.CommandLine.Help.HelpOption>. Moreover, when it detects any parse errors, it prints them to the standard error, prints help to standard output and returns `1` exit code:

```console
scl --invalid bla
```

```output
Unrecognized command or argument '--invalid'.
Unrecognized command or argument 'bla'.
```

## Add a subcommand and options

In this section, you:

* Create more options.
* Create a subcommand.
* Assign the new options to the new subcommand.

The new options will let you configure the foreground and background text colors and the readout speed. These features will be used to read a collection of quotes that comes from the [Teleprompter console app tutorial](../../csharp/tutorials/console-teleprompter.md).

1. Copy the [sampleQuotes.txt](https://github.com/dotnet/samples/raw/main/csharp/getting-started/console-teleprompter/sampleQuotes.txt) file from the GitHub repository for this sample into your project directory. For information on how to download files, see the instructions in [Samples and Tutorials](../../samples-and-tutorials/index.md#view-and-download-samples).

1. Open the project file and add an `<ItemGroup>` element just before the closing `</Project>` tag:

   ```xml
   <ItemGroup>
     <Content Include="sampleQuotes.txt">
       <CopyToOutputDirectory>Always</CopyToOutputDirectory>
     </Content>
   </ItemGroup>
   ```

   Adding this markup causes the text file to be copied to the *bin/debug/net9.0* folder when you build the app. So when you run the executable in that folder, you can access the file by name without specifying a folder path.

1. In *Program.cs*, after the code that creates the `--file` option, create options to control the readout speed and text colors:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="options" :::

1. After the line that creates the root command, delete the code that adds the `--file` option to it. You're removing it here because you'll add it to a new subcommand.

1. After the line that creates the root command, create a `read` subcommand. Add the options to this subcommand (by using collection initializer syntax rather than `Options` property), and add the subcommand to the root command.

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="subcommand" :::

1. Replace the `SetAction` code with the following `SetAction` code for the new subcommand:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="setaction" :::

   You're no longer calling `SetAction` on the root command because the root command no longer needs an action. When a command has subcommands, you typically have to specify one of the subcommands when invoking a command-line app.

1. Replace the `ReadFile` action method with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="action" :::

The app now looks like this:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="all" :::

### Test the new subcommand

Now if you try to run the app without specifying the subcommand, you get an error message followed by a help message that specifies the subcommand that is available.

```console
scl --file sampleQuotes.txt
```

```output
'--file' was not matched. Did you mean one of the following?
--help

Required command was not provided.
Unrecognized command or argument '--file'.
Unrecognized command or argument 'sampleQuotes.txt'.

Description:
  Sample app for System.CommandLine

Usage:
  scl [command] [options]

Options:
  -?, -h, --help  Show help and usage information
  --version       Show version information

Commands:
  read  Read and display the file.
```

The help text for subcommand `read` shows that four options are available. It shows valid values for the enum.

```console
scl read -h
```

```output
Description:
  Read and display the file.

Usage:
  scl read [options]

Options:
  --file <file>                                               The file to read and display on the console.
  --delay <delay>                                             Delay between lines, specified as milliseconds per
                                                              character in a line. [default: 42]
  --fgcolor                                                   Foreground color of text displayed on the console.
  <Black|Blue|Cyan|DarkBlue|DarkCyan|DarkGray|DarkGreen|Dark  [default: White]
  Magenta|DarkRed|DarkYellow|Gray|Green|Magenta|Red|White|Ye
  llow>
  --light-mode                                                Background color of text displayed on the console:
                                                              default is black, light mode is white.
  -?, -h, --help                                              Show help and usage information
```

Run subcommand `read` specifying only the `--file` option, and you get the default values for the other three options.

```console
scl read --file sampleQuotes.txt
```

The 42 milliseconds per character default delay causes a slow readout speed. You can speed it up by setting `--delay` to a lower number.

```console
scl read --file sampleQuotes.txt --delay 0
```

You can use `--fgcolor` and `--light-mode` to set text colors:

```console
scl read --file sampleQuotes.txt --fgcolor red --light-mode
```

Provide an invalid value for `--delay` and you get an error message:

```console
scl read --file sampleQuotes.txt --delay forty-two
```

```output
Cannot parse argument 'forty-two' for option '--int' as expected type 'System.Int32'.
```

Provide an invalid value for `--file` and you get an exception:

```console
scl read --file nofile
```

```output
Unhandled exception: System.IO.FileNotFoundException: Could not find file 'C:\bin\Debug\net9.0\nofile''.
File name: 'C:\bin\Debug\net9.0\nofile''
```

## Add subcommands and custom validation

This section creates the final version of the app. When finished, the app will have the following commands and options:

* root command with a recursive\* option named `--file`
  * `quotes` command
    * `read` command with options named `--delay`, `--fgcolor`, and `--light-mode`
    * `add` command with arguments named `quote` and `byline`
    * `delete` command with option named `--search-terms`

\* A recursive option is available to the command it's assigned to and recursively to all its subcommands.

Here's sample command line input that invokes each of the available commands with its options and arguments:

```console
scl quotes read --file sampleQuotes.txt --delay 40 --fgcolor red --light-mode
scl quotes add "Hello world!" "Nancy Davolio"
scl quotes delete --search-terms David "You can do" Antoine "Perfection is achieved"
```

1. In *Program.cs*, replace the code that creates the `--file` option with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="fileoption" :::

   This code uses <xref:System.CommandLine.Parsing.ArgumentResult> to provide custom parsing, validation, and error handling.

   Without this code, missing files are reported with an exception and stack trace. With this code just the specified error message is displayed.

   This code also specifies a default value, which is why it sets `DefaultValueFactory` to custom parsing method.

1. After the code that creates `lightModeOption`, add options and arguments for the `add` and `delete` commands:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="optionsandargs" :::

   The <xref:System.CommandLine.Option.AllowMultipleArgumentsPerToken> setting lets you omit the `--search-terms` option name when specifying elements in the list after the first one. It makes the following examples of command-line input equivalent:

   ```console
   scl quotes delete --search-terms David "You can do"
   scl quotes delete --search-terms David --search-terms "You can do"
   ```

1. Replace the code that creates the root command and the `read` command with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="commands" :::

   This code makes the following changes:

   * Removes the `--file` option from the `read` command.
   * Adds the `--file` option as a recursive option to the root command.

   * Creates a `quotes` command and adds it to the root command.
   * Adds the `read` command to the `quotes` command instead of to the root command.
   * Creates `add` and `delete` commands and adds them to the `quotes` command.

   The result is the following command hierarchy:

   * Root command
     * `quotes`
       * `read`
       * `add`
       * `delete`

   The app now implements the [recommended](design-guidance.md#symbols) pattern where the parent command (`quotes`) specifies an area or group, and its children commands (`read`, `add`, `delete`) are actions.

   Recursive options are applied to the command and recursively to subcommands. Since `--file` is on the root command, it will be available automatically in all subcommands of the app.

1. After the `SetAction` code, add new `SetAction` code for the new subcommands:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="setactions" :::

   Subcommand `quotes` doesn't have an action because it isn't a leaf command. Subcommands `read`, `add`, and `delete` are leaf commands under `quotes`, and `SetAction` is called for each of them.

1. Add the actions for `add` and `delete`.

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="actions" :::

The finished app looks like this:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="all" :::

Build the project, and then try the following commands.

Submit a nonexistent file to `--file` with the `read` command, and you get an error message instead of an exception and stack trace:

```console
scl quotes read --file nofile
```

```output
File does not exist
```

Try to run subcommand `quotes` and you get a message directing you to use `read`, `add`, or `delete`:

```console
scl quotes
```

```output
Required command was not provided.

Description:
  Work with a file that contains quotes.

Usage:
  scl quotes [command] [options]

Options:
  --file <file>   An option whose argument is parsed as a FileInfo [default: sampleQuotes.txt]
  -?, -h, --help  Show help and usage information

Commands:
  read                          Read and display the file.
  delete                        Delete lines from the file.
  add, insert <quote> <byline>  Add an entry to the file.
```

Run subcommand `add`, and then look at the end of the text file to see the added text:

```console
scl quotes add "Hello world!" "Nancy Davolio"
```

Run subcommand `delete` with search strings from the beginning of the file, and then look at the beginning of the text file to see where text was removed:

```console
scl quotes delete --search-terms David "You can do" Antoine "Perfection is achieved"
```

> [!NOTE]
> If you're running in the *bin/debug/net9.0* folder, that folder is where you'll find the file with changes from the `add` and `delete` commands. The copy of the file in the project folder remains unchanged.

## Next steps

In this tutorial, you created a simple command-line app that uses `System.CommandLine`. To learn more about the library, see [System.CommandLine overview](index.md).
