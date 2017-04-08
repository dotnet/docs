'<Snippet1>
Imports System
Imports System.Reflection

' Specify a combination of AssemblyNameFlags for this 
' assembly.
<Assembly:AssemblyFlagsAttribute( _
       AssemblyNameFlags.EnableJITcompileOptimizer _
    Or AssemblyNameFlags.Retargetable)>

Public Class Example
    Public Shared Sub Main()
        ' Get this assembly.
        Dim thisAsm As Assembly = GetType(Example).Assembly

        ' Get the AssemblyName for this assembly.
        Dim thisAsmName As AssemblyName = thisAsm.GetName(False)

        ' Display the flags that were set for this assembly.
        ListFlags(thisAsmName.Flags)

        ' Create an instance of AssemblyFlagsAttribute with the
        ' same combination of flags that was specified for this
        ' assembly. Note that PublicKey is included automatically
        ' for the assembly, but not for this instance of
        ' AssemblyFlagsAttribute.
        Dim afa As New AssemblyFlagsAttribute( _
               AssemblyNameFlags.EnableJITcompileOptimizer _
            Or AssemblyNameFlags.Retargetable)

        ' Get the flags. The property returns an integer, so
        ' the return value must be cast to AssemblyNameFlags.
        Dim anf As AssemblyNameFlags = _
            CType(afa.AssemblyFlags, AssemblyNameFlags)

        ' Display the flags.
        Console.WriteLine()
        ListFlags(anf)
    End Sub

    Private Shared Sub ListFlags(ByVal anf As AssemblyNameFlags)

        If anf = AssemblyNameFlags.None Then
            Console.WriteLine("AssemblyNameFlags.None")
        Else
            If 0 <> (anf And AssemblyNameFlags.Retargetable) Then _
                Console.WriteLine("AssemblyNameFlags.Retargetable")
            If 0 <> (anf And AssemblyNameFlags.PublicKey) Then _
                Console.WriteLine("AssemblyNameFlags.PublicKey")
            If 0 <> (anf And AssemblyNameFlags.EnableJITcompileOptimizer) Then _
                Console.WriteLine("AssemblyNameFlags.EnableJITcompileOptimizer")
            If 0 <> (anf And AssemblyNameFlags.EnableJITcompileTracking) Then _
                Console.WriteLine("AssemblyNameFlags.EnableJITcompileTracking")
        End If

    End SUb
End Class

' This code example produces the following output:
'
'AssemblyNameFlags.Retargetable
'AssemblyNameFlags.PublicKey
'AssemblyNameFlags.EnableJITcompileOptimizer
'
'AssemblyNameFlags.Retargetable
'AssemblyNameFlags.EnableJITcompileOptimizer
'</Snippet1>