'<snippet1>
Imports System.Collections.Generic

' Simple business object. A PartId is used to identify the type of part 
' but the part name can change. 
Public Class Part
    Implements IEquatable(Of Part)
    Implements IComparable(Of Part)
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

    Public Function SortByNameAscending(name1 As String, name2 As String) As Integer

        Return name1.CompareTo(name2)
    End Function

    ' Default comparer for Part.
    Public Function CompareTo(comparePart As Part) As Integer _
            Implements IComparable(Of ListSortVB.Part).CompareTo
        ' A null value means that this object is greater.
        If comparePart Is Nothing Then
            Return 1
        Else

            Return Me.PartId.CompareTo(comparePart.PartId)
        End If
    End Function
    Public Overrides Function GetHashCode() As Integer
        Return PartId
    End Function
    Public Overloads Function Equals(other As Part) As Boolean Implements IEquatable(Of ListSortVB.Part).Equals
        If other Is Nothing Then
            Return False
        End If
        Return (Me.PartId.Equals(other.PartId))
    End Function
    ' Should also override == and != operators.

End Class
Public Class Example
    Public Shared Sub Main()
        ' Create a list of parts.
        Dim parts As New List(Of Part)()

        ' Add parts to the list.
        parts.Add(New Part() With { _
             .PartName = "regular seat", _
             .PartId = 1434 _
        })
        parts.Add(New Part() With { _
             .PartName = "crank arm", _
             .PartId = 1234 _
        })
        parts.Add(New Part() With { _
             .PartName = "shift lever", _
             .PartId = 1634 _
        })


        ' Name intentionally left null.
        parts.Add(New Part() With { _
             .PartId = 1334 _
        })
        parts.Add(New Part() With { _
             .PartName = "banana seat", _
             .PartId = 1444 _
        })
        parts.Add(New Part() With { _
             .PartName = "cassette", _
             .PartId = 1534 _
        })


        ' Write out the parts in the list. This will call the overridden 
        ' ToString method in the Part class.
        Console.WriteLine(vbLf & "Before sort:")
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next


        ' Call Sort on the list. This will use the 
        ' default comparer, which is the Compare method 
        ' implemented on Part.
        parts.Sort()


        Console.WriteLine(vbLf & "After sort by part number:")
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next

        ' This shows calling the Sort(Comparison(T) overload using 
        ' an anonymous delegate method. 
        ' This method treats null as the lesser of two values.
        parts.Sort(Function(x As Part, y As Part)
                       If x.PartName Is Nothing AndAlso y.PartName Is Nothing Then
                           Return 0
                       ElseIf x.PartName Is Nothing Then
                           Return -1
                       ElseIf y.PartName Is Nothing Then
                           Return 1
                       Else
                           Return x.PartName.CompareTo(y.PartName)
                       End If
                   End Function)


        Console.WriteLine(vbLf & "After sort by name:")
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next

        '
        '        
        '            Before sort:
        '            ID: 1434   Name: regular seat
        '            ID: 1234   Name: crank arm
        '            ID: 1634   Name: shift lever
        '            ID: 1334   Name:
        '            ID: 1444   Name: banana seat
        '            ID: 1534   Name: cassette
        '
        '            After sort by part number:
        '            ID: 1234   Name: crank arm
        '            ID: 1334   Name:
        '            ID: 1434   Name: regular seat
        '            ID: 1444   Name: banana seat
        '            ID: 1534   Name: cassette
        '            ID: 1634   Name: shift lever
        '
        '            After sort by name:
        '            ID: 1334   Name:
        '            ID: 1444   Name: banana seat
        '            ID: 1534   Name: cassette
        '            ID: 1234   Name: crank arm
        '            ID: 1434   Name: regular seat
        '            ID: 1634   Name: shift lever

    End Sub
End Class
'</snippet1>


