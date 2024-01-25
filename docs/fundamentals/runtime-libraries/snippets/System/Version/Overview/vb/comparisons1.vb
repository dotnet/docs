' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      CompareSimple()
   End Sub
   
   Private Sub CompareSimple()
      ' <Snippet1>
      Dim v1 As New Version(2,0)
      Dim v2 As New Version("2.1")
      Console.Write("Version {0} is ", v1)
      Select Case v1.CompareTo(v2)
         Case 0
            Console.Write("the same as")
         Case 1
            Console.Write("later than")
         Case -1
            Console.Write("earlier than")
      End Select
      Console.WriteLine(" Version {0}.", v2)                  
      ' The example displays the following output:
      '       Version 2.0 is earlier than Version 2.1.
      ' </Snippet1>      
   End Sub
End Module

