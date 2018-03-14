---
title: "Walkthrough: Authoring a Composite Control with Visual C#"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "custom controls [C#]"
  - "user controls [Windows Forms], creating with Visual C#"
  - "UserControl class [Windows Forms], walkthroughs"
  - "user controls [C#]"
  - "custom controls [Windows Forms], creating"
ms.assetid: f88481a8-c746-4a36-9479-374ce5f2e91f
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Authoring a Composite Control with Visual C# #
Composite controls provide a means by which custom graphical interfaces can be created and reused. A composite control is essentially a component with a visual representation. As such, it might consist of one or more Windows Forms controls, components, or blocks of code that can extend functionality by validating user input, modifying display properties, or performing other tasks required by the author. Composite controls can be placed on Windows Forms in the same manner as other controls. In the first part of this walkthrough, you create a simple composite control called `ctlClock`. In the second part of the walkthrough, you extend the functionality of `ctlClock` through inheritance.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 When you create a new project, you specify its name to set the root namespace, assembly name, and project name, and ensure that the default component will be in the correct namespace.  
  
#### To create the ctlClockLib control library and the ctlClock control  
  
1.  On the **File** menu, point to **New**, and then click **Project** to open the **New Project** dialog box.  
  
2.  From the list of [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)] projects, select the **Windows Forms Control Library** project template, type `ctlClockLib` in the **Name** box, and then click **OK**.  
  
     The project name, `ctlClockLib`, is also assigned to the root namespace by default. The root namespace is used to qualify the names of components in the assembly. For example, if two assemblies provide components named `ctlClock`, you can specify your `ctlClock` component using `ctlClockLib.ctlClock.`  
  
3.  In Solution Explorer, right-click **UserControl1.cs**, and then click **Rename**. Change the file name to `ctlClock.cs`. Click the **Yes** button when you are asked if you want to rename all references to the code element "UserControl1".  
  
    > [!NOTE]
    >  By default, a composite control inherits from the <xref:System.Windows.Forms.UserControl> class provided by the system. The <xref:System.Windows.Forms.UserControl> class provides functionality required by all composite controls, and implements standard methods and properties.  
  
4.  On the **File** menu, click **Save All** to save the project.  
  
## Adding Windows Controls and Components to the Composite Control  
 A visual interface is an essential part of your composite control. This visual interface is implemented by the addition of one or more Windows controls to the designer surface. In the following demonstration, you will incorporate Windows controls into your composite control and write code to implement functionality.  
  
#### To add a Label and a Timer to your composite control  
  
1.  In Solution Explorer, right-click **ctlClock.cs**, and then click **View Designer**.  
  
2.  In the **Toolbox**, expand the **Common Controls** node, and then double-click **Label**.  
  
     A <xref:System.Windows.Forms.Label> control named `label1` is added to your control on the designer surface.  
  
3.  In the designer, click **label1**. In the Properties window, set the following properties.  
  
    |Property|Change to|  
    |--------------|---------------|  
    |**Name**|`lblDisplay`|  
    |**Text**|`(blank space)`|  
    |**TextAlign**|`MiddleCenter`|  
    |**Font.Size**|`14`|  
  
4.  In the **Toolbox**, expand the **Components** node, and then double-click **Timer**.  
  
     Because a <xref:System.Windows.Forms.Timer> is a component, it has no visual representation at run time. Therefore, it does not appear with the controls on the designer surface, but rather in the **Component Designer** (a tray at the bottom of the designer surface).  
  
5.  In the **Component Designer**, click **timer1**, and then set the <xref:System.Windows.Forms.Timer.Interval%2A> property to `1000` and the <xref:System.Windows.Forms.Timer.Enabled%2A> property to `true`.  
  
     The <xref:System.Windows.Forms.Timer.Interval%2A> property controls the frequency with which the <xref:System.Windows.Forms.Timer> component ticks. Each time `timer1` ticks, it runs the code in the `timer1_Tick` event. The interval represents the number of milliseconds between ticks.  
  
