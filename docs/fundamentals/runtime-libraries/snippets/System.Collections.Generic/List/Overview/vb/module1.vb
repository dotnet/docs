﻿'<snippet1>
Imports System.Collections.Generic

' Simple business object. A PartId is used to identify the type of part 
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
        Return PartId
    End Function
    Public Overloads Function Equals(other As Part) As Boolean _
        Implements IEquatable(Of Part).Equals
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



        ' Write out the parts in the list. This will call the overridden ToString method
        ' in the Part class.
        Console.WriteLine()
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next


        ' Check the list for part #1734. This calls the IEquatable.Equals method
        ' of the Part class, which checks the PartId for equality.
        Console.WriteLine(vbLf & "Contains(""1734""): {0}", parts.Contains(New Part() With { _
             .PartId = 1734, _
             .PartName = "" _
        }))

        ' Insert a new item at position 2.
        Console.WriteLine(vbLf & "Insert(2, ""1834"")")
        parts.Insert(2, New Part() With { _
             .PartName = "brake lever", _
             .PartId = 1834 _
        })


        'Console.WriteLine();
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next

        Console.WriteLine(vbLf & "Parts[3]: {0}", parts(3))

        Console.WriteLine(vbLf & "Remove(""1534"")")

        ' This will remove part 1534 even though the PartName is different,
        ' because the Equals method only checks PartId for equality.
        parts.Remove(New Part() With { _
             .PartId = 1534, _
             .PartName = "cogs" _
        })

        Console.WriteLine()
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next

        Console.WriteLine(vbLf & "RemoveAt(3)")
        ' This will remove part at index 3.
        parts.RemoveAt(3)

        Console.WriteLine()
        For Each aPart As Part In parts
            Console.WriteLine(aPart)
        Next
    End Sub
    '
    '        This example code produces the following output:
    '        ID: 1234   Name: crank arm
    '        ID: 1334   Name: chain ring
    '        ID: 1434   Name: regular seat
    '        ID: 1444   Name: banana seat
    '        ID: 1534   Name: cassette
    '        ID: 1634   Name: shift lever
    '
    '        Contains("1734"): False
    '
    '        Insert(2, "1834")
    '        ID: 1234   Name: crank arm
    '        ID: 1334   Name: chain ring
    '        ID: 1834   Name: brake lever
    '        ID: 1434   Name: regular seat
    '        ID: 1444   Name: banana seat
    '        ID: 1534   Name: cassette
    '        ID: 1634   Name: shift lever
    '
    '        Parts[3]: ID: 1434   Name: regular seat
    '
    '        Remove("1534")
    '
    '        ID: 1234   Name: crank arm
    '        ID: 1334   Name: chain ring
    '        ID: 1834   Name: brake lever
    '        ID: 1434   Name: regular seat
    '        ID: 1444   Name: banana seat
    '        ID: 1634   Name: shift lever
    '   '
    '        RemoveAt(3)
    '
    '        ID: 1234   Name: crank arm
    '        ID: 1334   Name: chain ring
    '        ID: 1834   Name: brake lever
    '        ID: 1444   Name: banana seat
    '        ID: 1634   Name: shift lever
    '        

End Class
'</snippet1>


