---
title: "Extending the Visual Basic Application Model"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic Application Model, extending"
ms.assetid: e91d3bed-4c27-40e3-871d-2be17467c72c
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Extending the Visual Basic Application Model
You can add functionality to the application model by overriding the `Overridable` members of the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase> class. This technique allows you to customize the behavior of the application model and add calls to your own methods as the application starts up and shuts down.  
  
## Visual Overview of the Application Model  
 This section visually presents the sequence of function calls in the Visual Basic Application Model. The next section describes the purpose of each function in detail.  
  
 The following graphic shows the application model call sequence in a normal Visual Basic Windows Forms application. The sequence starts when the `Sub Main` procedure calls the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Run%2A> method.  
  
 ![Visual Basic Application Model &#45;&#45; Run](../../../visual-basic/developing-apps/customizing-extending-my/media/vb_modelrun.gif "VB_ModelRun")  
  
 The Visual Basic Application Model also provides the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.StartupNextInstance> and <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UnhandledException> events. The following graphics show the mechanism for raising these events.  
  
 ![Visual Basic Application Model &#45;&#45; Next Instance](../../../visual-basic/developing-apps/customizing-extending-my/media/vb_modelnext.gif "VB_ModelNext")  
  
 ![Visual Basic Application Model Unhandled Exception](../../../visual-basic/developing-apps/customizing-extending-my/media/vb_unhandex.gif "VB_UnhandEx")  
  
## Overriding the Base Methods  
 The <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Run%2A> method defines the order in which the `Application` methods run. By default, the `Sub Main` procedure for a Windows Forms application calls the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Run%2A> method.  
  
 If the application is a normal application (multiple-instance application), or the first instance of a single-instance application, the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Run%2A> method executes the `Overridable` methods in the following order:  
  
1.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnInitialize%2A>. By default, this method sets the visual styles, text display styles, and current principal for the main application thread (if the application uses Windows authentication), and calls `ShowSplashScreen` if neither `/nosplash` nor `-nosplash` is used as a command-line argument.  
  
     The application startup sequence is canceled if this function returns `False`. This can be useful if there are circumstances in which the application should not run.  
  
     The <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnInitialize%2A> method calls the following methods:  
  
    1.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.ShowSplashScreen%2A>. Determines if the application has a splash screen defined and if it does, displays the splash screen on a separate thread.  
  
         The <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.ShowSplashScreen%2A> method contains the code that displays the splash screen for at least the number of milliseconds specified by the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.MinimumSplashScreenDisplayTime%2A> property. To use this functionality, you must add the splash screen to your application using the **Project Designer** (which sets the `My.Application.MinimumSplashScreenDisplayTime` property to two seconds), or set the `My.Application.MinimumSplashScreenDisplayTime` property in a method that overrides the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnInitialize%2A> or <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateSplashScreen%2A> method. For more information, see <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.MinimumSplashScreenDisplayTime%2A>.  
  
    2.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateSplashScreen%2A>. Allows a designer to emit code that initializes the splash screen.  
  
         By default, this method does nothing. If you select a splash screen for your application in the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] **Project Designer**, the designer overrides the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateSplashScreen%2A> method with a method that sets the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.SplashScreen%2A> property to a new instance of the splash-screen form.  
  
2.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnStartup%2A>. Provides an extensibility point for raising the `Startup` event. The application startup sequence stops if this function returns `False`.  
  
     By default, this method raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Startup> event. If the event handler sets the <xref:System.ComponentModel.CancelEventArgs.Cancel> property of the event argument to `True`, the method returns `False` to cancel the application startup.  
  
3.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnRun%2A>. Provides the starting point for when the main application is ready to start running, after the initialization is done.  
  
     By default, before it enters the Windows Forms message loop, this method calls the `OnCreateMainForm` (to create the application's main form) and `HideSplashScreen` (to close the splash screen) methods:  
  
    1.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateMainForm%2A>. Provides a way for a designer to emit code that initializes the main form.  
  
         By default, this method does nothing. However, when you select a main form for your application in the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] **Project Designer**, the designer overrides the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnCreateMainForm%2A> method with a method that sets the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.MainForm%2A> property to a new instance of the main form.  
  
    2.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.HideSplashScreen%2A>. If application has a splash screen defined and it is open, this method closes the splash screen.  
  
         By default, this method closes the splash screen.  
  
4.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnStartupNextInstance%2A>. Provides a way to customize how a single-instance application behaves when another instance of the application starts.  
  
     By default, this method raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.StartupNextInstance> event.  
  
5.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnShutdown%2A>. Provides an extensibility point for raising the `Shutdown` event. This method does not run if an unhandled exception occurs in the main application.  
  
     By default, this method raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Shutdown> event.  
  
6.  <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnUnhandledException%2A>. Executed if an unhandled exception occurs in any of the above listed methods.  
  
     By default, this method raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UnhandledException> event as long as a debugger is not attached and the application is handling the `UnhandledException` event.  
  
 If the application is a single-instance application, and the application is already running, the subsequent instance of the application calls the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnStartupNextInstance%2A> method on the original instance of the application, and then exits.  
 
 The <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.OnStartupNextInstance(Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs)> constructor calls the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UseCompatibleTextRendering%2A> property to determine which text rendering engine to use for the application's forms. By default, the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UseCompatibleTextRendering%2A> property returns `False`, indicating that the GDI text rendering engine be used, which is the default in [!INCLUDE[vbprvblong](~/includes/vbprvblong-md.md)]. You can override the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UseCompatibleTextRendering%2A> property to return `True`, which indicates that the GDI+ text rendering engine be used, which is the default in Visual Basic .NET 2002 and Visual Basic .NET 2003.  
  
## Configuring the Application  
 As a part of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] Application model, the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UseCompatibleTextRendering> class provides protected properties that configure the application. These properties should be set in the constructor of the implementing class.  
  
 In a default Windows Forms project, the **Project Designer** creates code to set the properties with the designer settings. The properties are used only when the application is starting; setting them after the application starts has no effect.  
  
|Property|Determines|Setting in the Application pane of  the Project Designer|  
|---|---|---|  
|<xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.IsSingleInstance%2A>|Whether the application runs as a single-instance or multiple-instance application.|**Make single instance application** check box|  
|<xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.EnableVisualStyles%2A>|If the application will use visual styles that match Windows XP.|**Enable XP visual styles** check box|  
|<xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.SaveMySettingsOnExit%2A>|If application automatically saves application's user-settings changes when the application exits.|**Save My.Settings on Shutdown** check box|  
|<xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.ShutdownStyle%2A>|What causes the application to terminate, such as when the startup form closes or when the last form closes.|**Shutdown mode** list|  
  
## See Also  
 <xref:Microsoft.VisualBasic.ApplicationServices.ApplicationBase>  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Startup>  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.StartupNextInstance>  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UnhandledException>  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Shutdown>  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.NetworkAvailabilityChanged>  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.NetworkAvailabilityChanged>  
 [Overview of the Visual Basic Application Model](../../../visual-basic/developing-apps/development-with-my/overview-of-the-visual-basic-application-model.md)  
 [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic)
