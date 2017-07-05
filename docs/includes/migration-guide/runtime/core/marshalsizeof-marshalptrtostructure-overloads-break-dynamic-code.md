### Marshal.SizeOf and Marshal.PtrToStructure overloads break dynamic code

|   |   |
|---|---|
|Details|Beginning in the .NET Framework 4.5.1, dynamically binding to the methods <xref:System.Runtime.InteropServices.Marshal.SizeOf%60%601>, <xref:System.Runtime.InteropServices.Marshal.SizeOf%60%601(%60%600)>, <xref:System.Runtime.InteropServices.Marshal.PtrToStructure(System.IntPtr,System.Object)>, <xref:System.Runtime.InteropServices.Marshal.PtrToStructure(System.IntPtr,System.Type)>, <xref:System.Runtime.InteropServices.Marshal.PtrToStructure%60%601(System.IntPtr)>, or <xref:System.Runtime.InteropServices.Marshal.PtrToStructure%60%601(System.IntPtr,%60%600)>, (via Windows PowerShell, IronPython, or the C# dynamic keyword, for example) can result in <code>MethodInvocationExceptions</code> because new overloads of these methods have been added that may be ambiguous to the scripting engines.|
|Suggestion|Update scripts to clearly indicate which overload shouldbe used. This can typically done by explicitly casting the methods&#39; type parameters as <xref:System.Type>. See <a href="https://support.microsoft.com/en-us/kb/2909958/">this link</a> for more detail and examples of how to workaround the issue.|
|Scope|Minor|
|Version|4.5.1|
|Type|Runtime|
|Analyzers|<ul><li>CD0130</li></ul>|

