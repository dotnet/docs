Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Public Class Sample
    
    Public Sub Method()
' <Snippet1>
 Dim asmname As New AssemblyName()
 asmname.Name = "assemfilename.exe"
 Dim asmbuild As AssemblyBuilder = _
    System.Threading.Thread.GetDomain().DefineDynamicAssembly(asmname, _
    AssemblyBuilderAccess.RunAndSave)
 Dim modbuild As ModuleBuilder = _
    asmbuild.DefineDynamicModule("modulename", "assemfilename.exe")
 Dim typebuild1 As TypeBuilder = modbuild.DefineType("typename")
 typebuild1.CreateType()
 asmbuild.Save("assemfilename.exe")
' </Snippet1>
    End Sub
End Class
