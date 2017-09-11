### ICommand.CanExecuteChanged event behaviour changed in .NET 4.5

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, a <xref:System.Windows.Input.ICommand.CanExecuteChanged?displayProperty=name> was ignored unless the sender of the event was the same object as the object that raised the event. This bug was fixed in .NET Framework 4.5 servcing updates.|
|Suggestion|This bug has been fixed in the .NET Framework 4.5 servicing releases, so it can be avoided by making sure that the .NET Framework is up-to-date or by upgrading to .NET Framework 4.5.1. Alternatively, application code using <xref:System.Windows.Input.ICommand?displayProperty=name> can be modified to make sure that the sender when raising a <xref:System.Windows.Input.ICommand.CanExecuteChanged?displayProperty=name> command is the same as the object raising the event.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Windows.Input.ICommand.CanExecuteChanged?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0084</li></ul>|

