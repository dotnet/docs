'<snippet00>
Imports System.Windows.Forms
Imports System.Collections.Generic
'<snippet20>
Public Enum Title
    King
    Sir
End Enum
'</snippet20>
Public Class EnumsAndComboBox
    Inherits Form

    Private flow As New FlowLayoutPanel()
    Private WithEvents checkForChange As Button = New Button()
    Private knights As List(Of Knight)
    Private dataGridView1 As New DataGridView()

    Public Sub New()
        MyBase.New()
        SetupForm()
        SetupGrid()
    End Sub

    Private Sub SetupForm()
        AutoSize = True
    End Sub

    '<snippet10>
    Private Sub SetupGrid()
        knights = New List(Of Knight)
        knights.Add(New Knight(Title.King, "Uther", True))
        knights.Add(New Knight(Title.King, "Arthur", True))
        knights.Add(New Knight(Title.Sir, "Mordred", False))
        knights.Add(New Knight(Title.Sir, "Gawain", True))
        knights.Add(New Knight(Title.Sir, "Galahad", True))

        ' Initialize the DataGridView.
        dataGridView1.AutoGenerateColumns = False
        dataGridView1.AutoSize = True
        dataGridView1.DataSource = knights

        dataGridView1.Columns.Add(CreateComboBoxWithEnums())

        ' Initialize and add a text box column.
        Dim column As DataGridViewColumn = _
            New DataGridViewTextBoxColumn()
        column.DataPropertyName = "Name"
        column.Name = "Knight"
        dataGridView1.Columns.Add(column)

        ' Initialize and add a check box column.
        column = New DataGridViewCheckBoxColumn()
        column.DataPropertyName = "GoodGuy"
        column.Name = "Good"
        dataGridView1.Columns.Add(column)

        ' Initialize the form.
        Controls.Add(dataGridView1)
        Me.AutoSize = True
        Me.Text = "DataGridView object binding demo"
    End Sub

    Private Function CreateComboBoxWithEnums() As DataGridViewComboBoxColumn
        Dim combo As New DataGridViewComboBoxColumn()
        combo.DataSource = [Enum].GetValues(GetType(Title))
        combo.DataPropertyName = "Title"
        combo.Name = "Title"
        Return combo
    End Function

#Region "business object"
    Private Class Knight
        Private hisName As String
        Private good As Boolean
        Private hisTitle As Title

        Public Sub New(ByVal title As Title, ByVal name As String, _
            ByVal good As Boolean)

            hisTitle = title
            hisName = name
            Me.good = good
        End Sub

        Public Property Name() As String
            Get
                Return hisName
            End Get

            Set(ByVal Value As String)
                hisName = Value
            End Set
        End Property

        Public Property GoodGuy() As Boolean
            Get
                Return good
            End Get
            Set(ByVal Value As Boolean)
                good = Value
            End Set
        End Property

        Public Property Title() As Title
            Get
                Return hisTitle
            End Get
            Set(ByVal Value As Title)
                hisTitle = Value
            End Set
        End Property
    End Class
#End Region
    '</snippet10>

    Public Shared Sub Main()
        Application.Run(New EnumsAndComboBox())
    End Sub

End Class
'</snippet00>
