Imports System.Data.Linq
Imports System.Data.Linq.Mapping


Module Module1

    Sub Main()

    End Sub

End Module

' <Snippet1>
Public Enum ShapeType As Integer
    Square = 0
    Circle = 1
End Enum

<Table(Name:="Shape")> _
<InheritanceMapping(Code:=ShapeType.Square, Type:=GetType(Square), _
    IsDefault:=True)> _
<InheritanceMapping(Code:=ShapeType.Circle, Type:=GetType(Circle))> _
Public MustInherit Class Shape
    <Column(IsDiscriminator:=True)> _
        Public ShapeType As ShapeType = 0
End Class

Public Class Square
    Inherits Shape
    <Column()> _
    Public Side As Integer = 0
End Class

Public Class Circle
    Inherits Shape
    <Column()> _
    Public Radius As Integer = 0
End Class
' </Snippet1>

' <Snippet2>
' Unmapped and not queryable.
Class A
End Class

' Mapped and queryable.
<Table()> _
<InheritanceMapping(Code:="B", Type:=GetType(B), _
IsDefault:=True)> _
<InheritanceMapping(Code:="D", Type:=GetType(D))> _
Class B
    Inherits A
End Class

' Unmapped and not queryable.
Class C
    Inherits B
End Class

' Mapped and queryable.
Class D
    Inherits C
End Class

' Unmapped and not queryable.
Class E
    Inherits D
End Class
' </Snippet2>




