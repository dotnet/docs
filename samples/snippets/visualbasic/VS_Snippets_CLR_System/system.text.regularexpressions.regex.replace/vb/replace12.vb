' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      ' Get drives available on local computer and form into a single character expression.
      Dim drives() As String = Environment.GetLogicalDrives()
      Dim driveNames As String = Nothing
      For Each drive As String In drives
         driveNames += drive.Substring(0,1)
      Next
      ' Create regular expression pattern dynamically based on local machine information.
      Dim pattern As String = "\\\\" + Environment.MachineName + "(?:\.\w+)*\\([" + driveNames + "])\$"

      Dim replacement As String = "$1:"
      Dim uncPaths() AS String = {"\\MyMachine.domain1.mycompany.com\C$\ThingsToDo.txt", _
                                  "\\MyMachine\c$\ThingsToDo.txt", _
                                  "\\MyMachine\d$\documents\mydocument.docx" } 
      
      For Each uncPath As String In uncPaths
         Console.WriteLine("Input string: " + uncPath)
         Dim localPath As String = Nothing
         Try
            localPath = Regex.Replace(uncPath, pattern, replacement, 
                                                               RegexOptions.IgnoreCase,
                                                               TimeSpan.FromSeconds(0.5))
            Console.WriteLine("Returned string: " + localPath)         
         Catch e As RegexMatchTimeoutException
            Console.WriteLine("The replace operation timed out.")
            Console.WriteLine("Returned string: " + localPath)
            If uncPath.Equals(localPath) Then 
               Console.WriteLine("Equal to original path.")
            Else
               Console.WriteLine("Original string: " + uncPath)
            End If
         End Try         
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output if run on a machine whose name is
' MyMachine:
'    Input string: \\MyMachine.domain1.mycompany.com\C$\ThingsToTo.txt
'    Returned string: C:\ThingsToDo.txt
'    
'    Input string: \\MyMachine\c$\ThingsToDo.txt
'    Returned string: c:\ThingsToDo.txt
'    
'    Input string: \\MyMachine\d$\documents\mydocument.docx
'    Returned string: d:\documents\mydocument.docx
' </Snippet12>
