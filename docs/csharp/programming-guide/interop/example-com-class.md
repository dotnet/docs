---
title: "Example COM Class (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "examples [C#], COM classes"
  - "COM, exposing Visual C# objects to"
ms.assetid: 6504dea9-ad1c-4993-a794-830fec5270af
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# Example COM Class (C# Programming Guide)
The following is an example of a class that you would expose as a COM object. After this code has been placed in a .cs file and added to your project, set the **Register for COM Interop** property to **True**. For more information, see [NIB: How to: Register a Component for COM Interop](http://msdn.microsoft.com/library/4de7d474-56e8-4027-994d-d47ca4725c5e).  
  
 Exposing Visual C# objects to COM requires declaring a class interface, an events interface if it is required, and the class itself. Class members must follow these rules to be visible to COM:  
  
-   The class must be public.  
  
-   Properties, methods, and events must be public.  
  
-   Properties and methods must be declared on the class interface.  
  
-   Events must be declared in the event interface.  
  
 Other public members in the class that are not declared in these interfaces will not be visible to COM, but they will be visible to other .NET Framework objects.  
  
 To expose properties and methods to COM, you must declare them on the class interface and mark them with a `DispId` attribute, and implement them in the class. The order in which the members are declared in the interface is the order used for the COM vtable.  
  
 To expose events from your class, you must declare them on the events interface and mark them with a `DispId` attribute. The class should not implement this interface.  
  
 The class implements the class interface; it can implement more than one interface, but the first implementation will be the default class interface. Implement the methods and properties exposed to COM here. They must be marked public and must match the declarations in the class interface. Also, declare the events raised by the class here. They must be marked public and must match the declarations in the events interface.  
  
## Example  
 [!code-csharp[csProgGuideInterop#8](../../../csharp/programming-guide/interop/codesnippet/CSharp/example-com-class_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Interoperability](../../../csharp/programming-guide/interop/index.md)  
 [Build Page, Project Designer (C#)](/visualstudio/ide/reference/build-page-project-designer-csharp)
