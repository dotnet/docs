---
title: Design-time errors in the Windows Forms Designer
ms.date: 09/09/2019
f1_keywords:
  - "DTELErrorList"
  - "WhyDTELPage"
helpviewer_keywords:
  - "errors [Windows Forms Designer]"
  - "design-time errors [Windows Forms Designer]"
ms.assetid: ad408380-825a-46d8-9a4a-531b130b88ce
author: gewarren
ms.author: gewarren
manager: jillfra
---
# Windows Forms Designer error page

If the Windows Forms Designer fails to load due to an error in your code or elsewhere, you'll see an error page instead of the designer. This error page does not necessarily signify a bug in the designer. The bug may be somewhere in the code-behind page that's named \<your-form-name>.Designer.cs. Errors appear in collapsible, yellow bars with a link to jump to the location of the error on the code page.

![Windows Forms Designer error page](media/windows-forms-designer-error-page-collapsed.png)

You can choose to ignore the errors and continue loading the designer by clicking **Ignore and Continue**. This action may result in unexpected behavior, for example, controls may not appear on the design surface.

## Instances of this error

When the yellow error bar is expanded, each instance of the error is listed. Many error types include an exact location in the following format: *[Project Name]* *[Form Name]* Line:*[Line Number]* Column:*[Column Number]*. If a call stack is associated with the error, you can click the **Show Call Stack** link to see it. Examining the call stack may further help you resolve the error.

![Windows Forms Designer expanded error](media/windows-forms-designer-error-page-expanded.png)

> [!NOTE]
> - For Visual Basic apps, the design-time error page does not display more than one error, but it may display multiple instances of the same error.
> - For C++ apps, errors don't have code location links.

## Help with this error

If a help topic for the error is available, click the **MSDN Help** link to navigate directly to the help page on docs.microsoft.com.

## Forum posts about this error

