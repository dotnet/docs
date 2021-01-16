'Imports System.Text.Json
'Imports System.Text.Json.Serialization

'Namespace SystemTextJsonSamples
'    '<Obsolete("Ignore", False)>
'    Public Class PersonConverterWithTypeDiscriminator
'        Inherits JsonConverter(Of Person)
'        Enum TypeDiscriminator
'            Customer = 1
'            Employee = 2
'        End Enum
'        Public Overrides Function CanConvert(typeToConvert As Type) As Boolean
'            Return GetType(Person).IsAssignableFrom(typeToConvert)
'        End Function
'        'Public Overrides Function Read(
'        '    ByRef reader As Utf8JsonReader, typeToConvert As Type, options As JsonSerializerOptions) As Person
'        '    If reader.TokenType <> JsonTokenType.StartObject Then
'        '        Throw New JsonException
'        '    End If

'        '    reader.Read()
'        '    If reader.TokenType <> JsonTokenType.PropertyName Then
'        '        Throw New JsonException
'        '    End If

'        '    Dim propertyName1 As String = reader.GetString()
'        '    If propertyName1 <> "TypeDiscriminator" Then
'        '        Throw New JsonException
'        '    End If

'        '    reader.Read()
'        '    If reader.TokenType <> JsonTokenType.Number Then
'        '        Throw New JsonException
'        '    End If

'        '    Dim typeDiscriminator1 As TypeDiscriminator = CType(reader.GetInt32(), TypeDiscriminator)

'        '    Dim person1 As Person
'        '    Select Case typeDiscriminator1
'        '        Case = TypeDiscriminator.Customer
'        '            person1 = New Customer
'        '        Case = TypeDiscriminator.Employee
'        '            person1 = New Employee
'        '        Case Else
'        '            Throw New JsonException
'        '    End Select


'        '    While reader.Read()
'        '        If reader.TokenType = JsonTokenType.EndObject Then
'        '            Return person1
'        '        End If

'        '        If reader.TokenType = JsonTokenType.PropertyName Then
'        '            propertyName1 = reader.GetString()
'        '            reader.Read()
'        '            Select Case propertyName1
'        '                Case "CreditLimit"
'        '                    Dim creditLimit As Decimal = reader.GetDecimal()
'        '                    CType(person1, Customer).CreditLimit = creditLimit
'        '                Case "OfficeNumber"
'        '                    Dim officeNumber As String = reader.GetString()
'        '                    CType(person1, Employee).OfficeNumber = officeNumber
'        '                Case "Name"
'        '                    Dim name As String = reader.GetString()
'        '                    person1.Name = name
'        '            End Select
'        '        End If
'        '    End While

'        '    Throw New JsonException
'        'End Function
'        Public Overrides Sub Write(
'            writer As Utf8JsonWriter, person1 As Person, options As JsonSerializerOptions)
'            writer.WriteStartObject()
'            Dim isEmployee As Boolean = TypeOf person1 Is Employee
'            Dim isCustomer As Boolean = TypeOf person1 Is Customer
'            If isCustomer Then
'                writer.WriteNumber("TypeDiscriminator", CInt(Fix(TypeDiscriminator.Customer)))
'                writer.WriteNumber("CreditLimit", CType(person1, Customer).CreditLimit)
'            ElseIf isEmployee Then
'                writer.WriteNumber("TypeDiscriminator", CInt(Fix(TypeDiscriminator.Employee)))
'                writer.WriteString("OfficeNumber", CType(person1, Employee).OfficeNumber)
'            End If

'            writer.WriteString("Name", person1.Name)

'            writer.WriteEndObject()
'        End Sub
'    End Class
'End Namespace
