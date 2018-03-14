Option Strict On
'<Snippet1>
Imports System.IO
Imports System.Dynamic
'</Snippet1>

'<Snippet2>
Public Enum StringSearchOption
    StartsWith
    Contains
    EndsWith
End Enum
'</Snippet2>

'<Snippet3>
Public Class ReadOnlyFile
    Inherits DynamicObject
    '</Snippet3>

    '<Snippet4>
    ' Store the path to the file and the initial line count value.
    Private p_filePath As String

    ' Public constructor. Verify that file exists and store the path in 
    ' the private variable.
    Public Sub New(ByVal filePath As String)
        If Not File.Exists(filePath) Then
            Throw New Exception("File path does not exist.")
        End If

        p_filePath = filePath
    End Sub
    '</Snippet4>

    '<Snippet6>
    ' Implement the TryGetMember method of the DynamicObject class for dynamic member calls.
    Public Overrides Function TryGetMember(ByVal binder As GetMemberBinder,
                                           ByRef result As Object) As Boolean
        result = GetPropertyValue(binder.Name)
        Return If(result Is Nothing, False, True)
    End Function
    '</Snippet6>

    '<Snippet7>
    ' Implement the TryInvokeMember method of the DynamicObject class for 
    ' dynamic member calls that have arguments.
    Public Overrides Function TryInvokeMember(ByVal binder As InvokeMemberBinder,
                                              ByVal args() As Object,
                                              ByRef result As Object) As Boolean

        Dim StringSearchOption As StringSearchOption = StringSearchOption.StartsWith
        Dim trimSpaces = True

        Try
            If args.Length > 0 Then StringSearchOption = CType(args(0), StringSearchOption)
        Catch
            Throw New ArgumentException("StringSearchOption argument must be a StringSearchOption enum value.")
        End Try

        Try
            If args.Length > 1 Then trimSpaces = CType(args(1), Boolean)
        Catch
            Throw New ArgumentException("trimSpaces argument must be a Boolean value.")
        End Try

        result = GetPropertyValue(binder.Name, StringSearchOption, trimSpaces)

        Return If(result Is Nothing, False, True)
    End Function
    '</Snippet7>

    '<Snippet5>
    Public Function GetPropertyValue(ByVal propertyName As String,
                                     Optional ByVal StringSearchOption As StringSearchOption = StringSearchOption.StartsWith,
                                     Optional ByVal trimSpaces As Boolean = True) As List(Of String)

        Dim sr As StreamReader = Nothing
        Dim results As New List(Of String)
        Dim line = ""
        Dim testLine = ""

        Try
            sr = New StreamReader(p_filePath)

            While Not sr.EndOfStream
                line = sr.ReadLine()

                ' Perform a case-insensitive search by using the specified search options.
                testLine = UCase(line)
                If trimSpaces Then testLine = Trim(testLine)

                Select Case StringSearchOption
                    Case StringSearchOption.StartsWith
                        If testLine.StartsWith(UCase(propertyName)) Then results.Add(line)
                    Case StringSearchOption.Contains
                        If testLine.Contains(UCase(propertyName)) Then results.Add(line)
                    Case StringSearchOption.EndsWith
                        If testLine.EndsWith(UCase(propertyName)) Then results.Add(line)
                End Select
            End While
        Catch
            ' Trap any exception that occurs in reading the file and return Nothing.
            results = Nothing
        Finally
            If sr IsNot Nothing Then sr.Close()
        End Try

        Return results
    End Function
    '</Snippet5>
End Class
