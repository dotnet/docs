---
description: "Learn more about: How to: Log Messages When the Application Starts or Shuts Down (Visual Basic)"
title: "How to: Log Messages When the Application Starts or Shuts Down"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "event logs, shutdown"
  - "My.Application.Log object, logging"
  - "Startup event [Visual Basic]"
  - "event logs, startup"
  - "Shutdown event [Visual Basic]"
  - "My.Log object, logging"
ms.assetid: 67624d05-cddf-48b7-8c36-5c99baa4c621
---
# How to: Log Messages When the Application Starts or Shuts Down (Visual Basic)

You can use the `My.Application.Log` and `My.Log` objects to log information about events that occur in your application. This example shows how to use the `My.Application.Log.WriteEntry` method with the `Startup` and `Shutdown` events to write tracing information.  
  
### To access the application's event-handler code  
  
1. Have a project selected in **Solution Explorer**. On the **Project** menu, choose **Properties**.  
  
2. Click the **Application** tab.  
  
3. Click the **View Application Events** button to open the Code Editor.  
  
     This opens the ApplicationEvents.vb file.  
  
### To log messages when the application starts  
  
1. Have the ApplicationEvents.vb file open in the Code Editor. On the **General** menu, choose **MyApplication Events**.  
  
2. On the **Declarations** menu, choose **Startup**.  
  
     The application raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Startup> event before the main application runs.  
  
3. Add the `My.Application.Log.WriteEntry` method to the `Startup` event handler.  
  
     [!code-vb[VbVbalrMyApplicationLog#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/MyEventsFake.vb#1)]  
  
### To log messages when the application shuts down  
  
1. Have the ApplicationEvents.vb file open in the Code Editor. On the **General** menu, choose **MyApplication Events**.  
  
2. On the **Declarations** menu, choose **Shutdown**.  
  
     The application raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.Shutdown> event after the main application runs, but before it shuts down.  
  
3. Add the `My.Application.Log.WriteEntry` method to the `Shutdown` event handler.  
  
     [!code-vb[VbVbalrMyApplicationLog#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/MyEventsFake.vb#2)]  
  
## Example  

 You can use the **Project Designer** to access the application events in the Code Editor. For more information, see [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic).  
  
 [!code-vb[VbVbalrMyApplicationLog#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/MyEventsFake.vb#3)]  
  
## See also

- <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A>
- <xref:Microsoft.VisualBasic.Logging.Log.WriteException%2A>
- [Application Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/application-page-project-designer-visual-basic)
- [Working with Application Logs](working-with-application-logs.md)
