### WPF Printing Stack Update

|   |   |
|---|---|
|Details|WPF's Printing APIs using <xref:System.Printing.PrintQueue?displayProperty=name> now call Window's Print Document Package API in favor of the now deprecated XPS Print API. The change was made with serviceability in mind; neither users nor developers should see any changes in behavior or API usage. The new printing stack is enabled by default when running in Windows 10 Creators Update. The old printing stack will still continue to work just as before in older Windows versions.|
|Suggestion|To use the old stack in Windows 10 Creators Update, set the <code>UseXpsOMPrinting</code> REG_DWORD value of the <code>HKEY_CURRENT_USER\Software\Microsoft\.NETFramework\Windows Presentation Foundation\Printing</code> registry key to <code>1</code>.|
|Scope|Edge|
|Version|4.7|
|Type|Runtime|
