' <snippet2>
Imports System
Imports System.Threading

Public Class ServerClass

    ' The method that will be called when the thread is started.
    Public Sub InstanceMethod()
        Console.WriteLine( _
            "ServerClass.InstanceMethod is running on another thread.")

        ' Pause for a moment to provide a delay to make 
        ' threads more apparent.
        Thread.Sleep(3000) 
        Console.WriteLine( _
            "The instance method called by the worker thread has ended.")
    End Sub 'InstanceMethod

    Public Shared Sub StaticMethod()
        Console.WriteLine( _
            "ServerClass.StaticMethod is running on another thread.")

        ' Pause for a moment to provide a delay to make 
        ' threads more apparent.
        Thread.Sleep(5000) 
        Console.WriteLine( _
            "The static method called by the worker thread has ended.")
    End Sub 'StaticMethod
End Class 'ServerClass

Public Class Simple

    Public Shared Sub Main() 
        Console.WriteLine("Thread Simple Sample")

        Dim serverObject As New ServerClass()

        ' Create the thread object, passing in the 
        ' serverObject.InstanceMethod method using a
        ' ThreadStart delegate.
        Dim InstanceCaller As New Thread( _
            New ThreadStart(AddressOf serverObject.InstanceMethod))

        ' Start the thread.
        InstanceCaller.Start()

        Console.WriteLine("The Main() thread calls this after " _
            & "starting the new InstanceCaller thread.")

        ' Create the thread object, passing in the 
        ' serverObject.StaticMethod method using a 
        ' ThreadStart delegate.
        Dim StaticCaller As New Thread( _
            New ThreadStart(AddressOf ServerClass.StaticMethod))

        ' Start the thread.
        StaticCaller.Start()

        Console.WriteLine("The Main() thread calls this after " _
            & "starting the new StaticCaller thread.")

    End Sub 'Main
End Class 'Simple
' </snippet2>
