'<snippet1>
Imports System.Reflection

Module Example
    Sub Main()
        Dim test As String = "abcdefghijklmnopqrstuvwxyz"

        ' Get a PropertyInfo object representing the Chars property.
        Dim pinfo As PropertyInfo = GetType(String).GetProperty("Chars")

        ' Show the first, seventh, and last characters.
        ShowIndividualCharacters(pinfo, test, { 0, 6, test.Length - 1 })

        ' Show the complete string.
        Console.Write("The entire string: ")
        For x As Integer = 0 To test.Length - 1
            Console.Write(pinfo.GetValue(test, { x }))
        Next
        Console.WriteLine()
    End Sub

    Sub ShowIndividualCharacters(pinfo As PropertyInfo, 
                                 value As Object, 
                                 ParamArray indexes() As Integer)
       For Each index In indexes 
          Console.WriteLine("Character in position {0,2}: '{1}'",
                            index, pinfo.GetValue(value, { index }))
       Next
       Console.WriteLine()                          
    End Sub   
End Module
' The example displays the following output:
'       Character in position  0: 'a'
'       Character in position  6: 'g'
'       Character in position 25: 'z'
'       
'       The entire string: abcdefghijklmnopqrstuvwxyz
'</snippet1>
