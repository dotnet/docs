'Imports System.Text
'Imports System.Text.Json

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public NotInheritable Class ValueTextEqualsExample
'        ' <DefineUtf8Var>
'        Private Shared ReadOnly s_nameUtf8 As Byte() = Encoding.UTF8.GetBytes("name")
'        ' </DefineUtf8Var>
'        Public Shared Sub Run(jsonReadOnlySpan As ReadOnlySpan(Of Byte))
'            Dim count As Integer = 0
'            Dim total As Integer = 0
'            Dim reader As Utf8JsonReader = New Utf8JsonReader(jsonReadOnlySpan)

'            ' <UseUtf8Var>
'            While reader.Read()
'                Select Case reader.TokenType
'                    Case JsonTokenType.StartObject
'                        total += 1
'                    Case JsonTokenType.PropertyName
'                        If reader.ValueTextEquals(s_nameUtf8) Then
'                            count += 1
'                        End If
'                End Select
'            End While
'            ' </UseUtf8Var>
'            Console.WriteLine($"{count} out of {total} have ""name"" properties""name"" properties")
'        End Sub
'    End Class
'End Namespace
