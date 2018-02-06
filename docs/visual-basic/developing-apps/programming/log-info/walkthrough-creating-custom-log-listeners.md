---
title: "Creating Custom Log Listeners (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "custom log listeners"
  - "My.Application.Log object, custom log listeners"
ms.assetid: 0e019115-4b25-4820-afb1-af8c6e391698
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Creating Custom Log Listeners (Visual Basic)
This walkthrough demonstrates how to create a custom log listener and configure it to listen to the output of the `My.Application.Log` object.  
  
## Getting Started  
 Log listeners must inherit from the <xref:System.Diagnostics.TraceListener> class.  
  
#### To create the listener  
  
-   In your application, create a class named `SimpleListener` that inherits from <xref:System.Diagnostics.TraceListener>.  
  
     [!code-vb[VbVbalrMyApplicationLog#16](../../../../visual-basic/developing-apps/programming/log-info/codesnippet/VisualBasic/walkthrough-creating-custom-log-listeners_1.vb)]  
  
     The <xref:System.Diagnostics.TraceListener.Write%2A> and <xref:System.Diagnostics.TraceListener.WriteLine%2A> methods, required by the base class, call `MsgBox` to display their input.  
  
     The <xref:System.Security.Permissions.HostProtectionAttribute> attribute is applied to the <xref:System.Diagnostics.TraceListener.Write%2A> and <xref:System.Diagnostics.TraceListener.WriteLine%2A> methods so that their attributes match the base class methods. The <xref:System.Security.Permissions.HostProtectionAttribute> attribute allows the host that runs the code to determine that the code exposes host-protection synchronization.  
  
    > [!NOTE]
    >  The <xref:System.Security.Permissions.HostProtectionAttribute> attribute is effective only on unmanaged applications that host the common language runtime and that implement host protection, such as SQL Server.  
  
 To ensure that `My.Application.Log` uses your log listener, you should strongly name the assembly that contains your log listener.  
  
 The next procedure provides some simple steps for creating a strongly named log-listener assembly. For more information, see [Creating and Using Strong-Named Assemblies](../../../../framework/app-domains/create-and-use-strong-named-assemblies.md).  
  
#### To strongly name the log-listener assembly  
  
1.  Have a project selected in **Solution Explorer**. On the **Project** menu, choose **Properties**.   
  
2.  Click the **Signing** tab.  
  
3.  Select the **Sign the assembly** box.  
  
4.  Select **\<New>** from the **Choose a strong name key file** drop-down list.  
  
     The **Create Strong Name Key** dialog box opens.  
  
5.  Provide a name for the key file in the **Key file name** box.  
  
6.  Enter a password in the **Enter password** and **Confirm password** boxes.  
  
7.  Click **OK**.  
  
8.  Rebuild the application.  
  
## Adding the Listener  
 Now that the assembly has a strong name, you need to determine the strong name of the listener so that `My.Application.Log` uses your log listener.  
  
 The format of a strongly named type is as follows.  
  
 \<type name>, \<assembly name>, \<version number>, \<culture>, \<strong name>  
  
#### To determine the strong name of the listener  
  
-   The following code shows how to determine the strongly named type name for `SimpleListener`.  
  
     [!code-vb[VbVbalrMyApplicationLog#17](../../../../visual-basic/developing-apps/programming/log-info/codesnippet/VisualBasic/walkthrough-creating-custom-log-listeners_2.vb)]  
  
     The strong name of the type depends on your project.  
  
 With the strong name, you can add the listener to the `My.Application.Log` log-listener collection.  
  
#### To add the listener to My.Application.Log  
  
1.  Right-click on app.config in the **Solution Explorer** and choose **Open**.  
  
     -or-  
  
     If there is an app.config file:  
  
    1.  On the **Project** menu, choose **Add New Item**.  
  
    2.  From the **Add New Item** dialog box, choose **Application Configuration File**.  
  
    3.  Click **Add**.  
  
2.  Locate the `<listeners>` section, in the `<source>` section with the `name` attribute "DefaultSource", located in the `<sources>` section. The `<sources>` section is located in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
3.  Add this element to the `<listeners>` section:  
  
    ```xml  
    <add name="SimpleLog" />  
    ```  
  
4.  Locate the `<sharedListeners>` section, in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
5.  Add this element to that `<sharedListeners>` section:  
  
    ```xml  
    <add name="SimpleLog" type="SimpleLogStrongName" />  
    ```  
  
     Change the value of `SimpleLogStrongName` to be the strong name of the listener.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>  
 [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md)  
 [How to: Log Exceptions](../../../../visual-basic/developing-apps/programming/log-info/how-to-log-exceptions.md)  
 [How to: Write Log Messages](../../../../visual-basic/developing-apps/programming/log-info/how-to-write-log-messages.md)  
 [Walkthrough: Changing Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-changing-where-my-application-log-writes-information.md)
