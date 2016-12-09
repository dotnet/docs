---
title: Debugging Your Hello World Application with Visual Studio 2015
description: Debugging Your Hello World Application with Visual Studio 2015
keywords: .NET, .NET Core, .NET Core console application
author: rpetrusha
ms.author: ronpet
ms.date: 10/24/2016
ms.topic: article
ms.prod: .net-core
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: ba33d3d7-d3bc-4449-9701-1d800f56baa0
---

# Debugging Your Hello World application with Visual Studio 2015 #

So far, you've followed the steps in [Building a Hello World Appllication with .NET Core in Visual Studio 2015](.\with-visual-studio.md) to create and run your console application. Once you've written and compiled it, you can begin testing it. Visual Studio includes a comprehensive set of debugging tools that you can use when testing and troubleshooting your application. Let's look at a few of them as we debug our program.

## Debugging in Debug mode ##

Debug mode is one of Visual Studio's two default build configurations. The current build configuration is shown on the toolbar. The following figure shows that our application will be compiled in debug mode.

   ![Image](.\media\debugmode.jpg)

You should always start out by testing your program in Debug mode. Debug mode turns off most compiler optimizations and provides richer information in the symbol database file (.pdb file) output by the build process.

Let's run our program in Debug mode and try a few debugging features: 

1. Set a breakpoint by positioning the cursor on the line that reads `Console.WriteLine("\nHello, {0}, on {1:d} at {1:t}", name, date);` and clicking in the left margin of the code window or selecting **Debug**, **Toggle Breakpoint**. (A breakpoint temporarily interrupts the execution of the application *before* the line with the breakpoint is executed.) As the following figure shows, Visual Studio indicates the line on which the breakpoint is set by highlighting it and displaying a red circle in its right margin.

   ![Image](.\media\setbreakpoint.jpg)

2. Run the program by selecting the green button on the toolar, pressing F5, or selecting **Debug**, **Start Debugging**.

3. Enter a string in the console window when the program prompts for a name.

4. Program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes. Visual Studio should look something like the following figure. Note that the **Autos** window displays the values of variables that are used around the current line. (The **Locals** window displays the values of variables that are defined in the method that is currently executing.)

   ![Image](.\media\breakpoint.jpg)

5. Let's try to change the value of the variables to see how this affects our program. If the **Immediate window** is not visible, display it by selecting **Debug**, **Windows**, **Immediate**. The **Immediate window** lets you interact with the application you're debugging. 

6. You can interactively change the values of variables. Type the following into the immediate window:

   ```console
   name = "Yuma"
   date = new DateTime(2016,11,01,11,59,00)
   ```

   The following image shows the **Immediate  window**:

   ![Image](.\media\immediatewindow.jpg)

   Note that the window displays the value of the string variable and the properties of the @System.DateTime value. In addition, the value of the variables is updated in the **Autos** and **Locals** windows.

7. Continue program execution by selecting the **Continue** button in the toolbar, or by selecting **Debug**, **Continue**. The resulting console window should resemble the following image. Note that the values displayed in the console window also correspond to the changes we made in the **Immediate window**.

   ![Image](.\media\changed.jpg)

8. Press any key to exit the application and end debug mode.

## Building a release version ##

Once you've tested the debug build of your application, you should also compile and test the release version. The release version incorporates compiler optimizations that can sometimes affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in asynchronous or multithreaded applications.

To build and test the release version of your console application, change the build configuration on the toolbar from **Debug** to **Release**, as shown in the following figure.

![Image](.\media\release.jpg)

When you press F5 or select **Build Solution** from the **Build** menu, Visual Studio compiles the release version of your console application for you to test. You can then run and test it as we did the debug verison of our application.

Once you've finished debugging your application, the next step is to publish a distributable version of your applicatio. For information about how to do this, see [Publishing the Hello World application](.\publishing-with-visual-studio.md).


