'<snippet000>
Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.Windows.Forms

'<snippet100>
Public Class Form1
    Inherits Form

    Private employees As New List(Of Employee)
    Private tasks As New List(Of Task)
    Private WithEvents reportButton As New Button
    Private WithEvents dataGridView1 As New DataGridView

    <STAThread()> _
    Public Sub Main()
        Application.Run(New Form1)
    End Sub

    Sub New()
        dataGridView1.Dock = DockStyle.Fill
        dataGridView1.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells
        reportButton.Text = "Generate Report"
        reportButton.Dock = DockStyle.Top

        Controls.Add(dataGridView1)
        Controls.Add(reportButton)
        Text = "DataGridViewComboBoxColumn Demo"
    End Sub

    ' Initializes the data source and populates the DataGridView control.
    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Me.Load

        PopulateLists()
        dataGridView1.AutoGenerateColumns = False
        dataGridView1.DataSource = tasks
        AddColumns()

    End Sub

    ' Populates the employees and tasks lists. 
    Private Sub PopulateLists()
        employees.Add(New Employee("Harry"))
        employees.Add(New Employee("Sally"))
        employees.Add(New Employee("Roy"))
        employees.Add(New Employee("Pris"))
        tasks.Add(New Task(1, employees(1)))
        tasks.Add(New Task(2))
        tasks.Add(New Task(3, employees(2)))
        tasks.Add(New Task(4))
    End Sub

    ' Configures columns for the DataGridView control.
    Private Sub AddColumns()

        Dim idColumn As New DataGridViewTextBoxColumn()
        idColumn.Name = "Task"
        idColumn.DataPropertyName = "Id"
        idColumn.ReadOnly = True

        '<snippet110>
        Dim assignedToColumn As New DataGridViewComboBoxColumn()

        ' Populate the combo box drop-down list with Employee objects. 
        For Each e As Employee In employees
            assignedToColumn.Items.Add(e)
        Next

        ' Add "unassigned" to the drop-down list and display it for 
        ' empty AssignedTo values or when the user presses CTRL+0. 
        assignedToColumn.Items.Add("unassigned")
        assignedToColumn.DefaultCellStyle.NullValue = "unassigned"
        '</snippet110>

        assignedToColumn.Name = "Assigned To"
        assignedToColumn.DataPropertyName = "AssignedTo"
        assignedToColumn.AutoComplete = True
        '<snippet115>
        assignedToColumn.DisplayMember = "Name"
        assignedToColumn.ValueMember = "Self"
        '</snippet115>

        ' Add a button column. 
        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = ""
        buttonColumn.Name = "Status Request"
        buttonColumn.Text = "Request Status"
        buttonColumn.UseColumnTextForButtonValue = True

        dataGridView1.Columns.Add(idColumn)
        dataGridView1.Columns.Add(assignedToColumn)
        dataGridView1.Columns.Add(buttonColumn)

    End Sub

    ' Reports on task assignments. 
    Private Sub reportButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles reportButton.Click

        Dim report As New StringBuilder()
        For Each t As Task In tasks
            Dim assignment As String
            If t.AssignedTo Is Nothing Then
                assignment = "unassigned"
            Else
                assignment = "assigned to " + t.AssignedTo.Name
            End If
            report.AppendFormat("Task {0} is {1}.", t.Id, assignment)
            report.Append(Environment.NewLine)
        Next
        MessageBox.Show(report.ToString(), "Task Assignments")

    End Sub

    ' Calls the Employee.RequestStatus method.
    Private Sub dataGridView1_CellClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellClick

        ' Ignore clicks that are not on button cells. 
        If e.RowIndex < 0 OrElse Not e.ColumnIndex = _
            dataGridView1.Columns("Status Request").Index Then Return

        ' Retrieve the task ID.
        Dim taskID As Int32 = CInt(dataGridView1(0, e.RowIndex).Value)

        '<snippet120>
        ' Retrieve the Employee object from the "Assigned To" cell.
        Dim assignedTo As Employee = TryCast(dataGridView1.Rows(e.RowIndex) _
            .Cells("Assigned To").Value, Employee)
        '</snippet120>

        ' Request status through the Employee object if present. 
        If assignedTo IsNot Nothing Then
            assignedTo.RequestStatus(taskID)
        Else
            MessageBox.Show(String.Format( _
                "Task {0} is unassigned.", taskID), "Status Request")
        End If

    End Sub

End Class
'</snippet100>

'<snippet200>
Public Class Task

    Sub New(ByVal id As Int32)
        idValue = id
    End Sub

    Sub New(ByVal id As Int32, ByVal assignedTo As Employee)
        idValue = id
        assignedToValue = assignedTo
    End Sub

    Private idValue As Int32
    Public Property Id() As Int32
        Get
            Return idValue
        End Get
        Set(ByVal value As Int32)
            idValue = value
        End Set
    End Property

    Private assignedToValue As Employee
    Public Property AssignedTo() As Employee
        Get
            Return assignedToValue
        End Get
        Set(ByVal value As Employee)
            assignedToValue = value
        End Set
    End Property

End Class
'</snippet200>

'<snippet300>
Public Class Employee

    Sub New(ByVal name As String)
        nameValue = name
    End Sub

    Private nameValue As String
    Public Property Name() As String
        Get
            Return nameValue
        End Get
        Set(ByVal value As String)
            nameValue = value
        End Set
    End Property

    '<snippet310>
    Public ReadOnly Property Self() As Employee
        Get
            Return Me
        End Get
    End Property
    '</snippet310>

    Public Sub RequestStatus(ByVal taskID As Int32)
        MessageBox.Show(String.Format( _
            "Status for task {0} has been requested from {1}.", _
            taskID, nameValue), "Status Request")
    End Sub

End Class
'</snippet300>
'</snippet000>