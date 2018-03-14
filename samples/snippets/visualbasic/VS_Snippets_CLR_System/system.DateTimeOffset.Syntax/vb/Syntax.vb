' Visual Basic .NET Document
Option Strict On

Public Class modMain 
   Private Shared dto As DateTimeOffset
 
   Private Sub New()
      dto = DateTImeOffset.Now
   End Sub
   
   Public ReadOnly Property UtcDateTime() As DateTime
      Get
         Return dto.UtcDateTime
      End Get
   End Property
   
   Public Shared Sub Main()
      Dim retVal As Integer
      Dim now As Date = Date.Now
      Dim thisInst As New modMain()
      retval = thisInst.Comparison(now, _
      New DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, New TimeSpan(-4, 0, 0)))
      Console.WriteLine(retval)
      Console.WriteLine(thisInst.Equality(DateTimeOffset.Now))
      Console.WriteLine(thisInst.Equality2(dto))
      Console.WriteLine(thisInst.Equality3)
      Console.WriteLine(thisInst.GreaterThan)
   End Sub

   Private Function Comparison(first As DateTimeOffset, second As DateTimeOffset) As Integer
      ' <Snippet1>
      Return DateTime.Compare(first.UtcDateTime, second.UtcDateTime)
      ' </Snippet1>
   End Function
   
   Private Function Equality(other As DateTimeOffset) As Boolean
      Dim dateTimeOffset1 As DateTimeOffset = DateTimeOffset.Now
      ' <Snippet2>
      Return Me.UtcDateTime = other.UtcDateTime
      ' </Snippet2>
   End Function
   
   Private Function Equality2(obj As Object) As Boolean
      ' <Snippet3>
      Return Me.UtcDateTime = DirectCast(obj, DatetimeOffset).UtcDateTime
      ' </Snippet3>   
   End Function
   
   Private Function Equality3() As Boolean
      Dim first As DateTimeOffset = DateTimeOffset.Now
      Dim second As DAteTimeOffset = DateTimeOffset.Now
      ' <Snippet4>
      Return first.UtcDateTime = second.UtcDateTime
      ' </Snippet4>   
    End Function
    
    Private Function GreaterThan() As Boolean
      Dim left As DateTimeOffset = DateTimeOffset.Now
      Dim right As DAteTimeOffset = DateTimeOffset.Now
      ' <Snippet5>
      Return left.UtcDateTime > right.UtcDateTime
      ' </Snippet5>   
      ' <Snippet6>
      Return left.UtcDateTime >= right.UtcDateTime
      ' </Snippet6>   
      ' <Snippet7>
      Return left.UtcDateTime <> right.UtcDateTime
      ' </Snippet7>   
      ' <Snippet8>
      Return left.UtcDateTime < right.UtcDateTime
      ' </Snippet8>   
      ' <Snippet9>
      Return left.UtcDateTime <= right.UtcDateTime
      ' </Snippet9>   
   End Function
End Class

