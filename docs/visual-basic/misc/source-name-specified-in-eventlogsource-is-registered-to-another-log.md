---
title: "Source name specified in EventLogSource is registered to a log other than that specified in EventLogName"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 7317e100-098b-408d-86e5-7c74cf8558c7
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Source name specified in EventLogSource is registered to a log other than that specified in EventLogName
The `EventLog` is attempting to refer to a source that is registered to a different log. If you are writing entries to an event log, you must specify the <xref:System.Diagnostics.EventLog.Source%2A> property. The <xref:System.Diagnostics.EventLog.Source%2A> property registers your component with the event log as a valid source of entries. A single source can be associated with (and therefore write entries to) only one event log at a time.  
  
 By default, if you try to write an entry without first having registered your component as a valid source, the system automatically registers the source with the event log, using the value of the <xref:System.Diagnostics.EventLog.Source%2A> property as the source string.  
  
## To correct this error  
  
-   Make sure the source is registered to the correct log. To do this, use the <xref:System.Diagnostics.EventLog.CreateEventSource%2A> method or one of its overloads to specify a string that uniquely identifies your component to the event log.  
  
## See Also  
 [Administering Event Logs](http://msdn.microsoft.com/library/35f53238-bdd2-417b-acd8-2fd9f7397f18)  
 [Event Log References](http://msdn.microsoft.com/library/4af0661c-6c96-49f4-961d-b26ed9bc3e87)  
 [How to: Add Your Application as a Source of Event Log Entries](http://msdn.microsoft.com/library/948ff920-a739-4e66-a191-ee951512d42c)  
 [How to: Remove an Event Source](http://msdn.microsoft.com/library/bc66c900-4b8a-426a-b8e2-17031a20167e)
