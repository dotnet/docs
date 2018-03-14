' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Reflection

Module Example
   Public Sub Main()
      ' Instantiate a target object.
      Dim int1 As Integer
      ' Set the Type instance to the target class type.
      Dim type1 As Type =int1.GetType()
      ' Instantiate an Assembly class to the assembly housing the Integer type.
      Dim sampleAssembly = Assembly.GetAssembly(int1.GetType())
      ' Display the name of the assembly that is calling the method.
      Console.WriteLine(("GetCallingAssembly = " + Assembly.GetCallingAssembly().FullName))
   End Sub
End Module
' The example displays output like the following:
'   GetCallingAssembly = Example, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
' </Snippet4>

