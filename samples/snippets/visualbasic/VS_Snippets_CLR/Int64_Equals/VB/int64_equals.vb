' System.Int64.Equals(Object)

' The following program demonstrates the 'Equals(Object)' method
' of struct 'Int64'. This compares an instance of 'Int64' with the
' passed in object and returns true if they are equal.

Imports System
Imports Microsoft.VisualBasic

Class MyInt64_Equals
   
   Public Shared Sub Main()
      Try
' <Snippet1>            
         Dim myVariable1 As Int64 = 80
         Dim myVariable2 As Int64 = 80
         
         ' Get and display the declaring type.
         Console.WriteLine(ControlChars.NewLine + "Type of 'myVariable1' is '{0}' and" +  _
                     " value is :{1}", myVariable1.GetType().ToString(), myVariable1.ToString())
         Console.WriteLine("Type of 'myVariable2' is '{0}' and" +  _
                  " value is :{1}", myVariable2.GetType().ToString(), myVariable2.ToString())
         
         ' Compare 'myVariable1' instance with 'myVariable2' Object.
         If myVariable1.Equals(myVariable2) Then
            Console.WriteLine(ControlChars.NewLine + "Structures 'myVariable1' and " + _
                     "'myVariable2' are equal")
         Else
            Console.WriteLine(ControlChars.NewLine + "Structures 'myVariable1' and " +  _
                  "'myVariable2' are not equal")
         End If
' </Snippet1>            
      Catch e As Exception
         Console.WriteLine("Exception :{0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'MyInt64_Equals
