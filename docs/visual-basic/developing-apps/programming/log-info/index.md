---
description: "Learn more about: Logging Information from the Application (Visual Basic)"
title: "Logging Information from the Application"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Log object"
  - "My.Log object"
  - "applications [Visual Basic], logging information from"
  - "logging"
  - "My.Application.Log object"
  - "examples [Visual Basic], logging application information"
ms.assetid: 8bf4f047-22d6-48d6-aec5-93b98ad5b8e8
ms.topic: concept-article
---
# Logging Information from the Application (Visual Basic)

This section contains topics that cover how to log information from your application using the `My.Application.Log` or `My.Log` object, and how to extend the application's logging capabilities.  
  
 The `Log` object provides methods for writing information to the application's log listeners, and the `Log` object's advanced `TraceSource` property provides detailed configuration information. The `Log` object is configured by the application's configuration file.  
  
 The `My.Log` object is available only for ASP.NET applications. For client applications, use `My.Application.Log`. For more information, see <xref:Microsoft.VisualBasic.Logging.Log>.  
  
## Tasks  
  
|To|See|  
|--------|---------|  
|Write event information to the application's logs.|[How to: Write Log Messages](how-to-write-log-messages.md)|  
|Write exception information to the application's logs.|[How to: Log Exceptions](how-to-log-exceptions.md)|  
|Write trace information to the application's logs when the application starts and shuts down.|[How to: Log Messages When the Application Starts or Shuts Down](how-to-log-messages-when-the-application-starts-or-shuts-down.md)|  
|Configure `My.Application.Log` to write information to a text file.|[How to: Write Event Information to a Text File](how-to-write-event-information-to-a-text-file.md)|  
|Configure `My.Application.Log` to write information to an event log.|[How to: Write to an Application Event Log](how-to-write-to-an-application-event-log.md)|  
|Change where `My.Application.Log` writes information.|[Walkthrough: Changing Where My.Application.Log Writes Information](walkthrough-changing-where-my-application-log-writes-information.md)|  
|Determine where `My.Application.Log` writes information.|[Walkthrough: Determining Where My.Application.Log Writes Information](walkthrough-determining-where-my-application-log-writes-information.md)|  
|Create a custom log listener for `My.Application.Log`.|[Walkthrough: Creating Custom Log Listeners](walkthrough-creating-custom-log-listeners.md)|  
|Filter the output of the `My.Application.Log` logs.|[Walkthrough: Filtering My.Application.Log Output](walkthrough-filtering-my-application-log-output.md)|  
  
## See also

- <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>
- [Working with Application Logs](working-with-application-logs.md)
- [Troubleshooting: Log Listeners](troubleshooting-log-listeners.md)
