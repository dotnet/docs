'ConvertAssemblyToTypelib
' <snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

<ComImport(), GuidAttribute("00020406-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown), ComVisible(False)> _
Public Interface UCOMICreateITypeLib
    Sub CreateTypeInfo()
    Sub SetName()
    Sub SetVersion()
    Sub SetGuid()
    Sub SetDocString()
    Sub SetHelpFileName()
    Sub SetHelpContext()
    Sub SetLcid()
    Sub SetLibFlags()
    Sub SaveAllChanges()
End Interface 'UCOMICreateITypeLib

Public Class App

    Public Shared Sub Main()
        Dim asm As [Assembly] = [Assembly].LoadFrom("MyAssembly.dll")
        Dim converter As New TypeLibConverter()
        Dim eventHandler As New ConversionEventHandler()

        Dim typeLib As UCOMICreateITypeLib = CType(converter.ConvertAssemblyToTypeLib(asm, "MyTypeLib.dll", 0, eventHandler), UCOMICreateITypeLib)
        typeLib.SaveAllChanges()
    End Sub 'Main
End Class 'App

Public Class ConversionEventHandler
    Implements ITypeLibExporterNotifySink

    Public Sub ReportEvent(ByVal eventKind As ExporterEventKind, ByVal eventCode As Integer, ByVal eventMsg As String) Implements ITypeLibExporterNotifySink.ReportEvent
        ' Handle the warning event here.
    End Sub 'ReportEvent

    Public Function ResolveRef(ByVal asm As [Assembly]) As [Object] Implements ITypeLibExporterNotifySink.ResolveRef
        ' Resolve the reference here and return a correct type library.
        Return Nothing
    End Function 'ResolveRef

End Class 'ConversionEventHandler
' </snippet1>