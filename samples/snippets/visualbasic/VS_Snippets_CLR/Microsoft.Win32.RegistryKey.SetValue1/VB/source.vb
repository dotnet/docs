' <Snippet1>
Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class Example
    Public Shared Sub Main()
        ' Delete and recreate the test key.
        Registry.CurrentUser.DeleteSubKey("RegistrySetValueExample", False)
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("RegistrySetValueExample")
        
        ' Create name/value pairs.
        ' Numeric values that cannot be interpreted as DWord (int) values
        ' are stored as strings.
        rk.SetValue("LargeNumberValue1", CType(42, Long))
        rk.SetValue("LargeNumberValue2", 42000000000)
        
        rk.SetValue("DWordValue", 42)
        rk.SetValue("MultipleStringValue", New String() {"One", "Two", "Three"})
        rk.SetValue("BinaryValue", New Byte() {10, 43, 44, 45, 14, 255})
        
        ' This overload of SetValue does not support expanding strings. Use
        ' the overload that allows you to specify RegistryValueKind.
        rk.SetValue("StringValue", "The path is %PATH%")
        
        ' Display all name/value pairs stored in the test key, with each
        ' registry data type in parentheses.
        '
        Dim valueNames As String() = rk.GetValueNames()
        Dim s As String
        For Each s In  valueNames
            Dim rvk As RegistryValueKind = rk.GetValueKind(s)
            Select Case rvk
                Case RegistryValueKind.MultiString
                    Dim values As String() = CType(rk.GetValue(s), String())
                    Console.Write(vbCrLf + " {0} ({1}) = ""{2}""", s, rvk, values(0))
                    Dim i As Integer
                    For i = 1 To values.Length - 1
                        Console.Write(", ""{0}""", values(i))
                    Next i
                    Console.WriteLine()
                
                Case RegistryValueKind.Binary
                    Dim bytes As Byte() = CType(rk.GetValue(s), Byte())
                    Console.Write(vbCrLf + " {0} ({1}) = {2:X2}", s, rvk, bytes(0))
                    Dim i As Integer
                    For i = 1 To bytes.Length - 1
                        ' Display each byte as two hexadecimal digits.
                        Console.Write(" {0:X2}", bytes(i))
                    Next i
                    Console.WriteLine()
                
                Case Else
                    Console.WriteLine(vbCrLf + " {0} ({1}) = {2}", s, rvk, rk.GetValue(s))
            End Select
        Next s
    End Sub 'Main
End Class 'Example
' </Snippet1>