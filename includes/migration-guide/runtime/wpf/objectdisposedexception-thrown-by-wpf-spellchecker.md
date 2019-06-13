### ObjectDisposedException thrown by WPF spellchecker

|   |   |
|---|---|
|Details|WPF applications occasionally crash during application shutdown with an <xref:System.ObjectDisposedException?displayProperty=name> thrown by the spellchecker. This is fixed in .NET Framework 4.7 WPF by handling the exception gracefully, and thus ensuring that applications are no longer adversely affected. It should be noted that occasional first-chance exceptions would continue to be observed in applications running under a debugger.|
|Suggestion|Upgrade to .NET Framework 4.7|
|Scope|Edge|
|Version|4.6.1|
|Type|Runtime|
