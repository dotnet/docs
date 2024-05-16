### WPF Printing Stack Update

#### Details

WPF's Printing APIs using <xref:System.Printing.PrintQueue?displayProperty=fullName> now call Window's Print Document Package API in favor of the now deprecated XPS Print API. The change was made with serviceability in mind; neither users nor developers should see any changes in behavior or API usage. The new printing stack is enabled by default when running in Windows 10 Creators Update. The old printing stack will still continue to work just as before in older Windows versions.

#### Suggestion

To use the old stack in Windows 10 Creators Update, set the `UseXpsOMPrinting` REG_DWORD value of the `HKEY_CURRENT_USER\Software\Microsoft\.NETFramework\Windows Presentation Foundation\Printing` registry key to `1`.

| Name    | Value       |
|:--------|:------------|
| Scope   |Edge|
|Version|4.7|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
