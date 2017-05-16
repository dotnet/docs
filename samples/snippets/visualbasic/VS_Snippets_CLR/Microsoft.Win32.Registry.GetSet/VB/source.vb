'<Snippet1>
Imports System
Imports Microsoft.Win32

Public Class Example
    Public Shared Sub Main()
        ' The name of the key must include a valid root.
        Const userRoot As String = "HKEY_CURRENT_USER"
        Const subkey As String = "RegistrySetValueExample"
        Const keyName As String = userRoot & "\" & subkey

        ' Integer values can be stored without specifying the
        ' registry data type, but Long values will be stored
        ' as strings unless you specify the type. Note that
        ' the integer is stored in the default name/value
        ' pair.
        Registry.SetValue(keyName, "", 5280)
        Registry.SetValue(keyName, "TestLong", 12345678901234, _
            RegistryValueKind.QWord)

        ' Strings with expandable environment variables are
        ' stored as ordinary strings unless you specify the
        ' data type.
        Registry.SetValue(keyName, "TestExpand", "My path: %path%")
        Registry.SetValue(keyName, "TestExpand2", "My path: %path%", _
            RegistryValueKind.ExpandString)

        ' Arrays of strings are stored automatically as 
        ' MultiString. Similarly, arrays of Byte are stored
        ' automatically as Binary.
        Dim strings() As String = {"One", "Two", "Three"}
        Registry.SetValue(keyName, "TestArray", strings)

        ' Your default value is returned if the name/value pair
        ' does not exist.
        Dim noSuch As String = _
            Registry.GetValue(keyName, "NoSuchName", _
            "Return this default if NoSuchName does not exist.")
        Console.WriteLine(vbCrLf & "NoSuchName: {0}", noSuch)

        ' Retrieve the Integer and Long values, specifying 
        ' numeric default values in case the name/value pairs
        ' do not exist. The Integer value is retrieved from the
        ' default (nameless) name/value pair for the key.
        Dim tInteger As Integer = _
            Registry.GetValue(keyName, "", -1)
        Console.WriteLine("(Default): {0}", tInteger)
        Dim tLong As Long = Registry.GetValue(keyName, _
             "TestLong", Long.MinValue)
        Console.WriteLine("TestLong: {0}", tLong)

        ' When retrieving a MultiString value, you can specify
        ' an array for the default return value. The value is
        ' declared inline, but could also be declared as:
        ' Dim default() As String = {"Default value."}
        '
        Dim tArray() As String = _
            Registry.GetValue(keyName, "TestArray", _
            New String() {"Default if TestArray does not exist."})
        For i As Integer = 0 To tArray.Length - 1
            Console.WriteLine("TestArray({0}): {1}", i, tArray(i))
        Next

        ' A string with embedded environment variables is not
        ' expanded if it was stored as an ordinary string.
        Dim tExpand As String = Registry.GetValue(keyName, _
             "TestExpand", "Default if TestExpand does not exist.")
        Console.WriteLine("TestExpand: {0}", tExpand)

        ' A string stored as ExpandString is expanded.
        Dim tExpand2 As String = Registry.GetValue(keyName, _
             "TestExpand2", "Default if TestExpand2 does not exist.")
        Console.WriteLine("TestExpand2: {0}...", _
            tExpand2.Substring(0, 40))

        Console.WriteLine(vbCrLf & _
            "Use the registry editor to examine the key.")
        Console.WriteLine("Press the Enter key to delete the key.")
        Console.ReadLine()
        Registry.CurrentUser.DeleteSubKey(subkey)
    End Sub
End Class
'
' This code example produces output similar to the following:
'
'NoSuchName: Return this default if NoSuchName does not exist.
'(Default): 5280
'TestLong: 12345678901234
'TestArray(0): One
'TestArray(1): Two
'TestArray(2): Three
'TestExpand: My path: %path%
'TestExpand2: My path: D:\Program Files\Microsoft.NET\...
'
'Use the registry editor to examine the key.
'Press the Enter key to delete the key.
'</Snippet1>