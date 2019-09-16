### Foreach iterator variable is now scoped within the iteration, so closure capturing semantics are different (in C#5)

|   |   |
|---|---|
|Details|Beginning with C# 5 (Visual Studio 2012), <code>foreach</code> iterator variables are scoped within the iteration. This can cause breaks if code was previously depending on the variables to not be included in the <code>foreach</code>'s closure. The symptom of this change is that an iterator variable passed to a delegate is treated as the value it has at the time the delegate is created, rather than the value it has at the time the delegate is invoked.|
|Suggestion|Ideally, code should be updated to expect the new compiler behavior. If the old semantics are required, the iterator variable can be replaced with a separate variable which is explicitly placed outside of the loop's scope.|
|Scope|Major|
|Version|4.5|
|Type|Retargeting|
