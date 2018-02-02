### WPF Spell Checking fails in unexpected ways

|   |   |
|---|---|
|Details|This includes a number of WPF Spell Checker issues:<ul><li>WPF Spell Checker sometimes throws <xref:System.Runtime.InteropServices.COMException?displayProperty=name></li><li>WPF Spell Checker fails with <xref:System.UnauthorizedAccessException> when applications are launched using &#39;run as different user&#39;</li><li>WPF Spell Checker incorrectly identifies spelling errors in compound words like &#39;Hausnummer&#39; in German.</li></ul>|
|Suggestion|Issue #1 - This has been fixed in .NET Framework 4.6.2 Issue #2 - WPF Spell Checker is no longer supported when applications are launched using &#39;run as different user&#39;. Starting .NET Framework 4.6.2, applications launched in this manner will no longer crash unexpectedly - instead the Spell Checker will be silently disabled. Issue #3 - This has been fixed in .NET Framework 4.6.2.|
|Scope|Edge|
|Version|4.6.1|
|Type|Runtime|

