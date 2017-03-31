' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports Microsoft.VisualBasic

Public Class Sample
    Private doc1 As String = "notValid.xml"
    Private doc2 As String = "cdDTD.xml"
    Private doc3 As String = "book1.xml"
    
    Private txtreader As XmlTextReader = Nothing
    Private reader As XmlValidatingReader = Nothing
    Private m_success As Boolean = True
    
    Public Sub New()
        'Parse the files and validate when requested.
        Validate(doc1, ValidationType.XDR) 'Validation should fail.
        Validate(doc2, ValidationType.DTD) 'Validation should fail.
        Validate(doc3, ValidationType.None) 'No validation performed.
    End Sub 'New
    
    Public Shared Sub Main()
        Dim validation As New Sample()
    End Sub 'Main
    
    Private Sub Validate(filename As String, vt As ValidationType)
        Try
            'Implement the readers.  Set the ValidationType.
            txtreader = New XmlTextReader(filename)
            reader = New XmlValidatingReader(txtreader)
            reader.ValidationType = vt
            
            'If the reader is set to validate, set the event handler.
            If vt = ValidationType.None Then
                Console.WriteLine(ControlChars.Cr & "Parsing XML file " & filename.ToString())
            Else
                Console.WriteLine(ControlChars.Cr & "Validating XML file " & filename.ToString())
                m_success = True
                'Set the validation event handler.
                AddHandler reader.ValidationEventHandler, AddressOf ValidationCallBack
            End If
            
            ' Read XML data
            While reader.Read()
            End While 
            If vt = ValidationType.None Then
                Console.WriteLine("Finished parsing file.")
            Else
                Console.WriteLine("Validation finished. Validation {0}", IIf(m_success, "successful", "failed"))
            End If
        
        Finally
            'Close the reader.
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try 
    End Sub 'Validate
    
    'Display the validation errors.
    Private Sub ValidationCallBack(sender As Object, args As ValidationEventArgs)
        m_success = False
        
        Console.Write(ControlChars.CrLf & ControlChars.Tab & "Validation error: " & args.Message)
    End Sub 'ValidationCallBack
End Class 'Sample
'</Snippet1>