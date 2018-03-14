Option Explicit On
Option Strict On

Class Class17310162be684a19ac0161e297d2b0c5
    ' 17310162-be68-4a19-ac01-61e297d2b0c5
    ' My.Computer.Registry.DynData Property

    Public Sub Method1()
        ' <snippet1>
        My.Computer.Registry.PerformanceData.
            DeleteSubKeyTree("Software\MyCompany\Preferences")
        ' </snippet1>
    End Sub

End Class

Class Class2ff506d6ee7544fc989ef1c6f499fe83
    ' 2ff506d6-ee75-44fc-989e-f1c6f499fe83
    ' My.Computer.Registry.CurrentUser Property

    Public Sub Method2()
        ' <snippet2>
        My.Computer.Registry.CurrentUser.DeleteSubKey(
          "Software\MyCompany\Preferences\UserData")
        ' </snippet2>
    End Sub

End Class

Class Class3baf495730ab472a9eb755a9994a297e
    ' 3baf4957-30ab-472a-9eb7-55a9994a297e
    ' My.Computer.Registry.LocalMachine Property

    Public Sub Method3()
        ' <snippet3>
        My.Computer.Registry.LocalMachine.OpenSubKey(
          "Software\MyCompany\Preferences", True)
        My.Computer.Registry.LocalMachine.SetValue("FontColor", "red")
        ' </snippet3>
    End Sub

End Class

Class Class47aeecc7139b421080f1e848614c6c31
    ' 47aeecc7-139b-4210-80f1-e848614c6c31
    ' My.Computer.Registry.Users Property

    Public Sub Method4()
        ' <snippet4>
        Dim keyCount = My.Computer.Registry.Users.ValueCount
        MsgBox(keyCount)
        ' </snippet4>
    End Sub

End Class

Class Class7aa7af2f269b4d18847ff6f534fa6d01
    ' 7aa7af2f-269b-4d18-847f-f6f534fa6d01
    ' My.Computer.Registry.CurrentConfig Property

    Public Sub Method5()
        ' <snippet5>
        My.Computer.Registry.CurrentConfig.CreateSubKey("MyDeviceSettings")
        ' </snippet5>
    End Sub

End Class

Class Classa113be157cc146988a048122ad130adf
    ' a113be15-7cc1-4698-8a04-8122ad130adf
    ' My.Computer.Registry.SetValue Method

    Public Sub Method6()
        ' <snippet6>
        Dim readValue As Object
        readValue = My.Computer.Registry.GetValue(
          "HKEY_CURRENT_USER\Software\MyApp", "Name", Nothing)
        ' </snippet6>
    End Sub

End Class

Class Classaf2f0b19c5224001abbed9f5a9de5997
    ' af2f0b19-c522-4001-abbe-d9f5a9de5997
    ' My.Computer.Registry.PerformanceData Property

    Public Sub Method7()
        ' <snippet7>
        My.Computer.Registry.PerformanceData.GetValue("MyCompany\ThisSoftware")
        ' </snippet7>
    End Sub

End Class

Class Classafd9edf9ef9b438ba390d71a02dc8203
    ' afd9edf9-ef9b-438b-a390-d71a02dc8203
    ' My.Computer.Registry Object

    Public Sub Method8()
        ' <snippet8>
        Dim readValue As Object
        readValue = My.Computer.Registry.GetValue(
          "HKEY_CURRENT_USER\Software\MyApp", "Name", Nothing)
        MsgBox("The value is " & CStr(readValue))
        ' </snippet8>
    End Sub

End Class

Class Classb54b514b1b824378b43e67a79cc88f5d
    ' b54b514b-1b82-4378-b43e-67a79cc88f5d
    ' My.Computer.Registry.GetValue Method

    Public Sub Method9()
        ' <snippet9>
        Dim readValue As Object
        readValue = My.Computer.Registry.GetValue(
          "HKEY_CURRENT_USER\Software\MyApp", "Name", Nothing)
        MsgBox("The value is " & CStr(readValue))
        ' </snippet9>
    End Sub

End Class

Class Classcd850b90986441b9800de22f4f71e30b
    ' cd850b90-9864-41b9-800d-e22f4f71e30b
    ' My.Computer.Registry.ClassesRoot Property

    Public Sub Method10()
        Dim listbox1 As New System.Windows.Forms.ListBox
        ' <snippet10>
        Dim keyList As System.Collections.IEnumerable
        keyList = My.Computer.Registry.ClassesRoot.GetSubKeyNames()
        For Each keyName As String In keyList
            ListBox1.Items.Add(keyName)
        Next
        ' </snippet10>
    End Sub

End Class


