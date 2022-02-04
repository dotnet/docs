---
title: "Tutorial: Get started with System.CommandLine"
description: Learn how to use the System.CommandLine library for command-line apps.
ms.date: 01/25/2022
ms.topic: tutorial
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
---
# Tutorial: Get started with System.CommandLine

This tutorial shows how to create a .NET command-line app that uses the [`System.CommandLine` library](index.md). You'll begin by creating a simple root command that has one option. Then you'll add to that base, creating a more complex app that contains multiple subcommands and different options for each command.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Create commands, options, and arguments.
> * Specify default values for options.
> * Assign options and arguments to commands.
> * Assign an option recursively to all subcommands under a command.
> * Work with multiple levels of nested subcommands.
> * Create aliases for commands and options.
> * Work with `string`, `string[]`, `int`, `bool`, `FileInfo` and enum option types.
> * Bind option values to command handler code.
> * Use custom code for parsing and validating options.

## Prerequisites

* A code editor, such as [Visual Studio Code](https://code.visualstudio.com/) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).
* The [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).

The tutorial instructions show .NET CLI commands for project tasks, but you can use [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **.NET desktop development** workload installed if you prefer.

## Create the app

Create a .NET 6 console app project named "scl".

1. Create a folder named *scl* for the project, and then open a command prompt in the new folder.

1. Run the following command:

   ```dotnetcli
   dotnet new console --framework net6.0
   ```

## Install the System.CommandLine package

* Run the following command:

  ```dotnetcli
  dotnet add package System.CommandLine --prerelease
  ```

  The `-prerelease` option is necessary because the library is still in beta.

1. Replace the contents of *Program.cs* with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage1/Program.cs" :::

The preceding code:

* Creates an [option](syntax.md#options) named `--message` of type `string` and assigns it to the [root command](syntax.md#commands).
* Specifies that `DoRootCommand` is the method that will be called when the root command is invoked.
* Displays the value of the `--message` option when the root command is invoked.

## Test the app

You can use any of the following ways to invoke a command-line app and specify options:

* Run the `dotnet build`command, and then open a command prompt in the *scl/bin/Debug/net6.0* folder to run the executable:

  ```console
  dotnet build
  cd bin/Debug/net6.0
  scl --file scl.runtimeconfig.json
  ```

* Use `dotnet run` and pass values to the app instead of to the `run` command by including them after `--`, as in the following example:

  ```dotnetcli
  dotnet run -- --file scl.runtimeconfig.json
  ```

* [Publish the project to a folder](../../core/tutorials/publishing-with-visual-studio-code.md), open a command prompt to that folder, and run the executable:

  ```console
  scl --file scl.runtimeconfig.json
  ```

* In Visual Studio 2022, select **Debug** > **Debug Properties** from the menu, and enter the options in the **Command line arguments** box:

  > `--file scl.runtimeconfig.json`

  Then run the app, for example by pressing Ctrl+F5.

This tutorial assumes you're using the first of these options.

When you run it, the app displays the contents of the file specified by the `--file` option.

```output
{
  "runtimeOptions": {
    "tfm": "net6.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "6.0.0"
    }
  }
}
```

### Help output

`System.CommandLine` automatically provides help output:

```console
scl --help
```

```output
Description:
  Sample app for System.CommandLine

Usage:
  scl [options]

Options:
  --file <file>   The file to read and display on the console.
  --version       Show version information
  -?, -h, --help  Show help and usage information
```

### Version output

`System.CommandLine` automatically provides version output:

```console
scl --version
```

```output
1.0.0
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
     <None Update="sampleQuotes.txt">
       <CopyToOutputDirectory>Always</CopyToOutputDirectory>
     </None>
   </ItemGroup>
   ```

   This markup causes the text file to be copied to the *bin/debug/net6.0* folder when you build the app. So when you run the executable in that folder, you can access the file by name without specifying a folder path.

1. In *Program.cs*, after the code that creates the `--file` option, create options to control the readout speed and text colors:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="options" :::

1. After the line that creates the root command, delete the line that adds the `--file` option to it. You're removing it here because you'll add it to a new subcommand.

1. After the line that creates the root command, create a `read` subcommand. Add the options to this subcommand and add the subcommand to the root command.

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="subcommand" :::

1. After the code that creates the subcommand, replace the root command `SetHandler` code with the following `SetHandler` code for the new subcommand:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="sethandler" :::

   Since you've created a subcommand, the root command no longer needs a handler. If a command has subcommands, you typically have to specify one of the subcommands when invoking a command-line app.

1. Replace the `ReadFile` handler method with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="handler" :::

The app now looks like this:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage2/Program.cs" id="all" :::

## Test the new subcommand

Now if you try to run the app without specifying the subcommand, you get an error message followed by a help message that specifies the subcommand that is available.

```console
scl --file sampleQuotes.txt
```

```output
Required command was not provided.

Description:
  Sample app for System.CommandLine

Usage:
  scl [command] [options]

Options:
  --message <string>  An option whose argument is parsed as a string
  --version          Show version information
  -?, -h, --help     Show help and usage information

Commands:
  read  Read and display the file.
```

The help text for subcommand `read` shows that four options are available. It shows default values and valid values for the enum.

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

Run subcommand `sub1` specifying only the file option, and you get the default values for the other three.

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
Unhandled exception: System.IO.FileNotFoundException:
Could not find file 'C:\bin\Debug\net6.0\nofile'.
```

## Add subcommands and custom validation

This section creates the final version of the app. When finished, the app will have the following commands and options:

* root command with a global\* option named `--file`
  * `quotes` command
    * `read` command with options named `--delay`, `--fgcolor`, and `--light-mode`
    * `add` command with arguments named `quote` and `byline`
    * `delete` command with option named `--search-terms`

\* A global option is available to the command it's assigned to and recursively to all its subcommands.

Here's sample command line input to invoke each of the available commands with its options:

```console
scl quotes read --file sampleQuotes.txt --delay 40 --fgcolor red --light-mode
scl quotes add "Hello world!" Nancy
scl quotes delete --search-terms David "You can do" Antoine "Perfection is achieved"
```

1. In *Program.cs*, replace the code that creates the `--file` option with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="fileoption" :::

   This code uses `ParseArgument<T>` to provide custom parsing and validation. The code also specifies a default value, which is why it sets `isDefault` to `true`. If you don't set `isDefault` to `true`, the `parseArgument` delegate doesn't get called when no input is provided for `--file`.

1. After the code that creates `lightModeOption`, add options and arguments for the `add` and `delete` commands:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="optionsandarguments" :::

   The `AllowMultipleArgumentsPerToken` setting lets you omit the `--search-terms` option name when specifying elements in the list after the first one. It makes the following examples of command-line input equivalent:

   ```console
   scl quotes delete --search-terms David "You can do"
   scl quotes delete --search-terms David --search-terms "You can do"
   ```

1. Replace the code that creates the root command and the `read` command with the following code:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="commands" :::

   This code makes the following changes:

   * Removes the `--file` option from the `read` command.
   * Adds the `--file` option as a global option to the root command.

   * Creates a `quotes` command and adds it to the root command.
   * Adds the `read` command to the `quotes` command instead of to the root command.
   * Creates `add` and `delete` commands and adds them to the `quotes` command.

   The result is the following command hierarchy:

   * Root command
     * `quotes`
       * `read`
       * `add`
       * `delete`

   The app now implements the recommended pattern where the parent command specifies an area or group, and its children commands are actions.

   Global options are applied to the command and recursively to subcommands. Since `--file` is on the root command, it will be available automatically in all subcommands of the app.

1. After the `SetHandler` code, add new `SetHandler` code for the new subcommands:

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="sethandlers" :::

   Subcommand `write` doesn't have a handler because it isn't a leaf command. Subcommands `add` and `delete` are leaf commands under `write`, and `SetHandler` is called for each of them.

1. Add handlers for `add` and `delete`.

   :::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="handlers" :::

The finished app looks like this:

:::code language="csharp" source="snippets/get-started-tutorial/csharp/Stage3/Program.cs" id="all" :::

Try the following commands.

Submit a nonexistent file to `--file` with the `read` command, and you get an error message instead of an exception and stack trace:

```console
scl read --file nofile
```

```output
File does not exist
```

Try to run subcommand `quotes` and you get a message directing you to use `add` or `delete`:

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
scl quotes add "Hello world!" Nancy
```

Run subcommand `delete` with search strings from the beginning of the file, and then look at the beginning of the text file to see where text was removed:

```console
scl quotes delete --search-terms David "You can do" Antoine "Perfection is achieved"
```

> [!NOTE]
> If you're running in the *bin/debug/net6.0* folder, that folder is where you'll find the file with changes from the `add` or `delete` commands. The copy of the file in the project folder remains unchanged.

## Next steps

In this tutorial, you created a simple command-line app that uses `System.CommandLine`. To learn more about the library, see [System.CommandLine overview](index.md).
