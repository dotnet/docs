 ' <snippet1>
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms


Public Class MyControl1
    Inherits System.Windows.Forms.UserControl
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private txtName As System.Windows.Forms.TextBox
    Private txtAddress As System.Windows.Forms.TextBox
    Private txtCity As System.Windows.Forms.TextBox
    Private txtState As System.Windows.Forms.TextBox
    Private txtZip As System.Windows.Forms.TextBox
    Private label6 As System.Windows.Forms.Label
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.IContainer = Nothing


    Public Sub New()

        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub

#Region "Component Designer generated code"

    ' <summary>
    ' Required method for Designer support - do not modify 
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' label1
        ' 
        Me.label1.Location = New System.Drawing.Point(20, 46)
        Me.label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 16)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Name"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ' 
        ' label2
        ' 
        Me.label2.Location = New System.Drawing.Point(20, 88)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(94, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Street Address"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ' 
        ' label3
        ' 
        Me.label3.Location = New System.Drawing.Point(20, 127)
        Me.label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(49, 13)
        Me.label3.TabIndex = 10
        Me.label3.Text = "City"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ' 
        ' label4
        ' 
        Me.label4.Location = New System.Drawing.Point(246, 127)
        Me.label4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(47, 13)
        Me.label4.TabIndex = 11
        Me.label4.Text = "State"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ' 
        ' label5
        ' 
        Me.label5.Location = New System.Drawing.Point(23, 167)
        Me.label5.Margin = New System.Windows.Forms.Padding(3, 3, 2, 3)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(46, 13)
        Me.label5.TabIndex = 12
        Me.label5.Text = "Zip"
        Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        ' 
        ' txtName
        ' 
        Me.txtName.Location = New System.Drawing.Point(135, 44)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(199, 20)
        Me.txtName.TabIndex = 0
        ' 
        ' txtAddress
        ' 
        Me.txtAddress.Location = New System.Drawing.Point(136, 84)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(198, 20)
        Me.txtAddress.TabIndex = 1
        ' 
        ' txtCity
        ' 
        Me.txtCity.Location = New System.Drawing.Point(136, 123)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.TabIndex = 2
        ' 
        ' txtState
        ' 
        Me.txtState.Location = New System.Drawing.Point(300, 123)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(33, 20)
        Me.txtState.TabIndex = 3
        ' 
        ' txtZip
        ' 
        Me.txtZip.Location = New System.Drawing.Point(135, 163)
        Me.txtZip.Margin = New System.Windows.Forms.Padding(1, 3, 3, 3)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.TabIndex = 4
        ' 
        ' btnOK
        ' 
        Me.btnOK.Location = New System.Drawing.Point(23, 207)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        ' 
        ' btnCancel
        ' 
        Me.btnCancel.Location = New System.Drawing.Point(157, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        ' 
        ' label6
        ' 
        Me.label6.Location = New System.Drawing.Point(66, 12)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(226, 23)
        Me.label6.TabIndex = 13
        Me.label6.Text = "Simple Windows Forms Control"
        Me.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        ' 
        ' MyControl1
        ' 
        Me.Controls.Add(label6)
        Me.Controls.Add(btnCancel)
        Me.Controls.Add(btnOK)
        Me.Controls.Add(txtZip)
        Me.Controls.Add(txtState)
        Me.Controls.Add(txtCity)
        Me.Controls.Add(txtAddress)
        Me.Controls.Add(txtName)
        Me.Controls.Add(label5)
        Me.Controls.Add(label4)
        Me.Controls.Add(label3)
        Me.Controls.Add(label2)
        Me.Controls.Add(label1)
        Me.Name = "MyControl1"
        Me.Size = New System.Drawing.Size(359, 244)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region


    ' <snippet2>
    Public Delegate Sub MyControlEventHandler(ByVal sender As Object, ByVal args As MyControlEventArgs)
    Public Event OnButtonClick As MyControlEventHandler
    ' </snippet2>

    ' <snippet4>
    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim retvals As New MyControlEventArgs(True, txtName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text)
        RaiseEvent OnButtonClick(Me, retvals)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim retvals As New MyControlEventArgs(False, txtName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZip.Text)
        RaiseEvent OnButtonClick(Me, retvals)

    End Sub
    ' </snippet4>
End Class

' <snippet3>
Public Class MyControlEventArgs
    Inherits EventArgs
    Private _Name As String
    Private _StreetAddress As String
    Private _City As String
    Private _State As String
    Private _Zip As String
    Private _IsOK As Boolean
    
    
    Public Sub New(ByVal result As Boolean, ByVal name As String, ByVal address As String, ByVal city As String, ByVal state As String, ByVal zip As String) 
        _IsOK = result
        _Name = name
        _StreetAddress = address
        _City = city
        _State = state
        _Zip = zip
    
    End Sub
    
    
    Public Property MyName() As String 
        Get
            Return _Name
        End Get
        Set
            _Name = value
        End Set
    End Property
    
    Public Property MyStreetAddress() As String 
        Get
            Return _StreetAddress
        End Get
        Set
            _StreetAddress = value
        End Set
    End Property
    
    Public Property MyCity() As String 
        Get
            Return _City
        End Get
        Set
            _City = value
        End Set
    End Property
    
    Public Property MyState() As String 
        Get
            Return _State
        End Get
        Set
            _State = value
        End Set
    End Property
    
    Public Property MyZip() As String 
        Get
            Return _Zip
        End Get
        Set
            _Zip = value
        End Set
    End Property
    
    Public Property IsOK() As Boolean 
        Get
            Return _IsOK
        End Get
        Set
            _IsOK = value
        End Set
    End Property
End Class
' </snippet3>
' </snippet1>