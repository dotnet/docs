' Visual Basic .NET Document
Option Strict On

Imports System.Text

<Assembly: CLSCompliant(True)>
Module modMain
   Public Sub Main()
      ' <Snippet1>      
      Dim s1 As String = "MyTest" 
      Dim s2 As String = New StringBuilder().Append("My").Append("Test").ToString() 
      Dim s3 As String = String.Intern(s2) 
      Console.WriteLine(CObj(s2) Is CObj(s1))      ' Different references.
      Console.WriteLine(CObj(s3) Is CObj(s1))      ' The same reference.
      ' </Snippet1>
   End Sub
End Module

