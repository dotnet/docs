' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Imports System.Runtime.Remoting

Module Example
   Public Sub Main()
      Dim handle As ObjectHandle = Activator.CreateInstance("PersonInfo", "Person")
      Dim p As Person = CType(handle.Unwrap(), Person)
      p.Name = "Samuel"
      Console.WriteLine(p)
   End Sub
End Module
' The example displays the following output:
'       Samuel
' </Snippet2>
