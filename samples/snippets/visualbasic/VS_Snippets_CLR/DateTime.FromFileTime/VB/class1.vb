Imports System.IO

Class Class1
   Public Shared Sub Main()
      Console.WriteLine("Enter a file's path")
      Dim filePath As String = System.Console.ReadLine()
      Dim fInfo As System.IO.FileInfo = Nothing
      Try
         fInfo = New System.IO.FileInfo(filePath)
      Catch

      End Try
      Dim fileTime As Long = System.Convert.ToInt64(fInfo.CreationTime.ToFileTime())
      Dim theApp As New Class1()
      Dim fileAge As System.TimeSpan = theApp.FileAge(fileTime)
      Console.WriteLine("{0}", fileAge)
   End Sub 'Main

   ' This function takes a file's creation time as an unsigned long,
   ' and returns its age.
   '<Snippet1>
   Public Function FileAge(ByVal fileCreationTime As Long) As System.TimeSpan
      Dim now As System.DateTime
      now = System.DateTime.Now

      Try
         Dim fCreationTime As System.DateTime
         Dim fAge As System.TimeSpan
         fCreationTime = System.DateTime.FromFileTime(fileCreationTime)
         fAge = now.Subtract(fCreationTime)
         Return fAge
      Catch exp As ArgumentOutOfRangeException
         ' fileCreationTime is not valid, so re-throw the exception.
         Throw
      End Try
   End Function
   '</Snippet1>
End Class
