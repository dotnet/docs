' <snippet2>
Imports System
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

Class SNKToAssembly
    Public Shared Sub Main()
        ' <snippet3>
        Dim fs As New FileStream("SomeKeyPair.snk", FileMode.Open)
        Dim kp As New StrongNameKeyPair(fs)
        fs.Close()
        Dim an As new AssemblyName()
        an.KeyPair = kp
        Dim appDomain As AppDomain = Thread.GetDomain()
        Dim ab As AssemblyBuilder = _
            appDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave)
        ' </snippet3>
    End Sub
End Class
' </snippet2>
