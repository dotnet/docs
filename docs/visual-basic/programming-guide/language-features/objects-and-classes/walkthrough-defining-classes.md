---
title: "Defining Classes (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "execution [Visual Basic], ending"
  - "objects [Visual Basic], initializing"
  - "Initialize event [Visual Basic]"
  - "files [Visual Basic], closing"
  - "programs [Visual Basic], quitting"
  - "code, exiting"
  - "objects [Visual Basic], creating"
  - "program termination"
  - "classes [Visual Basic], walkthroughs"
  - "class modules, walkthroughs"
  - "Terminate event [Visual Basic]"
  - "execution [Visual Basic], stopping"
ms.assetid: 07018828-2d49-4cf5-a44b-19fb15d9efea
---
# Walkthrough: Defining Classes (Visual Basic)

This walkthrough demonstrates how to define classes, which you can then use to create objects. It also shows you how to add properties and methods to the new class, and demonstrates how to initialize an object.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
## To define a class
  
1.  Create a project by clicking **New Project** on the **File** menu. The **New Project** dialog box appears.  
  
2.  Select Windows Application from the list of Visual Basic project templates to display the new project.  
  
3.  Add a new class to the project by clicking **Add Class** on the **Project** menu. The **Add New Item** dialog box appears.  
  
4.  Select the **Class** template.  
  
5.  Name the new class `UserNameInfo.vb`, and then click **Add** to display the code for the new class.  
  
     [!code-vb[VbVbalrOOP#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOOP/VB/OOP.vb#5)]
  
    > [!NOTE]
    >  You can use the Visual Basic **Code Editor** to add a class to your startup form by typing the `Class` keyword followed by the name of the new class. The **Code Editor** provides a corresponding `End Class` statement for you.  
  
6.  Define a private field for the class by adding the following code between the `Class` and `End Class` statements:  
  
     [!code-vb[VbVbalrOOP#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOOP/VB/OOP.vb#7)]
  
     Declaring the field as `Private` means it can be used only within the class. You can make fields available from outside a class by using access modifiers such as `Public` that provide more access. For more information, see [Access levels in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
7.  Define a property for the class by adding the following code:  
  
     [!code-vb[VbVbalrOOP#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOOP/VB/OOP.vb#8)]
  
8.  Define a method for the class by adding the following code:  
  
     [!code-vb[VbVbalrOOP#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOOP/VB/OOP.vb#9)]
  
9. Define a parameterized constructor for the new class by adding a procedure named `Sub New`:  
  
     [!code-vb[VbVbalrOOP#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOOP/VB/OOP.vb#10)]
  
     The `Sub New` constructor is called automatically when an object based on this class is created. This constructor sets the value of the field that holds the user name.  
  
## To create a button to test the class
  
1.  Change the startup form to design mode by right-clicking its name in **Solution Explorer** and then clicking **View Designer**. By default, the startup form for Windows Application projects is named Form1.vb. The main form will then appear.  
  
2.  Add a button to the main form and double-click it to display the code for the `Button1_Click` event handler. Add the following code to call the test procedure:  
  
     [!code-vb[VbVbalrOOP#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOOP/VB/OOP.vb#12)]
  
## To run your application
  
1.  Run your application by pressing F5. Click the button on the form to call the test procedure. It displays a message stating that the original `UserName` is "MOORE, BOBBY", because the procedure called the `Capitalize` method of the object.  
  
2.  Click **OK** to dismiss the message box. The `Button1 Click` procedure changes the value of the `UserName` property and displays a message stating that the new value of `UserName` is "Worden, Joe".  
  
## See also

- [Object-Oriented Programming (Visual Basic)](../../concepts/object-oriented-programming.md)
- [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
