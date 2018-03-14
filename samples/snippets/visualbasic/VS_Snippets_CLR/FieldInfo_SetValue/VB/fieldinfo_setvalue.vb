' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Globalization

Public Class Example
   Private myString As String
   
   Public Sub New()
      myString = "Old value"
   End Sub 
   
   ReadOnly Property StringProperty() As String
      Get
         Return myString
      End Get
   End Property
End Class 


Public Module FieldInfo_SetValue
   
   Sub Main()

        Dim myObject As New Example()
        Dim myType As Type = GetType(Example)
        Dim myFieldInfo As FieldInfo = myType.GetField("myString", _
           BindingFlags.NonPublic Or BindingFlags.Instance)

        ' Display the string before applying SetValue to the field.
        Console.WriteLine(vbCrLf & "The field value of myString is ""{0}"".", _
            myFieldInfo.GetValue(myObject))
        ' Display the SetValue signature used to set the value of a field.
        Console.WriteLine("Applying SetValue(Object, Object).")

        ' Change the field value using the SetValue method. 
        myFieldInfo.SetValue(myObject, "New value")
        ' Display the string after applying SetValue to the field.
        Console.WriteLine("The field value of mystring is ""{0}"".", _
            myFieldInfo.GetValue(myObject))

    End Sub 
End Module

' This code example produces the following output:
' The field value of myString is "Old value".
' Applying SetValue(Object, Object).
' The field value of mystring is "New value".
' </Snippet1>