---
title: Consuming a Class Library with .NET Core in Visual Studio 2017
description: Learn how to call the members in a class library with Visual Studio 2017
keywords: .NET Core, .NET Core class library, .NET STandard, .NET Standard class library distribution
author: rpetrusha
manager: wpickett
ms.author: ronpet
ms.date: 11/16/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: d7b94076-1108-4174-94e7-a18f00072bb7
---

# Consuming a Class Library with .NET Core in Visual Studio 2017 #

Once you've followed the steps in [Building a C# Class Library with .NET Core in Visual Studio 2017 RC](./library-with-visual-studio_2017.md) and [Testing a Class Library with .NET Core in Visual Studio 2017 RC](testing-library-with-visual-studio.md) to build and test your class library, and you've built a Release version of the library, the next step is to make it available to callers. You can do this in three ways:

- If the library will be used by a single solution (for example, if it is a component in a single large application), you can simply include it as a project in your solution.

- If the library will be generally accessible, you can distribute it as a NuGet package.

## Including a library as a project in a solution ##

Very much as we included our unit tests in the same solution as our class library, we can include our application as part of that solution. For example, let's use our class library in a console application that prompts the user to enter a string and reports whether its first charater is uppercase:

1. With the existing `ClassLibraryProjects` solution created in the [Building a C# Class Library with .NET Core in Visual Studio 2017 RC](./library-with-visual-studio_2017.md) topic open, right-click on the solution in Solution Explorer and select **Add**, **New Project**.

1. In the **Add New Project** dialog, select the **.NET Core** node within the **Visual C#** node, and select **Console App (.NET Core)**, as the following figure shows.

   ![Image](./media/use-library.jpg)

1. In tne **Name** text box, enter the name of the project, `ShowCase`, and select the **OK** button.

1. Right now, our project doesn't have access to our class library. To allow it to call methods in our class library, right-click on the **Dependencies** item in the `ShowCase` project in **Solution Explorer**, and select **Add Reference**.

1. In the **Reference Manager** dialog, select `StringLibrary`, our class library project, as the following figure shows.

   ![Image](./media/add-lib-ref.jpg)

1. Replace all of the code in the code window with the following code:

 [!CODE-csharp[UsingClassLib#1](../../../samples/snippets/csharp/getting_started/with_visual_studio_2017/showcase.cs#1)]

   The code uses the [Console.WindowHeight](xref:System.Console.WindowHeight) property to determine how many rows the console window has. Whenever the [Console.CursorTop](xref:System.Console.CursorTop) property is greater than or equal to the total number of rows in the console window, the code clears the console window and redisplays a message to the user.

   The program itself just prompts the user to enter a string. It then indicates whether the string starts with an uppercase character. If the user presses the **Enter** key without entering a string, the console window closes and the application terminates.

1. If necessary, change the toolbar to compile the **Debug** release of the `ShowCase` project, as the following figure shows.

   ![Image](./media/showcase-toolbar.jpg)

1. Compile and run the program by clicking the green arrow on the `ShowCase` button.

The application that uses this library can then be debugged and eventually published by following the steps listed in [Debugging your C# Hello World Application with Visual Studio 2017 RC](debugging-with-visual-studio-2017.md) and [Publishing your Hello World Application with Visual Studio 2017 RC](publishing-with-visual-studio-2017.md).

## Distributing the library in a NuGet package ##

You can make your class library more widely available by publishing it as a NuGet package. Visual Studio does not support the creation of NuGet packages. To create one, you use the [`dotnet.exe` command line utility](../../core/tools/dotnet.md) as follows:

1. Open a console window. For example, in the **Ask me anything** text box in the Windows taskbar, type *Command Prompt*. Then select the **Command Prompt** desktop app to open the console window.

1. Navigate to the your library's project directory. Typically, unless you've reconfigured the file location, it is in the `Documents\Visual Studio 2017\Projects\ClassLibraryProjects\StringLibrary` directory. The directory contains your source code and a project file, `StringLibrary.csproj`.

   [!TIP] If the directory that contains `dotnet.exe` is not in your path, you can find its location by entering `where dotnet.exe` in the console window.

1. Issue the command `dotnet.exe pack --no-build`. The `dotnet.exe` utility generates two packages with a .nupkg extension. One package contains the code, and the other contains the debug symbols.

For more information on creating NuGet packages, see [How to Create a NuGet Package with Cross Platform Tools](../../core/deploying/creating-nuget-packages.md).

