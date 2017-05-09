' Snippet for S_UE System.ServiceModel.Dispatcher.ExceptionHandler.HandleException
' 06192006 Created by A.Hu

' <snippet0>


Imports System
Imports System.ServiceModel.Dispatcher

Namespace CS
	Public Class MyExceptionHandler
		Inherits ExceptionHandler
			' HandleException method override gives control to 
			' your code.
			Public Overrides Function HandleException(ByVal ex As Exception) As Boolean
				' This method contains logic to decide whether 
				' the exception is serious enough
				' to terminate the process.
				Return ShouldTerminateProcess (ex)
			End Function

			Public Function ShouldTerminateProcess(ByVal ex As Exception) As Boolean
				' Write your logic here.
				Return True
			End Function
	End Class

' </snippet0>
    Module Module1
        ' <snippet1>
        Sub Main(ByVal args() As String)
            ' Create an instance of the MyExceptionHander class.
            Dim thisExceptionHandler As New MyExceptionHandler()

            ' Enable the custom handler by setting 
            '   AsynchronousThreadExceptionHandler property
            '   to this object.
            ExceptionHandler.AsynchronousThreadExceptionHandler = thisExceptionHandler

            ' After the handler is set, write your call to 
            ' System.ServiceModel.ICommunication.Open here
        End Sub
    End Module
    ' </snippet1>
End Namespace
