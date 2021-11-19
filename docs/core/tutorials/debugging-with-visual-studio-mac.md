---
title: Debug a .NET console application using Visual Studio for Mac
description: Learn how to debug a .NET console app using Visual Studio Mac.
ms.date: 11/30/2020
recommendations: false
---
# Tutorial: Debug a .NET console application using Visual Studio for Mac

This tutorial introduces the debugging tools available in Visual Studio for Mac.

## Prerequisites

- This tutorial works with the console app that you create in [Create a .NET console application using Visual Studio for Mac](with-visual-studio-mac.md).

## Use Debug build configuration

*Debug* and *Release* are Visual Studio's built-in build configurations. You use the Debug build configuration for debugging and the Release configuration for the final release distribution.

In the Debug configuration, a program compiles with full symbolic debug information and no optimization. Optimization complicates debugging, because the relationship between source code and generated instructions is more complex. The release configuration of a program has no symbolic debug information and is fully optimized.

By default, Visual Studio for Mac uses the Debug build configuration, so you don't need to change it before debugging.

1. Start Visual Studio for Mac.

1. Open the project that you created in [Create a .NET console application using Visual Studio for Mac](with-visual-studio-mac.md).

   The current build configuration is shown on the toolbar. The following toolbar image shows that Visual Studio is configured to compile the Debug version of the app:

   :::image type="content" source="media/debugging-with-visual-studio-mac/visual-studio-toolbar-debug.png" alt-text="Visual Studio toolbar with debug highlighted":::

## Set a breakpoint

A *breakpoint* temporarily interrupts the execution of the application before the line with the breakpoint is executed.

1. Set a breakpoint on the line that displays the name, date, and time. To do that, place the cursor in the line of code and press <kbd>⌘</kbd><kbd>\\</kbd> (<kbd>command</kbd>+<kbd>\\</kbd>). Another way to set a breakpoint is by selecting **Run** > **Toggle Breakpoint** from the menu.

   Visual Studio indicates the line on which the breakpoint is set by highlighting it and displaying a red dot in the left margin.

   :::image type="content" source="media/debugging-with-visual-studio-mac/set-breakpoint-in-editor.png" alt-text="Visual Studio Program window with breakpoint set":::

1. Press <kbd>⌘</kbd><kbd>↵</kbd> (<kbd>command</kbd>+<kbd>enter</kbd>) to start the program in debugging mode. Another way to start debugging is by choosing **Run** > **Start Debugging** from the menu.

1. Enter a string in the terminal window when the program prompts for a name, and then press <kbd>enter</kbd>.

1. Program execution stops when it reaches the breakpoint, before the `Console.WriteLine` method executes.

   :::image type="content" source="media/debugging-with-visual-studio-mac/breakpoint-hit.png" alt-text="Screenshot of a breakpoint in Visual Studio":::

## Use the Immediate window

The **Immediate** window lets you interact with the application you're debugging. You can interactively change the value of variables to see how it affects your program.

1. If the **Immediate** window is not visible, display it by choosing **View** > **Debug Pads** > **Immediate**.

1. Enter `name = "Gracie"` in the **Immediate** window and press <kbd>enter</kbd>.

1. Enter `currentDate = currentDate.AddDays(1)` in the **Immediate** window and press <kbd>enter</kbd>.

   The **Immediate** window displays the new value of the string variable and the properties of the <xref:System.DateTime> value.

   :::image type="content" source="media/debugging-with-visual-studio-mac/immediate-window.png" alt-text="Immediate Window in Visual Studio":::

   The **Locals** window displays the values of variables that are defined in the currently executing method. The values of the variables that you just changed are updated in the **Locals** window.

   :::image type="content" source="media/debugging-with-visual-studio-mac/locals-window.png" alt-text="Locals Window in Visual Studio":::

1. Press <kbd>⌘</kbd><kbd>↵</kbd> (<kbd>command</kbd>+<kbd>enter</kbd>) to continue debugging.

   The values displayed in the terminal correspond to the changes you made in the **Immediate** window.

   If you don't see the Terminal, select **Terminal - HelloWorld** in the bottom navigation bar.

   :::image type="content" source="media/debugging-with-visual-studio-mac/terminal-hello-world.png" alt-text="Terminal - Hello World in bottom navigation bar":::

1. Press any key to exit the program.

1. Close the terminal window.

## Set a conditional breakpoint

The program displays a string that the user enters. What happens if the user doesn't enter anything? You can test this with a useful debugging feature called a *conditional breakpoint*.

1. <kbd>ctrl</kbd>-click on the red dot that represents the breakpoint. In the context menu, select **Edit Breakpoint**.

1. In the **Edit Breakpoint** dialog, enter the following code in the field that follows **And the following condition is true**, and select **Apply**.

   ```csharp
   String.IsNullOrEmpty(name)
   ```

   :::image type="content" source="media/debugging-with-visual-studio-mac/breakpoint-settings.png" alt-text="Editor showing breakpoint settings panel":::

   Each time the breakpoint is hit, the debugger calls the `String.IsNullOrEmpty(name)` method, and it breaks on this line only if the method call returns `true`.

   Instead of a conditional expression, you can specify a *hit count*, which interrupts program execution before a statement is executed a specified number of times.

1. Press <kbd>⌘</kbd><kbd>↵</kbd> (<kbd>command</kbd>+<kbd>enter</kbd>) to start debugging.

