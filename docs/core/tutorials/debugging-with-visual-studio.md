---
title: Debug a .NET Core console application with Visual Studio
description: Learn how to debug a .NET Core console app with Visual Studio.
ms.date: 05/20/2020
dev_langs:
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet"
---
# Tutorial: Debug a .NET Core console application using Visual Studio

This tutorial introduces the debugging tools available in Visual Studio.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET Core console application in Visual Studio 2019](with-visual-studio.md).

## Debug build configuration

*Debug* and *Release* are two of Visual Studio's default build configurations. The current build configuration is shown on the toolbar. The following toolbar image shows that Visual Studio is configured to compile the Debug version of the app:

![Visual Studio toolbar with debug highlighted](./media/debugging-with-visual-studio/visual-studio-toolbar-debug.png)

Begin by running the Debug version of the app. The Debug build configuration turns off most compiler optimizations and provides richer information during the build process.

## Set a breakpoint

<!-- markdownlint-disable MD025 -->

1. Set a *breakpoint* on the line that displays the name, date, and time, by clicking in the left margin of the code window on that line. Another way to set a breakpoint is by placing the cursor in the line of code and then pressing **F9** or choosing **Debug** > **Toggle Breakpoint** from the menu bar.

   A breakpoint temporarily interrupts the execution of the application *before* the line with the breakpoint is executed.

   As the following image shows, Visual Studio indicates the line on which the breakpoint is set by highlighting it and displaying a red dot in the left margin.

   ![Visual Studio Program window with breakpoint set](./media/debugging-with-visual-studio/set-breakpoint-in-editor.png)

1. Run the program in Debug mode by selecting the **HelloWorld** button with the green arrow on the toolbar. Other ways to start debugging are by pressing **F5** or by choosing **Debug** > **Start Debugging**.

1. Enter a string in the console window when the program prompts for a name, and then press **Enter**.

1. Program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes. The **Locals** window displays the values of variables that are defined in the currently executing method.

   ![Screenshot of a breakpoint in Visual Studio](./media/debugging-with-visual-studio/breakpoint-hit.png)

1. The **Immediate** window lets you interact with the application you're debugging. You can interactively change the value of variables to see how it affects your program.

   1. If the **Immediate** window is not visible, display it by choosing **Debug** > **Windows** > **Immediate**.

   1. Enter `name = "Gracie"` in the **Immediate** window and press the **Enter** key.

   1. Enter `date = DateTime.Parse("2019-11-16T17:25:00Z").ToUniversalTime()` in the **Immediate** window and press the **Enter** key.

   The **Immediate** window displays the value of the string variable and the properties of the <xref:System.DateTime> value. In addition, the values of the variables are updated in the **Locals** window.

   ![Locals and Immediate Windows in Visual Studio 2019](./media/debugging-with-visual-studio/locals-immediate-window.png)

1. Continue program execution by selecting the **Continue** button in the toolbar. Another way to continue is by choosing **Debug** > **Continue**.

   The values displayed in the console window correspond to the changes you made in the **Immediate** window.

   ![Console window showing the entered values](./media/debugging-with-visual-studio/console-window.png)

1. Press any key to exit the application and stop debugging.

## Set a conditional breakpoint

The program displays the string that the user enters. What happens if the user doesn't enter anything? You can test this with a useful debugging feature called a *conditional breakpoint*, which breaks program execution when one or more conditions are met.

To set a conditional breakpoint and test what happens when the user fails to enter a string, do the following:

