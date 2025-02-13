---
description: "Learn more about: Development with My (Visual Basic)"
title: "Development with My"
ms.date: 07/20/2015
f1_keywords: 
  - "My.MyWpfExtension.Windows"
helpviewer_keywords: 
  - "My object"
  - "My namespace"
  - "My feature"
  - "Visual Basic, programming in"
ms.assetid: f1d04509-5e46-4551-9f9f-94334a121fca
---
# Development with My (Visual Basic)

Visual Basic provides new features for rapid application development that improve productivity and ease of use while delivering power. One of these features, called `My`, provides access to information and default object instances that are related to the application and its run-time environment. This information is organized in a format that is discoverable through IntelliSense and logically delineated according to use.  
  
 Top-level members of `My` are exposed as objects. Each object behaves similarly to a namespace or a class with `Shared` members, and it exposes a set of related members.  
  
 This table shows the top-level `My` objects and their relationship to each other.  
  
 ![Diagram shows the object model for My.](./media/index/my-object-model-relationships.gif)  
  
## Supported My Services in .NET 5+

Starting with .NET 5, not all `My` services are supported. The Visual Basic Application Framework was not supported in .NET 5 but was reintroduced in .NET 6. For more details, see [Update to WinForms VB Application Framework](https://devblogs.microsoft.com/dotnet/update-to-winforms-vb-appframework/).

The following `My` objects and services are available:

- **Supported in .NET 5+:**
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase>
  - <xref:Microsoft.VisualBasic.Devices.Computer>
  - <xref:Microsoft.VisualBasic.ApplicationServices.User>
  - [My.Settings Object](../../language-reference/objects/my-settings-object.md)
  - [My.Resources Object](../../language-reference/objects/my-resources-object.md)

- **Not supported in .NET 5+:**
  - [My.WebServices Object](../../language-reference/objects/my-webservices-object.md)

For more details on project type dependencies, see [How My Depends on Project Type](how-my-depends-on-project-type.md).

## In This Section  

 [Performing Tasks with My.Application, My.Computer, and My.User](performing-tasks-with-my-application-my-computer-and-my-user.md)  
 Describes the three central `My` objects, `My.Application`, `My.Computer`, and `My.User`, which provide access to information and functionality  
  
 [Default Object Instances Provided by My.Forms and My.WebServices](default-object-instances-provided-by-my-forms-and-my-webservices.md)  
 Describes the `My.Forms` and `My.WebServices` objects, which provide access to forms, data sources, and XML Web services used by your application.  
  
 [Rapid Application Development with My.Resources and My.Settings](rapid-application-development-with-my-resources-and-my-settings.md)  
 Describes the `My.Resources` and `My.Settings` objects, which provide access to an application's resources and settings.  
  
 [Overview of the Visual Basic Application Model](overview-of-the-visual-basic-application-model.md)  
 Describes the Visual Basic Application Startup/Shutdown model.  
  
 [How My Depends on Project Type](how-my-depends-on-project-type.md)  
 Gives details on which `My` features are available in different project types.  
  
## See also

- <xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase>
- <xref:Microsoft.VisualBasic.Devices.Computer>
- <xref:Microsoft.VisualBasic.ApplicationServices.User>
- [My.Forms Object](../../language-reference/objects/my-forms-object.md)
- [My.WebServices Object](../../language-reference/objects/my-webservices-object.md)
- [How My Depends on Project Type](how-my-depends-on-project-type.md)
