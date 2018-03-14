'<Snippet1>
<%@WebService Class="Streaming" language="VB"%>

Imports System
Imports System.IO
Imports System.Collections
Imports System.Xml.Serialization
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class Streaming 

    <WebMethod(BufferResponse:=False)> _
    Public Function GetTextFile(filename As String ) As TextFile
      Return New TextFile(filename)        
    End Function

    <WebMethod> _
    Public Sub CreateTextFile(contents As TextFile) 
        contents.Close()
    End Sub

End Class

Public Class TextFile 
    Public filename As String 
    Private readerWriter As TextFileReaderWriter 

    Public Sub New() 
    End Sub

    Public Sub New(filename As String) 
        Me.filename = filename
    End Sub

    <XmlArrayItem("line")> _
    Public ReadOnly Property contents As TextFileReaderWriter
        Get 
            readerWriter = New TextFileReaderWriter(filename)
            Return readerWriter
        End Get
    End Property

    Public Sub Close() 
        If Not (readerWriter Is Nothing) Then
	  readerWriter.Close()
        End If
    End Sub
End Class

Public Class TextFileReaderWriter 
   Implements IEnumerable 


    Public Filename As String 
    Private writer As StreamWriter 

    Public Sub New() 
    End Sub

    Public Sub New(myfilename As String ) 
        Filename = myfilename
    End Sub

    Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Dim reader As StreamReader = New StreamReader(Filename)
        Return New TextFileEnumerator(reader)
    End Function

    Public Sub Add(line As String) 
        If (writer Is Nothing) Then
            writer = New StreamWriter(Filename)
	End If
        writer.WriteLine(line)
    End Sub

    Public Sub Add(obj as Object)
	
    End Sub

    Public Sub Close() 
        If Not (writer Is Nothing) Then writer.Close()
    End Sub

End Class

Public Class TextFileEnumerator 
  Implements IEnumerator 
    Private currentLine As String
    Private reader As StreamReader

    Public Sub New(reader As StreamReader) 
        Me.reader = reader
    End Sub

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        currentLine = reader.ReadLine()
        If (currentLine Is Nothing) Then
            reader.Close()
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Reset() Implements IEnumerator.Reset
        reader.BaseStream.Position = 0
    End Sub

    ReadOnly Property Current As object Implements IEnumerator.Current
        Get 
            Return CurrentLine
        End Get
    End Property
End Class
'</Snippet1>