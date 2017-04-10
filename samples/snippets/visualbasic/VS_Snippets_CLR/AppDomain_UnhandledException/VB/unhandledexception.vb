Option Strict On
Option Explicit On
   
' <Snippet1>
Module Example
   Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      AddHandler currentDomain.UnhandledException, AddressOf MyHandler
      
      Try
         Throw New Exception("1")
      Catch e As Exception
         Console.WriteLine("Catch clause caught : " + e.Message)
         Console.WriteLine()
      End Try
      
      Throw New Exception("2")
   End Sub
   
   Sub MyHandler(sender As Object, args As UnhandledExceptionEventArgs)
      Dim e As Exception = DirectCast(args.ExceptionObject, Exception)
      Console.WriteLine("MyHandler caught : " + e.Message)
      Console.WriteLine("Runtime terminating: {0}", args.IsTerminating)
   End Sub
End Module
' The example displays the following output:
'       Catch clause caught : 1
'       
'       MyHandler caught : 2
'       Runtime terminating: True
'       
'       Unhandled Exception: System.Exception: 2
'          at Example.Main()
' </Snippet1>
