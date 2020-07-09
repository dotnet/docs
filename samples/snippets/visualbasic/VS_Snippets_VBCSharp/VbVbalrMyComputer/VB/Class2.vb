Option Explicit On
Option Strict On

''''''''''''''''
' Keyboard
'''''''''''''''

Namespace Keyboard
    Class Class0746a247f57e45fc93b7de462bef9206

        Public Sub Method23()
            ' 0746a247-f57e-45fc-93b7-de462bef9206
            ' My.Computer.Keyboard.AltKeyDown Property
            ' <snippet23>
            If My.Computer.Keyboard.AltKeyDown Then
                MsgBox("ALT key down")
            Else
                MsgBox("ALT key up")
            End If
            ' </snippet23>

            ' 3a08efec-d444-4200-9341-fff79474d0cc
            ' My.Computer.Keyboard.ScrollLock Property
            ' <snippet31>
            If My.Computer.Keyboard.ScrollLock Then
                MsgBox("SCROLL LOCK on")
            Else
                MsgBox("SCROLL LOCK off")
            End If
            ' </snippet31>

            ' 75b6f2c5-52e6-4f93-9ee6-3d0dfe712ed1
            ' My.Computer.Keyboard.CtrlKeyDown Property
            ' <snippet34>
            If My.Computer.Keyboard.CtrlKeyDown Then
                MsgBox("CTRL key down")
            Else
                MsgBox("CTRL key up")
            End If
            ' </snippet34>

            ' 78dec9be-4e69-4ede-b9be-2ac34bec2b26
            ' My.Computer.Keyboard Object
            ' <snippet36>
            If My.Computer.Keyboard.CtrlKeyDown Then
                MsgBox("CTRL key down")
            Else
                MsgBox("CTRL key up")
            End If
            ' </snippet36>

            ' a5fb87d3-96a2-4e7e-9b13-05cbd45df719
            ' My.Computer.Keyboard.ShiftKeyDown Property
            ' <snippet47>
            If My.Computer.Keyboard.ShiftKeyDown Then
                MsgBox("SHIFT key down")
            Else
                MsgBox("SHIFT key up")
            End If
            ' </snippet47>

            ' acf6542c-abdd-4dca-a81e-d97344f2194f
            ' My.Computer.Keyboard.NumLock Property
            ' <snippet48>
            If My.Computer.Keyboard.NumLock Then
                MsgBox("NUM LOCK on")
            Else
                MsgBox("NUM LOCK off")
            End If
            ' </snippet48>

            ' e37ac3d1-921e-4d86-947e-807696fe4061
            ' My.Computer.Keyboard.CapsLock Property
            ' <snippet50>
            If My.Computer.Keyboard.CapsLock Then
                MsgBox("CAPS LOCK on")
            Else
                MsgBox("CAPS LOCK off")
            End If
            ' </snippet50>
        End Sub

    End Class

    Class Class91e60f5cdd614222ba5f39af803afd8c
        ' 91e60f5c-dd61-4222-ba5f-39af803afd8c
        ' How to: Determine If CapsLock is On in Visual Basic

        Public Sub Method46()
            ' <snippet46>
            If My.Computer.Keyboard.CapsLock Then
                MsgBox("CAPS LOCK is on")
            Else
                MsgBox("CAPS LOCK is off")
            End If
            ' </snippet46>
        End Sub

    End Class

    Class Class29014fe5cccb4b3aafba6da018794c7a
        ' 29014fe5-cccb-4b3a-afba-6da018794c7a
        ' My.Computer.Keyboard.SendKeys Method

        ' f1303184-fce4-44fb-88b4-aac5f42d5d77
        ' How to: Start an Application and Send it Keystrokes (Visual Basic)

        Public Sub Method25()
            ' <snippet25>
            Dim ProcID As Integer
            ' Start the Notepad application, and store the process id.
            ProcID = Shell("NOTEPAD.EXE", AppWinStyle.NormalFocus)
            ' Activate the Notepad application.
            AppActivate(ProcID)
            ' Send the keystrokes to the Notepad application.
            My.Computer.Keyboard.SendKeys("I ", True)
            My.Computer.Keyboard.SendKeys("♥", True)
            My.Computer.Keyboard.SendKeys(" Visual Basic!", True)
            ' The sentence I ♥ Visual Basic! is printed on Notepad.
            ' </snippet25>
        End Sub

    End Class

End Namespace

''''''''''''''''
' Ports
'''''''''''''''

