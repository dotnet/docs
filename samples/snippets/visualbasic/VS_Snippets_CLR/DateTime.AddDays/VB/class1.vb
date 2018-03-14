' <Snippet1>
Class Class1
   Public Shared Sub Main()
      Dim today As System.DateTime
      Dim answer As System.DateTime

      today = System.DateTime.Now
      answer = today.AddDays(36)

      Console.WriteLine("Today: {0:dddd}", today)
      Console.WriteLine("36 days from today: {0:dddd}", answer)
   End Sub
End Class
' The example displays output like the following:
'       Today: Wednesday
'       36 days from today: Thursday
' </Snippet1>
