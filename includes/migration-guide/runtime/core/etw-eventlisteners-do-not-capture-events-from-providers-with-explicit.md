### ETW EventListeners do not capture events from providers with explicit keywords (like the TPL provider)

|   |   |
|---|---|
|Details|ETW EventListeners with a blank keyword mask do not properly capture events from providers with explicit keywords. In the .NET Framework 4.5, the TPL provider began providing explicit keywords and triggered this issue. In the .NET Framework 4.6, EventListeners have been updated to no longer have this issue.|
|Suggestion|To work around this problem, replace calls to <xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource,System.Diagnostics.Tracing.EventLevel)> with calls to the EnableEvents overload that explicitly specifies the &quot;any keywords&quot; mask to use: <code>EnableEvents(eventSource, level, unchecked((EventKeywords)0xFFFFffffFFFFffff))</code>.Alternatively, this issue has been fixed in the .NET Framework 4.6 and may be addressed by upgrading to that version of the .NET Framework.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Diagnostics.Tracing.EventListener.EnableEvents(System.Diagnostics.Tracing.EventSource,System.Diagnostics.Tracing.EventLevel)?displayProperty=nameWithType></li></ul>|
