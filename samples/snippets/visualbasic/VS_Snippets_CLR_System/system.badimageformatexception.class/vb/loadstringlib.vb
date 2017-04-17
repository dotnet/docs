' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim title As String = "a tale of two cities"
      ' Load assembly containing StateInfo type.
      Dim assem As Assembly = Assembly.LoadFrom(".\StringLib.dll")
      ' Get type representing StateInfo class.
      Dim stateInfoType As Type = assem.GetType("StringLib")
      ' Get Display method.
      Dim mi As MethodInfo = stateInfoType.GetMethod("ToProperCase")
      ' Call the Display method. 
      Dim properTitle As String = CStr(mi.Invoke(Nothing, New Object() { title } ))
      Console.WriteLine(properTitle)
   End Sub
End Module
' Attempting to load the StringLib.dll assembly produces the following output:
'    Unhandled Exception: System.BadImageFormatException: 
'                         The format of the file 'StringLib.dll' is invalid.
' </Snippet3>
