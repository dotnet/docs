---
title: "How to: Simulate Mouse and Keyboard Events in Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "keyboards [Windows Forms], event simulation"
  - "user input [Windows Forms], simulating"
  - "SendKeys [Windows Forms], using"
  - "mouse clicks [Windows Forms], simulating"
  - "mouse [Windows Forms], event simulation"
ms.assetid: 6abcb67e-3766-4af2-9590-bf5dabd17e41
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Simulate Mouse and Keyboard Events in Code
Windows Forms provides several options for programmatically simulating mouse and keyboard input. This topic provides an overview of these options.  
  
## Simulating Mouse Input  
 The best way to simulate mouse events is to call the `On`*EventName* method that raises the mouse event you want to simulate. This option is usually possible only within custom controls and forms, because the methods that raise events are protected and cannot be accessed outside the control or form. For example, the following steps illustrate how to simulate clicking the right mouse button in code.  
  
#### To programmatically click the right mouse button  
  
1.  Create a <xref:System.Windows.Forms.MouseEventArgs> whose <xref:System.Windows.Forms.MouseEventArgs.Button%2A> property is set to the <xref:System.Windows.Forms.MouseButtons.Right?displayProperty=nameWithType> value.  
  
2.  Call the <xref:System.Windows.Forms.Control.OnMouseClick%2A> method with this <xref:System.Windows.Forms.MouseEventArgs> as the argument.  
  
 For more information on custom controls, see [Developing Windows Forms Controls at Design Time](../../../docs/framework/winforms/controls/developing-windows-forms-controls-at-design-time.md).  
  
 There are other ways to simulate mouse input. For example, you can programmatically set a control property that represents a state that is typically set through mouse input (such as the <xref:System.Windows.Forms.CheckBox.Checked%2A> property of the <xref:System.Windows.Forms.CheckBox> control), or you can directly call the delegate that is attached to the event you want to simulate.  
  
## Simulating Keyboard Input  
 Although you can simulate keyboard input by using the strategies discussed above for mouse input, Windows Forms also provides the <xref:System.Windows.Forms.SendKeys> class for sending keystrokes to the active application.  
  
> [!CAUTION]
>  If your application is intended for international use with a variety of keyboards, the use of <xref:System.Windows.Forms.SendKeys.Send%2A?displayProperty=nameWithType> could yield unpredictable results and should be avoided.  
  
> [!NOTE]
>  The <xref:System.Windows.Forms.SendKeys> class has been updated for the .NET Framework 3.0 to enable its use in applications that run on Windows Vista. The enhanced security of Windows Vista (known as User Account Control or UAC) prevents the previous implementation from working as expected.  
>   
>  The <xref:System.Windows.Forms.SendKeys> class is susceptible to timing issues, which some developers have had to work around. The updated implementation is still susceptible to timing issues, but is slightly faster and may require changes to the workarounds. The <xref:System.Windows.Forms.SendKeys> class tries to use the previous implementation first, and if that fails, uses the new implementation. As a result, the <xref:System.Windows.Forms.SendKeys> class may behave differently on different operating systems. Additionally, when the <xref:System.Windows.Forms.SendKeys> class uses the new implementation, the <xref:System.Windows.Forms.SendKeys.SendWait%2A> method will not wait for messages to be processed when they are sent to another process.  
>   
>  If your application relies on consistent behavior regardless of the operating system, you can force the <xref:System.Windows.Forms.SendKeys> class to use the new implementation by adding the following application setting to your app.config file.  
>   
>  `<appSettings>`  
>   
>  `<add key="SendKeys" value="SendInput"/>`  
>   
>  `</appSettings>`  
>   
>  To force the <xref:System.Windows.Forms.SendKeys> class to use the previous implementation, use the value `"JournalHook"` instead.  
  
#### To send a keystroke to the same application  
  
1.  Call the <xref:System.Windows.Forms.SendKeys.Send%2A> or <xref:System.Windows.Forms.SendKeys.SendWait%2A> method of the <xref:System.Windows.Forms.SendKeys> class. The specified keystrokes will be received by the active control of the application. The following code example uses <xref:System.Windows.Forms.SendKeys.Send%2A> to simulate pressing the ENTER key when the user double-clicks the surface of the form. This example assumes a <xref:System.Windows.Forms.Form> with a single <xref:System.Windows.Forms.Button> control that has a tab index of 0.  
  
     [!code-cpp[System.Windows.Forms.SimulateKeyPress#10](../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/cpp/form1.cpp#10)]
     [!code-csharp[System.Windows.Forms.SimulateKeyPress#10](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/CS/form1.cs#10)]
     [!code-vb[System.Windows.Forms.SimulateKeyPress#10](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/VB/form1.vb#10)]  
  
#### To send a keystroke to a different application  
  
1.  Activate the application window that will receive the keystrokes, and then call the <xref:System.Windows.Forms.SendKeys.Send%2A> or <xref:System.Windows.Forms.SendKeys.SendWait%2A> method. Because there is no managed method to activate another application, you must use native Windows methods to force focus on other applications. The following code example uses platform invoke to call the `FindWindow` and `SetForegroundWindow` methods to activate the Calculator application window, and then calls <xref:System.Windows.Forms.SendKeys.SendWait%2A> to issue a series of calculations to the Calculator application.  
  
    > [!NOTE]
    >  The correct parameters of the `FindWindow` call that locates the Calculator application vary based on your version of Windows.  The following code finds the Calculator application on [!INCLUDE[win7](../../../includes/win7-md.md)]. On [!INCLUDE[windowsver](../../../includes/windowsver-md.md)], change the first parameter to "SciCalc". You can use the Spy++ tool, included with Visual Studio, to determine the correct parameters.  
  
     [!code-cpp[System.Windows.Forms.SimulateKeyPress#5](../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/cpp/form1.cpp#5)]
     [!code-csharp[System.Windows.Forms.SimulateKeyPress#5](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/CS/form1.cs#5)]
     [!code-vb[System.Windows.Forms.SimulateKeyPress#5](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/VB/form1.vb#5)]  
  
## Example  
 The following code example is the complete application for the previous code examples.  
  
 [!code-cpp[System.Windows.Forms.SimulateKeyPress#0](../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/cpp/form1.cpp#0)]
 [!code-csharp[System.Windows.Forms.SimulateKeyPress#0](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/CS/form1.cs#0)]
 [!code-vb[System.Windows.Forms.SimulateKeyPress#0](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/VB/form1.vb#0)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Drawing and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## See Also  
 [User Input in Windows Forms](../../../docs/framework/winforms/user-input-in-windows-forms.md)
