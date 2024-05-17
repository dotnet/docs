### Crash in Selector when removing an item from a custom INCC collection

#### Details

An `T:System.InvalidOperationException` can occur in the following scenario:

- The ItemsSource for a `T:System.Windows.Controls.Primitives.Selector` is a collection with a custom implementation of `T:System.Collections.Specialized.INotifyCollectionChanged`.
- The selected item is removed from the collection.
- The `T:System.Collections.Specialized.NotifyCollectionChangedEventArgs` has `P:System.Collections.Specialized.NotifyCollectionChangedEventArgs.OldStartingIndex` = -1 (indicating an unknown position).

The exception's call stack begins `at System.Windows.Threading.Dispatcher.VerifyAccess() at System.Windows.DependencyObject.GetValue(DependencyProperty dp) at System.Windows.Controls.Primitives.Selector.GetIsSelected(DependencyObject element)`. This exception can occur in .NET Framework 4.5 if the application has more than one Dispatcher thread. In .NET Framework 4.7 the exception can also occur in applications with a single Dispatcher thread.

The issue is fixed in .NET Framework 4.7.1.

#### Suggestion

Upgrade to .NET Framework 4.7.1.

| Name    | Value   |
| :------ | :------ |
| Scope   | Minor   |
| Version | 4.7     |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
