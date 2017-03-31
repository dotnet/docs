' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.IO
Imports System.Threading.Tasks

Module Example
   Public Sub Main()
      Dim tasks(1) As Task(Of String())
      Dim docsDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
      
      tasks(0) = Task(Of String()).Factory.StartNew( Function()Directory.GetFiles(docsDirectory) )
''                                        End Sub )
      tasks(1) = Task(Of String()).Factory.StartNew( Function() Directory.GetDirectories(docsDirectory) )
''                                        End Sub )
      Task.Factory.ContinueWhenAll(tasks, Sub(completedTasks)
                                             Console.WriteLine("{0} contains: ", docsDirectory)
                                             Console.WriteLine("   {0} subdirectories", tasks(1).Result.Length)
                                             Console.WriteLine("   {0} files", tasks(0).Result.Length)
                                          End Sub)
   End Sub
End Module
' The example displays output like the following:
'       C:\Users\<username>\Documents contains:
'          24 subdirectories
'          16 files
' </Snippet2>
