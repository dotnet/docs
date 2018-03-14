' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ShowYMD()
      Console.WriteLine("-----")
      ShowYMDHMS()
      Console.WriteLine("-----")
      ShowYMDHMSMs()
      Console.WriteLine("-----")
      ShowYMDHMSKind()
      Console.WriteLine("-----")
      ShowYMDHMSMsKind()
   End Sub
   
   Private Sub ShowYMD()
      ' <Snippet1>
      Dim date1 As New Date(2010, 8, 18)
      Console.WriteLine(date1.ToString())
      ' The example displays the following output:
      '      8/18/2010 12:00:00 AM      
      ' </Snippet1>
   End Sub
   
   Private Sub ShowYMDHMS()
      ' <Snippet3>
      Dim date1 As New Date(2010, 8, 18, 16, 32, 0)
      Console.WriteLine(date1.ToString())
      ' The example displays the following output:
      '      8/18/2010 4:32:00 PM
      ' </Snippet3>
   End Sub

   Private Sub ShowYMDHMSMs()
      ' <Snippet5>
      Dim date1 As New Date(2010, 8, 18, 16, 32, 18, 500)
      Console.WriteLine(date1.ToString("M/dd/yyyy h:mm:ss.fff tt"))
      ' The example displays the following output:
      '      8/18/2010 4:32:18.500 PM
      ' </Snippet5>
   End Sub
   
   Private Sub ShowYMDHMSKind()
      ' <Snippet7>
      Dim date1 As New Date(2010, 8, 18, 16, 32, 0, DateTimeKind.Local)
      Console.WriteLine("{0} {1}", date1, date1.Kind)
      ' The example displays the following output:
      '      8/18/2010 4:32:00 PM Local
      ' </Snippet7>
   End Sub
   
   Private Sub ShowYMDHMSMsKind()
      ' <Snippet8>
      Dim date1 As New Date(2010, 8, 18, 16, 32, 18, 500, DateTimeKind.Local)
      Console.WriteLine("{0:M/dd/yyyy h:mm:ss.fff tt} {1}", date1, date1.Kind)
      ' The example displays the following output:
      '      8/18/2010 4:32:18.500 PM Local
      ' </Snippet8>
   End Sub
End Module

