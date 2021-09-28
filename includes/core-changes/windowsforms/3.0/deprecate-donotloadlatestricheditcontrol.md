### DoNotLoadLatestRichEditControl compatibility switch not supported

The `Switch.System.Windows.Forms.UseLegacyImages` compatibility switch, which was introduced in .NET Framework 4.7.1, is not supported in Windows Forms on .NET Core or .NET 5.0 and later.

#### Change description

In .NET Framework 4.6.2 and previous versions, the <xref:System.Windows.Forms.RichTextBox> control instantiates the Win32 RichEdit control v3.0, and for applications that target .NET Framework 4.7.1, the  <xref:System.Windows.Forms.RichTextBox> control instantiates RichEdit v4.1 (in *msftedit.dll*). The `Switch.System.Windows.Forms.DoNotLoadLatestRichEditControl` compatibility switch was introduced to allow applications that target .NET Framework 4.7.1 and later versions to opt out of the new RichEdit v4.1 control and use the old RichEdit v3 control instead.

In .NET Core and .NET 5.0 and later versions, the `Switch.System.Windows.Forms.DoNotLoadLatestRichEditControl` switch is not supported. Only new versions of the <xref:System.Windows.Forms.RichTextBox> control are supported.

#### Version introduced

3.0

#### Recommended action

Remove the switch. The switch is not supported, and no alternative functionality is available.

#### Category

Windows Forms

#### Affected APIs

- <xref:System.Windows.Forms.RichTextBox?displayProperty=nameWithType>

<!-- 

#### Affected APIs

-  `T:System.Windows.Forms.RichTextBox` 

-->
