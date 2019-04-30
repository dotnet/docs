### WPF DataTemplate elements are now visible to UIA

|   |   |
|---|---|
|Details|Previously, <xref:System.Windows.DataTemplate?displayProperty=name> elements were invisible to UI Automation. Beginning in 4.5, UI Automation will detect these elements. This is useful in many cases, but can break tests that depend on UIA trees not containing <xref:System.Windows.DataTemplate?displayProperty=name> elements.|
|Suggestion|UI Automation tests for this app may need updated to account for the UIA tree now including previously invisible <xref:System.Windows.DataTemplate?displayProperty=name> elements. For example, tests that expect some elements to be next to each other may now need to expect previously invisible UIA elements in between. Or tests that rely on certain counts or indexes for UIA elements may need updated with new values.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.DataTemplate.%23ctor?displayProperty=nameWithType></li><li><xref:System.Windows.DataTemplate.%23ctor(System.Object)?displayProperty=nameWithType></li></ul>|
