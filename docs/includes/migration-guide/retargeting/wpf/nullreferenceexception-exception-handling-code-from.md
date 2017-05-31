### NullReferenceException in exception handling code from ImageSourceConverter.ConvertFrom

|   |   |
|---|---|
|Details|An error in the exception handling code for <xref:System.Windows.Media.ImageSourceConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)> caused an incorrect <xref:System.NullReferenceException?displayProperty=name> to be thrown instead of the intended exception (e.g. <xref:System.IO.DirectoryNotFoundException?displayProperty=name>, <xref:System.IO.FileNotFoundException?displayProperty=name>), this change corrects that error so that the method now throws the right exception.By default all applications targeting .NET Framework 4.6.2 and below will continue to throw <xref:System.NullReferenceException?displayProperty=name> for compatibility, developers targeting .NET Framework 4.7 and above should see the right exceptions.// Replace the space with an &#39;x&#39; if applicable|
|Suggestion|Developers who wish to revert to getting <xref:System.NullReferenceException?displayProperty=name> when targeting .NET Framework 4.7 can add/merge the following to their application&#39;s App.config file:<pre><code>&lt;configuration&gt;<br />&lt;runtime&gt;<br />&lt;AppContextSwitchOverrides value=&quot;Switch.System.Windows.Media.ImageSourceConverter.OverrideExceptionWithNullReferenceException=true&quot;/&gt;<br />&lt;/runtime&gt;<br />&lt;/configuration&gt;</code></pre>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Windows.Media.ImageSourceConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext%2CSystem.Globalization.CultureInfo%2CSystem.Object)?displayProperty=fullName></li></ul>|

