### EventListener truncates strings with embedded nulls

|   |   |
|---|---|
|Details|<xref:System.Diagnostics.Tracing.EventListener?displayProperty=name> truncates strings with embedded nulls. Null characters are not supported by the <xref:System.Diagnostics.Tracing.EventSource?displayProperty=name> class. The change only affects apps that use <xref:System.Diagnostics.Tracing.EventListener?displayProperty=name> to read <xref:System.Diagnostics.Tracing.EventSource?displayProperty=name> data in process and that use null characters as delimiters.|
|Suggestion|<xref:System.Diagnostics.Tracing.EventSource?displayProperty=name> data should be updated, if possible, to not use embedded null characters.|
|Scope|Edge|
|Version|4.5.1|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Diagnostics.Tracing.EventListener.%23ctor?displayProperty=fullName></li><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel)?displayProperty=fullName></li><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel%2CSystem.Diagnostics.Tracing.EventKeywords)?displayProperty=fullName></li><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource%2CSystem.Diagnostics.Tracing.EventLevel%2CSystem.Diagnostics.Tracing.EventKeywords%2CSystem.Collections.Generic.IDictionary%7BSystem.String%2CSystem.String%7D)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0046</li></ul>|

