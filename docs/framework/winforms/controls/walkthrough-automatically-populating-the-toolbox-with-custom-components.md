---
title: "Walkthrough: Automatically Populating the Toolbox with Custom Components"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "IToolboxService interface"
  - "Toolbox [Windows Forms], populating"
  - "custom components [Windows Forms], adding to Toolbox"
ms.assetid: 2fa1e3e8-6b9f-42b2-97c0-2be57444dba4
---
# Walkthrough: Automatically Populating the Toolbox with Custom Components

If your components are defined by a project in the currently open solution, they will automatically appear in the **Toolbox**, with no action required by you. You can also manually populate the **Toolbox** with your custom components by using the [Choose Toolbox Items Dialog Box (Visual Studio)](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/dyca0t6t(v=vs.100)), but the **Toolbox** takes account of items in your solution's build outputs with all the following characteristics:

- Implements <xref:System.ComponentModel.IComponent>;

- Does not have <xref:System.ComponentModel.ToolboxItemAttribute> set to `false`;

- Does not have <xref:System.ComponentModel.DesignTimeVisibleAttribute> set to `false`.

> [!NOTE]
> The **Toolbox** does not follow reference chains, so it won't display items that are not built by a project in your solution.

This walkthrough demonstrates how a custom component automatically appears in the **Toolbox** once the component is built. Tasks illustrated in this walkthrough include:

- Creating a Windows Forms project.

- Creating a custom component.

- Creating an instance of a custom component.

- Unloading and reloading a custom component.

When you are finished, you will see that the **Toolbox** is populated with a component that you have created.

## Create the project

1. In Visual Studio, create a Windows-based application project called `ToolboxExample` (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **Windows Forms Application**).

2. Add a new component to the project. Call it `DemoComponent`.

     For more information, see [How to: Add New Project Items](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/w0572c5b(v=vs.100)).

3. Build the project.

4. From the **Tools** menu, click the **Options** item. Click **General** under the **Windows Forms Designer** item and ensure that the **AutoToolboxPopulate** option is set to **True**.

## Create an instance of a custom component

The next step is to create an instance of the custom component on the form. Because the **Toolbox** automatically accounts for the new component, this is as easy as creating any other component or control.

1. Open the project's form in the **Forms Designer**.

2. In the **Toolbox**, click the new tab called **ToolboxExample Components**.

     Once you click the tab, you will see **DemoComponent**.

    > [!NOTE]
    > For performance reasons, components in the auto-populated area of the **Toolbox** do not display custom bitmaps, and the <xref:System.Drawing.ToolboxBitmapAttribute> is not supported. To display an icon for a custom component in the **Toolbox**, use the **Choose Toolbox Items** dialog box to load your component.

3. Drag your component onto your form.

     An instance of the component is created and added to the **Component Tray**.

## Unload and reload a custom component

The **Toolbox** takes account of the components in each loaded project, and when a project is unloaded, it removes references to the project's components.

1. Unload the project from the solution.

     For more information about unloading projects, see [How to: Unload and Reload Projects](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/tt479x1t(v=vs.100)). If you are prompted to save, choose **Yes**.

2. Add a new **Windows Application** project to the solution. Open the form in the **Designer**.

     The **ToolboxExample Components** tab from the previous project is now gone.

3. Reload the `ToolboxExample` project.

     The **ToolboxExample Components** tab now reappears.

## Next steps

This walkthrough demonstrates that the **Toolbox** takes account of a project's components, but the **Toolbox** is also takes account of controls. Experiment with your own custom controls by adding and removing control projects from your solution.

## See also

- [General, Windows Forms Designer, Options Dialog Box](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/5aazxs78(v=vs.100))
- [How to: Manipulate Toolbox Tabs](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/66kwe227(v=vs.100))
- [Choose Toolbox Items Dialog Box (Visual Studio)](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/dyca0t6t(v=vs.100))
- [Putting Controls on Windows Forms](putting-controls-on-windows-forms.md)
