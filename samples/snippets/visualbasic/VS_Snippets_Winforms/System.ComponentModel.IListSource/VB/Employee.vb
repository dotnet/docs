' <snippet10>
Imports System.ComponentModel

Public Class Employee
    Inherits BusinessObjectBase

    Private _id As String
    Private _name As String
    Private _parkingId As Decimal

    Public Sub New(ByVal name As String, ByVal parkId As Decimal)
        MyBase.New()
        Me._id = System.Guid.NewGuid().ToString()
        ' Set values
        Me.Name = name
        Me.ParkingID = parkId
    End Sub

    Public ReadOnly Property ID() As String
        Get
            Return _id
        End Get
    End Property

    Const NAME_Const As String = "Name"

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            If _name <> value Then
                _name = value
                OnPropertyChanged(NAME_Const)
            End If
        End Set
    End Property

    Const PARKINGID_Const As String = "ParkingID"

    Public Property ParkingID() As Decimal
        Get
            Return _parkingId
        End Get
        Set(ByVal value As Decimal)
            If _parkingId <> value Then
                _parkingId = value
                OnPropertyChanged(PARKINGID_Const)
            End If
        End Set
    End Property

End Class
' </snippet10>