1. In the terminal window, press <kbd>enter</kbd> when prompted to enter your name.

   Because the condition you specified (`name` is either `null` or <xref:System.String.Empty?displayProperty=nameWithType>) has been satisfied, program execution stops when it reaches the breakpoint.

1. Select the **Locals** window, which shows the values of variables that are local to the currently executing method. In this case, `Main` is the currently executing method. Observe that the value of the `name` variable is `""`, that is, <xref:System.String.Empty?displayProperty=nameWithType>.

1. You can also see that the value is an empty string by entering the `name` variable name in the **Immediate** window and pressing <kbd>enter</kbd>.

   :::image type="content" source="media/debugging-with-visual-studio-mac/immediate-window-output.png" alt-text="Immediate window showing name is an empty string":::

1. Press <kbd>⌘</kbd><kbd>↵</kbd> (<kbd>command</kbd>+<kbd>enter</kbd>) to continue debugging.

1. In the terminal window, press any key to exit the program.

1. Close the terminal window.

1. Clear the breakpoint by clicking on the red dot in the left margin of the code window. Another way to clear a breakpoint is by choosing **Run > Toggle Breakpoint** while the line of code is selected.

## Step through a program

Visual Studio also allows you to step line by line through a program and monitor its execution. Ordinarily, you'd set a breakpoint and follow program flow through a small part of your program code. Since this program is small, you can step through the entire program.

1. Set a breakpoint on the curly brace that marks the start of the `Main` method (press <kbd>command</kbd>+<kbd>\\</kbd>).

1. Press <kbd>⌘</kbd><kbd>↵</kbd> (<kbd>command</kbd>+<kbd>enter</kbd>) to start debugging.

   Visual Studio stops on the line with the breakpoint.

1. Press <kbd>⇧</kbd><kbd>⌘</kbd><kbd>I</kbd> (<kbd>shift</kbd>+<kbd>command</kbd>+<kbd>I</kbd>) or select **Run** > **Step Into** to advance one line.

   Visual Studio highlights and displays an arrow beside the next line of execution.

   :::image type="content" source="media/debugging-with-visual-studio-mac/step-into-method.png" alt-text="Visual Studio step into method":::

   At this point, the **Locals** window shows that the `args` array is empty, and `name` and `currentDate` have default values. In addition, Visual Studio has opened a blank terminal.

1. Press <kbd>⇧</kbd><kbd>⌘</kbd><kbd>I</kbd> (<kbd>shift</kbd>+<kbd>command</kbd>+<kbd>I</kbd>).

   Visual Studio highlights the statement that includes the `name` variable assignment. The **Locals** window shows that `name` is `null`, and the terminal displays the string "What is your name?".

1. Respond to the prompt by entering a string in the console window and pressing <kbd>enter</kbd>.

1. Press <kbd>⇧</kbd><kbd>⌘</kbd><kbd>I</kbd> (<kbd>shift</kbd>+<kbd>command</kbd>+<kbd>I</kbd>).

   Visual Studio highlights the statement that includes the `currentDate` variable assignment. The **Locals** window shows the value returned by the call to the <xref:System.Console.ReadLine%2A?displayProperty=nameWithType> method. The terminal displays the string you entered at the prompt.

1. Press <kbd>⇧</kbd><kbd>⌘</kbd><kbd>I</kbd> (<kbd>shift</kbd>+<kbd>command</kbd>+<kbd>I</kbd>).

   The **Locals** window shows the value of the `currentDate` variable after the assignment from the <xref:System.DateTime.Now?displayProperty=nameWithType> property. The terminal is unchanged.

1. Press <kbd>⇧</kbd><kbd>⌘</kbd><kbd>I</kbd> (<kbd>shift</kbd>+<kbd>command</kbd>+<kbd>I</kbd>).

   Visual Studio calls the <xref:System.Console.WriteLine(System.String,System.Object,System.Object)?displayProperty=nameWithType> method. The terminal displays the formatted string.

1. Press <kbd>⇧</kbd><kbd>⌘</kbd><kbd>U</kbd> (<kbd>shift</kbd>+<kbd>command</kbd>+<kbd>U</kbd>) or select **Run** > **Step Out**.

   The terminal displays a message and waits for you to press a key.

1. Press any key to exit the program.

## Use Release build configuration

Once you've tested the Debug version of your application, you should also compile and test the Release version. The Release version incorporates compiler optimizations that can negatively affect the behavior of an application. For example, compiler optimizations that are designed to improve performance can create race conditions in multithreaded applications.

To build and test the Release version of the console application, do the following steps:

1. Change the build configuration on the toolbar from **Debug** to **Release**.

   :::image type="content" source="media/debugging-with-visual-studio-mac/visual-studio-toolbar-release.png" alt-text="default Visual Studio toolbar with release highlighted":::

1. Press <kbd>⌥</kbd><kbd>⌘</kbd><kbd>↵</kbd> (<kbd>option</kbd>+<kbd>command</kbd>+<kbd>enter</kbd>) to run without debugging.

## Next steps

In this tutorial, you used Visual Studio debugging tools. In the next tutorial, you publish a deployable version of the app.

> [!div class="nextstepaction"]
> [Publish a .NET console application using Visual Studio for Mac](publishing-with-visual-studio-mac.md)
