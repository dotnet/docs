---
title: Create a .NET class library using Visual Studio Code
description: Learn how to create a .NET class library using Visual Studio Code.
ms.date: 06/14/2024
zone_pivot_groups: dotnet-version
---
# Tutorial: Create a .NET class library using Visual Studio Code

::: zone pivot="dotnet-8-0"

In this tutorial, you create a simple utility library that contains a single string-handling method.

A *class library* defines types and methods that are called by an application. If the library targets .NET Standard 2.0, it can be called by any .NET implementation (including .NET Framework) that supports .NET Standard 2.0. If the library targets .NET 8, it can be called by any application that targets .NET 8. This tutorial shows how to target .NET 8.

When you create a class library, you can distribute it as a third-party component or as a bundled component with one or more applications.

## Prerequisites

* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) installed.

  For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).

* The [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

## Create a class library project

Start by creating a .NET class library project named "StringLibrary" and an associated solution. A solution serves as a container for one or more projects. You'll add additional, related projects to the same solution.

1. Start Visual Studio Code.

1. Go to the Explorer view and select **Create .NET Project**. Alternatively, you can bring up the Command Palette using Ctrl+Shift+P (Command+Shift+P on MacOS) and then type ".NET" and find and select the .NET: New Project command.

1. After selecting the command, you'll need to choose the project template. Choose Class Library.

1. Then select the location where you would like the new project to be created.

1. Give it the name **StringLibrary** and select **Create Project**.

1. Press Enter at the prompt **Project will be created in \<path>**.

1. Check to make sure that the library targets .NET 8. In **Explorer**, open *StringLibrary/StringLibrary.csproj*.

   The `TargetFramework` element shows that the project targets .NET 8.0.

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>net8.0</TargetFramework>
     </PropertyGroup>

   </Project>
   ```

1. Open *Class1.cs* and replace the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/StringLibrary/Class1.cs":::

   The class library, `UtilityLibraries.StringLibrary`, contains a method named `StartsWithUpper`. This method returns a <xref:System.Boolean> value that indicates whether the current string instance begins with an uppercase character. The Unicode standard distinguishes uppercase characters from lowercase characters. The <xref:System.Char.IsUpper(System.Char)?displayProperty=nameWithType> method returns `true` if a character is uppercase.

   `StartsWithUpper` is implemented as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class.

1. Save the file.

1. Expand **Solution Explorer** at the bottom of the **Explorer** view.

1. Right click the solution in **Solution Explorer** and select **Build**, or open the Command Palette and select **.NET: Build** to build the solution and verify that the project compiles without error.

   The terminal output looks like the following example:

   ```output
   Microsoft (R) Build Engine version 17.8.0+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     StringLibrary -> C:\Projects\ClassLibraryProjects\StringLibrary\bin\Debug\net8.0\StringLibrary.dll
   Build succeeded.
       0 Warning(s)
       0 Error(s)
   Time Elapsed 00:00:02.78
   ```

## Add a console app to the solution

Add a console application that uses the class library. The app will prompt the user to enter a string and report whether the string begins with an uppercase character.

1. In the **Solution Explorer** select **New Project** or in the Command Palette select **.NET: New Project**.

1. Select Console app.

1. Give it the name **ShowCase**, select the default location and select **Create Project**.

1. Open *ShowCase/Program.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/ShowCase/Program.cs":::

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the <kbd>Enter</kbd> key without entering a string, the application ends, and the console window closes.

1. Save your changes.

## Add a project reference

Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project.

1. In **Solution Explorer** right click on the **ShowCase** project and select **Add Project Reference**.

1. Select StringLibrary.

## Run the app

1. Select Run>Run without debugging.

1. Select C#.

1. Select ShowCase.

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

In this tutorial, created a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET class library with .NET using Visual Studio Code](testing-library-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-7-0"

In this tutorial, you create a simple utility library that contains a single string-handling method.

A *class library* defines types and methods that are called by an application. If the library targets .NET Standard 2.0, it can be called by any .NET implementation (including .NET Framework) that supports .NET Standard 2.0. If the library targets .NET 7, it can be called by any application that targets .NET 7. This tutorial shows how to target .NET 7.

When you create a class library, you can distribute it as a third-party component or as a bundled component with one or more applications.

## Prerequisites

* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) installed. For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).
* The [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0).

## Create a class library project and solution

Start by creating a .NET class library project named "StringLibrary" and an associated solution. A solution serves as a container for one or more projects. You'll add additional, related projects to the same solution.

1. Start Visual Studio Code.

1. Go to the Explorer view and select **Create .NET Project**. Alternatively, you can bring up the Command Palette using Ctrl+Shift+P (Command+Shift+P on MacOS) and then type ".NET" and find and select the .NET: New Project command.

1. After selecting the command, you'll need to choose the project template. Choose Class Library.

1. Then select the location where you would like the new project to be created.

1. Give it the name **StringLibrary**, select **Show all template options**, select **.NET 7** and select **Create Project**.

1. Check to make sure that the library targets .NET 7. In **Explorer**, open *StringLibrary/StringLibrary.csproj*.

   The `TargetFramework` element shows that the project targets .NET 7.0.

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>
       <TargetFramework>net7.0</TargetFramework>
     </PropertyGroup>

   </Project>
   ```

1. Open *Class1.cs* and replace the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/StringLibrary/Class1.cs":::

   The class library, `UtilityLibraries.StringLibrary`, contains a method named `StartsWithUpper`. This method returns a <xref:System.Boolean> value that indicates whether the current string instance begins with an uppercase character. The Unicode standard distinguishes uppercase characters from lowercase characters. The <xref:System.Char.IsUpper(System.Char)?displayProperty=nameWithType> method returns `true` if a character is uppercase.

   `StartsWithUpper` is implemented as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class.

1. Save the file.

1. Right click on the project in **Solution Explorer** and right-click **Build** or open the Command Palette and select **.NET: Build** to build the solution and verify that the project compiles without error.

   The terminal output looks like the following example:

   ```output
   Microsoft (R) Build Engine version 16.7.4+b89cb5fde for .NET
   Copyright (C) Microsoft Corporation. All rights reserved.
     Determining projects to restore...
     All projects are up-to-date for restore.
     StringLibrary -> C:\Projects\ClassLibraryProjects\StringLibrary\bin\Debug\net7.0\StringLibrary.dll
   Build succeeded.
       0 Warning(s)
       0 Error(s)
   Time Elapsed 00:00:02.78
   ```

## Add a console app to the solution

Add a console application that uses the class library. The app will prompt the user to enter a string and report whether the string begins with an uppercase character.

1. In the **Solution Explorer** select **New Project** or in the Command Palette select **.NET: New Project**.

1. Select Console app.

1. Give it the name **ShowCase**, select the default location and select **Create Project**.

1. Open *ShowCase/Program.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/ShowCase/Program.cs":::

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the <kbd>Enter</kbd> key without entering a string, the application ends, and the console window closes.

1. Save your changes.

## Add a project reference

Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project.

1. In **Solution Explorer** right click on the **ShowCase** project and select **Add Project Reference**.

1. Select StringLibrary.

## Run the app

1. Select Run>Run without debugging.

1. Select C#.

1. Select ShowCase.

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

::: zone pivot="dotnet-6-0"

In this tutorial, you create a simple utility library that contains a single string-handling method.

A *class library* defines types and methods that are called by an application. If the library targets .NET Standard 2.0, it can be called by any .NET implementation (including .NET Framework) that supports .NET Standard 2.0. If the library targets .NET 6, it can be called by any application that targets .NET 6. This tutorial shows how to target .NET 6.

When you create a class library, you can distribute it as a third-party component or as a bundled component with one or more applications.

## Prerequisites

* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) installed. For information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).
* The [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).

