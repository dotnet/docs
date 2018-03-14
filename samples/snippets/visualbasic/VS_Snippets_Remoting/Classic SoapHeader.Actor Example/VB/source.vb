Imports System.Web.Services.Protocols
' <Snippet1>
Imports System

Public Class Sample
    
    Public Shared Sub Main()
        Dim ws As New MyWebService()

        Try
            Dim customHeader As New MyHeader1()

            customHeader.MyValue = "Header Value for MyValue"
            customHeader.Actor = "http://www.contoso.com/MySoapHeaderHandler"

            ws.myHeader = customHeader

	    Dim results As Integer

            results = ws.MyWebMethod(3,5)
        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.ToString())
        End Try
    End Sub
End Class

' </Snippet1>

' Following was added to make the sample compile.  
Public Class MyHeader1
	Inherits SoapHeader 

	Public MyValue As String
End Class

Public Class MyWebService 

	Public myHeader As MyHeader1

	Public Function MyWebMethod(num1 As Integer,num2 As Integer) As Integer
	 	Return num1 + num2
	End Function

End Class