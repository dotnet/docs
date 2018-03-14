'<Snippet1>
Imports System
Imports Microsoft.Win32
Imports System.Diagnostics

Public Class Example
    
    Public Shared Sub Main() 

        Const LIMIT As Integer = 100
        Dim cu As RegistryKey = Registry.CurrentUser
        Const testKey As String = "RegistryKeyPermissionCheckExample"
        
        Console.WriteLine("Generating {0} key/value pairs.", LIMIT)
        Dim rk As RegistryKey = cu.CreateSubKey(testKey)

        For i As Integer = 0 To LIMIT
            rk.SetValue("Key" & i, i)
        Next i
        
        rk.Close()
        
        Dim s As New Stopwatch()
        
        ' On the default setting, security is checked every time
        ' a key/value pair is read.
        rk = cu.OpenSubKey(testKey, _
            RegistryKeyPermissionCheck.Default)
        
        s.Start()
        For i As Integer = 0 To LIMIT
            rk.GetValue("Key" & i, i)
        Next i
        s.Stop()
        rk.Close()
        Dim delta1 As Long = s.ElapsedTicks
        
        s.Reset()
        
        ' When the key is opened with ReadSubTree, security is 
        ' not checked when the values are read.
        rk = cu.OpenSubKey(testKey, _
            RegistryKeyPermissionCheck.ReadSubTree)
        
        s.Start()
        For i As Integer = 0 To LIMIT
            rk.GetValue("Key" & i, i)
        Next i
        s.Stop()
        rk.Close()
        Dim delta2 As Long = s.ElapsedTicks
        
        Dim faster As Double = _
            CDbl(delta1 - delta2) * 100.0 / CDbl(delta1)
        Console.WriteLine("ReadSubTree is {0}% faster for {1} values.", _
            faster.ToString("0.0"), LIMIT)
        
        cu.DeleteSubKey(testKey)
    
    End Sub 
End Class 

' This code example produces output similar to the following:
'
'Generating 100 key/value pairs.
'ReadSubTree is 23.4% faster for 100 values.
' 
'</Snippet1>