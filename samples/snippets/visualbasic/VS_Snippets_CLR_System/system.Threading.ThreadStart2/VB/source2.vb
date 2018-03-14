'<snippet2>
Imports System.Threading

Public class ServerClass
    ' The method that will be called when the thread is started.
    Public Sub InstanceMethod()
        Console.WriteLine(
            "ServerClass.InstanceMethod is running on another thread.")

        ' Pause for a moment to provide a delay to make
        ' threads more apparent.
        Thread.Sleep(3000)
        Console.WriteLine(
            "The instance method called by the worker thread has ended.")
    End Sub

    Public Shared Sub SharedMethod()
        Console.WriteLine(
            "ServerClass.SharedMethod is running on another thread.")

        ' Pause for a moment to provide a delay to make
        ' threads more apparent.
        Thread.Sleep(5000)
        Console.WriteLine(
            "The Shared method called by the worker thread has ended.")
    End Sub
End Class

Public class Simple
    Public Shared Sub Main()
        Dim serverObject As New ServerClass()

        ' Create the thread object, passing in the
        ' serverObject.InstanceMethod method using a
        ' ThreadStart delegate.
        Dim InstanceCaller As New Thread(AddressOf serverObject.InstanceMethod)

        ' Start the thread.
        InstanceCaller.Start()

        Console.WriteLine("The Main() thread calls this after " _
            + "starting the new InstanceCaller thread.")

        ' Create the thread object, passing in the
        ' serverObject.SharedMethod method using a
        ' ThreadStart delegate.
        Dim SharedCaller As New Thread( _
            New ThreadStart(AddressOf ServerClass.SharedMethod))

        ' Start the thread.
        SharedCaller.Start()

        Console.WriteLine("The Main() thread calls this after " _
            + "starting the new SharedCaller thread.")
    End Sub
End Class
' The example displays output like the following:
'    The Main() thread calls this after starting the new InstanceCaller thread.
'    The Main() thread calls this after starting the new StaticCaller thread.
'    ServerClass.StaticMethod is running on another thread.
'    ServerClass.InstanceMethod is running on another thread.
'    The instance method called by the worker thread has ended.
'    The static method called by the worker thread has ended.
'</snippet2>
