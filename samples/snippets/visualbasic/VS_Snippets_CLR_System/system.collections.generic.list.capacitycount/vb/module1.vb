'<snippet1>
Imports System.Collections.Generic
' Simple business object. A PartId is used to identify a part 
' but the part name can change.
Public Class Part
    Implements IEquatable(Of Part)
    Public Property PartName() As String
        Get
            Return m_PartName
        End Get
        Set(value As String)
            m_PartName = Value
        End Set
    End Property
    Private m_PartName As String
    Public Property PartId() As Integer
        Get
            Return m_PartId
        End Get
        Set(value As Integer)
            m_PartId = Value
        End Set
    End Property
    Private m_PartId As Integer
    Public Overrides Function ToString() As String
        Return "ID: " & PartId & "   Name: " & PartName
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then
            Return False
        End If
        Dim objAsPart As Part = TryCast(obj, Part)
        If objAsPart Is Nothing Then
            Return False
        Else
            Return Equals(objAsPart)
        End If
    End Function
    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function
    Public Overloads Function Equals(other As Part) As Boolean Implements IEquatable(Of Part).Equals
        If other Is Nothing Then
            Return False
        End If
        Return (Me.PartId.Equals(other.PartId))
    End Function
    ' Should also override == and != operators.

End Class
Public Class Example

    Public Shared Sub Main()
        Dim parts As New List(Of Part)()

        Console.WriteLine(vbLf & "Capacity: {0}", parts.Capacity)

        ' Add parts to the list.
        parts.Add(New Part() With { _
             .PartName = "crank arm", _
             .PartId = 1234 _
        })
        parts.Add(New Part() With { _
             .PartName = "chain ring", _
             .PartId = 1334 _
        })
        parts.Add(New Part() With { _
             .PartName = "regular seat", _
             .PartId = 1434 _
        })
        parts.Add(New Part() With { _
             .PartName = "banana seat", _
             .PartId = 1444 _
        })
        parts.Add(New Part() With { _
             .PartName = "cassette", _
             .PartId = 1534 _
        })
        parts.Add(New Part() With { _
             .PartName = "shift lever", _
             .PartId = 1634 _
        })



        Console.WriteLine()
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next

        Console.WriteLine(vbLf & "Capacity: {0}", parts.Capacity)
        Console.WriteLine("Count: {0}", parts.Count)

        parts.TrimExcess()
        Console.WriteLine(vbLf & "TrimExcess()")
        Console.WriteLine("Capacity: {0}", parts.Capacity)
        Console.WriteLine("Count: {0}", parts.Count)

        parts.Clear()
        Console.WriteLine(vbLf & "Clear()")
        Console.WriteLine("Capacity: {0}", parts.Capacity)
        Console.WriteLine("Count: {0}", parts.Count)
    End Sub
    '
    '     This code example produces the following output. 
    '            Capacity: 0
    '
    '            ID: 1234   Name: crank arm
    '            ID: 1334   Name: chain ring
    '            ID: 1434   Name: seat
    '            ID: 1534   Name: cassette
    '            ID: 1634   Name: shift lever
    '
    '            Capacity: 8
    '            Count: 6
    '
    '            TrimExcess()
    '            Capacity: 6
    '            Count: 6
    '
    '            Clear()
    '            Capacity: 6
    '            Count: 0
    '     

End Class
'</snippet1>

