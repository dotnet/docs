' Visual Basic .NET Document
'Option Strict On
' <Snippet1>
Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms

Module Example
   Public outputMessage As Action(Of String)
   
   Public Sub Main()
      Dim output1 As Action(Of String) = AddressOf Console.WriteLine
      Dim output2 As Action(Of String) = AddressOf OutputToFile 
      Dim output3 As Action(Of String) = AddressOf MessageBox.Show
      
      outputMessage = [Delegate].Combine( { output1, output2, output3 } )
      Console.WriteLine("Invocation list has {0} methods.", 
                        outputMessage.GetInvocationList().Count)

      ' Invoke delegates normally.
      outputMessage("Hello there!")
      Console.WriteLine("Press <Enter> to continue...")
      Console.ReadLine()
      
      ' Invoke each delegate in the invocation list in reverse order.
      For ctr As Integer = outputMessage.GetInvocationList().Count - 1 To 0 Step -1
          Dim outputMsg = outputMessage.GetInvocationList(ctr)
          outputMsg.DynamicInvoke("Greetings and salutations!")
      Next
      Console.WriteLine("Press <Enter> to continue...")
      Console.ReadLine()
      
      ' Invoke each delegate that doesn't write to a file.
      For ctr As Integer = 0 To outputMessage.GetInvocationList().Count - 1 
         Dim outputMsg = outputMessage.GetInvocationList(ctr)
         If Not outputMsg.GetMethodInfo().Name.Contains("File") Then
            outputMsg.DynamicInvoke( { "Hi!" } )
         End If
      Next
   End Sub
   
   Private Sub OutputToFile(s As String)
      Dim sw As New StreamWriter(".\output.txt")
      sw.WriteLine(s)
      sw.Close()
   End Sub
End Module
' </Snippet1>
