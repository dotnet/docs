---
title: Debug a .NET console application using Visual Studio Code
description: Learn how to debug a .NET console app using Visual Studio Code.
ms.date: 10/22/2021
zone_pivot_groups: dotnet-version
recommendations: false
---
# Tutorial: Debug a .NET console application using Visual Studio Code

::: zone pivot="dotnet-6-0"

This tutorial introduces the debugging tools available in Visual Studio Code for working with .NET apps.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Use Debug build configuration

*Debug* and *Release* are .NET's built-in build configurations. You use the Debug build configuration for debugging and the Release configuration for the final release distribution.

In the Debug configuration, a program compiles with full symbolic debug information and no optimization. Optimization complicates debugging, because the relationship between source code and generated instructions is more complex. The release configuration of a program has no symbolic debug information and is fully optimized.

By default, Visual Studio Code launch settings use the Debug build configuration, so you don't need to change it before debugging.

1. Start Visual Studio Code.

1. Open the folder of the project that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Set a breakpoint

A *breakpoint* temporarily interrupts the execution of the application before the line with the breakpoint is run.

1. Open the *Program.cs* file.

1. Set a *breakpoint* on the line that displays the name, date, and time, by clicking in the left margin of the code window. The left margin is to the left of the line numbers. Other ways to set a breakpoint are by pressing <kbd>F9</kbd> or choosing **Run** > **Toggle Breakpoint** from the menu while the line of code is selected.

   Visual Studio Code indicates the line on which the breakpoint is set by displaying a red dot in the left margin.

   :::image type="content" source="media/debugging-with-visual-studio-code/breakpoint-set-net6.png" alt-text="Breakpoint set":::

## Set up for terminal input

The breakpoint is located after a `Console.ReadLine` method call. The **Debug Console** doesn't accept terminal input for a running program. To handle terminal input while debugging, you can use the integrated terminal (one of the Visual Studio Code windows) or an external terminal. For this tutorial, you use the integrated terminal.

1. Open *.vscode/launch.json*.

1. Change the `console` setting from `internalConsole` to `integratedTerminal`:

   ```json
   "console": "integratedTerminal",
   ```

1. Save your changes.

## Start debugging

1. Open the Debug view by selecting the Debugging icon on the left side menu.

   :::image type="content" source="media/debugging-with-visual-studio-code/select-debug-pane-net6.png" alt-text="Open the Debug tab in Visual Studio Code":::

1. Select the green arrow at the top of the pane, next to **.NET Core Launch (console)**. Other ways to start the program in debugging mode are by pressing <kbd>F5</kbd> or choosing **Run** > **Start Debugging** from the menu.

   :::image type="content" source="media/debugging-with-visual-studio-code/start-debugging.png" alt-text="Start debugging":::

1. Select the **Terminal** tab to see the "What is your name?" prompt that the program displays before waiting for a response.

   :::image type="content" source="media/debugging-with-visual-studio-code/select-terminal-net6.png" alt-text="Select the Terminal tab":::

1. Enter a string in the **Terminal** window in response to the prompt for a name, and then press <kbd>Enter</kbd>.

   Program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method runs. The **Locals** section of the **Variables** window displays the values of variables that are defined in the currently running method.

   :::image type="content" source="media/debugging-with-visual-studio-code/breakpoint-hit-net6.png" alt-text="Breakpoint hit, showing Locals":::

## Use the Debug Console

The **Debug Console** window lets you interact with the application you're debugging. You can change the value of variables to see how it affects your program.

1. Select the **Debug Console** tab.

1. Enter `name = "Gracie"` at the prompt at the bottom of the **Debug Console** window and press the <kbd>Enter</kbd> key.

   :::image type="content" source="media/debugging-with-visual-studio-code/change-variable-values-net6.png" alt-text="Change variable values":::

1. Enter `currentDate = DateTime.Parse("2019-11-16T17:25:00Z").ToUniversalTime()` at the bottom of the **Debug Console** window and press the <kbd>Enter</kbd> key.

   The **Variables** window displays the new values of the `name` and `currentDate` variables.

1. Continue program execution by selecting the **Continue** button in the toolbar. Another way to continue is by pressing <kbd>F5</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-code/continue-debugging.png" alt-text="Continue debugging":::

1. Select the **Terminal** tab again.

   The values displayed in the console window correspond to the changes you made in the **Debug Console**.

   :::image type="content" source="media/debugging-with-visual-studio-code/changed-variable-values.png" alt-text="Terminal showing the entered values":::

1. Press any key to exit the application and stop debugging.

## Set a conditional breakpoint

The program displays the string that the user enters. What happens if the user doesn't enter anything? You can test this with a useful debugging feature called a *conditional breakpoint*.

