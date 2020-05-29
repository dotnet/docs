---
title: Create a .NET Standard class library in Visual Studio Code
description: Learn how to create a .NET Standard class library using Visual Studio Code.
ms.date: 05/29/2020
---
# Tutorial: Create a .NET Standard library in Visual Studio Code

A *class library* defines types and methods that are called by an application. A class library that targets .NET Standard 2.0 allows your library to be called by any .NET implementation that supports that version of .NET Standard. When you finish your class library, you can decide whether you want to distribute it as a NuGet package or include it as a bundled component with one or more applications.

> [!NOTE]
> For a list of .NET Standard versions and the platforms they support, see [.NET Standard](../../standard/net-standard.md).

In this tutorial, you create a simple utility library that contains a single string-handling method. You implement it as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class.

## Prerequisites

1. [Visual Studio Code](https://code.visualstudio.com/) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed. For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).
2. The [.NET Core 3.1 SDK or later](https://dotnet.microsoft.com/download)

## Create a solution

Start by creating a blank solution to put the class library project in. A solution serves as a container for one or more projects. You'll add additional, related projects to the same solution.

1. Open Visual Studio Code.

1. Select **File** > **Open Folder**/**Open...** from the main menu, create a *ClassLibraryProjects* folder, and click **Select Folder**/**Open**.

1. Open the **Terminal** in Visual Studio Code by selecting **View** > **Terminal** from the main menu.

   The **Terminal** opens with the command prompt in the *ClassLibraryProjects* folder.

1. In the **Terminal**, enter the following command:

   ```dotnetcli
   dotnet new sln
   ```

## Create a class library project

Add a new .NET Standard class library project named "StringLibrary" to the solution.

1. In the terminal, run the following command to create the library project:

   ```dotnetcli
   dotnet new classlib -o StringLibrary
   ```

1. Run the following command to add the library project to the solution:

   ```dotnetcli
   dotnet sln add StringLibrary/StringLibrary.csproj
   ```

1. Check to make sure that the library targets the correct version of .NET Standard. In **Explorer**, open *StringLibrary/StringLibrary.csproj*.

   The `TargetFramework` element shows that the project targets .NET Standard 2.0.

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>netstandard2.0</TargetFramework>
     </PropertyGroup>

   </Project>
   ```

1. Open *Class1.cs* and replace the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/StringLibrary/Class1.cs":::

   The class library, `UtilityLibraries.StringLibrary`, contains a method named `StartsWithUpper`. This method returns a <xref:System.Boolean> value that indicates whether the current string instance begins with an uppercase character. The Unicode standard distinguishes uppercase characters from lowercase characters. The <xref:System.Char.IsUpper(System.Char)?displayProperty=nameWithType> method returns `true` if a character is uppercase.

1. Save the file.

1. Run the following command to build the solution and verify that the project compiles without error.

   ```dotnetcli
   dotnet build
   ```

## Add a console app to the solution

Add a console application that uses the class library. The app will prompt the user to enter a string and report whether the string begins with an uppercase character.

1. In the terminal, run the following command to create the library project:

   ```dotnetcli
   dotnet new console -o ShowCase
   ```

1. Run the following command to add the console app project to the solution:

   ```dotnetcli
   dotnet sln add ShowCase/ShowCase.csproj
   ```

1. Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project by running the following command:

   ```dotnetcli
   dotnet add ShowCase/Showcase.csproj reference StringLibrary/StringLibrary.csproj
   ```

1. Open *ShowCase/Program.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/ShowCase/Program.cs":::

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the Enter key without entering a string, the application ends, and the console window closes.

1. Save your changes.

1. Run the program.

   ```dotnetcli
   dotnet run --project ShowCase/ShowCase.csproj
   ```

1. Try out the program by entering strings and pressing **Enter**, then press **Enter** to exit.

## Next steps

In this tutorial, you created a solution, added a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET Standard library with .NET Core in Visual Studio Code](testing-library-with-visual-studio-code.md)
