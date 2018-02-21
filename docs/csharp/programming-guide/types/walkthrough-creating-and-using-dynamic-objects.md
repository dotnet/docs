---
title: "Walkthrough: Creating and Using Dynamic Objects (C# and Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dynamic objects [Visual Basic]"
  - "dynamic objects"
  - "dynamic objects [C#]"
ms.assetid: 568f1645-1305-4906-8625-5d77af81e04f
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# Walkthrough: Creating and Using Dynamic Objects (C# and Visual Basic)

Dynamic objects expose members such as properties and methods at run time, instead of in at compile time. This enables you to create objects to work with structures that do not match a static type or format. For example, you can use a dynamic object to reference the HTML Document Object Model (DOM), which can contain any combination of valid HTML markup elements and attributes. Because each HTML document is unique, the members for a particular HTML document are determined at run time. A common method to reference an attribute of an HTML element is to pass the name of the attribute to the `GetProperty` method of the element. To reference the `id` attribute of the HTML element `<div id="Div1">`, you first obtain a reference to the `<div>` element, and then use `divElement.GetProperty("id")`. If you use a dynamic object, you can reference the `id` attribute as `divElement.id`.  
  
 Dynamic objects also provide convenient access to dynamic languages such as IronPython and IronRuby. You can use a dynamic object to refer to a dynamic script that is interpreted at run time.  
  
 You reference a dynamic object by using late binding. In C#, you specify the type of a late-bound object as `dynamic`. In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], you specify the type of a late-bound object as `Object`. For more information, see [dynamic](../../../csharp/language-reference/keywords/dynamic.md) and [Early and Late Binding](../../../visual-basic/programming-guide/language-features/early-late-binding/index.md).  
  
 You can create custom dynamic objects by using the classes in the <xref:System.Dynamic?displayProperty=nameWithType> namespace. For example, you can create an <xref:System.Dynamic.ExpandoObject> and specify the members of that object at run time. You can also create your own type that inherits the <xref:System.Dynamic.DynamicObject> class. You can then override the members of the <xref:System.Dynamic.DynamicObject> class to provide run-time dynamic functionality.  
  
 In this walkthrough you will perform the following tasks:  
  
-   Create a custom object that dynamically exposes the contents of a text file as properties of an object.  
  
-   Create a project that uses an `IronPython` library.  
  
## Prerequisites  
You need [IronPython](http://ironpython.net/) for .NET to complete this walkthrough. Go to their [Download page](http://ironpython.net/download/) to obtain the latest version.
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
## Creating a Custom Dynamic Object  
 The first project that you create in this walkthrough defines a custom dynamic object that searches the contents of a text file. Text to search for is specified by the name of a dynamic property. For example, if calling code specifies `dynamicFile.Sample`, the dynamic class returns a generic list of strings that contains all of the lines from the file that begin with "Sample". The search is case-insensitive. The dynamic class also supports two optional arguments. The first argument is a search option enum value that specifies that the dynamic class should search for matches at the start of the line, the end of the line, or anywhere in the line. The second argument specifies that the dynamic class should trim leading and trailing spaces from each line before searching. For example, if calling code specifies `dynamicFile.Sample(StringSearchOption.Contains)`, the dynamic class searches for "Sample" anywhere in a line. If calling code specifies `dynamicFile.Sample(StringSearchOption.StartsWith, false)`, the dynamic class searches for "Sample" at the start of each line, and does not remove leading and trailing spaces. The default behavior of the dynamic class is to search for a match at the start of each line and to remove leading and trailing spaces.  
  
#### To create a custom dynamic class  
  
1.  Start [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)].  
  
2.  On the **File** menu, point to **New** and then click **Project**.  
  
3.  In the **New Project** dialog box, in the **Project Types** pane, make sure that **Windows** is selected. Select **Console Application** in the **Templates** pane. In the **Name** box, type `DynamicSample`, and then click **OK**. The new project is created.  
  
4.  Right-click the DynamicSample project and point to **Add**, and then click **Class**. In the **Name** box, type `ReadOnlyFile`, and then click **OK**. A new file is added that contains the ReadOnlyFile class.  
  
