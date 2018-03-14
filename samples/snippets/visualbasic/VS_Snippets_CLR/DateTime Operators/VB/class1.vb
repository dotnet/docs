
Class Class1
   Public Shared Sub Main()
      ' <Snippet1>
      Dim dTime As Date = #8/5/1980#

      ' tSpan is 17 days, 4 hours, 2 minutes and 1 second.
      Dim tSpan As New TimeSpan(17, 4, 2, 1)

      Dim result1, result2 As Date

      ' Result gets 8/22/1980 4:02:01 AM.
      result1 = Date.op_Addition(dTime, tSpan)
      
      result2 = dTime + tSpan 
      ' </Snippet1>			
      
      Console.WriteLine(result1)
      Console.WriteLine(result2)

      ' Equality operator.
      ' <Snippet2>
      Dim april19 As New DateTime(2001, 4, 19)
      Dim otherDate As New DateTime(1991, 6, 5)

      Dim areEqual As Boolean
      ' areEqual gets false.
      areEqual = DateTime.op_Equality(april19, otherDate)

      otherDate = New DateTime(2001, 4, 19)
      ' areEqual gets true.
      areEqual = System.DateTime.op_Equality(april19, otherDate)
      ' </Snippet2>
   End Sub
End Class
