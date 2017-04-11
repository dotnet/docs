' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization


' Three classes are included here. Each one will
' be used to create three XmlSerializer objects. 

Public Class Instrument
    Public InstrumentName As String
End Class

Public Class Player
    Public PlayerName As String
End Class

Public Class Piece
    Public PieceName As String
End Class

Public Class Test
    
    Public Shared Sub Main()
        Dim t As New Test()
        t.GetSerializers()
    End Sub    
    
    Public Sub GetSerializers()
        ' Create an array of types.
        Dim types(3) As Type
        types(0) = GetType(Instrument)
        types(1) = GetType(Player)
        types(2) = GetType(Piece)
        
        ' Create an array for XmlSerializer objects.
        Dim serializers(3) As XmlSerializer
        serializers = XmlSerializer.FromTypes(types)
        ' Create one Instrument and serialize it.
        Dim i As New Instrument()
        i.InstrumentName = "Piano"
        ' Create a TextWriter to write with.
        Dim writer As New StreamWriter("Inst.xml")
        serializers(0).Serialize(writer, i)
        writer.Close()
    End Sub
End Class

' </Snippet1>