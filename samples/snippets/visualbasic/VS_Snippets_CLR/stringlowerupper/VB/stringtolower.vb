'<snippet1>
Imports System

Public Class ToLowerTest
    
    Public Shared Sub Main()
        Dim info As String() = {"Name", "Title", "Age", "Location", "Gender"}
        
        Console.WriteLine("The initial values in the array are:")

        Dim s As String
        For Each s In info
            Console.WriteLine(s)
        Next 

        Console.WriteLine("{0}The lowercase of these values is:", Environment.NewLine)

        For Each s In info
            Console.WriteLine(s.ToLower())
        Next 

        Console.WriteLine("{0}The uppercase of these values is:", Environment.NewLine)

        For Each s In  info
            Console.WriteLine(s.ToUpper())
        Next 
    End Sub 
End Class 
' The example displays the following output:
'       The initial values in the array are:
'       Name
'       Title
'       Age
'       Location
'       Gender
'       
'       The lowercase of these values is:
'       name
'       title
'       age
'       location
'       gender
'       
'       The uppercase of these values is:
'       NAME
'       TITLE
'       AGE
'       LOCATION
'       GENDER
'</snippet1>
