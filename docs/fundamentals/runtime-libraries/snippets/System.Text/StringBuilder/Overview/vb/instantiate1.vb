' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Text

Module Example8
    Public Sub Main()
        Dim value As String = "An ordinary string"
        Dim index As Integer = value.IndexOf("An ") + 3
        Dim capacity As Integer = &HFFFF

        ' Instantiate a StringBuilder from a string.
        Dim sb1 As New StringBuilder(value)
        ShowSBInfo(sb1)

        ' Instantiate a StringBuilder from string and define a capacity.  
        Dim sb2 As New StringBuilder(value, capacity)
        ShowSBInfo(sb2)

        ' Instantiate a StringBuilder from substring and define a capacity.  
        Dim sb3 As New StringBuilder(value, index,
                                   value.Length - index,
                                   capacity)
        ShowSBInfo(sb3)
    End Sub

    Public Sub ShowSBInfo(sb As StringBuilder)
        Console.WriteLine()
        Console.WriteLine("Value: {0}", sb.ToString())
        For Each prop In sb.GetType().GetProperties
            If prop.GetIndexParameters().Length = 0 Then
                Console.Write("{0}: {1:N0}    ", prop.Name, prop.GetValue(sb))
            End If
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    Value: An ordinary string
'    Capacity: 18    MaxCapacity: 2,147,483,647    Length: 18
'    
'    Value: An ordinary string
'    Capacity: 65,535    MaxCapacity: 2,147,483,647    Length: 18
'    
'    Value: ordinary string
'    Capacity: 65,535    MaxCapacity: 2,147,483,647    Length: 15
' </Snippet6>

