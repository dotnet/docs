Imports System
Imports System.Runtime.Serialization


' <Snippet1>
' A serializable LinkedList example.  For the full LinkedList implementation
' see the Serialization sample.
<Serializable()> Class LinkedList
    Implements ISerializable

    Public Shared Sub Main()
    End Sub

    Private m_head As Node = Nothing
    Private m_tail As Node = Nothing    
    
    ' Serializes the object.
    Public Sub GetObjectData(info As SerializationInfo, _
    context As StreamingContext) Implements ISerializable.GetObjectData
    
        ' Stores the m_head and m_tail references in the SerializationInfo info.
        info.AddValue("head", m_head, m_head.GetType())
        info.AddValue("tail", m_tail, m_tail.GetType())
    End Sub
    
    
    ' Constructor that is called automatically during deserialization.
    ' Reconstructs the object from the information in SerializationInfo info.
    Private Sub New(info As SerializationInfo, context As StreamingContext)
        Dim temp As New Node(0)
        ' Retrieves the values of Type temp.GetType() from SerializationInfo info.
        m_head = CType(info.GetValue("head", temp.GetType()), Node)
        m_tail = CType(info.GetValue("tail", temp.GetType()), Node)
    End Sub
End Class
' </Snippet1>

' Class added so sample will compile
Class Node    
    Public Sub New(i As Integer)
    End Sub
End Class
