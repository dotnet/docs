' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports Microsoft.VisualBasic

Public Class ValidXSD
    Public Shared Sub Main()
        Dim fs As FileStream
        Dim schema As XmlSchema
        Try
            fs = New FileStream("example.xsd", FileMode.Open)
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
                ' Schema is successfully compiled. 
                ' Do something with it here.
            End If

        Catch e As XmlSchemaException
            Console.WriteLine("LineNumber = {0}", e.LineNumber)
            Console.WriteLine("LinePosition = {0}", e.LinePosition)
            Console.WriteLine("Message = {0}", e.Message)
            Console.WriteLine("Source = {0}", e.Source)

        End Try
    End Sub 'Main


    Private Shared Sub ShowCompileError(ByVal sender As Object, ByVal e As ValidationEventArgs)
        Console.WriteLine("Validation Error: {0}", e.Message)
    End Sub 'ShowCompileError
End Class 'ValidXSD
' </Snippet1>
