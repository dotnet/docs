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
        Return Convert.ToString("ID: " & PartId & "   Name: ") & PartName
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
        Console.WriteLine(vbLf & "Contains: Part with Id=1734: {0}",
                          parts.Contains(New Part() With { _
             .PartId = 1734, _
             .PartName = "" _
        }))

        ' Find items where name contains "seat".
        Console.WriteLine(vbLf & "Find: Part where name contains ""seat"": {0}",
                          parts.Find(Function(x) x.PartName.Contains("seat")))

        ' Check if an item with Id 1444 exists.
        Console.WriteLine(vbLf & "Exists: Part with Id=1444: {0}",
                          parts.Exists(Function(x) x.PartId = 1444))

        'This code example produces the following output:
        '        
        '        ID: 1234   Name: crank arm
        '        ID: 1334   Name: chain ring
        '        ID: 1434   Name: regular seat
        '        ID: 1444   Name: banana seat
        '        ID: 1534   Name: cassette
        '        ID: 1634   Name: shift lever
        '
        '        Contains: Part with Id=1734: False
        '
        '        Find: Part where name contains "seat": ID: 1434   Name: regular seat
        '
        '        Exists: Part with Id=1444: True 
        '         

    End Sub
End Class
'</snippet1>



