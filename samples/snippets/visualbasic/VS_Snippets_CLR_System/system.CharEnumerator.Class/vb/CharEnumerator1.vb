' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      UseCharEnumerator()
      Console.WriteLine("-----")
      UseForEach()
   End Sub
   
   Private Sub UseCharEnumerator()
      ' <Snippet1>
      Dim title As String = "A Tale of Two Cities"
      Dim chEnum As CharEnumerator = title.GetEnumerator()
      Dim ctr As Integer = 1
      Dim outputLine1, outputLine2, outputLine3 As String 
      
      Do While chEnum.MoveNext()
         outputLine1 += CStr(iif(ctr < 10 Or ctr Mod 10 <> 0, "  ", CStr(ctr \ 10) + " ")) 
         outputLine2 += (ctr Mod 10)& " "
         outputLine3 += chEnum.Current & " "
         ctr += 1
      Loop
      
      Console.WriteLine("The length of the string is {0} characters:", _
                        title.Length)
      Console.WriteLine(outputLine1)
      Console.WriteLine(outputLine2)    
      Console.WriteLine(outputLine3)
      ' The example displays the following output to the console:      
      '       The length of the string is 20 characters:
      '                         1                   2
      '       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
      '       A   T a l e   o f   T w o   C i t i e s
      ' </Snippet1>
   End Sub
   
   Private Sub UseForEach()
      ' <Snippet2>
      Dim title As String = "A Tale of Two Cities"
      Dim ctr As Integer = 1
      Dim outputLine1, outputLine2, outputLine3 As String 
      
      For Each ch As Char In title
         outputLine1 += CStr(iif(ctr < 10 Or ctr Mod 10 <> 0, "  ", CStr(ctr \ 10) + " ")) 
         outputLine2 += (ctr Mod 10)& " "
         outputLine3 += ch & " "
         ctr += 1
      Next
      
      Console.WriteLine("The length of the string is {0} characters:", _
                        title.Length)
      Console.WriteLine(outputLine1)
      Console.WriteLine(outputLine2)    
      Console.WriteLine(outputLine3)
      ' The example displays the following output to the console:      
      '       The length of the string is 20 characters:
      '                         1                   2
      '       1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0
      '       A   T a l e   o f   T w o   C i t i e s
      ' </Snippet2>
   End Sub
End Module

