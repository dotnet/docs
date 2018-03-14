'------------------------------------------------------------------------------
'<Snippet2>
Imports System
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

<Serializable()>
<SqlUserDefinedAggregate(Format.Native)>
Public Structure CountVowels

    ' count only the vowels in the passed-in strings
    Private countOfVowels As SqlInt32


    Public Sub Init()
        countOfVowels = 0
    End Sub


    Public Sub Accumulate(ByVal value As SqlString)
        Dim stringChar As String
        Dim indexChar As Int32

        ' for each character in the given parameter
        For indexChar = 0 To Len(value.ToString()) - 1

            stringChar = value.ToString().Substring(indexChar, 1)

            If stringChar.ToLower() Like "[aeiou]" Then

                ' it is a vowel, increment the count
                countOfVowels = countOfVowels + 1
            End If
        Next
    End Sub


    Public Sub Merge(ByVal value As CountVowels)

        Accumulate(value.Terminate())
    End Sub


    Public Function Terminate() As SqlString

        Return countOfVowels.ToString()
    End Function
End Structure
'</Snippet2>


'------------------------------------------------------------------------------
'<Snippet6>
<SqlUserDefinedAggregate(Format.Native)>
Public Class SampleAggregate
    '...
End Class
'</Snippet6>
