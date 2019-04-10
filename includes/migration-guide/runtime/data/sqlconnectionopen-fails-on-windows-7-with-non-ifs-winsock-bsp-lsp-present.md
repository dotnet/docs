### SqlConnection.Open fails on Windows 7 with non-IFS Winsock BSP or LSP present

|   |   |
|---|---|
|Details|<xref:System.Data.SqlClient.SqlConnection.Open> and <xref:System.Data.SqlClient.SqlConnection.OpenAsync(System.Threading.CancellationToken)> fail in the .NET Framework 4.5 if running on a Windows 7 machine with a non-IFS Winsock BSP or LSP are present on the computer.To determine whether a non-IFS BSP or LSP is installed, use the <code>netsh WinSock Show Catalog</code> command, and examine every <code>Winsock Catalog Provider Entry</code> item that is returned. If the Service Flags value has the <code>0x20000</code> bit set, the provider uses IFS handles and will work correctly. If the <code>0x20000</code> bit is clear (not set), it is a non-IFS BSP or LSP.|
|Suggestion|This bug has been fixed in the .NET Framework 4.5.2, so it can be avoided by upgrading the .NET Framework. Alternatively, it can be avoided by removing any installed non-IFS Winsock LSPs.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.SqlClient.SqlConnection.Open?displayProperty=nameWithType></li><li><xref:System.Data.SqlClient.SqlConnection.OpenAsync(System.Threading.CancellationToken)?displayProperty=nameWithType></li></ul>|
