' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports Microsoft.VisualBasic

Public Class Sample
    
    Private txtreader As XmlTextReader = Nothing
    Private reader As XmlValidatingReader = Nothing
    Private m_success As Boolean = True
    
    Public Sub New()
        'Validate file against the XSD schema. 
        'The validation should fail.
        Validate("notValidXSD.xml")
    End Sub 'New
    
    Public Shared Sub Main()
        Dim validation As New Sample()
    End Sub 'Main
    
    Private Sub Validate(filename As String)
        Try
            Console.WriteLine("Validating XML file " & filename.ToString())
            txtreader = New XmlTextReader(filename)
            reader = New XmlValidatingReader(txtreader)
            
            ' Set the validation event handler
            AddHandler reader.ValidationEventHandler, AddressOf Me.ValidationEventHandle
            
            ' Read XML data
            While reader.Read()
            End While
            Console.WriteLine("Validation finished. Validation {0}", IIf(m_success, "successful", "failed"))
        
        Finally
            'Close the reader.
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Validate
     
    'Display the validation error.
    Private Sub ValidationEventHandle(sender As Object, args As ValidationEventArgs)
        m_success = False
        Console.WriteLine(ControlChars.CrLf & ControlChars.Tab & "Validation error: " & args.Message)
    End Sub 'ValidationEventHandle
End Class 'Sample
' </Snippet1>