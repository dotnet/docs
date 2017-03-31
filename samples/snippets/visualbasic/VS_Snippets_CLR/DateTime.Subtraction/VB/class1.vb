Namespace Subtract
    _
   Class Class1
      Public Shared Sub Main(ByVal args() As String)
         '<Snippet1>
         Dim date1 As New System.DateTime(1996, 6, 3, 22, 15, 0)
         Dim date2 As New System.DateTime(1996, 12, 6, 13, 2, 0)
         Dim date3 As New System.DateTime(1996, 10, 12, 8, 42, 0)

         Dim diff1 As System.TimeSpan
         ' diff1 gets 185 days, 14 hours, and 47 minutes.
         diff1 = date2.Subtract(date1)

         Dim date4 As System.DateTime
         ' date4 gets 4/9/1996 5:55:00 PM.
         date4 = date3.Subtract(diff1)

         Dim diff2 As System.TimeSpan
         ' diff2 gets 55 days 4 hours and 20 minutes.
         diff2 = System.DateTime.op_Subtraction(date2, date3)

         Dim date5 As System.DateTime
         ' date5 gets 4/9/1996 5:55:00 PM.
         date5 = System.DateTime.op_Subtraction(date1, diff2)
         '</Snippet1>
         System.Console.WriteLine(diff1)
         System.Console.WriteLine(date4)
         System.Console.WriteLine(diff2)
         System.Console.WriteLine(date4)
      End Sub 'Main
   End Class 'Class1
End Namespace 'Subtract
