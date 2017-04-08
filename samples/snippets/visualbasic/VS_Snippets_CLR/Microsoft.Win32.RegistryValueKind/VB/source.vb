' <Snippet1>
Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Public Class Example
    Public Shared Sub Main()
        ' Delete and recreate the test key.
        Registry.CurrentUser.DeleteSubKey("RegistryValueKindExample", False)
        Dim rk As RegistryKey = Registry.CurrentUser.CreateSubKey("RegistryValueKindExample")
        
        ' Create name/value pairs.
        ' This overload supports QWord (long) values. 
        rk.SetValue("QuadWordValue", 42, RegistryValueKind.QWord)
        
        ' The following SetValue calls have the same effect as using the
        ' SetValue overload that does not specify RegistryValueKind.
        '
        rk.SetValue("DWordValue", 42, RegistryValueKind.DWord)
        rk.SetValue("MultipleStringValue", New String() {"One", "Two", "Three"}, RegistryValueKind.MultiString)
        rk.SetValue("BinaryValue", New Byte() {10, 43, 44, 45, 14, 255}, RegistryValueKind.Binary)
        rk.SetValue("StringValue", "The path is %PATH%", RegistryValueKind.String) 
        
        ' This overload supports setting expandable string values. Compare
        ' the output from this value with the previous string value.
        rk.SetValue("ExpandedStringValue", "The path is %PATH%", RegistryValueKind.ExpandString)
        
        
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
                    Console.Write(vbCrLf & " {0} ({1}) =", s, rvk)
                    For i As Integer = 0 To values.Length - 1
                        If i <> 0 Then Console.Write(",")
                        Console.Write(" ""{0}""", values(i))
                    Next i
                    Console.WriteLine()
                
                Case RegistryValueKind.Binary
                    Dim bytes As Byte() = CType(rk.GetValue(s), Byte())
                    Console.Write(vbCrLf & " {0} ({1}) =", s, rvk)
                    For i As Integer = 0 To bytes.Length - 1
                        ' Display each byte as two hexadecimal digits.
                        Console.Write(" {0:X2}", bytes(i))
                    Next i
                    Console.WriteLine()
                
                Case Else
                    Console.WriteLine(vbCrLf & " {0} ({1}) = {2}", s, rvk, rk.GetValue(s))
            End Select
        Next s
    End Sub 'Main
End Class 'Example

'
'This code example produces the following output (some output is omitted):
'
' QuadWordValue (QWord) = 42
'
' DWordValue (DWord) = 42
'
' MultipleStringValue (MultiString) = "One", "Two", "Three"
'
' BinaryValue (Binary) = 0A 2B 2C 2D 0E FF
'
' StringValue (String) = The path is %PATH%
'
' ExpandedStringValue (ExpandString) = The path is C:\Program Files\Microsoft.NET\SDK\v2.0\Bin;
' [***The remainder of this output is omitted.***]
' </Snippet1>