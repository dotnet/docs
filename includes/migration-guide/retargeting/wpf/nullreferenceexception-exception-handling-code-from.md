### NullReferenceException in exception handling code from ImageSourceConverter.ConvertFrom

|   |   |
|---|---|
|Details|An error in the exception handling code for <xref:System.Windows.Media.ImageSourceConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)> caused an incorrect <xref:System.NullReferenceException?displayProperty=name> to be thrown instead of the intended exception ( <xref:System.IO.DirectoryNotFoundException?displayProperty=name> or <xref:System.IO.FileNotFoundException?displayProperty=name>). This change corrects that error so that the method now throws the right exception. <p/>By default all applications targeting .NET Framework 4.6.2 and earlier continue to throw <xref:System.NullReferenceException?displayProperty=name> for compatibility. Developers targeting .NET Framework 4.7 and above should see the right exceptions.|
|Suggestion|Developers who wish to revert to getting <xref:System.NullReferenceException?displayProperty=name> when targeting .NET Framework 4.7 or later can add/merge the following to their application's App.config file:<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;runtime&gt;&#13;&#10;&lt;AppContextSwitchOverrides value=&quot;Switch.System.Windows.Media.ImageSourceConverter.OverrideExceptionWithNullReferenceException=true&quot;/&gt;&#13;&#10;&lt;/runtime&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>|
|Scope|Edge|
|Version|4.7|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Windows.Media.ImageSourceConverter.ConvertFrom(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object)?displayProperty=nameWithType></li></ul>|
