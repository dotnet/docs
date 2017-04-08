Imports System

Module Module1
    
    Sub Main()
    
    '<snippet1>
        Try
            Dim myProc As New System.Diagnostics.Process()
            myProc.StartInfo.FileName = "c:\nonexist.exe"  'Attempting to start a non-existing executable
            myProc.Start()    'Start the application and assign it to the process component.    

        Catch w As System.ComponentModel.Win32Exception
            Console.WriteLine(w.Message)
            Console.WriteLine(w.ErrorCode.ToString())
            Console.WriteLine(w.NativeErrorCode.ToString())
            Console.WriteLine(w.StackTrace)
            Console.WriteLine(w.Source)
            Dim e As New Exception()
            e = w.GetBaseException()
            Console.WriteLine(e.Message)
        End Try
        '</snippet1>
    End Sub

End Module
