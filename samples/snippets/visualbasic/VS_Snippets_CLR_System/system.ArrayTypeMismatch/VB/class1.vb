'<Snippet1>
Option Explicit On 
Option Strict On

Imports System


Namespace ArrayTypeMismatch

   Class Class1

      Public Shared Sub Main(ByVal args() As String)
         
         Dim names As String() = {"Dog", "Cat", "Fish"}
         Dim objs As System.Object() = CType(names, System.Object())

         Try
            objs(2) = "Mouse"

            Dim animalName As Object
            For Each animalName In objs
               System.Console.WriteLine(animalName)
            Next animalName
         Catch exp As System.ArrayTypeMismatchException
            ' Not reached, "Mouse" is of the correct type.
            System.Console.WriteLine("Exception Thrown.")
         End Try

         Try
            Dim obj As System.Object
            obj = CType(13, System.Object)
            objs(2) = obj
         Catch exp As System.ArrayTypeMismatchException
            ' Always reached, 13 is not a string.
            System.Console.WriteLine("New element is not of the correct type.")
         End Try

         ' Set objs to an array of objects instead of an array of strings.
         Dim objs2(3) As System.Object
         Try
            objs2(0) = "Turtle"
            objs2(1) = 12
            objs2(2) = 2.341

            Dim element As Object
            For Each element In objs2
               System.Console.WriteLine(element)
            Next element
         Catch exp As System.ArrayTypeMismatchException
            ' ArrayTypeMismatchException is not thrown this time.
            System.Console.WriteLine("Exception Thrown.")
         End Try
         
      End Sub
   End Class
End Namespace
'</Snippet1>