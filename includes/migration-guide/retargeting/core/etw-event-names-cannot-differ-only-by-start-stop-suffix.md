### ETW event names cannot differ only by a "Start" or "Stop" suffix

|   |   |
|---|---|
|Details|In the .NET Framework 4.6 and 4.6.1, the runtime throws an <xref:System.ArgumentException> when two Event Tracing for Windows (ETW) event names differ only by a &quot;Start&quot; or &quot;Stop&quot; suffix (as when one event is named <code>LogUser</code> and another is named <code>LogUserStart</code>). In this case, the runtime cannot construct the event source, which cannot emit any logging.|
|Suggestion|To prevent the exception, ensure that no two event names differ only by a &quot;Start&quot; or &quot;Stop&quot; suffix.This requirement is removed starting with the .NET Framework 4.6.2; the runtime can disambiguate event names that differ only by the &quot;Start&quot; and &quot;Stop&quot; suffix.|
|Scope|Edge|
|Version|4.6|
|Type|Retargeting|
