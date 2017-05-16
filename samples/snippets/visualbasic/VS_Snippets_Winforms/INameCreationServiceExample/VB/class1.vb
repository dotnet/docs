'<Snippet1>
Imports System
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Globalization

Public Class NameCreationService
    Implements System.ComponentModel.Design.Serialization.INameCreationService

    Public Sub New()
    End Sub

'<Snippet2>
    ' Creates an identifier for a particular data type that does not conflict 
    ' with the identifiers of any components in the specified collection
    Public Function CreateName(ByVal container As System.ComponentModel.IContainer, ByVal dataType As System.Type) As String Implements INameCreationService.CreateName
        ' Create a basic type name string
        Dim baseName As String = dataType.Name
        Dim uniqueID As Integer = 1

        Dim unique As Boolean = False
        ' Continue to increment uniqueID numeral until a unique ID is located.
        While Not unique
            unique = True
            ' Check each component in the container for a matching 
            ' base type name and unique ID.
            Dim i As Integer
            For i = 0 To container.Components.Count - 1
                ' Check component name for match with unique ID string.
                If container.Components(i).Site.Name.StartsWith((baseName + uniqueID.ToString())) Then
                    ' If a match is encountered, set flag to recycle 
                    ' collection, increment ID numeral, and restart.
                    unique = False
                    uniqueID += 1
                    Exit For
                End If
            Next i
        End While

        Return baseName + uniqueID.ToString()
    End Function
'</Snippet2>

'<Snippet3>
    ' Returns whether the specified name contains 
    ' all valid character types.
    Public Function IsValidName(ByVal name As String) As Boolean Implements INameCreationService.IsValidName
        Dim i As Integer
        For i = 0 To name.Length - 1
            Dim ch As Char = name.Chars(i)
            Dim uc As UnicodeCategory = [Char].GetUnicodeCategory(ch)
            Select Case uc
                Case UnicodeCategory.UppercaseLetter, UnicodeCategory.LowercaseLetter, UnicodeCategory.TitlecaseLetter, UnicodeCategory.DecimalDigitNumber
                Case Else
                    Return False
            End Select
        Next i
        Return True
    End Function
'</Snippet3>

'<Snippet4>
    ' Throws an exception if the specified name does not contain 
    ' all valid character types.
    Public Sub ValidateName(ByVal name As String) Implements INameCreationService.ValidateName
        Dim i As Integer
        For i = 0 To name.Length - 1
            Dim ch As Char = name.Chars(i)
            Dim uc As UnicodeCategory = [Char].GetUnicodeCategory(ch)
            Select Case uc
                Case UnicodeCategory.UppercaseLetter, UnicodeCategory.LowercaseLetter, UnicodeCategory.TitlecaseLetter, UnicodeCategory.DecimalDigitNumber
                Case Else
                    Throw New Exception("The name '" + name + "' is not a valid identifier.")
            End Select
        Next i
    End Sub
'</Snippet4>

End Class
'</Snippet1>