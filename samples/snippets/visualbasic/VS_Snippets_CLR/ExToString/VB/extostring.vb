'<Snippet1>
Public Class TestClass
End Class 


Public Class Example
   Public Shared Sub Main()
      Dim test As New TestClass()
      Dim objectsToCompare() As Object = { test, test.ToString(), 123,
                                           123.ToString(), "some text",
                                           "Some Text" }
      Dim s As String = "some text"
      For Each objectToCompare In objectsToCompare
         Try
            Dim i As Integer = s.CompareTo(objectToCompare)
            Console.WriteLine("Comparing '{0}' with '{1}': {2}",
                              s, objectToCompare, i)
         Catch e As ArgumentException
            Console.WriteLine("Bad argument: {0} (type {1})",
                              objectToCompare,
                              objectToCompare.GetType().Name)
         End Try
      Next
   End Sub 
End Class 
' The example displays the following output:
'       Bad argument: TestClass (type TestClass)
'       Comparing 'some text' with 'TestClass': -1
'       Bad argument: 123 (type Int32)
'       Comparing 'some text' with '123': 1
'       Comparing 'some text' with 'some text': 0
'       Comparing 'some text' with 'Some Text': -1
' </Snippet1>