' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports System.Reflection
Imports Microsoft.VisualBasic

Public Class ValidXSD

    Public Shared Sub Main()

        Dim xsd As String = "example.xsd"

        Dim fs As FileStream
        Dim schema As XmlSchema
        Try
            fs = New FileStream(xsd, FileMode.Open)
            schema = XmlSchema.Read(fs, New ValidationEventHandler(AddressOf ShowCompileError))

            Dim schemaSet As New XmlSchemaSet()
            AddHandler schemaSet.ValidationEventHandler, AddressOf ShowCompileError

            schemaSet.Add(schema)
            schemaSet.Compile()

            Dim compiledSchema As XmlSchema = Nothing

            For Each schema1 As XmlSchema In schemaSet.Schemas()
                compiledSchema = schema1
            Next

            schema = compiledSchema

            If schema.IsCompiled Then
                DisplayObjects(schema)
            End If

        Catch e As XmlSchemaException
            Console.WriteLine("LineNumber = {0}", e.LineNumber)
            Console.WriteLine("LinePosition = {0}", e.LinePosition)
            Console.WriteLine("Message = {0}", e.Message)
            Console.WriteLine("Source = {0}", e.Source)

        End Try
    End Sub 'Main


    Private Overloads Shared Sub DisplayObjects(ByVal o As Object)
        DisplayObjects(o, "")
    End Sub 'DisplayObjects

    Private Overloads Shared Sub DisplayObjects(ByVal o As Object, ByVal indent As String)
        Console.WriteLine("{0}{1}", indent, o)

        Dim property1 As PropertyInfo
        For Each property1 In o.GetType().GetProperties()
            If property1.PropertyType.FullName = "System.Xml.Schema.XmlSchemaObjectCollection" Then

                Dim childObjectCollection As XmlSchemaObjectCollection = CType(property1.GetValue(o, Nothing), XmlSchemaObjectCollection)

                Dim schemaObject As XmlSchemaObject
                For Each schemaObject In childObjectCollection
                    DisplayObjects(schemaObject, indent + ControlChars.Tab)
                Next schemaObject
            End If
        Next property1
    End Sub 'DisplayObjects

    Private Shared Sub ShowCompileError(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Console.WriteLine("Validation Error: {0}", e.Message)
    End Sub 'ShowCompileError
End Class 'ValidXSD
' </Snippet1>