6.  In the **Component Designer**, double-click **timer1** to go to the `timer1_Tick` event for `ctlClock`.  
  
7.  Modify the code so that it resembles the following code sample. Be sure to change the access modifier from `private` to `protected`.  
  
    ```csharp  
    protected void timer1_Tick(object sender, System.EventArgs e)  
    {  
        // Causes the label to display the current time.  
        lblDisplay.Text = DateTime.Now.ToLongTimeString();   
    }  
    ```  
  
     This code will cause the current time to be shown in `lblDisplay`. Because the interval of `timer1` was set to `1000`, this event will occur every thousand milliseconds, thus updating the current time every second.  
  
8.  Modify the method to be overridable with the `virtual` keyword. For more information, see the  "Inheriting from a User Control" section below.  
  
    ```csharp  
    protected virtual void timer1_Tick(object sender, System.EventArgs e)  
    ```  
  
9. On the **File** menu, click **Save All** to save the project.  
  
## Adding Properties to the Composite Control  
 Your clock control now encapsulates a <xref:System.Windows.Forms.Label> control and a <xref:System.Windows.Forms.Timer> component, each with its own set of inherent properties. While the individual properties of these controls will not be accessible to subsequent users of your control, you can create and expose custom properties by writing the appropriate blocks of code. In the following procedure, you will add properties to your control that enable the user to change the color of the background and text.  
  
#### To add a property to your composite control  
  
1.  In Solution Explorer, right-click **ctlClock.cs**, and then click **View Code**.  
  
     The **Code Editor** for your control opens.  
  
