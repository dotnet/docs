---
title: "My.Forms Object"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "My.Forms"
  - "My.MyProject.Forms"
helpviewer_keywords: 
  - "My.Forms object"
ms.assetid: f6bff4e6-6769-4294-956b-037aa6106d2a
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# My.Forms Object
Provides properties for accessing an instance of each Windows form declared in the current project.  
  
## Remarks  
 The `My.Forms` object provides an instance of each form in the current project. The name of the property is the same as the name of the form that the property accesses.   
  
 You can access the forms provided by the `My.Forms` object by using the name of the form, without qualification. Because the property name is the same as the form's type name, this allows you to access a form as if it had a default instance. For example, `My.Forms.Form1.Show` is equivalent to `Form1.Show`.  
  
 The `My.Forms` object exposes only the forms associated with the current project. It does not provide access to forms declared in referenced DLLs. To access a form that a DLL provides, you must use the qualified name of the form, written as *DllName*.*FormName*.  
  
 You can use the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OpenForms%2A> property to get a collection of all the application's open forms.  
  
 The object and its properties are available only for Windows applications.  
  
## Properties  
 Each property of the `My.Forms` object provides access to an instance of a form in the current project. The name of the property is the same as the name of the form that the property accesses, and the property type is the same as the form's type.  
  
> [!NOTE]
>  If there is a name collision, the property name to access a form is *RootNamespace*_*Namespace*\_*FormName*. For example, consider two forms named `Form1.`If one of these forms is in the root namespace `WindowsApplication1` and in the namespace `Namespace1`, you would access that form through `My.Forms.WindowsApplication1_Namespace1_Form1`.  
  
 The `My.Forms` object provides access to the instance of the application's main form that was created on startup. For all other forms, the `My.Forms` object creates a new instance of the form when it is accessed and stores it. Subsequent attempts to access that property return that instance of the form.  
  
 You can dispose of a form by assigning `Nothing` to the property for that form. The property setter calls the <xref:System.Windows.Forms.Form.Close%2A> method of the form, and then assigns `Nothing` to the stored value. If you assign any value other than `Nothing` to the property, the setter throws an <xref:System.ArgumentException> exception.  
  
 You can test whether a property of the `My.Forms` object stores an instance of the form by using the `Is` or `IsNot` operator. You can use those operators to check if the value of the property is `Nothing`.  
  
> [!NOTE]
>  Typically, the `Is` or `IsNot` operator has to read the value of the property to perform the comparison. However, if the property currently stores `Nothing`, the property creates a new instance of the form and then returns that instance. However, the Visual Basic compiler treats the properties of the `My.Forms` object differently and allows the `Is` or `IsNot` operator to check the status of the property without altering its value.  
  
## Example  
 This example changes the title of the default `SidebarMenu` form.  
  
 [!code-vb[VbVbalrMyForms#2](../../../visual-basic/language-reference/objects/codesnippet/VisualBasic/my-forms-object_1.vb)]  
  
 For this example to work, your project must have a form named `SidebarMenu`.  
  
 This code will work only in a Windows Application project.  
  
## Requirements  
  
### Availability by Project Type  
  
|Project type|Available|  
|---|---|  
|Windows Application|**Yes**|  
|Class Library|No|  
|Console Application|No|  
|Windows Control Library|No|  
|Web Control Library|No|  
|Windows Service|No|  
|Web Site|No|  
  
## See Also  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OpenForms%2A>  
 <xref:System.Windows.Forms.Form>  
 <xref:System.Windows.Forms.Form.Close%2A>  
 [Objects](../../../visual-basic/language-reference/objects/index.md)  
 [Is Operator](../../../visual-basic/language-reference/operators/is-operator.md)  
 [IsNot Operator](../../../visual-basic/language-reference/operators/isnot-operator.md)  
 [Accessing Application Forms](../../../visual-basic/developing-apps/programming/accessing-application-forms.md)
