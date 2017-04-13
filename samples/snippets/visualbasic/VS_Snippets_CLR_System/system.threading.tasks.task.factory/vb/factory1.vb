' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tasks(1) As Task
      Dim files() As String = Nothing
      Dim dirs() As String = Nothing
      Dim docsDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
      
      tasks(0) = Task.Factory.StartNew( Sub()
                                           files = Directory.GetFiles(docsDirectory)
                                        End Sub )
      tasks(1) = Task.Factory.StartNew( Sub()
                                           dirs = Directory.GetDirectories(docsDirectory)
                                        End Sub )
      Task.Factory.ContinueWhenAll(tasks, Sub(completedTasks)
                                             Console.WriteLine("{0} contains: ", docsDirectory)
                                             Console.WriteLine("   {0} subdirectories", dirs.Length)
                                             Console.WriteLine("   {0} files", files.Length)
                                          End Sub)
   End Sub
End Module
' The example displays output like the following:
'       C:\Users\<username>\Documents contains:
'          24 subdirectories
'          16 files
' </Snippet1>
