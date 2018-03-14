Option Strict On

Class Class1

      Public Shared Sub Main()
         ' <Snippet1>
         Dim thDay As New System.DateTime(System.DateTime.Today.Year, 7, 28)

         Dim compareValue As Integer
         Try
            compareValue = thDay.CompareTo(System.DateTime.Today)
         Catch exp As ArgumentException
            System.Console.WriteLine("Value is not a DateTime")
         End Try

         If compareValue < 0 Then
            System.Console.WriteLine("{0:d} is in the past.", thDay)
         ElseIf compareValue = 0 Then
            System.Console.WriteLine("{0:d} is today!", thDay)
         Else   ' compareValue >= 1 
            System.Console.WriteLine("{0:d} has not come yet.", thDay)
         End If
         ' </Snippet1>
      End Sub
End Class
