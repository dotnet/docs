### WF serializes Expressions.Literal&lt;T&gt; DateTimes differently now (breaks custom XAML parsers)

|   |   |
|---|---|
|Details|The associated <xref:System.Windows.Markup.ValueSerializer> object will convert a <xref:System.DateTime?displayProperty=name> or <xref:System.DateTimeOffset?displayProperty=name> object whose Second and <xref:System.DateTime.Millisecond?displayProperty=name> components are non-zero and (for a <xref:System.DateTime?displayProperty=name> value) whose <xref:System.DateTime.Kind> property is not Unspecified to property element syntax instead of a string. This change allows <xref:System.DateTime?displayProperty=name> and <xref:System.DateTimeOffset?displayProperty=name> values to be round-tripped. Custom XAML parsers that assume that input XAML is in the attribute syntax will not function correctly.|
|Suggestion|This change allows <xref:System.DateTime?displayProperty=name> and <xref:System.DateTimeOffset?displayProperty=name> values to be round-tripped. Custom XAML parsers that assume that input XAML is in the attribute syntax will not function correctly.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
