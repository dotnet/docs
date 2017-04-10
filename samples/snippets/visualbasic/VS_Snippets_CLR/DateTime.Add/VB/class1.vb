Class Class1
   Public Shared Sub Main()
      ' <Snippet1>
      ' Calculate what day of the week is 36 days from this instant.
      Dim today As System.DateTime
      Dim duration As System.TimeSpan
      Dim answer As System.DateTime

      today = System.DateTime.Now
      duration = New System.TimeSpan(36, 0, 0, 0)
      answer = today.Add(duration)

      System.Console.WriteLine("{0:dddd}", answer)
      ' </Snippet1>
   End Sub
End Class
