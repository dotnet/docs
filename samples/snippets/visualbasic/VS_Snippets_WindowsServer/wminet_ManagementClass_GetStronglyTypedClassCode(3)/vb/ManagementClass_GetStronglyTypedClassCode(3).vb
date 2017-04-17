'<Snippet1>
Imports System
Imports System.Management
Imports System.CodeDom
Imports System.IO
Imports System.CodeDom.Compiler
Imports Microsoft.VisualBasic

Class GenerateVBCode

    Public Overloads Shared Function _
        Main(ByVal args() As String) As Integer

        Dim cls1 As ManagementClass
        cls1 = New ManagementClass( _
            Nothing, "Win32_LogicalDisk", Nothing)
        cls1.GetStronglyTypedClassCode( _
            CodeLanguage.VB, _
            "C:\temp\Logicaldisk.vb", _
            String.Empty)

    End Function
End Class
'</Snippet1>