1. Right-click on the red dot that represents the breakpoint. In the context menu, select **Conditions** to open the **Breakpoint Settings** dialog. Select the box for **Conditions** if it's not already selected.

   ![Editor showing breakpoint settings panel - C#](./media/debugging-with-visual-studio/breakpoint-settings.png)

1. For the **Conditional Expression**, enter the following code in the field that shows example code that tests if `x` is 5. If the language you want to use is not shown, change the language selector at the top of the page.

   ```csharp
   String.IsNullOrEmpty(name)
   ```

   ```vb
   String.IsNullOrEmpty(name)
   ```

   Each time the breakpoint is hit, the debugger calls the `String.IsNullOrEmpty(name)` method, and it breaks on this line only if the method call returns `true`.

   Instead of a conditional expression, you can specify a *hit count*, which interrupts program execution before a statement is executed a specified number of times, or a *filter condition*, which interrupts program execution based on such attributes as a thread identifier, process name, or thread name.

1. Select **Close** to close the dialog.

1. Start the program with debugging by pressing **F5**.

1. In the console window, press the **Enter** key when prompted to enter your name.

1. Because the condition you specified (`name` is either `null` or <xref:System.String.Empty?displayProperty=nameWithType>) has been satisfied, program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes.

1. Select the **Locals** window, which shows the values of variables that are local to the currently executing method. In this case, `Main` is the currently executing method. Observe that the value of the `name` variable is `""`, or <xref:System.String.Empty?displayProperty=nameWithType>.

1. Confirm the value is an empty string by entering the following statement in the **Immediate** window and pressing **Enter**. The result is `true`.

   ```csharp
   ? name == String.Empty
   ```

   ```vb
   ? String.IsNullOrEmpty(name)
   ```

   The question mark directs the immediate window to [evaluate an expression](/visualstudio/ide/reference/immediate-window#enter-commands).

   ![Immediate Window returning a value of true after the statement is executed - C#](./media/debugging-with-visual-studio/immediate-window-output.png)

1. Select the **Continue** button on the toolbar to continue program execution.

1. Press any key to close the console window and stop debugging.

1. Clear the breakpoint by clicking on the dot in the left margin of the code window. Another way to clear a breakpoint is by choosing **Debug > Toggle Breakpoint** while the line of code is selected.

## Step through a program

Visual Studio also allows you to step line by line through a program and monitor its execution. Ordinarily, you'd set a breakpoint and follow program flow through a small part of your program code. Since your program is small, you can step through the entire program.

1. Choose **Debug** > **Step Into**. Another way to debug one statement at a time is by pressing **F11**.

   Visual Studio highlights and displays an arrow beside the next line of execution.

   C#

   ![Visual Studio step into method - C#](./media/debugging-with-visual-studio/step-into-method.png)

   Visual Basic

   ![Visual Studio step into method - Visual Basic](./media/debugging-with-visual-studio/vb-step-into-method.png)

   At this point, the **Locals** window shows that the `args` array is empty, and `name` and `date` have default values. In addition, Visual Studio has opened a blank console window.

1. Press **F11**. Visual Studio now highlights the next line of execution. The **Locals** window is unchanged, and the console window remains blank.

   C#

   ![Visual Studio step in method source - C#](./media/debugging-with-visual-studio/step-into-source-method.png)

   Visual Basic

   ![Visual Studio step into method source - Visual Basic](./media/debugging-with-visual-studio/vb-step-into-source-method.png)

1. Press **F11**. Visual Studio highlights the statement that includes the `name` variable assignment. The **Locals** window shows that `name` is `null`, and the console window displays the string "What is your name?".

1. Respond to the prompt by entering a string in the console window and pressing **Enter**. The console is unresponsive, and the string you entered isn't displayed in the console window, but the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method will nevertheless capture your input.

1. Press **F11**. Visual Studio highlights the statement that includes the `date` variable assignment (`currentDate` in Visual Basic). The **Locals** window shows the value returned by the call to the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method. The console window also displays the string you entered at the prompt.

1. Press **F11**. The **Locals** window shows the value of the `date` variable after the assignment from the <xref:System.DateTime.Now?displayProperty=nameWithType> property. The console window is unchanged.

1. Press **F11**. Visual Studio calls the <xref:System.Console.WriteLine(System.String,System.Object,System.Object)?displayProperty=nameWithType> method. The console window displays the formatted string.

1. Choose **Debug** > **Step Out**. Another way to stop step-by-step execution is by pressing **Shift**+**F11**.

   The console window displays a message and waits for you to press a key.

1. Press any key to close the console window and stop debugging.

## Build a Release version

Once you've tested the Debug version of your application, you should also compile and test the Release version. The Release version incorporates compiler optimizations that can sometimes negatively affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in multithreaded applications.

To build and test the Release version of your console application, change the build configuration on the toolbar from **Debug** to **Release**.

![default Visual Studio toolbar with debug highlighted](./media/debugging-with-visual-studio/visual-studio-toolbar-release.png)

When you press **F5** or choose **Build Solution** from the **Build** menu, Visual Studio compiles the Release version of the application. You can test it as you did the Debug version.

## Next steps

In this tutorial, you used Visual Studio debugging tools. In the next tutorial, you publish a deployable version of the app.

> [!div class="nextstepaction"]
> [Publish a .NET Core console application with Visual Studio](publishing-with-visual-studio.md)
