Option Explicit On
Option Strict On

Imports System
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server
Imports System.Text

'<Snippet1>
<Serializable(), SqlUserDefinedTypeAttribute(Format.Native, _
  IsByteOrdered:=True, _
  Name:="Point", _
  ValidationMethodName:="ValidatePoint")> _
  Public Structure Point
    Implements INullable
'</Snippet1>
    Private is_Null As Boolean
    Private _x As Int32
    Private _y As Int32

    Public ReadOnly Property IsNull() As Boolean _
       Implements INullable.IsNull
        Get
            Return (is_Null)
        End Get
    End Property

    Public Shared ReadOnly Property Null() As Point
        Get
            Dim pt As New Point
            pt.is_Null = True
            Return (pt)
        End Get
    End Property

    ' Use StringBuilder to provide string representation of UDT.
    Public Overrides Function ToString() As String
        ' Since InvokeIfReceiverIsNull defaults to 'true'
        ' this test is unneccesary if Point is only being called
        ' from SQL.
        If Me.IsNull Then
            Return "NULL"
        Else
            Dim builder As StringBuilder = New StringBuilder
            builder.Append(_x)
            builder.Append(",")
            builder.Append(_y)
            Return builder.ToString
        End If
    End Function

    <SqlMethod(OnNullCall:=False)> _
    Public Shared Function Parse(ByVal s As SqlString) As Point
        ' With OnNullCall=False, this check is unnecessary if
        ' Point only being called from SQL.
        If s.IsNull Then
            Return Null
        End If

        ' Parse input string here to separate out points.
        Dim pt As New Point()
        Dim xy() As String = s.Value.Split(",".ToCharArray())
        pt.X = Int32.Parse(xy(0))
        pt.Y = Int32.Parse(xy(1))

        ' Call ValidatePoint to enforce validation
        ' for string conversions.
        If Not pt.ValidatePoint() Then
            Throw New ArgumentException("Invalid XY coordinate values.")
        End If
        Return pt
    End Function

    ' X and Y coordinates are exposed as properties.
    Public Property X() As Int32
        Get
            Return (Me._x)
        End Get

        Set(ByVal Value As Int32)
            Dim temp As Int32 = _x
            _x = Value
            If Not ValidatePoint() Then
                _x = temp
                Throw New ArgumentException("Invalid X coordinate value.")
            End If
        End Set
    End Property

    Public Property Y() As Int32
        Get
            Return (Me._y)
        End Get

        Set(ByVal Value As Int32)
            Dim temp As Int32 = _y
            _y = Value
            If Not ValidatePoint() Then
                _y = temp
                Throw New ArgumentException("Invalid Y coordinate value.")
            End If
        End Set
    End Property

    ' Validation method to enforce valid X and Y values.
    Private Function ValidatePoint() As Boolean
        ' Allow only zero or positive integers for X and Y coordinates.
        If (_x >= 0) And (_y >= 0) Then
            Return True
        Else
            Return False
        End If
    End Function


    
End Structure
