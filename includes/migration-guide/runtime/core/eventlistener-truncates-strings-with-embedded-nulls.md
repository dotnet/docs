### EventListener truncates strings with embedded nulls

|   |   |
|---|---|
|Details|<xref:System.Diagnostics.Tracing.EventListener?displayProperty=name> truncates strings with embedded nulls. Null characters are not supported by the <xref:System.Diagnostics.Tracing.EventSource?displayProperty=name> class. The change only affects apps that use <xref:System.Diagnostics.Tracing.EventListener?displayProperty=name> to read <xref:System.Diagnostics.Tracing.EventSource?displayProperty=name> data in process and that use null characters as delimiters.|
|Suggestion|<xref:System.Diagnostics.Tracing.EventSource?displayProperty=name> data should be updated, if possible, to not use embedded null characters.|
|Scope|Edge|
|Version|4.5.1|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Diagnostics.Tracing.EventListener.%23ctor?displayProperty=nameWithType></li><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource,System.Diagnostics.Tracing.EventLevel)?displayProperty=nameWithType></li><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource,System.Diagnostics.Tracing.EventLevel,System.Diagnostics.Tracing.EventKeywords)?displayProperty=nameWithType></li><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource,System.Diagnostics.Tracing.EventLevel,System.Diagnostics.Tracing.EventKeywords,System.Collections.Generic.IDictionary{System.String,System.String})?displayProperty=nameWithType></li></ul>|
