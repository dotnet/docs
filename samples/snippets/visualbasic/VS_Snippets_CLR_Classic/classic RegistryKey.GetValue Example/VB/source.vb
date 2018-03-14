' <Snippet1>
Imports System
Imports Microsoft.Win32

Public Class RegGetDef
    Public Shared Sub Main()
        ' Create a reference to a valid key.  In order for this code to
        ' work, the indicated key must have been created previously.
        ' The key name is not case-sensitive.
        Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\myTestKey", false)

        ' Get the value from the specified name/value pair in the key.
        Dim valueName As String = "myTestValue"

        Console.WriteLine("Retrieving registry value ...")
        Console.WriteLine()
        Dim o As Object = rk.GetValue(valueName)
        Console.WriteLine("Object Type = " + o.GetType().FullName)
        Console.WriteLine()
        Select Case rk.GetValueKind(valueName)
            Case RegistryValueKind.String
            Case RegistryValueKind.ExpandString
                Console.WriteLine("Value = " + o)
            Case RegistryValueKind.Binary
                For Each b As Byte In CType(o,Byte())
                    Console.Write("{0:x2} ", b)
                Next b
                Console.WriteLine()
            Case RegistryValueKind.DWord
                Console.WriteLine("Value = " + Convert.ToString(CType(o,Int32)))
            Case RegistryValueKind.QWord
                Console.WriteLine("Value = " + Convert.ToString(CType(o,Int64)))
            Case RegistryValueKind.MultiString
                For Each s As String In CType(o,String())
                    Console.Write("[{0:s}], ", s)
                Next s
                Console.WriteLine()
            Case Else
                Console.WriteLine("Value = (Unknown)")
        End Select

        ' Attempt to retrieve a value that does not exist; the specified
        ' default value is returned.
        Dim Def As String = rk.GetValue("notavalue", "The default to return")
        Console.WriteLine()
        Console.WriteLine(def)
        
        rk.Close()
    End Sub
End Class
'
' Output:
' Retrieving registry value ...
'
' Object Type = System.String
'
' Value = testData
'
'The default to return
' </Snippet1>

