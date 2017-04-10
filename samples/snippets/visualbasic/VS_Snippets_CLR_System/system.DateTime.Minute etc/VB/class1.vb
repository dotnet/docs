
Namespace Minute_Etc
    _
   Class Class1

      Public Shared Sub Main()
         ' <Snippet1>
         Dim moment As New System.DateTime(1999, 1, 13, 3, 57, 32, 11)

         ' Year gets 1999.
         Dim year As Integer = moment.Year

         ' Month gets 1 (January).
         Dim month As Integer = moment.Month

         ' Day gets 13.
         Dim day As Integer = moment.Day

         ' Hour gets 3.
         Dim hour As Integer = moment.Hour

         ' Minute gets 57.
         Dim minute As Integer = moment.Minute

         ' Second gets 32.
         Dim second As Integer = moment.Second

         ' Millisecond gets 11.
         Dim millisecond As Integer = moment.Millisecond
         ' </Snippet1>
      End Sub
   End Class
End Namespace