5.  At the top of the ReadOnlyFile.cs or ReadOnlyFile.vb file, add the following code to import the <xref:System.IO?displayProperty=nameWithType> and <xref:System.Dynamic?displayProperty=nameWithType> namespaces.  
  
     [!code-csharp[VbDynamicWalkthrough#1](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_1.cs)]

     [!code-vb[VbDynamicWalkthrough#1](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_1.vb)]  
  
6.  The custom dynamic object uses an enum to determine the search criteria. Before the class statement, add the following enum definition.  
  
     [!code-csharp[VbDynamicWalkthrough#2](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_2.cs)]

     [!code-vb[VbDynamicWalkthrough#2](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_2.vb)]  
  
7.  Update the class statement to inherit the `DynamicObject` class, as shown in the following code example.  
  
     [!code-csharp[VbDynamicWalkthrough#3](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_3.cs)]

     [!code-vb[VbDynamicWalkthrough#3](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_3.vb)]  
  
8.  Add the following code to the `ReadOnlyFile` class to define a private field for the file path and a constructor for the `ReadOnlyFile` class.  
  
     [!code-csharp[VbDynamicWalkthrough#4](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_4.cs)]
     
     [!code-vb[VbDynamicWalkthrough#4](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_4.vb)]  
  
9. Add the following `GetPropertyValue` method to the `ReadOnlyFile` class. The `GetPropertyValue` method takes, as input, search criteria and returns the lines from a text file that match that search criteria. The dynamic methods provided by the `ReadOnlyFile` class call the `GetPropertyValue` method to retrieve their respective results.  
  
     [!code-csharp[VbDynamicWalkthrough#5](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_5.cs)]
     
     [!code-vb[VbDynamicWalkthrough#5](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_5.vb)]  
  
10. After the `GetPropertyValue` method, add the following code to override the <xref:System.Dynamic.DynamicObject.TryGetMember%2A> method of the <xref:System.Dynamic.DynamicObject> class. The <xref:System.Dynamic.DynamicObject.TryGetMember%2A> method is called when a member of a dynamic class is requested and no arguments are specified. The `binder` argument contains information about the referenced member, and the `result` argument references the result returned for the specified member. The <xref:System.Dynamic.DynamicObject.TryGetMember%2A> method returns a Boolean value that returns `true` if the requested member exists; otherwise it returns `false`.  
  
     [!code-csharp[VbDynamicWalkthrough#6](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_6.cs)]
     
     [!code-vb[VbDynamicWalkthrough#6](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_6.vb)]  
  
11. After the `TryGetMember` method, add the following code to override the <xref:System.Dynamic.DynamicObject.TryInvokeMember%2A> method of the <xref:System.Dynamic.DynamicObject> class. The <xref:System.Dynamic.DynamicObject.TryInvokeMember%2A> method is called when a member of a dynamic class is requested with arguments. The `binder` argument contains information about the referenced member, and the `result` argument references the result returned for the specified member. The `args` argument contains an array of the arguments that are passed to the member. The <xref:System.Dynamic.DynamicObject.TryInvokeMember%2A> method returns a Boolean value that returns `true` if the requested member exists; otherwise it returns `false`.  
  
     The custom version of the `TryInvokeMember` method expects the first argument to be a value from the `StringSearchOption` enum that you defined in a previous step. The `TryInvokeMember` method expects the second argument to be a Boolean value. If one or both arguments are valid values, they are passed to the `GetPropertyValue` method to retrieve the results.  
  
     [!code-csharp[VbDynamicWalkthrough#7](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_7.cs)]
     
     [!code-vb[VbDynamicWalkthrough#7](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_7.vb)]  
  
12. Save and close the file.  
  
#### To create a sample text file  
  
1.  Right-click the DynamicSample project and point to **Add**, and then click **New Item**. In the **Installed Templates** pane, select **General**, and then select the **Text File** template. Leave the default name of TextFile1.txt in the **Name** box, and then click **Add**. A new text file is added to the project.  
  
2.  Copy the following text to the TextFile1.txt file.  
  
    ```  
    List of customers and suppliers  
  
    Supplier: Lucerne Publishing (http://www.lucernepublishing.com/)  
    Customer: Preston, Chris  
    Customer: Hines, Patrick  
    Customer: Cameron, Maria  
    Supplier: Graphic Design Institute (http://www.graphicdesigninstitute.com/)   
    Supplier: Fabrikam, Inc. (http://www.fabrikam.com/)   
    Customer: Seubert, Roxanne  
    Supplier: Proseware, Inc. (http://www.proseware.com/)   
    Customer: Adolphi, Stephan  
    Customer: Koch, Paul  
    ```  
  
3.  Save and close the file.  
  
#### To create a sample application that uses the custom dynamic object  
  
1.  In **Solution Explorer**, double-click the Module1.vb file if you are using [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] or the Program.cs file if you are using Visual C#.  
  
2.  Add the following code to the Main procedure to create an instance of the `ReadOnlyFile` class for the TextFile1.txt file. The code uses late binding to call dynamic members and retrieve lines of text that contain the string "Customer".  
  
     [!code-csharp[VbDynamicWalkthrough#8](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_8.cs)]
     
     [!code-vb[VbDynamicWalkthrough#8](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_8.vb)]  
  
3.  Save the file and press CTRL+F5 to build and run the application.  
  
## Calling a Dynamic Language Library  

The next project that you create in this walkthrough accesses a library that is written in the dynamic language IronPython.
  
#### To create a custom dynamic class  
  
1.  In [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)], on the **File** menu, point to **New** and then click **Project**.  
  
2.  In the **New Project** dialog box, in the **Project Types** pane, make sure that **Windows** is selected. Select **Console Application** in the **Templates** pane. In the **Name** box, type `DynamicIronPythonSample`, and then click **OK**. The new project is created.  
  
3.  If you are using [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], right-click the DynamicIronPythonSample project and then click **Properties**. Click the **References** tab. Click the **Add** button. If you are using Visual C#, in **Solution Explorer**, right-click the **References** folder and then click **Add Reference**.  
  
4.  On the **Browse** tab, browse to the folder where the IronPython libraries are installed. For example, C:\Program Files\IronPython 2.6 for .NET 4.0. Select the **IronPython.dll**, **IronPython.Modules.dll**, **Microsoft.Scripting.dll**, and **Microsoft.Dynamic.dll** libraries. Click **OK**.  
  
5.  If you are using [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], edit the Module1.vb file. If you are using Visual C#, edit the Program.cs file.  
  
6.  At the top of the file, add the following code to import the `Microsoft.Scripting.Hosting` and `IronPython.Hosting` namespaces from the IronPython libraries.  
  
     [!code-csharp[VbDynamicWalkthroughIronPython#1](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_9.cs)]
     
     [!code-vb[VbDynamicWalkthroughIronPython#1](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_9.vb)]  
  
7.  In the Main method, add the following code to create a new `Microsoft.Scripting.Hosting.ScriptRuntime` object to host the IronPython libraries. The `ScriptRuntime` object loads the IronPython library module random.py.  
  
     [!code-csharp[VbDynamicWalkthroughIronPython#2](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_10.cs)]
     
     [!code-vb[VbDynamicWalkthroughIronPython#2](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_10.vb)]  
  
8.  After the code to load the random.py module, add the following code to create an array of integers. The array is passed to the `shuffle` method of the random.py module, which randomly sorts the values in the array.  
  
     [!code-csharp[VbDynamicWalkthroughIronPython#3](../../../csharp/programming-guide/types/codesnippet/CSharp/walkthrough-creating-and-using-dynamic-objects_11.cs)]
     
     [!code-vb[VbDynamicWalkthroughIronPython#3](../../../csharp/programming-guide/types/codesnippet/VisualBasic/walkthrough-creating-and-using-dynamic-objects_11.vb)]  
  
9. Save the file and press CTRL+F5 to build and run the application.  
  
## See Also  
 <xref:System.Dynamic?displayProperty=nameWithType>  
 <xref:System.Dynamic.DynamicObject?displayProperty=nameWithType>  
 [Using Type dynamic](../../../csharp/programming-guide/types/using-type-dynamic.md)  
 [Early and Late Binding](../../../visual-basic/programming-guide/language-features/early-late-binding/index.md)  
 [dynamic](../../../csharp/language-reference/keywords/dynamic.md)  
 [Implementing Dynamic Interfaces (downloadable PDF from Microsoft TechNet)](http://download.microsoft.com/download/5/4/B/54B83DFE-D7AA-4155-9687-B0CF58FF65D7/implementing-dynamic-interfaces.pdf)
