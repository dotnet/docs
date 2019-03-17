---
title: "Source name specified in EventLogSource is registered to a log other than that specified in EventLogName"
ms.date: 07/20/2015
ms.assetid: 7317e100-098b-408d-86e5-7c74cf8558c7
---
# Source name specified in EventLogSource is registered to a log other than that specified in EventLogName
The `EventLog` is attempting to refer to a source that is registered to a different log. If you are writing entries to an event log, you must specify the <xref:System.Diagnostics.EventLog.Source%2A> property. The <xref:System.Diagnostics.EventLog.Source%2A> property registers your component with the event log as a valid source of entries. A single source can be associated with (and therefore write entries to) only one event log at a time.  
  
 By default, if you try to write an entry without first having registered your component as a valid source, the system automatically registers the source with the event log, using the value of the <xref:System.Diagnostics.EventLog.Source%2A> property as the source string.  
  
## To correct this error  
  
-   Make sure the source is registered to the correct log. To do this, use the <xref:System.Diagnostics.EventLog.CreateEventSource%2A> method or one of its overloads to specify a string that uniquely identifies your component to the event log.  
  
## See also

- [Administering Event Logs](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/4f69axw4(v=vs.90))
- [Event Log References](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/k43k9z2a(v=vs.90))
- [How to: Add Your Application as a Source of Event Log Entries](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/xz73e171(v=vs.90))
- [How to: Remove an Event Source](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/k57466fc(v=vs.90))
