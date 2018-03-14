Option Strict On

Imports System
Imports System.Text.RegularExpressions

<assembly: CLSCompliant(True)>

Public Module Example
   ' <Snippet2>
   Public Sub Main()
      Dim inputString As String = "My favorite web sites include:</P>" & _
                                  "<A HREF=""http://msdn2.microsoft.com"">" & _
                                  "MSDN Home Page</A></P>" & _
                                  "<A HREF=""http://www.microsoft.com"">" & _
                                  "Microsoft Corporation Home Page</A></P>" & _
                                  "<A HREF=""http://blogs.msdn.com/bclteam"">" & _
                                  ".NET Base Class Library blog</A></P>"
      DumpHRefs(inputString)                     
   End Sub
   ' The example displays the following output:
   '       Found href http://msdn2.microsoft.com at 43
   '       Found href http://www.microsoft.com at 102
   '       Found href http://blogs.msdn.com/bclteam/) at 176
   ' </Snippet2>
   
   ' <Snippet1>
   Private Sub DumpHRefs(inputString As String) 
      Dim m As Match
      Dim HRefPattern As String = "href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))"
      
      Try
         m = Regex.Match(inputString, HRefPattern, _ 
                         RegexOptions.IgnoreCase Or RegexOptions.Compiled,
                         TimeSpan.FromSeconds(1))
         Do While m.Success
            Console.WriteLine("Found href {0} at {1}.", _
                              m.Groups(1), m.Groups(1).Index)
            m = m.NextMatch()
         Loop   
      Catch e As RegexMatchTimeoutException
         Console.WriteLine("The matching operation timed out.")
      End Try
   End Sub
   ' </Snippet1>
End Module
