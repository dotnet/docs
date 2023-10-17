### Add SelectionTextBrush public property to TextBox/PasswordBox non-adorner selection

#### Details

In WPF applications using [non-adorner based text selection](https://github.com/Microsoft/dotnet/blob/master/Documentation/compatibility/wpf-TextBox-PasswordBox-text-selection-does-not-follow-system-colors.md) for <xref:System.Windows.Controls.TextBox> and <xref:System.Windows.Controls.PasswordBox>, developers may now set the newly added SelectionTextBrush property in order to alter the rendering of the selected text.  By default, this color changes with <xref:System.Windows.SystemColors.HighlightTextBrushKey>.  If non-adorner based text selection is not enabled, this property does nothing.

#### Suggestion

Once non-adorner based text selection is enabled, you can use the <xref:System.Windows.Controls.PasswordBox.SelectionTextBrush?displayProperty=nameWithType> and <xref:System.Windows.Controls.Primitives.TextBoxBase.SelectionTextBrush> property to change the appearance of the selected text. This can be achieved using XAML:

```xaml
<TextBox SelectionBrush="Red" SelectionTextBrush="White"  SelectionOpacity="0.5"
Foreground="Blue" CaretBrush="Blue">
This is some text.
</TextBox>

```

| Name    | Value       |
|:--------|:------------|
| Scope   | Major       |
| Version | 4.8         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Windows.Controls.Primitives.TextBoxBase.SelectionTextBrushProperty?displayProperty=nameWithType>
- <xref:System.Windows.Controls.Primitives.TextBoxBase.SelectionTextBrush?displayProperty=nameWithType>
- [System.Windows.Controls.TextBox](xref:System.Windows.Controls.TextBox)
- [System.Windows.Controls.PasswordBox](xref:System.Windows.Controls.PasswordBox)
