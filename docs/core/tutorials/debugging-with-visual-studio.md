---
title: Debug a .NET console application using Visual Studio
description: Learn how to debug a .NET console app using Visual Studio.
ms.date: 09/02/2021
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet"
recommendations: false
---
# Tutorial: Debug a .NET console application using Visual Studio

::: zone pivot="dotnet-6-0"

This tutorial introduces the debugging tools available in Visual Studio.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio](with-visual-studio.md).

## Use Debug build configuration

*Debug* and *Release* are Visual Studio's built-in build configurations. You use the Debug build configuration for debugging and the Release configuration for the final release distribution.

In the Debug configuration, a program compiles with full symbolic debug information and no optimization. Optimization complicates debugging, because the relationship between source code and generated instructions is more complex. The release configuration of a program has no symbolic debug information and is fully optimized.

 By default, Visual Studio uses the Debug build configuration, so you don't need to change it before debugging.

1. Start Visual Studio.

1. Open the project that you created in [Create a .NET console application using Visual Studio](with-visual-studio.md).

   The current build configuration is shown on the toolbar. The following toolbar image shows that Visual Studio is configured to compile the Debug version of the app:

   :::image type="content" source="./media/debugging-with-visual-studio/visual-studio-toolbar-debug.png" alt-text="Visual Studio toolbar with debug highlighted":::

## Set a breakpoint

A *breakpoint* temporarily interrupts the execution of the application before the line with the breakpoint is executed.

1. Set a *breakpoint* on the line that displays the name, date, and time, by clicking in the left margin of the code window on that line. The left margin is to the left of the line numbers.  Other ways to set a breakpoint are by placing the cursor in the line of code and then pressing <kbd>F9</kbd> or choosing **Debug** > **Toggle Breakpoint** from the menu bar.

   As the following image shows, Visual Studio indicates the line on which the breakpoint is set by highlighting it and displaying a red dot in the left margin.

   :::image type="content" source="./media/debugging-with-visual-studio/set-breakpoint-in-editor-net6.png" alt-text="Visual Studio Program window with breakpoint set":::

1. Press <kbd>F5</kbd> to run the program in Debug mode. Another way to start debugging is by choosing **Debug** > **Start Debugging** from the menu.

1. Enter a string in the console window when the program prompts for a name, and then press <kbd>Enter</kbd>.

1. Program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes. The **Locals** window displays the values of variables that are defined in the currently executing method.

   :::image type="content" source="./media/debugging-with-visual-studio/breakpoint-hit-net6.png" alt-text="Screenshot of a breakpoint in Visual Studio":::

## Use the Immediate window

The **Immediate** window lets you interact with the application you're debugging. You can interactively change the value of variables to see how it affects your program.

1. If the **Immediate** window is not visible, display it by choosing **Debug** > **Windows** > **Immediate**.

1. Enter `name = "Gracie"` in the **Immediate** window and press the <kbd>Enter</kbd> key.

1. Enter `currentDate = DateTime.Parse("2019-11-16T17:25:00Z").ToUniversalTime()` in the **Immediate** window and press the <kbd>Enter</kbd> key.

   The **Immediate** window displays the value of the string variable and the properties of the <xref:System.DateTime> value. In addition, the values of the variables are updated in the **Locals** window.

   :::image type="content" source="./media/debugging-with-visual-studio/locals-immediate-window.png" alt-text="Locals and Immediate Windows in Visual Studio 2019":::

1. Press <kbd>F5</kbd> to continue program execution. Another way to continue is by choosing **Debug** > **Continue** from the menu.

   The values displayed in the console window correspond to the changes you made in the **Immediate** window.

   :::image type="content" source="./media/debugging-with-visual-studio/console-window.png" alt-text="Console window showing the entered values":::

1. Press any key to exit the application and stop debugging.

## Set a conditional breakpoint

The program displays the string that the user enters. What happens if the user doesn't enter anything? You can test this with a useful debugging feature called a *conditional breakpoint*.

