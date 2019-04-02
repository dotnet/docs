---
title: "Troubleshooting: Log Listeners (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "event logs, troubleshooting"
  - "troubleshooting Visual Basic, event logs"
  - "troubleshooting event logs"
ms.assetid: ac6eb760-3d5d-461e-aedd-40599ee22e49
---
# Troubleshooting: Log Listeners (Visual Basic)
You can use the `My.Application.Log` and `My.Log` objects to log information about events that occur in your application.  
  
 To determine which log listeners receive those messages, see [Walkthrough: Determining Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-determining-where-my-application-log-writes-information.md).  
  
 The `Log` object can use log filtering to limit the amount of information that it logs. If the filters are misconfigured, the logs might contain the wrong information. For more information about filtering, see [Walkthrough: Filtering My.Application.Log Output](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-filtering-my-application-log-output.md).  
  
 However, if a log is configured incorrectly, you may need more information about its current configuration. You can get to this information through the log's advanced `TraceSource` property.  
  
### To determine the log listeners for the Log object in code  
  
1.  Import the <xref:System.Diagnostics> namespace at the beginning of the code file. For more information, see [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md).  
  
     [!code-vb[VbVbalrMyApplicationLog#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#13)]  
  
2.  Create a function that returns a string consisting of information for each of the log's listeners.  
  
     [!code-vb[VbVbalrMyApplicationLog#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#14)]  
  
3.  Pass the collection of the log's trace listeners to the `GetListeners` function, and display the return value.  
  
     [!code-vb[VbVbalrMyApplicationLog#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#19)]  
  
     For more information, see <xref:Microsoft.VisualBasic.Logging.Log.TraceSource%2A>.  
  
## See also

- <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>
- [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md)
- [Walkthrough: Determining Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-determining-where-my-application-log-writes-information.md)
