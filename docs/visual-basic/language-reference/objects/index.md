---
title: "Objects (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "objects [Visual Basic]"
ms.assetid: 651c73e4-dca8-402b-9c6b-e3902b3a3f4b
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Objects (Visual Basic)
This topic provides links to other topics that document the Visual Basic run-time objects and contain tables of their member procedures, properties, and events.  
  
## Visual Basic Run-time Objects  
  
|||  
|---|---|  
|<xref:Microsoft.VisualBasic.Collection>|Provides a convenient way to see a related group of items as a single object.|  
|<xref:Microsoft.VisualBasic.Information.Err%2A>|Contains information about run-time errors.|  
|The `My.Application` object consists of the following classes:<br /><br /> <xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase> provides members that are available in all projects.<br /><br /> <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase> provides members available in Windows Forms applications.<br /><br /> <xref:Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase> provides members available in console applications.|Provides data that is associated only with the current application or DLL. No system-level information can be altered with `My.Application`.<br /><br /> Some members are available only for Windows Forms or console applications.|  
|`My.Application.Info` (<xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase.Info%2A>)|Provides properties for getting the information about an application, such as the version number, description, loaded assemblies, and so on.|  
|`My.Application.Log` (<xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase.Log%2A>)|Provides a property and methods to write event and exception information to the application's log listeners.|  
|`My.Computer` (<xref:Microsoft.VisualBasic.Devices.Computer>)|Provides properties for manipulating computer components such as audio, the clock, the keyboard, the file system, and so on.|  
|`My.Computer.Audio` (<xref:Microsoft.VisualBasic.Devices.Audio>)|Provides methods for playing sounds.|  
|`My.Computer.Clipboard` (<xref:Microsoft.VisualBasic.Devices.Computer.Clipboard%2A>)|Provides methods for manipulating the Clipboard.|  
|`My.Computer.Clock` (<xref:Microsoft.VisualBasic.Devices.Clock>)|Provides properties for accessing the current local time and Universal Coordinated Time (equivalent to Greenwich Mean Time) from the system clock.|  
|`My.Computer.FileSystem` (<xref:Microsoft.VisualBasic.FileIO.FileSystem>)|Provides properties and methods for working with drives, files, and directories.|  
|`My.Computer.FileSystem.SpecialDirectories` (<xref:Microsoft.VisualBasic.FileIO.SpecialDirectories>)|Provides properties for accessing commonly referenced directories.|  
|`My.Computer.Info` (<xref:Microsoft.VisualBasic.Devices.ComputerInfo>)|Provides properties for getting information about the computer's memory, loaded assemblies, name, and operating system.|  
|`My.Computer.Keyboard` (<xref:Microsoft.VisualBasic.Devices.Keyboard>)|Provides properties for accessing the current state of the keyboard, such as what keys are currently pressed, and provides a method to send keystrokes to the active window.|  
|`My.Computer.Mouse` (<xref:Microsoft.VisualBasic.Devices.Mouse>)|Provides properties for getting information about the format and configuration of the mouse that is installed on the local computer.|  
|`My.Computer.Network` (<xref:Microsoft.VisualBasic.Devices.Network>)|Provides a property, an event, and methods for interacting with the network to which the computer is connected.|  
|`My.Computer.Ports` (<xref:Microsoft.VisualBasic.Devices.Ports>)|Provides a property and a method for accessing the computer's serial ports.|  
|`My.Computer.Registry` (<xref:Microsoft.VisualBasic.MyServices.RegistryProxy>)|Provides properties and methods for manipulating the registry.|  
|[My.Forms Object](../../../visual-basic/language-reference/objects/my-forms-object.md)|Provides properties for accessing an instance of each Windows Form declared in the current project.|  
|`My.Log` (<xref:Microsoft.VisualBasic.Logging.AspLog>)|Provides a property and methods for writing event and exception information to the application's log listeners for Web applications.|  
|[My.Request Object](../../../visual-basic/language-reference/objects/my-request-object.md)|Gets the <xref:System.Web.HttpRequest> object for the requested page. The `My.Request` object contains information about the current HTTP request.<br /><br /> The `My.Request` object is available only for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] applications.|  
|[My.Resources Object](../../../visual-basic/language-reference/objects/my-resources-object.md)|Provides properties and classes for accessing an application's resources.|  
|[My.Response Object](../../../visual-basic/language-reference/objects/my-response-object.md)|Gets the <xref:System.Web.HttpResponse> object that is associated with the <xref:System.Web.UI.Page>. This object allows you to send HTTP response data to a client and contains information about that response.<br /><br /> The `My.Response` object is available only for [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)] applications.|  
|[My.Settings Object](../../../visual-basic/language-reference/objects/my-settings-object.md)|Provides properties and methods for accessing an application's settings.|  
|`My.User` (<xref:Microsoft.VisualBasic.ApplicationServices.User>)|Provides access to information about the current user.|  
|[My.WebServices Object](../../../visual-basic/language-reference/objects/my-webservices-object.md)|Provides properties for creating and accessing a single instance of each Web service that is referenced by the current project.|  
|<xref:Microsoft.VisualBasic.FileIO.TextFieldParser>|Provides methods and properties for parsing structured text files.|  
  
## See Also  
 [Visual Basic Language Reference](../../../visual-basic/language-reference/index.md)  
 [Visual Basic](../../../visual-basic/index.md)