1. Right-click on the red dot that represents the breakpoint. In the context menu, select **Conditions** to open the **Breakpoint Settings** dialog. Select the box for **Conditions** if it's not already selected.

   :::image type="content" source="./media/debugging-with-visual-studio/breakpoint-settings-net6.png" alt-text="Editor showing breakpoint settings panel - C#":::

1. For the **Conditional Expression**, enter the following code in the field that shows example code that tests if `x` is 5.

   ```csharp
   String.IsNullOrEmpty(name)
   ```

   ```vb
   String.IsNullOrEmpty(name)
   ```

   Each time the breakpoint is hit, the debugger calls the `String.IsNullOrEmpty(name)` method, and it breaks on this line only if the method call returns `true`.

   Instead of a conditional expression, you can specify a *hit count*, which interrupts program execution before a statement is executed a specified number of times. Another option is to specify a *filter condition*, which interrupts program execution based on such attributes as a thread identifier, process name, or thread name.

1. Select **Close** to close the dialog.

1. Start the program with debugging by pressing <kbd>F5</kbd>.

1. In the console window, press the <kbd>Enter</kbd> key when prompted to enter your name.

1. Because the condition you specified (`name` is either `null` or <xref:System.String.Empty?displayProperty=nameWithType>) has been satisfied, program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes.

1. Select the **Locals** window, which shows the values of variables that are local to the currently executing method. In this case, `Main` is the currently executing method. Observe that the value of the `name` variable is `""`, or <xref:System.String.Empty?displayProperty=nameWithType>.

1. Confirm the value is an empty string by entering the following statement in the **Immediate** window and pressing <kbd>Enter</kbd>. The result is `true`.

   ```csharp
   ? name == String.Empty
   ```

   ```vb
   ? String.IsNullOrEmpty(name)
   ```

   The question mark directs the immediate window to [evaluate an expression](/visualstudio/ide/reference/immediate-window#enter-commands).

   :::image type="content" source="./media/debugging-with-visual-studio/immediate-window-output.png" alt-text="Immediate Window returning a value of true after the statement is executed - C#":::

1. Press <kbd>F5</kbd> to continue program execution.

1. Press any key to close the console window and stop debugging.

1. Clear the breakpoint by clicking on the dot in the left margin of the code window. Other ways to clear a breakpoint are by pressing <kbd>F9</kbd> or choosing **Debug > Toggle Breakpoint** while the line of code is selected.

## Step through a program

Visual Studio also allows you to step line by line through a program and monitor its execution. Ordinarily, you'd set a breakpoint and follow program flow through a small part of your program code. Since this program is small, you can step through the entire program.

1. Choose **Debug** > **Step Into**. Another way to debug one statement at a time is by pressing <kbd>F11</kbd>.

   Visual Studio highlights and displays an arrow beside the next line of execution.

   C#

   :::image type="content" source="./media/debugging-with-visual-studio/step-into-method-net6.png" alt-text="Visual Studio step into method - C#":::

   Visual Basic

   :::image type="content" source="./media/debugging-with-visual-studio/vb-step-into-method.png" alt-text="Visual Studio step into method - Visual Basic":::

   At this point, the **Locals** window shows that the `args` array is empty, and `name` and `currentDate` have default values. In addition, Visual Studio has opened a blank console window.

1. Press <kbd>F11</kbd>. Visual Studio now highlights the next line of execution. The **Locals** window is unchanged, and the console window remains blank.

   C#

   :::image type="content" source="./media/debugging-with-visual-studio/step-into-source-method-net6.png" alt-text="Visual Studio step in method source - C#":::

   Visual Basic

   :::image type="content" source="./media/debugging-with-visual-studio/vb-step-into-source-method.png" alt-text="Visual Studio step into method source - Visual Basic":::

1. Press <kbd>F11</kbd>. Visual Studio highlights the statement that includes the `name` variable assignment. The **Locals** window shows that `name` is `null`, and the console window displays the string "What is your name?".

1. Respond to the prompt by entering a string in the console window and pressing <kbd>Enter</kbd>. The console is unresponsive, and the string you entered isn't displayed in the console window, but the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method will nevertheless capture your input.

1. Press <kbd>F11</kbd>. Visual Studio highlights the statement that includes the `currentDate` variable assignment. The **Locals** window shows the value returned by the call to the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method. The console window also displays the string you entered at the prompt.

1. Press <kbd>F11</kbd>. The **Locals** window shows the value of the `currentDate` variable after the assignment from the <xref:System.DateTime.Now?displayProperty=nameWithType> property. The console window is unchanged.

1. Press <kbd>F11</kbd>. Visual Studio calls the <xref:System.Console.WriteLine(System.String,System.Object,System.Object)?displayProperty=nameWithType> method. The console window displays the formatted string.

1. Choose **Debug** > **Step Out**. Another way to stop step-by-step execution is by pressing <kbd>Shift</kbd>+<kbd>F11</kbd>.

   The console window displays a message and waits for you to press a key.

1. Press any key to close the console window and stop debugging.

## Use Release build configuration

Once you've tested the Debug version of your application, you should also compile and test the Release version. The Release version incorporates compiler optimizations that can sometimes negatively affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in multithreaded applications.

To build and test the Release version of your console application, change the build configuration on the toolbar from **Debug** to **Release**.

:::image type="content" source="./media/debugging-with-visual-studio/visual-studio-toolbar-release.png" alt-text="default Visual Studio toolbar with release highlighted":::

When you press <kbd>F5</kbd> or choose **Build Solution** from the **Build** menu, Visual Studio compiles the Release version of the application. You can test it as you did the Debug version.

## Next steps

In this tutorial, you used Visual Studio debugging tools. In the next tutorial, you publish a deployable version of the app.

> [!div class="nextstepaction"]
> [Publish a .NET console application using Visual Studio](publishing-with-visual-studio.md)

::: zone-end

::: zone pivot="dotnet-5-0"

This tutorial introduces the debugging tools available in Visual Studio.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio](with-visual-studio.md).

