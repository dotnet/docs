---
title: Create a .NET class library using Visual Studio Code
description: Learn how to create a .NET class library using Visual Studio Code.
ms.date: 10/25/2021
zone_pivot_groups: dotnet-version
recommendations: false
---
# Tutorial: Create a .NET class library using Visual Studio Code

::: zone pivot="dotnet-6-0"

In this tutorial, you create a simple utility library that contains a single string-handling method.

A *class library* defines types and methods that are called by an application. If the library targets .NET Standard 2.0, it can be called by any .NET implementation (including .NET Framework) that supports .NET Standard 2.0. If the library targets .NET 6, it can be called by any application that targets .NET 6. This tutorial shows how to target .NET 6.

When you create a class library, you can distribute it as a third-party component or as a bundled component with one or more applications.

## Prerequisites

* [Visual Studio Code](https://code.visualstudio.com/) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed. For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).
* The [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).

## Create a solution

Start by creating a blank solution to put the class library project in. A solution serves as a container for one or more projects. You'll add additional, related projects to the same solution.

1. Start Visual Studio Code.

1. Select **File** > **Open Folder** (**Open...** on macOS) from the main menu

1. In the **Open Folder** dialog, create a *ClassLibraryProjects* folder and click **Select Folder** (**Open** on macOS).

1. Open the **Terminal** in Visual Studio Code by selecting **View** > **Terminal** from the main menu.

   The **Terminal** opens with the command prompt in the *ClassLibraryProjects* folder.

1. In the **Terminal**, enter the following command:

   ```dotnetcli
   dotnet new sln
   ```

   The terminal output looks like the following example:

   ```output
   The template "Solution File" was created successfully.
   ```

## Create a class library project

Add a new .NET class library project named "StringLibrary" to the solution.

1. In the terminal, run the following command to create the library project:

   ```dotnetcli
   dotnet new classlib -o StringLibrary
   ```

   The `-o` or `--output` command specifies the location to place the generated output.

   The terminal output looks like the following example:

   ```output
   The template "Class library" was created successfully.
   Processing post-creation actions...
   Running 'dotnet restore' on StringLibrary\StringLibrary.csproj...
     Determining projects to restore...
     Restored C:\Projects\ClassLibraryProjects\StringLibrary\StringLibrary.csproj (in 328 ms).
   Restore succeeded.
   ```

1. Run the following command to add the library project to the solution:

   ```dotnetcli
   dotnet sln add StringLibrary/StringLibrary.csproj
   ```

   The terminal output looks like the following example:

   ```output
   Project `StringLibrary\StringLibrary.csproj` added to the solution.
   ```

1. Check to make sure that the library targets .NET 6. In **Explorer**, open *StringLibrary/StringLibrary.csproj*.

   The `TargetFramework` element shows that the project targets .NET 6.0.

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>net6.0</TargetFramework>
     </PropertyGroup>

   </Project>
   ```

1. Open *Class1.cs* and replace the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/StringLibrary/Class1.cs":::

   The class library, `UtilityLibraries.StringLibrary`, contains a method named `StartsWithUpper`. This method returns a <xref:System.Boolean> value that indicates whether the current string instance begins with an uppercase character. The Unicode standard distinguishes uppercase characters from lowercase characters. The <xref:System.Char.IsUpper(System.Char)?displayProperty=nameWithType> method returns `true` if a character is uppercase.

   `StartsWithUpper` is implemented as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class.

1. Save the file.

1. Run the following command to build the solution and verify that the project compiles without error.

   ```dotnetcli
   dotnet build
   ```

   The terminal output looks like the following example:

   ```output
   Microsoft (R) Build Engine version 16.7.0+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     StringLibrary -> C:\Projects\ClassLibraryProjects\StringLibrary\bin\Debug\net6.0\StringLibrary.dll
   Build succeeded.
       0 Warning(s)
       0 Error(s)
   Time Elapsed 00:00:02.78
   ```

## Add a console app to the solution

Add a console application that uses the class library. The app will prompt the user to enter a string and report whether the string begins with an uppercase character.

1. In the terminal, run the following command to create the console app project:

   ```dotnetcli
   dotnet new console -o ShowCase
   ```

   The terminal output looks like the following example:

   ```output
   The template "Console Application" was created successfully.
   Processing post-creation actions...
   Running 'dotnet restore' on ShowCase\ShowCase.csproj...  
     Determining projects to restore...
     Restored C:\Projects\ClassLibraryProjects\ShowCase\ShowCase.csproj (in 210 ms).
   Restore succeeded.
   ```

1. Run the following command to add the console app project to the solution:

   ```dotnetcli
   dotnet sln add ShowCase/ShowCase.csproj
   ```

   The terminal output looks like the following example:

   ```output
   Project `ShowCase\ShowCase.csproj` added to the solution.
   ```

1. Open *ShowCase/Program.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/ShowCase/Program.cs":::

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the <kbd>Enter</kbd> key without entering a string, the application ends, and the console window closes.

1. Save your changes.

## Add a project reference

Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project.

1. Run the following command:

   ```dotnetcli
   dotnet add ShowCase/ShowCase.csproj reference StringLibrary/StringLibrary.csproj
   ```

   The terminal output looks like the following example:

   ```output
   Reference `..\StringLibrary\StringLibrary.csproj` added to the project.
   ```

## Run the app

1. Run the following command in the terminal:

   ```dotnetcli
   dotnet run --project ShowCase/ShowCase.csproj
   ```

1. Try out the program by entering strings and pressing <kbd>Enter</kbd>, then press <kbd>Enter</kbd> to exit.

   The terminal output looks like the following example:

   ```output
   Press <Enter> only to exit; otherwise, enter a string and press <Enter>:

   A string that starts with an uppercase letter
   Input: A string that starts with an uppercase letter
   Begins with uppercase? : Yes

   a string that starts with a lowercase letter
   Input: a string that starts with a lowercase letter
   Begins with uppercase? : No
   ```

## Additional resources

* [Develop libraries with the .NET CLI](libraries.md)
* [.NET Standard versions and the platforms they support](../../standard/net-standard.md).

## Next steps

In this tutorial, you created a solution, added a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET class library with .NET using Visual Studio Code](testing-library-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-5-0"

In this tutorial, you create a simple utility library that contains a single string-handling method.

A *class library* defines types and methods that are called by an application. If the library targets .NET Standard 2.0, it can be called by any .NET implementation (including .NET Framework) that supports .NET Standard 2.0. If the library targets .NET 5, it can be called by any application that targets .NET 5. This tutorial shows how to target .NET 5.

When you create a class library, you can distribute it as a third-party component or as a bundled component with one or more applications.

## Prerequisites

1. [Visual Studio Code](https://code.visualstudio.com/) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed. For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).
2. The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download)

## Create a solution

Start by creating a blank solution to put the class library project in. A solution serves as a container for one or more projects. You'll add additional, related projects to the same solution.

1. Start Visual Studio Code.

1. Select **File** > **Open Folder** (**Open...** on macOS) from the main menu

1. In the **Open Folder** dialog, create a *ClassLibraryProjects* folder and click **Select Folder** (**Open** on macOS).

1. Open the **Terminal** in Visual Studio Code by selecting **View** > **Terminal** from the main menu.

   The **Terminal** opens with the command prompt in the *ClassLibraryProjects* folder.

1. In the **Terminal**, enter the following command:

   ```dotnetcli
   dotnet new sln
   ```

   The terminal output looks like the following example:

   ```output
   The template "Solution File" was created successfully.
   ```

## Create a class library project

Add a new .NET class library project named "StringLibrary" to the solution.

1. In the terminal, run the following command to create the library project:

   ```dotnetcli
   dotnet new classlib -o StringLibrary
   ```

   The `-o` or `--output` command specifies the location to place the generated output.

   The terminal output looks like the following example:

   ```output
   The template "Class library" was created successfully.
   Processing post-creation actions...
   Running 'dotnet restore' on StringLibrary\StringLibrary.csproj...
     Determining projects to restore...
     Restored C:\Projects\ClassLibraryProjects\StringLibrary\StringLibrary.csproj (in 328 ms).
   Restore succeeded.
   ```

1. Run the following command to add the library project to the solution:

   ```dotnetcli
   dotnet sln add StringLibrary/StringLibrary.csproj
   ```

   The terminal output looks like the following example:

   ```output
   Project `StringLibrary\StringLibrary.csproj` added to the solution.
   ```

1. Check to make sure that the library targets .NET 5. In **Explorer**, open *StringLibrary/StringLibrary.csproj*.

   The `TargetFramework` element shows that the project targets .NET 5.0.

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>net5.0</TargetFramework>
     </PropertyGroup>

   </Project>
   ```

1. Open *Class1.cs* and replace the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/StringLibrary/Class1.cs":::

   The class library, `UtilityLibraries.StringLibrary`, contains a method named `StartsWithUpper`. This method returns a <xref:System.Boolean> value that indicates whether the current string instance begins with an uppercase character. The Unicode standard distinguishes uppercase characters from lowercase characters. The <xref:System.Char.IsUpper(System.Char)?displayProperty=nameWithType> method returns `true` if a character is uppercase.

   `StartsWithUpper` is implemented as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class. The question mark (`?`) after `string` indicates that the string may be null.

1. Save the file.

1. Run the following command to build the solution and verify that the project compiles without error.

   ```dotnetcli
   dotnet build
   ```

   The terminal output looks like the following example:

   ```output
   Microsoft (R) Build Engine version 16.7.0+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     StringLibrary -> C:\Projects\ClassLibraryProjects\StringLibrary\bin\Debug\net5.0\StringLibrary.dll
   Build succeeded.
       0 Warning(s)
       0 Error(s)
   Time Elapsed 00:00:02.78
   ```

## Add a console app to the solution

Add a console application that uses the class library. The app will prompt the user to enter a string and report whether the string begins with an uppercase character.

1. In the terminal, run the following command to create the console app project:

   ```dotnetcli
   dotnet new console -o ShowCase
   ```

   The terminal output looks like the following example:

   ```output
   The template "Console Application" was created successfully.
   Processing post-creation actions...
   Running 'dotnet restore' on ShowCase\ShowCase.csproj...  
     Determining projects to restore...
     Restored C:\Projects\ClassLibraryProjects\ShowCase\ShowCase.csproj (in 210 ms).
   Restore succeeded.
   ```

1. Run the following command to add the console app project to the solution:

   ```dotnetcli
   dotnet sln add ShowCase/ShowCase.csproj
   ```

   The terminal output looks like the following example:

   ```output
   Project `ShowCase\ShowCase.csproj` added to the solution.
   ```

1. Open *ShowCase/Program.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/ShowCase/Program.cs":::

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the <kbd>Enter</kbd> key without entering a string, the application ends, and the console window closes.

1. Save your changes.

## Add a project reference

Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project.

1. Run the following command:

   ```dotnetcli
   dotnet add ShowCase/ShowCase.csproj reference StringLibrary/StringLibrary.csproj
   ```

   The terminal output looks like the following example:

   ```output
   Reference `..\StringLibrary\StringLibrary.csproj` added to the project.
   ```

## Run the app

1. Run the following command in the terminal:

   ```dotnetcli
   dotnet run --project ShowCase/ShowCase.csproj
   ```

1. Try out the program by entering strings and pressing <kbd>Enter</kbd>, then press <kbd>Enter</kbd> to exit.

   The terminal output looks like the following example:

   ```output
   Press <Enter> only to exit; otherwise, enter a string and press <Enter>:

   A string that starts with an uppercase letter
   Input: A string that starts with an uppercase letter
   Begins with uppercase? : Yes

   a string that starts with a lowercase letter
   Input: a string that starts with a lowercase letter
   Begins with uppercase? : No
   ```

## Additional resources

* [Develop libraries with the .NET CLI](libraries.md)
* [.NET Standard versions and the platforms they support](../../standard/net-standard.md).

## Next steps

In this tutorial, you created a solution, added a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET class library with .NET using Visual Studio Code](testing-library-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-core-3-1"

This tutorial is only available for .NET 5 and .NET 6. Select one of those options at the top of the page.

::: zone-end
