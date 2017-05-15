'<Snippet1>

Imports System
Imports System.Runtime.InteropServices
Imports System.Reflection

Class LCIDAttrSampler

    Const LCID_INSTALLED As Integer = 1
    Const LCID_SUPPORTED As Integer = 2

    <DllImport("KERNEL32.DLL", EntryPoint:="IsValidLocale", _
    SetLastError:=True, CharSet:=CharSet.Unicode, _
    CallingConvention:=CallingConvention.StdCall), _
    LCIDConversionAttribute(0)> _
    Public Shared Function IsValidLocale(ByVal dwFlags As Integer) As Boolean
    End Function

    Public Sub CheckCurrentLCID()
        Dim mthIfo As MethodInfo = Me.GetType().GetMethod("IsValidLocale")
        Dim attr As Attribute = Attribute.GetCustomAttribute(mthIfo, GetType(LCIDConversionAttribute))

        If Not(attr Is Nothing) Then
            Dim lcidAttr As LCIDConversionAttribute = CType(attr, LCIDConversionAttribute)
            Console.WriteLine("Position of the LCID argument in the unmanaged signature: " + lcidAttr.Value.ToString())
        End If

        Dim res As Boolean = IsValidLocale(LCID_INSTALLED)
        Console.WriteLine("Result LCID_INSTALLED " + res.ToString())
        res = IsValidLocale(LCID_SUPPORTED)
        Console.WriteLine("Result LCID_SUPPORTED " + res.ToString())
    End Sub

    Public Shared Sub Main()
        Dim smpl As LCIDAttrSampler = New LCIDAttrSampler()
        smpl.CheckCurrentLCID()
    End Sub

End Class

'</Snippet1>
