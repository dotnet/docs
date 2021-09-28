' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Resources
Imports System.Windows.Forms

Public Class CarDisplayApp : Inherits Form
    Private Const resxFile As String = ".\CarResources.resx"
    Dim cars() As Automobile

    Public Shared Sub Main()
        Dim app As New CarDisplayApp()
        Application.Run(app)
    End Sub

    Public Sub New()
        ' Instantiate controls.
        Dim pictureBox As New PictureBox()
        pictureBox.Location = New Point(10, 10)
        Me.Controls.Add(pictureBox)
        Dim grid As New DataGridView()
        grid.Location = New Point(10, 60)
        Me.Controls.Add(grid)

        ' Get resources from .resx file.
        Using resxSet As New ResXResourceSet(resxFile)
            ' Retrieve the string resource for the title.
            Me.Text = resxSet.GetString("Title")
            ' Retrieve the image.
            Dim image As Icon = CType(resxSet.GetObject("Information", True), Icon)
            If image IsNot Nothing Then
                pictureBox.Image = image.ToBitmap()
            End If

            ' Retrieve Automobile objects.  
            Dim carList As New List(Of Automobile)
            Dim resName As String = "EarlyAuto"
            Dim auto As Automobile
            Dim ctr As Integer = 1
            Do
                auto = CType(resxSet.GetObject(resName + ctr.ToString()), Automobile)
                ctr += 1
                If auto IsNot Nothing Then carList.Add(auto)
            Loop While auto IsNot Nothing
            cars = carList.ToArray()
            grid.DataSource = cars
        End Using
    End Sub
End Class
' </Snippet3>


<Serializable()> Public Class Automobile
    Private carMake As String
    Private carModel As String
    Private carYear As Integer
    Private carDoors AS Integer
    Private carCylinders As Integer

    Public Sub New(make As String, model As String, year As Integer)
        Me.New(make, model, year, 0, 0)
    End Sub

    Public Sub New(make As String, model As String, year As Integer,
                   doors As Integer, cylinders As Integer)
        Me.carMake = make
        Me.carModel = model
        Me.carYear = year
        Me.carDoors = doors
        Me.carCylinders = cylinders
    End Sub

    Public ReadOnly Property Make As String
        Get
            Return Me.carMake
        End Get
    End Property

    Public ReadOnly Property Model As String
        Get
            Return Me.carModel
        End Get
    End Property

    Public ReadOnly Property Year As Integer
        Get
            Return Me.carYear
        End Get
    End Property

    Public ReadOnly Property Doors As Integer
        Get
            Return Me.carDoors
        End Get
    End Property

    Public ReadOnly Property Cylinders As Integer
        Get
            Return Me.carCylinders
        End Get
    End Property
End Class
