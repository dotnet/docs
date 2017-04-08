' <Snippet1>
Class Example
     Public Shared Sub Main()
         Try
             ' Get the type of the specified class.
             Dim myType1 As Type = Type.GetType("System.Int32")
             Console.WriteLine("The full name is {0}.", myType1.FullName)
         Catch e As TypeLoadException
             Console.WriteLine("{0}: Unable to load type System.Int32",
                               e.GetType().Name)
         End Try

         Console.WriteLine()

         Try
             ' Since NoneSuch does not exist in this assembly, GetType throws a TypeLoadException.
             Dim myType2 As Type = Type.GetType("NoneSuch", True)
             Console.WriteLine("The full name is {0}.", myType2.FullName)
         Catch e As TypeLoadException
             Console.WriteLine("{0}: Unable to load type NoneSuch", e.GetType().Name)
         End Try
     End Sub
End Class
' The example displays the following output:
'       The full name is System.Int32.
'
'       TypeLoadException: Unable to load type NoneSuch
' </Snippet1>