### Application.FilterMessage no longer throws for re-entrant implementations of IMessageFilter.PreFilterMessage

#### Details

Prior to the .NET Framework 4.6.1, calling <xref:System.Windows.Forms.Application.FilterMessage(System.Windows.Forms.Message@)> with an <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage(System.Windows.Forms.Message@)> which called <xref:System.Windows.Forms.Application.AddMessageFilter(System.Windows.Forms.IMessageFilter)?displayProperty=fullName> or <xref:System.Windows.Forms.Application.RemoveMessageFilter(System.Windows.Forms.IMessageFilter)?displayProperty=fullName> (while also calling <xref:System.Windows.Forms.Application.DoEvents>) would cause an <xref:System.IndexOutOfRangeException?displayProperty=fullName>.<p/>Beginning with applications targeting the .NET Framework 4.6.1, this exception is no longer thrown, and re-entrant filters as described above may be used.

#### Suggestion

Be aware that <xref:System.Windows.Forms.Application.FilterMessage(System.Windows.Forms.Message@)> will no longer throw for the re-entrant <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage(System.Windows.Forms.Message@)> behavior described above. This only affects applications targeting the .NET Framework 4.6.1.Apps targeting the .NET Framework 4.6.1 can opt out of this change (or apps targeting older Frameworks may opt in) by using the [DontSupportReentrantFilterMessage](~/docs/framework/migration-guide/mitigation-custom-imessagefilter-prefiltermessage-implementations.md#mitigation) compatibility switch.

| Name          | Value       |
|:--------------|:------------|
| Scope         | Edge        |
| Version       | 4.6.1       |
| Type          | Retargeting |

#### Affected APIs

- <xref:System.Windows.Forms.Application.FilterMessage(System.Windows.Forms.Message@)?displayProperty=nameWithType>
