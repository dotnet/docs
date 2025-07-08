' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Text

Module Example9
    Public Sub Main()
        Dim rnd As New Random()
        Dim tempF() As String = {"47.6F", "51.3F", "49.5F", "62.3F"}
        Dim tempC() As String = {"21.2C", "16.1C", "23.5C", "22.9C"}
        Dim temps()() As String = {tempF, tempC}

        Dim sb As StringBuilder = New StringBuilder()
        Dim f As New StringBuilderFinder(sb, "F")
        Dim baseDate As New DateTime(2013, 5, 1)
        Dim temperatures() As String = temps(rnd.Next(2))
        Dim isFahrenheit As Boolean = False
        For Each temperature In temperatures
            If isFahrenheit Then
                sb.AppendFormat("{0:d}: {1}{2}", baseDate, temperature, vbCrLf)
            Else
                isFahrenheit = f.SearchAndAppend(String.Format("{0:d}: {1}{2}",
                                             baseDate, temperature, vbCrLf))
            End If
            baseDate = baseDate.AddDays(1)
        Next
        If isFahrenheit Then
            sb.Insert(0, "Average Daily Temperature in Degrees Fahrenheit")
            sb.Insert(47, vbCrLf + vbCrLf)
        Else
            sb.Insert(0, "Average Daily Temperature in Degrees Celsius")
            sb.Insert(44, vbCrLf + vbCrLf)
        End If
        Console.WriteLine(sb.ToString())
    End Sub
End Module

Public Class StringBuilderFinder
   Private sb As StringBuilder
   Private text As String
   
   Public Sub New(sb As StringBuilder, textToFind As String)
      Me.sb = sb
      text = textToFind
   End Sub
   
   Public Function SearchAndAppend(stringToSearch As String) As Boolean
      sb.Append(stringToSearch)
      Return stringToSearch.Contains(text)
   End Function
End Class
' The example displays output similar to the following:
'    Average Daily Temperature in Degrees Celsius
'    
'    5/1/2013: 21.2C
'    5/2/2013: 16.1C
'    5/3/2013: 23.5C
'    5/4/2013: 22.9C
' </Snippet12>