2.  Locate the `public partial class ctlClock` statement. Beneath the opening brace (`{)`, type the following code.  
  
    ```csharp  
    private Color colFColor;  
    private Color colBColor;  
    ```  
  
     These statements create the private variables that you will use to store the values for the properties you are about to create.  
  
3.  Type the following code beneath the variable declarations from step 2.  
  
    ```csharp  
    // Declares the name and type of the property.  
    public Color ClockBackColor  
    {  
        // Retrieves the value of the private variable colBColor.  
        get  
        {  
            return colBColor;  
        }  
        // Stores the selected value in the private variable colBColor, and   
        // updates the background color of the label control lblDisplay.  
        set  
        {  
            colBColor = value;  
            lblDisplay.BackColor = colBColor;     
        }  
    }  
    // Provides a similar set of instructions for the foreground color.  
    public Color ClockForeColor  
    {  
        get  
        {  
            return colFColor;  
        }  
        set  
        {  
            colFColor = value;  
            lblDisplay.ForeColor = colFColor;  
        }  
    }  
    ```  
  
     The preceding code makes two custom properties, `ClockForeColor` and `ClockBackColor`, available to subsequent users of this control. The `get` and `set` statements provide for storage and retrieval of the property value, as well as code to implement functionality appropriate to the property.  
  
4.  On the **File** menu, click **Save All** to save the project.  
  
## Testing the Control  
 Controls are not stand-alone applications; they must be hosted in a container. Test your control's run-time behavior and exercise its properties with the **UserControl Test Container**. For more information, see [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md).  
  
#### To test your control  
  
1.  Press F5 to build the project and run your control in the **UserControl Test Container**.  
  
2.  In the test container's property grid, locate the `ClockBackColor` property, and then select the property to display the color palette.  
  
3.  Choose a color by clicking it.  
  
     The background color of your control changes to the color you selected.  
  
4.  Use a similar sequence of events to verify that the `ClockForeColor` property is functioning as expected.  
  
     In this section and the preceding sections, you have seen how components and Windows controls can be combined with code and packaging to provide custom functionality in the form of a composite control. You have learned to expose properties in your composite control, and how to test your control after it is complete. In the next section you will learn how to construct an inherited composite control using `ctlClock` as a base.  
  
## Inheriting from a Composite Control  
 In the previous sections, you learned how to combine Windows controls, components, and code into reusable composite controls. Your composite control can now be used as a base upon which other controls can be built. The process of deriving a class from a base class is called *inheritance*. In this section, you will create a composite control called `ctlAlarmClock`. This control will be derived from its parent control, `ctlClock`. You will learn to extend the functionality of `ctlClock` by overriding parent methods and adding new methods and properties.  
  
 The first step in creating an inherited control is to derive it from its parent. This action creates a new control that has all of the properties, methods, and graphical characteristics of the parent control, but can also act as a base for the addition of new or modified functionality.  
  
#### To create the inherited control  
  
1.  In Solution Explorer, right-click **ctlClockLib**, point to **Add**, and then click **User Control**.  
  
     The **Add New Item** dialog box opens.  
  
2.  Select the **Inherited User Control** template.  
  
3.  In the **Name** box, type `ctlAlarmClock.cs`, and then click **Add**.  
  
     The **Inheritance Picker** dialog box appears.  
  
4.  Under **Component Name**, double-click **ctlClock**.  
  
5.  In Solution Explorer, browse through the current projects.  
  
    > [!NOTE]
    >  A file called **ctlAlarmClock.cs** has been added to the current project.  
  
### Adding the Alarm Properties  
 Properties are added to an inherited control in the same way they are added to a composite control. You will now use the property declaration syntax to add two properties to your control: `AlarmTime`, which will store the value of the date and time the alarm is to go off, and `AlarmSet`, which will indicate whether the alarm is set.  
  
##### To add properties to your composite control  
  
1.  In Solution Explorer, right-click **ctlAlarmClock**, and then click **View Code**.  
  
2.  Locate the `public class` statement. Note that your control inherits from `ctlClockLib.ctlClock`. Beneath the opening brace (`{)` statement, type the following code.  
  
    ```csharp  
    private DateTime dteAlarmTime;  
    private bool blnAlarmSet;  
    // These properties will be declared as public to allow future   
    // developers to access them.  
    public DateTime AlarmTime  
    {  
        get  
        {  
            return dteAlarmTime;  
        }  
        set  
        {  
            dteAlarmTime = value;  
        }  
    }  
    public bool AlarmSet  
    {  
        get  
        {  
            return blnAlarmSet;  
        }  
        set  
        {  
            blnAlarmSet = value;  
        }  
    }  
    ```  
  
### Adding to the Graphical Interface of the Control  
 Your inherited control has a visual interface that is identical to the control it inherits from. It possesses the same constituent controls as its parent control, but the properties of the constituent controls will not be available unless they were specifically exposed. You may add to the graphical interface of an inherited composite control in the same manner as you would add to any composite control. To continue adding to your alarm clock's visual interface, you will add a label control that will flash when the alarm is sounding.  
  
##### To add the label control  
  
1.  In Solution Explorer, right-click **ctlAlarmClock**, and then click **View Designer**.  
  
     The designer for `ctlAlarmClock` opens in the main window.  
  
2.  Click the display portion of the control, and view the Properties window.  
  
    > [!NOTE]
    >  While all the properties are displayed, they are dimmed. This indicates that these properties are native to `lblDisplay` and cannot be modified or accessed in the Properties window. By default, controls contained in a composite control are `private`, and their properties are not accessible by any means.  
  
    > [!NOTE]
    >  If you want subsequent users of your composite control to have access to its internal controls, declare them as `public` or `protected`. This will allow you to set and modify properties of controls contained within your composite control by using the appropriate code.  
  
3.  Add a <xref:System.Windows.Forms.Label> control to your composite control.  
  
4.  Using the mouse, drag the <xref:System.Windows.Forms.Label> control immediately beneath the display box. In the Properties window, set the following properties.  
  
    |Property|Setting|  
    |--------------|-------------|  
    |**Name**|`lblAlarm`|  
    |**Text**|**Alarm!**|  
    |**TextAlign**|`MiddleCenter`|  
    |**Visible**|`false`|  
  
### Adding the Alarm Functionality  
 In the previous procedures, you added properties and a control that will enable alarm functionality in your composite control. In this procedure, you will add code to compare the current time to the alarm time and, if they are the same, to flash an alarm. By overriding the `timer1_Tick` method of `ctlClock` and adding additional code to it, you will extend the capability of `ctlAlarmClock` while retaining all of the inherent functionality of `ctlClock`.  
  
##### To override the timer1_Tick method of ctlClock  
  
1.  In the **Code Editor**, locate the `private bool blnAlarmSet;` statement. Immediately beneath it, add the following statement.  
  
    ```csharp  
    private bool blnColorTicker;  
    ```  
  
2.  In the **Code Editor**, locate the closing brace (`})` at the end of the class. Just before the brace, add the following code.  
  
    ```csharp  
    protected override void timer1_Tick(object sender, System.EventArgs e)  
    {  
        // Calls the Timer1_Tick method of ctlClock.  
        base.timer1_Tick(sender, e);  
        // Checks to see if the alarm is set.  
        if (AlarmSet == false)  
            return;  
        else  
            // If the date, hour, and minute of the alarm time are the same as  
            // the current time, flash an alarm.   
        {  
            if (AlarmTime.Date == DateTime.Now.Date && AlarmTime.Hour ==   
                DateTime.Now.Hour && AlarmTime.Minute == DateTime.Now.Minute)  
            {  
                // Sets lblAlarmVisible to true, and changes the background color based on  
                // the value of blnColorTicker. The background color of the label   
                // will flash once per tick of the clock.  
                lblAlarm.Visible = true;  
                if (blnColorTicker == false)   
                {  
                    lblAlarm.BackColor = Color.Red;  
                    blnColorTicker = true;  
                }  
                else  
                {  
                    lblAlarm.BackColor = Color.Blue;  
                    blnColorTicker = false;  
                }  
            }  
            else  
            {  
                // Once the alarm has sounded for a minute, the label is made   
                // invisible again.  
                lblAlarm.Visible = false;  
            }  
        }  
    }  
    ```  
  
     The addition of this code accomplishes several tasks. The `override` statement directs the control to use this method in place of the method that was inherited from the base control. When this method is called, it calls the method it overrides by invoking the `base.timer1_Tick` statement, ensuring that all of the functionality incorporated in the original control is reproduced in this control. It then runs additional code to incorporate the alarm functionality. A flashing label control will appear when the alarm occurs.  
  
     Your alarm clock control is almost complete. The only thing that remains is to implement a way to turn it off. To do this, you will add code to the `lblAlarm_Click` method.  
  
##### To implement the shutoff method  
  
1.  In Solution Explorer, right-click **ctlAlarmClock.cs**, and then click **View Designer**.  
  
     The designer opens.  
  
2.  Add a button to the control. Set the properties of the button as follows.  
  
    |Property|Value|  
    |--------------|-----------|  
    |**Name**|`btnAlarmOff`|  
    |**Text**|**Disable Alarm**|  
  
3.  In the designer, double-click **btnAlarmOff**.  
  
     The **Code Editor** opens to the `private void btnAlarmOff_Click` line.  
  
4.  Modify this method so that it resembles the following code.  
  
    ```csharp  
    private void btnAlarmOff_Click(object sender, System.EventArgs e)  
    {  
        // Turns off the alarm.  
        AlarmSet = false;  
        // Hides the flashing label.  
        lblAlarm.Visible = false;  
    }  
    ```  
  
5.  On the **File** menu, click **Save All** to save the project.  
  
### Using the Inherited Control on a Form  
 You can test your inherited control the same way you tested the base class control, `ctlClock`: Press F5 to build the project and run your control in the **UserControl Test Container**. For more information, see [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md).  
  
 To put your control to use, you will need to host it on a form. As with a standard composite control, an inherited composite control cannot stand alone and must be hosted in a form or other container. Since `ctlAlarmClock` has a greater depth of functionality, additional code is required to test it. In this procedure, you will write a simple program to test the functionality of `ctlAlarmClock`. You will write code to set and display the `AlarmTime` property of `ctlAlarmClock`, and will test its inherent functions.  
  
##### To build and add your control to a test form  
  
1.  In Solution Explorer, right-click **ctlClockLib**, and then click **Build**.  
  
2.  Add a new **Windows Application** project to the solution, and name it `Test`.  
  
3.  In Solution Explorer, right-click the **References** node for your test project. Click **Add Reference** to display the **Add Reference** dialog box. Click the tab labeled **Projects**. Your `ctlClockLib` project will be listed under **Project Name**. Double-click the project to add the reference to the test project.  
  
4.  In Solution Explorer, right-click **Test**, and then click **Build**.  
  
5.  In the **Toolbox**, expand the **ctlClockLib Components** node.  
  
6.  Double-click **ctlAlarmClock** to add a copy of `ctlAlarmClock` to your form.  
  
7.  In the **Toolbox**, locate and double-click **DateTimePicker** to add a <xref:System.Windows.Forms.DateTimePicker> control to your form, and then add a <xref:System.Windows.Forms.Label> control by double-clicking **Label**.  
  
8.  Use the mouse to position the controls in a convenient place on the form.  
  
9. Set the properties of these controls in the following manner.  
  
    |Control|Property|Value|  
    |-------------|--------------|-----------|  
    |`label1`|**Text**|`(blank space)`|  
    ||**Name**|`lblTest`|  
    |`dateTimePicker1`|**Name**|`dtpTest`|  
    ||**Format**|<xref:System.Windows.Forms.DateTimePickerFormat.Time>|  
  
10. In the designer, double-click **dtpTest**.  
  
     The **Code Editor** opens to `private void dtpTest_ValueChanged`.  
  
11. Modify the code so that it resembles the following.  
  
    ```csharp  
    private void dtpTest_ValueChanged(object sender, System.EventArgs e)  
    {  
        ctlAlarmClock1.AlarmTime = dtpTest.Value;  
        ctlAlarmClock1.AlarmSet = true;  
        lblTest.Text = "Alarm Time is " +  
            ctlAlarmClock1.AlarmTime.ToShortTimeString();  
    }  
    ```  
  
12. In Solution Explorer, right-click **Test**, and then click **Set as StartUp Project**.  
  
13. On the **Debug** menu, click **Start Debugging**.  
  
     The test program starts. Note that the current time is updated in the `ctlAlarmClock` control, and that the starting time is shown in the <xref:System.Windows.Forms.DateTimePicker> control.  
  
14. Click the <xref:System.Windows.Forms.DateTimePicker> where the minutes of the hour are displayed.  
  
15. Using the keyboard, set a value for minutes that is one minute greater than the current time shown by `ctlAlarmClock`.  
  
     The time for the alarm setting is shown in `lblTest`. Wait for the displayed time to reach the alarm setting time. When the displayed time reaches the time to which the alarm is set, the `lblAlarm` will flash.  
  
16. Turn off the alarm by clicking `btnAlarmOff`. You may now reset the alarm.  
  
     This walkthrough has covered a number of key concepts. You have learned to create a composite control by combining controls and components into a composite control container. You have learned to add properties to your control, and to write code to implement custom functionality. In the last section, you learned to extend the functionality of a given composite control through inheritance, and to alter the functionality of host methods by overriding those methods.  
  
## See Also  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)  
 [Programming with Components](http://msdn.microsoft.com/library/d4d4fcb4-e0b8-46b3-b679-7ee0026eb9e3)  
 [Component Authoring Walkthroughs](http://msdn.microsoft.com/library/c414cca9-2489-4208-8b38-954586d91c13)  
 [How to: Display a Control in the Choose Toolbox Items Dialog Box](../../../../docs/framework/winforms/controls/how-to-display-a-control-in-the-choose-toolbox-items-dialog-box.md)  
 [Walkthrough: Inheriting from a Windows Forms Control with Visual C#](../../../../docs/framework/winforms/controls/walkthrough-inheriting-from-a-windows-forms-control-with-visual-csharp.md)
