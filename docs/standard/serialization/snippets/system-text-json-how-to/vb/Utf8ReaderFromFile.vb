'Imports System.IO
'Imports System.Text
'Imports System.Text.Json

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public NotInheritable Class Utf8ReaderFromFile
'        Private Shared ReadOnly s_nameUtf8 As Byte() = Encoding.UTF8.GetBytes("name")
'        Private Shared ReadOnly Property Utf8Bom As ReadOnlySpan(Of Byte)
'            Get
'                Return New Byte() {&HEF, &HBB, &HBF}
'            End Get
'        End Property
'        Public Shared Sub Run()
'            ' ReadAllBytes if the file encoding is UTF-8:
'            Dim fileName As String = "UniversitiesUtf8.json"
'            Dim jsonReadOnlySpan As ReadOnlySpan(Of Byte) = File.ReadAllBytes(fileName)

'            ' Read past the UTF-8 BOM bytes if a BOM exists.
'            If jsonReadOnlySpan.StartsWith(Utf8Bom) Then
'                jsonReadOnlySpan = jsonReadOnlySpan.Slice(Utf8Bom.Length)
'            End If

'            ' Or read as UTF-16 and transcode to UTF-8 to convert to a ReadOnlySpan<byte>
'            'string fileName = "Universities.json";
'            'string jsonString = File.ReadAllText(fileName);
'            'ReadOnlySpan<byte> jsonReadOnlySpan = Encoding.UTF8.GetBytes(jsonString);

'            Dim count As Integer = 0
'            Dim total As Integer = 0

'            Dim reader As Utf8JsonReader = New Utf8JsonReader(jsonReadOnlySpan)

'            While reader.Read()
'                Dim tokenType1 As JsonTokenType = reader.TokenType

'                Select Case tokenType1
'                    Case JsonTokenType.StartObject
'                        total += 1
'                    Case JsonTokenType.PropertyName
'                        If reader.ValueTextEquals(s_nameUtf8) Then
'                            ' Assume valid JSON, known schema
'                            reader.Read()
'                            If reader.GetString().EndsWith("University") Then
'                                count += 1
'                            End If
'                        End If
'                End Select
'            End While
'            Console.WriteLine($"{count} out of {total} have names that end with 'University'")
'        End Sub
'    End Class
'End Namespace
