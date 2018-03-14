' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports Microsoft.VisualBasic

Public Class SchemaCollectionSample
    Private doc1 As String = "booksSchema.xml"
    Private doc2 As String = "booksSchemaFail.xml"
    Private doc3 As String = "newbooks.xml"
    Private schema As String = "books.xsd"
    Private schema1 As String = "schema1.xdr"
    
    Private reader As XmlTextReader = Nothing
    Private vreader As XmlValidatingReader = Nothing
    Private m_success As Boolean = True
    
    Public Sub New()

            'Load the schema collection
            Dim xsc As New XmlSchemaCollection()
            xsc.Add("urn:bookstore-schema", schema) 'XSD schema
            xsc.Add("urn:newbooks-schema", schema1) 'XDR schema

            'Validate the files using schemas stored in the collection.
            Validate(doc1, xsc) 'Should pass.
            Validate(doc2, xsc) 'Should fail.   
            Validate(doc3, xsc) 'Should fail. 
        
    End Sub 'New
    
    Public Shared Sub Main()
        Dim validation As New SchemaCollectionSample()
    End Sub 'Main
    
    Private Sub Validate(filename As String, xsc As XmlSchemaCollection)
        
            m_success = True
            Console.WriteLine()
            Console.WriteLine("Validating XML file {0}...", filename.ToString())
            reader = New XmlTextReader(filename)
            
            'Create a validating reader.
            vreader = New XmlValidatingReader(reader)
            
            'Use the schemas stored in the schema collection.
            vreader.Schemas.Add(xsc)
            
            'Set the validation event handler.
            AddHandler vreader.ValidationEventHandler, AddressOf ValidationCallBack
            'Read and validate the XML data.
            While vreader.Read()
            End While
            Console.WriteLine("Validation finished. Validation {0}", IIf(m_success, "successful", "failed"))
            Console.WriteLine()

            'Close the reader.
            vreader.Close()

    End Sub 'Validate
       
    
    Private Sub ValidationCallBack(sender As Object, args As ValidationEventArgs)
        m_success = False
        
        Console.Write((ControlChars.CrLf & ControlChars.Tab & "Validation error: " & args.Message))
    End Sub 'ValidationCallBack 
End Class 'SchemaCollectionSample
' </Snippet1>