' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Threading

Module Example

    Sub Main()
 
        Dim t As New Thread(AddressOf ThreadProc)
        Console.WriteLine("Before setting apartment state: {0}", _
            t.GetApartmentState())

        t.SetApartmentState(ApartmentState.STA)
        Console.WriteLine("After setting apartment state: {0}", _
            t.GetApartmentState())

        Dim result As Boolean = _
            t.TrySetApartmentState(ApartmentState.MTA)
        Console.WriteLine("Try to change state: {0}", result)

        t.Start()

        Thread.Sleep(500)

        Try
            t.TrySetApartmentState(ApartmentState.STA)
        Catch ex As ThreadStateException
            Console.WriteLine("ThreadStateException occurs " & _
                "if apartment state is set after starting thread.")
        End Try

        t.Join()
    End Sub

    Sub ThreadProc()
        Thread.Sleep(2000)
    End Sub
End Module

' This code example produces the following output:
'
'Before setting apartment state: Unknown
'After setting apartment state: STA
'Try to change state: False
'ThreadStateException occurs if apartment state is set after starting thread.
'</Snippet1>
