 ' System.Reflection.ParameterInfo.Attributes
'  The following example displays the attributes associated with the
'  parameters of the method called 'MyMethod' of class 'ParameterInfo_Example'.


' <Snippet1>
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class MyClass1
   
   Public Function MyMethod(i As Integer, ByRef j As Short, ByRef k As Long) As Integer
      j = 2
      Return 0
   End Function 'MyMethod
End Class 'MyClass1

Public Class ParameterInfo_Attributes
   
   Public Shared Sub Main()
      ' Get the type. 
      Dim myType As Type = GetType(MyClass1)
      ' Get the method named 'MyMethod' from the type.
      Dim myMethodBase As MethodBase = myType.GetMethod("MyMethod")
      ' Get the parameters associated with the method.
      Dim myParameters As ParameterInfo() = myMethodBase.GetParameters()
      Console.WriteLine(ControlChars.Cr + "The method {0} has the {1} parameters :", "ParameterInfo_Example.MyMethod", myParameters.Length)
      ' Print the attributes associated with each of the parameters.
      Dim i As Integer
      For i = 0 To myParameters.Length - 1
         Console.WriteLine(ControlChars.Tab + "The {0} parameter has the attribute : {1}", i + 1, myParameters(i).Attributes)
      Next i
   End Sub 'Main
End Class 'ParameterInfo_Attributes
' </Snippet1>