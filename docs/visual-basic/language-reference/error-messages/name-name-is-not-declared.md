---
title: "Name &#39;&lt;name&gt;&#39; is not declared"
ms.date: 10/10/2018
f1_keywords: 
  - "bc30451"
  - "vbc30451"
helpviewer_keywords: 
  - "BC30451"
author: rpetrusha
ms.author: ronpet
ms.assetid: 765f099b-e21e-47c6-a906-a065444e56b3
---
# Name &#39;&lt;name&gt;&#39; is not declared
A statement refers to a programming element, but the compiler cannot find an element with that exact name.  
  
 **Error ID:** BC30451  
  
## To correct this error  
  
1. Check the spelling of the name in the referring statement. Visual Basic is case-insensitive, but any other variation in the spelling is regarded as a completely different name. Note that the underscore (`_`) is part of the name and therefore part of the spelling.  
  
2. Check that you have the member access operator (`.`) between an object and its member. For example, if you have a <xref:System.Windows.Forms.TextBox> control named `TextBox1`, to access its <xref:System.Windows.Forms.TextBoxBase.Text%2A> property you should type `TextBox1.Text`. If instead you type `TextBox1Text`, you have created a different name.  
  
3. If the spelling is correct and the syntax of any object member access is correct, verify that the element has been declared. For more information, see [Declared Elements](../../programming-guide/language-features/declared-elements/index.md).  
  
4. If the programming element has been declared, check that it is in scope. If the referring statement is outside the region declaring the programming element, you might need to qualify the element name. For more information, see [Scope in Visual Basic](../../programming-guide/language-features/declared-elements/scope.md).  

5. If you are not using a fully qualified type or type and member name (for example, your code refers to a property as `MethodInfo.Name` instead of `System.Reflection.MethodInfo.Name`), add an [Imports statement](../statements/imports-statement-net-namespace-and-type.md).

6. If you are attempting to compile an SDK-style project (a project with a \*.vbproj file that begins with the line `<Project Sdk="Microsoft.NET.Sdk">`), and the error message refers to a type or member in the Microsoft.VisualBasic.dll assembly, configure your application to compile with a reference to the Visual Basic Runtime Library. By default, a subset of the library is embedded in your assembly in an SDK-style project.

   For example, the following example fails to compile because the <xref:Microsoft.VisualBasic.CompilerServices.Conversions.ToInteger%2A?displayProperty=fullName> method cannot be found. It is not embedded in the subset of the Visual Basic Runtime included with your application.  

   [!code-vb[BC30451](~/samples/snippets/visualbasic/language-reference/error-messages/bc30451/program1.vb)]

   To address this error, add the `<VBRuntime>Default</VBRuntime>` element to the projects `<PropertyGroup>` section, as the following Visual Basic project file shows.

   [!code-vb[BC30451](~/samples/snippets/visualbasic/language-reference/error-messages/bc30451/vbruntime.vbproj?highlight=6)]

## See also  

[Declarations and Constants Summary](../../../visual-basic/language-reference/keywords/declarations-and-constants-summary.md)  
 [Visual Basic Naming Conventions](../../../visual-basic/programming-guide/program-structure/naming-conventions.md)  
 [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)