## Create a class library project and solution

Start by creating a .NET class library project named "StringLibrary" and an associated solution. A solution serves as a container for one or more projects. You'll add additional, related projects to the same solution.

1. Start Visual Studio Code.

1. Go to the Explorer view and select **Create .NET Project**. Alternatively, you can bring up the Command Palette using Ctrl+Shift+P (Command+Shift+P on MacOS) and then type ".NET" and find and select the .NET: New Project command.

1. After selecting the command, you'll need to choose the project template. Choose Class Library.

1. Then select the location where you would like the new project to be created.

1. Give it the name **StringLibrary**, select **Show all template options**, select **.NET 7** and select **Create Project**.

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

1. Right click on the project in **Solution Explorer** and right-click **Build** or open the Command Palette and select **.NET: Build** to build the solution and verify that the project compiles without error.

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

1. In the **Solution Explorer** select **New Project** or in the Command Palette select **.NET: New Project**.

1. Select Console app.

1. Give it the name **ShowCase**, select the default location and select **Create Project**.

1. Open *ShowCase/Program.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio-6-0/csharp/ShowCase/Program.cs":::

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the <kbd>Enter</kbd> key without entering a string, the application ends, and the console window closes.

1. Save your changes.

## Add a project reference

Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project.

1. In **Solution Explorer** right click on the **ShowCase** project and select **Add Project Reference**.

1. Select StringLibrary.

## Run the app

1. Select Run>Run without debugging.

1. Select C#.

1. Select ShowCase.

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
