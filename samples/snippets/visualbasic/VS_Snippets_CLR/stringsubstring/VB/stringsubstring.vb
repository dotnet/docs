'<snippet1>
Public Class SubStringTest
    Public Shared Sub Main()
        Dim info As String() = { "Name: Felica Walker", "Title: Mz.", 
                                 "Age: 47", "Location: Paris", "Gender: F"}
        Dim found As Integer = 0
       
        Console.WriteLine("The initial values in the array are:")
        For Each s As String In info
            Console.WriteLine(s)
        Next s

        Console.WriteLine(vbCrLf + "We want to retrieve only the key information. That is:")
        For Each s As String In info
            found = s.IndexOf(": ")
            Console.WriteLine("   {0}", s.Substring(found + 2))
        Next s
    End Sub 
End Class 
' The example displays the following output:
'       The initial values in the array are:
'       Name: Felica Walker
'       Title: Mz.
'       Age: 47
'       Location: Paris
'       Gender: F
'       
'       We want to retrieve only the key information. That is:
'          Felica Walker
'          Mz.
'          47
'          Paris
'          F
'</snippet1>
