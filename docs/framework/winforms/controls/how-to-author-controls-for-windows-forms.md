---
title: "How to: Author Controls for Windows Forms"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "controls [Windows Forms], creating"
  - "UserControl class [Windows Forms], Windows Forms"
  - "custom controls [Windows Forms], creating"
ms.assetid: 7570e982-545b-4c3a-a7c7-55581d313400
author: gewarren
ms.author: gewarren
manager: jillfra
---
# How to: Author controls for Windows Forms

A control represents a graphical link between the user and the program. A control can provide or process data, accept user input, respond to events, or perform any number of other functions that connect the user and the application. Because a control is essentially a component with a graphical interface, it can serve any function that a component does, as well as provide user interaction. Controls are created to serve specific purposes, and authoring controls is just another programming task. With that in mind, the following steps represent an overview of the control authoring process. Links provide additional information on the individual steps.

## To author a control

1. Determine what you want your control to accomplish, or what part it will play in your application. Factors to consider are:

    - What kind of graphical interface do you need?

    - What specific user interactions will this control handle?

    - Is the functionality you need provided by any existing controls?

    - Can you get the functionality you need by combining several Windows Forms controls?

2. If you need an object model for your control, determine how functionality will be distributed throughout the object model, and divide up functionality between the control and any subobjects. An object model may be useful if you are planning a complex control, or want to incorporate several functionalities.

3. Determine the type of control (for example, user control, custom control, inherited Windows Forms control) you need. For details, see [Control Type Recommendations](control-type-recommendations.md) and [Varieties of Custom Controls](varieties-of-custom-controls.md).

4. Express functionality as properties, methods, and events of the control and its subobjects or subsidiary structures, and assign appropriate access levels (for example, public, protected, and so on).

5. If you need custom painting for your control, add code for it. For details, see [Custom Control Painting and Rendering](custom-control-painting-and-rendering.md).

6. If your control inherits from <xref:System.Windows.Forms.UserControl>, you can test its runtime behavior by building the control project and running it in the **UserControl Test Container**. For more information, see [How to: Test the Run-Time Behavior of a UserControl](how-to-test-the-run-time-behavior-of-a-usercontrol.md).

7. You can also test and debug your control by creating a new project, such as a Windows Application, and placing it into a container. This process is demonstrated as part of [Walkthrough: Authoring a Composite Control](walkthrough-authoring-a-composite-control-with-visual-csharp.md).

8. As you add each feature, add features to your test project to exercise the new functionality.

9. Repeat, refining the design.

10. Package and deploy your control. For details, see [First look at deployment in Visual Studio](/visualstudio/deployment/deploying-applications-services-and-components).

## See also

- [How to: Inherit from the UserControl Class](how-to-inherit-from-the-usercontrol-class.md)
- [How to: Inherit from the Control Class](how-to-inherit-from-the-control-class.md)
- [How to: Inherit from Existing Windows Forms Controls](how-to-inherit-from-existing-windows-forms-controls.md)
- [How to: Test the Run-Time Behavior of a UserControl](how-to-test-the-run-time-behavior-of-a-usercontrol.md)
- [Varieties of Custom Controls](varieties-of-custom-controls.md)