## Use Debug build configuration

*Debug* and *Release* are Visual Studio's built-in build configurations. You use the Debug build configuration for debugging and the Release configuration for the final release distribution.

In the Debug configuration, a program compiles with full symbolic debug information and no optimization. Optimization complicates debugging, because the relationship between source code and generated instructions is more complex. The release configuration of a program has no symbolic debug information and is fully optimized.

 By default, Visual Studio uses the Debug build configuration, so you don't need to change it before debugging.

1. Start Visual Studio.

1. Open the project that you created in [Create a .NET console application using Visual Studio](with-visual-studio.md).

   The current build configuration is shown on the toolbar. The following toolbar image shows that Visual Studio is configured to compile the Debug version of the app:

   :::image type="content" source="./media/debugging-with-visual-studio/visual-studio-toolbar-debug.png" alt-text="Visual Studio toolbar with debug highlighted":::

## Set a breakpoint

A *breakpoint* temporarily interrupts the execution of the application before the line with the breakpoint is executed.

1. Set a *breakpoint* on the line that displays the name, date, and time, by clicking in the left margin of the code window on that line. The left margin is to the left of the line numbers.  Other ways to set a breakpoint are by placing the cursor in the line of code and then pressing <kbd>F9</kbd> or choosing **Debug** > **Toggle Breakpoint** from the menu bar.

   As the following image shows, Visual Studio indicates the line on which the breakpoint is set by highlighting it and displaying a red dot in the left margin.

   :::image type="content" source="./media/debugging-with-visual-studio/set-breakpoint-in-editor.png" alt-text="Visual Studio Program window with breakpoint set":::

1. Press <kbd>F5</kbd> to run the program in Debug mode. Another way to start debugging is by choosing **Debug** > **Start Debugging** from the menu.

