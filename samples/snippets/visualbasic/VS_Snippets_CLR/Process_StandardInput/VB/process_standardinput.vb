' System.Diagnostics.Process.StandardInput
'
'
' The following example illustrates how to redirect the StandardInput
' stream of a process.  The example starts the sort command with
' redirected input.  It then prompts the user for text, and passes 
' that to the sort command by means of the redirected input stream.
' The sort command results are displayed to the user on the console.

' <Snippet1>

Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports Microsoft.VisualBasic

Namespace Process_StandardInput_Sample

   Class StandardInputTest
      
      Shared Sub Main()
          
         Console.WriteLine("Ready to sort one or more text lines...")
            
         ' Start the Sort.exe process with redirected input.
         ' Use the sort command to sort the input text.
         Dim myProcess As New Process()
            
         myProcess.StartInfo.FileName = "Sort.exe"
         myProcess.StartInfo.UseShellExecute = False
         myProcess.StartInfo.RedirectStandardInput = True
            
         myProcess.Start()
            
         Dim myStreamWriter As StreamWriter = myProcess.StandardInput
            
         ' Prompt the user for input text lines to sort. 
         ' Write each line to the StandardInput stream of
         ' the sort command.
         Dim inputText As String
         Dim numLines As Integer = 0
         Do
            Console.WriteLine("Enter a line of text (or press the Enter key to stop):")
               
            inputText = Console.ReadLine()
            If inputText.Length > 0 Then
               numLines += 1
               myStreamWriter.WriteLine(inputText)
            End If
         Loop While inputText.Length <> 0
            
            
         ' Write a report header to the console.
         If numLines > 0 Then
            Console.WriteLine(" {0} sorted text line(s) ", numLines)
            Console.WriteLine("------------------------")
         Else
            Console.WriteLine(" No input was sorted")
         End If
            
         ' End the input stream to the sort command.
         ' When the stream closes, the sort command
         ' writes the sorted text lines to the 
         ' console.
         myStreamWriter.Close()
            
            
         ' Wait for the sort process to write the sorted text lines.
         myProcess.WaitForExit()
         myProcess.Close()
         
      End Sub 'Main
   End Class  'StandardInputTest
End Namespace 'Process_StandardInput_Sample
' </Snippet1>
