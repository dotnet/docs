### Null coalescer values are not visible in debugger until one step later

|   |   |
|---|---|
|Details|A bug in the .NET Framework 4.5 causes values set via a null coalescing operation to not be visible in the debugger immediately after the assignment operation is executed when running on the 64-bit version of the Framework.|
|Suggestion|Stepping one additional time in the debugger will cause the local/field's value to be correctly updated. Also, this issue has been fixed in the .NET Framework 4.6; upgrading to that version of the Framework should solve the issue.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