Namespace Ports
    Class Class3834db40f43145f1b671dc91787164b6
        ' 3834db40-f431-45f1-b671-dc91787164b6
        ' How to: Dial Modems Attached to Serial Ports in Visual Basic

        ' <snippet27>
        Sub DialModem()
            ' Dial a number via an attached modem on COM1.
            Using com1 As IO.Ports.SerialPort =
                    My.Computer.Ports.OpenSerialPort("COM1", 9600)
                ' <snippet29>
                com1.DtrEnable = True
                ' </snippet29>
                ' <snippet30>
                com1.Write("ATDT 555-0100" & vbCrLf)
                ' </snippet30>
                ' Insert code to transfer data to and from the modem.
            End Using
        End Sub
        ' </snippet27>

        Public Sub Method28()
            ' <snippet28>
            Using com1 As IO.Ports.SerialPort =
                    My.Computer.Ports.OpenSerialPort("COM1", 9600)
            End Using
            ' </snippet28>
        End Sub

    End Class

    Class Class6ebf46cdb2d04b2c9a1fbe177b22ad52
        ' 6ebf46cd-b2d0-4b2c-9a1f-be177b22ad52
        ' How to: Send Strings to Serial Ports in Visual Basic

        ' 244ede4e-25b7-445b-9fd6-163550cce193
        ' My.Computer.Ports Object

        ' ed1e75f0-635a-4229-8fe6-becea5d036c3
        ' My.Computer.Ports.OpenSerialPort Method

        ' <snippet33>
        Sub SendSerialData(ByVal data As String)
            ' Send strings to a serial port.
            Using com1 As IO.Ports.SerialPort =
                    My.Computer.Ports.OpenSerialPort("COM1")
                com1.WriteLine(data)
            End Using
        End Sub
        ' </snippet33>
    End Class

    Class Class8371ce2ce1c7476ba86d9afc2614b6b7
        ' 8371ce2c-e1c7-476b-a86d-9afc2614b6b7
        ' How to: Receive Strings From Serial Ports in Visual Basic

        ' <snippet37>
        Function ReceiveSerialData() As String
            ' Receive strings from a serial port.
            ' <snippet38>
            Dim returnStr As String = ""
            ' </snippet38>

            Dim com1 As IO.Ports.SerialPort = Nothing
            Try
                com1 = My.Computer.Ports.OpenSerialPort("COM1")
                com1.ReadTimeout = 10000
                Do
                    ' <snippet41>
                    Dim Incoming As String = com1.ReadLine()
                    ' </snippet41>
                    If Incoming Is Nothing Then
                        Exit Do
                        ' <snippet43>
                    Else
                        returnStr &= Incoming & vbCrLf
                        ' </snippet43>
                    End If
                Loop
            Catch ex As TimeoutException
                returnStr = "Error: Serial Port read timed out."
            Finally
                If com1 IsNot Nothing Then com1.Close()
            End Try

            ' <snippet44>
            Return returnStr
            ' </snippet44>
        End Function
        ' </snippet37>

        Public Sub Method39()
            Dim returnStr As String

            Do
                Dim Incoming As String = ""
                ' <snippet42>
                If Incoming Is Nothing Then
                    Exit Do
                End If
                ' </snippet42>
            Loop

            ' <snippet39>
            Dim com1 As IO.Ports.SerialPort = Nothing
            Try
                com1 = My.Computer.Ports.OpenSerialPort("COM1")
                com1.ReadTimeout = 10000

            Catch ex As TimeoutException
                returnStr = "Error: Serial Port read timed out."
            Finally
                If com1 IsNot Nothing Then com1.Close()
            End Try
            ' </snippet39>

            ' <snippet40>
            Do
            Loop
            ' </snippet40>
        End Sub

    End Class

    Class Class8da93782a6924430bf520ff7bbfc20fb
        ' 8da93782-a692-4430-bf52-0ff7bbfc20fb
        ' My.Computer.Ports.SerialPortNames Property

        ' eaf2ee5a-8103-4e10-a205-ed1d4db120ba
        ' How to: Show Available Serial Ports in Visual Basic

        Dim ListBox1 As New ListBox
        ' <snippet45>
        Sub GetSerialPortNames()
            ' Show all available COM ports.
            For Each sp As String In My.Computer.Ports.SerialPortNames
                ListBox1.Items.Add(sp)
            Next
        End Sub
        ' </snippet45>
    End Class
End Namespace

''''''''''''''''
' Mouse
'''''''''''''''

Namespace Mouse
    Class Class332d44f70b664eaab4ced7f161bfbd07
        ' 332d44f7-0b66-4eaa-b4ce-d7f161bfbd07
        ' My.Computer.Mouse.WheelExists Property

        ' 67600f96-25d7-4dd9-946a-b46e1fc6a57f
        ' My.Computer.Mouse.WheelScrollLines Property

        ' da473357-2120-47dd-bd42-c63d695157eb
        ' My.Computer.Mouse Object

        Public Sub Method26()
            ' <snippet26>
            If My.Computer.Mouse.WheelExists Then
                Dim lines As Integer = My.Computer.Mouse.WheelScrollLines
                If lines > 0 Then
                    MsgBox("Application scrolls " &
                        lines & " line(s) for each wheel turn.")
                Else
                    MsgBox("Application scrolls " &
                        (-lines) & " page(s) for each wheel turn.")
                End If
            Else
                MsgBox("Mouse has no scroll wheel.")
            End If
            ' </snippet26>
        End Sub

    End Class

    Class Class77f7e416fb864521bed0657824e97027
        ' 77f7e416-fb86-4521-bed0-657824e97027
        ' My.Computer.Mouse.ButtonsSwapped Property

        Public Sub Method35()
            ' <snippet35>
            If My.Computer.Mouse.ButtonsSwapped Then
                MsgBox("Functionality of the mouse buttons is swapped.")
            Else
                MsgBox("Default functionality of the mouse buttons.")
            End If
            ' </snippet35>
        End Sub

    End Class
End Namespace