1. Enter a string in the console window when the program prompts for a name, and then press <kbd>Enter</kbd>.

1. Program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes. The **Locals** window displays the values of variables that are defined in the currently executing method.

   :::image type="content" source="./media/debugging-with-visual-studio/breakpoint-hit.png" alt-text="Screenshot of a breakpoint in Visual Studio":::

## Use the Immediate window

The **Immediate** window lets you interact with the application you're debugging. You can interactively change the value of variables to see how it affects your program.

1. If the **Immediate** window is not visible, display it by choosing **Debug** > **Windows** > **Immediate**.

1. Enter `name = "Gracie"` in the **Immediate** window and press the <kbd>Enter</kbd> key.

1. Enter `currentDate = DateTime.Parse("2019-11-16T17:25:00Z").ToUniversalTime()` in the **Immediate** window and press the <kbd>Enter</kbd> key.

   The **Immediate** window displays the value of the string variable and the properties of the <xref:System.DateTime> value. In addition, the values of the variables are updated in the **Locals** window.

   :::image type="content" source="./media/debugging-with-visual-studio/locals-immediate-window.png" alt-text="Locals and Immediate Windows in Visual Studio 2019":::

1. Press <kbd>F5</kbd> to continue program execution. Another way to continue is by choosing **Debug** > **Continue** from the menu.

   The values displayed in the console window correspond to the changes you made in the **Immediate** window.

   :::image type="content" source="./media/debugging-with-visual-studio/console-window.png" alt-text="Console window showing the entered values":::

1. Press any key to exit the application and stop debugging.

## Set a conditional breakpoint

The program displays the string that the user enters. What happens if the user doesn't enter anything? You can test this with a useful debugging feature called a *conditional breakpoint*.

1. Right-click on the red dot that represents the breakpoint. In the context menu, select **Conditions** to open the **Breakpoint Settings** dialog. Select the box for **Conditions** if it's not already selected.

   :::image type="content" source="./media/debugging-with-visual-studio/breakpoint-settings.png" alt-text="Editor showing breakpoint settings panel - C#":::

1. For the **Conditional Expression**, enter the following code in the field that shows example code that tests if `x` is 5. If the language you want to use is not shown, change the language selector at the top of the page.

   ```csharp
   String.IsNullOrEmpty(name)
   ```

   ```vb
   String.IsNullOrEmpty(name)
   ```

   Each time the breakpoint is hit, the debugger calls the `String.IsNullOrEmpty(name)` method, and it breaks on this line only if the method call returns `true`.

   Instead of a conditional expression, you can specify a *hit count*, which interrupts program execution before a statement is executed a specified number of times. Another option is to specify a *filter condition*, which interrupts program execution based on such attributes as a thread identifier, process name, or thread name.

1. Select **Close** to close the dialog.

1. Start the program with debugging by pressing <kbd>F5</kbd>.

1. In the console window, press the <kbd>Enter</kbd> key when prompted to enter your name.

1. Because the condition you specified (`name` is either `null` or <xref:System.String.Empty?displayProperty=nameWithType>) has been satisfied, program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes.

1. Select the **Locals** window, which shows the values of variables that are local to the currently executing method. In this case, `Main` is the currently executing method. Observe that the value of the `name` variable is `""`, or <xref:System.String.Empty?displayProperty=nameWithType>.

