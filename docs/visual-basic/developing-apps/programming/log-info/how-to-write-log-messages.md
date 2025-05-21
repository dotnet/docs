---
description: "Learn more about: How to: Write Log Messages (Visual Basic)"
title: "How to: Write Log Messages"
ms.date: 07/20/2015
helpviewer_keywords:
  - "My.Application.Log object, writing log messages"
ms.assetid: 972a3e0c-2996-4623-a7a9-d7ebc4d207f8
ms.topic: how-to
---

# How to: Write Log Messages (Visual Basic)

You can use the `My.Application.Log` and `My.Log` objects to log information about your application. This example shows how to use the `My.Application.Log.WriteEntry` method to log tracing information.

For logging exception information, use the `My.Application.Log.WriteException` method; see [How to: Log Exceptions](how-to-log-exceptions.md).

## Example

This example uses the `My.Application.Log.WriteEntry` method to write out the trace information.

[!code-vb[VbVbalrMyApplicationLog#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrMyApplicationLog/VB/Form1.vb#11)]

## .NET Framework Security

Make sure the data you write to the log does not include sensitive information such as user passwords. For more information, see [Working with Application Logs](working-with-application-logs.md).

## See also

- <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>
- <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A>
- <xref:Microsoft.VisualBasic.Logging.Log.WriteException%2A>
- [Working with Application Logs](working-with-application-logs.md)
- [How to: Log Exceptions](how-to-log-exceptions.md)
- [Walkthrough: Determining Where My.Application.Log Writes Information](walkthrough-determining-where-my-application-log-writes-information.md)
- [Walkthrough: Changing Where My.Application.Log Writes Information](walkthrough-changing-where-my-application-log-writes-information.md)
- [Walkthrough: Filtering My.Application.Log Output](walkthrough-filtering-my-application-log-output.md)