1. Right-click (<kbd>Ctrl</kbd>-click on macOS) on the red dot that represents the breakpoint. In the context menu, select **Edit Breakpoint** to open a dialog that lets you enter a conditional expression.

   :::image type="content" source="media/debugging-with-visual-studio-code/breakpoint-context-menu-net6.png" alt-text="Breakpoint context menu":::

1. Select `Expression` in the drop-down, enter the following conditional expression, and press <kbd>Enter</kbd>.

   ```csharp
   String.IsNullOrEmpty(name)
   ```

   :::image type="content" source="media/debugging-with-visual-studio-code/conditional-expression-net6.png" alt-text="Enter a conditional expression":::

   Each time the breakpoint is hit, the debugger calls the `String.IsNullOrEmpty(name)` method, and it breaks on this line only if the method call returns `true`.

   Instead of a conditional expression, you can specify a *hit count*, which interrupts program execution before a statement is run a specified number of times. Another option is to specify a *filter condition*, which interrupts program execution based on such attributes as a thread identifier, process name, or thread name.

1. Start the program with debugging by pressing <kbd>F5</kbd>.

1. In the **Terminal** tab, press the <kbd>Enter</kbd> key when prompted to enter your name.

   Because the condition you specified (`name` is either `null` or <xref:System.String.Empty?displayProperty=nameWithType>) has been satisfied, program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method runs.

   The **Variables** window shows that the value of the `name` variable is `""`, or <xref:System.String.Empty?displayProperty=nameWithType>.

1. Confirm the value is an empty string by entering the following statement at the **Debug Console** prompt and pressing <kbd>Enter</kbd>. The result is `true`.

   ```csharp
   name == String.Empty
   ```

1. Select the **Continue** button on the toolbar to continue program execution.

1. Select the **Terminal** tab, and press any key to exit the program and stop debugging.

1. Clear the breakpoint by clicking on the dot in the left margin of the code window. Other ways to clear a breakpoint are by pressing <kbd>F9</kbd> or choosing **Run > Toggle Breakpoint** from the menu while the line of code is selected.

1. If you get a warning that the breakpoint condition will be lost, select **Remove Breakpoint**.

## Step through a program

Visual Studio Code also allows you to step line by line through a program and monitor its execution. Ordinarily, you'd set a breakpoint and follow program flow through a small part of your program code. Since this program is small, you can step through the entire program.

1. Set a breakpoint on the opening curly brace of the `Main` method.

1. Press <kbd>F5</kbd> to start debugging.

   Visual Studio Code highlights the breakpoint line.

   At this point, the **Variables** window shows that the `args` array is empty, and `name` and `currentDate` have default values.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-code/step-into.png" alt-text="Step-Into button":::

   Visual Studio Code highlights the next line.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio Code runs the `Console.WriteLine` for the name prompt and highlights the next line of execution. The next line is the `Console.ReadLine` for the `name`. The **Variables** window is unchanged, and the **Terminal** tab shows the "What is your name?" prompt.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio highlights the `name` variable assignment. The **Variables** window shows that `name` is still `null`.

1. Respond to the prompt by entering a string in the Terminal tab and pressing <kbd>Enter</kbd>.

   The **Terminal** tab might not display the string you enter while you're entering it, but the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method will capture your input.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio Code highlights the `currentDate` variable assignment. The **Variables** window shows the value returned by the call to the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method. The **Terminal** tab displays the string you entered at the prompt.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   The **Variables** window shows the value of the `currentDate` variable after the assignment from the <xref:System.DateTime.Now?displayProperty=nameWithType> property.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio Code calls the <xref:System.Console.WriteLine(System.String,System.Object,System.Object)?displayProperty=nameWithType> method. The console window displays the formatted string.

1. Select **Run** > **Step Out** or press <kbd>Shift</kbd>+<kbd>F11</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-code/step-out.png" alt-text="Step-Out button":::

1. Select the **Terminal** tab.

   The terminal displays "Press any key to exit..."

1. Press any key to exit the program.

## Use Release build configuration

Once you've tested the Debug version of your application, you should also compile and test the Release version. The Release version incorporates compiler optimizations that can affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in multithreaded applications.

To build and test the Release version of your console application, open the **Terminal** and run the following command:

```dotnetcli
dotnet run --configuration Release
```

## Additional resources

* [Debugging in Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)

## Next steps

In this tutorial, you used Visual Studio Code debugging tools. In the next tutorial, you publish a deployable version of the app.

