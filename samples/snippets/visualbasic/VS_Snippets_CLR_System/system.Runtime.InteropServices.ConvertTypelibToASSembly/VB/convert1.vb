'ConvertTypelibToAssembly
'<snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Public Class App
    Private Enum RegKind
        RegKind_Default = 0
        RegKind_Register = 1
        RegKind_None = 2
    End Enum 'RegKind

    <DllImport("oleaut32.dll", CharSet:=CharSet.Unicode, PreserveSig:=False)> _
    Private Shared Sub LoadTypeLibEx(ByVal strTypeLibName As [String], ByVal regKind As RegKind, <MarshalAs(UnmanagedType.Interface)> ByRef typeLib As [Object])
    End Sub

    Public Shared Sub Main()
        Dim typeLib As [Object]
        LoadTypeLibEx("SHDocVw.dll", RegKind.RegKind_None, typeLib)

        If typeLib Is Nothing Then
            Console.WriteLine("LoadTypeLibEx failed.")
            Return
        End If

        Dim converter As New TypeLibConverter()
        Dim eventHandler As New ConversionEventHandler()
        Dim asm As AssemblyBuilder = converter.ConvertTypeLibToAssembly(typeLib, "ExplorerLib.dll", 0, eventHandler, Nothing, Nothing, Nothing, Nothing)
        asm.Save("ExplorerLib.dll")
    End Sub 'Main
End Class 'App
 _

Public Class ConversionEventHandler
    Implements ITypeLibImporterNotifySink

    Public Sub ReportEvent(ByVal eventKind As ImporterEventKind, ByVal eventCode As Integer, ByVal eventMsg As String) Implements ITypeLibImporterNotifySink.ReportEvent
        ' handle warning event here...
    End Sub 'ReportEvent

    Public Function ResolveRef(ByVal typeLib As Object) As [Assembly] Implements ITypeLibImporterNotifySink.ResolveRef
        ' resolve reference here and return a correct assembly...
        Return Nothing
    End Function 'ResolveRef
End Class 'ConversionEventHandler
'</snippet1>