1. Confirm the value is an empty string by entering the following statement in the **Immediate** window and pressing <kbd>Enter</kbd>. The result is `true`.

   ```csharp
   ? name == String.Empty
   ```

   ```vb
   ? String.IsNullOrEmpty(name)
   ```

   The question mark directs the immediate window to [evaluate an expression](/visualstudio/ide/reference/immediate-window#enter-commands).

   :::image type="content" source="./media/debugging-with-visual-studio/immediate-window-output.png" alt-text="Immediate Window returning a value of true after the statement is executed - C#":::

1. Press <kbd>F5</kbd> to continue program execution.

1. Press any key to close the console window and stop debugging.

1. Clear the breakpoint by clicking on the dot in the left margin of the code window. Other ways to clear a breakpoint are by pressing <kbd>F9</kbd> or choosing **Debug > Toggle Breakpoint** while the line of code is selected.

## Step through a program

Visual Studio also allows you to step line by line through a program and monitor its execution. Ordinarily, you'd set a breakpoint and follow program flow through a small part of your program code. Since this program is small, you can step through the entire program.

1. Choose **Debug** > **Step Into**. Another way to debug one statement at a time is by pressing <kbd>F11</kbd>.

   Visual Studio highlights and displays an arrow beside the next line of execution.

   C#

   :::image type="content" source="./media/debugging-with-visual-studio/step-into-method.png" alt-text="Visual Studio step into method - C#":::

   Visual Basic

   :::image type="content" source="./media/debugging-with-visual-studio/vb-step-into-method.png" alt-text="Visual Studio step into method - Visual Basic":::

   At this point, the **Locals** window shows that the `args` array is empty, and `name` and `currentDate` have default values. In addition, Visual Studio has opened a blank console window.

1. Press <kbd>F11</kbd>. Visual Studio now highlights the next line of execution. The **Locals** window is unchanged, and the console window remains blank.

   C#

   :::image type="content" source="./media/debugging-with-visual-studio/step-into-source-method.png" alt-text="Visual Studio step in method source - C#":::

   Visual Basic

   :::image type="content" source="./media/debugging-with-visual-studio/vb-step-into-source-method.png" alt-text="Visual Studio step into method source - Visual Basic":::

1. Press <kbd>F11</kbd>. Visual Studio highlights the statement that includes the `name` variable assignment. The **Locals** window shows that `name` is `null`, and the console window displays the string "What is your name?".

1. Respond to the prompt by entering a string in the console window and pressing <kbd>Enter</kbd>. The console is unresponsive, and the string you entered isn't displayed in the console window, but the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method will nevertheless capture your input.

1. Press <kbd>F11</kbd>. Visual Studio highlights the statement that includes the `currentDate` variable assignment. The **Locals** window shows the value returned by the call to the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method. The console window also displays the string you entered at the prompt.

1. Press <kbd>F11</kbd>. The **Locals** window shows the value of the `currentDate` variable after the assignment from the <xref:System.DateTime.Now?displayProperty=nameWithType> property. The console window is unchanged.

1. Press <kbd>F11</kbd>. Visual Studio calls the <xref:System.Console.WriteLine(System.String,System.Object,System.Object)?displayProperty=nameWithType> method. The console window displays the formatted string.

1. Choose **Debug** > **Step Out**. Another way to stop step-by-step execution is by pressing <kbd>Shift</kbd>+<kbd>F11</kbd>.

   The console window displays a message and waits for you to press a key.

1. Press any key to close the console window and stop debugging.

## Use Release build configuration

Once you've tested the Debug version of your application, you should also compile and test the Release version. The Release version incorporates compiler optimizations that can sometimes negatively affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in multithreaded applications.

To build and test the Release version of your console application, change the build configuration on the toolbar from **Debug** to **Release**.

:::image type="content" source="./media/debugging-with-visual-studio/visual-studio-toolbar-release.png" alt-text="default Visual Studio toolbar with release highlighted":::

When you press <kbd>F5</kbd> or choose **Build Solution** from the **Build** menu, Visual Studio compiles the Release version of the application. You can test it as you did the Debug version.

## Next steps

In this tutorial, you used Visual Studio debugging tools. In the next tutorial, you publish a deployable version of the app.

> [!div class="nextstepaction"]
> [Publish a .NET console application using Visual Studio](publishing-with-visual-studio.md)

::: zone-end

::: zone pivot="dotnet-core-3-1"

This tutorial is only available for .NET 5 and .NET 6. Select one of those options at the top of the page.

::: zone-end