Click the **Search the MSDN Forums for posts related to this error** link to navigate to the Microsoft Developer Network forums. You may want to specifically search the [Windows Forms Designer](https://social.msdn.microsoft.com/Forums/windows/home?forum=winformsdesigner) or [Windows Forms](https://social.msdn.microsoft.com/Forums/windows/home?category=windowsforms) forums.

## Design-time errors

This section lists some of the errors you may encounter.

### '\<identifier name>' is not a valid identifier

This error indicates that a field, method, event, or object is improperly named.

### '\<name>' already exists in '\<project name>'

Error message: "'\<name>' already exists in '\<project name>'. Please enter a unique name."

You have specified a name for an inherited form that already exists in the project. To correct this error, give the inherited form a unique name.

### '\<Toolbox tab name>' is not a toolbox category

A third-party designer has tried to access a tab on the Toolbox that does not exist. To correct this error, note the exact text of the error message and contact the component vendor.

### A requested language parser is not installed

Error message: "A requested language parser is not installed. The language parser name is '{0}'."

Visual Studio attempted to a load a designer that was registered for the file type, but could not load it. This is most likely because of an error that occurred during setup. To correct this error, note the exact text of the error message, and contact the vendor of the language you're using for a fix.

### A service required for generating and parsing source code is missing

This is a problem with a third-party component. To correct this error, note the exact text of the error message and contact the component vendor.

### An exception occurred while trying to create an instance of '\<object name>'

Error message: "An exception occurred while trying to create an instance of '\<object name>'. The exception was "\<exception string\>".

A third-party designer requested that Visual Studio create an object, but the object raised an error. To correct this error, note the exact text of the error message and contact the component vendor.

### Another editor has '\<document name>' open in an incompatible mode

Error message: "Another editor has '\<document name>' open in an incompatible mode. Please close the editor and try this operation again."

This error arises if you try to open a file that is already opened in another editor. The editor that already has the file open will be shown. To correct this error, close the editor that has the file open, and try again.

## Another editor has made changes to '\<document name>'

Close and reopen the designer for the changes to take effect. Normally, Visual Studio automatically reloads a designer after changes are made. However, other designers, such as third-party component designers, may not support reload behavior. In this case, Visual Studio prompts you to close and reopen the designer manually.

### Another editor has the file open in an incompatible mode

Error message: "Another editor has the file open in an incompatible mode. Please close the editor and try this operation again."

This message is similar to "Another editor has '\<document name>' open in an incompatible mode", but Visual Studio is unable to determine the file name. To correct this error, close the editor that has the file open, and try again.

### Array rank '\<rank in array>' is too high

Visual Studio only supports single-dimension arrays in the code block that is parsed by the designer. Multidimensional arrays are valid outside this area.

### Assembly '\<assembly name>' could not be opened

Error message: "Assembly '\<assembly name>' could not be opened. Verify that the file still exists."

This error message arises when you try to open a file that could not be opened. To correct this error, verify that the file exists and is a valid assembly.

### Bad element type. This serializer expects an element of type '\<type name>'

This is a problem with a third-party component. To correct this error, note the exact text of the error message and contact the component vendor.

### Cannot access the Visual Studio Toolbox at this time

Visual Studio made a call to the Toolbox, which was not available.

Please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### Cannot bind an event handler to the '\<event name>' event because it is read-only

This error most often arises when you've tried to connect an event to a control that's inherited from a base class. If the control's member variable is private, Visual Studio cannot connect the event to the method. Privately inherited controls cannot have additional events bound to them.

### Cannot create a method name for the requested component because it is not a member of the design container

Visual Studio has tried to add an event handler to a component that does not have a member variable in the designer. To correct this error, note the exact text of the error message and contact the component vendor.

### Cannot name the object '\<name>' because it is already named '\<name>'

This is an internal error in the Visual Studio serializer. It indicates that the serializer has tried to name an object twice, which is not supported.

Please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### Cannot remove or destroy inherited component '\<component name>'

Inherited controls are under the ownership of their inheriting class. Changes to the inherited control must be made in the class from which the control originates. Thus, you cannot rename or destroy it.

### Category '\<Toolbox tab name>' does not have a tool for class '\<class name>'

The designer tried to reference a class on a particular Toolbox tab, but the class does not exist. To correct this error, note the exact text of the error message, and contact the component vendor.

### Class '\<class name>' has no matching constructor

A third-party designer has asked Visual Studio to create an object with particular parameters in the constructor that does not exist. To correct this error, note the exact text of the error message and contact the component vendor.

### Code generation for property '\<property name>' failed

This is a generic wrapper for an error. The error string that accompanies this message will give more details about the error message and have a link to a more specific help topic. To correct this error, address the error specified in the error message appended to this error.

### Component '\<component name>' did not call Container.Add() in its constructor

This is an error in the component you just placed on the form or loaded. It indicates that the component did not add itself to its container control (whether that was another control or a form). The designer will continue to work, but there may be problems with the component at run time.

To correct this error, note the exact text of the error message and contact the component vendor. Or, if it is a component you created, call the `IContainer.Add` method in the component's constructor.

### Component name cannot be empty

This error arises when you try to rename a component to an empty value.

### Could not access the variable '\<variable name>' because it has not been initialized yet

This error can arise because of two scenarios. Either a third-party component vendor has a problem with a control or component they have distributed, or the code you have written has recursive dependencies between components.

To correct this error, ensure that your code does not have a recursive dependency. If it is free of such problems, note the exact text of the error message and contact the component vendor.

### Could not find type '\<type name>'

Error message: "Could not find type '\<type name>'. Please make sure that the assembly that contains this type is referenced. If this type is a part of your development project, make sure that the project has been successfully built."

This error occurred because a reference was not found. Make sure the type indicated in the error message is referenced, and that any assemblies that the type requires are also referenced. Often, the problem is that a control in the solution has not been built. To build, select **Build Solution** from the **Build** menu. Otherwise, if the control has already been built, add a reference manually from the right-click menu of the **References** or **Dependencies** folder in Solution Explorer.

### Could not load type '\<type name>'

Error message: "Could not load type '\<type name>'. Please make sure that the assembly containing this type is added to the project references."

Visual Studio attempted to wire up an event-handling method and could not find one or more parameter types for the method. This is usually caused by a missing reference. To correct this error, add the reference containing the type to the project and try again.

### Could not locate the project item templates for inherited components

The templates for inherited forms in Visual Studio are not available.

Please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### Delegate class '\<class name>' has no invoke method. Is this class a delegate?

Visual Studio has tried to create an event handler, but there is something wrong with the event type. This can happen if the event was created by a non-CLS-compliant language.

To correct this error, note the exact text of the error message and contact the component vendor.

### Duplicate declaration of member '\<member name>'

This error arises because a member variable has been declared twice (for example, two controls named `Button1` are declared in the code). Names must be unique across inherited forms. Additionally, names cannot differ only by case.

### Error reading resources from the resource file for the culture '\<culture name>'

This error can occur if there is a bad .resx file in the project.

To correct this error:

1. Click the **Show All Files** button in Solution Explorer to view the .resx files associated with the solution.
2. Load the .resx file in the XML Editor by right-clicking the .resx file and choosing **Open**.
3. Edit the .resx file manually to address the errors.

### Error reading resources from the resource file for the default culture '\<culture name>'

This error can occur if there is a bad .resx file in the project for the default culture.

To correct this error:

1. Click the **Show All Files** button in Solution Explorer to view the .resx files associated with the solution.
2. Load the .resx file in the XML Editor by right-clicking the .resx file and choosing **Open**.
3. Edit the .resx file manually to address the errors.

### Failed to parse method '\<method name>'

Error message: "Failed to parse method '\<method name>'. The parser reported the following error: '\<error string>'. Please look in the Task List for potential errors."

This is a general error message for problems that arise during parsing. These errors are generally due to syntax errors. See the Task List for specific messages related to the error.

### Invalid component name: '\<component name>'

You've tried to rename a component to an invalid value for that language. To correct this error, name the component such that it complies with the naming rules for that language.

### The type '\<class name>' is made of several partial classes in the same file

When you define a class in multiple files by using the partial keyword, you can only have one partial definition in each file.

To correct this error, remove all but one of the partial definitions of your class from the file.

### The assembly '\<assembly name>' could not be found

Error message: "The assembly '\<assembly name>' could not be found. Ensure that the assembly is referenced. If the assembly is part of the current development project, ensure that the project has been built."

This error is similar to "The type '\<type name>' could not be found", but this error usually happens because of a metadata attribute. To correct this error, check that all assemblies used by attributes are referenced.

### The assembly name '\<assembly name>' is invalid

A component has requested a particular assembly, but the name provided by the component is not a valid assembly name.

To correct this error, note the exact text of the error message and contact the component vendor.

### The base class '\<class name>' cannot be designed

Visual Studio loaded the class, but the class cannot be designed because the implementer of the class did not provide a designer.

If the class supports a designer, make sure there are no problems that would cause issues with displaying it in a designer, such as compiler errors. Also, make sure that all references to the class are correct and all class names are correctly spelled.

Otherwise, if the class is not designable, edit it in Code view.

### The base class '\<class name>' could not be loaded

The class was not referenced in the project, so Visual Studio could not load it. To correct this error, add a reference to the class in the project, and close and reopen the Windows Forms Designer window.

### The class '\<class name>' cannot be designed in this version of Visual Studio

The designer for this control or component does not support the same types that Visual Studio does. Note the exact text of the error message and contact the component vendor.

### The class name is not a valid identifier for this language

The source code being created by the user has a class name that is not valid for the language being used. To correct this error, name the class such that it conforms to the language requirements.

### The component cannot be added because it contains a circular reference to '\<reference name>'

You cannot add a control or component to itself. Another situation where this might occur is if there is code in the InitializeComponent method of a form (for example, Form1) that creates another instance of Form1.

### The designer cannot be modified at this time

This error occurs when the file in the editor is marked as read-only. Ensure that the file is not marked read-only and the application is not running.

### The designer could not be shown for this file because none of the classes within it can be designed

This error occurs when Visual Studio cannot find a base class that satisfies designer requirements. Examples include: Visual Studio cannot find a designer for the base class; the base class is a class that could not be found or loaded.

Forms and controls must derive from a base class that supports designers. If you're deriving from an inherited form or control, make sure the project has been built.

### The designer for base class '\<class name>' is not installed

Visual Studio could not load the designer for the class.

Please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### The designer must create an instance of type '\<type name>', but it can't because the type is declared as abstract

This error occurred because the base class of the object being passed to the designer is abstract, which is not allowed.

### The file could not be loaded in the designer

The base class of this file does not support any designers. As a workaround, use Code view to work on the file. Right-click the file in Solution Explorer and choose **View Code**.

### The language for this file does not support the necessary code parsing and generation services

Error message: "The language for this file does not support the necessary code parsing and generation services. Please ensure the file you are opening is a member of a project and then try to open the file again."

This error most likely resulted from opening a file that's in a project that does not support designers.

### The language parser class '\<class name>' is not implemented properly

Error message: "The language parser class '\<class name>' is not implemented properly. Please contact the vendor for an updated parser module."

The language in use has registered a designer class in the Registry that does not derive from the correct base class. Note the exact text of the error message, and contact the vendor of the language you are using.

### The name '\<name>' is already used by another object

This is an internal error in the Visual Studio serializer.

Please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### The object '\<object name>' does not implement the IComponent interface

Visual Studio tried to create a component, but the object created does not implement the IComponent interface.

Note the exact text of the error message and contact the component vendor for a fix.

### The object '\<object name>' returned null for the property '\<property name>' but this is not allowed

There are some properties in the .NET Framework that should always return an object. For example, the Controls collection of a form should always return an object, even when there are no controls in it.

To correct this error, ensure that the property specified in the error is not null.

### The serialization data object is not of the proper type

A data object offered by the serializer is not an instance of a type that matches the current serializer being used.

Note the exact text of the error message and contact the component vendor.

### The service '\<service name>' is required, but could not be located

Error message: "The service '\<service name>' is required, but could not be located. There may be a problem with your Visual Studio installation."

A service required by Visual Studio was unavailable. If you were trying to force a designer to load a project that does not support that designer, use the Code Editor to make the changes you require. Otherwise, please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### The service instance must derive from or implement '\<interface name>'

This error indicates that a component or component designer has called the AddService method, which requires an interface and object, but the object specified does not implement the interface specified.

Note the exact text of the error message and contact the component vendor.

### The text in the code window could not be modified

Error message: "The text in the code window could not be modified. Check that the file is not read-only and there is sufficient disk space."

This error occurs when Visual Studio is unable to edit a file due to disk space or memory problems. Another cause may be that the file is read-only.

### The Toolbox enumerator object only supports retrieving one item at a time

The Toolbox enumerator only supports retrieving one item at a time.

Please log an issue by using [Report a Problem](/visualstudio/ide/how-to-report-a-problem-with-visual-studio).

### The Toolbox item for '\<component name>' could not be retrieved from the Toolbox

Error message: "The Toolbox item for '\<component name>' could not be retrieved from the Toolbox. Make sure the assembly that contains the Toolbox item is correctly installed. The Toolbox item raised the following error: \<error string>."

The component in question threw an exception when Visual Studio accessed it. Note the exact text of the error message and contact the component vendor.

### The Toolbox item for '\<Toolbox item name>' could not be retrieved from the Toolbox

Error message: "The Toolbox item for '\<Toolbox item name>' could not be retrieved from the Toolbox. Try removing the item from the Toolbox and adding it back."

This error occurs if the data within the Toolbox item becomes corrupted or the version of the component has changed. Try removing the item from the Toolbox and adding it back again.

## See also

- [Develop Windows Forms controls using the designer](developing-windows-forms-controls-at-design-time.md)
- [Windows Forms Designer forum](https://social.msdn.microsoft.com/Forums/windows/home?forum=winformsdesigner)
