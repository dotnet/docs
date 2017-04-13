' <Snippet1>
Imports System

Public Class SamplesDelegate

   ' Declares a delegate for a method that takes in an int and returns a String.
   Delegate Function myMethodDelegate(myInt As Integer) As [String]

   ' Defines some methods to which the delegate can point.
   Public Class mySampleClass

      ' Defines an instance method.
      Public Function myStringMethod(myInt As Integer) As [String]
         If myInt > 0 Then
            Return "positive"
         End If
         If myInt < 0 Then
            Return "negative"
         End If
         Return "zero"
      End Function 'myStringMethod

      ' Defines a static method.
      Public Shared Function mySignMethod(myInt As Integer) As [String]
         If myInt > 0 Then
            Return "+"
         End If
         If myInt < 0 Then
            Return "-"
         End If
         Return ""
      End Function 'mySignMethod
   End Class 'mySampleClass

   Public Shared Sub Main()

      ' Creates one delegate for each method. For the instance method, an
      ' instance (mySC) must be supplied. For the Shared method, the
      ' method name is qualified by the class name.
      Dim mySC As New mySampleClass()
      Dim myD1 As New myMethodDelegate(AddressOf mySC.myStringMethod)
      Dim myD2 As New myMethodDelegate(AddressOf mySampleClass.mySignMethod)

      ' Invokes the delegates.
      Console.WriteLine("{0} is {1}; use the sign ""{2}"".", 5, myD1(5), myD2(5))
      Console.WriteLine("{0} is {1}; use the sign ""{2}"".", - 3, myD1(- 3), myD2(- 3))
      Console.WriteLine("{0} is {1}; use the sign ""{2}"".", 0, myD1(0), myD2(0))

   End Sub 'Main

End Class 'SamplesDelegate 


'This code produces the following output:
' 
'5 is positive; use the sign "+".
'-3 is negative; use the sign "-".
'0 is zero; use the sign "".


' </Snippet1>