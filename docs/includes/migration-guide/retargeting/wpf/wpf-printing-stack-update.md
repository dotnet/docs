### WPF Printing Stack Update

|   |   |
|---|---|
|Details|WPF&#39;s Printing APIs using <xref:System.Printing.PrintQueue?displayProperty=name> now call Window&#39;s Print Document Package API in favor of the now deprecated XPS Print API, neither users nor developers should see any changes in behaviour or API usage, the change was made with serviceability in mind. The new printing stack is by default enabled when running in Windows 10 Creators Update. The old printing stack will still continue to work just as before in older Windows versions.|
|Suggestion|If the user wants to use the old stack in Windows 10 Creators Update, the user should set registry key REG_DWORD <code>HKEY_CURRENT_USER\Software\Microsoft\.NETFramework\Windows Presentation Foundation\Printing\UseXpsOMPrinting = 1</code>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|

