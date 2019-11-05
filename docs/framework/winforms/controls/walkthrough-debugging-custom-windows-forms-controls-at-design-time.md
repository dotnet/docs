---
title: "Walkthrough: Debugging Custom Windows Forms Controls at Design Time"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "debugging [Visual Studio], walkthroughs"
  - "custom controls [Windows Forms], walkthroughs"
  - "visual editors"
  - "debugging [Visual Studio], Windows Forms"
  - "custom controls [Windows Forms], debugging"
  - "designers"
  - "controls [Windows Forms], debugging"
  - "walkthroughs [Windows Forms], debugging"
  - "design-time debugging"
ms.assetid: 1fd83ccd-3798-42fc-85a3-6cba99467387
author: jillre
ms.author: jillfra
manager: jillfra
---
# Walkthrough: Debug Custom Windows Forms Controls at Design Time

When you create a custom control, you will often find it necessary to debug its design-time behavior. This is especially true if you are authoring a custom designer for your custom control. For details, see [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](creating-a-wf-control-design-time-features.md).

You can debug your custom controls using Visual Studio, just as you would debug any other .NET Framework classes. The difference is that you will debug a separate instance of Visual Studio that is running your custom control's code.

## Create the project

The first step is to create the application project. You will use this project to build the application that hosts the custom control.

In Visual Studio, create a Windows Application project, and name it **DebuggingExample**.

## Create the control library project

1. Add a **Windows Control Library** project to the solution.

2. Add a new **UserControl** item to the DebugControlLibrary project. Name it **DebugControl**.

3. In **Solution Explorer**, delete the project's default control by deleting the code file with a base name of UserControl1.

4. Build the solution.

## Checkpoint

At this point, you will be able to see your custom control in the **Toolbox**.

To check your progress, find the new tab called **DebugControlLibrary Components** and click to select it. When it opens, you will see your control listed as **DebugControl** with the default icon beside it.

## Add a property to your custom control

To demonstrate that your custom control's code is running at design-time, you will add a property and set a breakpoint in the code that implements the property.

1. Open **DebugControl** in the **Code Editor**. Add the following code to the class definition:

    ```vb
    Private demoStringValue As String = Nothing
    <BrowsableAttribute(true)>
    Public Property DemoString() As String

        Get
            Return Me.demoStringValue
        End Get

        Set(ByVal value As String)
            Me.demoStringValue = value
        End Set

    End Property
    ```

    ```csharp
    private string demoStringValue = null;
    [Browsable(true)]
    public string DemoString
    {
        get
        {
            return this.demoStringValue;
        }
        set
        {
            demoStringValue = value;
        }
    }
    ```

2. Build the solution.

## Add your custom control to the host form

To debug the design-time behavior of your custom control, you will place an instance of the custom control class on a host form.

1. In the "DebuggingExample" project, open Form1 in the **Windows Forms Designer**.

2. In the **Toolbox**, open the **DebugControlLibrary Components** tab and drag a **DebugControl** instance onto the form.

3. Find the `DemoString` custom property in the **Properties** window. Note that you can change its value as you would any other property. Also note that when the `DemoString` property is selected, the property's description string appears at the bottom of the **Properties** window.

## Set up the project for design-time debugging

To debug your custom control's design-time behavior, you will debug a separate instance of Visual Studio that is running your custom control's code.

1. Right-click on the **DebugControlLibrary** project in the **Solution Explorer** and select **Properties**.

2. In the **DebugControlLibrary** property sheet, select the **Debug** tab.

     In the **Start Action** section, select **Start external program**. You will be debugging a separate instance of Visual Studio, so click the ellipsis (![The Ellipsis button (...) in the Properties window of Visual Studio](./media/visual-studio-ellipsis-button.png)) button to browse for the Visual Studio IDE. The name of the executable file is **devenv.exe**, and if you installed to the default location, its path is *%ProgramFiles(x86)%\Microsoft Visual Studio\2019\\\<edition>\Common7\IDE*.

3. Select **OK** to close the dialog box.

4. Right-click the **DebugControlLibrary** project and select **Set as StartUp Project** to enable this debugging configuration.

## Debug your custom control at design time

Now you are ready to debug your custom control as it runs in design mode. When you start the debugging session, a new instance of Visual Studio will be created, and you will use it to load the "DebuggingExample" solution. When you open Form1 in the **Forms Designer**, an instance of your custom control will be created and will start running.

1. Open the **DebugControl** source file in the **Code Editor** and place a breakpoint on the `Set` accessor of the `DemoString` property.

2. Press **F5** to start the debugging session. A new instance of Visual Studio is created. You can distinguish between the instances in two ways:

    - The debugging instance has the word **Running** in its title bar

    - The debugging instance has the **Start** button on its **Debug** toolbar disabled

   Your breakpoint is set in the debugging instance.

3. In the new instance of Visual Studio, open the "DebuggingExample" solution. You can easily find the solution by selecting **Recent Projects** from the **File** menu. The "DebuggingExample.sln" solution file will be listed as the most recently used file.

4. Open Form1 in the **Forms Designer** and select the **DebugControl** control.

5. Change the value of the `DemoString` property. When you commit the change, the debugging instance of Visual Studio acquires focus and execution stops at your breakpoint. You can single-step through the property accessor just as your would any other code.

6. To stop debugging, exit the hosted instance of Visual Studio or select the **Stop Debugging** button in the debugging instance.

## Next steps

Now that you can debug your custom controls at design time, there are many possibilities for expanding your control's interaction with the Visual Studio IDE.

- You can use the <xref:System.ComponentModel.Component.DesignMode%2A> property of the <xref:System.ComponentModel.Component> class to write code that will only execute at design time. For details, see <xref:System.ComponentModel.Component.DesignMode%2A>.

- There are several attributes you can apply to your control's properties to manipulate your custom control's interaction with the designer. You can find these attributes in the <xref:System.ComponentModel?displayProperty=nameWithType> namespace.

- You can write a custom designer for your custom control. This gives you complete control over the design experience using the extensible designer infrastructure exposed by Visual Studio. For details, see [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](creating-a-wf-control-design-time-features.md).

## See also

- [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](creating-a-wf-control-design-time-features.md)