> [!div class="nextstepaction"]
> [Publish a .NET console application using Visual Studio Code](publishing-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-5-0"

This tutorial introduces the debugging tools available in Visual Studio Code for working with .NET apps.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Use Debug build configuration

*Debug* and *Release* are .NET Core's built-in build configurations. You use the Debug build configuration for debugging and the Release configuration for the final release distribution.

In the Debug configuration, a program compiles with full symbolic debug information and no optimization. Optimization complicates debugging, because the relationship between source code and generated instructions is more complex. The release configuration of a program has no symbolic debug information and is fully optimized.

By default, Visual Studio Code launch settings use the Debug build configuration, so you don't need to change it before debugging.

1. Start Visual Studio Code.

1. Open the folder of the project that you created in [Create a .NET console application using Visual Studio Code](with-visual-studio-code.md).

## Set a breakpoint

A *breakpoint* temporarily interrupts the execution of the application before the line with the breakpoint is executed.

1. Open the *Program.cs* file.

1. Set a *breakpoint* on the line that displays the name, date, and time, by clicking in the left margin of the code window. The left margin is to the left of the line numbers. Other ways to set a breakpoint are by pressing <kbd>F9</kbd> or choosing **Run** > **Toggle Breakpoint** from the menu while the line of code is selected.

   Visual Studio Code indicates the line on which the breakpoint is set by displaying a red dot in the left margin.

   :::image type="content" source="media/debugging-with-visual-studio-code/breakpoint-set.png" alt-text="Breakpoint set":::

## Set up for terminal input

The breakpoint is located after a `Console.ReadLine` method call. The **Debug Console** doesn't accept terminal input for a running program. To handle terminal input while debugging, you can use the integrated terminal (one of the Visual Studio Code windows) or an external terminal. For this tutorial, you use the integrated terminal.

1. Open *.vscode/launch.json*.

1. Change the `console` setting from `internalConsole` to `integratedTerminal`:

   ```json
   "console": "integratedTerminal",
   ```

1. Save your changes.

## Start debugging

1. Open the Debug view by selecting the Debugging icon on the left side menu.

   :::image type="content" source="media/debugging-with-visual-studio-code/select-debug-pane.png" alt-text="Open the Debug tab in Visual Studio Code":::

1. Select the green arrow at the top of the pane, next to **.NET Core Launch (console)**. Other ways to start the program in debugging mode are by pressing <kbd>F5</kbd> or choosing **Run** > **Start Debugging** from the menu.

   :::image type="content" source="media/debugging-with-visual-studio-code/start-debugging.png" alt-text="Start debugging":::

1. Select the **Terminal** tab to see the "What is your name?" prompt that the program displays before waiting for a response.

   :::image type="content" source="media/debugging-with-visual-studio-code/select-terminal.png" alt-text="Select the Terminal tab":::

1. Enter a string in the **Terminal** window in response to the prompt for a name, and then press <kbd>Enter</kbd>.

   Program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes. The **Locals** section of the **Variables** window displays the values of variables that are defined in the currently executing method.

   :::image type="content" source="media/debugging-with-visual-studio-code/breakpoint-hit.png" alt-text="Breakpoint hit, showing Locals":::

## Use the Debug Console

The **Debug Console** window lets you interact with the application you're debugging. You can change the value of variables to see how it affects your program.

1. Select the **Debug Console** tab.

1. Enter `name = "Gracie"` at the prompt at the bottom of the **Debug Console** window and press the <kbd>Enter</kbd> key.

   :::image type="content" source="media/debugging-with-visual-studio-code/change-variable-values.png" alt-text="Change variable values":::

1. Enter `currentDate = DateTime.Parse("2019-11-16T17:25:00Z").ToUniversalTime()` at the bottom of the **Debug Console** window and press the <kbd>Enter</kbd> key.

   The **Variables** window displays the new values of the `name` and `currentDate` variables.

1. Continue program execution by selecting the **Continue** button in the toolbar. Another way to continue is by pressing <kbd>F5</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-code/continue-debugging.png" alt-text="Continue debugging":::

1. Select the **Terminal** tab again.

   The values displayed in the console window correspond to the changes you made in the **Debug Console**.

   :::image type="content" source="media/debugging-with-visual-studio-code/changed-variable-values.png" alt-text="Terminal showing the entered values":::

1. Press any key to exit the application and stop debugging.

## Set a conditional breakpoint

The program displays the string that the user enters. What happens if the user doesn't enter anything? You can test this with a useful debugging feature called a *conditional breakpoint*.

1. Right-click (<kbd>Ctrl</kbd>-click on macOS) on the red dot that represents the breakpoint. In the context menu, select **Edit Breakpoint** to open a dialog that lets you enter a conditional expression.

   :::image type="content" source="media/debugging-with-visual-studio-code/breakpoint-context-menu.png" alt-text="Breakpoint context menu":::

1. Select `Expression` in the drop-down, enter the following conditional expression, and press <kbd>Enter</kbd>.

   ```csharp
   String.IsNullOrEmpty(name)
   ```

   :::image type="content" source="media/debugging-with-visual-studio-code/conditional-expression.png" alt-text="Enter a conditional expression":::

   Each time the breakpoint is hit, the debugger calls the `String.IsNullOrEmpty(name)` method, and it breaks on this line only if the method call returns `true`.

   Instead of a conditional expression, you can specify a *hit count*, which interrupts program execution before a statement is executed a specified number of times. Another option is to specify a *filter condition*, which interrupts program execution based on such attributes as a thread identifier, process name, or thread name.

1. Start the program with debugging by pressing <kbd>F5</kbd>.

1. In the **Terminal** tab, press the <kbd>Enter</kbd> key when prompted to enter your name.

   Because the condition you specified (`name` is either `null` or <xref:System.String.Empty?displayProperty=nameWithType>) has been satisfied, program execution stops when it reaches the breakpoint and before the `Console.WriteLine` method executes.

   The **Variables** window shows that the value of the `name` variable is `""`, or <xref:System.String.Empty?displayProperty=nameWithType>.

1. Confirm the value is an empty string by entering the following statement at the **Debug Console** prompt and pressing <kbd>Enter</kbd>. The result is `true`.

   ```csharp
   name == String.Empty
   ```

   :::image type="content" source="media/debugging-with-visual-studio-code/expression-in-debug-console.png" alt-text="Debug Console returning a value of true after the statement is executed":::

1. Select the **Continue** button on the toolbar to continue program execution.

1. Select the **Terminal** tab, and press any key to exit the program and stop debugging.

1. Clear the breakpoint by clicking on the dot in the left margin of the code window. Other ways to clear a breakpoint are by pressing <kbd>F9</kbd> or choosing **Run > Toggle Breakpoint** from the menu while the line of code is selected.

1. If you get a warning that the breakpoint condition will be lost, select **Remove Breakpoint**.

## Step through a program

Visual Studio Code also allows you to step line by line through a program and monitor its execution. Ordinarily, you'd set a breakpoint and follow program flow through a small part of your program code. Since this program is small, you can step through the entire program.

1. Set a breakpoint on the opening curly brace of the `Main` method.

1. Press <kbd>F5</kbd> to start debugging.

   Visual Studio Code highlights the breakpoint line.

   At this point, the **Variables** window shows that the `args` array is empty, and `name` and `currentDate` have default values.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-code/step-into.png" alt-text="Step-Into button":::

   Visual Studio Code highlights the next line.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio Code executes the `Console.WriteLine` for the name prompt and highlights the next line of execution. The next line is the `Console.ReadLine` for the `name`. The **Variables** window is unchanged, and the **Terminal** tab shows the "What is your name?" prompt.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio highlights the `name` variable assignment. The **Variables** window shows that `name` is still `null`.

1. Respond to the prompt by entering a string in the Terminal tab and pressing <kbd>Enter</kbd>.

   The **Terminal** tab might not display the string you enter while you're entering it, but the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method will capture your input.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio Code highlights the `currentDate` variable assignment. The **Variables** window shows the value returned by the call to the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method. The **Terminal** tab displays the string you entered at the prompt.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   The **Variables** window shows the value of the `currentDate` variable after the assignment from the <xref:System.DateTime.Now?displayProperty=nameWithType> property.

1. Select **Run** > **Step Into** or press <kbd>F11</kbd>.

   Visual Studio Code calls the <xref:System.Console.WriteLine(System.String,System.Object,System.Object)?displayProperty=nameWithType> method. The console window displays the formatted string.

1. Select **Run** > **Step Out** or press <kbd>Shift</kbd>+<kbd>F11</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-code/step-out.png" alt-text="Step-Out button":::

1. Select the **Terminal** tab.

   The terminal displays "Press any key to exit..."

1. Press any key to exit the program.

## Use Release build configuration

Once you've tested the Debug version of your application, you should also compile and test the Release version. The Release version incorporates compiler optimizations that can affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in multithreaded applications.

To build and test the Release version of your console application, open the **Terminal** and run the following command:

```dotnetcli
dotnet run --configuration Release
```

## Additional resources

* [Debugging in Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)

## Next steps

In this tutorial, you used Visual Studio Code debugging tools. In the next tutorial, you publish a deployable version of the app.

> [!div class="nextstepaction"]
> [Publish a .NET console application using Visual Studio Code](publishing-with-visual-studio-code.md)

::: zone-end

::: zone pivot="dotnet-core-3-1"

This tutorial is only available for .NET 5 and .NET 6. Select one of those options at the top of the page.

::: zone-end
