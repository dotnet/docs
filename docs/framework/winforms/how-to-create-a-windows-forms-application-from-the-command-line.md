---
title: "How to: Create a Windows Forms application from the command line"
ms.date: "03/14/2018"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-winforms"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Windows Forms, application development from command line"
  - "Windows Forms, getting started"
  - "Windows Forms, creating basic form"
ms.assetid: 45ad3f8b-1c26-4c9f-91a9-3bb0759a47a4
author: rpetrusha
ms.author: ronpet
ms.workload: 
  - dotnet
---
# How to: Create a Windows Forms application from the command line
The following procedures describe the basic steps that you must complete to create and run a Windows Forms application from the command line. There is extensive support for these procedures in Visual Studio.  Also see [Walkthrough: Creating a Simple Windows Form](http://msdn.microsoft.com/library/z9w2f38k\(v=vs.100\)).  
  
## Procedure  
  
#### To create the form  
  
1.  In an empty code file, type the following import or using statements:  
  
     [!code-csharp[System.Windows.Forms.BasicForm#2](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.BasicForm#2](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/VB/Form1.vb#2)]  
  
2.  Declare a class named `Form1` that inherits from the Form class.  
  
     [!code-csharp[System.Windows.Forms.BasicForm#3](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.BasicForm#3](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/VB/Form1.vb#3)]  
  
3.  Create a default constructor for `Form1`.  
  
     You will add more code to the constructor in a subsequent procedure.  
  
     [!code-csharp[System.Windows.Forms.BasicForm#4](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/CS/Form1.cs#4)]
     [!code-vb[System.Windows.Forms.BasicForm#4](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/VB/Form1.vb#4)]  
  
4.  Add a `Main` method to the class.  
  
    1.  Apply the <xref:System.STAThreadAttribute> to the C# `Main` method to specify your Windows Forms application is a single-threaded apartment. (The attribute is not necessary in Visual Basic, since Windows forms applications developed with Visual Basic use a single-threaded apartment model by default.)  
  
    2.  Call <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> to apply operating system styles to your application.  
  
    3.  Create an instance of the form and run it.  
  
     [!code-csharp[System.Windows.Forms.BasicForm#5](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/CS/Form1.cs#5)]
     [!code-vb[System.Windows.Forms.BasicForm#5](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BasicForm/VB/Form1.vb#5)]  
  
#### To compile and run the application  
  
1.  At the .NET Framework command prompt, navigate to the directory you created the `Form1` class.  
  
2.  Compile the form.  
  
    -   If you are using C#, type: `csc form1.cs`  
  
         `-or-`  
  
    -   If you are using Visual Basic, type: `vbc form1.vb`  
  
3.  At the command prompt, type: `Form1.exe`  
  
## Adding a Control and Handling an Event  
 The previous procedure steps demonstrated how to just create a basic Windows Form that compiles and runs. The next procedure will show you how to create and add a control to the form, and handle an event for the control. For more information about the controls you can add to Windows Forms, see [Windows Forms Controls](../../../docs/framework/winforms/controls/index.md).  
  
 In addition to understanding how to create Windows Forms applications, you should understand event-based programming and how to handle user input. For more information, see [Creating Event Handlers in Windows Forms](../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md), and [Handling User Input](../../../docs/framework/winforms/controls/handling-user-input.md)  
  
#### To declare a button control and handle its click event  
  
1.  Declare a button control named `button1`.  
  
2.  In the constructor, create the button and set its <xref:System.Windows.Forms.Control.Size%2A>, <xref:System.Windows.Forms.Control.Location%2A> and <xref:System.Windows.Forms.Control.Text%2A> properties.  
  
3.  Add the button to the form.  
  
     The following code example demonstrates how to declare the button control.  
  
     [!code-csharp[System.Windows.Forms.FormWithButton#2](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.FormWithButton#2](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/VB/Form1.vb#2)]  
  
4.  Create a method to handle the <xref:System.Windows.Forms.Control.Click> event for the button.  
  
5.  In the click event handler, display a <xref:System.Windows.Forms.MessageBox> with the message, "Hello World".  
  
     The following code example demonstrates how to handle the button control's click event.  
  
     [!code-csharp[System.Windows.Forms.FormWithButton#3](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.FormWithButton#3](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/VB/Form1.vb#3)]  
  
6.  Associate the <xref:System.Windows.Forms.Control.Click> event with the method you created.  
  
     The following code example demonstrates how to associate the event with the method.  
  
     [!code-csharp[System.Windows.Forms.FormWithButton#4](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/CS/Form1.cs#4)]
     [!code-vb[System.Windows.Forms.FormWithButton#4](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/VB/Form1.vb#4)]  
  
7.  Compile and run the application as described in the previous procedure.  
  
## Example  
 Following code example is the complete example from the previous procedures.  
  
 [!code-csharp[System.Windows.Forms.FormWithButton#1](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.FormWithButton#1](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FormWithButton/VB/Form1.vb#1)]  
  
## Compiling the Code  
  
-   To compile the code, follow the instructions in the proceeding procedure that describe how to compile and run the application.  
  
## See Also  
 <xref:System.Windows.Forms.Form>  
 <xref:System.Windows.Forms.Control>  
 [Changing the Appearance of Windows Forms](../../../docs/framework/winforms/changing-the-appearance-of-windows-forms.md)  
 [Enhancing Windows Forms Applications](../../../docs/framework/winforms/advanced/index.md)  
 [Getting Started with Windows Forms](../../../docs/framework/winforms/getting-started-with-windows-forms.md)
