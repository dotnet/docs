' <Snippet1>
Imports System.Threading

Public Class Test

    <MTAThread> _
    Shared Sub Main()
        ' To start a thread using a static thread procedure, use the
        ' class name and method name when you create the ThreadStart
        ' delegate. Visual Basic expands the AddressOf expression 
        ' to the appropriate delegate creation syntax:
        '    New ThreadStart(AddressOf Work.DoWork)
        '
        Dim newThread As New Thread(AddressOf Work.DoWork)
        newThread.Start()

        ' To start a thread using an instance method for the thread 
        ' procedure, use the instance variable and method name when 
        ' you create the ThreadStart delegate. Visual Basic expands 
        ' the AddressOf expression to the appropriate delegate 
        ' creation syntax:
        '    New ThreadStart(AddressOf w.DoMoreWork)
        '
        Dim w As New Work()
        w.Data = 42
        newThread = new Thread(AddressOf w.DoMoreWork)
        newThread.Start()
    End Sub
End Class

Public Class Work
    Public Shared Sub DoWork()
        Console.WriteLine("Static thread procedure.")
    End Sub
    Public Data As Integer
    Public Sub DoMoreWork()
        Console.WriteLine("Instance thread procedure. Data={0}", Data)
    End Sub
End Class

' This code example produces the following output (the order 
'   of the lines might vary):
'
'Static thread procedure.
'Instance thread procedure. Data=42
' </Snippet1>
