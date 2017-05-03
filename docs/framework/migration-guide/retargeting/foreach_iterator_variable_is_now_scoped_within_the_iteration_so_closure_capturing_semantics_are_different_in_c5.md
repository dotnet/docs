### Foreach iterator variable is now scoped within the iteration, so closure capturing semantics are different (in C\#5)

|   |   |
|---|---|
|Details|Beginning with C# 5 (Visual Studio 2012), foreach iterator variables are scoped within the iteration. This can cause breaks if code was previously depending on the variables to not be included in the foreach&#39;s closure. The symptom of this change will be that an iterator variable passed to a delagate will be treated as the value it had at the time the delegate was created, rather than the value it had at the time the delegate was invoked.|
|Suggestion|Ideally, code should be updated to expect the new compiler behavior. If the old semantics are required, the iterator variable can be replaced with a separate variable which is explicitly placed outside of the loop&#39;s scope.|
|Scope|Major|
|Version|4.5|
|Type|Retargeting|
|Analyzers|<ul><li>CD0100</li></ul>|
