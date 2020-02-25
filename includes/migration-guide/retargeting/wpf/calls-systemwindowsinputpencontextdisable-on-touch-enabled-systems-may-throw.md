### Calls to System.Windows.Input.PenContext.Disable on touch-enabled systems may throw an ArgumentException

|   |   |
|---|---|
|Details|Under some circumstances, calls to the internal **System.Windows.Intput.PenContext.Disable** method on touch-enabled systems may throw an unhandled <code>T:System.ArgumentException</code> because of reentrancy.|
|Suggestion|This issue has been addressed in the .NET Framework 4.7. To prevent the exception, upgrade to a version of the .NET Framework starting with the .NET Framework 4.7.|
|Scope|Edge|
|Version|4.6.1|
|Type|Retargeting|
