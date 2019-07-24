### WinForm's CheckForOverflowUnderflow property is now true for System.Drawing

|   |   |
|---|---|
|Details|The CheckForOverflowUnderflow property for the System.Drawing.dll assembly is set to true.|
|Suggestion|Previously when overflows occurred, the result would be silently truncated. Now an <xref:System.OverflowException?displayProperty=name> exception is thrown.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
