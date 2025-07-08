' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example3
    Public Sub Main()
        Dim p As New Person("John", "Doe")
        Console.WriteLine(p)
    End Sub
End Module

Public Class Person
   Shared infoModule As InfoModule
   
   Dim fName As String
   Dim mName As String
   Dim lName As String
   
   Shared Sub New()
      infoModule = New InfoModule(DateTime.UtcNow)
   End Sub
   
   Public Sub New(fName As String, lName As String)
      Me.fName = fName
      Me.lName = lName
      infoModule.Increment()
   End Sub
   
   Public Overrides Function ToString() As String
      Return String.Format("{0} {1}", fName, lName)
   End Function
End Class
' The example displays the following output if missing1a.dll is renamed or removed:
'    Unhandled Exception: System.TypeInitializationException: 
'       The type initializer for 'Person' threw an exception. ---> 
'       System.IO.FileNotFoundException: Could not load file or assembly 
'       'Missing1a, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' 
'       or one of its dependencies. The system cannot find the file specified.
'       at Person..cctor()
'       --- End of inner exception stack trace ---
'       at Person..ctor(String fName, String lName)
'       at Example.Main()
' </Snippet2>
