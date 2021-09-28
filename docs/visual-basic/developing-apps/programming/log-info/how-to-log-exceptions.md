---
description: "Learn more about: How to: Log Exceptions in Visual Basic"
title: "How to: Log Exceptions"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "exceptions, logging"
  - "exceptions, tracking"
ms.assetid: a26c60e2-ae39-444a-aebb-33eccadc0eeb
---
# How to: Log Exceptions in Visual Basic

You can use the `My.Application.Log` and `My.Log` objects to log information about exceptions that occur in your application. These examples show how to use the `My.Application.Log.WriteException` method to log exceptions that you catch explicitly and exceptions that are unhandled.  
  
 For logging tracing information, use the `My.Application.Log.WriteEntry` method. For more information, see <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A>  
  
### To log a handled exception  
  
1. Create the method that will generate the exception information.  
  
     [!code-vb[VbVbalrMyApplicationLog#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#9)]  
  
2. Use a `Try...Catch` block to catch the exception.  
  
     [!code-vb[VbVbalrMyApplicationLog#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#6)]  
  
3. Put the code that could generate an exception in the `Try` block.  
  
     Uncomment the `Dim` and `MsgBox` lines to cause a <xref:System.NullReferenceException> exception.  
  
     [!code-vb[VbVbalrMyApplicationLog#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#7)]  
  
4. In the `Catch` block, use the `My.Application.Log.WriteException` method to write the exception information.  
  
     [!code-vb[VbVbalrMyApplicationLog#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#8)]  
  
     The following example shows the complete code for logging a handled exception.  
  
     [!code-vb[VbVbalrMyApplicationLog#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#10)]  
  
### To log an unhandled exception  
  
1. Have a project selected in **Solution Explorer**. On the **Project** menu, choose **Properties**.  
  
2. Click the **Application** tab.  
  
3. Click the **View Application Events** button to open the Code Editor.  
  
     This opens the ApplicationEvents.vb file.  
  
4. Have the ApplicationEvents.vb file open in the Code Editor. On the **General** menu, choose **MyApplication Events**.  
  
5. On the **Declarations** menu, choose **UnhandledException**.  
  
     The application raises the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UnhandledException> event before the main application runs.  
  
6. Add the `My.Application.Log.WriteException` method to the `UnhandledException` event handler.  
  
     [!code-vb[VbVbalrMyApplicationLog#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/MyEventsFake.vb#4)]  
  
     The following example shows the complete code for logging an unhandled exception.  
  
     [!code-vb[VbVbalrMyApplicationLog#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/MyEventsFake.vb#5)]  
  
## See also

- <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A>
- <xref:Microsoft.VisualBasic.Logging.Log.WriteException%2A>
- [Working with Application Logs](working-with-application-logs.md)
- [How to: Write Log Messages](how-to-write-log-messages.md)
- [Walkthrough: Determining Where My.Application.Log Writes Information](walkthrough-determining-where-my-application-log-writes-information.md)
- [Walkthrough: Changing Where My.Application.Log Writes Information](walkthrough-changing-where-my-application-log-writes-information.md)
