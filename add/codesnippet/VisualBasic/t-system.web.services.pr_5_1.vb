Imports System

Public Class Sample
    
    Public Shared Sub Main()
        Dim ws As New MyWebService()

        Try
            Dim customHeader As New MyHeader1()

            customHeader.MyValue = "Header Value for MyValue"
            customHeader.MustUnderstand = True

            ws.myHeader = customHeader

	    Dim results As Integer

            results = ws.MyWebMethod(3,5)
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.ToString())
        End Try
    End Sub
End Class
