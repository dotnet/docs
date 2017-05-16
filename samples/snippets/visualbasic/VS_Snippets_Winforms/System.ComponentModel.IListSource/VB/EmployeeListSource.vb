' <snippet1>
Imports System.ComponentModel

Public Class EmployeeListSource
    Inherits Component
    Implements IListSource

    <System.Diagnostics.DebuggerNonUserCode()> _
Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    ' <snippet2>
#Region "IListSource Members"

    ' <snippet3>
    Public ReadOnly Property ContainsListCollection() As Boolean Implements System.ComponentModel.IListSource.ContainsListCollection
        Get
            Return False
        End Get
    End Property
    ' </snippet3>

    ' <snippet4>
    Public Function GetList() As System.Collections.IList Implements System.ComponentModel.IListSource.GetList

        Dim ble As New BindingList(Of Employee)

        If Not Me.DesignMode Then
            ble.Add(New Employee("Aaberg, Jesper", 26000000))
            ble.Add(New Employee("Cajhen, Janko", 19600000))
            ble.Add(New Employee("Furse, Kari", 19000000))
            ble.Add(New Employee("Langhorn, Carl", 16000000))
            ble.Add(New Employee("Todorov, Teodor", 15700000))
            ble.Add(New Employee("Verebélyi, Ágnes", 15700000))
        End If

        Return ble

    End Function
    ' </snippet4>

#End Region
    ' </snippet2>

End Class
' </snippet1>